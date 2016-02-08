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
            this.VisibleTabPage = new System.Windows.Forms.TabPage();
            this.VisibleSettinsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label11 = new System.Windows.Forms.Label();
            this.BackColorButton = new Cube.Forms.Button();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.ForeColorButton = new Cube.Forms.Button();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.FontButton = new Cube.Forms.Button();
            this.FontLabel = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
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
            this.SpecialCharsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.EolVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.TabVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.SpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.FullSpaceVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.ModifiedLineVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.GeneralSettingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label21 = new System.Windows.Forms.Label();
            this.AutoSaveTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label22 = new System.Windows.Forms.Label();
            this.RemoveWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.VersionTabPage = new System.Windows.Forms.TabPage();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ApplyButton = new Cube.Forms.Button();
            this.ExitButton = new Cube.Forms.Button();
            this.RunButton = new Cube.Forms.Button();
            this.LayoutPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.VisibleTabPage.SuspendLayout();
            this.VisibleSettinsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).BeginInit();
            this.GeneralTabPage.SuspendLayout();
            this.GeneralSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).BeginInit();
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
            this.TabControl.Controls.Add(this.VisibleTabPage);
            this.TabControl.Controls.Add(this.GeneralTabPage);
            this.TabControl.Controls.Add(this.VersionTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(12, 42);
            this.TabControl.Margin = new System.Windows.Forms.Padding(12, 12, 12, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(474, 423);
            this.TabControl.TabIndex = 1;
            // 
            // VisibleTabPage
            // 
            this.VisibleTabPage.Controls.Add(this.VisibleSettinsPanel);
            this.VisibleTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisibleTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleTabPage.Name = "VisibleTabPage";
            this.VisibleTabPage.Size = new System.Drawing.Size(466, 395);
            this.VisibleTabPage.TabIndex = 0;
            this.VisibleTabPage.Text = "表 示";
            this.VisibleTabPage.UseVisualStyleBackColor = true;
            // 
            // VisibleSettinsPanel
            // 
            this.VisibleSettinsPanel.AutoScroll = true;
            this.VisibleSettinsPanel.Controls.Add(this.Label11);
            this.VisibleSettinsPanel.Controls.Add(this.BackColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.BackColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label12);
            this.VisibleSettinsPanel.Controls.Add(this.ForeColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.ForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label13);
            this.VisibleSettinsPanel.Controls.Add(this.FontButton);
            this.VisibleSettinsPanel.Controls.Add(this.FontLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label14);
            this.VisibleSettinsPanel.Controls.Add(this.TabWidthNumericUpDown);
            this.VisibleSettinsPanel.Controls.Add(this.TabToSpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.RulerVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberBackColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorTitleLabel);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCharsVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.EolVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.TabVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.FullSpaceVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentLineVisibleCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.ModifiedLineVisibleCheckBox);
            this.VisibleSettinsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisibleSettinsPanel.Location = new System.Drawing.Point(0, 0);
            this.VisibleSettinsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleSettinsPanel.Name = "VisibleSettinsPanel";
            this.VisibleSettinsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.VisibleSettinsPanel.Size = new System.Drawing.Size(466, 395);
            this.VisibleSettinsPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 23);
            this.Label11.Margin = new System.Windows.Forms.Padding(3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(100, 23);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "背景色";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackColorButton
            // 
            this.BackColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.BackColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BackColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BackColorButton.Location = new System.Drawing.Point(121, 23);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(50, 23);
            this.BackColorButton.TabIndex = 7;
            this.BackColorButton.UseVisualStyleBackColor = false;
            // 
            // BackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.BackColorLabel, true);
            this.BackColorLabel.Location = new System.Drawing.Point(177, 23);
            this.BackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.BackColorLabel.TabIndex = 8;
            this.BackColorLabel.Text = "(255, 255, 255)";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 52);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(100, 23);
            this.Label12.TabIndex = 3;
            this.Label12.Text = "テキストの色";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForeColorButton
            // 
            this.ForeColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.ForeColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ForeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForeColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ForeColorButton.Location = new System.Drawing.Point(121, 52);
            this.ForeColorButton.Name = "ForeColorButton";
            this.ForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.ForeColorButton.TabIndex = 4;
            this.ForeColorButton.UseVisualStyleBackColor = false;
            // 
            // ForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.ForeColorLabel, true);
            this.ForeColorLabel.Location = new System.Drawing.Point(177, 52);
            this.ForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.ForeColorLabel.TabIndex = 5;
            this.ForeColorLabel.Text = "(255, 255, 255)";
            this.ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(15, 81);
            this.Label13.Margin = new System.Windows.Forms.Padding(3);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(100, 23);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "フォント";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontButton
            // 
            this.FontButton.Location = new System.Drawing.Point(121, 81);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(50, 23);
            this.FontButton.TabIndex = 2;
            this.FontButton.Text = "...";
            this.FontButton.UseVisualStyleBackColor = true;
            // 
            // FontLabel
            // 
            this.FontLabel.AutoEllipsis = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.FontLabel, true);
            this.FontLabel.Location = new System.Drawing.Point(177, 81);
            this.FontLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(190, 23);
            this.FontLabel.TabIndex = 1;
            this.FontLabel.Text = "(メイリオ, 11pt)";
            this.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(15, 110);
            this.Label14.Margin = new System.Windows.Forms.Padding(3);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(100, 23);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "タブ幅";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabWidthNumericUpDown
            // 
            this.TabWidthNumericUpDown.Location = new System.Drawing.Point(121, 110);
            this.TabWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TabWidthNumericUpDown.Name = "TabWidthNumericUpDown";
            this.TabWidthNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.TabWidthNumericUpDown.TabIndex = 12;
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
            this.TabToSpaceCheckBox.Location = new System.Drawing.Point(186, 112);
            this.TabToSpaceCheckBox.Margin = new System.Windows.Forms.Padding(12, 5, 3, 0);
            this.TabToSpaceCheckBox.Name = "TabToSpaceCheckBox";
            this.TabToSpaceCheckBox.Size = new System.Drawing.Size(182, 19);
            this.TabToSpaceCheckBox.TabIndex = 13;
            this.TabToSpaceCheckBox.Text = "タブの代わりにスペースを挿入する";
            this.TabToSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberVisibleCheckBox
            // 
            this.LineNumberVisibleCheckBox.AutoSize = true;
            this.LineNumberVisibleCheckBox.Location = new System.Drawing.Point(15, 152);
            this.LineNumberVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
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
            this.RulerVisibleCheckBox.Location = new System.Drawing.Point(148, 152);
            this.RulerVisibleCheckBox.Margin = new System.Windows.Forms.Padding(16, 16, 3, 0);
            this.RulerVisibleCheckBox.Name = "RulerVisibleCheckBox";
            this.RulerVisibleCheckBox.Size = new System.Drawing.Size(110, 19);
            this.RulerVisibleCheckBox.TabIndex = 10;
            this.RulerVisibleCheckBox.Text = "目盛りを表示する";
            this.RulerVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // LineNumberBackColorTitleLabel
            // 
            this.LineNumberBackColorTitleLabel.Location = new System.Drawing.Point(30, 177);
            this.LineNumberBackColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.LineNumberBackColorTitleLabel.Name = "LineNumberBackColorTitleLabel";
            this.LineNumberBackColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberBackColorTitleLabel.TabIndex = 24;
            this.LineNumberBackColorTitleLabel.Text = "背景色";
            this.LineNumberBackColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberBackColorButton
            // 
            this.LineNumberBackColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.LineNumberBackColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberBackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberBackColorButton.Location = new System.Drawing.Point(121, 177);
            this.LineNumberBackColorButton.Name = "LineNumberBackColorButton";
            this.LineNumberBackColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberBackColorButton.TabIndex = 25;
            this.LineNumberBackColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberBackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberBackColorLabel, true);
            this.LineNumberBackColorLabel.Location = new System.Drawing.Point(177, 177);
            this.LineNumberBackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LineNumberBackColorLabel.Name = "LineNumberBackColorLabel";
            this.LineNumberBackColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberBackColorLabel.TabIndex = 26;
            this.LineNumberBackColorLabel.Text = "(255, 255, 255)";
            this.LineNumberBackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorTitleLabel
            // 
            this.LineNumberForeColorTitleLabel.Location = new System.Drawing.Point(30, 206);
            this.LineNumberForeColorTitleLabel.Margin = new System.Windows.Forms.Padding(18, 3, 3, 3);
            this.LineNumberForeColorTitleLabel.Name = "LineNumberForeColorTitleLabel";
            this.LineNumberForeColorTitleLabel.Size = new System.Drawing.Size(85, 23);
            this.LineNumberForeColorTitleLabel.TabIndex = 21;
            this.LineNumberForeColorTitleLabel.Text = "行番号等の色";
            this.LineNumberForeColorTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumberForeColorButton
            // 
            this.LineNumberForeColorButton.BackColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.LineNumberForeColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineNumberForeColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LineNumberForeColorButton.Location = new System.Drawing.Point(121, 206);
            this.LineNumberForeColorButton.Name = "LineNumberForeColorButton";
            this.LineNumberForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.LineNumberForeColorButton.TabIndex = 22;
            this.LineNumberForeColorButton.UseVisualStyleBackColor = false;
            // 
            // LineNumberForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberForeColorLabel, true);
            this.LineNumberForeColorLabel.Location = new System.Drawing.Point(177, 206);
            this.LineNumberForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LineNumberForeColorLabel.Name = "LineNumberForeColorLabel";
            this.LineNumberForeColorLabel.Size = new System.Drawing.Size(190, 23);
            this.LineNumberForeColorLabel.TabIndex = 23;
            this.LineNumberForeColorLabel.Text = "(255, 255, 255)";
            this.LineNumberForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpecialCharsVisibleCheckBox
            // 
            this.SpecialCharsVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCharsVisibleCheckBox, true);
            this.SpecialCharsVisibleCheckBox.Location = new System.Drawing.Point(15, 240);
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
            this.EolVisibleCheckBox.Location = new System.Drawing.Point(32, 268);
            this.EolVisibleCheckBox.Margin = new System.Windows.Forms.Padding(20, 6, 3, 3);
            this.EolVisibleCheckBox.Name = "EolVisibleCheckBox";
            this.EolVisibleCheckBox.Size = new System.Drawing.Size(50, 19);
            this.EolVisibleCheckBox.TabIndex = 17;
            this.EolVisibleCheckBox.Text = "改行";
            this.EolVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // TabVisibleCheckBox
            // 
            this.TabVisibleCheckBox.AutoSize = true;
            this.TabVisibleCheckBox.Location = new System.Drawing.Point(88, 268);
            this.TabVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TabVisibleCheckBox.Name = "TabVisibleCheckBox";
            this.TabVisibleCheckBox.Size = new System.Drawing.Size(43, 19);
            this.TabVisibleCheckBox.TabIndex = 18;
            this.TabVisibleCheckBox.Text = "タブ";
            this.TabVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpaceVisibleCheckBox
            // 
            this.SpaceVisibleCheckBox.AutoSize = true;
            this.SpaceVisibleCheckBox.Location = new System.Drawing.Point(137, 268);
            this.SpaceVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
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
            this.FullSpaceVisibleCheckBox.Location = new System.Drawing.Point(231, 268);
            this.FullSpaceVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.FullSpaceVisibleCheckBox.Name = "FullSpaceVisibleCheckBox";
            this.FullSpaceVisibleCheckBox.Size = new System.Drawing.Size(88, 19);
            this.FullSpaceVisibleCheckBox.TabIndex = 20;
            this.FullSpaceVisibleCheckBox.Text = "全角スペース";
            this.FullSpaceVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentLineVisibleCheckBox
            // 
            this.CurrentLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentLineVisibleCheckBox, true);
            this.CurrentLineVisibleCheckBox.Location = new System.Drawing.Point(15, 298);
            this.CurrentLineVisibleCheckBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.CurrentLineVisibleCheckBox.Name = "CurrentLineVisibleCheckBox";
            this.CurrentLineVisibleCheckBox.Size = new System.Drawing.Size(181, 19);
            this.CurrentLineVisibleCheckBox.TabIndex = 15;
            this.CurrentLineVisibleCheckBox.Text = "カーソルのある行を強調表示する";
            this.CurrentLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // ModifiedLineVisibleCheckBox
            // 
            this.ModifiedLineVisibleCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.ModifiedLineVisibleCheckBox, true);
            this.ModifiedLineVisibleCheckBox.Location = new System.Drawing.Point(15, 323);
            this.ModifiedLineVisibleCheckBox.Name = "ModifiedLineVisibleCheckBox";
            this.ModifiedLineVisibleCheckBox.Size = new System.Drawing.Size(156, 19);
            this.ModifiedLineVisibleCheckBox.TabIndex = 14;
            this.ModifiedLineVisibleCheckBox.Text = "修正した行を強調表示する";
            this.ModifiedLineVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.GeneralSettingsPanel);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Size = new System.Drawing.Size(466, 395);
            this.GeneralTabPage.TabIndex = 1;
            this.GeneralTabPage.Text = "その他";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // GeneralSettingsPanel
            // 
            this.GeneralSettingsPanel.AutoScroll = true;
            this.GeneralSettingsPanel.Controls.Add(this.Label21);
            this.GeneralSettingsPanel.Controls.Add(this.AutoSaveTimeNumericUpDown);
            this.GeneralSettingsPanel.Controls.Add(this.Label22);
            this.GeneralSettingsPanel.Controls.Add(this.RemoveWarningCheckBox);
            this.GeneralSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.GeneralSettingsPanel.Name = "GeneralSettingsPanel";
            this.GeneralSettingsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.GeneralSettingsPanel.Size = new System.Drawing.Size(466, 395);
            this.GeneralSettingsPanel.TabIndex = 0;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(15, 23);
            this.Label21.Margin = new System.Windows.Forms.Padding(3);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(100, 23);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "自動保存間隔";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutoSaveTimeNumericUpDown
            // 
            this.AutoSaveTimeNumericUpDown.Location = new System.Drawing.Point(121, 23);
            this.AutoSaveTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AutoSaveTimeNumericUpDown.Name = "AutoSaveTimeNumericUpDown";
            this.AutoSaveTimeNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.AutoSaveTimeNumericUpDown.TabIndex = 1;
            this.AutoSaveTimeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Label22
            // 
            this.GeneralSettingsPanel.SetFlowBreak(this.Label22, true);
            this.Label22.Location = new System.Drawing.Point(207, 23);
            this.Label22.Margin = new System.Windows.Forms.Padding(3);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(100, 23);
            this.Label22.TabIndex = 2;
            this.Label22.Text = "秒";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RemoveWarningCheckBox
            // 
            this.RemoveWarningCheckBox.AutoSize = true;
            this.RemoveWarningCheckBox.Location = new System.Drawing.Point(15, 55);
            this.RemoveWarningCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.RemoveWarningCheckBox.Name = "RemoveWarningCheckBox";
            this.RemoveWarningCheckBox.Size = new System.Drawing.Size(218, 19);
            this.RemoveWarningCheckBox.TabIndex = 3;
            this.RemoveWarningCheckBox.Text = "ノート削除時に警告メッセージを表示する";
            this.RemoveWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // VersionTabPage
            // 
            this.VersionTabPage.Location = new System.Drawing.Point(4, 24);
            this.VersionTabPage.Name = "VersionTabPage";
            this.VersionTabPage.Size = new System.Drawing.Size(466, 395);
            this.VersionTabPage.TabIndex = 2;
            this.VersionTabPage.Text = "バージョン情報";
            this.VersionTabPage.UseVisualStyleBackColor = true;
            // 
            // ButtonsPanel
            // 
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
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(386, 13);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(100, 30);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "適用";
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(280, 13);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "キャンセル";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(154, 13);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(120, 30);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "OK";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.RunButton;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(500, 530);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(430, 360);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Sizable = true;
            this.LayoutPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.VisibleTabPage.ResumeLayout(false);
            this.VisibleSettinsPanel.ResumeLayout(false);
            this.VisibleSettinsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).EndInit();
            this.GeneralTabPage.ResumeLayout(false);
            this.GeneralSettingsPanel.ResumeLayout(false);
            this.GeneralSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoSaveTimeNumericUpDown)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage VisibleTabPage;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage VersionTabPage;
        private Cube.Forms.FlowLayoutPanel ButtonsPanel;
        private Cube.Forms.Button ApplyButton;
        private Cube.Forms.Button ExitButton;
        private Cube.Forms.Button RunButton;
        private System.Windows.Forms.FlowLayoutPanel VisibleSettinsPanel;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.Label FontLabel;
        private Cube.Forms.Button FontButton;
        private System.Windows.Forms.Label Label12;
        private Cube.Forms.Button ForeColorButton;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label Label11;
        private Cube.Forms.Button BackColorButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.CheckBox LineNumberVisibleCheckBox;
        private System.Windows.Forms.CheckBox RulerVisibleCheckBox;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.NumericUpDown TabWidthNumericUpDown;
        private System.Windows.Forms.CheckBox TabToSpaceCheckBox;
        private System.Windows.Forms.CheckBox ModifiedLineVisibleCheckBox;
        private System.Windows.Forms.CheckBox CurrentLineVisibleCheckBox;
        private System.Windows.Forms.CheckBox SpecialCharsVisibleCheckBox;
        private System.Windows.Forms.CheckBox EolVisibleCheckBox;
        private System.Windows.Forms.CheckBox TabVisibleCheckBox;
        private System.Windows.Forms.CheckBox SpaceVisibleCheckBox;
        private System.Windows.Forms.CheckBox FullSpaceVisibleCheckBox;
        private System.Windows.Forms.Label LineNumberBackColorTitleLabel;
        private Cube.Forms.Button LineNumberBackColorButton;
        private System.Windows.Forms.Label LineNumberBackColorLabel;
        private System.Windows.Forms.Label LineNumberForeColorTitleLabel;
        private Cube.Forms.Button LineNumberForeColorButton;
        private System.Windows.Forms.Label LineNumberForeColorLabel;
        private System.Windows.Forms.FlowLayoutPanel GeneralSettingsPanel;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.NumericUpDown AutoSaveTimeNumericUpDown;
        private System.Windows.Forms.Label Label22;
        private System.Windows.Forms.CheckBox RemoveWarningCheckBox;
    }
}