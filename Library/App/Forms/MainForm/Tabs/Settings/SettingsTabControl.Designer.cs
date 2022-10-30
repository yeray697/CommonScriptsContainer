namespace App.Forms.MainForm.Tabs.Settings
{
    partial class SettingsTabControl
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
            this.lblConsoleMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            this.lblFileMinLogLevel = new MaterialSkin.Controls.MaterialLabel();
            this.swtIsDarkMode = new MaterialSkin.Controls.MaterialSwitch();
            this.cbxConsoleMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxFileMinLevel = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblDarkMode = new MaterialSkin.Controls.MaterialLabel();
            this.tbxPrimaryColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbxLightPrimaryColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbxDarkPrimaryColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbxAccentColor = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // lblConsoleMinLogLevel
            // 
            this.lblConsoleMinLogLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblConsoleMinLogLevel.Depth = 0;
            this.lblConsoleMinLogLevel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblConsoleMinLogLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsoleMinLogLevel.Location = new System.Drawing.Point(39, 103);
            this.lblConsoleMinLogLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConsoleMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConsoleMinLogLevel.Name = "lblConsoleMinLogLevel";
            this.lblConsoleMinLogLevel.Size = new System.Drawing.Size(133, 49);
            this.lblConsoleMinLogLevel.TabIndex = 25;
            this.lblConsoleMinLogLevel.Text = "Console Minimum Logging Level";
            // 
            // lblFileMinLogLevel
            // 
            this.lblFileMinLogLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblFileMinLogLevel.Depth = 0;
            this.lblFileMinLogLevel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFileMinLogLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileMinLogLevel.Location = new System.Drawing.Point(39, 34);
            this.lblFileMinLogLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileMinLogLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFileMinLogLevel.Name = "lblFileMinLogLevel";
            this.lblFileMinLogLevel.Size = new System.Drawing.Size(133, 49);
            this.lblFileMinLogLevel.TabIndex = 24;
            this.lblFileMinLogLevel.Text = "File Minimum Logging Level";
            // 
            // swtIsDarkMode
            // 
            this.swtIsDarkMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swtIsDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.swtIsDarkMode.Checked = true;
            this.swtIsDarkMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.swtIsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swtIsDarkMode.Depth = 0;
            this.swtIsDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.swtIsDarkMode.Location = new System.Drawing.Point(681, 30);
            this.swtIsDarkMode.Margin = new System.Windows.Forms.Padding(0);
            this.swtIsDarkMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtIsDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtIsDarkMode.Name = "swtIsDarkMode";
            this.swtIsDarkMode.Ripple = true;
            this.swtIsDarkMode.Size = new System.Drawing.Size(48, 27);
            this.swtIsDarkMode.TabIndex = 23;
            this.swtIsDarkMode.UseVisualStyleBackColor = false;
            // 
            // cbxConsoleMinLevel
            // 
            this.cbxConsoleMinLevel.AllowDrop = true;
            this.cbxConsoleMinLevel.AutoResize = false;
            this.cbxConsoleMinLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbxConsoleMinLevel.CausesValidation = false;
            this.cbxConsoleMinLevel.Depth = 0;
            this.cbxConsoleMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxConsoleMinLevel.DropDownHeight = 174;
            this.cbxConsoleMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConsoleMinLevel.DropDownWidth = 121;
            this.cbxConsoleMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxConsoleMinLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxConsoleMinLevel.FormattingEnabled = true;
            this.cbxConsoleMinLevel.IntegralHeight = false;
            this.cbxConsoleMinLevel.ItemHeight = 43;
            this.cbxConsoleMinLevel.Location = new System.Drawing.Point(189, 103);
            this.cbxConsoleMinLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxConsoleMinLevel.MaxDropDownItems = 4;
            this.cbxConsoleMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxConsoleMinLevel.Name = "cbxConsoleMinLevel";
            this.cbxConsoleMinLevel.Size = new System.Drawing.Size(150, 49);
            this.cbxConsoleMinLevel.StartIndex = 0;
            this.cbxConsoleMinLevel.TabIndex = 22;
            // 
            // cbxFileMinLevel
            // 
            this.cbxFileMinLevel.AllowDrop = true;
            this.cbxFileMinLevel.AutoResize = false;
            this.cbxFileMinLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbxFileMinLevel.CausesValidation = false;
            this.cbxFileMinLevel.Depth = 0;
            this.cbxFileMinLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxFileMinLevel.DropDownHeight = 174;
            this.cbxFileMinLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileMinLevel.DropDownWidth = 121;
            this.cbxFileMinLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxFileMinLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxFileMinLevel.FormattingEnabled = true;
            this.cbxFileMinLevel.IntegralHeight = false;
            this.cbxFileMinLevel.ItemHeight = 43;
            this.cbxFileMinLevel.Location = new System.Drawing.Point(189, 34);
            this.cbxFileMinLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cbxFileMinLevel.MaxDropDownItems = 4;
            this.cbxFileMinLevel.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxFileMinLevel.Name = "cbxFileMinLevel";
            this.cbxFileMinLevel.Size = new System.Drawing.Size(150, 49);
            this.cbxFileMinLevel.StartIndex = 0;
            this.cbxFileMinLevel.TabIndex = 21;
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
            this.btnSave.Location = new System.Drawing.Point(681, 286);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SaveSettingsButtonClicked);
            // 
            // lblDarkMode
            // 
            this.lblDarkMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblDarkMode.Depth = 0;
            this.lblDarkMode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDarkMode.Location = new System.Drawing.Point(521, 34);
            this.lblDarkMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(133, 28);
            this.lblDarkMode.TabIndex = 19;
            this.lblDarkMode.Text = "Is Dark Mode?";
            // 
            // tbxPrimaryColor
            // 
            this.tbxPrimaryColor.AnimateReadOnly = false;
            this.tbxPrimaryColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxPrimaryColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxPrimaryColor.Depth = 0;
            this.tbxPrimaryColor.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxPrimaryColor.HideSelection = true;
            this.tbxPrimaryColor.Hint = "Primary Color";
            this.tbxPrimaryColor.LeadingIcon = null;
            this.tbxPrimaryColor.Location = new System.Drawing.Point(479, 104);
            this.tbxPrimaryColor.MaxLength = 32767;
            this.tbxPrimaryColor.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxPrimaryColor.Name = "tbxPrimaryColor";
            this.tbxPrimaryColor.PasswordChar = '\0';
            this.tbxPrimaryColor.PrefixSuffixText = null;
            this.tbxPrimaryColor.ReadOnly = false;
            this.tbxPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxPrimaryColor.SelectedText = "";
            this.tbxPrimaryColor.SelectionLength = 0;
            this.tbxPrimaryColor.SelectionStart = 0;
            this.tbxPrimaryColor.ShortcutsEnabled = true;
            this.tbxPrimaryColor.Size = new System.Drawing.Size(250, 48);
            this.tbxPrimaryColor.TabIndex = 26;
            this.tbxPrimaryColor.TabStop = false;
            this.tbxPrimaryColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxPrimaryColor.TrailingIcon = null;
            this.tbxPrimaryColor.UseSystemPasswordChar = false;
            // 
            // tbxLightPrimaryColor
            // 
            this.tbxLightPrimaryColor.AnimateReadOnly = false;
            this.tbxLightPrimaryColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxLightPrimaryColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxLightPrimaryColor.Depth = 0;
            this.tbxLightPrimaryColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxLightPrimaryColor.HideSelection = true;
            this.tbxLightPrimaryColor.Hint = "Primary Light Color";
            this.tbxLightPrimaryColor.LeadingIcon = null;
            this.tbxLightPrimaryColor.Location = new System.Drawing.Point(479, 171);
            this.tbxLightPrimaryColor.MaxLength = 32767;
            this.tbxLightPrimaryColor.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxLightPrimaryColor.Name = "tbxLightPrimaryColor";
            this.tbxLightPrimaryColor.PasswordChar = '\0';
            this.tbxLightPrimaryColor.PrefixSuffixText = null;
            this.tbxLightPrimaryColor.ReadOnly = false;
            this.tbxLightPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxLightPrimaryColor.SelectedText = "";
            this.tbxLightPrimaryColor.SelectionLength = 0;
            this.tbxLightPrimaryColor.SelectionStart = 0;
            this.tbxLightPrimaryColor.ShortcutsEnabled = true;
            this.tbxLightPrimaryColor.Size = new System.Drawing.Size(250, 48);
            this.tbxLightPrimaryColor.TabIndex = 27;
            this.tbxLightPrimaryColor.TabStop = false;
            this.tbxLightPrimaryColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxLightPrimaryColor.TrailingIcon = null;
            this.tbxLightPrimaryColor.UseSystemPasswordChar = false;
            // 
            // tbxDarkPrimaryColor
            // 
            this.tbxDarkPrimaryColor.AnimateReadOnly = false;
            this.tbxDarkPrimaryColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxDarkPrimaryColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxDarkPrimaryColor.Depth = 0;
            this.tbxDarkPrimaryColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxDarkPrimaryColor.HideSelection = true;
            this.tbxDarkPrimaryColor.Hint = "Primary Dark Color";
            this.tbxDarkPrimaryColor.LeadingIcon = null;
            this.tbxDarkPrimaryColor.Location = new System.Drawing.Point(172, 185);
            this.tbxDarkPrimaryColor.MaxLength = 32767;
            this.tbxDarkPrimaryColor.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxDarkPrimaryColor.Name = "tbxDarkPrimaryColor";
            this.tbxDarkPrimaryColor.PasswordChar = '\0';
            this.tbxDarkPrimaryColor.PrefixSuffixText = null;
            this.tbxDarkPrimaryColor.ReadOnly = false;
            this.tbxDarkPrimaryColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxDarkPrimaryColor.SelectedText = "";
            this.tbxDarkPrimaryColor.SelectionLength = 0;
            this.tbxDarkPrimaryColor.SelectionStart = 0;
            this.tbxDarkPrimaryColor.ShortcutsEnabled = true;
            this.tbxDarkPrimaryColor.Size = new System.Drawing.Size(250, 48);
            this.tbxDarkPrimaryColor.TabIndex = 28;
            this.tbxDarkPrimaryColor.TabStop = false;
            this.tbxDarkPrimaryColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxDarkPrimaryColor.TrailingIcon = null;
            this.tbxDarkPrimaryColor.UseSystemPasswordChar = false;
            // 
            // tbxAccentColor
            // 
            this.tbxAccentColor.AnimateReadOnly = false;
            this.tbxAccentColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxAccentColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxAccentColor.Depth = 0;
            this.tbxAccentColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxAccentColor.HideSelection = true;
            this.tbxAccentColor.Hint = "Accent Color";
            this.tbxAccentColor.LeadingIcon = null;
            this.tbxAccentColor.Location = new System.Drawing.Point(311, 274);
            this.tbxAccentColor.MaxLength = 32767;
            this.tbxAccentColor.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxAccentColor.Name = "tbxAccentColor";
            this.tbxAccentColor.PasswordChar = '\0';
            this.tbxAccentColor.PrefixSuffixText = null;
            this.tbxAccentColor.ReadOnly = false;
            this.tbxAccentColor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxAccentColor.SelectedText = "";
            this.tbxAccentColor.SelectionLength = 0;
            this.tbxAccentColor.SelectionStart = 0;
            this.tbxAccentColor.ShortcutsEnabled = true;
            this.tbxAccentColor.Size = new System.Drawing.Size(250, 48);
            this.tbxAccentColor.TabIndex = 29;
            this.tbxAccentColor.TabStop = false;
            this.tbxAccentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxAccentColor.TrailingIcon = null;
            this.tbxAccentColor.UseSystemPasswordChar = false;
            // 
            // SettingsTabControl
            // 
            this.Controls.Add(this.tbxAccentColor);
            this.Controls.Add(this.tbxDarkPrimaryColor);
            this.Controls.Add(this.tbxLightPrimaryColor);
            this.Controls.Add(this.tbxPrimaryColor);
            this.Controls.Add(this.lblConsoleMinLogLevel);
            this.Controls.Add(this.lblFileMinLogLevel);
            this.Controls.Add(this.swtIsDarkMode);
            this.Controls.Add(this.cbxConsoleMinLevel);
            this.Controls.Add(this.cbxFileMinLevel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDarkMode);
            this.Name = "SettingsTabControl";
            this.Size = new System.Drawing.Size(781, 355);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblConsoleMinLogLevel;
        private MaterialSkin.Controls.MaterialLabel lblFileMinLogLevel;
        private MaterialSkin.Controls.MaterialSwitch swtIsDarkMode;
        private MaterialSkin.Controls.MaterialComboBox cbxConsoleMinLevel;
        private MaterialSkin.Controls.MaterialComboBox cbxFileMinLevel;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialLabel lblDarkMode;
        private MaterialSkin.Controls.MaterialTextBox2 tbxPrimaryColor;
        private MaterialSkin.Controls.MaterialTextBox2 tbxLightPrimaryColor;
        private MaterialSkin.Controls.MaterialTextBox2 tbxDarkPrimaryColor;
        private MaterialSkin.Controls.MaterialTextBox2 tbxAccentColor;
    }
}
