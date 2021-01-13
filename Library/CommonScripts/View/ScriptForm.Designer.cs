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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.lblScriptName = new MetroSet_UI.Controls.MetroSetLabel();
            this.lblScriptPath = new MetroSet_UI.Controls.MetroSetLabel();
            this.tbxScriptName = new MetroSet_UI.Controls.MetroSetTextBox();
            this.btnPathSelector = new MetroSet_UI.Controls.MetroSetButton();
            this.tbxScriptPath = new MetroSet_UI.Controls.MetroSetTextBox();
            this.btnCancel = new MetroSet_UI.Controls.MetroSetButton();
            this.btnSave = new MetroSet_UI.Controls.MetroSetButton();
            this.lblScriptType = new MetroSet_UI.Controls.MetroSetLabel();
            this.cbxScriptType = new MetroSet_UI.Controls.MetroSetComboBox();
            this.ofdScriptPath = new System.Windows.Forms.OpenFileDialog();
            this.tbxKeyPressed = new MetroSet_UI.Controls.MetroSetTextBox();
            this.lblListenKey = new MetroSet_UI.Controls.MetroSetLabel();
            this.lblScriptSchedule = new MetroSet_UI.Controls.MetroSetLabel();
            this.pbxRemoveKeyPressed = new System.Windows.Forms.PictureBox();
            this.pbxEditKeyPressed = new System.Windows.Forms.PictureBox();
            this.tbxScriptScheduled = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemoveKeyPressed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditKeyPressed)).BeginInit();
            this.SuspendLayout();
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Location = new System.Drawing.Point(549, 0);
            // 
            // lblScriptName
            // 
            this.lblScriptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScriptName.IsDerivedStyle = true;
            this.lblScriptName.Location = new System.Drawing.Point(15, 95);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(100, 26);
            this.lblScriptName.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptName.StyleManager = null;
            this.lblScriptName.TabIndex = 1;
            this.lblScriptName.Text = "Name:";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptName.ThemeAuthor = "Narwin";
            this.lblScriptName.ThemeName = "MetroLite";
            // 
            // lblScriptPath
            // 
            this.lblScriptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScriptPath.IsDerivedStyle = true;
            this.lblScriptPath.Location = new System.Drawing.Point(15, 131);
            this.lblScriptPath.Name = "lblScriptPath";
            this.lblScriptPath.Size = new System.Drawing.Size(100, 26);
            this.lblScriptPath.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptPath.StyleManager = null;
            this.lblScriptPath.TabIndex = 2;
            this.lblScriptPath.Text = "Path:";
            this.lblScriptPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptPath.ThemeAuthor = "Narwin";
            this.lblScriptPath.ThemeName = "MetroLite";
            // 
            // tbxScriptName
            // 
            this.tbxScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxScriptName.AutoCompleteCustomSource = null;
            this.tbxScriptName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbxScriptName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbxScriptName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxScriptName.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tbxScriptName.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxScriptName.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.tbxScriptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxScriptName.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbxScriptName.Image = null;
            this.tbxScriptName.IsDerivedStyle = true;
            this.tbxScriptName.Lines = null;
            this.tbxScriptName.Location = new System.Drawing.Point(121, 95);
            this.tbxScriptName.MaxLength = 32767;
            this.tbxScriptName.Multiline = false;
            this.tbxScriptName.Name = "tbxScriptName";
            this.tbxScriptName.ReadOnly = false;
            this.tbxScriptName.Size = new System.Drawing.Size(514, 26);
            this.tbxScriptName.Style = MetroSet_UI.Enums.Style.Light;
            this.tbxScriptName.StyleManager = null;
            this.tbxScriptName.TabIndex = 3;
            this.tbxScriptName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxScriptName.ThemeAuthor = "Narwin";
            this.tbxScriptName.ThemeName = "MetroLite";
            this.tbxScriptName.UseSystemPasswordChar = false;
            this.tbxScriptName.WatermarkText = "";
            // 
            // btnPathSelector
            // 
            this.btnPathSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathSelector.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnPathSelector.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnPathSelector.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnPathSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPathSelector.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnPathSelector.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnPathSelector.HoverTextColor = System.Drawing.Color.White;
            this.btnPathSelector.IsDerivedStyle = true;
            this.btnPathSelector.Location = new System.Drawing.Point(609, 131);
            this.btnPathSelector.Name = "btnPathSelector";
            this.btnPathSelector.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnPathSelector.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnPathSelector.NormalTextColor = System.Drawing.Color.White;
            this.btnPathSelector.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnPathSelector.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnPathSelector.PressTextColor = System.Drawing.Color.White;
            this.btnPathSelector.Size = new System.Drawing.Size(26, 26);
            this.btnPathSelector.Style = MetroSet_UI.Enums.Style.Light;
            this.btnPathSelector.StyleManager = null;
            this.btnPathSelector.TabIndex = 4;
            this.btnPathSelector.Text = "...";
            this.btnPathSelector.ThemeAuthor = "Narwin";
            this.btnPathSelector.ThemeName = "MetroLite";
            this.btnPathSelector.Click += new System.EventHandler(this.ShowPathSelector);
            // 
            // tbxScriptPath
            // 
            this.tbxScriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxScriptPath.AutoCompleteCustomSource = null;
            this.tbxScriptPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbxScriptPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbxScriptPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxScriptPath.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tbxScriptPath.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxScriptPath.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.tbxScriptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxScriptPath.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbxScriptPath.Image = null;
            this.tbxScriptPath.IsDerivedStyle = true;
            this.tbxScriptPath.Lines = null;
            this.tbxScriptPath.Location = new System.Drawing.Point(121, 131);
            this.tbxScriptPath.MaxLength = 32767;
            this.tbxScriptPath.Multiline = false;
            this.tbxScriptPath.Name = "tbxScriptPath";
            this.tbxScriptPath.ReadOnly = false;
            this.tbxScriptPath.Size = new System.Drawing.Size(482, 26);
            this.tbxScriptPath.Style = MetroSet_UI.Enums.Style.Light;
            this.tbxScriptPath.StyleManager = null;
            this.tbxScriptPath.TabIndex = 5;
            this.tbxScriptPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxScriptPath.ThemeAuthor = "Narwin";
            this.tbxScriptPath.ThemeName = "MetroLite";
            this.tbxScriptPath.UseSystemPasswordChar = false;
            this.tbxScriptPath.WatermarkText = "";
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
            this.btnCancel.Location = new System.Drawing.Point(479, 212);
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
            this.btnSave.Location = new System.Drawing.Point(560, 212);
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
            // lblScriptType
            // 
            this.lblScriptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScriptType.IsDerivedStyle = true;
            this.lblScriptType.Location = new System.Drawing.Point(15, 167);
            this.lblScriptType.Name = "lblScriptType";
            this.lblScriptType.Size = new System.Drawing.Size(100, 26);
            this.lblScriptType.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptType.StyleManager = null;
            this.lblScriptType.TabIndex = 8;
            this.lblScriptType.Text = "Type:";
            this.lblScriptType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptType.ThemeAuthor = "Narwin";
            this.lblScriptType.ThemeName = "MetroLite";
            // 
            // cbxScriptType
            // 
            this.cbxScriptType.AllowDrop = true;
            this.cbxScriptType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxScriptType.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxScriptType.BackColor = System.Drawing.Color.Transparent;
            this.cbxScriptType.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbxScriptType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbxScriptType.CausesValidation = false;
            this.cbxScriptType.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbxScriptType.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cbxScriptType.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cbxScriptType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxScriptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxScriptType.FormattingEnabled = true;
            this.cbxScriptType.IsDerivedStyle = true;
            this.cbxScriptType.ItemHeight = 20;
            this.cbxScriptType.Location = new System.Drawing.Point(121, 167);
            this.cbxScriptType.Name = "cbxScriptType";
            this.cbxScriptType.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbxScriptType.SelectedItemForeColor = System.Drawing.Color.White;
            this.cbxScriptType.Size = new System.Drawing.Size(115, 26);
            this.cbxScriptType.Style = MetroSet_UI.Enums.Style.Light;
            this.cbxScriptType.StyleManager = null;
            this.cbxScriptType.TabIndex = 10;
            this.cbxScriptType.ThemeAuthor = "Narwin";
            this.cbxScriptType.ThemeName = "MetroLite";
            this.cbxScriptType.SelectedValueChanged += new System.EventHandler(this.ScriptTypeChanged);
            // 
            // ofdScriptPath
            // 
            this.ofdScriptPath.FileName = "openFileDialog1";
            // 
            // tbxKeyPressed
            // 
            this.tbxKeyPressed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxKeyPressed.AutoCompleteCustomSource = null;
            this.tbxKeyPressed.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbxKeyPressed.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbxKeyPressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxKeyPressed.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tbxKeyPressed.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.tbxKeyPressed.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.tbxKeyPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxKeyPressed.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.tbxKeyPressed.Image = null;
            this.tbxKeyPressed.IsDerivedStyle = true;
            this.tbxKeyPressed.Lines = null;
            this.tbxKeyPressed.Location = new System.Drawing.Point(396, 167);
            this.tbxKeyPressed.MaxLength = 32767;
            this.tbxKeyPressed.Multiline = false;
            this.tbxKeyPressed.Name = "tbxKeyPressed";
            this.tbxKeyPressed.ReadOnly = true;
            this.tbxKeyPressed.Size = new System.Drawing.Size(175, 26);
            this.tbxKeyPressed.Style = MetroSet_UI.Enums.Style.Light;
            this.tbxKeyPressed.StyleManager = null;
            this.tbxKeyPressed.TabIndex = 13;
            this.tbxKeyPressed.Text = "Listening...";
            this.tbxKeyPressed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbxKeyPressed.ThemeAuthor = "Narwin";
            this.tbxKeyPressed.ThemeName = "MetroLite";
            this.tbxKeyPressed.UseSystemPasswordChar = false;
            this.tbxKeyPressed.WatermarkText = "";
            // 
            // lblListenKey
            // 
            this.lblListenKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblListenKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblListenKey.IsDerivedStyle = true;
            this.lblListenKey.Location = new System.Drawing.Point(242, 167);
            this.lblListenKey.Name = "lblListenKey";
            this.lblListenKey.Size = new System.Drawing.Size(148, 26);
            this.lblListenKey.Style = MetroSet_UI.Enums.Style.Light;
            this.lblListenKey.StyleManager = null;
            this.lblListenKey.TabIndex = 11;
            this.lblListenKey.Text = "Run on key pressed:";
            this.lblListenKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblListenKey.ThemeAuthor = "Narwin";
            this.lblListenKey.ThemeName = "MetroLite";
            // 
            // lblScriptSchedule
            // 
            this.lblScriptSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScriptSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblScriptSchedule.IsDerivedStyle = true;
            this.lblScriptSchedule.Location = new System.Drawing.Point(264, 167);
            this.lblScriptSchedule.Name = "lblScriptSchedule";
            this.lblScriptSchedule.Size = new System.Drawing.Size(50, 26);
            this.lblScriptSchedule.Style = MetroSet_UI.Enums.Style.Light;
            this.lblScriptSchedule.StyleManager = null;
            this.lblScriptSchedule.TabIndex = 15;
            this.lblScriptSchedule.Text = "Run at:";
            this.lblScriptSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblScriptSchedule.ThemeAuthor = "Narwin";
            this.lblScriptSchedule.ThemeName = "MetroLite";
            this.lblScriptSchedule.UseCompatibleTextRendering = true;
            // 
            // pbxRemoveKeyPressed
            // 
            this.pbxRemoveKeyPressed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxRemoveKeyPressed.BackColor = System.Drawing.Color.Transparent;
            this.pbxRemoveKeyPressed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxRemoveKeyPressed.Image = ((System.Drawing.Image)(resources.GetObject("pbxRemoveKeyPressed.Image")));
            this.pbxRemoveKeyPressed.Location = new System.Drawing.Point(609, 167);
            this.pbxRemoveKeyPressed.Name = "pbxRemoveKeyPressed";
            this.pbxRemoveKeyPressed.Size = new System.Drawing.Size(26, 26);
            this.pbxRemoveKeyPressed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRemoveKeyPressed.TabIndex = 17;
            this.pbxRemoveKeyPressed.TabStop = false;
            this.pbxRemoveKeyPressed.Click += new System.EventHandler(this.RemoveKeyMappingClicked);
            // 
            // pbxEditKeyPressed
            // 
            this.pbxEditKeyPressed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxEditKeyPressed.BackColor = System.Drawing.Color.Transparent;
            this.pbxEditKeyPressed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxEditKeyPressed.Image = ((System.Drawing.Image)(resources.GetObject("pbxEditKeyPressed.Image")));
            this.pbxEditKeyPressed.Location = new System.Drawing.Point(577, 167);
            this.pbxEditKeyPressed.Name = "pbxEditKeyPressed";
            this.pbxEditKeyPressed.Size = new System.Drawing.Size(26, 26);
            this.pbxEditKeyPressed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEditKeyPressed.TabIndex = 16;
            this.pbxEditKeyPressed.TabStop = false;
            this.pbxEditKeyPressed.Click += new System.EventHandler(this.EditKeyMappingClicked);
            // 
            // tbxScriptScheduled
            // 
            this.tbxScriptScheduled.Location = new System.Drawing.Point(320, 166);
            this.tbxScriptScheduled.Mask = "00:00";
            this.tbxScriptScheduled.Name = "tbxScriptScheduled";
            this.tbxScriptScheduled.Size = new System.Drawing.Size(48, 27);
            this.tbxScriptScheduled.TabIndex = 18;
            this.tbxScriptScheduled.ValidatingType = typeof(System.DateTime);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 250);
            this.Controls.Add(this.tbxScriptScheduled);
            this.Controls.Add(this.pbxRemoveKeyPressed);
            this.Controls.Add(this.pbxEditKeyPressed);
            this.Controls.Add(this.lblScriptSchedule);
            this.Controls.Add(this.tbxKeyPressed);
            this.Controls.Add(this.lblListenKey);
            this.Controls.Add(this.cbxScriptType);
            this.Controls.Add(this.lblScriptType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbxScriptPath);
            this.Controls.Add(this.btnPathSelector);
            this.Controls.Add(this.tbxScriptName);
            this.Controls.Add(this.lblScriptPath);
            this.Controls.Add(this.lblScriptName);
            this.MaximumSize = new System.Drawing.Size(1024, 250);
            this.MinimumSize = new System.Drawing.Size(650, 250);
            this.Name = "ScriptForm";
            this.Text = "ScriptForm";
            this.Controls.SetChildIndex(this.lblScriptName, 0);
            this.Controls.SetChildIndex(this.lblScriptPath, 0);
            this.Controls.SetChildIndex(this.tbxScriptName, 0);
            this.Controls.SetChildIndex(this.btnPathSelector, 0);
            this.Controls.SetChildIndex(this.tbxScriptPath, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblScriptType, 0);
            this.Controls.SetChildIndex(this.cbxScriptType, 0);
            this.Controls.SetChildIndex(this.lblListenKey, 0);
            this.Controls.SetChildIndex(this.tbxKeyPressed, 0);
            this.Controls.SetChildIndex(this.lblScriptSchedule, 0);
            this.Controls.SetChildIndex(this.pbxEditKeyPressed, 0);
            this.Controls.SetChildIndex(this.pbxRemoveKeyPressed, 0);
            this.Controls.SetChildIndex(this.tbxScriptScheduled, 0);
            this.Controls.SetChildIndex(this.metroSetControlBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxRemoveKeyPressed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEditKeyPressed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lblScriptName;
        private MetroSet_UI.Controls.MetroSetLabel lblScriptPath;
        private MetroSet_UI.Controls.MetroSetTextBox tbxScriptName;
        private MetroSet_UI.Controls.MetroSetButton btnPathSelector;
        private MetroSet_UI.Controls.MetroSetTextBox tbxScriptPath;
        private MetroSet_UI.Controls.MetroSetButton btnCancel;
        private MetroSet_UI.Controls.MetroSetButton btnSave;
        private MetroSet_UI.Controls.MetroSetLabel lblScriptType;
        private MetroSet_UI.Controls.MetroSetComboBox cbxScriptType;
        private System.Windows.Forms.OpenFileDialog ofdScriptPath;
        private MetroSet_UI.Controls.MetroSetTextBox tbxKeyPressed;
        private MetroSet_UI.Controls.MetroSetLabel lblListenKey;
        private MetroSet_UI.Controls.MetroSetLabel lblScriptSchedule;
        private System.Windows.Forms.PictureBox pbxRemoveKeyPressed;
        private System.Windows.Forms.PictureBox pbxEditKeyPressed;
        private System.Windows.Forms.MaskedTextBox tbxScriptScheduled;
    }
}