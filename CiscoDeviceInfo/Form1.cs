using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Security;
using Lextm.SharpSnmpLib.Messaging;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;


namespace CiscoDeviceInfo
{
	public partial class Form1 : Form
	{
		private Thread threadGeneral;
		private BackgroundWorker bgWorkerChart;
		private AutoResetEvent bgWorkerChartComplete;
		private SnmpInterop snmp;
		DeviceConfigurationList storedDevices = new DeviceConfigurationList();
		FormConfigure frmConfig;

		public Form1()
		{
			InitializeComponent();
			
			dataGridInterfaces.DoubleBuffered(true);
            dataGridSwStack.DoubleBuffered(true);
			dataGridRoutes.DoubleBuffered(true);
			dataGridIPSec.DoubleBuffered(true);
			dataGridArp.DoubleBuffered(true);
			dataGridCDP.DoubleBuffered(true);

            // Remove tabs.
			ResetUI();

            // Load list of devices.
			RefreshDeviceList();

            // Version infromation.
            tooltipHyperlink.Text = "Version " + System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;
		}


		/// <summary>
		/// Deserializes the configuration and populates the combo box with the device list.
		/// </summary>
		private void RefreshDeviceList()
		{
			storedDevices.Devices.Clear();
			combDevices.Items.Clear();

			storedDevices = new DeviceConfigurationSerializer().DeSerializeObject(ConfigurationSettings.DeviceSettingsPath);

			foreach (DeviceConfiguration device in storedDevices.Devices)
			{
				combDevices.Items.Add(device.Name);
			}
		}


		/// <summary>
		/// Resets all tabs to a default position.
		/// </summary>
		private void ResetUI()
		{
			// Reset tab layout.
			tabPages.TabPages.Clear();
			tabPages.TabPages.Add(tabWelcome);
			tabPages.Refresh();
			progressThread.Value = 0;
			combDevices.Enabled = true;
		}


		/// <summary>
		/// Returns two LONG values, in and out octets for plotting.
		/// </summary>
		/// <param name="interfaceIndex"></param>
		/// <returns></returns>
		private long[] getInterfaceOctets(int interfaceIndex)
		{
			// Where our SNMP results are going.
			List<Variable> oidResults = new List<Variable>();

			ObjectIdentifier oidSpeed = new ObjectIdentifier(".1.3.6.1.2.1.2.2.1.5." + interfaceIndex);
			ObjectIdentifier oidType = new ObjectIdentifier(".1.3.6.1.2.1.2.2.1.3." + interfaceIndex);
			ObjectIdentifier oidInOctets = new ObjectIdentifier(".1.3.6.1.2.1.2.2.1.10. " + interfaceIndex);
			ObjectIdentifier oidOutOctets = new ObjectIdentifier(".1.3.6.1.2.1.2.2.1.16." + interfaceIndex);

			// OID's we're going to retrieve.
			List<Variable> oidList = new List<Variable>();
			oidList.Add(new Variable(oidSpeed));
			oidList.Add(new Variable(oidType));
			oidList.Add(new Variable(oidInOctets));
			oidList.Add(new Variable(oidOutOctets));

			long[] returnValue = new long[3];

			oidResults = snmp.GetOidValues(oidList);

			Integer32 vIfType = (Integer32)oidResults.Find(o => o.Id == oidType).Data;
			int dIfType = vIfType.ToInt32();

			Gauge32 guageIfSpeed = (Gauge32)oidResults.Find(o => o.Id == oidSpeed).Data;
			Variable vInOctets = oidResults.Find(o => o.Id == oidInOctets);
			Variable vOutOctets = oidResults.Find(o => o.Id == oidOutOctets);

			if (dIfType != 94 && dIfType != 117 && dIfType != 6 && dIfType != 131)
				return new long[] { 0, 0, 0 };

			if (vInOctets.Data.TypeCode == SnmpType.NoSuchInstance || vOutOctets.Data.TypeCode == SnmpType.NoSuchInstance)
			{
				return new long[] { 0, 0, 0 };
			}
			Counter32 counterInOctets = (Counter32)vInOctets.Data;
			Counter32 counterOutOctets = (Counter32)vOutOctets.Data;

			returnValue[0] = Convert.ToInt64(guageIfSpeed.ToUInt32());
			returnValue[1] = Convert.ToInt64(counterInOctets.ToString());
			returnValue[2] = Convert.ToInt64(counterOutOctets.ToString());

			return returnValue;
		}


		/// <summary>
		/// Plots interface throughput on the graph
		/// </summary>
		private void PlotInterfaceUsageWorker(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker bgWorker = sender as BackgroundWorker;
			Dictionary<int, string> intList = snmp.deviceInterfaces;
			Dictionary<int, long> intPrevOutOctets = new Dictionary<int, long>();
			Dictionary<int, long> intPrevInOctets = new Dictionary<int, long>();
			Dictionary<int, DateTime> intPrevCheck = new Dictionary<int, DateTime>();

			int waitSecods = 2; // Wait 1 second between polls
			bool bFirstPass = true;

			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(delegate { this.chartLine.Series.Clear(); }));
			}
			else
			{
				this.chartLine.Series.Clear();
			}

			//
			// Check the chart is on the screen and not the error label.
			if (!tableLayoutPanel3.Controls.Contains(chartLine))
			{
				if (InvokeRequired)
				{
					Invoke(new MethodInvoker(delegate { this.tableLayoutPanel3.Controls.Remove(this.lblGraphError); }));
					Invoke(new MethodInvoker(delegate { this.tableLayoutPanel3.Controls.Add(this.chartLine); }));
				}
				else
				{
					tableLayoutPanel3.Controls.Remove(lblGraphError);
					tableLayoutPanel3.Controls.Add(chartLine, 0, 0);
				}
			}

			//
			// Do the plotting.
			while (!bgWorker.CancellationPending)
			{
				// iterate over interfaces
				foreach (int i in intList.Keys)
				{
					if (bgWorker.CancellationPending)
					{
						bgWorkerChartComplete.Set();
						e.Cancel = true;
						return;
					}

					long[] intInfo = { 0, 0 };
					long dInOctets = 0;
					long dOutOctets = 0;
					long dPrevInOctets = 0;
					long dPrevOutOctets = 0;
					DateTime dPrevTimestamp;
					string szInterfaceName = intList[i];
					try
					{
						intInfo = getInterfaceOctets(i);

						// If we have previous data for this interface, get it.
						if (intPrevInOctets.Keys.Contains(i) && intPrevOutOctets.Keys.Contains(i))
						{
							dPrevInOctets = intPrevInOctets[i];
							dPrevOutOctets = intPrevOutOctets[i];
							dPrevTimestamp = intPrevCheck[i];
						}
						dInOctets = intInfo[1];
						dOutOctets = intInfo[2];
					}
					catch (Lextm.SharpSnmpLib.Messaging.TimeoutException)
					{
						if (InvokeRequired)
						{
							Invoke(new MethodInvoker(delegate { this.tableLayoutPanel3.Controls.Remove(this.chartLine); }));
							Invoke(new MethodInvoker(delegate { this.tableLayoutPanel3.Controls.Add(this.lblGraphError, 0, 0); }));
						}
						else
						{
							tableLayoutPanel3.Controls.Remove(chartLine);
							tableLayoutPanel3.Controls.Add(lblGraphError);
						}
						bgWorkerChartComplete.Set();
						e.Cancel = true;
						return;
					}
					catch
					{
						bgWorkerChartComplete.Set();
						e.Cancel = true;
						throw;
					}


					//
					// Add the series to the chart if it's not there already.
					if (null == chartLine.Series.FindByName(szInterfaceName))
					{
						// If we have no in+out octets, or the speed is 0 just move onto the next interface.
						if (intInfo[0] == 0)
							continue;

						Series seriesInt = new Series(szInterfaceName);
						seriesInt.ChartType = SeriesChartType.Line;
						seriesInt.XValueType = ChartValueType.Time;
						seriesInt.YValueType = ChartValueType.Auto;
						seriesInt.ToolTip = szInterfaceName;

						if (InvokeRequired)
						{
							Invoke(new MethodInvoker(delegate { this.chartLine.Series.Add(seriesInt); }));
						}
						else
						{
							this.chartLine.Series.Add(seriesInt);
						}
					}


					//
					// If this isn't the first pass then add some data to the graph.
					if (!bFirstPass && (dInOctets >= dPrevInOctets && dOutOctets >= dPrevOutOctets))
					{
						long dElapsedSec = Convert.ToInt64((DateTime.UtcNow - intPrevCheck[i]).TotalSeconds);
						double speed = (((dInOctets - dPrevInOctets) + (dOutOctets - dPrevOutOctets)) * 8 * 100) / dElapsedSec;
						speed /= 1048576; // 1048576 = 1 Megabyte

						// Is catching ObjectDisposedException the right thing to do here?
						try
						{
							if (InvokeRequired)
							{
								if (this.chartLine.Series[szInterfaceName].Points.Count >= 21)
									Invoke(new MethodInvoker(delegate { this.chartLine.Series[szInterfaceName].Points.Remove(this.chartLine.Series[szInterfaceName].Points.First()); }));

								Invoke(new MethodInvoker(delegate { this.chartLine.Series[szInterfaceName].Points.AddXY(DateTime.Now, speed); }));
							}
							else
							{
								if (this.chartLine.Series[szInterfaceName].Points.Count >= 21)
									chartLine.Series[szInterfaceName].Points.Remove(chartLine.Series[szInterfaceName].Points.First());

								chartLine.Series[szInterfaceName].Points.AddY(speed);
							}
						}
						catch (ObjectDisposedException)
						{
							return;
						}
						catch
						{
							throw;
						}
					}

					// Store this set of values ready for next iteration.
					intPrevInOctets[i] = intInfo[1];
					intPrevOutOctets[i] = intInfo[2];
					intPrevCheck[i] = DateTime.UtcNow;
				}

				// Finished with this round, wait before continuing.
				bFirstPass = false;
				if (bgWorker.CancellationPending)
				{
					bgWorkerChartComplete.Set();
					e.Cancel = true;
					return;
				}
				Thread.Sleep(waitSecods * 1000);
			}

			// Loop has finished so exit the BackgroundWorker.
			bgWorkerChartComplete.Set();
		}


		/// <summary>
		/// Method to be called in a thread to get SNMP information.
		/// </summary>
		private void ThreadSNMP()
		{
			// Reset progress bar.
			this.Invoke(new MethodInvoker(delegate { this.progressThread.Value = 0; }));

            // Disable list of devices.
            this.Invoke(new MethodInvoker(delegate { this.combDevices.Enabled = false; }));

			try
			{
				// General Tab
				this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabGeneral); }));
				Dictionary<string, string> dictBasicInfo = snmp.DictionaryBasicInfo();
				txtHostname.Invoke(new MethodInvoker(delegate { this.txtHostname.Text = dictBasicInfo["Hostname"]; }));
				txtUptime.Invoke(new MethodInvoker(delegate { this.txtUptime.Text = dictBasicInfo["Uptime"]; }));
				txtModel.Invoke(new MethodInvoker(delegate { this.txtModel.Text = dictBasicInfo["Model"]; }));
				txtSerial.Invoke(new MethodInvoker(delegate { this.txtSerial.Text = dictBasicInfo["Serial"]; }));
				txtContact.Invoke(new MethodInvoker(delegate { this.txtContact.Text = dictBasicInfo["Contact"]; }));
				txtLocation.Invoke(new MethodInvoker(delegate { this.txtLocation.Text = dictBasicInfo["Location"]; }));
				txtVersion.Invoke(new MethodInvoker(delegate { this.txtVersion.Text = dictBasicInfo["Version"]; }));
				this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));

				// IP addresses
				snmp.GetIPInterfaces();

				// Interface Tab
				DataTable dtInterfaces = snmp.DataTableInterfaces();
				this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabInterfaces); }));
				this.BeginInvoke(new MethodInvoker(delegate { this.dataGridInterfaces.DataSource = dtInterfaces; }));
				this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));

				// Switch Stack Tab
				DataTable dSwitchStack = snmp.DataTableSwitchStack();
				if (dSwitchStack.Rows.Count > 0)
				{
					this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabSwStack); }));
					this.BeginInvoke(new MethodInvoker(delegate { this.dataGridSwStack.DataSource = dSwitchStack; }));
					this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));
				}

				// ARP Tab
				DataTable dtARP = snmp.DataTableARP();
				if (dtARP.Rows.Count > 0)
				{
					this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabARP); }));
					this.BeginInvoke(new MethodInvoker(delegate { this.dataGridArp.DataSource = dtARP; }));
					this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));
				}

				// Routing Tab
				DataTable dtRoutes = snmp.DataTableRoutes();
				if (dtRoutes.Rows.Count > 0)
				{
					this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabRouting); }));
					this.BeginInvoke(new MethodInvoker(delegate { this.dataGridRoutes.DataSource = dtRoutes; }));
					this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));
				}

				// IPSec Tab
				DataTable dtIPSec = snmp.DataTableIPSec();
				if (dtIPSec.Rows.Count > 0)
				{
					this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabIPSec); }));
					this.BeginInvoke(new MethodInvoker(delegate { this.dataGridIPSec.DataSource = dtIPSec; }));
					this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));
				}

				// CDP Tab
				DataTable dtCDP = snmp.DataTableCDP();
				if (dtCDP.Rows.Count > 0)
				{
					this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabCDP); }));
					this.BeginInvoke(new MethodInvoker(delegate { this.dataGridCDP.DataSource = dtCDP; }));
					this.Invoke(new MethodInvoker(delegate { this.progressThread.PerformStep(); }));
				}

				// Graphing
				this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabGraph); }));
				this.Invoke(new MethodInvoker(delegate { this.progressThread.Value = 0; }));

				// Enable list of devices.
				this.Invoke(new MethodInvoker(delegate { this.combDevices.Enabled = true; }));

				bgWorkerChart.RunWorkerAsync();
			}
			catch (Lextm.SharpSnmpLib.Messaging.TimeoutException)
			{
				MessageBox.Show("The device did not resond to an SNMP request within " + ConfigurationSettings.SNMPTimeout / 1000 + " seconds, giving up", "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Invoke(new MethodInvoker(delegate { this.tabPages.TabPages.Add(tabWelcome); }));
				this.Invoke(new MethodInvoker(delegate { this.progressThread.Value = 0; }));
				this.Invoke(new MethodInvoker(delegate { ResetUI(); }));
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occured performing an SNMP operation: " + System.Environment.NewLine + System.Environment.NewLine + ex.Message, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Invoke(new MethodInvoker(delegate { ResetUI(); }));
				return;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		private void AbortBackgroundWorker()
		{
			//
			// Remove any threads that are running from the previous device.
			if (bgWorkerChart != null && bgWorkerChartComplete != null)
			{
				bgWorkerChart.CancelAsync();
				bgWorkerChartComplete.WaitOne(200);
			}
		}


		 #region "Form Events"
        /// <summary>
        /// Used to fix redraw on tab controls, see http://support.microsoft.com/kb/953934
        /// </summary>
        private void fixTabResize(object sender, EventArgs e)
        {
            this.Refresh();
        }


		/// <summary>
		/// Event triggered when BtnAddDevices is clicked. Displaying FormConfiguration
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddDevices_Click(object sender, EventArgs e)
		{
			if (frmConfig == null || frmConfig.IsDisposed)
			{
				frmConfig = new FormConfigure();
				frmConfig.FormClosed += new FormClosedEventHandler(ConfigurationFormClosed);
				frmConfig.Show();
			}
			else
			{
				frmConfig.BringToFront();
			}

			RefreshDeviceList();
		}


		/// <summary>
		/// Event triggered when a device is selected from combDevices
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void combDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (combDevices.SelectedItem == null)
				return;

			// Kill any graph threads.
			AbortBackgroundWorker();

			// Remove all tabs.
			ResetUI();

			// Create new instance of objects used.
			DeviceConfiguration selectedDevice = storedDevices.Devices.Find(d => d.Name == combDevices.SelectedItem.ToString());
            try
            {
                snmp = new SnmpInterop(selectedDevice);
				snmp.dnsLookups = ConfigurationSettings.DNSLookups;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the selected device:" + System.Environment.NewLine + System.Environment.NewLine + ex.Message,
                    "Unable to connect to device",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            // By now we know we can connect to the device, since the SnmpInterop() constructor tests this.
            tabPages.TabPages.Remove(tabWelcome);

			// General information tab.
			threadGeneral = new Thread(new ThreadStart(ThreadSNMP));
			threadGeneral.Name = "SNMP Tables";
			threadGeneral.Start();

			// Graphing
			bgWorkerChartComplete = new AutoResetEvent(false);
			bgWorkerChart = new BackgroundWorker();
			bgWorkerChart.WorkerSupportsCancellation = true;
			bgWorkerChart.DoWork += new DoWorkEventHandler(PlotInterfaceUsageWorker);
		}


		/// <summary>
		/// Event triggered when the statusStrip URL is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://damn.technology");
		}


		/// <summary>
		/// Event triggered on close of FormConfiguration
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConfigurationFormClosed(object sender, FormClosedEventArgs  e)
		{
			RefreshDeviceList();
		}

		
		/// <summary>
		/// When the main form is closed we need to dispose of the graph thread.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1Closed(object sender, FormClosingEventArgs e)
		{
			// Abort any graph threads.
			AbortBackgroundWorker();

			// Dispose of the object.
			if(bgWorkerChartComplete != null)
				bgWorkerChartComplete.Dispose();
		}

		#endregion

	}
}
