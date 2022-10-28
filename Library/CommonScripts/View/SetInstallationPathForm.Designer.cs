
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
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnInstallationPath = new MaterialSkin.Controls.MaterialButton();
            this.tbxInstallationPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.fbdInstallationPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(429, 148);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(336, 148);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // btnInstallationPath
            // 
            this.btnInstallationPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallationPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInstallationPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnInstallationPath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnInstallationPath.Depth = 0;
            this.btnInstallationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInstallationPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInstallationPath.HighEmphasis = true;
            this.btnInstallationPath.Icon = null;
            this.btnInstallationPath.Location = new System.Drawing.Point(429, 91);
            this.btnInstallationPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInstallationPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInstallationPath.Name = "btnInstallationPath";
            this.btnInstallationPath.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnInstallationPath.Size = new System.Drawing.Size(64, 36);
            this.btnInstallationPath.TabIndex = 4;
            this.btnInstallationPath.Text = "...";
            this.btnInstallationPath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInstallationPath.UseAccentColor = false;
            this.btnInstallationPath.UseVisualStyleBackColor = false;
            this.btnInstallationPath.Click += new System.EventHandler(this.ShowPathSelector);
            // 
            // tbxInstallationPath
            // 
            this.tbxInstallationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInstallationPath.AnimateReadOnly = false;
            this.tbxInstallationPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbxInstallationPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxInstallationPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxInstallationPath.Depth = 0;
            this.tbxInstallationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxInstallationPath.HideSelection = true;
            this.tbxInstallationPath.Hint = "Path";
            this.tbxInstallationPath.LeadingIcon = null;
            this.tbxInstallationPath.Location = new System.Drawing.Point(19, 83);
            this.tbxInstallationPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbxInstallationPath.MaxLength = 32767;
            this.tbxInstallationPath.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxInstallationPath.Name = "tbxInstallationPath";
            this.tbxInstallationPath.PasswordChar = '\0';
            this.tbxInstallationPath.PrefixSuffixText = null;
            this.tbxInstallationPath.ReadOnly = false;
            this.tbxInstallationPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxInstallationPath.SelectedText = "";
            this.tbxInstallationPath.SelectionLength = 0;
            this.tbxInstallationPath.SelectionStart = 0;
            this.tbxInstallationPath.ShortcutsEnabled = true;
            this.tbxInstallationPath.Size = new System.Drawing.Size(394, 48);
            this.tbxInstallationPath.TabIndex = 5;
            this.tbxInstallationPath.TabStop = false;
            this.tbxInstallationPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxInstallationPath.TrailingIcon = null;
            this.tbxInstallationPath.UseSystemPasswordChar = false;
            // 
            // SetInstallationPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 194);
            this.Controls.Add(this.tbxInstallationPath);
            this.Controls.Add(this.btnInstallationPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(700, 194);
            this.MinimumSize = new System.Drawing.Size(315, 194);
            this.Name = "SetInstallationPathForm";
            this.Padding = new System.Windows.Forms.Padding(1, 27, 1, 2);
            this.Text = "Set Installation Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnInstallationPath;
        private MaterialSkin.Controls.MaterialTextBox2 tbxInstallationPath;
        private System.Windows.Forms.FolderBrowserDialog fbdInstallationPath;
    }
}