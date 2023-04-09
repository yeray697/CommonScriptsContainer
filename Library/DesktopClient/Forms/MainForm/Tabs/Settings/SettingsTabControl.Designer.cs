namespace DesktopClient.Forms.MainForm.Tabs.Settings
{
    partial class SettingsTabControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblConsoleMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            lblFileMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            swtIsDarkMode = new MaterialSkin.Controls.MaterialSwitch();
            cbxConsoleMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            cbxFileMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            lblDarkMode = new MaterialSkin.Controls.MaterialLabel();
            swtEnableGrpcServer = new MaterialSkin.Controls.MaterialSwitch();
            lblEnableGrpcServer = new MaterialSkin.Controls.MaterialLabel();
            swtEnableWebClient = new MaterialSkin.Controls.MaterialSwitch();
            lblEnableWebClient = new MaterialSkin.Controls.MaterialLabel();
            lblRequiresRestart1 = new MaterialSkin.Controls.MaterialLabel();
            lblRequiresRestart2 = new MaterialSkin.Controls.MaterialLabel();
            swtRunOnStartup = new MaterialSkin.Controls.MaterialSwitch();
            lblRunOnStartup = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // lblConsoleMinLogLevel
            // 
            lblConsoleMinLogLevel.BackColor = Color.FromArgb(242, 242, 242);
            lblConsoleMinLogLevel.Depth = 0;
            lblConsoleMinLogLevel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblConsoleMinLogLevel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblConsoleMinLogLevel.Location = new Point(39, 103);
            lblConsoleMinLogLevel.Margin = new Padding(2, 0, 2, 0);
            lblConsoleMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            lblConsoleMinLogLevel.Name = "lblConsoleMinLogLevel";
            lblConsoleMinLogLevel.Size = new Size(163, 49);
            lblConsoleMinLogLevel.TabIndex = 25;
            lblConsoleMinLogLevel.Text = "Console Minimum Logging Level";
            // 
            // lblFileMinLogLevel
            // 
            lblFileMinLogLevel.BackColor = Color.FromArgb(242, 242, 242);
            lblFileMinLogLevel.Depth = 0;
            lblFileMinLogLevel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFileMinLogLevel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblFileMinLogLevel.Location = new Point(39, 34);
            lblFileMinLogLevel.Margin = new Padding(2, 0, 2, 0);
            lblFileMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            lblFileMinLogLevel.Name = "lblFileMinLogLevel";
            lblFileMinLogLevel.Size = new Size(163, 49);
            lblFileMinLogLevel.TabIndex = 24;
            lblFileMinLogLevel.Text = "File Minimum Logging Level";
            // 
            // swtIsDarkMode
            // 
            swtIsDarkMode.BackColor = Color.FromArgb(242, 242, 242);
            swtIsDarkMode.Checked = true;
            swtIsDarkMode.CheckState = CheckState.Indeterminate;
            swtIsDarkMode.Cursor = Cursors.Hand;
            swtIsDarkMode.Depth = 0;
            swtIsDarkMode.ForeColor = Color.FromArgb(222, 0, 0, 0);
            swtIsDarkMode.Location = new Point(225, 171);
            swtIsDarkMode.Margin = new Padding(0);
            swtIsDarkMode.MouseLocation = new Point(-1, -1);
            swtIsDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            swtIsDarkMode.Name = "swtIsDarkMode";
            swtIsDarkMode.Ripple = true;
            swtIsDarkMode.Size = new Size(48, 27);
            swtIsDarkMode.TabIndex = 23;
            swtIsDarkMode.UseVisualStyleBackColor = false;
            // 
            // cbxConsoleMinLevel
            // 
            cbxConsoleMinLevel.AllowDrop = true;
            cbxConsoleMinLevel.AutoResize = false;
            cbxConsoleMinLevel.BackColor = Color.FromArgb(242, 242, 242);
            cbxConsoleMinLevel.CausesValidation = false;
            cbxConsoleMinLevel.Depth = 0;
            cbxConsoleMinLevel.DrawMode = DrawMode.OwnerDrawVariable;
            cbxConsoleMinLevel.DropDownHeight = 174;
            cbxConsoleMinLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxConsoleMinLevel.DropDownWidth = 121;
            cbxConsoleMinLevel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbxConsoleMinLevel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxConsoleMinLevel.FormattingEnabled = true;
            cbxConsoleMinLevel.IntegralHeight = false;
            cbxConsoleMinLevel.ItemHeight = 43;
            cbxConsoleMinLevel.Location = new Point(215, 103);
            cbxConsoleMinLevel.Margin = new Padding(2);
            cbxConsoleMinLevel.MaxDropDownItems = 4;
            cbxConsoleMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            cbxConsoleMinLevel.Name = "cbxConsoleMinLevel";
            cbxConsoleMinLevel.Size = new Size(150, 49);
            cbxConsoleMinLevel.StartIndex = 0;
            cbxConsoleMinLevel.TabIndex = 22;
            // 
            // cbxFileMinLevel
            // 
            cbxFileMinLevel.AllowDrop = true;
            cbxFileMinLevel.AutoResize = false;
            cbxFileMinLevel.BackColor = Color.FromArgb(242, 242, 242);
            cbxFileMinLevel.CausesValidation = false;
            cbxFileMinLevel.Depth = 0;
            cbxFileMinLevel.DrawMode = DrawMode.OwnerDrawVariable;
            cbxFileMinLevel.DropDownHeight = 174;
            cbxFileMinLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFileMinLevel.DropDownWidth = 121;
            cbxFileMinLevel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbxFileMinLevel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbxFileMinLevel.FormattingEnabled = true;
            cbxFileMinLevel.IntegralHeight = false;
            cbxFileMinLevel.ItemHeight = 43;
            cbxFileMinLevel.Location = new Point(215, 34);
            cbxFileMinLevel.Margin = new Padding(2);
            cbxFileMinLevel.MaxDropDownItems = 4;
            cbxFileMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            cbxFileMinLevel.Name = "cbxFileMinLevel";
            cbxFileMinLevel.Size = new Size(150, 49);
            cbxFileMinLevel.StartIndex = 0;
            cbxFileMinLevel.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.BackColor = Color.FromArgb(242, 242, 242);
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(681, 324);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(64, 36);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += SaveSettingsButtonClicked;
            // 
            // lblDarkMode
            // 
            lblDarkMode.BackColor = Color.FromArgb(242, 242, 242);
            lblDarkMode.Depth = 0;
            lblDarkMode.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDarkMode.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDarkMode.Location = new Point(39, 175);
            lblDarkMode.Margin = new Padding(2, 0, 2, 0);
            lblDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            lblDarkMode.Name = "lblDarkMode";
            lblDarkMode.Size = new Size(163, 28);
            lblDarkMode.TabIndex = 19;
            lblDarkMode.Text = "Is Dark Mode?";
            // 
            // swtEnableGrpcServer
            // 
            swtEnableGrpcServer.BackColor = Color.FromArgb(242, 242, 242);
            swtEnableGrpcServer.Checked = true;
            swtEnableGrpcServer.CheckState = CheckState.Indeterminate;
            swtEnableGrpcServer.Cursor = Cursors.Hand;
            swtEnableGrpcServer.Depth = 0;
            swtEnableGrpcServer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            swtEnableGrpcServer.Location = new Point(225, 213);
            swtEnableGrpcServer.Margin = new Padding(0);
            swtEnableGrpcServer.MouseLocation = new Point(-1, -1);
            swtEnableGrpcServer.MouseState = MaterialSkin.MouseState.HOVER;
            swtEnableGrpcServer.Name = "swtEnableGrpcServer";
            swtEnableGrpcServer.Ripple = true;
            swtEnableGrpcServer.Size = new Size(48, 27);
            swtEnableGrpcServer.TabIndex = 27;
            swtEnableGrpcServer.UseVisualStyleBackColor = false;
            // 
            // lblEnableGrpcServer
            // 
            lblEnableGrpcServer.BackColor = Color.FromArgb(242, 242, 242);
            lblEnableGrpcServer.Depth = 0;
            lblEnableGrpcServer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEnableGrpcServer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEnableGrpcServer.Location = new Point(39, 217);
            lblEnableGrpcServer.Margin = new Padding(2, 0, 2, 0);
            lblEnableGrpcServer.MouseState = MaterialSkin.MouseState.HOVER;
            lblEnableGrpcServer.Name = "lblEnableGrpcServer";
            lblEnableGrpcServer.Size = new Size(163, 28);
            lblEnableGrpcServer.TabIndex = 26;
            lblEnableGrpcServer.Text = "Enable GRPC Server";
            // 
            // swtEnableWebClient
            // 
            swtEnableWebClient.BackColor = Color.FromArgb(242, 242, 242);
            swtEnableWebClient.Checked = true;
            swtEnableWebClient.CheckState = CheckState.Indeterminate;
            swtEnableWebClient.Cursor = Cursors.Hand;
            swtEnableWebClient.Depth = 0;
            swtEnableWebClient.ForeColor = Color.FromArgb(222, 0, 0, 0);
            swtEnableWebClient.Location = new Point(225, 254);
            swtEnableWebClient.Margin = new Padding(0);
            swtEnableWebClient.MouseLocation = new Point(-1, -1);
            swtEnableWebClient.MouseState = MaterialSkin.MouseState.HOVER;
            swtEnableWebClient.Name = "swtEnableWebClient";
            swtEnableWebClient.Ripple = true;
            swtEnableWebClient.Size = new Size(48, 27);
            swtEnableWebClient.TabIndex = 29;
            swtEnableWebClient.UseVisualStyleBackColor = false;
            // 
            // lblEnableWebClient
            // 
            lblEnableWebClient.BackColor = Color.FromArgb(242, 242, 242);
            lblEnableWebClient.Depth = 0;
            lblEnableWebClient.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEnableWebClient.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEnableWebClient.Location = new Point(39, 258);
            lblEnableWebClient.Margin = new Padding(2, 0, 2, 0);
            lblEnableWebClient.MouseState = MaterialSkin.MouseState.HOVER;
            lblEnableWebClient.Name = "lblEnableWebClient";
            lblEnableWebClient.Size = new Size(163, 28);
            lblEnableWebClient.TabIndex = 28;
            lblEnableWebClient.Text = "Enable Web Client";
            // 
            // lblRequiresRestart1
            // 
            lblRequiresRestart1.BackColor = Color.FromArgb(242, 242, 242);
            lblRequiresRestart1.Depth = 0;
            lblRequiresRestart1.Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRequiresRestart1.FontType = MaterialSkin.MaterialSkinManager.fontType.Overline;
            lblRequiresRestart1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblRequiresRestart1.Location = new Point(39, 235);
            lblRequiresRestart1.Margin = new Padding(2, 0, 2, 0);
            lblRequiresRestart1.MouseState = MaterialSkin.MouseState.HOVER;
            lblRequiresRestart1.Name = "lblRequiresRestart1";
            lblRequiresRestart1.Size = new Size(163, 14);
            lblRequiresRestart1.TabIndex = 30;
            lblRequiresRestart1.Text = "Requires App Restart";
            // 
            // lblRequiresRestart2
            // 
            lblRequiresRestart2.BackColor = Color.FromArgb(242, 242, 242);
            lblRequiresRestart2.Depth = 0;
            lblRequiresRestart2.Font = new Font("Roboto", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRequiresRestart2.FontType = MaterialSkin.MaterialSkinManager.fontType.Overline;
            lblRequiresRestart2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblRequiresRestart2.Location = new Point(39, 276);
            lblRequiresRestart2.Margin = new Padding(2, 0, 2, 0);
            lblRequiresRestart2.MouseState = MaterialSkin.MouseState.HOVER;
            lblRequiresRestart2.Name = "lblRequiresRestart2";
            lblRequiresRestart2.Size = new Size(163, 14);
            lblRequiresRestart2.TabIndex = 31;
            lblRequiresRestart2.Text = "Requires App Restart";
            // 
            // swtRunOnStartup
            // 
            swtRunOnStartup.BackColor = Color.FromArgb(242, 242, 242);
            swtRunOnStartup.Checked = true;
            swtRunOnStartup.CheckState = CheckState.Indeterminate;
            swtRunOnStartup.Cursor = Cursors.Hand;
            swtRunOnStartup.Depth = 0;
            swtRunOnStartup.ForeColor = Color.FromArgb(222, 0, 0, 0);
            swtRunOnStartup.Location = new Point(225, 294);
            swtRunOnStartup.Margin = new Padding(0);
            swtRunOnStartup.MouseLocation = new Point(-1, -1);
            swtRunOnStartup.MouseState = MaterialSkin.MouseState.HOVER;
            swtRunOnStartup.Name = "swtRunOnStartup";
            swtRunOnStartup.Ripple = true;
            swtRunOnStartup.Size = new Size(48, 27);
            swtRunOnStartup.TabIndex = 33;
            swtRunOnStartup.UseVisualStyleBackColor = false;
            // 
            // lblRunOnStartup
            // 
            lblRunOnStartup.BackColor = Color.FromArgb(242, 242, 242);
            lblRunOnStartup.Depth = 0;
            lblRunOnStartup.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblRunOnStartup.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblRunOnStartup.Location = new Point(39, 298);
            lblRunOnStartup.Margin = new Padding(2, 0, 2, 0);
            lblRunOnStartup.MouseState = MaterialSkin.MouseState.HOVER;
            lblRunOnStartup.Name = "lblRunOnStartup";
            lblRunOnStartup.Size = new Size(163, 28);
            lblRunOnStartup.TabIndex = 32;
            lblRunOnStartup.Text = "Run On Startup";
            // 
            // SettingsTabControl
            // 
            Controls.Add(swtRunOnStartup);
            Controls.Add(lblRunOnStartup);
            Controls.Add(lblRequiresRestart2);
            Controls.Add(lblRequiresRestart1);
            Controls.Add(swtEnableWebClient);
            Controls.Add(lblEnableWebClient);
            Controls.Add(swtEnableGrpcServer);
            Controls.Add(lblEnableGrpcServer);
            Controls.Add(lblConsoleMinLogLevel);
            Controls.Add(lblFileMinLogLevel);
            Controls.Add(swtIsDarkMode);
            Controls.Add(cbxConsoleMinLevel);
            Controls.Add(cbxFileMinLevel);
            Controls.Add(btnSave);
            Controls.Add(lblDarkMode);
            Name = "SettingsTabControl";
            Size = new Size(781, 393);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblConsoleMinLogLevel;
        private MaterialSkin.Controls.MaterialLabel lblFileMinLogLevel;
        private MaterialSkin.Controls.MaterialSwitch swtIsDarkMode;
        private MaterialSkin.Controls.MaterialComboBox cbxConsoleMinLevel;
        private MaterialSkin.Controls.MaterialComboBox cbxFileMinLevel;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialLabel lblDarkMode;
        private MaterialSkin.Controls.MaterialSwitch swtEnableGrpcServer;
        private MaterialSkin.Controls.MaterialLabel lblEnableGrpcServer;
        private MaterialSkin.Controls.MaterialSwitch swtEnableWebClient;
        private MaterialSkin.Controls.MaterialLabel lblEnableWebClient;
        private MaterialSkin.Controls.MaterialLabel lblRequiresRestart1;
        private MaterialSkin.Controls.MaterialLabel lblRequiresRestart2;
        private MaterialSkin.Controls.MaterialSwitch swtRunOnStartup;
        private MaterialSkin.Controls.MaterialLabel lblRunOnStartup;
    }
}
