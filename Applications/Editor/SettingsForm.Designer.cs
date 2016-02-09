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
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.GeneralSettingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label11 = new System.Windows.Forms.Label();
            this.FontButton = new Cube.Forms.Button();
            this.FontLabel = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.BackColorButton = new Cube.Forms.Button();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.ForeColorButton = new Cube.Forms.Button();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.HighlightBackColorButton = new Cube.Forms.Button();
            this.HighlightBackColorLabel = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.HighlightForeColorButton = new Cube.Forms.Button();
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
            this.LineNumberVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.RulerVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.LineNumberBackColorTitleLabel = new System.Windows.Forms.Label();
            this.LineNumberBackColorButton = new Cube.Forms.Button();
            this.LineNumberBackColorLabel = new System.Windows.Forms.Label();
            this.LineNumberForeColorTitleLabel = new System.Windows.Forms.Label();
            this.LineNumberForeColorButton = new Cube.Forms.Button();
            this.LineNumberForeColorLabel = new System.Windows.Forms.Label();
            this.BracketVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.ModifiedLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentLineColorTitleLabel = new System.Windows.Forms.Label();
            this.CurrentLineColorButton = new Cube.Forms.Button();
            this.CurrentLineColorLabel = new System.Windows.Forms.Label();
            this.SpecialCharsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.EolVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.TabVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.FullSpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SpecialCharsColorTitleLabel = new System.Windows.Forms.Label();
            this.SpecialCharsColorButton = new Cube.Forms.Button();
            this.SpecialCharsColorLabel = new System.Windows.Forms.Label();
            this.VersionTabPage = new System.Windows.Forms.TabPage();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ApplyButton = new Cube.Forms.Button();
            this.ExitButton = new Cube.Forms.Button();
            this.RunButton = new Cube.Forms.Button();
            this.WardWrapCheckBox = new System.Windows.Forms.CheckBox();
            this.LayoutPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.GeneralSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).BeginInit();
            this.VisibleTabPage.SuspendLayout();
            this.VisibleSettinsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.TabControl, 0, 1);
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 0, 2);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.LayoutPanel.Size = new System.Drawing.Size(498, 528);
            this.LayoutPanel.TabIndex = 0;
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
            // TabControl
            // 
            this.TabControl.Controls.Add(this.GeneralTabPage);
            this.TabControl.Controls.Add(this.VisibleTabPage);
            this.TabControl.Controls.Add(this.VersionTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(12, 42);
            this.TabControl.Margin = new System.Windows.Forms.Padding(12, 12, 12, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(474, 423);
            this.TabControl.TabIndex = 1;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.GeneralSettingsPanel);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(466, 395);
            this.GeneralTabPage.TabIndex = 3;
            this.GeneralTabPage.Text = "一 般";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // GeneralSettingsPanel
            // 
            this.GeneralSettingsPanel.AutoScroll = true;
            this.GeneralSettingsPanel.Controls.Add(this.Label11);
            this.GeneralSettingsPanel.Controls.Add(this.FontButton);
            this.GeneralSettingsPanel.Controls.Add(this.FontLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label12);
            this.GeneralSettingsPanel.Controls.Add(this.BackColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.BackColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label13);
            this.GeneralSettingsPanel.Controls.Add(this.ForeColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.ForeColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label14);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightBackColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightBackColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label15);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightForeColorButton);
            this.GeneralSettingsPanel.Controls.Add(this.HighlightForeColorLabel);
            this.GeneralSettingsPanel.Controls.Add(this.Label31);
            this.GeneralSettingsPanel.Controls.Add(this.AutoSaveTimeNumericUpDown);
            this.GeneralSettingsPanel.Controls.Add(this.Label32);
            this.GeneralSettingsPanel.Controls.Add(this.RemoveWarningCheckBox);
            this.GeneralSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralSettingsPanel.Location = new System.Drawing.Point(3, 3);
            this.GeneralSettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GeneralSettingsPanel.Name = "GeneralSettingsPanel";
            this.GeneralSettingsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.GeneralSettingsPanel.Size = new System.Drawing.Size(460, 389);
            this.GeneralSettingsPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 23);
            this.Label11.Margin = new System.Windows.Forms.Padding(3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(100, 23);
            this.Label11.TabIndex = 9;
            this.Label11.Text = "フォント";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontButton
            // 
            this.FontButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FontButton.Location = new System.Drawing.Point(121, 23);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(50, 23);
            this.FontButton.TabIndex = 11;
            this.FontButton.Text = "...";
            this.FontButton.UseVisualStyleBackColor = true;
            // 
            // FontLabel
            // 
            this.FontLabel.AutoEllipsis = true;
            this.GeneralSettingsPanel.SetFlowBreak(this.FontLabel, true);
            this.FontLabel.Location = new System.Drawing.Point(177, 23);
            this.FontLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(190, 23);
            this.FontLabel.TabIndex = 10;
            this.FontLabel.Text = "(メイリオ, 11pt)";
            this.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 52);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(100, 23);
            this.Label12.TabIndex = 15;
            this.Label12.Text = "背景色";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackColorButton
            // 
            this.BackColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.BackColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BackColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BackColorButton.Location = new System.Drawing.Point(121, 52);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(50, 23);
            this.BackColorButton.TabIndex = 16;
            this.BackColorButton.UseVisualStyleBackColor = false;
            // 
            // BackColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.BackColorLabel, true);
            this.BackColorLabel.Location = new System.Drawing.Point(177, 52);
            this.BackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.BackColorLabel.TabIndex = 17;
            this.BackColorLabel.Text = "(255, 255, 255)";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(15, 81);
            this.Label13.Margin = new System.Windows.Forms.Padding(3);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(100, 23);
            this.Label13.TabIndex = 12;
            this.Label13.Text = "テキスト色";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForeColorButton
            // 
            this.ForeColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ForeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ForeColorButton.Location = new System.Drawing.Point(121, 81);
            this.ForeColorButton.Name = "ForeColorButton";
            this.ForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.ForeColorButton.TabIndex = 13;
            this.ForeColorButton.UseVisualStyleBackColor = false;
            // 
            // ForeColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.ForeColorLabel, true);
            this.ForeColorLabel.Location = new System.Drawing.Point(177, 81);
            this.ForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.ForeColorLabel.TabIndex = 14;
            this.ForeColorLabel.Text = "(255, 255, 255)";
            this.ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(15, 110);
            this.Label14.Margin = new System.Windows.Forms.Padding(3);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(100, 23);
            this.Label14.TabIndex = 18;
            this.Label14.Text = "強調背景色";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HighlightBackColorButton
            // 
            this.HighlightBackColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.HighlightBackColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HighlightBackColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.HighlightBackColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighlightBackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.HighlightBackColorButton.Location = new System.Drawing.Point(121, 110);
            this.HighlightBackColorButton.Name = "HighlightBackColorButton";
            this.HighlightBackColorButton.Size = new System.Drawing.Size(50, 23);
            this.HighlightBackColorButton.TabIndex = 19;
            this.HighlightBackColorButton.UseVisualStyleBackColor = false;
            // 
            // HighlightBackColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.HighlightBackColorLabel, true);
            this.HighlightBackColorLabel.Location = new System.Drawing.Point(177, 110);
            this.HighlightBackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.HighlightBackColorLabel.Name = "HighlightBackColorLabel";
            this.HighlightBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.HighlightBackColorLabel.TabIndex = 20;
            this.HighlightBackColorLabel.Text = "(255, 255, 255)";
            this.HighlightBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(15, 139);
            this.Label15.Margin = new System.Windows.Forms.Padding(3);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(100, 23);
            this.Label15.TabIndex = 21;
            this.Label15.Text = "強調テキスト色";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HighlightForeColorButton
            // 
            this.HighlightForeColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.HighlightForeColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HighlightForeColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.HighlightForeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HighlightForeColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.HighlightForeColorButton.Location = new System.Drawing.Point(121, 139);
            this.HighlightForeColorButton.Name = "HighlightForeColorButton";
            this.HighlightForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.HighlightForeColorButton.TabIndex = 22;
            this.HighlightForeColorButton.UseVisualStyleBackColor = false;
            // 
            // HighlightForeColorLabel
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.HighlightForeColorLabel, true);
            this.HighlightForeColorLabel.Location = new System.Drawing.Point(177, 139);
            this.HighlightForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.HighlightForeColorLabel.Name = "HighlightForeColorLabel";
            this.HighlightForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.HighlightForeColorLabel.TabIndex = 23;
            this.HighlightForeColorLabel.Text = "(255, 255, 255)";
            this.HighlightForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label31
            // 
            this.Label31.Location = new System.Drawing.Point(15, 189);
            this.Label31.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(100, 23);
            this.Label31.TabIndex = 24;
            this.Label31.Text = "自動保存間隔";
            this.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoSaveTimeNumericUpDown
            // 
            this.AutoSaveTimeNumericUpDown.Location = new System.Drawing.Point(121, 189);
            this.AutoSaveTimeNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.AutoSaveTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AutoSaveTimeNumericUpDown.Name = "AutoSaveTimeNumericUpDown";
            this.AutoSaveTimeNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.AutoSaveTimeNumericUpDown.TabIndex = 25;
            this.AutoSaveTimeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Label32
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.Label32, true);
            this.Label32.Location = new System.Drawing.Point(207, 189);
            this.Label32.Margin = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(100, 23);
            this.Label32.TabIndex = 26;
            this.Label32.Text = "秒";
            this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemoveWarningCheckBox
            // 
            this.RemoveWarningCheckBox.AutoSize = true;
            this.GeneralSettingsPanel.SetFlowBreak(this.RemoveWarningCheckBox, true);
            this.RemoveWarningCheckBox.Location = new System.Drawing.Point(15, 221);
            this.RemoveWarningCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.RemoveWarningCheckBox.Name = "RemoveWarningCheckBox";
            this.RemoveWarningCheckBox.Size = new System.Drawing.Size(218, 19);
            this.RemoveWarningCheckBox.TabIndex = 27;
            this.RemoveWarningCheckBox.Text = "ノート削除時に警告メッセージを表示する";
            this.RemoveWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // VisibleTabPage
            // 
            this.VisibleTabPage.Controls.Add(this.VisibleSettinsPanel);
            this.VisibleTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisibleTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleTabPage.Name = "VisibleTabPage";
            this.VisibleTabPage.Size = new System.Drawing.Size(466, 395);
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
            this.VisibleSettinsPanel.Controls.Add(this.WardWrapCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.RulerVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.BracketVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.ModifiedLineVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.EolVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.TabVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.FullSpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsColorLabel);
            this.VisibleSettinsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisibleSettinsPanel.Location = new System.Drawing.Point(0, 0);
            this.VisibleSettinsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleSettinsPanel.Name = "VisibleSettinsPanel";
            this.VisibleSettinsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.VisibleSettinsPanel.Size = new System.Drawing.Size(466, 395);
            this.VisibleSettinsPanel.TabIndex = 0;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(15, 23);
            this.Label21.Margin = new System.Windows.Forms.Padding(3);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(100, 23);
            this.Label21.TabIndex = 34;
            this.Label21.Text = "タブ幅";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabWidthNumericUpDown
            // 
            this.TabWidthNumericUpDown.Location = new System.Drawing.Point(121, 23);
            this.TabWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TabWidthNumericUpDown.Name = "TabWidthNumericUpDown";
            this.TabWidthNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.TabWidthNumericUpDown.TabIndex = 35;
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
            this.TabToSpaceCheckBox.Margin = new System.Windows.Forms.Padding(12, 5, 3, 0);
            this.TabToSpaceCheckBox.Name = "TabToSpaceCheckBox";
            this.TabToSpaceCheckBox.Size = new System.Drawing.Size(182, 19);
            this.TabToSpaceCheckBox.TabIndex = 36;
            this.TabToSpaceCheckBox.Text = "タブの代わりにスペースを挿入する";
            this.TabToSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberVisibleCheckBox
            // 
            this.LineNumberVisibleCheckBox.AutoSize = true;
            this.LineNumberVisibleCheckBox.Location = new System.Drawing.Point(15, 80);
            this.LineNumberVisibleCheckBox.Name = "LineNumberVisibleCheckBox";
            this.LineNumberVisibleCheckBox.Size = new System.Drawing.Size(114, 19);
            this.LineNumberVisibleCheckBox.TabIndex = 9;
            this.LineNumberVisibleCheckBox.Text = "行番号を表示する";
            this.LineNumberVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // RulerVisibleCheckBox
            // 
            this.RulerVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.RulerVisibleCheckBox, true);
            this.RulerVisibleCheckBox.Location = new System.Drawing.Point(148, 80);
            this.RulerVisibleCheckBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 0);
            this.RulerVisibleCheckBox.Name = "RulerVisibleCheckBox";
            this.RulerVisibleCheckBox.Size = new System.Drawing.Size(110, 19);
            this.RulerVisibleCheckBox.TabIndex = 10;
            this.RulerVisibleCheckBox.Text = "目盛りを表示する";
            this.RulerVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberBackColorTitleLabel
            // 
            this.LineNumberBackColorTitleLabel.Location = new System.Drawing.Point(30, 102);
            this.LineNumberBackColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 0, 3, 3);
            this.LineNumberBackColorTitleLabel.Name = "LineNumberBackColorTitleLabel";
            this.LineNumberBackColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberBackColorTitleLabel.TabIndex = 24;
            this.LineNumberBackColorTitleLabel.Text = "背景色";
            this.LineNumberBackColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberBackColorButton
            // 
            this.LineNumberBackColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LineNumberBackColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.LineNumberBackColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberBackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorButton.Location = new System.Drawing.Point(121, 102);
            this.LineNumberBackColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LineNumberBackColorButton.Name = "LineNumberBackColorButton";
            this.LineNumberBackColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberBackColorButton.TabIndex = 25;
            this.LineNumberBackColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberBackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberBackColorLabel, true);
            this.LineNumberBackColorLabel.Location = new System.Drawing.Point(177, 102);
            this.LineNumberBackColorLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LineNumberBackColorLabel.Name = "LineNumberBackColorLabel";
            this.LineNumberBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberBackColorLabel.TabIndex = 26;
            this.LineNumberBackColorLabel.Text = "(255, 255, 255)";
            this.LineNumberBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorTitleLabel
            // 
            this.LineNumberForeColorTitleLabel.Location = new System.Drawing.Point(30, 131);
            this.LineNumberForeColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.LineNumberForeColorTitleLabel.Name = "LineNumberForeColorTitleLabel";
            this.LineNumberForeColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberForeColorTitleLabel.TabIndex = 21;
            this.LineNumberForeColorTitleLabel.Text = "テキスト色";
            this.LineNumberForeColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorButton
            // 
            this.LineNumberForeColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LineNumberForeColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.LineNumberForeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberForeColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorButton.Location = new System.Drawing.Point(121, 131);
            this.LineNumberForeColorButton.Name = "LineNumberForeColorButton";
            this.LineNumberForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberForeColorButton.TabIndex = 22;
            this.LineNumberForeColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberForeColorLabel, true);
            this.LineNumberForeColorLabel.Location = new System.Drawing.Point(177, 131);
            this.LineNumberForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LineNumberForeColorLabel.Name = "LineNumberForeColorLabel";
            this.LineNumberForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberForeColorLabel.TabIndex = 23;
            this.LineNumberForeColorLabel.Text = "(255, 255, 255)";
            this.LineNumberForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BracketVisibleCheckBox
            // 
            this.BracketVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.BracketVisibleCheckBox, true);
            this.BracketVisibleCheckBox.Location = new System.Drawing.Point(15, 165);
            this.BracketVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.BracketVisibleCheckBox.Name = "BracketVisibleCheckBox";
            this.BracketVisibleCheckBox.Size = new System.Drawing.Size(169, 19);
            this.BracketVisibleCheckBox.TabIndex = 27;
            this.BracketVisibleCheckBox.Text = "対応する括弧を強調表示する";
            this.BracketVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // ModifiedLineVisibleCheckBox
            // 
            this.ModifiedLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.ModifiedLineVisibleCheckBox, true);
            this.ModifiedLineVisibleCheckBox.Location = new System.Drawing.Point(15, 190);
            this.ModifiedLineVisibleCheckBox.Name = "ModifiedLineVisibleCheckBox";
            this.ModifiedLineVisibleCheckBox.Size = new System.Drawing.Size(156, 19);
            this.ModifiedLineVisibleCheckBox.TabIndex = 14;
            this.ModifiedLineVisibleCheckBox.Text = "修正した行を強調表示する";
            this.ModifiedLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentLineVisibleCheckBox
            // 
            this.CurrentLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentLineVisibleCheckBox, true);
            this.CurrentLineVisibleCheckBox.Location = new System.Drawing.Point(15, 215);
            this.CurrentLineVisibleCheckBox.Name = "CurrentLineVisibleCheckBox";
            this.CurrentLineVisibleCheckBox.Size = new System.Drawing.Size(181, 19);
            this.CurrentLineVisibleCheckBox.TabIndex = 15;
            this.CurrentLineVisibleCheckBox.Text = "カーソルのある行を強調表示する";
            this.CurrentLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentLineColorTitleLabel
            // 
            this.CurrentLineColorTitleLabel.Location = new System.Drawing.Point(30, 238);
            this.CurrentLineColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 0, 3, 3);
            this.CurrentLineColorTitleLabel.Name = "CurrentLineColorTitleLabel";
            this.CurrentLineColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.CurrentLineColorTitleLabel.TabIndex = 40;
            this.CurrentLineColorTitleLabel.Text = "表示色";
            this.CurrentLineColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentLineColorButton
            // 
            this.CurrentLineColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.CurrentLineColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CurrentLineColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.CurrentLineColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentLineColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentLineColorButton.Location = new System.Drawing.Point(121, 238);
            this.CurrentLineColorButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.CurrentLineColorButton.Name = "CurrentLineColorButton";
            this.CurrentLineColorButton.Size = new System.Drawing.Size(50, 23);
            this.CurrentLineColorButton.TabIndex = 41;
            this.CurrentLineColorButton.UseVisualStyleBackColor = false;
            // 
            // CurrentLineColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentLineColorLabel, true);
            this.CurrentLineColorLabel.Location = new System.Drawing.Point(177, 238);
            this.CurrentLineColorLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.CurrentLineColorLabel.Name = "CurrentLineColorLabel";
            this.CurrentLineColorLabel.Size = new System.Drawing.Size(190, 23);
            this.CurrentLineColorLabel.TabIndex = 42;
            this.CurrentLineColorLabel.Text = "(255, 255, 255)";
            this.CurrentLineColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpecialCharsVisibleCheckBox
            // 
            this.SpecialCharsVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCharsVisibleCheckBox, true);
            this.SpecialCharsVisibleCheckBox.Location = new System.Drawing.Point(15, 272);
            this.SpecialCharsVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SpecialCharsVisibleCheckBox.Name = "SpecialCharsVisibleCheckBox";
            this.SpecialCharsVisibleCheckBox.Size = new System.Drawing.Size(126, 19);
            this.SpecialCharsVisibleCheckBox.TabIndex = 16;
            this.SpecialCharsVisibleCheckBox.Text = "特殊文字を表示する";
            this.SpecialCharsVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // EolVisibleCheckBox
            // 
            this.EolVisibleCheckBox.AutoSize = true;
            this.EolVisibleCheckBox.Location = new System.Drawing.Point(32, 297);
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
            this.TabVisibleCheckBox.Location = new System.Drawing.Point(88, 297);
            this.TabVisibleCheckBox.Name = "TabVisibleCheckBox";
            this.TabVisibleCheckBox.Size = new System.Drawing.Size(43, 19);
            this.TabVisibleCheckBox.TabIndex = 18;
            this.TabVisibleCheckBox.Text = "タブ";
            this.TabVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpaceVisibleCheckBox
            // 
            this.SpaceVisibleCheckBox.AutoSize = true;
            this.SpaceVisibleCheckBox.Location = new System.Drawing.Point(137, 297);
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
            this.FullSpaceVisibleCheckBox.Location = new System.Drawing.Point(231, 297);
            this.FullSpaceVisibleCheckBox.Name = "FullSpaceVisibleCheckBox";
            this.FullSpaceVisibleCheckBox.Size = new System.Drawing.Size(88, 19);
            this.FullSpaceVisibleCheckBox.TabIndex = 20;
            this.FullSpaceVisibleCheckBox.Text = "全角スペース";
            this.FullSpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpecialCharsColorTitleLabel
            // 
            this.SpecialCharsColorTitleLabel.Location = new System.Drawing.Point(30, 322);
            this.SpecialCharsColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.SpecialCharsColorTitleLabel.Name = "SpecialCharsColorTitleLabel";
            this.SpecialCharsColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.SpecialCharsColorTitleLabel.TabIndex = 37;
            this.SpecialCharsColorTitleLabel.Text = "表示色";
            this.SpecialCharsColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpecialCharsColorButton
            // 
            this.SpecialCharsColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.SpecialCharsColorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SpecialCharsColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.SpecialCharsColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpecialCharsColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SpecialCharsColorButton.Location = new System.Drawing.Point(121, 322);
            this.SpecialCharsColorButton.Name = "SpecialCharsColorButton";
            this.SpecialCharsColorButton.Size = new System.Drawing.Size(50, 23);
            this.SpecialCharsColorButton.TabIndex = 38;
            this.SpecialCharsColorButton.UseVisualStyleBackColor = false;
            // 
            // SpecialCharsColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCharsColorLabel, true);
            this.SpecialCharsColorLabel.Location = new System.Drawing.Point(177, 322);
            this.SpecialCharsColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SpecialCharsColorLabel.Name = "SpecialCharsColorLabel";
            this.SpecialCharsColorLabel.Size = new System.Drawing.Size(190, 23);
            this.SpecialCharsColorLabel.TabIndex = 39;
            this.SpecialCharsColorLabel.Text = "(255, 255, 255)";
            this.SpecialCharsColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VersionTabPage
            // 
            this.VersionTabPage.Location = new System.Drawing.Point(4, 24);
            this.VersionTabPage.Name = "VersionTabPage";
            this.VersionTabPage.Size = new System.Drawing.Size(466, 395);
            this.VersionTabPage.TabIndex = 2;
            this.VersionTabPage.Text = "CubeNote について";
            this.VersionTabPage.UseVisualStyleBackColor = true;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ResetButton);
            this.ButtonsPanel.Controls.Add(this.ApplyButton);
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.RunButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 468);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ButtonsPanel.Size = new System.Drawing.Size(498, 60);
            this.ButtonsPanel.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(358, 13);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(120, 30);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "初期値にリセット";
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(252, 13);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(100, 30);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "適用";
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(146, 13);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "キャンセル";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(20, 13);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(120, 30);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "OK";
            // 
            // WardWrapCheckBox
            // 
            this.WardWrapCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.WardWrapCheckBox, true);
            this.WardWrapCheckBox.Location = new System.Drawing.Point(15, 55);
            this.WardWrapCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.WardWrapCheckBox.Name = "WardWrapCheckBox";
            this.WardWrapCheckBox.Size = new System.Drawing.Size(147, 19);
            this.WardWrapCheckBox.TabIndex = 43;
            this.WardWrapCheckBox.Text = "テキストを右端で折り返す";
            this.WardWrapCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.RunButton;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(500, 530);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(500, 360);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Sizable = true;
            this.LayoutPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralSettingsPanel.ResumeLayout(false);
            this.GeneralSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).EndInit();
            this.VisibleTabPage.ResumeLayout(false);
            this.VisibleSettinsPanel.ResumeLayout(false);
            this.VisibleSettinsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage VisibleTabPage;
        private System.Windows.Forms.TabPage VersionTabPage;
        private Cube.Forms.FlowLayoutPanel ButtonsPanel;
        private Cube.Forms.Button ApplyButton;
        private Cube.Forms.Button ExitButton;
        private Cube.Forms.Button RunButton;
        private System.Windows.Forms.FlowLayoutPanel GeneralSettingsPanel;
        private System.Windows.Forms.Label Label11;
        private Forms.Button FontButton;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Label Label12;
        private Forms.Button BackColorButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.Label Label13;
        private Forms.Button ForeColorButton;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label Label14;
        private Forms.Button HighlightBackColorButton;
        private System.Windows.Forms.Label HighlightBackColorLabel;
        private System.Windows.Forms.Label Label15;
        private Forms.Button HighlightForeColorButton;
        private System.Windows.Forms.Label HighlightForeColorLabel;
        private System.Windows.Forms.Label Label31;
        private System.Windows.Forms.NumericUpDown AutoSaveTimeNumericUpDown;
        private System.Windows.Forms.Label Label32;
        private System.Windows.Forms.CheckBox RemoveWarningCheckBox;
        private System.Windows.Forms.FlowLayoutPanel VisibleSettinsPanel;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.NumericUpDown TabWidthNumericUpDown;
        private System.Windows.Forms.CheckBox TabToSpaceCheckBox;
        private System.Windows.Forms.CheckBox LineNumberVisibleCheckBox;
        private System.Windows.Forms.CheckBox RulerVisibleCheckBox;
        private System.Windows.Forms.Label LineNumberBackColorTitleLabel;
        private Forms.Button LineNumberBackColorButton;
        private System.Windows.Forms.Label LineNumberBackColorLabel;
        private System.Windows.Forms.Label LineNumberForeColorTitleLabel;
        private Forms.Button LineNumberForeColorButton;
        private System.Windows.Forms.Label LineNumberForeColorLabel;
        private System.Windows.Forms.CheckBox BracketVisibleCheckBox;
        private System.Windows.Forms.CheckBox CurrentLineVisibleCheckBox;
        private System.Windows.Forms.Label CurrentLineColorTitleLabel;
        private Forms.Button CurrentLineColorButton;
        private System.Windows.Forms.Label CurrentLineColorLabel;
        private System.Windows.Forms.CheckBox ModifiedLineVisibleCheckBox;
        private System.Windows.Forms.CheckBox SpecialCharsVisibleCheckBox;
        private System.Windows.Forms.CheckBox EolVisibleCheckBox;
        private System.Windows.Forms.CheckBox TabVisibleCheckBox;
        private System.Windows.Forms.CheckBox SpaceVisibleCheckBox;
        private System.Windows.Forms.CheckBox FullSpaceVisibleCheckBox;
        private System.Windows.Forms.Label SpecialCharsColorTitleLabel;
        private Forms.Button SpecialCharsColorButton;
        private System.Windows.Forms.Label SpecialCharsColorLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox WardWrapCheckBox;
    }
}