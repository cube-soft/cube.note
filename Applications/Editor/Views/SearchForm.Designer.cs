namespace Cube.Note.App.Editor
{
    partial class SearchForm
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
            this.ContentsPanel = new System.Windows.Forms.SplitContainer();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.SearchTabPage = new System.Windows.Forms.TabPage();
            this.SearchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ConditionPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RangeLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ReplaceLabel = new System.Windows.Forms.Label();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.RangeComboBox = new System.Windows.Forms.ComboBox();
            this.CaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OptionalShadow2 = new System.Windows.Forms.Panel();
            this.OptionalButton2 = new Cube.Forms.Button();
            this.OptionalShadow1 = new System.Windows.Forms.Panel();
            this.OptionalButton1 = new Cube.Forms.Button();
            this.SearchShadow = new System.Windows.Forms.Panel();
            this.SearchButton = new Cube.Forms.Button();
            this.ReplaceTabPage = new System.Windows.Forms.TabPage();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultListView = new Cube.Note.App.Editor.PageListView();
            this.Separator = new System.Windows.Forms.PictureBox();
            this.FooterStatusStrip = new Cube.Forms.StatusStrip();
            this.MessageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).BeginInit();
            this.ContentsPanel.Panel1.SuspendLayout();
            this.ContentsPanel.Panel2.SuspendLayout();
            this.ContentsPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.SearchTabPage.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.ConditionPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.OptionalShadow2.SuspendLayout();
            this.OptionalShadow1.SuspendLayout();
            this.SearchShadow.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).BeginInit();
            this.FooterStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 1);
            this.LayoutPanel.Controls.Add(this.FooterStatusStrip, 0, 2);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.LayoutPanel.Size = new System.Drawing.Size(448, 448);
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
            this.TitleControl.Size = new System.Drawing.Size(448, 30);
            this.TitleControl.TabIndex = 0;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ContentsPanel.IsSplitterFixed = true;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 30);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            this.ContentsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ContentsPanel.Panel1
            // 
            this.ContentsPanel.Panel1.Controls.Add(this.TabControl);
            this.ContentsPanel.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 2, 2);
            // 
            // ContentsPanel.Panel2
            // 
            this.ContentsPanel.Panel2.Controls.Add(this.ResultPanel);
            this.ContentsPanel.Panel2.Controls.Add(this.Separator);
            this.ContentsPanel.Size = new System.Drawing.Size(448, 396);
            this.ContentsPanel.SplitterDistance = 217;
            this.ContentsPanel.SplitterWidth = 1;
            this.ContentsPanel.TabIndex = 1;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.SearchTabPage);
            this.TabControl.Controls.Add(this.ReplaceTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(4, 4);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(442, 211);
            this.TabControl.TabIndex = 0;
            // 
            // SearchTabPage
            // 
            this.SearchTabPage.Controls.Add(this.SearchPanel);
            this.SearchTabPage.Location = new System.Drawing.Point(4, 24);
            this.SearchTabPage.Name = "SearchTabPage";
            this.SearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SearchTabPage.Size = new System.Drawing.Size(434, 183);
            this.SearchTabPage.TabIndex = 0;
            this.SearchTabPage.Text = "検 索";
            this.SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.ConditionPanel);
            this.SearchPanel.Controls.Add(this.CaseSensitiveCheckBox);
            this.SearchPanel.Controls.Add(this.ButtonsPanel);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(3, 3);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(12);
            this.SearchPanel.Size = new System.Drawing.Size(428, 177);
            this.SearchPanel.TabIndex = 3;
            // 
            // ConditionPanel
            // 
            this.ConditionPanel.ColumnCount = 2;
            this.ConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ConditionPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConditionPanel.Controls.Add(this.RangeLabel, 0, 2);
            this.ConditionPanel.Controls.Add(this.SearchLabel, 0, 0);
            this.ConditionPanel.Controls.Add(this.SearchTextBox, 1, 0);
            this.ConditionPanel.Controls.Add(this.ReplaceLabel, 0, 1);
            this.ConditionPanel.Controls.Add(this.ReplaceTextBox, 1, 1);
            this.ConditionPanel.Controls.Add(this.RangeComboBox, 1, 2);
            this.ConditionPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.ConditionPanel.Location = new System.Drawing.Point(12, 12);
            this.ConditionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionPanel.Name = "ConditionPanel";
            this.ConditionPanel.RowCount = 3;
            this.ConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConditionPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ConditionPanel.Size = new System.Drawing.Size(401, 90);
            this.ConditionPanel.TabIndex = 9;
            // 
            // RangeLabel
            // 
            this.RangeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RangeLabel.Location = new System.Drawing.Point(3, 63);
            this.RangeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.RangeLabel.Name = "RangeLabel";
            this.RangeLabel.Size = new System.Drawing.Size(94, 24);
            this.RangeLabel.TabIndex = 10;
            this.RangeLabel.Text = "検索範囲";
            this.RangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchLabel
            // 
            this.SearchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchLabel.Location = new System.Drawing.Point(3, 3);
            this.SearchLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(94, 24);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "検索する文字列";
            this.SearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(103, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(295, 23);
            this.SearchTextBox.TabIndex = 2;
            // 
            // ReplaceLabel
            // 
            this.ReplaceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplaceLabel.Location = new System.Drawing.Point(3, 33);
            this.ReplaceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.ReplaceLabel.Name = "ReplaceLabel";
            this.ReplaceLabel.Size = new System.Drawing.Size(94, 24);
            this.ReplaceLabel.TabIndex = 8;
            this.ReplaceLabel.Text = "置換後の文字列";
            this.ReplaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplaceTextBox.Location = new System.Drawing.Point(103, 33);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(295, 23);
            this.ReplaceTextBox.TabIndex = 9;
            // 
            // RangeComboBox
            // 
            this.RangeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RangeComboBox.FormattingEnabled = true;
            this.RangeComboBox.Location = new System.Drawing.Point(103, 63);
            this.RangeComboBox.Name = "RangeComboBox";
            this.RangeComboBox.Size = new System.Drawing.Size(295, 23);
            this.RangeComboBox.TabIndex = 11;
            // 
            // CaseSensitiveCheckBox
            // 
            this.CaseSensitiveCheckBox.AutoSize = true;
            this.SearchPanel.SetFlowBreak(this.CaseSensitiveCheckBox, true);
            this.CaseSensitiveCheckBox.Location = new System.Drawing.Point(12, 108);
            this.CaseSensitiveCheckBox.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.CaseSensitiveCheckBox.Name = "CaseSensitiveCheckBox";
            this.CaseSensitiveCheckBox.Size = new System.Drawing.Size(158, 19);
            this.CaseSensitiveCheckBox.TabIndex = 5;
            this.CaseSensitiveCheckBox.Text = "大文字と小文字を区別する";
            this.CaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.OptionalShadow2);
            this.ButtonsPanel.Controls.Add(this.OptionalShadow1);
            this.ButtonsPanel.Controls.Add(this.SearchShadow);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(12, 133);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(401, 32);
            this.ButtonsPanel.TabIndex = 6;
            // 
            // OptionalShadow2
            // 
            this.OptionalShadow2.BackColor = System.Drawing.Color.Gainsboro;
            this.OptionalShadow2.Controls.Add(this.OptionalButton2);
            this.OptionalShadow2.Location = new System.Drawing.Point(301, 0);
            this.OptionalShadow2.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalShadow2.Name = "OptionalShadow2";
            this.OptionalShadow2.Size = new System.Drawing.Size(100, 32);
            this.OptionalShadow2.TabIndex = 7;
            // 
            // OptionalButton2
            // 
            this.OptionalButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.OptionalButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionalButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.OptionalButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionalButton2.ForeColor = System.Drawing.Color.White;
            this.OptionalButton2.Location = new System.Drawing.Point(0, 0);
            this.OptionalButton2.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalButton2.Name = "OptionalButton2";
            this.OptionalButton2.Size = new System.Drawing.Size(100, 30);
            this.OptionalButton2.TabIndex = 0;
            this.OptionalButton2.Text = "次を検索";
            this.OptionalButton2.UseVisualStyleBackColor = false;
            // 
            // OptionalShadow1
            // 
            this.OptionalShadow1.BackColor = System.Drawing.Color.Gainsboro;
            this.OptionalShadow1.Controls.Add(this.OptionalButton1);
            this.OptionalShadow1.Location = new System.Drawing.Point(197, 0);
            this.OptionalShadow1.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.OptionalShadow1.Name = "OptionalShadow1";
            this.OptionalShadow1.Size = new System.Drawing.Size(100, 32);
            this.OptionalShadow1.TabIndex = 8;
            // 
            // OptionalButton1
            // 
            this.OptionalButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.OptionalButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionalButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.OptionalButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionalButton1.ForeColor = System.Drawing.Color.White;
            this.OptionalButton1.Location = new System.Drawing.Point(0, 0);
            this.OptionalButton1.Margin = new System.Windows.Forms.Padding(0);
            this.OptionalButton1.Name = "OptionalButton1";
            this.OptionalButton1.Size = new System.Drawing.Size(100, 30);
            this.OptionalButton1.TabIndex = 0;
            this.OptionalButton1.Text = "前を検索";
            this.OptionalButton1.UseVisualStyleBackColor = false;
            // 
            // SearchShadow
            // 
            this.SearchShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.SearchShadow.Controls.Add(this.SearchButton);
            this.SearchShadow.Location = new System.Drawing.Point(93, 0);
            this.SearchShadow.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.SearchShadow.Name = "SearchShadow";
            this.SearchShadow.Size = new System.Drawing.Size(100, 32);
            this.SearchShadow.TabIndex = 9;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.Color.White;
            this.SearchButton.Location = new System.Drawing.Point(0, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 30);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "検索";
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // ReplaceTabPage
            // 
            this.ReplaceTabPage.Location = new System.Drawing.Point(4, 22);
            this.ReplaceTabPage.Name = "ReplaceTabPage";
            this.ReplaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReplaceTabPage.Size = new System.Drawing.Size(434, 185);
            this.ReplaceTabPage.TabIndex = 1;
            this.ReplaceTabPage.Text = "置 換";
            this.ReplaceTabPage.UseVisualStyleBackColor = true;
            // 
            // ResultPanel
            // 
            this.ResultPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ResultPanel.Controls.Add(this.ResultListView);
            this.ResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultPanel.Location = new System.Drawing.Point(0, 1);
            this.ResultPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.ResultPanel.Size = new System.Drawing.Size(448, 177);
            this.ResultPanel.TabIndex = 2;
            // 
            // ResultListView
            // 
            this.ResultListView.Aggregator = null;
            this.ResultListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultListView.DataSource = null;
            this.ResultListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultListView.FullRowSelect = true;
            this.ResultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ResultListView.LabelWrap = false;
            this.ResultListView.Location = new System.Drawing.Point(4, 0);
            this.ResultListView.Margin = new System.Windows.Forms.Padding(0);
            this.ResultListView.MultiSelect = false;
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.ShowPropertyButton = false;
            this.ResultListView.ShowRemoveButton = false;
            this.ResultListView.Size = new System.Drawing.Size(444, 173);
            this.ResultListView.TabIndex = 1;
            this.ResultListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.ResultListView.TileSize = new System.Drawing.Size(444, 8);
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.View = System.Windows.Forms.View.Tile;
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.Separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.Separator.Location = new System.Drawing.Point(0, 0);
            this.Separator.Margin = new System.Windows.Forms.Padding(0);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(448, 1);
            this.Separator.TabIndex = 1;
            this.Separator.TabStop = false;
            // 
            // FooterStatusStrip
            // 
            this.FooterStatusStrip.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FooterStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MessageLabel});
            this.FooterStatusStrip.Location = new System.Drawing.Point(0, 426);
            this.FooterStatusStrip.Name = "FooterStatusStrip";
            this.FooterStatusStrip.Size = new System.Drawing.Size(448, 22);
            this.FooterStatusStrip.TabIndex = 2;
            this.FooterStatusStrip.Text = "statusStrip1";
            // 
            // MessageLabel
            // 
            this.MessageLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(402, 17);
            this.MessageLabel.Spring = true;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.LayoutPanel);
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(370, 270);
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.Sizable = true;
            this.Text = "検索と置換";
            this.TopMost = true;
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ContentsPanel.Panel1.ResumeLayout(false);
            this.ContentsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.SearchTabPage.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.OptionalShadow2.ResumeLayout(false);
            this.OptionalShadow1.ResumeLayout(false);
            this.SearchShadow.ResumeLayout(false);
            this.ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).EndInit();
            this.FooterStatusStrip.ResumeLayout(false);
            this.FooterStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private System.Windows.Forms.SplitContainer ContentsPanel;
        private Cube.Forms.StatusStrip FooterStatusStrip;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage SearchTabPage;
        private System.Windows.Forms.TabPage ReplaceTabPage;
        private System.Windows.Forms.PictureBox Separator;
        private System.Windows.Forms.Panel ResultPanel;
        private PageListView ResultListView;
        private System.Windows.Forms.FlowLayoutPanel SearchPanel;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckBox;
        private System.Windows.Forms.FlowLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Panel OptionalShadow2;
        private Forms.Button OptionalButton2;
        private System.Windows.Forms.Panel OptionalShadow1;
        private Forms.Button OptionalButton1;
        private System.Windows.Forms.Panel SearchShadow;
        private Forms.Button SearchButton;
        private System.Windows.Forms.ToolStripStatusLabel MessageLabel;
        private System.Windows.Forms.TableLayoutPanel ConditionPanel;
        private System.Windows.Forms.Label RangeLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label ReplaceLabel;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.ComboBox RangeComboBox;
    }
}