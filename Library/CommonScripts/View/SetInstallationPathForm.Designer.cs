
using System;

namespace CommonScripts.View
{
    partial class SetInstallationPathForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new MetroSet_UI.Controls.MetroSetButton();
            this.btnCancel = new MetroSet_UI.Controls.MetroSetButton();
            this.lblInstallationPath = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnInstallationPath = new MetroSet_UI.Controls.MetroSetButton();
            this.tbxInstallationPath = new MetroSet_UI.Controls.MetroSetTextBox();
            this.fbdInstallationPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSave.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSave.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSave.HoverTextColor = System.Drawing.Color.White;
            this.btnSave.IsDerivedStyle = true;
            this.btnSave.Location = new System.Drawing.Point(560, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSave.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSave.NormalTextColor = System.Drawing.Color.White;
            this.btnSave.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSave.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSave.PressTextColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = MetroSet_UI.Enums.Style.Light;
            this.btnSave.StyleManager = null;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeAuthor = "Narwin";
            this.btnSave.ThemeName = "MetroLite";
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCancel.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnCancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnCancel.HoverTextColor = System.Drawing.Color.White;
            this.btnCancel.IsDerivedStyle = true;
            this.btnCancel.Location = new System.Drawing.Point(479, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCancel.NormalTextColor = System.Drawing.Color.White;
            this.btnCancel.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnCancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnCancel.PressTextColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = MetroSet_UI.Enums.Style.Light;
            this.btnCancel.StyleManager = null;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeAuthor = "Narwin";
            this.btnCancel.ThemeName = "MetroLite";
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // lblInstallationPath
            // 
            this.lblInstallationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInstallationPath.IsDerivedStyle = true;
            this.lblInstallationPath.Location = new System.Drawing.Point(15, 95);
            this.lblInstallationPath.Name = "lblInstallationPath";
            this.lblInstallationPath.Size = new System.Drawing.Size(100, 26);
            this.lblInstallationPath.Style = MetroSet_UI.Enums.Style.Light;
            this.lblInstallationPath.StyleManager = null;
            this.lblInstallationPath.TabIndex = 2;
            this.lblInstallationPath.Text = "Path:";
            this.lblInstallationPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInstallationPath.ThemeAuthor = "Narwin";
            this.lblInstallationPath.ThemeName = "MetroLite";
            // 
            // btnInstallationPath
            // 
            this.btnInstallationPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallationPath.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnInstallationPath.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnInstallationPath.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnInstallationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInstallationPath.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnInstallationPath.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnInstallationPath.HoverTextColor = System.Drawing.Color.White;
            this.btnInstallationPath.IsDerivedStyle = true;
            this.btnInstallationPath.Location = new System.Drawing.Point(609, 95);
            this.btnInstallationPath.Name = "btnInstallationPath";
            this.btnInstallationPath.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnInstallationPath.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnInstallationPath.NormalTextColor = System.Drawing.Color.White;
            this.btnInstallationPath.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnInstallationPath.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnInstallationPath.PressTextColor = System.Drawing.Color.White;
            this.btnInstallationPath.Size = new System.Drawing.Size(26, 26);
            this.btnInstallationPath.Style = MetroSet_UI.Enums.Style.Light;
            this.btnInstallationPath.StyleManager = null;
            this.btnInstallationPath.TabIndex = 4;
            this.btnInstallationPath.Text = "...";
            this.btnInstallationPath.ThemeAuthor = "Narwin";
            this.btnInstallationPath.ThemeName = "MetroLite";
            this.btnInstallationPath.Click += new System.EventHandler(this.ShowPathSelector);
            // 
            // tbxInstallationPath
            // 
            this.tbxInstallationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInstallationPath.AutoCompleteCustomSource = null;
            this.tbxInstallationPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbxInstallationPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbxInstallationPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxInstallationPath.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tbxInstallationPath.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxInstallationPath.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.tbxInstallationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxInstallationPath.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbxInstallationPath.Image = null;
            this.tbxInstallationPath.IsDerivedStyle = true;
            this.tbxInstallationPath.Lines = null;
            this.tbxInstallationPath.Location = new System.Drawing.Point(121, 95);
            this.tbxInstallationPath.MaxLength = 32767;
            this.tbxInstallationPath.Multiline = false;
            this.tbxInstallationPath.Name = "tbxInstallationPath";
            this.tbxInstallationPath.ReadOnly = false;
            this.tbxInstallationPath.Size = new System.Drawing.Size(482, 26);
            this.tbxInstallationPath.Style = MetroSet_UI.Enums.Style.Light;
            this.tbxInstallationPath.StyleManager = null;
            this.tbxInstallationPath.TabIndex = 5;
            this.tbxInstallationPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxInstallationPath.ThemeAuthor = "Narwin";
            this.tbxInstallationPath.ThemeName = "MetroLite";
            this.tbxInstallationPath.UseSystemPasswordChar = false;
            this.tbxInstallationPath.WatermarkText = "";
            // 
            // SetInstallationPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 178);
            this.Controls.Add(this.tbxInstallationPath);
            this.Controls.Add(this.btnInstallationPath);
            this.Controls.Add(this.lblInstallationPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximumSize = new System.Drawing.Size(1000, 178);
            this.MinimumSize = new System.Drawing.Size(450, 178);
            this.Name = "SetInstallationPathForm";
            this.Text = "Set Installation Path";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton btnSave;
        private MetroSet_UI.Controls.MetroSetButton btnCancel;
        private MetroSet_UI.Controls.MetroSetLabel lblInstallationPath;
        private MetroSet_UI.Controls.MetroSetButton btnInstallationPath;
        private MetroSet_UI.Controls.MetroSetTextBox tbxInstallationPath;
        private System.Windows.Forms.FolderBrowserDialog fbdInstallationPath;
    }
}