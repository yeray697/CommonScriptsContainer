using MetroSet_UI.Controls;

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
            this.lblScriptName = new MetroSet_UI.Controls.MetroSetLabel();
            this.pbxStatus = new System.Windows.Forms.PictureBox();
            this.pbxEdit = new System.Windows.Forms.PictureBox();
            this.pbxRemove = new System.Windows.Forms.PictureBox();
            this.lblScriptType = new MetroSet_UI.Controls.MetroSetLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScriptName
            // 
            this.lblScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblScriptName.Location = new System.Drawing.Point(30, 5);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(218, 20);
            this.lblScriptName.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptName.StyleManager = null;
            this.lblScriptName.TabIndex = 0;
            this.lblScriptName.Text = "ScriptName";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptName.ThemeAuthor = "Narwin";
            this.lblScriptName.ThemeName = "MetroLite";
            // 
            // pbxStatus
            // 
            this.pbxStatus.BackColor = System.Drawing.Color.Transparent;
            this.pbxStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxStatus.Image = global::CommonScripts.Properties.Resources.pause;
            this.pbxStatus.Location = new System.Drawing.Point(5, 5);
            this.pbxStatus.Name = "pbxStatus";
            this.pbxStatus.Padding = new System.Windows.Forms.Padding(2);
            this.pbxStatus.Size = new System.Drawing.Size(20, 20);
            this.pbxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxStatus.TabIndex = 1;
            this.pbxStatus.TabStop = false;
            this.pbxStatus.Click += new System.EventHandler(this.pbxStatus_Click);
            // 
            // pbxEdit
            // 
            this.pbxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pbxEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEdit.Image = global::CommonScripts.Properties.Resources.edit;
            this.pbxEdit.Location = new System.Drawing.Point(360, 5);
            this.pbxEdit.Name = "pbxEdit";
            this.pbxEdit.Size = new System.Drawing.Size(20, 20);
            this.pbxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEdit.TabIndex = 2;
            this.pbxEdit.TabStop = false;
            this.pbxEdit.Click += new System.EventHandler(this.pbxEdit_Click);
            // 
            // pbxRemove
            // 
            this.pbxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxRemove.BackColor = System.Drawing.Color.Transparent;
            this.pbxRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRemove.Image = global::CommonScripts.Properties.Resources.delete;
            this.pbxRemove.Location = new System.Drawing.Point(385, 5);
            this.pbxRemove.Name = "pbxRemove";
            this.pbxRemove.Size = new System.Drawing.Size(20, 20);
            this.pbxRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRemove.TabIndex = 3;
            this.pbxRemove.TabStop = false;
            this.pbxRemove.Click += new System.EventHandler(this.pbxRemove_Click);
            // 
            // lblScriptType
            // 
            this.lblScriptType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblScriptType.Location = new System.Drawing.Point(254, 5);
            this.lblScriptType.Name = "lblScriptType";
            this.lblScriptType.Size = new System.Drawing.Size(100, 20);
            this.lblScriptType.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptType.StyleManager = null;
            this.lblScriptType.TabIndex = 4;
            this.lblScriptType.Text = "Script Type";
            this.lblScriptType.ThemeAuthor = "Narwin";
            this.lblScriptType.ThemeName = "MetroLite";
            // 
            // ScriptItem
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.lblScriptType);
            this.Controls.Add(this.pbxRemove);
            this.Controls.Add(this.pbxEdit);
            this.Controls.Add(this.pbxStatus);
            this.Controls.Add(this.lblScriptName);
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
        private MetroSetLabel lblScriptName;
        private MetroSetLabel lblScriptType;
    }
}
