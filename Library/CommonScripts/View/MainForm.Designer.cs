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
            this.mtcMain = new MetroSet_UI.Controls.MetroSetTabControl();
            this.mtpRun = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.pnlScripts = new MetroSet_UI.Controls.MetroSetPanel();
            this.styleManager = new MetroSet_UI.Components.StyleManager();
            this.lblRunAddScript = new MetroSet_UI.Controls.MetroSetLabel();
            this.mtpConsole = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mtcMain.SuspendLayout();
            this.mtpRun.SuspendLayout();
            this.mtpConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.StyleManager = this.styleManager;
            // 
            // mtcMain
            // 
            this.mtcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtcMain.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.mtcMain.AnimateTime = 200;
            this.mtcMain.BackgroundColor = System.Drawing.Color.White;
            this.mtcMain.Controls.Add(this.mtpRun);
            this.mtcMain.Controls.Add(this.mtpConsole);
            this.mtcMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mtcMain.IsDerivedStyle = true;
            this.mtcMain.ItemSize = new System.Drawing.Size(100, 38);
            this.mtcMain.Location = new System.Drawing.Point(15, 93);
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.SelectedTextColor = System.Drawing.Color.White;
            this.mtcMain.Size = new System.Drawing.Size(644, 351);
            this.mtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mtcMain.Speed = 100;
            this.mtcMain.Style = MetroSet_UI.Enums.Style.Light;
            this.mtcMain.StyleManager = this.styleManager;
            this.mtcMain.TabIndex = 0;
            this.mtcMain.TabStyle = MetroSet_UI.Enums.TabStyle.Style2;
            this.mtcMain.ThemeAuthor = "Narwin";
            this.mtcMain.ThemeName = "MetroLite";
            this.mtcMain.UnselectedTextColor = System.Drawing.Color.Gray;
            this.mtcMain.UseAnimation = false;
            // 
            // mtpRun
            // 
            this.mtpRun.BaseColor = System.Drawing.Color.White;
            this.mtpRun.Controls.Add(this.pnlScripts);
            this.mtpRun.Controls.Add(this.lblRunAddScript);
            this.mtpRun.Font = null;
            this.mtpRun.ImageIndex = 0;
            this.mtpRun.ImageKey = null;
            this.mtpRun.IsDerivedStyle = true;
            this.mtpRun.Location = new System.Drawing.Point(4, 42);
            this.mtpRun.Name = "mtpRun";
            this.mtpRun.Size = new System.Drawing.Size(636, 305);
            this.mtpRun.Style = MetroSet_UI.Enums.Style.Light;
            this.mtpRun.StyleManager = this.styleManager;
            this.mtpRun.TabIndex = 0;
            this.mtpRun.Text = "Run";
            this.mtpRun.ThemeAuthor = "Narwin";
            this.mtpRun.ThemeName = "MetroLite";
            this.mtpRun.ToolTipText = null;
            // 
            // pnlScripts
            // 
            this.pnlScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScripts.AutoScroll = true;
            this.pnlScripts.BackgroundColor = System.Drawing.Color.White;
            this.pnlScripts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlScripts.BorderThickness = 0;
            this.pnlScripts.IsDerivedStyle = true;
            this.pnlScripts.Location = new System.Drawing.Point(3, 3);
            this.pnlScripts.Name = "pnlScripts";
            this.pnlScripts.Padding = new System.Windows.Forms.Padding(500);
            this.pnlScripts.Size = new System.Drawing.Size(630, 279);
            this.pnlScripts.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlScripts.StyleManager = this.styleManager;
            this.pnlScripts.TabIndex = 4;
            this.pnlScripts.ThemeAuthor = "Narwin";
            this.pnlScripts.ThemeName = "MetroLite";
            // 
            // styleManager
            // 
            this.styleManager.CustomTheme = "";
            this.styleManager.MetroForm = this;
            this.styleManager.Style = MetroSet_UI.Enums.Style.Light;
            this.styleManager.ThemeAuthor = "Narwin";
            this.styleManager.ThemeName = "MetroLite";
            // 
            // lblRunAddScript
            // 
            this.lblRunAddScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRunAddScript.AutoSize = true;
            this.lblRunAddScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRunAddScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRunAddScript.IsDerivedStyle = true;
            this.lblRunAddScript.Location = new System.Drawing.Point(3, 288);
            this.lblRunAddScript.Name = "lblRunAddScript";
            this.lblRunAddScript.Size = new System.Drawing.Size(124, 17);
            this.lblRunAddScript.Style = MetroSet_UI.Enums.Style.Light;
            this.lblRunAddScript.StyleManager = this.styleManager;
            this.lblRunAddScript.TabIndex = 3;
            this.lblRunAddScript.Text = "Add a new script...";
            this.lblRunAddScript.ThemeAuthor = "Narwin";
            this.lblRunAddScript.ThemeName = "MetroLite";
            this.lblRunAddScript.Click += new System.EventHandler(this.AddScript);
            // 
            // mtpConsole
            // 
            this.mtpConsole.BaseColor = System.Drawing.Color.White;
            this.mtpConsole.Controls.Add(this.rtbConsole);
            this.mtpConsole.Font = null;
            this.mtpConsole.ImageIndex = 0;
            this.mtpConsole.ImageKey = null;
            this.mtpConsole.IsDerivedStyle = true;
            this.mtpConsole.Location = new System.Drawing.Point(4, 42);
            this.mtpConsole.Name = "mtpConsole";
            this.mtpConsole.Size = new System.Drawing.Size(636, 305);
            this.mtpConsole.Style = MetroSet_UI.Enums.Style.Light;
            this.mtpConsole.StyleManager = this.styleManager;
            this.mtpConsole.TabIndex = 0;
            this.mtpConsole.Text = "Console";
            this.mtpConsole.ThemeAuthor = "Narwin";
            this.mtpConsole.ThemeName = "MetroLite";
            this.mtpConsole.ToolTipText = null;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbConsole.Location = new System.Drawing.Point(3, 3);
            this.rtbConsole.MaxLength = 32767;
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(630, 279);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("appNotifyIcon.Icon")));
            this.appNotifyIcon.Visible = true;
            this.appNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.appNotifyIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 451);
            this.Controls.Add(this.mtcMain);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StyleManager = this.styleManager;
            this.Text = "Common Scripts";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Controls.SetChildIndex(this.mtcMain, 0);
            this.Controls.SetChildIndex(this.metroSetControlBox1, 0);
            this.mtcMain.ResumeLayout(false);
            this.mtpRun.ResumeLayout(false);
            this.mtpRun.PerformLayout();
            this.mtpConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetTabControl mtcMain;
        private MetroSet_UI.Child.MetroSetSetTabPage mtpRun;
        private MetroSet_UI.Child.MetroSetSetTabPage mtpConsole;
        private MetroSet_UI.Controls.MetroSetLabel lblRunAddScript;
        private MetroSet_UI.Controls.MetroSetPanel pnlScripts;
        private MetroSet_UI.Components.StyleManager styleManager;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.RichTextBox rtbConsole;
    }
}

