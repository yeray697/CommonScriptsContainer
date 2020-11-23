namespace CommonScripts.View
{
    partial class Settings
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
            this.lblDarkMode = new MetroSet_UI.Controls.MetroSetLabel();
            this.btnSave = new MetroSet_UI.Controls.MetroSetButton();
            this.btnCancel = new MetroSet_UI.Controls.MetroSetButton();
            this.cbxFileMinLevel = new MetroSet_UI.Controls.MetroSetComboBox();
            this.cbxConsoleMinLevel = new MetroSet_UI.Controls.MetroSetComboBox();
            this.swtIsDarkMode = new MetroSet_UI.Controls.MetroSetSwitch();
            this.lblFileMinLogLevel = new MetroSet_UI.Controls.MetroSetLabel();
            this.lblConsoleMinLogLevel = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Location = new System.Drawing.Point(233, 0);
            // 
            // lblDarkMode
            // 
            this.lblDarkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDarkMode.IsDerivedStyle = true;
            this.lblDarkMode.Location = new System.Drawing.Point(20, 110);
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(120, 22);
            this.lblDarkMode.Style = MetroSet_UI.Enums.Style.Light;
            this.lblDarkMode.StyleManager = null;
            this.lblDarkMode.TabIndex = 2;
            this.lblDarkMode.Text = "Is Dark Mode?";
            this.lblDarkMode.ThemeAuthor = "Narwin";
            this.lblDarkMode.ThemeName = "MetroLite";
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
            this.btnSave.Location = new System.Drawing.Point(244, 255);
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
            this.btnSave.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(163, 255);
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
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.ThemeAuthor = "Narwin";
            this.btnCancel.ThemeName = "MetroLite";
            this.btnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // cbxFileMinLevel
            // 
            this.cbxFileMinLevel.AllowDrop = true;
            this.cbxFileMinLevel.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxFileMinLevel.BackColor = System.Drawing.Color.Transparent;
            this.cbxFileMinLevel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbxFileMinLevel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxFileMinLevel.CausesValidation = false;
            this.cbxFileMinLevel.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbxFileMinLevel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cbxFileMinLevel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cbxFileMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxFileMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxFileMinLevel.FormattingEnabled = true;
            this.cbxFileMinLevel.IsDerivedStyle = true;
            this.cbxFileMinLevel.ItemHeight = 20;
            this.cbxFileMinLevel.Location = new System.Drawing.Point(164, 150);
            this.cbxFileMinLevel.Name = "cbxFileMinLevel";
            this.cbxFileMinLevel.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbxFileMinLevel.SelectedItemForeColor = System.Drawing.Color.White;
            this.cbxFileMinLevel.Size = new System.Drawing.Size(154, 26);
            this.cbxFileMinLevel.Style = MetroSet_UI.Enums.Style.Light;
            this.cbxFileMinLevel.StyleManager = null;
            this.cbxFileMinLevel.TabIndex = 5;
            this.cbxFileMinLevel.ThemeAuthor = "Narwin";
            this.cbxFileMinLevel.ThemeName = "MetroLite";
            // 
            // cbxConsoleMinLevel
            // 
            this.cbxConsoleMinLevel.AllowDrop = true;
            this.cbxConsoleMinLevel.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxConsoleMinLevel.BackColor = System.Drawing.Color.Transparent;
            this.cbxConsoleMinLevel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbxConsoleMinLevel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxConsoleMinLevel.CausesValidation = false;
            this.cbxConsoleMinLevel.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbxConsoleMinLevel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cbxConsoleMinLevel.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cbxConsoleMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxConsoleMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsoleMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxConsoleMinLevel.FormattingEnabled = true;
            this.cbxConsoleMinLevel.IsDerivedStyle = true;
            this.cbxConsoleMinLevel.ItemHeight = 20;
            this.cbxConsoleMinLevel.Location = new System.Drawing.Point(164, 198);
            this.cbxConsoleMinLevel.Name = "cbxConsoleMinLevel";
            this.cbxConsoleMinLevel.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbxConsoleMinLevel.SelectedItemForeColor = System.Drawing.Color.White;
            this.cbxConsoleMinLevel.Size = new System.Drawing.Size(154, 26);
            this.cbxConsoleMinLevel.Style = MetroSet_UI.Enums.Style.Light;
            this.cbxConsoleMinLevel.StyleManager = null;
            this.cbxConsoleMinLevel.TabIndex = 6;
            this.cbxConsoleMinLevel.ThemeAuthor = "Narwin";
            this.cbxConsoleMinLevel.ThemeName = "MetroLite";
            // 
            // swtIsDarkMode
            // 
            this.swtIsDarkMode.BackColor = System.Drawing.Color.Transparent;
            this.swtIsDarkMode.BackgroundColor = System.Drawing.Color.Empty;
            this.swtIsDarkMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(159)))), ((int)(((byte)(147)))));
            this.swtIsDarkMode.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.swtIsDarkMode.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.swtIsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swtIsDarkMode.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.swtIsDarkMode.DisabledCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.swtIsDarkMode.DisabledUnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.swtIsDarkMode.IsDerivedStyle = true;
            this.swtIsDarkMode.Location = new System.Drawing.Point(164, 110);
            this.swtIsDarkMode.Name = "swtIsDarkMode";
            this.swtIsDarkMode.Size = new System.Drawing.Size(58, 22);
            this.swtIsDarkMode.Style = MetroSet_UI.Enums.Style.Light;
            this.swtIsDarkMode.StyleManager = null;
            this.swtIsDarkMode.Switched = false;
            this.swtIsDarkMode.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.swtIsDarkMode.TabIndex = 7;
            this.swtIsDarkMode.ThemeAuthor = "Narwin";
            this.swtIsDarkMode.ThemeName = "MetroLite";
            this.swtIsDarkMode.UnCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            // 
            // lblFileMinLogLevel
            // 
            this.lblFileMinLogLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFileMinLogLevel.IsDerivedStyle = true;
            this.lblFileMinLogLevel.Location = new System.Drawing.Point(20, 146);
            this.lblFileMinLogLevel.Name = "lblFileMinLogLevel";
            this.lblFileMinLogLevel.Size = new System.Drawing.Size(120, 34);
            this.lblFileMinLogLevel.Style = MetroSet_UI.Enums.Style.Light;
            this.lblFileMinLogLevel.StyleManager = null;
            this.lblFileMinLogLevel.TabIndex = 9;
            this.lblFileMinLogLevel.Text = "File Minimum Logging Level";
            this.lblFileMinLogLevel.ThemeAuthor = "Narwin";
            this.lblFileMinLogLevel.ThemeName = "MetroLite";
            // 
            // lblConsoleMinLogLevel
            // 
            this.lblConsoleMinLogLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConsoleMinLogLevel.IsDerivedStyle = true;
            this.lblConsoleMinLogLevel.Location = new System.Drawing.Point(20, 194);
            this.lblConsoleMinLogLevel.Name = "lblConsoleMinLogLevel";
            this.lblConsoleMinLogLevel.Size = new System.Drawing.Size(120, 34);
            this.lblConsoleMinLogLevel.Style = MetroSet_UI.Enums.Style.Light;
            this.lblConsoleMinLogLevel.StyleManager = null;
            this.lblConsoleMinLogLevel.TabIndex = 10;
            this.lblConsoleMinLogLevel.Text = "Console Minimum Logging Level";
            this.lblConsoleMinLogLevel.ThemeAuthor = "Narwin";
            this.lblConsoleMinLogLevel.ThemeName = "MetroLite";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 293);
            this.Controls.Add(this.lblConsoleMinLogLevel);
            this.Controls.Add(this.lblFileMinLogLevel);
            this.Controls.Add(this.swtIsDarkMode);
            this.Controls.Add(this.cbxConsoleMinLevel);
            this.Controls.Add(this.cbxFileMinLevel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDarkMode);
            this.Name = "Settings";
            this.Text = "SettingsForm";
            this.Controls.SetChildIndex(this.lblDarkMode, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.cbxFileMinLevel, 0);
            this.Controls.SetChildIndex(this.cbxConsoleMinLevel, 0);
            this.Controls.SetChildIndex(this.swtIsDarkMode, 0);
            this.Controls.SetChildIndex(this.lblFileMinLogLevel, 0);
            this.Controls.SetChildIndex(this.lblConsoleMinLogLevel, 0);
            this.Controls.SetChildIndex(this.metroSetControlBox1, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Controls.MetroSetLabel lblDarkMode;
        private MetroSet_UI.Controls.MetroSetButton btnSave;
        private MetroSet_UI.Controls.MetroSetButton btnCancel;
        private MetroSet_UI.Controls.MetroSetComboBox cbxFileMinLevel;
        private MetroSet_UI.Controls.MetroSetComboBox cbxConsoleMinLevel;
        private MetroSet_UI.Controls.MetroSetSwitch swtIsDarkMode;
        private MetroSet_UI.Controls.MetroSetLabel lblFileMinLogLevel;
        private MetroSet_UI.Controls.MetroSetLabel lblConsoleMinLogLevel;
    }
}