namespace CommonScripts.View
{
    partial class ScriptForm
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
            this.tbxScriptName = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnPathSelector = new MaterialSkin.Controls.MaterialButton();
            this.tbxScriptPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.cbxScriptType = new MaterialSkin.Controls.MaterialComboBox();
            this.ofdScriptPath = new System.Windows.Forms.OpenFileDialog();
            this.tbxKeyPressed = new MaterialSkin.Controls.MaterialTextBox2();
            this.tbxScriptScheduled = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.SuspendLayout();
            // 
            // tbxScriptName
            // 
            this.tbxScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxScriptName.AnimateReadOnly = false;
            this.tbxScriptName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbxScriptName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxScriptName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxScriptName.Depth = 0;
            this.tbxScriptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxScriptName.HideSelection = true;
            this.tbxScriptName.Hint = "Name";
            this.tbxScriptName.LeadingIcon = null;
            this.tbxScriptName.Location = new System.Drawing.Point(13, 76);
            this.tbxScriptName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxScriptName.MaxLength = 32767;
            this.tbxScriptName.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxScriptName.Name = "tbxScriptName";
            this.tbxScriptName.PasswordChar = '\0';
            this.tbxScriptName.PrefixSuffixText = null;
            this.tbxScriptName.ReadOnly = false;
            this.tbxScriptName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxScriptName.SelectedText = "";
            this.tbxScriptName.SelectionLength = 0;
            this.tbxScriptName.SelectionStart = 0;
            this.tbxScriptName.ShortcutsEnabled = true;
            this.tbxScriptName.Size = new System.Drawing.Size(620, 48);
            this.tbxScriptName.TabIndex = 3;
            this.tbxScriptName.TabStop = false;
            this.tbxScriptName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxScriptName.TrailingIcon = null;
            this.tbxScriptName.UseSystemPasswordChar = false;
            // 
            // btnPathSelector
            // 
            this.btnPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathSelector.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPathSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnPathSelector.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPathSelector.Depth = 0;
            this.btnPathSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPathSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPathSelector.HighEmphasis = true;
            this.btnPathSelector.Icon = null;
            this.btnPathSelector.Location = new System.Drawing.Point(569, 145);
            this.btnPathSelector.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPathSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPathSelector.Name = "btnPathSelector";
            this.btnPathSelector.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPathSelector.Size = new System.Drawing.Size(64, 36);
            this.btnPathSelector.TabIndex = 4;
            this.btnPathSelector.Text = "...";
            this.btnPathSelector.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPathSelector.UseAccentColor = false;
            this.btnPathSelector.UseVisualStyleBackColor = false;
            this.btnPathSelector.Click += new System.EventHandler(this.ShowPathSelector);
            // 
            // tbxScriptPath
            // 
            this.tbxScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxScriptPath.AnimateReadOnly = false;
            this.tbxScriptPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbxScriptPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxScriptPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxScriptPath.Depth = 0;
            this.tbxScriptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxScriptPath.HideSelection = true;
            this.tbxScriptPath.Hint = "Path";
            this.tbxScriptPath.LeadingIcon = null;
            this.tbxScriptPath.Location = new System.Drawing.Point(13, 140);
            this.tbxScriptPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbxScriptPath.MaxLength = 32767;
            this.tbxScriptPath.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxScriptPath.Name = "tbxScriptPath";
            this.tbxScriptPath.PasswordChar = '\0';
            this.tbxScriptPath.PrefixSuffixText = null;
            this.tbxScriptPath.ReadOnly = false;
            this.tbxScriptPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxScriptPath.SelectedText = "";
            this.tbxScriptPath.SelectionLength = 0;
            this.tbxScriptPath.SelectionStart = 0;
            this.tbxScriptPath.ShortcutsEnabled = true;
            this.tbxScriptPath.Size = new System.Drawing.Size(546, 48);
            this.tbxScriptPath.TabIndex = 5;
            this.tbxScriptPath.TabStop = false;
            this.tbxScriptPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxScriptPath.TrailingIcon = null;
            this.tbxScriptPath.UseSystemPasswordChar = false;
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
            this.btnCancel.Location = new System.Drawing.Point(482, 276);
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
            this.btnSave.Location = new System.Drawing.Point(569, 276);
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
            // cbxScriptType
            // 
            this.cbxScriptType.AllowDrop = true;
            this.cbxScriptType.AutoResize = false;
            this.cbxScriptType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbxScriptType.CausesValidation = false;
            this.cbxScriptType.Depth = 0;
            this.cbxScriptType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxScriptType.DropDownHeight = 174;
            this.cbxScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScriptType.DropDownWidth = 121;
            this.cbxScriptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxScriptType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxScriptType.FormattingEnabled = true;
            this.cbxScriptType.Hint = "Type";
            this.cbxScriptType.IntegralHeight = false;
            this.cbxScriptType.ItemHeight = 43;
            this.cbxScriptType.Location = new System.Drawing.Point(13, 209);
            this.cbxScriptType.Margin = new System.Windows.Forms.Padding(2);
            this.cbxScriptType.MaxDropDownItems = 4;
            this.cbxScriptType.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxScriptType.Name = "cbxScriptType";
            this.cbxScriptType.Size = new System.Drawing.Size(128, 49);
            this.cbxScriptType.StartIndex = 0;
            this.cbxScriptType.TabIndex = 10;
            this.cbxScriptType.SelectedValueChanged += new System.EventHandler(this.ScriptTypeChanged);
            // 
            // ofdScriptPath
            // 
            this.ofdScriptPath.FileName = "openFileDialog1";
            // 
            // tbxKeyPressed
            // 
            this.tbxKeyPressed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxKeyPressed.AnimateReadOnly = false;
            this.tbxKeyPressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbxKeyPressed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxKeyPressed.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbxKeyPressed.Depth = 0;
            this.tbxKeyPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxKeyPressed.HideSelection = true;
            this.tbxKeyPressed.Hint = "Run on key pressed";
            this.tbxKeyPressed.LeadingIcon = null;
            this.tbxKeyPressed.Location = new System.Drawing.Point(157, 209);
            this.tbxKeyPressed.Margin = new System.Windows.Forms.Padding(2);
            this.tbxKeyPressed.MaxLength = 32767;
            this.tbxKeyPressed.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxKeyPressed.Name = "tbxKeyPressed";
            this.tbxKeyPressed.PasswordChar = '\0';
            this.tbxKeyPressed.PrefixSuffixText = null;
            this.tbxKeyPressed.ReadOnly = true;
            this.tbxKeyPressed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxKeyPressed.SelectedText = "";
            this.tbxKeyPressed.SelectionLength = 0;
            this.tbxKeyPressed.SelectionStart = 0;
            this.tbxKeyPressed.ShortcutsEnabled = true;
            this.tbxKeyPressed.Size = new System.Drawing.Size(476, 48);
            this.tbxKeyPressed.TabIndex = 13;
            this.tbxKeyPressed.TabStop = false;
            this.tbxKeyPressed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxKeyPressed.TrailingIcon = null;
            this.tbxKeyPressed.UseSystemPasswordChar = false;
            this.tbxKeyPressed.Enter += new System.EventHandler(this.ListenForKeyControlFocused);
            this.tbxKeyPressed.Leave += new System.EventHandler(this.ListenForKeyControlLeaveFocus);
            // 
            // tbxScriptScheduled
            // 
            this.tbxScriptScheduled.AllowPromptAsInput = true;
            this.tbxScriptScheduled.AnimateReadOnly = false;
            this.tbxScriptScheduled.AsciiOnly = false;
            this.tbxScriptScheduled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbxScriptScheduled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbxScriptScheduled.BeepOnError = false;
            this.tbxScriptScheduled.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.tbxScriptScheduled.Depth = 0;
            this.tbxScriptScheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbxScriptScheduled.HidePromptOnLeave = false;
            this.tbxScriptScheduled.HideSelection = true;
            this.tbxScriptScheduled.Hint = "Run at";
            this.tbxScriptScheduled.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.tbxScriptScheduled.LeadingIcon = null;
            this.tbxScriptScheduled.Location = new System.Drawing.Point(157, 209);
            this.tbxScriptScheduled.Margin = new System.Windows.Forms.Padding(2);
            this.tbxScriptScheduled.Mask = "00:00";
            this.tbxScriptScheduled.MaxLength = 32767;
            this.tbxScriptScheduled.MouseState = MaterialSkin.MouseState.OUT;
            this.tbxScriptScheduled.Name = "tbxScriptScheduled";
            this.tbxScriptScheduled.PasswordChar = '\0';
            this.tbxScriptScheduled.PrefixSuffixText = null;
            this.tbxScriptScheduled.PromptChar = '_';
            this.tbxScriptScheduled.ReadOnly = false;
            this.tbxScriptScheduled.RejectInputOnFirstFailure = false;
            this.tbxScriptScheduled.ResetOnPrompt = true;
            this.tbxScriptScheduled.ResetOnSpace = true;
            this.tbxScriptScheduled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxScriptScheduled.SelectedText = "";
            this.tbxScriptScheduled.SelectionLength = 0;
            this.tbxScriptScheduled.SelectionStart = 0;
            this.tbxScriptScheduled.ShortcutsEnabled = true;
            this.tbxScriptScheduled.Size = new System.Drawing.Size(71, 48);
            this.tbxScriptScheduled.SkipLiterals = true;
            this.tbxScriptScheduled.TabIndex = 18;
            this.tbxScriptScheduled.TabStop = false;
            this.tbxScriptScheduled.Text = "  :";
            this.tbxScriptScheduled.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxScriptScheduled.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.tbxScriptScheduled.TrailingIcon = null;
            this.tbxScriptScheduled.UseSystemPasswordChar = false;
            this.tbxScriptScheduled.ValidatingType = typeof(System.DateTime);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 325);
            this.Controls.Add(this.tbxScriptScheduled);
            this.Controls.Add(this.tbxKeyPressed);
            this.Controls.Add(this.cbxScriptType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxScriptPath);
            this.Controls.Add(this.btnPathSelector);
            this.Controls.Add(this.tbxScriptName);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(646, 325);
            this.MinimumSize = new System.Drawing.Size(506, 325);
            this.Name = "ScriptForm";
            this.Padding = new System.Windows.Forms.Padding(1, 27, 1, 2);
            this.Text = "ScriptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 tbxScriptName;
        private MaterialSkin.Controls.MaterialButton btnPathSelector;
        private MaterialSkin.Controls.MaterialTextBox2 tbxScriptPath;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialComboBox cbxScriptType;
        private System.Windows.Forms.OpenFileDialog ofdScriptPath;
        private MaterialSkin.Controls.MaterialTextBox2 tbxKeyPressed;
        private MaterialSkin.Controls.MaterialMaskedTextBox tbxScriptScheduled;
    }
}