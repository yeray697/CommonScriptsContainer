using CommonScripts.CustomComponent.ScriptListBox;
using System.Drawing;

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
            this.mtcMain = new MetroFramework.Controls.MetroTabControl();
            this.mtpRun = new MetroFramework.Controls.MetroTabPage();
            this.pnlScripts = new MetroFramework.Controls.MetroPanel();
            this.lblRunAddScript = new MetroFramework.Controls.MetroLabel();
            this.mtpSettings = new MetroFramework.Controls.MetroTabPage();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.mtcMain.SuspendLayout();
            this.mtpRun.SuspendLayout();
            this.pnlScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // mtcMain
            // 
            this.mtcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtcMain.Controls.Add(this.mtpRun);
            this.mtcMain.Controls.Add(this.mtpSettings);
            this.mtcMain.Location = new System.Drawing.Point(20, 60);
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.Size = new System.Drawing.Size(576, 331);
            this.mtcMain.TabIndex = 0;
            // 
            // mtpRun
            // 
            this.mtpRun.Controls.Add(this.pnlScripts);
            this.mtpRun.Controls.Add(this.lblRunAddScript);
            this.mtpRun.HorizontalScrollbar = true;
            this.mtpRun.HorizontalScrollbarBarColor = true;
            this.mtpRun.Location = new System.Drawing.Point(4, 35);
            this.mtpRun.Name = "mtpRun";
            this.mtpRun.Padding = new System.Windows.Forms.Padding(25);
            this.mtpRun.Size = new System.Drawing.Size(568, 292);
            this.mtpRun.TabIndex = 0;
            this.mtpRun.Text = "Run";
            this.mtpRun.VerticalScrollbar = true;
            this.mtpRun.VerticalScrollbarBarColor = true;
            // 
            // pnlScripts
            // 
            this.pnlScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScripts.AutoScroll = true;
            this.pnlScripts.HorizontalScrollbar = true;
            this.pnlScripts.HorizontalScrollbarBarColor = true;
            this.pnlScripts.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlScripts.HorizontalScrollbarSize = 10;
            this.pnlScripts.Location = new System.Drawing.Point(3, 3);
            this.pnlScripts.Name = "pnlScripts";
            this.pnlScripts.Size = new System.Drawing.Size(562, 259);
            this.pnlScripts.TabIndex = 4;
            this.pnlScripts.VerticalScrollbar = true;
            this.pnlScripts.VerticalScrollbarBarColor = true;
            this.pnlScripts.VerticalScrollbarHighlightOnWheel = false;
            this.pnlScripts.VerticalScrollbarSize = 10;
            // 
            // lblRunAddScript
            // 
            this.lblRunAddScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRunAddScript.AutoSize = true;
            this.lblRunAddScript.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblRunAddScript.ForeColor = System.Drawing.Color.Red;
            this.lblRunAddScript.Location = new System.Drawing.Point(3, 265);
            this.lblRunAddScript.Name = "lblRunAddScript";
            this.lblRunAddScript.Size = new System.Drawing.Size(120, 19);
            this.lblRunAddScript.TabIndex = 3;
            this.lblRunAddScript.Text = "Add a new script...";
            this.lblRunAddScript.UseStyleColors = true;
            this.lblRunAddScript.Click += new System.EventHandler(this.lblRunAddScript_Click);
            // 
            // mtpSettings
            // 
            this.mtpSettings.HorizontalScrollbar = true;
            this.mtpSettings.HorizontalScrollbarBarColor = true;
            this.mtpSettings.Location = new System.Drawing.Point(4, 35);
            this.mtpSettings.Name = "mtpSettings";
            this.mtpSettings.Padding = new System.Windows.Forms.Padding(25);
            this.mtpSettings.Size = new System.Drawing.Size(568, 292);
            this.mtpSettings.TabIndex = 0;
            this.mtpSettings.Text = "Settings";
            this.mtpSettings.VerticalScrollbar = true;
            this.mtpSettings.VerticalScrollbarBarColor = true;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            this.metroStyleManager.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroStyleManager.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 411);
            this.Controls.Add(this.mtcMain);
            this.Name = "MainForm";
            this.Text = "Common Scripts";
            this.mtcMain.ResumeLayout(false);
            this.mtpRun.ResumeLayout(false);
            this.mtpRun.PerformLayout();
            this.pnlScripts.ResumeLayout(false);
            this.pnlScripts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl mtcMain;
        private MetroFramework.Controls.MetroTabPage mtpRun;
        private MetroFramework.Controls.MetroTabPage mtpSettings;
        private MetroFramework.Controls.MetroLabel lblRunAddScript;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroPanel pnlScripts;
    }
}

