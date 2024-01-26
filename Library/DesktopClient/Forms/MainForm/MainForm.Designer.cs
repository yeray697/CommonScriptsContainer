namespace DesktopClient.Forms.MainForm
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
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mtcMain = new MaterialSkin.Controls.MaterialTabControl();
            this.mtpRun = new System.Windows.Forms.TabPage();
            this.runTabControl = new DesktopClient.Forms.MainForm.Tabs.Run.RunTabControl();
            this.mtpConsole = new System.Windows.Forms.TabPage();
            this.consoleTabControl = new DesktopClient.Forms.MainForm.Tabs.Console.ConsoleTabControl();
            this.mtpSettings = new System.Windows.Forms.TabPage();
            this.settingsTabControl = new DesktopClient.Forms.MainForm.Tabs.Settings.SettingsTabControl();
            this.drawerImageList = new System.Windows.Forms.ImageList(this.components);
            this.mtcMain.SuspendLayout();
            this.mtpRun.SuspendLayout();
            this.mtpConsole.SuspendLayout();
            this.mtpSettings.SuspendLayout();
            this.SuspendLayout();
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
            this.mtcMain.ImageList = this.drawerImageList;
            this.mtcMain.Location = new System.Drawing.Point(0, 64);
            this.mtcMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtcMain.Multiline = true;
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.Size = new System.Drawing.Size(635, 375);
            this.mtcMain.TabIndex = 3;
            this.mtcMain.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Tab_Selecting);
            // 
            // mtpRun
            // 
            this.mtpRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpRun.Controls.Add(this.runTabControl);
            this.mtpRun.ImageKey = "script.png";
            this.mtpRun.Location = new System.Drawing.Point(4, 31);
            this.mtpRun.Name = "mtpRun";
            this.mtpRun.Padding = new System.Windows.Forms.Padding(3);
            this.mtpRun.Size = new System.Drawing.Size(627, 340);
            this.mtpRun.TabIndex = 0;
            this.mtpRun.Text = "Run";
            // 
            // runTabControl
            // 
            this.runTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.runTabControl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.runTabControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.runTabControl.Location = new System.Drawing.Point(0, 0);
            this.runTabControl.Name = "runTabControl";
            this.runTabControl.Padding = new System.Windows.Forms.Padding(8, 11, 0, 1);
            this.runTabControl.Size = new System.Drawing.Size(627, 340);
            this.runTabControl.TabIndex = 0;
            // 
            // mtpConsole
            // 
            this.mtpConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpConsole.Controls.Add(this.consoleTabControl);
            this.mtpConsole.ImageKey = "log.png";
            this.mtpConsole.Location = new System.Drawing.Point(4, 31);
            this.mtpConsole.Name = "mtpConsole";
            this.mtpConsole.Padding = new System.Windows.Forms.Padding(3);
            this.mtpConsole.Size = new System.Drawing.Size(627, 340);
            this.mtpConsole.TabIndex = 1;
            this.mtpConsole.Text = "Console";
            // 
            // consoleTabControl
            // 
            this.consoleTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.consoleTabControl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.consoleTabControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.consoleTabControl.Location = new System.Drawing.Point(0, 0);
            this.consoleTabControl.Name = "consoleTabControl";
            this.consoleTabControl.Padding = new System.Windows.Forms.Padding(11, 11, 0, 0);
            this.consoleTabControl.Size = new System.Drawing.Size(627, 340);
            this.consoleTabControl.TabIndex = 0;
            // 
            // mtpSettings
            // 
            this.mtpSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.mtpSettings.Controls.Add(this.settingsTabControl);
            this.mtpSettings.ImageKey = "settings.png";
            this.mtpSettings.Location = new System.Drawing.Point(4, 31);
            this.mtpSettings.Name = "mtpSettings";
            this.mtpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.mtpSettings.Size = new System.Drawing.Size(627, 340);
            this.mtpSettings.TabIndex = 2;
            this.mtpSettings.Text = "Settings";
            this.mtpSettings.Enter += new System.EventHandler(this.SettingsTab_Open);
            this.mtpSettings.Leave += new System.EventHandler(this.SettingsTab_Leave);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.settingsTabControl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.settingsTabControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.settingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.PreventTabSettingsFromLeaving = false;
            this.settingsTabControl.Size = new System.Drawing.Size(627, 340);
            this.settingsTabControl.TabIndex = 0;
            // 
            // drawerImageList
            // 
            this.drawerImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.drawerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("drawerImageList.ImageStream")));
            this.drawerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.drawerImageList.Images.SetKeyName(0, "script.png");
            this.drawerImageList.Images.SetKeyName(1, "log.png");
            this.drawerImageList.Images.SetKeyName(2, "settings.png");
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(647, 451);
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
            this.mtpConsole.ResumeLayout(false);
            this.mtpSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private MaterialSkin.Controls.MaterialTabControl mtcMain;
        private System.Windows.Forms.TabPage mtpRun;
        private System.Windows.Forms.TabPage mtpConsole;
        private System.Windows.Forms.TabPage mtpSettings;
        private System.Windows.Forms.ImageList drawerImageList;
        private Tabs.Settings.SettingsTabControl settingsTabControl;
        private Tabs.Console.ConsoleTabControl consoleTabControl;
        private Tabs.Run.RunTabControl runTabControl;
    }
}

