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
            this.BackColorButton = new System.Windows.Forms.Button();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.ForeColorButton = new System.Windows.Forms.Button();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.FontButton = new System.Windows.Forms.Button();
            this.FontLabel = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.TabNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TabToSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.LineNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.NumberBackColorButton = new System.Windows.Forms.Button();
            this.NumberBackColor = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.NumberForeColorButton = new System.Windows.Forms.Button();
            this.NumberForeColorLabel = new System.Windows.Forms.Label();
            this.RulerCheckBox = new System.Windows.Forms.CheckBox();
            this.ModifyCheckBox = new System.Windows.Forms.CheckBox();
            this.CurrentCheckBox = new System.Windows.Forms.CheckBox();
            this.SpecialCheckBox = new System.Windows.Forms.CheckBox();
            this.EolCheckBox = new System.Windows.Forms.CheckBox();
            this.TabCheckBox = new System.Windows.Forms.CheckBox();
            this.SpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.FullSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.VersionTabPage = new System.Windows.Forms.TabPage();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.LayoutPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.VisibleTabPage.SuspendLayout();
            this.VisibleSettinsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabNumericUpDown)).BeginInit();
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
            this.LayoutPanel.Size = new System.Drawing.Size(498, 518);
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
            this.TabControl.Size = new System.Drawing.Size(474, 413);
            this.TabControl.TabIndex = 1;
            // 
            // VisibleTabPage
            // 
            this.VisibleTabPage.Controls.Add(this.VisibleSettinsPanel);
            this.VisibleTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisibleTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleTabPage.Name = "VisibleTabPage";
            this.VisibleTabPage.Size = new System.Drawing.Size(466, 385);
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
            this.VisibleSettinsPanel.Controls.Add(this.TabNumericUpDown);
            this.VisibleSettinsPanel.Controls.Add(this.TabToSpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.Label15);
            this.VisibleSettinsPanel.Controls.Add(this.NumberBackColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.NumberBackColor);
            this.VisibleSettinsPanel.Controls.Add(this.Label16);
            this.VisibleSettinsPanel.Controls.Add(this.NumberForeColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.NumberForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.RulerCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.ModifyCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.EolCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.TabCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.FullSpaceCheckBox);
            this.VisibleSettinsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisibleSettinsPanel.Location = new System.Drawing.Point(0, 0);
            this.VisibleSettinsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleSettinsPanel.Name = "VisibleSettinsPanel";
            this.VisibleSettinsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.VisibleSettinsPanel.Size = new System.Drawing.Size(466, 385);
            this.VisibleSettinsPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 23);
            this.Label11.Margin = new System.Windows.Forms.Padding(3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(80, 23);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "背景色";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackColorButton
            // 
            this.BackColorButton.Location = new System.Drawing.Point(101, 23);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(50, 23);
            this.BackColorButton.TabIndex = 7;
            this.BackColorButton.UseVisualStyleBackColor = true;
            // 
            // BackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.BackColorLabel, true);
            this.BackColorLabel.Location = new System.Drawing.Point(157, 23);
            this.BackColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(250, 23);
            this.BackColorLabel.TabIndex = 8;
            this.BackColorLabel.Text = "(255, 255, 255)";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 52);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(80, 23);
            this.Label12.TabIndex = 3;
            this.Label12.Text = "テキストの色";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForeColorButton
            // 
            this.ForeColorButton.Location = new System.Drawing.Point(101, 52);
            this.ForeColorButton.Name = "ForeColorButton";
            this.ForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.ForeColorButton.TabIndex = 4;
            this.ForeColorButton.UseVisualStyleBackColor = true;
            // 
            // ForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.ForeColorLabel, true);
            this.ForeColorLabel.Location = new System.Drawing.Point(157, 52);
            this.ForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(250, 23);
            this.ForeColorLabel.TabIndex = 5;
            this.ForeColorLabel.Text = "(255, 255, 255)";
            this.ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(15, 81);
            this.Label13.Margin = new System.Windows.Forms.Padding(3);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(80, 23);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "フォント";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontButton
            // 
            this.FontButton.Location = new System.Drawing.Point(101, 81);
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
            this.FontLabel.Location = new System.Drawing.Point(157, 81);
            this.FontLabel.Margin = new System.Windows.Forms.Padding(3);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(250, 23);
            this.FontLabel.TabIndex = 1;
            this.FontLabel.Text = "(メイリオ, 11pt)";
            this.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(15, 110);
            this.Label14.Margin = new System.Windows.Forms.Padding(3);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(80, 23);
            this.Label14.TabIndex = 11;
            this.Label14.Text = "タブ幅";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabNumericUpDown
            // 
            this.TabNumericUpDown.Location = new System.Drawing.Point(101, 110);
            this.TabNumericUpDown.Name = "TabNumericUpDown";
            this.TabNumericUpDown.Size = new System.Drawing.Size(70, 23);
            this.TabNumericUpDown.TabIndex = 12;
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
            // LineNumberCheckBox
            // 
            this.LineNumberCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.LineNumberCheckBox, true);
            this.LineNumberCheckBox.Location = new System.Drawing.Point(15, 144);
            this.LineNumberCheckBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.LineNumberCheckBox.Name = "LineNumberCheckBox";
            this.LineNumberCheckBox.Size = new System.Drawing.Size(114, 19);
            this.LineNumberCheckBox.TabIndex = 9;
            this.LineNumberCheckBox.Text = "行番号を表示する";
            this.LineNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // Label15
            // 
            this.Label15.Location = new System.Drawing.Point(40, 168);
            this.Label15.Margin = new System.Windows.Forms.Padding(28, 3, 3, 3);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(80, 23);
            this.Label15.TabIndex = 24;
            this.Label15.Text = "背景色";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumberBackColorButton
            // 
            this.NumberBackColorButton.Location = new System.Drawing.Point(126, 168);
            this.NumberBackColorButton.Name = "NumberBackColorButton";
            this.NumberBackColorButton.Size = new System.Drawing.Size(50, 23);
            this.NumberBackColorButton.TabIndex = 25;
            this.NumberBackColorButton.UseVisualStyleBackColor = true;
            // 
            // NumberBackColor
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.NumberBackColor, true);
            this.NumberBackColor.Location = new System.Drawing.Point(182, 168);
            this.NumberBackColor.Margin = new System.Windows.Forms.Padding(3);
            this.NumberBackColor.Name = "NumberBackColor";
            this.NumberBackColor.Size = new System.Drawing.Size(230, 23);
            this.NumberBackColor.TabIndex = 26;
            this.NumberBackColor.Text = "(255, 255, 255)";
            this.NumberBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label16
            // 
            this.Label16.Location = new System.Drawing.Point(40, 197);
            this.Label16.Margin = new System.Windows.Forms.Padding(28, 3, 3, 3);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(80, 23);
            this.Label16.TabIndex = 21;
            this.Label16.Text = "行番号の色";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumberForeColorButton
            // 
            this.NumberForeColorButton.Location = new System.Drawing.Point(126, 197);
            this.NumberForeColorButton.Name = "NumberForeColorButton";
            this.NumberForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.NumberForeColorButton.TabIndex = 22;
            this.NumberForeColorButton.UseVisualStyleBackColor = true;
            // 
            // NumberForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.NumberForeColorLabel, true);
            this.NumberForeColorLabel.Location = new System.Drawing.Point(182, 197);
            this.NumberForeColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.NumberForeColorLabel.Name = "NumberForeColorLabel";
            this.NumberForeColorLabel.Size = new System.Drawing.Size(230, 23);
            this.NumberForeColorLabel.TabIndex = 23;
            this.NumberForeColorLabel.Text = "(255, 255, 255)";
            this.NumberForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RulerCheckBox
            // 
            this.RulerCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.RulerCheckBox, true);
            this.RulerCheckBox.Location = new System.Drawing.Point(15, 231);
            this.RulerCheckBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.RulerCheckBox.Name = "RulerCheckBox";
            this.RulerCheckBox.Size = new System.Drawing.Size(116, 19);
            this.RulerCheckBox.TabIndex = 10;
            this.RulerCheckBox.Text = "ルーラーを表示する";
            this.RulerCheckBox.UseVisualStyleBackColor = true;
            // 
            // ModifyCheckBox
            // 
            this.ModifyCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.ModifyCheckBox, true);
            this.ModifyCheckBox.Location = new System.Drawing.Point(15, 256);
            this.ModifyCheckBox.Name = "ModifyCheckBox";
            this.ModifyCheckBox.Size = new System.Drawing.Size(132, 19);
            this.ModifyCheckBox.TabIndex = 14;
            this.ModifyCheckBox.Text = "修正した行を表示する";
            this.ModifyCheckBox.UseVisualStyleBackColor = true;
            // 
            // CurrentCheckBox
            // 
            this.CurrentCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.CurrentCheckBox, true);
            this.CurrentCheckBox.Location = new System.Drawing.Point(15, 281);
            this.CurrentCheckBox.Name = "CurrentCheckBox";
            this.CurrentCheckBox.Size = new System.Drawing.Size(148, 19);
            this.CurrentCheckBox.TabIndex = 15;
            this.CurrentCheckBox.Text = "現在の行を強調表示する";
            this.CurrentCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpecialCheckBox
            // 
            this.SpecialCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.SpecialCheckBox, true);
            this.SpecialCheckBox.Location = new System.Drawing.Point(15, 306);
            this.SpecialCheckBox.Name = "SpecialCheckBox";
            this.SpecialCheckBox.Size = new System.Drawing.Size(126, 19);
            this.SpecialCheckBox.TabIndex = 16;
            this.SpecialCheckBox.Text = "特殊文字を表示する";
            this.SpecialCheckBox.UseVisualStyleBackColor = true;
            // 
            // EolCheckBox
            // 
            this.EolCheckBox.AutoSize = true;
            this.EolCheckBox.Location = new System.Drawing.Point(40, 331);
            this.EolCheckBox.Margin = new System.Windows.Forms.Padding(28, 3, 3, 3);
            this.EolCheckBox.Name = "EolCheckBox";
            this.EolCheckBox.Size = new System.Drawing.Size(50, 19);
            this.EolCheckBox.TabIndex = 17;
            this.EolCheckBox.Text = "改行";
            this.EolCheckBox.UseVisualStyleBackColor = true;
            // 
            // TabCheckBox
            // 
            this.TabCheckBox.AutoSize = true;
            this.TabCheckBox.Location = new System.Drawing.Point(96, 331);
            this.TabCheckBox.Name = "TabCheckBox";
            this.TabCheckBox.Size = new System.Drawing.Size(43, 19);
            this.TabCheckBox.TabIndex = 18;
            this.TabCheckBox.Text = "タブ";
            this.TabCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpaceCheckBox
            // 
            this.SpaceCheckBox.AutoSize = true;
            this.SpaceCheckBox.Location = new System.Drawing.Point(145, 331);
            this.SpaceCheckBox.Name = "SpaceCheckBox";
            this.SpaceCheckBox.Size = new System.Drawing.Size(88, 19);
            this.SpaceCheckBox.TabIndex = 19;
            this.SpaceCheckBox.Text = "半角スペース";
            this.SpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // FullSpaceCheckBox
            // 
            this.FullSpaceCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.FullSpaceCheckBox, true);
            this.FullSpaceCheckBox.Location = new System.Drawing.Point(239, 331);
            this.FullSpaceCheckBox.Name = "FullSpaceCheckBox";
            this.FullSpaceCheckBox.Size = new System.Drawing.Size(88, 19);
            this.FullSpaceCheckBox.TabIndex = 20;
            this.FullSpaceCheckBox.Text = "全角スペース";
            this.FullSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Size = new System.Drawing.Size(466, 385);
            this.GeneralTabPage.TabIndex = 1;
            this.GeneralTabPage.Text = "その他";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // VersionTabPage
            // 
            this.VersionTabPage.Location = new System.Drawing.Point(4, 24);
            this.VersionTabPage.Name = "VersionTabPage";
            this.VersionTabPage.Size = new System.Drawing.Size(466, 385);
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
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 458);
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
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(280, 13);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(154, 13);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(120, 30);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "OK";
            this.RunButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.RunButton;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(500, 520);
            this.Controls.Add(this.LayoutPanel);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.LayoutPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.VisibleTabPage.ResumeLayout(false);
            this.VisibleSettinsPanel.ResumeLayout(false);
            this.VisibleSettinsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabNumericUpDown)).EndInit();
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
        private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.FlowLayoutPanel VisibleSettinsPanel;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Button ForeColorButton;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Button BackColorButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.CheckBox LineNumberCheckBox;
        private System.Windows.Forms.CheckBox RulerCheckBox;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.NumericUpDown TabNumericUpDown;
        private System.Windows.Forms.CheckBox TabToSpaceCheckBox;
        private System.Windows.Forms.CheckBox ModifyCheckBox;
        private System.Windows.Forms.CheckBox CurrentCheckBox;
        private System.Windows.Forms.CheckBox SpecialCheckBox;
        private System.Windows.Forms.CheckBox EolCheckBox;
        private System.Windows.Forms.CheckBox TabCheckBox;
        private System.Windows.Forms.CheckBox SpaceCheckBox;
        private System.Windows.Forms.CheckBox FullSpaceCheckBox;
        private System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Button NumberBackColorButton;
        private System.Windows.Forms.Label NumberBackColor;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Button NumberForeColorButton;
        private System.Windows.Forms.Label NumberForeColorLabel;
    }
}