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
            this.Label1 = new System.Windows.Forms.Label();
            this.FontButton = new System.Windows.Forms.Button();
            this.FontLabel = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ForeColorButton = new System.Windows.Forms.Button();
            this.ForeColorLabel = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.BackColorButton = new System.Windows.Forms.Button();
            this.BackColorLabel = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.TabNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TabToSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.LineNumberCheckBox = new System.Windows.Forms.CheckBox();
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
            this.LayoutPanel.Size = new System.Drawing.Size(498, 498);
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
            this.TabControl.Size = new System.Drawing.Size(474, 393);
            this.TabControl.TabIndex = 1;
            // 
            // VisibleTabPage
            // 
            this.VisibleTabPage.Controls.Add(this.VisibleSettinsPanel);
            this.VisibleTabPage.Location = new System.Drawing.Point(4, 24);
            this.VisibleTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleTabPage.Name = "VisibleTabPage";
            this.VisibleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VisibleTabPage.Size = new System.Drawing.Size(466, 365);
            this.VisibleTabPage.TabIndex = 0;
            this.VisibleTabPage.Text = "表示";
            this.VisibleTabPage.UseVisualStyleBackColor = true;
            // 
            // VisibleSettinsPanel
            // 
            this.VisibleSettinsPanel.Controls.Add(this.Label1);
            this.VisibleSettinsPanel.Controls.Add(this.FontButton);
            this.VisibleSettinsPanel.Controls.Add(this.FontLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label2);
            this.VisibleSettinsPanel.Controls.Add(this.ForeColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.ForeColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label3);
            this.VisibleSettinsPanel.Controls.Add(this.BackColorButton);
            this.VisibleSettinsPanel.Controls.Add(this.BackColorLabel);
            this.VisibleSettinsPanel.Controls.Add(this.Label4);
            this.VisibleSettinsPanel.Controls.Add(this.TabNumericUpDown);
            this.VisibleSettinsPanel.Controls.Add(this.TabToSpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.LineNumberCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.RulerCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.ModifyCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.CurrentCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpecialCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.EolCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.TabCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.SpaceCheckBox);
            this.VisibleSettinsPanel.Controls.Add(this.FullSpaceCheckBox);
            this.VisibleSettinsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisibleSettinsPanel.Location = new System.Drawing.Point(3, 3);
            this.VisibleSettinsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.VisibleSettinsPanel.Name = "VisibleSettinsPanel";
            this.VisibleSettinsPanel.Padding = new System.Windows.Forms.Padding(12, 20, 0, 0);
            this.VisibleSettinsPanel.Size = new System.Drawing.Size(460, 359);
            this.VisibleSettinsPanel.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(16, 24);
            this.Label1.Margin = new System.Windows.Forms.Padding(4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "テキストのフォント";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FontButton
            // 
            this.FontButton.Location = new System.Drawing.Point(124, 24);
            this.FontButton.Margin = new System.Windows.Forms.Padding(4);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(50, 23);
            this.FontButton.TabIndex = 2;
            this.FontButton.Text = "...";
            this.FontButton.UseVisualStyleBackColor = true;
            // 
            // FontLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.FontLabel, true);
            this.FontLabel.Location = new System.Drawing.Point(182, 24);
            this.FontLabel.Margin = new System.Windows.Forms.Padding(4);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(250, 23);
            this.FontLabel.TabIndex = 1;
            this.FontLabel.Text = "(メイリオ, 11pt)";
            this.FontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(16, 55);
            this.Label2.Margin = new System.Windows.Forms.Padding(4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 23);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "テキストの色";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ForeColorButton
            // 
            this.ForeColorButton.Location = new System.Drawing.Point(124, 55);
            this.ForeColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.ForeColorButton.Name = "ForeColorButton";
            this.ForeColorButton.Size = new System.Drawing.Size(50, 23);
            this.ForeColorButton.TabIndex = 4;
            this.ForeColorButton.UseVisualStyleBackColor = true;
            // 
            // ForeColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.ForeColorLabel, true);
            this.ForeColorLabel.Location = new System.Drawing.Point(182, 55);
            this.ForeColorLabel.Margin = new System.Windows.Forms.Padding(4);
            this.ForeColorLabel.Name = "ForeColorLabel";
            this.ForeColorLabel.Size = new System.Drawing.Size(250, 23);
            this.ForeColorLabel.TabIndex = 5;
            this.ForeColorLabel.Text = "(255, 255, 255)";
            this.ForeColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(16, 86);
            this.Label3.Margin = new System.Windows.Forms.Padding(4);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 23);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "背景色";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BackColorButton
            // 
            this.BackColorButton.Location = new System.Drawing.Point(124, 86);
            this.BackColorButton.Margin = new System.Windows.Forms.Padding(4);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(50, 23);
            this.BackColorButton.TabIndex = 7;
            this.BackColorButton.UseVisualStyleBackColor = true;
            // 
            // BackColorLabel
            // 
            this.VisibleSettinsPanel.SetFlowBreak(this.BackColorLabel, true);
            this.BackColorLabel.Location = new System.Drawing.Point(182, 86);
            this.BackColorLabel.Margin = new System.Windows.Forms.Padding(4);
            this.BackColorLabel.Name = "BackColorLabel";
            this.BackColorLabel.Size = new System.Drawing.Size(250, 23);
            this.BackColorLabel.TabIndex = 8;
            this.BackColorLabel.Text = "(255, 255, 255)";
            this.BackColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(16, 117);
            this.Label4.Margin = new System.Windows.Forms.Padding(4);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 23);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "タブ幅";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabNumericUpDown
            // 
            this.TabNumericUpDown.Location = new System.Drawing.Point(124, 117);
            this.TabNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.TabNumericUpDown.Name = "TabNumericUpDown";
            this.TabNumericUpDown.Size = new System.Drawing.Size(70, 23);
            this.TabNumericUpDown.TabIndex = 12;
            // 
            // TabToSpaceCheckBox
            // 
            this.TabToSpaceCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.TabToSpaceCheckBox, true);
            this.TabToSpaceCheckBox.Location = new System.Drawing.Point(210, 119);
            this.TabToSpaceCheckBox.Margin = new System.Windows.Forms.Padding(12, 6, 4, 0);
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
            this.LineNumberCheckBox.Location = new System.Drawing.Point(16, 160);
            this.LineNumberCheckBox.Margin = new System.Windows.Forms.Padding(4, 16, 4, 4);
            this.LineNumberCheckBox.Name = "LineNumberCheckBox";
            this.LineNumberCheckBox.Size = new System.Drawing.Size(114, 19);
            this.LineNumberCheckBox.TabIndex = 9;
            this.LineNumberCheckBox.Text = "行番号を表示する";
            this.LineNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // RulerCheckBox
            // 
            this.RulerCheckBox.AutoSize = true;
            this.VisibleSettinsPanel.SetFlowBreak(this.RulerCheckBox, true);
            this.RulerCheckBox.Location = new System.Drawing.Point(16, 187);
            this.RulerCheckBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.ModifyCheckBox.Location = new System.Drawing.Point(16, 214);
            this.ModifyCheckBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.CurrentCheckBox.Location = new System.Drawing.Point(16, 241);
            this.CurrentCheckBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.SpecialCheckBox.Location = new System.Drawing.Point(16, 268);
            this.SpecialCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SpecialCheckBox.Name = "SpecialCheckBox";
            this.SpecialCheckBox.Size = new System.Drawing.Size(126, 19);
            this.SpecialCheckBox.TabIndex = 16;
            this.SpecialCheckBox.Text = "特殊文字を表示する";
            this.SpecialCheckBox.UseVisualStyleBackColor = true;
            // 
            // EolCheckBox
            // 
            this.EolCheckBox.AutoSize = true;
            this.EolCheckBox.Location = new System.Drawing.Point(36, 295);
            this.EolCheckBox.Margin = new System.Windows.Forms.Padding(24, 4, 4, 4);
            this.EolCheckBox.Name = "EolCheckBox";
            this.EolCheckBox.Size = new System.Drawing.Size(50, 19);
            this.EolCheckBox.TabIndex = 17;
            this.EolCheckBox.Text = "改行";
            this.EolCheckBox.UseVisualStyleBackColor = true;
            // 
            // TabCheckBox
            // 
            this.TabCheckBox.AutoSize = true;
            this.TabCheckBox.Location = new System.Drawing.Point(94, 295);
            this.TabCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.TabCheckBox.Name = "TabCheckBox";
            this.TabCheckBox.Size = new System.Drawing.Size(43, 19);
            this.TabCheckBox.TabIndex = 18;
            this.TabCheckBox.Text = "タブ";
            this.TabCheckBox.UseVisualStyleBackColor = true;
            // 
            // SpaceCheckBox
            // 
            this.SpaceCheckBox.AutoSize = true;
            this.SpaceCheckBox.Location = new System.Drawing.Point(145, 295);
            this.SpaceCheckBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.FullSpaceCheckBox.Location = new System.Drawing.Point(241, 295);
            this.FullSpaceCheckBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(466, 365);
            this.GeneralTabPage.TabIndex = 1;
            this.GeneralTabPage.Text = "その他";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // VersionTabPage
            // 
            this.VersionTabPage.Location = new System.Drawing.Point(4, 24);
            this.VersionTabPage.Name = "VersionTabPage";
            this.VersionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VersionTabPage.Size = new System.Drawing.Size(466, 365);
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
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 438);
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
            this.ClientSize = new System.Drawing.Size(500, 500);
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
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button ForeColorButton;
        private System.Windows.Forms.Label ForeColorLabel;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button BackColorButton;
        private System.Windows.Forms.Label BackColorLabel;
        private System.Windows.Forms.CheckBox LineNumberCheckBox;
        private System.Windows.Forms.CheckBox RulerCheckBox;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.NumericUpDown TabNumericUpDown;
        private System.Windows.Forms.CheckBox TabToSpaceCheckBox;
        private System.Windows.Forms.CheckBox ModifyCheckBox;
        private System.Windows.Forms.CheckBox CurrentCheckBox;
        private System.Windows.Forms.CheckBox SpecialCheckBox;
        private System.Windows.Forms.CheckBox EolCheckBox;
        private System.Windows.Forms.CheckBox TabCheckBox;
        private System.Windows.Forms.CheckBox SpaceCheckBox;
        private System.Windows.Forms.CheckBox FullSpaceCheckBox;
    }
}