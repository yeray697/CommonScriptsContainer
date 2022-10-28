namespace CommonScripts.View
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mtcMain = new MaterialSkin.Controls.MaterialTabControl();
            this.mtpRun = new System.Windows.Forms.TabPage();
            this.lblRunTitle = new MaterialSkin.Controls.MaterialLabel();
            this.btnRunAddScript = new MaterialSkin.Controls.MaterialButton();
            this.pnlScripts = new System.Windows.Forms.Panel();
            this.mtpConsole = new System.Windows.Forms.TabPage();
            this.mtpSettings = new System.Windows.Forms.TabPage();
            this.lblConsoleMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            this.lblFileMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            this.swtIsDarkMode = new MaterialSkin.Controls.MaterialSwitch();
            this.cbxConsoleMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxFileMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblDarkMode = new MaterialSkin.Controls.MaterialLabel();
            this.cmsScriptList = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtcMain.SuspendLayout();
            this.mtpRun.SuspendLayout();
            this.mtpConsole.SuspendLayout();
            this.mtpSettings.SuspendLayout();
            this.cmsScriptList.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rtbConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rtbConsole.Location = new System.Drawing.Point(3, 3);
            this.rtbConsole.MaxLength = 32767;
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(648, 341);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Visible = true;
            this.appNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppTrayIcon_DoubleClick);
            // 
            // mtcMain
            // 
            this.mtcMain.Controls.Add(this.mtpRun);
            this.mtcMain.Controls.Add(this.mtpConsole);
            this.mtcMain.Controls.Add(this.mtpSettings);
            this.mtcMain.Depth = 0;
            this.mtcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtcMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtcMain.Location = new System.Drawing.Point(0, 64);
            this.mtcMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtcMain.Multiline = true;
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.Size = new System.Drawing.Size(662, 375);
            this.mtcMain.TabIndex = 3;
            this.mtcMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabSelectingEvent);
            // 
            // mtpRun
            // 
            this.mtpRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpRun.Controls.Add(this.lblRunTitle);
            this.mtpRun.Controls.Add(this.btnRunAddScript);
            this.mtpRun.Controls.Add(this.pnlScripts);
            this.mtpRun.Location = new System.Drawing.Point(4, 24);
            this.mtpRun.Name = "mtpRun";
            this.mtpRun.Padding = new System.Windows.Forms.Padding(3);
            this.mtpRun.Size = new System.Drawing.Size(654, 347);
            this.mtpRun.TabIndex = 0;
            this.mtpRun.Text = "Run";
            // 
            // lblRunTitle
            // 
            this.lblRunTitle.AutoSize = true;
            this.lblRunTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblRunTitle.Depth = 0;
            this.lblRunTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRunTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblRunTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRunTitle.Location = new System.Drawing.Point(11, 7);
            this.lblRunTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRunTitle.Name = "lblRunTitle";
            this.lblRunTitle.Size = new System.Drawing.Size(122, 29);
            this.lblRunTitle.TabIndex = 0;
            this.lblRunTitle.Text = "Run Scripts";
            // 
            // btnRunAddScript
            // 
            this.btnRunAddScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAddScript.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRunAddScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRunAddScript.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btnRunAddScript.Depth = 0;
            this.btnRunAddScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRunAddScript.HighEmphasis = true;
            this.btnRunAddScript.Icon = null;
            this.btnRunAddScript.Location = new System.Drawing.Point(550, 0);
            this.btnRunAddScript.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRunAddScript.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRunAddScript.Name = "btnRunAddScript";
            this.btnRunAddScript.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRunAddScript.Size = new System.Drawing.Size(104, 36);
            this.btnRunAddScript.TabIndex = 5;
            this.btnRunAddScript.Text = "Add Script";
            this.btnRunAddScript.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRunAddScript.UseAccentColor = true;
            this.btnRunAddScript.UseVisualStyleBackColor = false;
            this.btnRunAddScript.Click += new System.EventHandler(this.AddScript);
            // 
            // pnlScripts
            // 
            this.pnlScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlScripts.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlScripts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlScripts.Location = new System.Drawing.Point(11, 54);
            this.pnlScripts.Name = "pnlScripts";
            this.pnlScripts.Size = new System.Drawing.Size(643, 293);
            this.pnlScripts.TabIndex = 4;
            // 
            // mtpConsole
            // 
            this.mtpConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpConsole.Controls.Add(this.rtbConsole);
            this.mtpConsole.Location = new System.Drawing.Point(4, 24);
            this.mtpConsole.Name = "mtpConsole";
            this.mtpConsole.Padding = new System.Windows.Forms.Padding(3);
            this.mtpConsole.Size = new System.Drawing.Size(654, 347);
            this.mtpConsole.TabIndex = 1;
            this.mtpConsole.Text = "Console";
            // 
            // mtpSettings
            // 
            this.mtpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpSettings.Controls.Add(this.lblConsoleMinLogLevel);
            this.mtpSettings.Controls.Add(this.lblFileMinLogLevel);
            this.mtpSettings.Controls.Add(this.swtIsDarkMode);
            this.mtpSettings.Controls.Add(this.cbxConsoleMinLevel);
            this.mtpSettings.Controls.Add(this.cbxFileMinLevel);
            this.mtpSettings.Controls.Add(this.btnSave);
            this.mtpSettings.Controls.Add(this.lblDarkMode);
            this.mtpSettings.Location = new System.Drawing.Point(4, 24);
            this.mtpSettings.Name = "mtpSettings";
            this.mtpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.mtpSettings.Size = new System.Drawing.Size(654, 347);
            this.mtpSettings.TabIndex = 2;
            this.mtpSettings.Text = "Settings";
            this.mtpSettings.Enter += new System.EventHandler(this.OpenSettingsTab);
            this.mtpSettings.Leave += new System.EventHandler(this.LeaveSettingsTab);
            // 
            // lblConsoleMinLogLevel
            // 
            this.lblConsoleMinLogLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblConsoleMinLogLevel.Depth = 0;
            this.lblConsoleMinLogLevel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblConsoleMinLogLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsoleMinLogLevel.Location = new System.Drawing.Point(219, 169);
            this.lblConsoleMinLogLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsoleMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConsoleMinLogLevel.Name = "lblConsoleMinLogLevel";
            this.lblConsoleMinLogLevel.Size = new System.Drawing.Size(133, 49);
            this.lblConsoleMinLogLevel.TabIndex = 18;
            this.lblConsoleMinLogLevel.Text = "Console Minimum Logging Level";
            // 
            // lblFileMinLogLevel
            // 
            this.lblFileMinLogLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblFileMinLogLevel.Depth = 0;
            this.lblFileMinLogLevel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFileMinLogLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileMinLogLevel.Location = new System.Drawing.Point(219, 98);
            this.lblFileMinLogLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFileMinLogLevel.Name = "lblFileMinLogLevel";
            this.lblFileMinLogLevel.Size = new System.Drawing.Size(133, 49);
            this.lblFileMinLogLevel.TabIndex = 17;
            this.lblFileMinLogLevel.Text = "File Minimum Logging Level";
            // 
            // swtIsDarkMode
            // 
            this.swtIsDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.swtIsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swtIsDarkMode.Depth = 0;
            this.swtIsDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.swtIsDarkMode.Location = new System.Drawing.Point(369, 56);
            this.swtIsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.swtIsDarkMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtIsDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtIsDarkMode.Name = "swtIsDarkMode";
            this.swtIsDarkMode.Ripple = true;
            this.swtIsDarkMode.Size = new System.Drawing.Size(44, 27);
            this.swtIsDarkMode.TabIndex = 16;
            this.swtIsDarkMode.UseVisualStyleBackColor = false;
            // 
            // cbxConsoleMinLevel
            // 
            this.cbxConsoleMinLevel.AllowDrop = true;
            this.cbxConsoleMinLevel.AutoResize = false;
            this.cbxConsoleMinLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbxConsoleMinLevel.CausesValidation = false;
            this.cbxConsoleMinLevel.Depth = 0;
            this.cbxConsoleMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxConsoleMinLevel.DropDownHeight = 174;
            this.cbxConsoleMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsoleMinLevel.DropDownWidth = 121;
            this.cbxConsoleMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxConsoleMinLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxConsoleMinLevel.FormattingEnabled = true;
            this.cbxConsoleMinLevel.IntegralHeight = false;
            this.cbxConsoleMinLevel.ItemHeight = 43;
            this.cbxConsoleMinLevel.Location = new System.Drawing.Point(369, 169);
            this.cbxConsoleMinLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxConsoleMinLevel.MaxDropDownItems = 4;
            this.cbxConsoleMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxConsoleMinLevel.Name = "cbxConsoleMinLevel";
            this.cbxConsoleMinLevel.Size = new System.Drawing.Size(109, 49);
            this.cbxConsoleMinLevel.StartIndex = 0;
            this.cbxConsoleMinLevel.TabIndex = 15;
            // 
            // cbxFileMinLevel
            // 
            this.cbxFileMinLevel.AllowDrop = true;
            this.cbxFileMinLevel.AutoResize = false;
            this.cbxFileMinLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbxFileMinLevel.CausesValidation = false;
            this.cbxFileMinLevel.Depth = 0;
            this.cbxFileMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxFileMinLevel.DropDownHeight = 174;
            this.cbxFileMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileMinLevel.DropDownWidth = 121;
            this.cbxFileMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxFileMinLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxFileMinLevel.FormattingEnabled = true;
            this.cbxFileMinLevel.IntegralHeight = false;
            this.cbxFileMinLevel.ItemHeight = 43;
            this.cbxFileMinLevel.Location = new System.Drawing.Point(369, 98);
            this.cbxFileMinLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxFileMinLevel.MaxDropDownItems = 4;
            this.cbxFileMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxFileMinLevel.Name = "cbxFileMinLevel";
            this.cbxFileMinLevel.Size = new System.Drawing.Size(109, 49);
            this.cbxFileMinLevel.StartIndex = 0;
            this.cbxFileMinLevel.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(584, 304);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveSettingsButtonClicked);
            // 
            // lblDarkMode
            // 
            this.lblDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblDarkMode.Depth = 0;
            this.lblDarkMode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDarkMode.Location = new System.Drawing.Point(219, 60);
            this.lblDarkMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(133, 28);
            this.lblDarkMode.TabIndex = 11;
            this.lblDarkMode.Text = "Is Dark Mode?";
            // 
            // cmsScriptList
            // 
            this.cmsScriptList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmsScriptList.Depth = 0;
            this.cmsScriptList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.cmsScriptList.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmsScriptList.Name = "cmsScriptList";
            this.cmsScriptList.Size = new System.Drawing.Size(181, 70);
            this.cmsScriptList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 451);
            this.Controls.Add(this.mtcMain);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.mtcMain;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 12, 12);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Common Scripts";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mtcMain.ResumeLayout(false);
            this.mtpRun.ResumeLayout(false);
            this.mtpRun.PerformLayout();
            this.mtpConsole.ResumeLayout(false);
            this.mtpSettings.ResumeLayout(false);
            this.mtpSettings.PerformLayout();
            this.cmsScriptList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private MaterialSkin.Controls.MaterialTabControl mtcMain;
        private System.Windows.Forms.TabPage mtpRun;
        private System.Windows.Forms.TabPage mtpConsole;
        private System.Windows.Forms.Panel pnlScripts;
        private MaterialSkin.Controls.MaterialLabel lblRunTitle;
        private MaterialSkin.Controls.MaterialButton btnRunAddScript;
        private System.Windows.Forms.TabPage mtpSettings;
        private MaterialSkin.Controls.MaterialLabel lblConsoleMinLogLevel;
        private MaterialSkin.Controls.MaterialLabel lblFileMinLogLevel;
        private MaterialSkin.Controls.MaterialSwitch swtIsDarkMode;
        private MaterialSkin.Controls.MaterialComboBox cbxConsoleMinLevel;
        private MaterialSkin.Controls.MaterialComboBox cbxFileMinLevel;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialLabel lblDarkMode;
        private MaterialSkin.Controls.MaterialContextMenuStrip cmsScriptList;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

