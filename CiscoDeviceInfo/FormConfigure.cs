using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;

namespace CiscoDeviceInfo
{
    public partial class FormConfigure : Form
    {
        private DeviceConfigurationList storedDevices;

        public FormConfigure()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Form load event, sets validation and loads device list from stored file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConfigure_Load(object sender, EventArgs e)
        {
			string szSettingsFile = ConfigurationSettings.DeviceSettingsPath;

            // Setup validation and load devices for devices tab.
            this.txtName.Validating += ValidateForm;
            this.txtAddress.Validating += ValidateForm;
            this.txtPort.Validating += ValidateForm;
            this.txtCommunityRO.Validating += ValidateForm;
            this.txtUsername.Validating += ValidateForm;
            this.txtAuth.Validating += ValidateForm;
            this.txtPriv.Validating += ValidateForm;
            storedDevices = DeviceConfigurationList.GetDeviceList(szSettingsFile);
            RefreshDeviceList();

            // Load settings tab data.
			if (szSettingsFile != ConfigurationSettings.DefaultStoragePath)
            {
                checkStorage.Checked = true;
                txtStorage.Enabled = true;
                txtStorage.Text = szSettingsFile;
            }
            if( ConfigurationSettings.DNSLookups)
            {
                checkDNS.Checked = true;
            }
			if (ConfigurationSettings.SNMPTimeout != 10000)
			{
				checkTimeout.Checked = true;
				txtTimeout.Value = ConfigurationSettings.SNMPTimeout / 1000;
			}
        }


        /// <summary>
        /// Refreshes the list of added devices.
        /// </summary>
        private void RefreshDeviceList()
        {
            listDevices.Items.Clear();
            foreach (DeviceConfiguration device in storedDevices.Devices)
            {
                listDevices.Items.Add(device.Name);
            }
        }


		/// <summary>
		/// Adds device to the DeviceConfigurationList on this form.
		/// </summary>
        public void addDeviceToStorage()
        {
            DeviceConfiguration device = new DeviceConfiguration();
            device.Name = txtName.Text;
            device.Address = txtAddress.Text;
            device.Port = Convert.ToInt32(txtPort.Text);
            if (combVersion.Text == "V1")
            {
                device.Version = DeviceConfiguration.SNMPVersion.V1;
            }
            else if (combVersion.Text == "V2C")
            {
                device.Version = DeviceConfiguration.SNMPVersion.V2C;
            }
            else
            {
                device.Version = DeviceConfiguration.SNMPVersion.V3;
            }
            device.CommunityRO = txtCommunityRO.Text;

            if (device.Version == DeviceConfiguration.SNMPVersion.V3)
            {
                device.Username = txtUsername.Text;
                device.AuthPass = txtAuth.Text;
                if (combAuth.Text == "NoAuth")
                {
                    device.AuthType = DeviceConfiguration.V3AuthTypes.NoAuth;
                }
                else if (combAuth.Text == "MD-5")
                {
                    device.AuthType = DeviceConfiguration.V3AuthTypes.MD5;
                }
                else
                {
                    device.AuthType = DeviceConfiguration.V3AuthTypes.SHA1;
                }

                // Can only use privacy if we authenticate.
                if (device.AuthType != DeviceConfiguration.V3AuthTypes.NoAuth)
                {
                    device.PrivPass = txtPriv.Text;
                    if (combPriv.Text == "NoPriv")
                    {
                        device.PrivType = DeviceConfiguration.V3PrivTypes.NoPriv;
                    }
                    else if (combPriv.Text == "AES-128")
                    {
                        device.PrivType = DeviceConfiguration.V3PrivTypes.AES;
                    }
                    else
                    {
                        device.PrivType = DeviceConfiguration.V3PrivTypes.DES;
                    }
                }
            }

            // Save object.
            if (storedDevices.Devices.Find(d => d.Name == device.Name) != null)
            {
				DialogResult dlgOverwritePrompt = MessageBox.Show("A device with this name already exists, do you with to update it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (dlgOverwritePrompt == DialogResult.No)
				{
					return;
				}
				else
				{
					storedDevices.Devices.Remove(storedDevices.Devices.Find(d => d.Name == device.Name));
				}
            }
            storedDevices.Devices.Add(device);
			ClearFormContents();
			grpGeneral.Enabled = false;
			grpCommunities.Enabled = false;
			grpSecPriv.Enabled = false;
			txtPort.Text = "161";
			txtCommunityRO.Text = "public";
            RefreshDeviceList();
        }


        /// <summary>
        /// Clears the input fields of any contents.
        /// </summary>
        private void ClearFormContents()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPort.Text = string.Empty;
            combVersion.SelectedIndex = 1;
            txtCommunityRO.Text = string.Empty;
            combAuth.SelectedIndex = 0;
            combPriv.SelectedIndex = 0;
            txtUsername.Text = string.Empty;
            txtAuth.Text = string.Empty;
            txtPriv.Text = string.Empty;
        }


        /// <summary>
        /// Validates form field contents for ALL fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateForm(object sender, CancelEventArgs e)
        {
            bool bOK = true;

            errProvider.SetError(txtName, string.Empty);
            errProvider.SetError(txtAddress, string.Empty);
            errProvider.SetError(txtPort, string.Empty);
            errProvider.SetError(txtCommunityRO, string.Empty);
            errProvider.SetError(txtUsername, string.Empty);
            errProvider.SetError(txtAuth, string.Empty);
            errProvider.SetError(txtPriv, string.Empty);

            // Name
            if (txtName.Text.Length < 3 || txtName.Text.Length > 40 )
            {
                errProvider.SetError(txtName, "Invalid Name. Must be between 3 and 40 characters.");
                bOK = false;
            }

            // Address
            string ValidIpAddress = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            string ValidHostname = @"^(([a-zA-Z]|[a-zA-Z][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z]|[A-Za-z][A-Za-z0-9\-]*[A-Za-z0-9])$";

            if ( txtAddress.Text.Length == 0 || (!new Regex(ValidIpAddress).IsMatch(txtAddress.Text) && !new Regex(ValidHostname).IsMatch(txtAddress.Text)) )
            {
                errProvider.SetError(txtAddress, "Invalid Address. Enter either an IP address or hostname.");
                bOK = false;
            }

            // Port
            try
            {
                Convert.ToInt32(txtPort.Text);
            }
            catch
            {
                errProvider.SetError(txtPort, "Invalid Port. An integer between 1 and 65535 is required.");
                bOK = false;
            }

            // Read Only community.
            if ( (txtCommunityRO.Text.Length == 0 || txtCommunityRO.Text.Length > 32) && combVersion.Text != "V3")
            {
                errProvider.SetError(txtCommunityRO, "Invalid community string. Length must be between 0 and 32 characters");
                bOK = false;
            }

            // SNMPv3 Settings
            if (combVersion.Text == "V3")
            {
                // Username
                if (txtUsername.Text.Length == 0)
                {
                    errProvider.SetError(txtUsername, "Invalid Username. Length must be greater than 0.");
                    bOK = false;
                }
                if (combAuth.Text != "NoAuth")
                {
                    // Auth Passphrase
                    if (txtAuth.Text.Length == 0)
                    {
                        errProvider.SetError(txtAuth, "Invalid Passphrase. Length must be greater than 0.");
                        bOK = false;
                    }
                }
                if (combPriv.Text != "NoPriv")
                {
                    // Priv Passphrase
                    if (txtPriv.Text.Length == 0)
                    {
                        errProvider.SetError(txtPriv, "Invalid Passphrase. Length must be greater than 0.");
                        bOK = false;
                    }
                }
            }
            btnSave.Enabled = bOK;
        }


        #region Form Events

        /// <summary>
        /// Add device to array and refresh list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpGeneral.Enabled = true;
            grpCommunities.Enabled = true;

            ClearFormContents();
            txtPort.Text = "161";
            txtCommunityRO.Text = "public";

            btnSave.Enabled = true;

            // Important to put focus in a control, so that validation will take place.
            txtName.Focus();
        }


        /// <summary>
        /// Remove the selected item from the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Remove the device from the storage instance on this form.
            storedDevices.Devices.Remove( 
                storedDevices.Devices.Find( d => d.Name == listDevices.SelectedItem.ToString() )
                    );

            // Remove from the user-visible lis.t
            listDevices.Items.Remove(listDevices.SelectedItem);

            // Serialize the object to disk once more.
			DeviceConfigurationList.SaveDeviceList(ConfigurationSettings.DeviceSettingsPath, storedDevices);

            ClearFormContents();

            grpGeneral.Enabled = false;
            grpCommunities.Enabled = false;
            grpSecPriv.Enabled = false;
            btnDelete.Enabled = false;
        }

        
        /// <summary>
        /// Serializes the list and saves to disk.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            addDeviceToStorage();
            try
            {
                DeviceConfigurationList.SaveDeviceList(ConfigurationSettings.DeviceSettingsPath, storedDevices);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save device configuration information." + System.Environment.NewLine + System.Environment.NewLine + ex.Message,
                    "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnSave.Enabled = false;
        }


        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


		/// <summary>
		/// Selected SNMP Version changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void combVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( combVersion.Text == "V1" || combVersion.Text == "V2C")
            {
                grpCommunities.Enabled = true;
                grpSecPriv.Enabled = false;
            }
            else if (combVersion.Text == "V3")
            {
                this.combAuth.SelectedIndex = 0;
                this.combPriv.SelectedIndex = 0;
                if (grpCommunities.Enabled)
                {
                    grpCommunities.Enabled = false;
                    grpSecPriv.Enabled = true;
                }
            }
        }


		/// <summary>
		/// Selected SNMPv3 Auth changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void combAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combAuth.Text != "NoAuth")
            {
                txtAuth.Enabled = true;
                txtAuth.Validating += ValidateForm;
            }
            else
            {
                txtAuth.Enabled = false;

            }
        }


		/// <summary>
		/// Selected SNMPv3 Privacy changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void combPriv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combPriv.Text != "NoPriv")
            {
                txtPriv.Enabled = true;
                txtPriv.Validating += ValidateForm;
            }
            else
            {
                txtPriv.Enabled = false;

            }
        }


		/// <summary>
		/// Device in device list selected.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void listDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the properties from the selected item.
            if (listDevices.SelectedItem == null)
            {
				btnSave.Enabled = false;
                return;
            }

			//
			// Populate the form with the device settings.
            DeviceConfiguration device = storedDevices.Devices.Find(d => d.Name == listDevices.SelectedItem.ToString());
            txtName.Text = device.Name;
            txtAddress.Text = device.Address;
            txtPort.Text = device.Port.ToString();
            switch (device.Version)
            {
                case DeviceConfiguration.SNMPVersion.V1:
                    combVersion.SelectedIndex = 0;
                    txtCommunityRO.Text = device.CommunityRO;
                    break;
                case DeviceConfiguration.SNMPVersion.V2C:
                    combVersion.SelectedIndex = 1;
                    txtCommunityRO.Text = device.CommunityRO;
                    break;
                case DeviceConfiguration.SNMPVersion.V3:
                    combVersion.SelectedIndex = 2;
                    break;
            }
            txtUsername.Text = device.Username;
            txtAuth.Text = device.AuthPass;
            switch (device.AuthType)
            {
                case DeviceConfiguration.V3AuthTypes.NoAuth:
                    combAuth.SelectedIndex = 0;
                    break;
                case DeviceConfiguration.V3AuthTypes.MD5:
                    combAuth.SelectedIndex = 1;
                    break;
                case DeviceConfiguration.V3AuthTypes.SHA1:
                    combAuth.SelectedIndex = 2;
                    break;
            }
            txtPriv.Text = device.PrivPass;
            switch (device.PrivType)
            {
                case DeviceConfiguration.V3PrivTypes.NoPriv:
                    combPriv.SelectedIndex = 0;
                    break;
                case DeviceConfiguration.V3PrivTypes.DES:
                    combPriv.SelectedIndex = 1;
                    break;
                case DeviceConfiguration.V3PrivTypes.AES:
                    combPriv.SelectedIndex = 2;
                    break;
            }

            btnDelete.Enabled = true;

            ValidateChildren();

			//
			// Enable form editing for the selected device.
			btnSave.Enabled = true;
			grpGeneral.Enabled = true;
			if (combVersion.SelectedIndex == 0 || combVersion.SelectedIndex == 1)
			{
				grpCommunities.Enabled = true;
			}
			else
			{
				grpSecPriv.Enabled = true;
			}
        }


		/// <summary>
		/// Toggle storage location on settings tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkStorage_CheckedChanged(object sender, EventArgs e)
		{
			if (checkStorage.Checked)
			{
				txtStorage.Enabled = true;
				txtStorage.Text = ConfigurationSettings.DeviceSettingsPath;
			}
			else
			{
				txtStorage.Enabled = false;
			}
		}


		/// <summary>
		/// Save button click event on settings tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSettingsSave_Click(object sender, EventArgs e)
		{
			// 
			// DNS Lookups.
			if (checkDNS.Checked != ConfigurationSettings.DNSLookups)
			{
				ConfigurationSettings.DNSLookups = checkDNS.Checked;
			}

			//
			// Set storage path info.
			if (checkStorage.Checked && txtStorage.Text != ConfigurationSettings.DefaultStoragePath)
			{
				ConfigurationSettings.DeviceSettingsPath = txtStorage.Text;
			}
			else if (!checkStorage.Checked)
			{
				ConfigurationSettings.DeviceSettingsPath = ConfigurationSettings.DefaultStoragePath;
			}

			//
			// Timeout.
			if (txtTimeout.Value != ConfigurationSettings.SNMPTimeout)
			{
				ConfigurationSettings.SNMPTimeout = Convert.ToInt32(txtTimeout.Value * 1000);
			}


		}

		/// <summary>
		/// Timeout tickbox ticked/unticked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkTimeout_CheckedChanged(object sender, EventArgs e)
		{
			if (checkTimeout.Checked)
			{
				txtTimeout.Enabled = true;
			}
			else
			{
				txtTimeout.Enabled = false;
				txtTimeout.Value = 10;
			}
		}

        #endregion

    }

}
