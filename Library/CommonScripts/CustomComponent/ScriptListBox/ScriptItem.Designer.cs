namespace CommonScripts.CustomComponent.ScriptListBox
{
    partial class ScriptItem
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblScriptName = new MaterialSkin.Controls.MaterialLabel();
            this.pbxStatus = new System.Windows.Forms.PictureBox();
            this.pbxMenu = new System.Windows.Forms.PictureBox();
            this.lblScriptType = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScriptName
            // 
            this.lblScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptName.Depth = 0;
            this.lblScriptName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblScriptName.Location = new System.Drawing.Point(25, 5);
            this.lblScriptName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(242, 20);
            this.lblScriptName.TabIndex = 0;
            this.lblScriptName.Text = "ScriptName";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseClick);
            // 
            // pbxStatus
            // 
            this.pbxStatus.BackColor = System.Drawing.Color.Transparent;
            this.pbxStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxStatus.Image = global::CommonScripts.Properties.Resources.pause;
            this.pbxStatus.Location = new System.Drawing.Point(0, 5);
            this.pbxStatus.Name = "pbxStatus";
            this.pbxStatus.Padding = new System.Windows.Forms.Padding(2);
            this.pbxStatus.Size = new System.Drawing.Size(20, 20);
            this.pbxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxStatus.TabIndex = 1;
            this.pbxStatus.TabStop = false;
            this.pbxStatus.Click += new System.EventHandler(this.StatusButtonClicked);
            // 
            // pbxMenu
            // 
            this.pbxMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxMenu.BackColor = System.Drawing.Color.Transparent;
            this.pbxMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxMenu.Image = global::CommonScripts.Properties.Resources.menu_vertical;
            this.pbxMenu.Location = new System.Drawing.Point(380, 0);
            this.pbxMenu.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pbxMenu.Name = "pbxMenu";
            this.pbxMenu.Size = new System.Drawing.Size(30, 30);
            this.pbxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxMenu.TabIndex = 3;
            this.pbxMenu.TabStop = false;
            this.pbxMenu.Click += new System.EventHandler(this.MenuButtonClicked);
            // 
            // lblScriptType
            // 
            this.lblScriptType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptType.Depth = 0;
            this.lblScriptType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblScriptType.Location = new System.Drawing.Point(273, 5);
            this.lblScriptType.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblScriptType.Name = "lblScriptType";
            this.lblScriptType.Size = new System.Drawing.Size(101, 20);
            this.lblScriptType.TabIndex = 4;
            this.lblScriptType.Text = "Script Type";
            this.lblScriptType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseClick);
            // 
            // ScriptItem
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblScriptType);
            this.Controls.Add(this.pbxMenu);
            this.Controls.Add(this.pbxStatus);
            this.Controls.Add(this.lblScriptName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ScriptItem";
            this.Size = new System.Drawing.Size(410, 30);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Control_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.PictureBox pbxStatus;
        private System.Windows.Forms.PictureBox pbxMenu;
        private MaterialSkin.Controls.MaterialLabel lblScriptName;
        private MaterialSkin.Controls.MaterialLabel lblScriptType;
    }
}
