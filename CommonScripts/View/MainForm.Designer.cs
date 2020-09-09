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
            this.mtcMain = new MetroSet_UI.Controls.MetroSetTabControl();
            this.mtpRun = new MetroSet_UI.Child.MetroSetTabPage();
            this.pnlScripts = new MetroSet_UI.Controls.MetroSetPanel();
            this.styleManager = new MetroSet_UI.StyleManager();
            this.lblRunAddScript = new MetroSet_UI.Controls.MetroSetLabel();
            this.mtpSettings = new MetroSet_UI.Child.MetroSetTabPage();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.mtcMain.SuspendLayout();
            this.mtpRun.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtcMain
            // 
            this.mtcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtcMain.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.mtcMain.AnimateTime = 200;
            this.mtcMain.Controls.Add(this.mtpRun);
            this.mtcMain.Controls.Add(this.mtpSettings);
            this.mtcMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mtcMain.ItemSize = new System.Drawing.Size(100, 38);
            this.mtcMain.Location = new System.Drawing.Point(15, 93);
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.Size = new System.Drawing.Size(644, 351);
            this.mtcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mtcMain.Speed = 20;
            this.mtcMain.Style = MetroSet_UI.Design.Style.Light;
            this.mtcMain.StyleManager = this.styleManager;
            this.mtcMain.TabIndex = 0;
            this.mtcMain.TabStyle = MetroSet_UI.Enums.TabStyle.Style2;
            this.mtcMain.ThemeAuthor = "Narwin";
            this.mtcMain.ThemeName = "MetroLite";
            this.mtcMain.UseAnimation = true;
            // 
            // mtpRun
            // 
            this.mtpRun.BaseColor = System.Drawing.Color.White;
            this.mtpRun.Controls.Add(this.pnlScripts);
            this.mtpRun.Controls.Add(this.lblRunAddScript);
            this.mtpRun.ImageIndex = 0;
            this.mtpRun.ImageKey = null;
            this.mtpRun.Location = new System.Drawing.Point(4, 42);
            this.mtpRun.Name = "mtpRun";
            this.mtpRun.Size = new System.Drawing.Size(636, 305);
            this.mtpRun.Style = MetroSet_UI.Design.Style.Light;
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
            this.pnlScripts.Location = new System.Drawing.Point(3, 3);
            this.pnlScripts.Name = "pnlScripts";
            this.pnlScripts.Padding = new System.Windows.Forms.Padding(500);
            this.pnlScripts.Size = new System.Drawing.Size(630, 279);
            this.pnlScripts.Style = MetroSet_UI.Design.Style.Light;
            this.pnlScripts.StyleManager = this.styleManager;
            this.pnlScripts.TabIndex = 4;
            this.pnlScripts.ThemeAuthor = "Narwin";
            this.pnlScripts.ThemeName = "MetroLite";
            // 
            // styleManager
            // 
            this.styleManager.CustomTheme = "";
            this.styleManager.MetroForm = this;
            this.styleManager.Style = MetroSet_UI.Design.Style.Light;
            this.styleManager.ThemeAuthor = "Narwin";
            this.styleManager.ThemeName = "MetroLite";
            // 
            // lblRunAddScript
            // 
            this.lblRunAddScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRunAddScript.AutoSize = true;
            this.lblRunAddScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRunAddScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRunAddScript.Location = new System.Drawing.Point(3, 288);
            this.lblRunAddScript.Name = "lblRunAddScript";
            this.lblRunAddScript.Size = new System.Drawing.Size(124, 17);
            this.lblRunAddScript.Style = MetroSet_UI.Design.Style.Light;
            this.lblRunAddScript.StyleManager = this.styleManager;
            this.lblRunAddScript.TabIndex = 3;
            this.lblRunAddScript.Text = "Add a new script...";
            this.lblRunAddScript.ThemeAuthor = "Narwin";
            this.lblRunAddScript.ThemeName = "MetroLite";
            this.lblRunAddScript.Click += new System.EventHandler(this.AddScript);
            // 
            // mtpSettings
            // 
            this.mtpSettings.BaseColor = System.Drawing.Color.White;
            this.mtpSettings.ImageIndex = 0;
            this.mtpSettings.ImageKey = null;
            this.mtpSettings.Location = new System.Drawing.Point(4, 42);
            this.mtpSettings.Name = "mtpSettings";
            this.mtpSettings.Size = new System.Drawing.Size(636, 305);
            this.mtpSettings.Style = MetroSet_UI.Design.Style.Light;
            this.mtpSettings.StyleManager = this.styleManager;
            this.mtpSettings.TabIndex = 0;
            this.mtpSettings.Text = "Settings";
            this.mtpSettings.ThemeAuthor = "Narwin";
            this.mtpSettings.ThemeName = "MetroLite";
            this.mtpSettings.ToolTipText = null;
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.Location = new System.Drawing.Point(573, 1);
            this.metroSetControlBox1.MaximizeBox = true;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = true;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Design.Style.Light;
            this.metroSetControlBox1.StyleManager = this.styleManager;
            this.metroSetControlBox1.TabIndex = 1;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLite";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 451);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.mtcMain);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StyleManager = this.styleManager;
            this.Text = "Common Scripts";
            this.mtcMain.ResumeLayout(false);
            this.mtpRun.ResumeLayout(false);
            this.mtpRun.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetTabControl mtcMain;
        private MetroSet_UI.Child.MetroSetTabPage mtpRun;
        private MetroSet_UI.Child.MetroSetTabPage mtpSettings;
        private MetroSet_UI.Controls.MetroSetLabel lblRunAddScript;
        private MetroSet_UI.Controls.MetroSetPanel pnlScripts;
        private MetroSet_UI.StyleManager styleManager;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
    }
}

