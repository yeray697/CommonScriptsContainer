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
            this.pbxEdit = new System.Windows.Forms.PictureBox();
            this.pbxRemove = new System.Windows.Forms.PictureBox();
            this.lblScriptType = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemove)).BeginInit();
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
            this.lblScriptName.Size = new System.Drawing.Size(218, 20);
            this.lblScriptName.TabIndex = 0;
            this.lblScriptName.Text = "ScriptName";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // pbxEdit
            // 
            this.pbxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pbxEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEdit.Image = global::CommonScripts.Properties.Resources.edit;
            this.pbxEdit.Location = new System.Drawing.Point(365, 5);
            this.pbxEdit.Name = "pbxEdit";
            this.pbxEdit.Size = new System.Drawing.Size(20, 20);
            this.pbxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEdit.TabIndex = 2;
            this.pbxEdit.TabStop = false;
            this.pbxEdit.Click += new System.EventHandler(this.EditButtonClicked);
            // 
            // pbxRemove
            // 
            this.pbxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxRemove.BackColor = System.Drawing.Color.Transparent;
            this.pbxRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRemove.Image = global::CommonScripts.Properties.Resources.delete;
            this.pbxRemove.Location = new System.Drawing.Point(390, 5);
            this.pbxRemove.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pbxRemove.Name = "pbxRemove";
            this.pbxRemove.Size = new System.Drawing.Size(20, 20);
            this.pbxRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRemove.TabIndex = 3;
            this.pbxRemove.TabStop = false;
            this.pbxRemove.Click += new System.EventHandler(this.RemoveButtonClicked);
            // 
            // lblScriptType
            // 
            this.lblScriptType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptType.Depth = 0;
            this.lblScriptType.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblScriptType.Location = new System.Drawing.Point(249, 5);
            this.lblScriptType.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblScriptType.Name = "lblScriptType";
            this.lblScriptType.Size = new System.Drawing.Size(100, 20);
            this.lblScriptType.TabIndex = 4;
            this.lblScriptType.Text = "Script Type";
            // 
            // ScriptItem
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblScriptType);
            this.Controls.Add(this.pbxRemove);
            this.Controls.Add(this.pbxEdit);
            this.Controls.Add(this.pbxStatus);
            this.Controls.Add(this.lblScriptName);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ScriptItem";
            this.Size = new System.Drawing.Size(410, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.PictureBox pbxStatus;
        private System.Windows.Forms.PictureBox pbxEdit;
        private System.Windows.Forms.PictureBox pbxRemove;
        private MaterialSkin.Controls.MaterialLabel lblScriptName;
        private MaterialSkin.Controls.MaterialLabel lblScriptType;
    }
}
