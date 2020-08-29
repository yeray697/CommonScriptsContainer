using MetroFramework.Controls;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem : MetroPanel
    {
        private System.Windows.Forms.PictureBox pbxScriptStatus;
        private System.Windows.Forms.PictureBox pbxEdit;
        private System.Windows.Forms.PictureBox pbxRemove;
        private MetroLabel lblScriptName;

        private void InitializeComponent()
        {
            this.lblScriptName = new MetroFramework.Controls.MetroLabel();
            this.pbxScriptStatus = new System.Windows.Forms.PictureBox();
            this.pbxEdit = new System.Windows.Forms.PictureBox();
            this.pbxRemove = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScriptStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScriptName
            // 
            this.lblScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptName.Location = new System.Drawing.Point(30, 5);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(315, 20);
            this.lblScriptName.TabIndex = 0;
            this.lblScriptName.Text = "ScriptName";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxScriptStatus
            // 
            this.pbxScriptStatus.BackColor = System.Drawing.Color.Transparent;
            this.pbxScriptStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbxScriptStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxScriptStatus.Image = global::CommonScripts.Properties.Resources.pause;
            this.pbxScriptStatus.Location = new System.Drawing.Point(5, 5);
            this.pbxScriptStatus.Name = "pbxScriptStatus";
            this.pbxScriptStatus.Padding = new System.Windows.Forms.Padding(2);
            this.pbxScriptStatus.Size = new System.Drawing.Size(20, 20);
            this.pbxScriptStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxScriptStatus.TabIndex = 1;
            this.pbxScriptStatus.TabStop = false;
            // 
            // pbxEdit
            // 
            this.pbxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pbxEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEdit.Image = global::CommonScripts.Properties.Resources.edit;
            this.pbxEdit.Location = new System.Drawing.Point(350, 5);
            this.pbxEdit.Name = "pbxEdit";
            this.pbxEdit.Size = new System.Drawing.Size(20, 20);
            this.pbxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEdit.TabIndex = 2;
            this.pbxEdit.TabStop = false;
            // 
            // pbxRemove
            // 
            this.pbxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxRemove.BackColor = System.Drawing.Color.Transparent;
            this.pbxRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRemove.Image = global::CommonScripts.Properties.Resources.delete;
            this.pbxRemove.Location = new System.Drawing.Point(375, 5);
            this.pbxRemove.Name = "pbxRemove";
            this.pbxRemove.Size = new System.Drawing.Size(20, 20);
            this.pbxRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRemove.TabIndex = 3;
            this.pbxRemove.TabStop = false;
            // 
            // ScriptItem
            // 
            this.Controls.Add(this.pbxRemove);
            this.Controls.Add(this.pbxEdit);
            this.Controls.Add(this.pbxScriptStatus);
            this.Controls.Add(this.lblScriptName);

            this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Size = new System.Drawing.Size(400, 30);
            this.Style = MetroFramework.MetroColorStyle.Teal;
            ((System.ComponentModel.ISupportInitialize)(this.pbxScriptStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemove)).EndInit();
            this.ResumeLayout(false);

            this.ParentChanged += MainForm_ParentChanged;

        }
    }
}
