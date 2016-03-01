namespace Cube.Note.App.Editor
{
    partial class SettingsForm
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
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.ResetButton = new Cube.Forms.Button();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ExitButtonShadow = new System.Windows.Forms.Panel();
            this.ExitButton = new Cube.Forms.Button();
            this.ApplyButtonShadow = new System.Windows.Forms.Panel();
            this.ApplyButton = new Cube.Forms.Button();
            this.SettingsControl = new Cube.Note.App.Editor.SettingsControl();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.GeneralSettingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label11 = new System.Windows.Forms.Label();
            this.FontFontButton = new Cube.Forms.FontButton();
            this.FontLabel = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.BackColorColorButton = new Cube.Forms.ColorButton();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.ForeColorColorButton = new Cube.Forms.ColorButton();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.HighlightBackColorColorButton = new Cube.Forms.ColorButton();
            this.HighlightBackColorLabel = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.HighlightForeColorColorButton = new Cube.Forms.ColorButton();
            this.HighlightForeColorLabel = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.AutoSaveTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label32 = new System.Windows.Forms.Label();
            this.RemoveWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.VisibleTabPage = new System.Windows.Forms.TabPage();
            this.VisibleSettinsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label21 = new System.Windows.Forms.Label();
            this.TabWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TabToSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.WordWrapCheckBox = new System.Windows.Forms.CheckBox();
            this.WordWrapLabel = new System.Windows.Forms.Label();
            this.WordWrapCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WordWrapAsWindowCheckBox = new System.Windows.Forms.CheckBox();
            this.LineNumberVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.RulerVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LineNumberBackColorTitleLabel = new System.Windows.Forms.Label();
            this.LineNumberBackColorColorButton = new Cube.Forms.ColorButton();
            this.LineNumberBackColorLabel = new System.Windows.Forms.Label();
            this.LineNumberForeColorTitleLabel = new System.Windows.Forms.Label();
            this.LineNumberForeColorColorButton = new Cube.Forms.ColorButton();
            this.LineNumberForeColorLabel = new System.Windows.Forms.Label();
            this.BracketVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.ModifiedLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentLineColorTitleLabel = new System.Windows.Forms.Label();
            this.CurrentLineColorColorButton = new Cube.Forms.ColorButton();
            this.CurrentLineColorLabel = new System.Windows.Forms.Label();
            this.SpecialCharsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.EolVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.TabVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.FullSpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SpecialCharsColorTitleLabel = new System.Windows.Forms.Label();
            this.SpecialCharsColorColorButton = new Cube.Forms.ColorButton();
            this.SpecialCharsColorLabel = new System.Windows.Forms.Label();
            this.VersionTabPage = new System.Windows.Forms.TabPage();
            this.TextColorColorButton = new Cube.Forms.ColorButton();
            this.Label16 = new System.Windows.Forms.Label();
            this.SearchBackColorColorButton = new Cube.Forms.ColorButton();
            this.SearchBackColorLabel = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.SearchForeColorColorButton = new Cube.Forms.ColorButton();
            this.SearchForeColorLabel = new System.Windows.Forms.Label();
            this.LayoutPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.ExitButtonShadow.SuspendLayout();
            this.ApplyButtonShadow.SuspendLayout();
            this.SettingsControl.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.GeneralSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).BeginInit();
            this.VisibleTabPage.SuspendLayout();
            this.VisibleSettinsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WordWrapCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.ResetButton, 0, 2);
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 0, 3);
            this.LayoutPanel.Controls.Add(this.SettingsControl, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 4;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.LayoutPanel.Size = new System.Drawing.Size(498, 538);
            this.LayoutPanel.TabIndex = 0;
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResetButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.Font = new System.Drawing.Font("Meiryo UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ResetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ResetButton.Location = new System.Drawing.Point(12, 457);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(12, 1, 0, 1);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(120, 25);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "初期値にリセット";
            this.ResetButton.UseVisualStyleBackColor = false;
            // 
            // TitleControl
            // 
            this.TitleControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.TitleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleControl.Location = new System.Drawing.Point(0, 0);
            this.TitleControl.Margin = new System.Windows.Forms.Padding(0);
            this.TitleControl.MaximizeBox = true;
            this.TitleControl.MinimizeBox = true;
            this.TitleControl.Name = "TitleControl";
            this.TitleControl.Size = new System.Drawing.Size(498, 30);
            this.TitleControl.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ExitButtonShadow);
            this.ButtonsPanel.Controls.Add(this.ApplyButtonShadow);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 483);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ButtonsPanel.Size = new System.Drawing.Size(498, 55);
            this.ButtonsPanel.TabIndex = 2;
            // 
            // ExitButtonShadow
            // 
            this.ExitButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ExitButtonShadow.Controls.Add(this.ExitButton);
            this.ExitButtonShadow.Location = new System.Drawing.Point(372, 4);
            this.ExitButtonShadow.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.ExitButtonShadow.Name = "ExitButtonShadow";
            this.ExitButtonShadow.Size = new System.Drawing.Size(110, 37);
            this.ExitButtonShadow.TabIndex = 2;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(0, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(110, 35);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // ApplyButtonShadow
            // 
            this.ApplyButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ApplyButtonShadow.Controls.Add(this.ApplyButton);
            this.ApplyButtonShadow.Location = new System.Drawing.Point(236, 4);
            this.ApplyButtonShadow.Name = "ApplyButtonShadow";
            this.ApplyButtonShadow.Size = new System.Drawing.Size(130, 37);
            this.ApplyButtonShadow.TabIndex = 3;
            // 
            // ApplyButton
            // 
            this.ApplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ApplyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.ForeColor = System.Drawing.Color.White;
            this.ApplyButton.Location = new System.Drawing.Point(0, 0);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(0);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(130, 35);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "OK";
            this.ApplyButton.UseVisualStyleBackColor = false;
            // 
            // SettingsControl
            // 
            this.SettingsControl.Controls.Add(this.TabControl);
            this.SettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsControl.Location = new System.Drawing.Point(12, 42);
            this.SettingsControl.Margin = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.SettingsControl.Name = "SettingsControl";
            this.SettingsControl.Size = new System.Drawing.Size(474, 414);
            this.SettingsControl.TabIndex = 5;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.GeneralTabPage);
            this.TabControl.Controls.Add(this.VisibleTabPage);
            this.TabControl.Controls.Add(this.VersionTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(474, 414);
            this.TabControl.TabIndex = 2;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.GeneralSettingsPanel);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Size = new System.Drawing.Size(466, 386);
            this.GeneralTabPage.TabIndex = 3;
            this.GeneralTabPage.Text = "一 般";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // GeneralSettingsPanel
            // 
            this.GeneralSettingsPanel.AutoScroll = true;
            this.GeneralSettingsPanel.Controls.Add(this.Label11);
            this.GeneralSettingsPanel.Controls.Add(this.FontFontButton);
            this.GeneralSettingsPanel.Controls.Add(this.FontLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label12);
            this.GeneralSettingsPanel.Controls.Add(this.BackColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.BackColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label13);
            this.GeneralSettingsPanel.Controls.Add(this.ForeColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.ForeColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label14);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightBackColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightBackColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label15);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightForeColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightForeColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label16);
            this.GeneralSettingsPanel.Controls.Add(this.SearchBackColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.SearchBackColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label17);
            this.GeneralSettingsPanel.Controls.Add(this.SearchForeColorColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.SearchForeColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label31);
            this.GeneralSettingsPanel.Controls.Add(this.AutoSaveTimeNumericUpDown);
            this.GeneralSettingsPanel.Controls.Add(this.Label32);
            this.GeneralSettingsPanel.Controls.Add(this.RemoveWarningCheckBox);
            this.GeneralSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.GeneralSettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GeneralSettingsPanel.Name = "GeneralSettingsPanel";
            this.GeneralSettingsPanel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.GeneralSettingsPanel.Size = new System.Drawing.Size(466, 386);
            this.GeneralSettingsPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 23);
            this.Label11.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(100, 23);
            this.Label11.TabIndex = 100;
            this.Label11.Text = "フォント";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontFontButton
            // 
            this.FontFontButton.BackColor = System.Drawing.Color.White;
            this.FontFontButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FontFontButton.FixedPitchOnly = false;
            this.FontFontButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FontFontButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontFontButton.ForeColor = System.Drawing.Color.White;
            this.FontFontButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Font;
            this.FontFontButton.Location = new System.Drawing.Point(121, 23);
            this.FontFontButton.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.FontFontButton.Name = "FontFontButton";
            this.FontFontButton.Size = new System.Drawing.Size(50, 23);
            this.FontFontButton.TabIndex = 0;
            this.FontFontButton.UseVisualStyleBackColor = false;
            // 
            // FontLabel
            // 
            this.FontLabel.AutoEllipsis = true;
            this.GeneralSettingsPanel.SetFlowBreak(this.FontLabel, true);
            this.FontLabel.Location = new System.Drawing.Point(177, 23);
            this.FontLabel.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(190, 23);
            this.FontLabel.TabIndex = 1;
            this.FontLabel.Text = "(メイリオ, 11pt)";
            this.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 52);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(100, 23);
            this.Label12.TabIndex = 101;
            this.Label12.Text = "背景色";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackColorColorButton
            // 
            this.BackColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.BackColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BackColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BackColorColorButton.Location = new System.Drawing.Point(121, 52);
            this.BackColorColorButton.Name = "BackColorColorButton";
            this.BackColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.BackColorColorButton.TabIndex = 2;
            this.BackColorColorButton.UseVisualStyleBackColor = false;
            // 
            // BackColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.BackColorLabel, true);
            this.BackColorLabel.Location = new System.Drawing.Point(177, 52);
            this.BackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.BackColorLabel.TabIndex = 3;
            this.BackColorLabel.Text = "(255, 255, 255)";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(15, 81);
            this.Label13.Margin = new System.Windows.Forms.Padding(3);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(100, 23);
            this.Label13.TabIndex = 102;
            this.Label13.Text = "テキスト色";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForeColorColorButton
            // 
            this.ForeColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ForeColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ForeColorColorButton.Location = new System.Drawing.Point(121, 81);
            this.ForeColorColorButton.Name = "ForeColorColorButton";
            this.ForeColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.ForeColorColorButton.TabIndex = 4;
            this.ForeColorColorButton.UseVisualStyleBackColor = false;
            // 
            // ForeColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.ForeColorLabel, true);
            this.ForeColorLabel.Location = new System.Drawing.Point(177, 81);
            this.ForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.ForeColorLabel.TabIndex = 5;
            this.ForeColorLabel.Text = "(255, 255, 255)";
            this.ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(15, 110);
            this.Label14.Margin = new System.Windows.Forms.Padding(3);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(100, 23);
            this.Label14.TabIndex = 103;
            this.Label14.Text = "強調背景色";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HighlightBackColorColorButton
            // 
            this.HighlightBackColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.HighlightBackColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HighlightBackColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.HighlightBackColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighlightBackColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.HighlightBackColorColorButton.Location = new System.Drawing.Point(121, 110);
            this.HighlightBackColorColorButton.Name = "HighlightBackColorColorButton";
            this.HighlightBackColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.HighlightBackColorColorButton.TabIndex = 6;
            this.HighlightBackColorColorButton.UseVisualStyleBackColor = false;
            // 
            // HighlightBackColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.HighlightBackColorLabel, true);
            this.HighlightBackColorLabel.Location = new System.Drawing.Point(177, 110);
            this.HighlightBackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.HighlightBackColorLabel.Name = "HighlightBackColorLabel";
            this.HighlightBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.HighlightBackColorLabel.TabIndex = 7;
            this.HighlightBackColorLabel.Text = "(255, 255, 255)";
            this.HighlightBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(15, 139);
            this.Label15.Margin = new System.Windows.Forms.Padding(3);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(100, 23);
            this.Label15.TabIndex = 104;
            this.Label15.Text = "強調テキスト色";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HighlightForeColorColorButton
            // 
            this.HighlightForeColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.HighlightForeColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HighlightForeColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.HighlightForeColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighlightForeColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.HighlightForeColorColorButton.Location = new System.Drawing.Point(121, 139);
            this.HighlightForeColorColorButton.Name = "HighlightForeColorColorButton";
            this.HighlightForeColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.HighlightForeColorColorButton.TabIndex = 8;
            this.HighlightForeColorColorButton.UseVisualStyleBackColor = false;
            // 
            // HighlightForeColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.HighlightForeColorLabel, true);
            this.HighlightForeColorLabel.Location = new System.Drawing.Point(177, 139);
            this.HighlightForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.HighlightForeColorLabel.Name = "HighlightForeColorLabel";
            this.HighlightForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.HighlightForeColorLabel.TabIndex = 9;
            this.HighlightForeColorLabel.Text = "(255, 255, 255)";
            this.HighlightForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label31
            // 
            this.Label31.Location = new System.Drawing.Point(15, 247);
            this.Label31.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(100, 23);
            this.Label31.TabIndex = 105;
            this.Label31.Text = "自動保存間隔";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoSaveTimeNumericUpDown
            // 
            this.AutoSaveTimeNumericUpDown.Location = new System.Drawing.Point(121, 247);
            this.AutoSaveTimeNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.AutoSaveTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AutoSaveTimeNumericUpDown.Name = "AutoSaveTimeNumericUpDown";
            this.AutoSaveTimeNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.AutoSaveTimeNumericUpDown.TabIndex = 10;
            this.AutoSaveTimeNumericUpDown.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // Label32
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.Label32, true);
            this.Label32.Location = new System.Drawing.Point(207, 247);
            this.Label32.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(100, 23);
            this.Label32.TabIndex = 106;
            this.Label32.Text = "秒";
            this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemoveWarningCheckBox
            // 
            this.RemoveWarningCheckBox.AutoSize = true;
            this.RemoveWarningCheckBox.Location = new System.Drawing.Point(15, 279);
            this.RemoveWarningCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.RemoveWarningCheckBox.Name = "RemoveWarningCheckBox";
            this.RemoveWarningCheckBox.Size = new System.Drawing.Size(218, 19);
            this.RemoveWarningCheckBox.TabIndex = 15;
            this.RemoveWarningCheckBox.Text = "ノート削除時に警告メッセージを表示する";
            this.RemoveWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // VisibleTabPage
            // 
            this.VisibleTabPage.Controls.Add(this.VisibleSettinsPanel);
            this.VisibleTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisibleTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleTabPage.Name = "VisibleTabPage";
            this.VisibleTabPage.Size = new System.Drawing.Size(466, 386);
            this.VisibleTabPage.TabIndex = 0;
            this.VisibleTabPage.Text = "表示オプション";
            this.VisibleTabPage.UseVisualStyleBackColor = true;
            // 
            // VisibleSettinsPanel
            // 
            this.VisibleSettinsPanel.AutoScroll = true;
            this.VisibleSettinsPanel.Controls.Add(this.Label21);
            this.VisibleSettinsPanel.Controls.Add(this.TabWidthNumericUpDown);
            this.VisibleSettinsPanel.Controls.Add(this.TabToSpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.WordWrapCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.WordWrapLabel);
            this.VisibleSettinsPanel.Controls.Add(this.WordWrapCountNumericUpDown);
            this.VisibleSettinsPanel.Controls.Add(this.WordWrapAsWindowCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.RulerVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.BracketVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.ModifiedLineVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.EolVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.TabVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.FullSpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorLabel);
            this.VisibleSettinsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisibleSettinsPanel.Location = new System.Drawing.Point(0, 0);
            this.VisibleSettinsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleSettinsPanel.Name = "VisibleSettinsPanel";
            this.VisibleSettinsPanel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.VisibleSettinsPanel.Size = new System.Drawing.Size(466, 386);
            this.VisibleSettinsPanel.TabIndex = 0;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(15, 23);
            this.Label21.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(100, 23);
            this.Label21.TabIndex = 100;
            this.Label21.Text = "タブ幅";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabWidthNumericUpDown
            // 
            this.TabWidthNumericUpDown.Location = new System.Drawing.Point(121, 23);
            this.TabWidthNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 23, 3, 3);
            this.TabWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TabWidthNumericUpDown.Name = "TabWidthNumericUpDown";
            this.TabWidthNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.TabWidthNumericUpDown.TabIndex = 0;
            this.TabWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TabToSpaceCheckBox
            // 
            this.TabToSpaceCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.TabToSpaceCheckBox, true);
            this.TabToSpaceCheckBox.Location = new System.Drawing.Point(186, 25);
            this.TabToSpaceCheckBox.Margin = new System.Windows.Forms.Padding(12, 25, 3, 0);
            this.TabToSpaceCheckBox.Name = "TabToSpaceCheckBox";
            this.TabToSpaceCheckBox.Size = new System.Drawing.Size(182, 19);
            this.TabToSpaceCheckBox.TabIndex = 1;
            this.TabToSpaceCheckBox.Text = "タブの代わりにスペースを挿入する";
            this.TabToSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // WordWrapCheckBox
            // 
            this.WordWrapCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.WordWrapCheckBox, true);
            this.WordWrapCheckBox.Location = new System.Drawing.Point(15, 55);
            this.WordWrapCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.WordWrapCheckBox.Name = "WordWrapCheckBox";
            this.WordWrapCheckBox.Size = new System.Drawing.Size(147, 19);
            this.WordWrapCheckBox.TabIndex = 2;
            this.WordWrapCheckBox.Text = "テキストを右端で折り返す";
            this.WordWrapCheckBox.UseVisualStyleBackColor = true;
            // 
            // WordWrapLabel
            // 
            this.WordWrapLabel.Location = new System.Drawing.Point(30, 77);
            this.WordWrapLabel.Margin = new System.Windows.Forms.Padding(18, 0, 3, 3);
            this.WordWrapLabel.Name = "WordWrapLabel";
            this.WordWrapLabel.Size = new System.Drawing.Size(85, 23);
            this.WordWrapLabel.TabIndex = 101;
            this.WordWrapLabel.Text = "文字数";
            this.WordWrapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WordWrapCountNumericUpDown
            // 
            this.WordWrapCountNumericUpDown.Location = new System.Drawing.Point(121, 77);
            this.WordWrapCountNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.WordWrapCountNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WordWrapCountNumericUpDown.Name = "WordWrapCountNumericUpDown";
            this.WordWrapCountNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.WordWrapCountNumericUpDown.TabIndex = 3;
            this.WordWrapCountNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // WordWrapAsWindowCheckBox
            // 
            this.WordWrapAsWindowCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.WordWrapAsWindowCheckBox, true);
            this.WordWrapAsWindowCheckBox.Location = new System.Drawing.Point(186, 79);
            this.WordWrapAsWindowCheckBox.Margin = new System.Windows.Forms.Padding(12, 2, 3, 0);
            this.WordWrapAsWindowCheckBox.Name = "WordWrapAsWindowCheckBox";
            this.WordWrapAsWindowCheckBox.Size = new System.Drawing.Size(130, 19);
            this.WordWrapAsWindowCheckBox.TabIndex = 4;
            this.WordWrapAsWindowCheckBox.Text = "ウィンドウ幅に合わせる";
            this.WordWrapAsWindowCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberVisibleCheckBox
            // 
            this.LineNumberVisibleCheckBox.AutoSize = true;
            this.LineNumberVisibleCheckBox.Location = new System.Drawing.Point(15, 106);
            this.LineNumberVisibleCheckBox.Name = "LineNumberVisibleCheckBox";
            this.LineNumberVisibleCheckBox.Size = new System.Drawing.Size(114, 19);
            this.LineNumberVisibleCheckBox.TabIndex = 5;
            this.LineNumberVisibleCheckBox.Text = "行番号を表示する";
            this.LineNumberVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // RulerVisibleCheckBox
            // 
            this.RulerVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.RulerVisibleCheckBox, true);
            this.RulerVisibleCheckBox.Location = new System.Drawing.Point(148, 106);
            this.RulerVisibleCheckBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 0);
            this.RulerVisibleCheckBox.Name = "RulerVisibleCheckBox";
            this.RulerVisibleCheckBox.Size = new System.Drawing.Size(110, 19);
            this.RulerVisibleCheckBox.TabIndex = 6;
            this.RulerVisibleCheckBox.Text = "目盛りを表示する";
            this.RulerVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberBackColorTitleLabel
            // 
            this.LineNumberBackColorTitleLabel.Location = new System.Drawing.Point(30, 128);
            this.LineNumberBackColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 0, 3, 3);
            this.LineNumberBackColorTitleLabel.Name = "LineNumberBackColorTitleLabel";
            this.LineNumberBackColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberBackColorTitleLabel.TabIndex = 102;
            this.LineNumberBackColorTitleLabel.Text = "背景色";
            this.LineNumberBackColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberBackColorColorButton
            // 
            this.LineNumberBackColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LineNumberBackColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LineNumberBackColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberBackColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorColorButton.Location = new System.Drawing.Point(121, 128);
            this.LineNumberBackColorColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LineNumberBackColorColorButton.Name = "LineNumberBackColorColorButton";
            this.LineNumberBackColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberBackColorColorButton.TabIndex = 7;
            this.LineNumberBackColorColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberBackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberBackColorLabel, true);
            this.LineNumberBackColorLabel.Location = new System.Drawing.Point(177, 128);
            this.LineNumberBackColorLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LineNumberBackColorLabel.Name = "LineNumberBackColorLabel";
            this.LineNumberBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberBackColorLabel.TabIndex = 8;
            this.LineNumberBackColorLabel.Text = "(255, 255, 255)";
            this.LineNumberBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorTitleLabel
            // 
            this.LineNumberForeColorTitleLabel.Location = new System.Drawing.Point(30, 157);
            this.LineNumberForeColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.LineNumberForeColorTitleLabel.Name = "LineNumberForeColorTitleLabel";
            this.LineNumberForeColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberForeColorTitleLabel.TabIndex = 103;
            this.LineNumberForeColorTitleLabel.Text = "テキスト色";
            this.LineNumberForeColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorColorButton
            // 
            this.LineNumberForeColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LineNumberForeColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.LineNumberForeColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberForeColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorColorButton.Location = new System.Drawing.Point(121, 157);
            this.LineNumberForeColorColorButton.Name = "LineNumberForeColorColorButton";
            this.LineNumberForeColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberForeColorColorButton.TabIndex = 9;
            this.LineNumberForeColorColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberForeColorLabel, true);
            this.LineNumberForeColorLabel.Location = new System.Drawing.Point(177, 157);
            this.LineNumberForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LineNumberForeColorLabel.Name = "LineNumberForeColorLabel";
            this.LineNumberForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberForeColorLabel.TabIndex = 10;
            this.LineNumberForeColorLabel.Text = "(255, 255, 255)";
            this.LineNumberForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BracketVisibleCheckBox
            // 
            this.BracketVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.BracketVisibleCheckBox, true);
            this.BracketVisibleCheckBox.Location = new System.Drawing.Point(15, 186);
            this.BracketVisibleCheckBox.Name = "BracketVisibleCheckBox";
            this.BracketVisibleCheckBox.Size = new System.Drawing.Size(169, 19);
            this.BracketVisibleCheckBox.TabIndex = 11;
            this.BracketVisibleCheckBox.Text = "対応する括弧を強調表示する";
            this.BracketVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // ModifiedLineVisibleCheckBox
            // 
            this.ModifiedLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.ModifiedLineVisibleCheckBox, true);
            this.ModifiedLineVisibleCheckBox.Location = new System.Drawing.Point(15, 211);
            this.ModifiedLineVisibleCheckBox.Name = "ModifiedLineVisibleCheckBox";
            this.ModifiedLineVisibleCheckBox.Size = new System.Drawing.Size(156, 19);
            this.ModifiedLineVisibleCheckBox.TabIndex = 12;
            this.ModifiedLineVisibleCheckBox.Text = "修正した行を強調表示する";
            this.ModifiedLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentLineVisibleCheckBox
            // 
            this.CurrentLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentLineVisibleCheckBox, true);
            this.CurrentLineVisibleCheckBox.Location = new System.Drawing.Point(15, 236);
            this.CurrentLineVisibleCheckBox.Name = "CurrentLineVisibleCheckBox";
            this.CurrentLineVisibleCheckBox.Size = new System.Drawing.Size(181, 19);
            this.CurrentLineVisibleCheckBox.TabIndex = 13;
            this.CurrentLineVisibleCheckBox.Text = "カーソルのある行を強調表示する";
            this.CurrentLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentLineColorTitleLabel
            // 
            this.CurrentLineColorTitleLabel.Location = new System.Drawing.Point(30, 259);
            this.CurrentLineColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 0, 3, 3);
            this.CurrentLineColorTitleLabel.Name = "CurrentLineColorTitleLabel";
            this.CurrentLineColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.CurrentLineColorTitleLabel.TabIndex = 104;
            this.CurrentLineColorTitleLabel.Text = "表示色";
            this.CurrentLineColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentLineColorColorButton
            // 
            this.CurrentLineColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentLineColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CurrentLineColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.CurrentLineColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentLineColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentLineColorColorButton.Location = new System.Drawing.Point(121, 259);
            this.CurrentLineColorColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.CurrentLineColorColorButton.Name = "CurrentLineColorColorButton";
            this.CurrentLineColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.CurrentLineColorColorButton.TabIndex = 14;
            this.CurrentLineColorColorButton.UseVisualStyleBackColor = false;
            // 
            // CurrentLineColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentLineColorLabel, true);
            this.CurrentLineColorLabel.Location = new System.Drawing.Point(177, 259);
            this.CurrentLineColorLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.CurrentLineColorLabel.Name = "CurrentLineColorLabel";
            this.CurrentLineColorLabel.Size = new System.Drawing.Size(190, 23);
            this.CurrentLineColorLabel.TabIndex = 15;
            this.CurrentLineColorLabel.Text = "(255, 255, 255)";
            this.CurrentLineColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpecialCharsVisibleCheckBox
            // 
            this.SpecialCharsVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCharsVisibleCheckBox, true);
            this.SpecialCharsVisibleCheckBox.Location = new System.Drawing.Point(15, 288);
            this.SpecialCharsVisibleCheckBox.Name = "SpecialCharsVisibleCheckBox";
            this.SpecialCharsVisibleCheckBox.Size = new System.Drawing.Size(126, 19);
            this.SpecialCharsVisibleCheckBox.TabIndex = 16;
            this.SpecialCharsVisibleCheckBox.Text = "特殊文字を表示する";
            this.SpecialCharsVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // EolVisibleCheckBox
            // 
            this.EolVisibleCheckBox.AutoSize = true;
            this.EolVisibleCheckBox.Location = new System.Drawing.Point(32, 313);
            this.EolVisibleCheckBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.EolVisibleCheckBox.Name = "EolVisibleCheckBox";
            this.EolVisibleCheckBox.Size = new System.Drawing.Size(50, 19);
            this.EolVisibleCheckBox.TabIndex = 17;
            this.EolVisibleCheckBox.Text = "改行";
            this.EolVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TabVisibleCheckBox
            // 
            this.TabVisibleCheckBox.AutoSize = true;
            this.TabVisibleCheckBox.Location = new System.Drawing.Point(88, 313);
            this.TabVisibleCheckBox.Name = "TabVisibleCheckBox";
            this.TabVisibleCheckBox.Size = new System.Drawing.Size(43, 19);
            this.TabVisibleCheckBox.TabIndex = 18;
            this.TabVisibleCheckBox.Text = "タブ";
            this.TabVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpaceVisibleCheckBox
            // 
            this.SpaceVisibleCheckBox.AutoSize = true;
            this.SpaceVisibleCheckBox.Location = new System.Drawing.Point(137, 313);
            this.SpaceVisibleCheckBox.Name = "SpaceVisibleCheckBox";
            this.SpaceVisibleCheckBox.Size = new System.Drawing.Size(88, 19);
            this.SpaceVisibleCheckBox.TabIndex = 19;
            this.SpaceVisibleCheckBox.Text = "半角スペース";
            this.SpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // FullSpaceVisibleCheckBox
            // 
            this.FullSpaceVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.FullSpaceVisibleCheckBox, true);
            this.FullSpaceVisibleCheckBox.Location = new System.Drawing.Point(231, 313);
            this.FullSpaceVisibleCheckBox.Name = "FullSpaceVisibleCheckBox";
            this.FullSpaceVisibleCheckBox.Size = new System.Drawing.Size(88, 19);
            this.FullSpaceVisibleCheckBox.TabIndex = 20;
            this.FullSpaceVisibleCheckBox.Text = "全角スペース";
            this.FullSpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpecialCharsColorTitleLabel
            // 
            this.SpecialCharsColorTitleLabel.Location = new System.Drawing.Point(30, 338);
            this.SpecialCharsColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.SpecialCharsColorTitleLabel.Name = "SpecialCharsColorTitleLabel";
            this.SpecialCharsColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.SpecialCharsColorTitleLabel.TabIndex = 105;
            this.SpecialCharsColorTitleLabel.Text = "表示色";
            this.SpecialCharsColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpecialCharsColorColorButton
            // 
            this.SpecialCharsColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.SpecialCharsColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpecialCharsColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SpecialCharsColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpecialCharsColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SpecialCharsColorColorButton.Location = new System.Drawing.Point(121, 338);
            this.SpecialCharsColorColorButton.Name = "SpecialCharsColorColorButton";
            this.SpecialCharsColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.SpecialCharsColorColorButton.TabIndex = 21;
            this.SpecialCharsColorColorButton.UseVisualStyleBackColor = false;
            // 
            // SpecialCharsColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCharsColorLabel, true);
            this.SpecialCharsColorLabel.Location = new System.Drawing.Point(177, 338);
            this.SpecialCharsColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SpecialCharsColorLabel.Name = "SpecialCharsColorLabel";
            this.SpecialCharsColorLabel.Size = new System.Drawing.Size(190, 23);
            this.SpecialCharsColorLabel.TabIndex = 22;
            this.SpecialCharsColorLabel.Text = "(255, 255, 255)";
            this.SpecialCharsColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionTabPage
            // 
            this.VersionTabPage.Location = new System.Drawing.Point(4, 24);
            this.VersionTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VersionTabPage.Name = "VersionTabPage";
            this.VersionTabPage.Size = new System.Drawing.Size(466, 386);
            this.VersionTabPage.TabIndex = 2;
            this.VersionTabPage.Text = "CubeNote について";
            this.VersionTabPage.UseVisualStyleBackColor = true;
            // 
            // TextColorColorButton
            // 
            this.TextColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.TextColorColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TextColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.TextColorColorButton.Location = new System.Drawing.Point(121, 81);
            this.TextColorColorButton.Name = "TextColorColorButton";
            this.TextColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.TextColorColorButton.TabIndex = 30;
            this.TextColorColorButton.Text = "colorButton1";
            this.TextColorColorButton.UseVisualStyleBackColor = false;
            // 
            // Label16
            // 
            this.Label16.Location = new System.Drawing.Point(15, 168);
            this.Label16.Margin = new System.Windows.Forms.Padding(3);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(100, 23);
            this.Label16.TabIndex = 111;
            this.Label16.Text = "検索背景色";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchBackColorColorButton
            // 
            this.SearchBackColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.SearchBackColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchBackColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SearchBackColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBackColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchBackColorColorButton.Location = new System.Drawing.Point(121, 168);
            this.SearchBackColorColorButton.Name = "SearchBackColorColorButton";
            this.SearchBackColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.SearchBackColorColorButton.TabIndex = 10;
            this.SearchBackColorColorButton.UseVisualStyleBackColor = false;
            // 
            // SearchBackColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.SearchBackColorLabel, true);
            this.SearchBackColorLabel.Location = new System.Drawing.Point(177, 168);
            this.SearchBackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SearchBackColorLabel.Name = "SearchBackColorLabel";
            this.SearchBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.SearchBackColorLabel.TabIndex = 11;
            this.SearchBackColorLabel.Text = "(255, 255, 255)";
            this.SearchBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label17
            // 
            this.Label17.Location = new System.Drawing.Point(15, 197);
            this.Label17.Margin = new System.Windows.Forms.Padding(3);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(100, 23);
            this.Label17.TabIndex = 112;
            this.Label17.Text = "検索テキスト色";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchForeColorColorButton
            // 
            this.SearchForeColorColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.SearchForeColorColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchForeColorColorButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SearchForeColorColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchForeColorColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchForeColorColorButton.Location = new System.Drawing.Point(121, 197);
            this.SearchForeColorColorButton.Name = "SearchForeColorColorButton";
            this.SearchForeColorColorButton.Size = new System.Drawing.Size(50, 23);
            this.SearchForeColorColorButton.TabIndex = 12;
            this.SearchForeColorColorButton.UseVisualStyleBackColor = false;
            // 
            // SearchForeColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.SearchForeColorLabel, true);
            this.SearchForeColorLabel.Location = new System.Drawing.Point(177, 197);
            this.SearchForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SearchForeColorLabel.Name = "SearchForeColorLabel";
            this.SearchForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.SearchForeColorLabel.TabIndex = 13;
            this.SearchForeColorLabel.Text = "(255, 255, 255)";
            this.SearchForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(500, 540);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(500, 320);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Sizable = true;
            this.LayoutPanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.ExitButtonShadow.ResumeLayout(false);
            this.ApplyButtonShadow.ResumeLayout(false);
            this.SettingsControl.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralSettingsPanel.ResumeLayout(false);
            this.GeneralSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).EndInit();
            this.VisibleTabPage.ResumeLayout(false);
            this.VisibleSettinsPanel.ResumeLayout(false);
            this.VisibleSettinsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WordWrapCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private Cube.Forms.FlowLayoutPanel ButtonsPanel;
        private Cube.Forms.Button ResetButton;
        private System.Windows.Forms.Panel ExitButtonShadow;
        private Forms.Button ExitButton;
        private System.Windows.Forms.Panel ApplyButtonShadow;
        private Forms.Button ApplyButton;
        private SettingsControl SettingsControl;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.FlowLayoutPanel GeneralSettingsPanel;
        private System.Windows.Forms.Label Label11;
        private Forms.FontButton FontFontButton;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Label Label12;
        private Forms.ColorButton BackColorColorButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.Label Label13;
        private Forms.ColorButton ForeColorColorButton;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.Label HighlightBackColorLabel;
        private System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Label HighlightForeColorLabel;
        private System.Windows.Forms.Label Label31;
        private System.Windows.Forms.NumericUpDown AutoSaveTimeNumericUpDown;
        private System.Windows.Forms.Label Label32;
        private System.Windows.Forms.CheckBox RemoveWarningCheckBox;
        private System.Windows.Forms.TabPage VisibleTabPage;
        private System.Windows.Forms.FlowLayoutPanel VisibleSettinsPanel;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.NumericUpDown TabWidthNumericUpDown;
        private System.Windows.Forms.CheckBox TabToSpaceCheckBox;
        private System.Windows.Forms.CheckBox WordWrapCheckBox;
        private System.Windows.Forms.Label WordWrapLabel;
        private System.Windows.Forms.NumericUpDown WordWrapCountNumericUpDown;
        private System.Windows.Forms.CheckBox WordWrapAsWindowCheckBox;
        private System.Windows.Forms.CheckBox LineNumberVisibleCheckBox;
        private System.Windows.Forms.CheckBox RulerVisibleCheckBox;
        private System.Windows.Forms.Label LineNumberBackColorTitleLabel;
        private System.Windows.Forms.Label LineNumberBackColorLabel;
        private System.Windows.Forms.Label LineNumberForeColorTitleLabel;
        private System.Windows.Forms.Label LineNumberForeColorLabel;
        private System.Windows.Forms.CheckBox BracketVisibleCheckBox;
        private System.Windows.Forms.CheckBox ModifiedLineVisibleCheckBox;
        private System.Windows.Forms.CheckBox CurrentLineVisibleCheckBox;
        private System.Windows.Forms.Label CurrentLineColorTitleLabel;
        private System.Windows.Forms.Label CurrentLineColorLabel;
        private System.Windows.Forms.CheckBox SpecialCharsVisibleCheckBox;
        private System.Windows.Forms.CheckBox EolVisibleCheckBox;
        private System.Windows.Forms.CheckBox TabVisibleCheckBox;
        private System.Windows.Forms.CheckBox SpaceVisibleCheckBox;
        private System.Windows.Forms.CheckBox FullSpaceVisibleCheckBox;
        private System.Windows.Forms.Label SpecialCharsColorTitleLabel;
        private System.Windows.Forms.Label SpecialCharsColorLabel;
        private System.Windows.Forms.TabPage VersionTabPage;
        private Forms.ColorButton HighlightBackColorColorButton;
        private Forms.ColorButton HighlightForeColorColorButton;
        private Forms.ColorButton TextColorColorButton;
        private Forms.ColorButton LineNumberBackColorColorButton;
        private Forms.ColorButton LineNumberForeColorColorButton;
        private Forms.ColorButton CurrentLineColorColorButton;
        private Forms.ColorButton SpecialCharsColorColorButton;
        private System.Windows.Forms.Label Label16;
        private Forms.ColorButton SearchBackColorColorButton;
        private System.Windows.Forms.Label SearchBackColorLabel;
        private System.Windows.Forms.Label Label17;
        private Forms.ColorButton SearchForeColorColorButton;
        private System.Windows.Forms.Label SearchForeColorLabel;
    }
}