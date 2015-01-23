namespace CiscoDeviceInfo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tooltipHyperlink = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressThread = new System.Windows.Forms.ToolStripProgressBar();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabPages = new System.Windows.Forms.TabControl();
			this.tabWelcome = new System.Windows.Forms.TabPage();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.lblVersion = new System.Windows.Forms.Label();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.lblLocation = new System.Windows.Forms.Label();
			this.txtContact = new System.Windows.Forms.TextBox();
			this.lblContact = new System.Windows.Forms.Label();
			this.lblSerial = new System.Windows.Forms.Label();
			this.lblModel = new System.Windows.Forms.Label();
			this.txtSerial = new System.Windows.Forms.TextBox();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.txtUptime = new System.Windows.Forms.TextBox();
			this.lblUptime = new System.Windows.Forms.Label();
			this.txtHostname = new System.Windows.Forms.TextBox();
			this.lblHostname = new System.Windows.Forms.Label();
			this.tabInterfaces = new System.Windows.Forms.TabPage();
			this.dataGridInterfaces = new CiscoDeviceInfo.MyDataGridView();
			this.intID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intMTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intPhysicalAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colL3Addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intAdminStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intOperStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.intLastChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabSwStack = new System.Windows.Forms.TabPage();
			this.dataGridSwStack = new CiscoDeviceInfo.MyDataGridView();
			this.colModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumPorts = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVLAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabARP = new System.Windows.Forms.TabPage();
			this.dataGridArp = new CiscoDeviceInfo.MyDataGridView();
			this.arpInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.arpPhysicalAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.arpNetworkAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabRouting = new System.Windows.Forms.TabPage();
			this.dataGridRoutes = new CiscoDeviceInfo.MyDataGridView();
			this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Mask = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NextHop = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Metric = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Interface = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabIPSec = new System.Windows.Forms.TabPage();
			this.dataGridIPSec = new CiscoDeviceInfo.MyDataGridView();
			this.ipsecLocalAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ipsecRemoteAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ipsecP1Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ipSecPacketsIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ipSecPacketsOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ipSecActiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabCDP = new System.Windows.Forms.TabPage();
			this.dataGridCDP = new CiscoDeviceInfo.MyDataGridView();
			this.cdpInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cdpHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cdpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cdpPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cdpVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cdpNativeVLAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabGraph = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblDevice = new System.Windows.Forms.Label();
			this.combDevices = new System.Windows.Forms.ComboBox();
			this.btnAddDevices = new System.Windows.Forms.Button();
			this.lblGraphError = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabPages.SuspendLayout();
			this.tabWelcome.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabInterfaces.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridInterfaces)).BeginInit();
			this.tabSwStack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSwStack)).BeginInit();
			this.tabARP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridArp)).BeginInit();
			this.tabRouting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridRoutes)).BeginInit();
			this.tabIPSec.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridIPSec)).BeginInit();
			this.tabCDP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCDP)).BeginInit();
			this.tabGraph.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltipHyperlink,
            this.progressThread});
			this.statusStrip1.Location = new System.Drawing.Point(0, 479);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(717, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tooltipHyperlink
			// 
			this.tooltipHyperlink.IsLink = true;
			this.tooltipHyperlink.Name = "tooltipHyperlink";
			this.tooltipHyperlink.Size = new System.Drawing.Size(600, 17);
			this.tooltipHyperlink.Spring = true;
			this.tooltipHyperlink.Text = "http://hope.mx";
			this.tooltipHyperlink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tooltipHyperlink.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
			// 
			// progressThread
			// 
			this.progressThread.Maximum = 7;
			this.progressThread.Name = "progressThread";
			this.progressThread.Size = new System.Drawing.Size(100, 16);
			this.progressThread.Step = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tabPages, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 479);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tabPages
			// 
			this.tabPages.Controls.Add(this.tabWelcome);
			this.tabPages.Controls.Add(this.tabGeneral);
			this.tabPages.Controls.Add(this.tabInterfaces);
			this.tabPages.Controls.Add(this.tabSwStack);
			this.tabPages.Controls.Add(this.tabARP);
			this.tabPages.Controls.Add(this.tabRouting);
			this.tabPages.Controls.Add(this.tabIPSec);
			this.tabPages.Controls.Add(this.tabCDP);
			this.tabPages.Controls.Add(this.tabGraph);
			this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPages.Location = new System.Drawing.Point(3, 38);
			this.tabPages.Name = "tabPages";
			this.tabPages.SelectedIndex = 0;
			this.tabPages.Size = new System.Drawing.Size(711, 438);
			this.tabPages.TabIndex = 7;
			// 
			// tabWelcome
			// 
			this.tabWelcome.Controls.Add(this.lblWelcome);
			this.tabWelcome.Location = new System.Drawing.Point(4, 22);
			this.tabWelcome.Name = "tabWelcome";
			this.tabWelcome.Padding = new System.Windows.Forms.Padding(3);
			this.tabWelcome.Size = new System.Drawing.Size(703, 412);
			this.tabWelcome.TabIndex = 7;
			this.tabWelcome.Text = "Welcome";
			this.tabWelcome.UseVisualStyleBackColor = true;
			this.tabWelcome.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// lblWelcome
			// 
			this.lblWelcome.AutoSize = true;
			this.lblWelcome.Location = new System.Drawing.Point(13, 20);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(677, 26);
			this.lblWelcome.TabIndex = 0;
			this.lblWelcome.Text = resources.GetString("lblWelcome.Text");
			this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.lblVersion);
			this.tabGeneral.Controls.Add(this.txtVersion);
			this.tabGeneral.Controls.Add(this.txtLocation);
			this.tabGeneral.Controls.Add(this.lblLocation);
			this.tabGeneral.Controls.Add(this.txtContact);
			this.tabGeneral.Controls.Add(this.lblContact);
			this.tabGeneral.Controls.Add(this.lblSerial);
			this.tabGeneral.Controls.Add(this.lblModel);
			this.tabGeneral.Controls.Add(this.txtSerial);
			this.tabGeneral.Controls.Add(this.txtModel);
			this.tabGeneral.Controls.Add(this.txtUptime);
			this.tabGeneral.Controls.Add(this.lblUptime);
			this.tabGeneral.Controls.Add(this.txtHostname);
			this.tabGeneral.Controls.Add(this.lblHostname);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(703, 412);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			this.tabGeneral.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(20, 130);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(45, 13);
			this.lblVersion.TabIndex = 13;
			this.lblVersion.Text = "Version:";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVersion
			// 
			this.txtVersion.AcceptsReturn = true;
			this.txtVersion.Location = new System.Drawing.Point(71, 127);
			this.txtVersion.Multiline = true;
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.ReadOnly = true;
			this.txtVersion.Size = new System.Drawing.Size(584, 85);
			this.txtVersion.TabIndex = 12;
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(71, 100);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.ReadOnly = true;
			this.txtLocation.Size = new System.Drawing.Size(584, 20);
			this.txtLocation.TabIndex = 11;
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = true;
			this.lblLocation.Location = new System.Drawing.Point(14, 103);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(51, 13);
			this.lblLocation.TabIndex = 10;
			this.lblLocation.Text = "Location:";
			this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtContact
			// 
			this.txtContact.Location = new System.Drawing.Point(71, 74);
			this.txtContact.Name = "txtContact";
			this.txtContact.ReadOnly = true;
			this.txtContact.Size = new System.Drawing.Size(584, 20);
			this.txtContact.TabIndex = 9;
			// 
			// lblContact
			// 
			this.lblContact.AutoSize = true;
			this.lblContact.Location = new System.Drawing.Point(18, 77);
			this.lblContact.Name = "lblContact";
			this.lblContact.Size = new System.Drawing.Size(47, 13);
			this.lblContact.TabIndex = 8;
			this.lblContact.Text = "Contact:";
			this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSerial
			// 
			this.lblSerial.AutoSize = true;
			this.lblSerial.Location = new System.Drawing.Point(336, 37);
			this.lblSerial.Name = "lblSerial";
			this.lblSerial.Size = new System.Drawing.Size(76, 13);
			this.lblSerial.TabIndex = 7;
			this.lblSerial.Text = "Serial Number:";
			this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblModel
			// 
			this.lblModel.AutoSize = true;
			this.lblModel.Location = new System.Drawing.Point(373, 10);
			this.lblModel.Name = "lblModel";
			this.lblModel.Size = new System.Drawing.Size(39, 13);
			this.lblModel.TabIndex = 6;
			this.lblModel.Text = "Model:";
			this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSerial
			// 
			this.txtSerial.Location = new System.Drawing.Point(418, 34);
			this.txtSerial.Name = "txtSerial";
			this.txtSerial.ReadOnly = true;
			this.txtSerial.Size = new System.Drawing.Size(237, 20);
			this.txtSerial.TabIndex = 5;
			// 
			// txtModel
			// 
			this.txtModel.Location = new System.Drawing.Point(418, 7);
			this.txtModel.Name = "txtModel";
			this.txtModel.ReadOnly = true;
			this.txtModel.Size = new System.Drawing.Size(237, 20);
			this.txtModel.TabIndex = 4;
			// 
			// txtUptime
			// 
			this.txtUptime.Location = new System.Drawing.Point(71, 34);
			this.txtUptime.Name = "txtUptime";
			this.txtUptime.ReadOnly = true;
			this.txtUptime.Size = new System.Drawing.Size(237, 20);
			this.txtUptime.TabIndex = 3;
			// 
			// lblUptime
			// 
			this.lblUptime.AutoSize = true;
			this.lblUptime.Location = new System.Drawing.Point(22, 37);
			this.lblUptime.Name = "lblUptime";
			this.lblUptime.Size = new System.Drawing.Size(43, 13);
			this.lblUptime.TabIndex = 2;
			this.lblUptime.Text = "Uptime:";
			this.lblUptime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtHostname
			// 
			this.txtHostname.Location = new System.Drawing.Point(71, 7);
			this.txtHostname.Name = "txtHostname";
			this.txtHostname.ReadOnly = true;
			this.txtHostname.Size = new System.Drawing.Size(237, 20);
			this.txtHostname.TabIndex = 1;
			// 
			// lblHostname
			// 
			this.lblHostname.AutoSize = true;
			this.lblHostname.Location = new System.Drawing.Point(7, 10);
			this.lblHostname.Name = "lblHostname";
			this.lblHostname.Size = new System.Drawing.Size(58, 13);
			this.lblHostname.TabIndex = 0;
			this.lblHostname.Text = "Hostname:";
			this.lblHostname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabInterfaces
			// 
			this.tabInterfaces.Controls.Add(this.dataGridInterfaces);
			this.tabInterfaces.Location = new System.Drawing.Point(4, 22);
			this.tabInterfaces.Name = "tabInterfaces";
			this.tabInterfaces.Padding = new System.Windows.Forms.Padding(3);
			this.tabInterfaces.Size = new System.Drawing.Size(703, 412);
			this.tabInterfaces.TabIndex = 4;
			this.tabInterfaces.Text = "Interfaces";
			this.tabInterfaces.UseVisualStyleBackColor = true;
			this.tabInterfaces.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// dataGridInterfaces
			// 
			this.dataGridInterfaces.AllowUserToAddRows = false;
			this.dataGridInterfaces.AllowUserToDeleteRows = false;
			this.dataGridInterfaces.AllowUserToResizeRows = false;
			this.dataGridInterfaces.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
			this.dataGridInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.intID,
            this.intName,
            this.intMTU,
            this.intSpeed,
            this.intPhysicalAddr,
            this.colL3Addr,
            this.intAdminStatus,
            this.intOperStatus,
            this.intLastChange,
            this.colDescription});
			this.dataGridInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridInterfaces.Location = new System.Drawing.Point(3, 3);
			this.dataGridInterfaces.Name = "dataGridInterfaces";
			this.dataGridInterfaces.ReadOnly = true;
			this.dataGridInterfaces.RowHeadersVisible = false;
			this.dataGridInterfaces.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
			this.dataGridInterfaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridInterfaces.Size = new System.Drawing.Size(697, 406);
			this.dataGridInterfaces.TabIndex = 0;
			// 
			// intID
			// 
			this.intID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intID.DataPropertyName = "ID";
			this.intID.HeaderText = "ID";
			this.intID.MinimumWidth = 30;
			this.intID.Name = "intID";
			this.intID.ReadOnly = true;
			this.intID.Visible = false;
			// 
			// intName
			// 
			this.intName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intName.DataPropertyName = "Name";
			this.intName.HeaderText = "Name";
			this.intName.MinimumWidth = 100;
			this.intName.Name = "intName";
			this.intName.ReadOnly = true;
			// 
			// intMTU
			// 
			this.intMTU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intMTU.DataPropertyName = "MTU";
			this.intMTU.HeaderText = "MTU";
			this.intMTU.MinimumWidth = 50;
			this.intMTU.Name = "intMTU";
			this.intMTU.ReadOnly = true;
			this.intMTU.Width = 50;
			// 
			// intSpeed
			// 
			this.intSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intSpeed.DataPropertyName = "Speed";
			this.intSpeed.HeaderText = "Speed";
			this.intSpeed.MinimumWidth = 50;
			this.intSpeed.Name = "intSpeed";
			this.intSpeed.ReadOnly = true;
			this.intSpeed.Width = 50;
			// 
			// intPhysicalAddr
			// 
			this.intPhysicalAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intPhysicalAddr.DataPropertyName = "Physical Address";
			this.intPhysicalAddr.HeaderText = "Physical Address";
			this.intPhysicalAddr.MinimumWidth = 100;
			this.intPhysicalAddr.Name = "intPhysicalAddr";
			this.intPhysicalAddr.ReadOnly = true;
			// 
			// colL3Addr
			// 
			this.colL3Addr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colL3Addr.DataPropertyName = "L3 Address";
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.colL3Addr.DefaultCellStyle = dataGridViewCellStyle1;
			this.colL3Addr.HeaderText = "IP Address";
			this.colL3Addr.MinimumWidth = 80;
			this.colL3Addr.Name = "colL3Addr";
			this.colL3Addr.ReadOnly = true;
			this.colL3Addr.Width = 80;
			// 
			// intAdminStatus
			// 
			this.intAdminStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intAdminStatus.DataPropertyName = "Admin Status";
			this.intAdminStatus.HeaderText = "Admin Status";
			this.intAdminStatus.MinimumWidth = 80;
			this.intAdminStatus.Name = "intAdminStatus";
			this.intAdminStatus.ReadOnly = true;
			this.intAdminStatus.Width = 80;
			// 
			// intOperStatus
			// 
			this.intOperStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.intOperStatus.DataPropertyName = "Oper Status";
			this.intOperStatus.HeaderText = "Oper Status";
			this.intOperStatus.MinimumWidth = 70;
			this.intOperStatus.Name = "intOperStatus";
			this.intOperStatus.ReadOnly = true;
			this.intOperStatus.Width = 70;
			// 
			// intLastChange
			// 
			this.intLastChange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.intLastChange.DataPropertyName = "Last Change";
			dataGridViewCellStyle2.NullValue = null;
			this.intLastChange.DefaultCellStyle = dataGridViewCellStyle2;
			this.intLastChange.HeaderText = "Last Change";
			this.intLastChange.MinimumWidth = 100;
			this.intLastChange.Name = "intLastChange";
			this.intLastChange.ReadOnly = true;
			// 
			// colDescription
			// 
			this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colDescription.DataPropertyName = "Description";
			this.colDescription.HeaderText = "Description";
			this.colDescription.MinimumWidth = 200;
			this.colDescription.Name = "colDescription";
			this.colDescription.ReadOnly = true;
			this.colDescription.Visible = false;
			// 
			// tabSwStack
			// 
			this.tabSwStack.Controls.Add(this.dataGridSwStack);
			this.tabSwStack.Location = new System.Drawing.Point(4, 22);
			this.tabSwStack.Name = "tabSwStack";
			this.tabSwStack.Padding = new System.Windows.Forms.Padding(3);
			this.tabSwStack.Size = new System.Drawing.Size(703, 412);
			this.tabSwStack.TabIndex = 8;
			this.tabSwStack.Text = "Switch Stack";
			this.tabSwStack.UseVisualStyleBackColor = true;
			// 
			// dataGridSwStack
			// 
			this.dataGridSwStack.AllowUserToAddRows = false;
			this.dataGridSwStack.AllowUserToDeleteRows = false;
			this.dataGridSwStack.AllowUserToResizeRows = false;
			this.dataGridSwStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridSwStack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModule,
            this.colModel,
            this.colSN,
            this.colNumPorts,
            this.colIP,
            this.colVLAN,
            this.colStatus});
			this.dataGridSwStack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridSwStack.Location = new System.Drawing.Point(3, 3);
			this.dataGridSwStack.Name = "dataGridSwStack";
			this.dataGridSwStack.ReadOnly = true;
			this.dataGridSwStack.RowHeadersVisible = false;
			this.dataGridSwStack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridSwStack.Size = new System.Drawing.Size(697, 406);
			this.dataGridSwStack.TabIndex = 0;
			// 
			// colModule
			// 
			this.colModule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colModule.DataPropertyName = "Module";
			this.colModule.HeaderText = "Module";
			this.colModule.MinimumWidth = 55;
			this.colModule.Name = "colModule";
			this.colModule.ReadOnly = true;
			this.colModule.Width = 55;
			// 
			// colModel
			// 
			this.colModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colModel.DataPropertyName = "Model";
			this.colModel.HeaderText = "Type";
			this.colModel.MinimumWidth = 56;
			this.colModel.Name = "colModel";
			this.colModel.ReadOnly = true;
			this.colModel.Width = 56;
			// 
			// colSN
			// 
			this.colSN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colSN.DataPropertyName = "Serial Number";
			this.colSN.HeaderText = "Serial Number";
			this.colSN.MinimumWidth = 98;
			this.colSN.Name = "colSN";
			this.colSN.ReadOnly = true;
			this.colSN.Width = 98;
			// 
			// colNumPorts
			// 
			this.colNumPorts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colNumPorts.DataPropertyName = "# Ports";
			this.colNumPorts.HeaderText = "# Ports";
			this.colNumPorts.MinimumWidth = 66;
			this.colNumPorts.Name = "colNumPorts";
			this.colNumPorts.ReadOnly = true;
			this.colNumPorts.Width = 66;
			// 
			// colIP
			// 
			this.colIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colIP.DataPropertyName = "IP Address";
			this.colIP.HeaderText = "IP Address";
			this.colIP.MinimumWidth = 80;
			this.colIP.Name = "colIP";
			this.colIP.ReadOnly = true;
			this.colIP.Width = 80;
			// 
			// colVLAN
			// 
			this.colVLAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.colVLAN.DataPropertyName = "VLAN";
			this.colVLAN.HeaderText = "VLAN";
			this.colVLAN.MinimumWidth = 60;
			this.colVLAN.Name = "colVLAN";
			this.colVLAN.ReadOnly = true;
			this.colVLAN.Width = 60;
			// 
			// colStatus
			// 
			this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colStatus.DataPropertyName = "Status";
			this.colStatus.HeaderText = "Status";
			this.colStatus.MinimumWidth = 80;
			this.colStatus.Name = "colStatus";
			this.colStatus.ReadOnly = true;
			// 
			// tabARP
			// 
			this.tabARP.Controls.Add(this.dataGridArp);
			this.tabARP.Location = new System.Drawing.Point(4, 22);
			this.tabARP.Name = "tabARP";
			this.tabARP.Padding = new System.Windows.Forms.Padding(3);
			this.tabARP.Size = new System.Drawing.Size(703, 412);
			this.tabARP.TabIndex = 3;
			this.tabARP.Text = "ARP Cache";
			this.tabARP.UseVisualStyleBackColor = true;
			this.tabARP.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// dataGridArp
			// 
			this.dataGridArp.AllowUserToAddRows = false;
			this.dataGridArp.AllowUserToDeleteRows = false;
			this.dataGridArp.AllowUserToResizeRows = false;
			this.dataGridArp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridArp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.arpInterface,
            this.arpPhysicalAddress,
            this.arpNetworkAddress});
			this.dataGridArp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridArp.Location = new System.Drawing.Point(3, 3);
			this.dataGridArp.Name = "dataGridArp";
			this.dataGridArp.ReadOnly = true;
			this.dataGridArp.RowHeadersVisible = false;
			this.dataGridArp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridArp.Size = new System.Drawing.Size(697, 406);
			this.dataGridArp.TabIndex = 0;
			// 
			// arpInterface
			// 
			this.arpInterface.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.arpInterface.DataPropertyName = "Interface";
			this.arpInterface.HeaderText = "Interface";
			this.arpInterface.MinimumWidth = 100;
			this.arpInterface.Name = "arpInterface";
			this.arpInterface.ReadOnly = true;
			// 
			// arpPhysicalAddress
			// 
			this.arpPhysicalAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.arpPhysicalAddress.DataPropertyName = "Physical Address";
			this.arpPhysicalAddress.HeaderText = "Physical Address";
			this.arpPhysicalAddress.MinimumWidth = 100;
			this.arpPhysicalAddress.Name = "arpPhysicalAddress";
			this.arpPhysicalAddress.ReadOnly = true;
			// 
			// arpNetworkAddress
			// 
			this.arpNetworkAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.arpNetworkAddress.DataPropertyName = "Network Address";
			this.arpNetworkAddress.HeaderText = "Network Address";
			this.arpNetworkAddress.MinimumWidth = 80;
			this.arpNetworkAddress.Name = "arpNetworkAddress";
			this.arpNetworkAddress.ReadOnly = true;
			// 
			// tabRouting
			// 
			this.tabRouting.Controls.Add(this.dataGridRoutes);
			this.tabRouting.Location = new System.Drawing.Point(4, 22);
			this.tabRouting.Name = "tabRouting";
			this.tabRouting.Padding = new System.Windows.Forms.Padding(3);
			this.tabRouting.Size = new System.Drawing.Size(703, 412);
			this.tabRouting.TabIndex = 1;
			this.tabRouting.Text = "Routing";
			this.tabRouting.UseVisualStyleBackColor = true;
			this.tabRouting.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// dataGridRoutes
			// 
			this.dataGridRoutes.AllowUserToAddRows = false;
			this.dataGridRoutes.AllowUserToDeleteRows = false;
			this.dataGridRoutes.AllowUserToResizeRows = false;
			this.dataGridRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destination,
            this.Mask,
            this.NextHop,
            this.Metric,
            this.Interface,
            this.Protocol,
            this.Type,
            this.Age});
			this.dataGridRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridRoutes.Location = new System.Drawing.Point(3, 3);
			this.dataGridRoutes.Name = "dataGridRoutes";
			this.dataGridRoutes.ReadOnly = true;
			this.dataGridRoutes.RowHeadersVisible = false;
			this.dataGridRoutes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridRoutes.Size = new System.Drawing.Size(697, 406);
			this.dataGridRoutes.TabIndex = 0;
			// 
			// Destination
			// 
			this.Destination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Destination.DataPropertyName = "Destination";
			this.Destination.HeaderText = "Destination";
			this.Destination.MinimumWidth = 80;
			this.Destination.Name = "Destination";
			this.Destination.ReadOnly = true;
			this.Destination.Width = 80;
			// 
			// Mask
			// 
			this.Mask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Mask.DataPropertyName = "Mask";
			this.Mask.HeaderText = "Mask";
			this.Mask.MinimumWidth = 100;
			this.Mask.Name = "Mask";
			this.Mask.ReadOnly = true;
			// 
			// NextHop
			// 
			this.NextHop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.NextHop.DataPropertyName = "Next Hop";
			this.NextHop.HeaderText = "Next Hop";
			this.NextHop.MinimumWidth = 80;
			this.NextHop.Name = "NextHop";
			this.NextHop.ReadOnly = true;
			this.NextHop.Width = 80;
			// 
			// Metric
			// 
			this.Metric.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Metric.DataPropertyName = "Metric";
			this.Metric.HeaderText = "Metric";
			this.Metric.MinimumWidth = 60;
			this.Metric.Name = "Metric";
			this.Metric.ReadOnly = true;
			this.Metric.Width = 60;
			// 
			// Interface
			// 
			this.Interface.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Interface.DataPropertyName = "Interface";
			this.Interface.HeaderText = "Interface";
			this.Interface.MinimumWidth = 80;
			this.Interface.Name = "Interface";
			this.Interface.ReadOnly = true;
			this.Interface.Width = 80;
			// 
			// Protocol
			// 
			this.Protocol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Protocol.DataPropertyName = "Protocol";
			this.Protocol.HeaderText = "Protocol";
			this.Protocol.MinimumWidth = 65;
			this.Protocol.Name = "Protocol";
			this.Protocol.ReadOnly = true;
			this.Protocol.Width = 65;
			// 
			// Type
			// 
			this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Type.DataPropertyName = "Type";
			this.Type.HeaderText = "Type";
			this.Type.MinimumWidth = 50;
			this.Type.Name = "Type";
			this.Type.ReadOnly = true;
			this.Type.Width = 50;
			// 
			// Age
			// 
			this.Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Age.DataPropertyName = "Age";
			this.Age.HeaderText = "Age";
			this.Age.MinimumWidth = 100;
			this.Age.Name = "Age";
			this.Age.ReadOnly = true;
			// 
			// tabIPSec
			// 
			this.tabIPSec.Controls.Add(this.dataGridIPSec);
			this.tabIPSec.Location = new System.Drawing.Point(4, 22);
			this.tabIPSec.Name = "tabIPSec";
			this.tabIPSec.Padding = new System.Windows.Forms.Padding(3);
			this.tabIPSec.Size = new System.Drawing.Size(703, 412);
			this.tabIPSec.TabIndex = 2;
			this.tabIPSec.Text = "IPSec";
			this.tabIPSec.UseVisualStyleBackColor = true;
			this.tabIPSec.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// dataGridIPSec
			// 
			this.dataGridIPSec.AllowUserToAddRows = false;
			this.dataGridIPSec.AllowUserToDeleteRows = false;
			this.dataGridIPSec.AllowUserToResizeRows = false;
			this.dataGridIPSec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridIPSec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ipsecLocalAddr,
            this.ipsecRemoteAddr,
            this.ipsecP1Active,
            this.ipSecPacketsIn,
            this.ipSecPacketsOut,
            this.ipSecActiveTime});
			this.dataGridIPSec.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridIPSec.Location = new System.Drawing.Point(3, 3);
			this.dataGridIPSec.Name = "dataGridIPSec";
			this.dataGridIPSec.ReadOnly = true;
			this.dataGridIPSec.RowHeadersVisible = false;
			this.dataGridIPSec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridIPSec.Size = new System.Drawing.Size(697, 406);
			this.dataGridIPSec.TabIndex = 0;
			// 
			// ipsecLocalAddr
			// 
			this.ipsecLocalAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ipsecLocalAddr.DataPropertyName = "Local Address";
			this.ipsecLocalAddr.HeaderText = "Local Address";
			this.ipsecLocalAddr.MinimumWidth = 80;
			this.ipsecLocalAddr.Name = "ipsecLocalAddr";
			this.ipsecLocalAddr.ReadOnly = true;
			this.ipsecLocalAddr.Width = 80;
			// 
			// ipsecRemoteAddr
			// 
			this.ipsecRemoteAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ipsecRemoteAddr.DataPropertyName = "Remote Address";
			this.ipsecRemoteAddr.HeaderText = "Remote Address";
			this.ipsecRemoteAddr.MinimumWidth = 80;
			this.ipsecRemoteAddr.Name = "ipsecRemoteAddr";
			this.ipsecRemoteAddr.ReadOnly = true;
			this.ipsecRemoteAddr.Width = 80;
			// 
			// ipsecP1Active
			// 
			this.ipsecP1Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ipsecP1Active.DataPropertyName = "Phase 1 Active";
			this.ipsecP1Active.FillWeight = 90F;
			this.ipsecP1Active.HeaderText = "Phase 1 Active";
			this.ipsecP1Active.MinimumWidth = 90;
			this.ipsecP1Active.Name = "ipsecP1Active";
			this.ipsecP1Active.ReadOnly = true;
			this.ipsecP1Active.Width = 90;
			// 
			// ipSecPacketsIn
			// 
			this.ipSecPacketsIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ipSecPacketsIn.DataPropertyName = "Packets In";
			this.ipSecPacketsIn.HeaderText = "Packets In";
			this.ipSecPacketsIn.MinimumWidth = 100;
			this.ipSecPacketsIn.Name = "ipSecPacketsIn";
			this.ipSecPacketsIn.ReadOnly = true;
			// 
			// ipSecPacketsOut
			// 
			this.ipSecPacketsOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.ipSecPacketsOut.DataPropertyName = "Packets Out";
			this.ipSecPacketsOut.HeaderText = "Packets Out";
			this.ipSecPacketsOut.MinimumWidth = 100;
			this.ipSecPacketsOut.Name = "ipSecPacketsOut";
			this.ipSecPacketsOut.ReadOnly = true;
			// 
			// ipSecActiveTime
			// 
			this.ipSecActiveTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ipSecActiveTime.DataPropertyName = "Active Time";
			this.ipSecActiveTime.HeaderText = "Active Time";
			this.ipSecActiveTime.MinimumWidth = 170;
			this.ipSecActiveTime.Name = "ipSecActiveTime";
			this.ipSecActiveTime.ReadOnly = true;
			// 
			// tabCDP
			// 
			this.tabCDP.Controls.Add(this.dataGridCDP);
			this.tabCDP.Location = new System.Drawing.Point(4, 22);
			this.tabCDP.Name = "tabCDP";
			this.tabCDP.Padding = new System.Windows.Forms.Padding(3);
			this.tabCDP.Size = new System.Drawing.Size(703, 412);
			this.tabCDP.TabIndex = 5;
			this.tabCDP.Text = "CDP";
			this.tabCDP.UseVisualStyleBackColor = true;
			this.tabCDP.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// dataGridCDP
			// 
			this.dataGridCDP.AllowUserToAddRows = false;
			this.dataGridCDP.AllowUserToDeleteRows = false;
			this.dataGridCDP.AllowUserToResizeRows = false;
			this.dataGridCDP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridCDP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdpInterface,
            this.cdpHostname,
            this.cdpAddress,
            this.cdpPlatform,
            this.cdpVersion,
            this.cdpNativeVLAN});
			this.dataGridCDP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridCDP.Location = new System.Drawing.Point(3, 3);
			this.dataGridCDP.Name = "dataGridCDP";
			this.dataGridCDP.ReadOnly = true;
			this.dataGridCDP.RowHeadersVisible = false;
			this.dataGridCDP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridCDP.Size = new System.Drawing.Size(697, 406);
			this.dataGridCDP.TabIndex = 0;
			// 
			// cdpInterface
			// 
			this.cdpInterface.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.cdpInterface.DataPropertyName = "Interface";
			this.cdpInterface.FillWeight = 32.04115F;
			this.cdpInterface.HeaderText = "Interface";
			this.cdpInterface.MinimumWidth = 100;
			this.cdpInterface.Name = "cdpInterface";
			this.cdpInterface.ReadOnly = true;
			// 
			// cdpHostname
			// 
			this.cdpHostname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.cdpHostname.DataPropertyName = "Hostname";
			this.cdpHostname.HeaderText = "Hostname";
			this.cdpHostname.MinimumWidth = 100;
			this.cdpHostname.Name = "cdpHostname";
			this.cdpHostname.ReadOnly = true;
			// 
			// cdpAddress
			// 
			this.cdpAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.cdpAddress.DataPropertyName = "IP Address";
			this.cdpAddress.HeaderText = "IP Address";
			this.cdpAddress.MinimumWidth = 80;
			this.cdpAddress.Name = "cdpAddress";
			this.cdpAddress.ReadOnly = true;
			this.cdpAddress.Width = 80;
			// 
			// cdpPlatform
			// 
			this.cdpPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.cdpPlatform.DataPropertyName = "Platform";
			this.cdpPlatform.HeaderText = "Platform";
			this.cdpPlatform.MinimumWidth = 80;
			this.cdpPlatform.Name = "cdpPlatform";
			this.cdpPlatform.ReadOnly = true;
			this.cdpPlatform.Width = 80;
			// 
			// cdpVersion
			// 
			this.cdpVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.cdpVersion.DataPropertyName = "Version";
			this.cdpVersion.HeaderText = "Version";
			this.cdpVersion.MinimumWidth = 100;
			this.cdpVersion.Name = "cdpVersion";
			this.cdpVersion.ReadOnly = true;
			// 
			// cdpNativeVLAN
			// 
			this.cdpNativeVLAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.cdpNativeVLAN.DataPropertyName = "Native VLAN";
			this.cdpNativeVLAN.HeaderText = "Native VLAN";
			this.cdpNativeVLAN.MinimumWidth = 100;
			this.cdpNativeVLAN.Name = "cdpNativeVLAN";
			this.cdpNativeVLAN.ReadOnly = true;
			// 
			// tabGraph
			// 
			this.tabGraph.Controls.Add(this.tableLayoutPanel3);
			this.tabGraph.Location = new System.Drawing.Point(4, 22);
			this.tabGraph.Name = "tabGraph";
			this.tabGraph.Padding = new System.Windows.Forms.Padding(3);
			this.tabGraph.Size = new System.Drawing.Size(703, 412);
			this.tabGraph.TabIndex = 6;
			this.tabGraph.Text = "Interface Usage";
			this.tabGraph.UseVisualStyleBackColor = true;
			this.tabGraph.SizeChanged += new System.EventHandler(this.fixTabResize);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.chartLine, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 406F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(697, 406);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// chartLine
			// 
			chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
			chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisX2.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
			chartArea1.AxisY.Title = "KB / s";
			chartArea1.Name = "ChartArea1";
			this.chartLine.ChartAreas.Add(chartArea1);
			this.chartLine.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			legend1.Title = "Interfaces";
			this.chartLine.Legends.Add(legend1);
			this.chartLine.Location = new System.Drawing.Point(0, 0);
			this.chartLine.Margin = new System.Windows.Forms.Padding(0);
			this.chartLine.Name = "chartLine";
			this.chartLine.Size = new System.Drawing.Size(697, 406);
			this.chartLine.TabIndex = 3;
			this.chartLine.Text = "Interface Throughput";
			title1.DockedToChartArea = "ChartArea1";
			title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title1.Name = "Interface Throughput";
			title1.Text = "Interface Throughput";
			this.chartLine.Titles.Add(title1);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
			this.tableLayoutPanel2.Controls.Add(this.lblDevice, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.combDevices, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnAddDevices, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(711, 29);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// lblDevice
			// 
			this.lblDevice.AutoSize = true;
			this.lblDevice.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblDevice.Location = new System.Drawing.Point(8, 0);
			this.lblDevice.Name = "lblDevice";
			this.lblDevice.Size = new System.Drawing.Size(44, 29);
			this.lblDevice.TabIndex = 6;
			this.lblDevice.Text = "Device:";
			this.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// combDevices
			// 
			this.combDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.combDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combDevices.FormattingEnabled = true;
			this.combDevices.Location = new System.Drawing.Point(58, 4);
			this.combDevices.Name = "combDevices";
			this.combDevices.Size = new System.Drawing.Size(569, 21);
			this.combDevices.Sorted = true;
			this.combDevices.TabIndex = 7;
			this.combDevices.SelectedIndexChanged += new System.EventHandler(this.combDevices_SelectedIndexChanged);
			// 
			// btnAddDevices
			// 
			this.btnAddDevices.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnAddDevices.Location = new System.Drawing.Point(633, 3);
			this.btnAddDevices.Name = "btnAddDevices";
			this.btnAddDevices.Size = new System.Drawing.Size(75, 23);
			this.btnAddDevices.TabIndex = 5;
			this.btnAddDevices.Text = "Settings";
			this.btnAddDevices.UseVisualStyleBackColor = true;
			this.btnAddDevices.Click += new System.EventHandler(this.btnAddDevices_Click);
			// 
			// lblGraphError
			// 
			this.lblGraphError.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblGraphError.Location = new System.Drawing.Point(0, 0);
			this.lblGraphError.Name = "lblGraphError";
			this.lblGraphError.Size = new System.Drawing.Size(100, 23);
			this.lblGraphError.TabIndex = 0;
			this.lblGraphError.Text = "Unable to graph interface usage due to a slow responding device";
			this.lblGraphError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 501);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(733, 539);
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Cisco Device Info";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1Closed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabPages.ResumeLayout(false);
			this.tabWelcome.ResumeLayout(false);
			this.tabWelcome.PerformLayout();
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabInterfaces.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridInterfaces)).EndInit();
			this.tabSwStack.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridSwStack)).EndInit();
			this.tabARP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridArp)).EndInit();
			this.tabRouting.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridRoutes)).EndInit();
			this.tabIPSec.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridIPSec)).EndInit();
			this.tabCDP.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridCDP)).EndInit();
			this.tabGraph.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabPages;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtUptime;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.TabPage tabRouting;
        private CiscoDeviceInfo.MyDataGridView dataGridRoutes;
        private System.Windows.Forms.TabPage tabIPSec;
		private CiscoDeviceInfo.MyDataGridView dataGridIPSec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabARP;
		private CiscoDeviceInfo.MyDataGridView dataGridArp;
        private System.Windows.Forms.TabPage tabInterfaces;
		private CiscoDeviceInfo.MyDataGridView dataGridInterfaces;
        private System.Windows.Forms.TabPage tabCDP;
		private CiscoDeviceInfo.MyDataGridView dataGridCDP;
        private System.Windows.Forms.Button btnAddDevices;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox combDevices;
        private System.Windows.Forms.ToolStripStatusLabel tooltipHyperlink;
		private System.Windows.Forms.TabPage tabGraph;
		private System.Windows.Forms.Label lblGraphError;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;
		private System.Windows.Forms.TabPage tabWelcome;
		private System.Windows.Forms.Label lblWelcome;
		private System.Windows.Forms.ToolStripProgressBar progressThread;
        private System.Windows.Forms.TabPage tabSwStack;
		private CiscoDeviceInfo.MyDataGridView dataGridSwStack;
		private System.Windows.Forms.DataGridViewTextBoxColumn intID;
		private System.Windows.Forms.DataGridViewTextBoxColumn intName;
		private System.Windows.Forms.DataGridViewTextBoxColumn intMTU;
		private System.Windows.Forms.DataGridViewTextBoxColumn intSpeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn intPhysicalAddr;
		private System.Windows.Forms.DataGridViewTextBoxColumn colL3Addr;
		private System.Windows.Forms.DataGridViewTextBoxColumn intAdminStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn intOperStatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn intLastChange;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
		private System.Windows.Forms.DataGridViewTextBoxColumn Mask;
		private System.Windows.Forms.DataGridViewTextBoxColumn NextHop;
		private System.Windows.Forms.DataGridViewTextBoxColumn Metric;
		private System.Windows.Forms.DataGridViewTextBoxColumn Interface;
		private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Age;
		private System.Windows.Forms.DataGridViewTextBoxColumn arpInterface;
		private System.Windows.Forms.DataGridViewTextBoxColumn arpPhysicalAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn arpNetworkAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpInterface;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpHostname;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpAddress;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpPlatform;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpVersion;
		private System.Windows.Forms.DataGridViewTextBoxColumn cdpNativeVLAN;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipsecLocalAddr;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipsecRemoteAddr;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ipsecP1Active;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipSecPacketsIn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipSecPacketsOut;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipSecActiveTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn colModule;
		private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSN;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumPorts;
		private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
		private System.Windows.Forms.DataGridViewTextBoxColumn colVLAN;
		private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}

