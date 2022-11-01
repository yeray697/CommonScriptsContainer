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
            this.swtIsDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.swtIsDarkMode.Checked = true;
            this.swtIsDarkMode.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.swtIsDarkMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swtIsDarkMode.Depth = 0;
            this.swtIsDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.swtIsDarkMode.Location = new System.Drawing.Point(199, 171);
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
            this.lblDarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblDarkMode.Depth = 0;
            this.lblDarkMode.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDarkMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDarkMode.Location = new System.Drawing.Point(39, 175);
            this.lblDarkMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDarkMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDarkMode.Name = "lblDarkMode";
            this.lblDarkMode.Size = new System.Drawing.Size(133, 28);
            this.lblDarkMode.TabIndex = 19;
            this.lblDarkMode.Text = "Is Dark Mode?";
            // 
            // SettingsTabControl
            // 
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
    }
}
