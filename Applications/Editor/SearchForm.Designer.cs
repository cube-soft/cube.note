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
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.SearchTabPage = new System.Windows.Forms.TabPage();
            this.SearchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label11 = new System.Windows.Forms.Label();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.RangeComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButtonShadow = new System.Windows.Forms.Panel();
            this.SearchButton = new Cube.Forms.Button();
            this.ReplaceTabPage = new System.Windows.Forms.TabPage();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultListView = new Cube.Note.App.Editor.PageListView();
            this.Separator = new System.Windows.Forms.PictureBox();
            this.FooterStatusStrip = new Cube.Forms.StatusStrip();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).BeginInit();
            this.ContentsPanel.Panel1.SuspendLayout();
            this.ContentsPanel.Panel2.SuspendLayout();
            this.ContentsPanel.SuspendLayout();
            this.MenuTabControl.SuspendLayout();
            this.SearchTabPage.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.SearchButtonShadow.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).BeginInit();
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
            this.LayoutPanel.Size = new System.Drawing.Size(398, 348);
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
            this.TitleControl.Size = new System.Drawing.Size(398, 30);
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
            this.ContentsPanel.Panel1.Controls.Add(this.MenuTabControl);
            this.ContentsPanel.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 2, 2);
            // 
            // ContentsPanel.Panel2
            // 
            this.ContentsPanel.Panel2.Controls.Add(this.ResultPanel);
            this.ContentsPanel.Panel2.Controls.Add(this.Separator);
            this.ContentsPanel.Size = new System.Drawing.Size(398, 296);
            this.ContentsPanel.SplitterDistance = 160;
            this.ContentsPanel.SplitterWidth = 1;
            this.ContentsPanel.TabIndex = 1;
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.SearchTabPage);
            this.MenuTabControl.Controls.Add(this.ReplaceTabPage);
            this.MenuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTabControl.Location = new System.Drawing.Point(4, 4);
            this.MenuTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(392, 154);
            this.MenuTabControl.TabIndex = 0;
            // 
            // SearchTabPage
            // 
            this.SearchTabPage.Controls.Add(this.SearchPanel);
            this.SearchTabPage.Location = new System.Drawing.Point(4, 24);
            this.SearchTabPage.Name = "SearchTabPage";
            this.SearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SearchTabPage.Size = new System.Drawing.Size(384, 126);
            this.SearchTabPage.TabIndex = 0;
            this.SearchTabPage.Text = "検 索";
            this.SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.Label11);
            this.SearchPanel.Controls.Add(this.KeywordTextBox);
            this.SearchPanel.Controls.Add(this.Label12);
            this.SearchPanel.Controls.Add(this.RangeComboBox);
            this.SearchPanel.Controls.Add(this.SearchButtonShadow);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(3, 3);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(12);
            this.SearchPanel.Size = new System.Drawing.Size(378, 120);
            this.SearchPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 15);
            this.Label11.Margin = new System.Windows.Forms.Padding(3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(75, 23);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "キーワード";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KeywordTextBox
            // 
            this.SearchPanel.SetFlowBreak(this.KeywordTextBox, true);
            this.KeywordTextBox.Location = new System.Drawing.Point(96, 15);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(267, 23);
            this.KeywordTextBox.TabIndex = 1;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 44);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(75, 23);
            this.Label12.TabIndex = 2;
            this.Label12.Text = "範囲";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RangeComboBox
            // 
            this.RangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchPanel.SetFlowBreak(this.RangeComboBox, true);
            this.RangeComboBox.FormattingEnabled = true;
            this.RangeComboBox.Location = new System.Drawing.Point(96, 44);
            this.RangeComboBox.Name = "RangeComboBox";
            this.RangeComboBox.Size = new System.Drawing.Size(267, 23);
            this.RangeComboBox.TabIndex = 3;
            // 
            // SearchButtonShadow
            // 
            this.SearchButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.SearchButtonShadow.Controls.Add(this.SearchButton);
            this.SearchButtonShadow.Location = new System.Drawing.Point(12, 78);
            this.SearchButtonShadow.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.SearchButtonShadow.Name = "SearchButtonShadow";
            this.SearchButtonShadow.Size = new System.Drawing.Size(100, 32);
            this.SearchButtonShadow.TabIndex = 4;
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
            this.ReplaceTabPage.Size = new System.Drawing.Size(384, 128);
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
            this.ResultPanel.Size = new System.Drawing.Size(398, 134);
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
            this.ResultListView.Size = new System.Drawing.Size(394, 130);
            this.ResultListView.TabIndex = 1;
            this.ResultListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.ResultListView.TileSize = new System.Drawing.Size(394, 10);
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
            this.Separator.Size = new System.Drawing.Size(398, 1);
            this.Separator.TabIndex = 1;
            this.Separator.TabStop = false;
            // 
            // FooterStatusStrip
            // 
            this.FooterStatusStrip.Location = new System.Drawing.Point(0, 326);
            this.FooterStatusStrip.Name = "FooterStatusStrip";
            this.FooterStatusStrip.Size = new System.Drawing.Size(398, 22);
            this.FooterStatusStrip.TabIndex = 2;
            this.FooterStatusStrip.Text = "statusStrip1";
            // 
            // SearchForm
            // 
            this.AcceptButton = this.SearchButton;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(300, 220);
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
            this.MenuTabControl.ResumeLayout(false);
            this.SearchTabPage.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.SearchButtonShadow.ResumeLayout(false);
            this.ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private System.Windows.Forms.SplitContainer ContentsPanel;
        private Cube.Forms.StatusStrip FooterStatusStrip;
        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage SearchTabPage;
        private System.Windows.Forms.TabPage ReplaceTabPage;
        private System.Windows.Forms.FlowLayoutPanel SearchPanel;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.ComboBox RangeComboBox;
        private System.Windows.Forms.Panel SearchButtonShadow;
        private Forms.Button SearchButton;
        private System.Windows.Forms.PictureBox Separator;
        private System.Windows.Forms.Panel ResultPanel;
        private PageListView ResultListView;
    }
}