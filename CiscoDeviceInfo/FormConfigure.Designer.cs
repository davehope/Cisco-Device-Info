namespace CiscoDeviceInfo
{
    partial class FormConfigure
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigure));
            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.lblDNS = new System.Windows.Forms.Label();
            this.checkDNS = new System.Windows.Forms.CheckBox();
            this.checkStorage = new System.Windows.Forms.CheckBox();
            this.labelStorage = new System.Windows.Forms.Label();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.checkTimeout = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.NumericUpDown();
            this.tabDevices = new System.Windows.Forms.TabPage();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpSecPriv = new System.Windows.Forms.GroupBox();
            this.combAuth = new System.Windows.Forms.ComboBox();
            this.txtAuth = new System.Windows.Forms.TextBox();
            this.combPriv = new System.Windows.Forms.ComboBox();
            this.txtPriv = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.lblPrivacy = new System.Windows.Forms.Label();
            this.lblAuthPass = new System.Windows.Forms.Label();
            this.lblPrivPass = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpCommunities = new System.Windows.Forms.GroupBox();
            this.txtCommunityRO = new System.Windows.Forms.TextBox();
            this.lblCommunityRO = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.combVersion = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout)).BeginInit();
            this.tabDevices.SuspendLayout();
            this.grpSecPriv.SuspendLayout();
            this.grpCommunities.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errProvider
            // 
            this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProvider.ContainerControl = this;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.txtTimeout);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.checkTimeout);
            this.tabSettings.Controls.Add(this.btnClose2);
            this.tabSettings.Controls.Add(this.btnSettingsSave);
            this.tabSettings.Controls.Add(this.txtStorage);
            this.tabSettings.Controls.Add(this.labelStorage);
            this.tabSettings.Controls.Add(this.checkStorage);
            this.tabSettings.Controls.Add(this.checkDNS);
            this.tabSettings.Controls.Add(this.lblDNS);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(523, 407);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // lblDNS
            // 
            this.lblDNS.AutoSize = true;
            this.lblDNS.Location = new System.Drawing.Point(34, 46);
            this.lblDNS.Name = "lblDNS";
            this.lblDNS.Size = new System.Drawing.Size(458, 26);
            this.lblDNS.TabIndex = 0;
            this.lblDNS.Text = "This setting determines whether IP addresses in certain places should be resolved" +
    " to hostnames\r\n using PTR records. This is currently available only on the IPSec" +
    " tab.";
            // 
            // checkDNS
            // 
            this.checkDNS.AutoSize = true;
            this.checkDNS.Location = new System.Drawing.Point(18, 26);
            this.checkDNS.Name = "checkDNS";
            this.checkDNS.Size = new System.Drawing.Size(195, 17);
            this.checkDNS.TabIndex = 1;
            this.checkDNS.Text = "Resolve IP addresses to hostnames";
            this.checkDNS.UseVisualStyleBackColor = true;
            // 
            // checkStorage
            // 
            this.checkStorage.AutoSize = true;
            this.checkStorage.Location = new System.Drawing.Point(18, 88);
            this.checkStorage.Name = "checkStorage";
            this.checkStorage.Size = new System.Drawing.Size(251, 17);
            this.checkStorage.TabIndex = 2;
            this.checkStorage.Text = "Store device configuration in a different location";
            this.checkStorage.UseVisualStyleBackColor = true;
            this.checkStorage.CheckedChanged += new System.EventHandler(this.checkStorage_CheckedChanged);
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(34, 108);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(457, 39);
            this.labelStorage.TabIndex = 3;
            this.labelStorage.Text = resources.GetString("labelStorage.Text");
            // 
            // txtStorage
            // 
            this.txtStorage.Enabled = false;
            this.txtStorage.Location = new System.Drawing.Point(40, 160);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(452, 20);
            this.txtStorage.TabIndex = 4;
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Location = new System.Drawing.Point(442, 374);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsSave.TabIndex = 5;
            this.btnSettingsSave.Text = "Save";
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(361, 374);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(75, 23);
            this.btnClose2.TabIndex = 6;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkTimeout
            // 
            this.checkTimeout.AutoSize = true;
            this.checkTimeout.Location = new System.Drawing.Point(18, 197);
            this.checkTimeout.Name = "checkTimeout";
            this.checkTimeout.Size = new System.Drawing.Size(211, 17);
            this.checkTimeout.TabIndex = 9;
            this.checkTimeout.Text = "Adjust the timeout for SNMP operations";
            this.checkTimeout.UseVisualStyleBackColor = true;
            this.checkTimeout.CheckedChanged += new System.EventHandler(this.checkTimeout_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtTimeout
            // 
            this.txtTimeout.Enabled = false;
            this.txtTimeout.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTimeout.Location = new System.Drawing.Point(40, 272);
            this.txtTimeout.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtTimeout.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(56, 20);
            this.txtTimeout.TabIndex = 11;
            this.txtTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tabDevices
            // 
            this.tabDevices.Controls.Add(this.btnClose);
            this.tabDevices.Controls.Add(this.grpGeneral);
            this.tabDevices.Controls.Add(this.btnSave);
            this.tabDevices.Controls.Add(this.grpCommunities);
            this.tabDevices.Controls.Add(this.btnDelete);
            this.tabDevices.Controls.Add(this.grpSecPriv);
            this.tabDevices.Controls.Add(this.btnAdd);
            this.tabDevices.Controls.Add(this.listDevices);
            this.tabDevices.Location = new System.Drawing.Point(4, 22);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevices.Size = new System.Drawing.Size(523, 407);
            this.tabDevices.TabIndex = 0;
            this.tabDevices.Text = "Devices";
            this.tabDevices.UseVisualStyleBackColor = true;
            // 
            // listDevices
            // 
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(9, 12);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(175, 355);
            this.listDevices.Sorted = true;
            this.listDevices.TabIndex = 14;
            this.listDevices.SelectedIndexChanged += new System.EventHandler(this.listDevices_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(38, 374);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpSecPriv
            // 
            this.grpSecPriv.Controls.Add(this.lblUsername);
            this.grpSecPriv.Controls.Add(this.txtUsername);
            this.grpSecPriv.Controls.Add(this.lblPrivPass);
            this.grpSecPriv.Controls.Add(this.lblAuthPass);
            this.grpSecPriv.Controls.Add(this.lblPrivacy);
            this.grpSecPriv.Controls.Add(this.lblAuth);
            this.grpSecPriv.Controls.Add(this.txtPriv);
            this.grpSecPriv.Controls.Add(this.combPriv);
            this.grpSecPriv.Controls.Add(this.txtAuth);
            this.grpSecPriv.Controls.Add(this.combAuth);
            this.grpSecPriv.Enabled = false;
            this.grpSecPriv.Location = new System.Drawing.Point(190, 201);
            this.grpSecPriv.Name = "grpSecPriv";
            this.grpSecPriv.Size = new System.Drawing.Size(327, 167);
            this.grpSecPriv.TabIndex = 18;
            this.grpSecPriv.TabStop = false;
            this.grpSecPriv.Text = "Security and privacy";
            // 
            // combAuth
            // 
            this.combAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combAuth.FormattingEnabled = true;
            this.combAuth.Items.AddRange(new object[] {
            "NoAuth",
            "MD-5",
            "SHA-1"});
            this.combAuth.Location = new System.Drawing.Point(102, 45);
            this.combAuth.Name = "combAuth";
            this.combAuth.Size = new System.Drawing.Size(204, 21);
            this.combAuth.TabIndex = 8;
            this.combAuth.SelectedIndexChanged += new System.EventHandler(this.combAuth_SelectedIndexChanged);
            // 
            // txtAuth
            // 
            this.txtAuth.Location = new System.Drawing.Point(102, 72);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.Size = new System.Drawing.Size(204, 20);
            this.txtAuth.TabIndex = 9;
            this.txtAuth.UseSystemPasswordChar = true;
            // 
            // combPriv
            // 
            this.combPriv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPriv.FormattingEnabled = true;
            this.combPriv.Items.AddRange(new object[] {
            "NoPriv",
            "DES",
            "AES-128"});
            this.combPriv.Location = new System.Drawing.Point(102, 98);
            this.combPriv.Name = "combPriv";
            this.combPriv.Size = new System.Drawing.Size(204, 21);
            this.combPriv.TabIndex = 10;
            this.combPriv.SelectedIndexChanged += new System.EventHandler(this.combPriv_SelectedIndexChanged);
            // 
            // txtPriv
            // 
            this.txtPriv.Location = new System.Drawing.Point(102, 125);
            this.txtPriv.Name = "txtPriv";
            this.txtPriv.Size = new System.Drawing.Size(204, 20);
            this.txtPriv.TabIndex = 11;
            this.txtPriv.UseSystemPasswordChar = true;
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(18, 48);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(78, 13);
            this.lblAuth.TabIndex = 4;
            this.lblAuth.Text = "Authentication:";
            this.lblAuth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrivacy
            // 
            this.lblPrivacy.AutoSize = true;
            this.lblPrivacy.Location = new System.Drawing.Point(51, 101);
            this.lblPrivacy.Name = "lblPrivacy";
            this.lblPrivacy.Size = new System.Drawing.Size(45, 13);
            this.lblPrivacy.TabIndex = 5;
            this.lblPrivacy.Text = "Privacy:";
            this.lblPrivacy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAuthPass
            // 
            this.lblAuthPass.AutoSize = true;
            this.lblAuthPass.Location = new System.Drawing.Point(31, 75);
            this.lblAuthPass.Name = "lblAuthPass";
            this.lblAuthPass.Size = new System.Drawing.Size(65, 13);
            this.lblAuthPass.TabIndex = 6;
            this.lblAuthPass.Text = "Passphrase:";
            this.lblAuthPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrivPass
            // 
            this.lblPrivPass.AutoSize = true;
            this.lblPrivPass.Location = new System.Drawing.Point(31, 128);
            this.lblPrivPass.Name = "lblPrivPass";
            this.lblPrivPass.Size = new System.Drawing.Size(65, 13);
            this.lblPrivPass.TabIndex = 7;
            this.lblPrivPass.Text = "Passphrase:";
            this.lblPrivPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(102, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(202, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(38, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 22;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(9, 374);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpCommunities
            // 
            this.grpCommunities.Controls.Add(this.lblCommunityRO);
            this.grpCommunities.Controls.Add(this.txtCommunityRO);
            this.grpCommunities.Enabled = false;
            this.grpCommunities.Location = new System.Drawing.Point(190, 138);
            this.grpCommunities.Name = "grpCommunities";
            this.grpCommunities.Size = new System.Drawing.Size(327, 55);
            this.grpCommunities.TabIndex = 19;
            this.grpCommunities.TabStop = false;
            this.grpCommunities.Text = "Communities";
            // 
            // txtCommunityRO
            // 
            this.txtCommunityRO.Location = new System.Drawing.Point(102, 19);
            this.txtCommunityRO.Name = "txtCommunityRO";
            this.txtCommunityRO.Size = new System.Drawing.Size(204, 20);
            this.txtCommunityRO.TabIndex = 7;
            this.txtCommunityRO.UseSystemPasswordChar = true;
            // 
            // lblCommunityRO
            // 
            this.lblCommunityRO.AutoSize = true;
            this.lblCommunityRO.Location = new System.Drawing.Point(36, 22);
            this.lblCommunityRO.Name = "lblCommunityRO";
            this.lblCommunityRO.Size = new System.Drawing.Size(60, 13);
            this.lblCommunityRO.TabIndex = 2;
            this.lblCommunityRO.Text = "Read Only:";
            this.lblCommunityRO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(442, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.lblVersion);
            this.grpGeneral.Controls.Add(this.combVersion);
            this.grpGeneral.Controls.Add(this.lblPort);
            this.grpGeneral.Controls.Add(this.txtPort);
            this.grpGeneral.Controls.Add(this.txtAddress);
            this.grpGeneral.Controls.Add(this.lblAddress);
            this.grpGeneral.Enabled = false;
            this.grpGeneral.Location = new System.Drawing.Point(190, 6);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(327, 126);
            this.grpGeneral.TabIndex = 15;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(48, 48);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(102, 45);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(204, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(102, 72);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(204, 20);
            this.txtPort.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(67, 75);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // combVersion
            // 
            this.combVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combVersion.FormattingEnabled = true;
            this.combVersion.Items.AddRange(new object[] {
            "V1",
            "V2C",
            "V3"});
            this.combVersion.Location = new System.Drawing.Point(102, 99);
            this.combVersion.Name = "combVersion";
            this.combVersion.Size = new System.Drawing.Size(204, 21);
            this.combVersion.TabIndex = 6;
            this.combVersion.SelectedIndexChanged += new System.EventHandler(this.combVersion_SelectedIndexChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(51, 102);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(58, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(361, 374);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDevices);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // FormConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 443);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigure";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Device Configuration";
            this.Load += new System.EventHandler(this.FormConfigure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeout)).EndInit();
            this.tabDevices.ResumeLayout(false);
            this.grpSecPriv.ResumeLayout(false);
            this.grpSecPriv.PerformLayout();
            this.grpCommunities.ResumeLayout(false);
            this.grpCommunities.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDevices;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox combVersion;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpCommunities;
        private System.Windows.Forms.Label lblCommunityRO;
        private System.Windows.Forms.TextBox txtCommunityRO;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpSecPriv;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPrivPass;
        private System.Windows.Forms.Label lblAuthPass;
        private System.Windows.Forms.Label lblPrivacy;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.TextBox txtPriv;
        private System.Windows.Forms.ComboBox combPriv;
        private System.Windows.Forms.TextBox txtAuth;
        private System.Windows.Forms.ComboBox combAuth;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox listDevices;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.NumericUpDown txtTimeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkTimeout;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.CheckBox checkStorage;
        private System.Windows.Forms.CheckBox checkDNS;
        private System.Windows.Forms.Label lblDNS;

    }
}