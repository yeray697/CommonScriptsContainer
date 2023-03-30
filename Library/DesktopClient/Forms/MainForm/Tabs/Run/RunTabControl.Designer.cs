namespace DesktopClient.Forms.MainForm.Tabs.Run
{
    partial class RunTabControl
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
            this.lblRunTitle = new MaterialSkin.Controls.MaterialLabel();
            this.btnRunAddScript = new MaterialSkin.Controls.MaterialButton();
            this.pnlScripts = new System.Windows.Forms.Panel();
            this.cmsScriptList = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsScriptList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRunTitle
            // 
            this.lblRunTitle.AutoSize = true;
            this.lblRunTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblRunTitle.Depth = 0;
            this.lblRunTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRunTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblRunTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRunTitle.Location = new System.Drawing.Point(2, 3);
            this.lblRunTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRunTitle.Name = "lblRunTitle";
            this.lblRunTitle.Size = new System.Drawing.Size(122, 29);
            this.lblRunTitle.TabIndex = 6;
            this.lblRunTitle.Text = "Run Scripts";
            // 
            // btnRunAddScript
            // 
            this.btnRunAddScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAddScript.AutoSize = false;
            this.btnRunAddScript.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRunAddScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRunAddScript.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btnRunAddScript.Depth = 0;
            this.btnRunAddScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRunAddScript.HighEmphasis = true;
            this.btnRunAddScript.Icon = global::DesktopClient.Resources.plus;
            this.btnRunAddScript.Location = new System.Drawing.Point(526, 0);
            this.btnRunAddScript.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRunAddScript.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRunAddScript.Name = "btnRunAddScript";
            this.btnRunAddScript.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRunAddScript.Size = new System.Drawing.Size(128, 36);
            this.btnRunAddScript.TabIndex = 8;
            this.btnRunAddScript.Text = "Add Script";
            this.btnRunAddScript.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRunAddScript.UseAccentColor = true;
            this.btnRunAddScript.UseVisualStyleBackColor = false;
            this.btnRunAddScript.Click += new System.EventHandler(this.AddScriptButtonClicked);
            // 
            // pnlScripts
            // 
            this.pnlScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScripts.AutoScroll = true;
            this.pnlScripts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pnlScripts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlScripts.Location = new System.Drawing.Point(0, 45);
            this.pnlScripts.Name = "pnlScripts";
            this.pnlScripts.Size = new System.Drawing.Size(654, 295);
            this.pnlScripts.TabIndex = 7;
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
            this.cmsScriptList.Size = new System.Drawing.Size(118, 48);
            this.cmsScriptList.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // RunTabControl
            // 
            this.Controls.Add(this.lblRunTitle);
            this.Controls.Add(this.btnRunAddScript);
            this.Controls.Add(this.pnlScripts);
            this.Name = "RunTabControl";
            this.Size = new System.Drawing.Size(654, 340);
            this.Load += new System.EventHandler(this.OnLoad);
            this.cmsScriptList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblRunTitle;
        private MaterialSkin.Controls.MaterialButton btnRunAddScript;
        private System.Windows.Forms.Panel pnlScripts;
        private MaterialSkin.Controls.MaterialContextMenuStrip cmsScriptList;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}
