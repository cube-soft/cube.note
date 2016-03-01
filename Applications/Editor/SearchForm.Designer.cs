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
            this.SearchNextButton = new Cube.Forms.Button();
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.ContentsPanel = new System.Windows.Forms.SplitContainer();
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.SearchTabPage = new System.Windows.Forms.TabPage();
            this.SearchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label11 = new System.Windows.Forms.Label();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.SearchRangeComboBox = new System.Windows.Forms.ComboBox();
            this.SearchCaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SearchNextShadow = new System.Windows.Forms.Panel();
            this.SearchPrevShadow = new System.Windows.Forms.Panel();
            this.SearchPrevButton = new Cube.Forms.Button();
            this.SearchShadow = new System.Windows.Forms.Panel();
            this.SearchButton = new Cube.Forms.Button();
            this.ReplaceTabPage = new System.Windows.Forms.TabPage();
            this.ReplacePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Label21 = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.ReplaceRangeComboBox = new System.Windows.Forms.ComboBox();
            this.ReplaceCaseSensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.ReplaceButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ReplaceAllShadow = new System.Windows.Forms.Panel();
            this.ReplaceAllButton = new Cube.Forms.Button();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultListView = new Cube.Note.App.Editor.PageListView();
            this.Separator = new System.Windows.Forms.PictureBox();
            this.FooterStatusStrip = new Cube.Forms.StatusStrip();
            this.ReplaceButton = new Cube.Forms.Button();
            this.ReplaceShadow = new System.Windows.Forms.Panel();
            this.ReplaceSearchButton = new Cube.Forms.Button();
            this.ReplaceSearchShadow = new System.Windows.Forms.Panel();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).BeginInit();
            this.ContentsPanel.Panel1.SuspendLayout();
            this.ContentsPanel.Panel2.SuspendLayout();
            this.ContentsPanel.SuspendLayout();
            this.MenuTabControl.SuspendLayout();
            this.SearchTabPage.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.SearchButtonsPanel.SuspendLayout();
            this.SearchNextShadow.SuspendLayout();
            this.SearchPrevShadow.SuspendLayout();
            this.SearchShadow.SuspendLayout();
            this.ReplaceTabPage.SuspendLayout();
            this.ReplacePanel.SuspendLayout();
            this.ReplaceButtonsPanel.SuspendLayout();
            this.ReplaceAllShadow.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).BeginInit();
            this.ReplaceShadow.SuspendLayout();
            this.ReplaceSearchShadow.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchNextButton
            // 
            this.SearchNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.SearchNextButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchNextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.SearchNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchNextButton.ForeColor = System.Drawing.Color.White;
            this.SearchNextButton.Location = new System.Drawing.Point(0, 0);
            this.SearchNextButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchNextButton.Name = "SearchNextButton";
            this.SearchNextButton.Size = new System.Drawing.Size(100, 30);
            this.SearchNextButton.TabIndex = 0;
            this.SearchNextButton.Text = "次を検索";
            this.SearchNextButton.UseVisualStyleBackColor = false;
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
            this.LayoutPanel.Size = new System.Drawing.Size(448, 348);
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
            this.ContentsPanel.Panel1.Controls.Add(this.MenuTabControl);
            this.ContentsPanel.Panel1.Padding = new System.Windows.Forms.Padding(4, 4, 2, 2);
            // 
            // ContentsPanel.Panel2
            // 
            this.ContentsPanel.Panel2.Controls.Add(this.ResultPanel);
            this.ContentsPanel.Panel2.Controls.Add(this.Separator);
            this.ContentsPanel.Size = new System.Drawing.Size(448, 296);
            this.ContentsPanel.SplitterDistance = 210;
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
            this.MenuTabControl.Size = new System.Drawing.Size(442, 204);
            this.MenuTabControl.TabIndex = 0;
            // 
            // SearchTabPage
            // 
            this.SearchTabPage.Controls.Add(this.SearchPanel);
            this.SearchTabPage.Location = new System.Drawing.Point(4, 24);
            this.SearchTabPage.Name = "SearchTabPage";
            this.SearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SearchTabPage.Size = new System.Drawing.Size(434, 176);
            this.SearchTabPage.TabIndex = 0;
            this.SearchTabPage.Text = "検 索";
            this.SearchTabPage.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Controls.Add(this.Label11);
            this.SearchPanel.Controls.Add(this.KeywordTextBox);
            this.SearchPanel.Controls.Add(this.Label12);
            this.SearchPanel.Controls.Add(this.SearchRangeComboBox);
            this.SearchPanel.Controls.Add(this.SearchCaseSensitiveCheckBox);
            this.SearchPanel.Controls.Add(this.SearchButtonsPanel);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(3, 3);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Padding = new System.Windows.Forms.Padding(12);
            this.SearchPanel.Size = new System.Drawing.Size(428, 170);
            this.SearchPanel.TabIndex = 0;
            // 
            // Label11
            // 
            this.Label11.Location = new System.Drawing.Point(15, 15);
            this.Label11.Margin = new System.Windows.Forms.Padding(3);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(100, 23);
            this.Label11.TabIndex = 0;
            this.Label11.Text = "検索する文字列";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KeywordTextBox
            // 
            this.SearchPanel.SetFlowBreak(this.KeywordTextBox, true);
            this.KeywordTextBox.Location = new System.Drawing.Point(121, 15);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(292, 23);
            this.KeywordTextBox.TabIndex = 1;
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(15, 44);
            this.Label12.Margin = new System.Windows.Forms.Padding(3);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(100, 23);
            this.Label12.TabIndex = 2;
            this.Label12.Text = "検索範囲";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchRangeComboBox
            // 
            this.SearchRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchPanel.SetFlowBreak(this.SearchRangeComboBox, true);
            this.SearchRangeComboBox.FormattingEnabled = true;
            this.SearchRangeComboBox.Location = new System.Drawing.Point(121, 44);
            this.SearchRangeComboBox.Name = "SearchRangeComboBox";
            this.SearchRangeComboBox.Size = new System.Drawing.Size(292, 23);
            this.SearchRangeComboBox.TabIndex = 3;
            // 
            // SearchCaseSensitiveCheckBox
            // 
            this.SearchCaseSensitiveCheckBox.AutoSize = true;
            this.SearchPanel.SetFlowBreak(this.SearchCaseSensitiveCheckBox, true);
            this.SearchCaseSensitiveCheckBox.Location = new System.Drawing.Point(15, 76);
            this.SearchCaseSensitiveCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.SearchCaseSensitiveCheckBox.Name = "SearchCaseSensitiveCheckBox";
            this.SearchCaseSensitiveCheckBox.Size = new System.Drawing.Size(158, 19);
            this.SearchCaseSensitiveCheckBox.TabIndex = 5;
            this.SearchCaseSensitiveCheckBox.Text = "大文字と小文字を区別する";
            this.SearchCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchButtonsPanel
            // 
            this.SearchButtonsPanel.Controls.Add(this.SearchNextShadow);
            this.SearchButtonsPanel.Controls.Add(this.SearchPrevShadow);
            this.SearchButtonsPanel.Controls.Add(this.SearchShadow);
            this.SearchButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SearchButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.SearchButtonsPanel.Location = new System.Drawing.Point(15, 130);
            this.SearchButtonsPanel.Margin = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.SearchButtonsPanel.Name = "SearchButtonsPanel";
            this.SearchButtonsPanel.Size = new System.Drawing.Size(398, 33);
            this.SearchButtonsPanel.TabIndex = 6;
            // 
            // SearchNextShadow
            // 
            this.SearchNextShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.SearchNextShadow.Controls.Add(this.SearchNextButton);
            this.SearchNextShadow.Location = new System.Drawing.Point(298, 0);
            this.SearchNextShadow.Margin = new System.Windows.Forms.Padding(0);
            this.SearchNextShadow.Name = "SearchNextShadow";
            this.SearchNextShadow.Size = new System.Drawing.Size(100, 32);
            this.SearchNextShadow.TabIndex = 7;
            // 
            // SearchPrevShadow
            // 
            this.SearchPrevShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.SearchPrevShadow.Controls.Add(this.SearchPrevButton);
            this.SearchPrevShadow.Location = new System.Drawing.Point(194, 0);
            this.SearchPrevShadow.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.SearchPrevShadow.Name = "SearchPrevShadow";
            this.SearchPrevShadow.Size = new System.Drawing.Size(100, 32);
            this.SearchPrevShadow.TabIndex = 8;
            // 
            // SearchPrevButton
            // 
            this.SearchPrevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.SearchPrevButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchPrevButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.SearchPrevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchPrevButton.ForeColor = System.Drawing.Color.White;
            this.SearchPrevButton.Location = new System.Drawing.Point(0, 0);
            this.SearchPrevButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPrevButton.Name = "SearchPrevButton";
            this.SearchPrevButton.Size = new System.Drawing.Size(100, 30);
            this.SearchPrevButton.TabIndex = 0;
            this.SearchPrevButton.Text = "前を検索";
            this.SearchPrevButton.UseVisualStyleBackColor = false;
            // 
            // SearchShadow
            // 
            this.SearchShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.SearchShadow.Controls.Add(this.SearchButton);
            this.SearchShadow.Location = new System.Drawing.Point(90, 0);
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
            this.ReplaceTabPage.Controls.Add(this.ReplacePanel);
            this.ReplaceTabPage.Location = new System.Drawing.Point(4, 24);
            this.ReplaceTabPage.Name = "ReplaceTabPage";
            this.ReplaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReplaceTabPage.Size = new System.Drawing.Size(434, 176);
            this.ReplaceTabPage.TabIndex = 1;
            this.ReplaceTabPage.Text = "置 換";
            this.ReplaceTabPage.UseVisualStyleBackColor = true;
            // 
            // ReplacePanel
            // 
            this.ReplacePanel.Controls.Add(this.Label21);
            this.ReplacePanel.Controls.Add(this.SearchTextBox);
            this.ReplacePanel.Controls.Add(this.Label22);
            this.ReplacePanel.Controls.Add(this.ReplaceTextBox);
            this.ReplacePanel.Controls.Add(this.Label23);
            this.ReplacePanel.Controls.Add(this.ReplaceRangeComboBox);
            this.ReplacePanel.Controls.Add(this.ReplaceCaseSensitiveCheckBox);
            this.ReplacePanel.Controls.Add(this.ReplaceButtonsPanel);
            this.ReplacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplacePanel.Location = new System.Drawing.Point(3, 3);
            this.ReplacePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ReplacePanel.Name = "ReplacePanel";
            this.ReplacePanel.Padding = new System.Windows.Forms.Padding(12);
            this.ReplacePanel.Size = new System.Drawing.Size(428, 170);
            this.ReplacePanel.TabIndex = 1;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(15, 15);
            this.Label21.Margin = new System.Windows.Forms.Padding(3);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(100, 23);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "検索する文字列";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchTextBox
            // 
            this.ReplacePanel.SetFlowBreak(this.SearchTextBox, true);
            this.SearchTextBox.Location = new System.Drawing.Point(121, 15);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(292, 23);
            this.SearchTextBox.TabIndex = 1;
            // 
            // Label22
            // 
            this.Label22.Location = new System.Drawing.Point(15, 44);
            this.Label22.Margin = new System.Windows.Forms.Padding(3);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(100, 23);
            this.Label22.TabIndex = 7;
            this.Label22.Text = "置換後の文字列";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReplaceTextBox
            // 
            this.ReplacePanel.SetFlowBreak(this.ReplaceTextBox, true);
            this.ReplaceTextBox.Location = new System.Drawing.Point(121, 44);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(292, 23);
            this.ReplaceTextBox.TabIndex = 8;
            // 
            // Label23
            // 
            this.Label23.Location = new System.Drawing.Point(15, 73);
            this.Label23.Margin = new System.Windows.Forms.Padding(3);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(100, 23);
            this.Label23.TabIndex = 2;
            this.Label23.Text = "検索範囲";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReplaceRangeComboBox
            // 
            this.ReplaceRangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ReplacePanel.SetFlowBreak(this.ReplaceRangeComboBox, true);
            this.ReplaceRangeComboBox.FormattingEnabled = true;
            this.ReplaceRangeComboBox.Location = new System.Drawing.Point(121, 73);
            this.ReplaceRangeComboBox.Name = "ReplaceRangeComboBox";
            this.ReplaceRangeComboBox.Size = new System.Drawing.Size(292, 23);
            this.ReplaceRangeComboBox.TabIndex = 3;
            // 
            // ReplaceCaseSensitiveCheckBox
            // 
            this.ReplaceCaseSensitiveCheckBox.AutoSize = true;
            this.ReplacePanel.SetFlowBreak(this.ReplaceCaseSensitiveCheckBox, true);
            this.ReplaceCaseSensitiveCheckBox.Location = new System.Drawing.Point(15, 105);
            this.ReplaceCaseSensitiveCheckBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.ReplaceCaseSensitiveCheckBox.Name = "ReplaceCaseSensitiveCheckBox";
            this.ReplaceCaseSensitiveCheckBox.Size = new System.Drawing.Size(158, 19);
            this.ReplaceCaseSensitiveCheckBox.TabIndex = 5;
            this.ReplaceCaseSensitiveCheckBox.Text = "大文字と小文字を区別する";
            this.ReplaceCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReplaceButtonsPanel
            // 
            this.ReplaceButtonsPanel.Controls.Add(this.ReplaceAllShadow);
            this.ReplaceButtonsPanel.Controls.Add(this.ReplaceShadow);
            this.ReplaceButtonsPanel.Controls.Add(this.ReplaceSearchShadow);
            this.ReplaceButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReplaceButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ReplaceButtonsPanel.Location = new System.Drawing.Point(15, 130);
            this.ReplaceButtonsPanel.Name = "ReplaceButtonsPanel";
            this.ReplaceButtonsPanel.Size = new System.Drawing.Size(398, 32);
            this.ReplaceButtonsPanel.TabIndex = 6;
            // 
            // ReplaceAllShadow
            // 
            this.ReplaceAllShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ReplaceAllShadow.Controls.Add(this.ReplaceAllButton);
            this.ReplaceAllShadow.Location = new System.Drawing.Point(298, 0);
            this.ReplaceAllShadow.Margin = new System.Windows.Forms.Padding(0);
            this.ReplaceAllShadow.Name = "ReplaceAllShadow";
            this.ReplaceAllShadow.Size = new System.Drawing.Size(100, 32);
            this.ReplaceAllShadow.TabIndex = 7;
            // 
            // ReplaceAllButton
            // 
            this.ReplaceAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.ReplaceAllButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReplaceAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.ReplaceAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceAllButton.ForeColor = System.Drawing.Color.White;
            this.ReplaceAllButton.Location = new System.Drawing.Point(0, 0);
            this.ReplaceAllButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReplaceAllButton.Name = "ReplaceAllButton";
            this.ReplaceAllButton.Size = new System.Drawing.Size(100, 30);
            this.ReplaceAllButton.TabIndex = 0;
            this.ReplaceAllButton.Text = "すべて置換";
            this.ReplaceAllButton.UseVisualStyleBackColor = false;
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
            this.ResultPanel.Size = new System.Drawing.Size(448, 84);
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
            this.ResultListView.Size = new System.Drawing.Size(444, 80);
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
            this.FooterStatusStrip.Location = new System.Drawing.Point(0, 326);
            this.FooterStatusStrip.Name = "FooterStatusStrip";
            this.FooterStatusStrip.Size = new System.Drawing.Size(448, 22);
            this.FooterStatusStrip.TabIndex = 2;
            this.FooterStatusStrip.Text = "statusStrip1";
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.ReplaceButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReplaceButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.ReplaceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceButton.ForeColor = System.Drawing.Color.White;
            this.ReplaceButton.Location = new System.Drawing.Point(0, 0);
            this.ReplaceButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(100, 30);
            this.ReplaceButton.TabIndex = 0;
            this.ReplaceButton.Text = "次を置換";
            this.ReplaceButton.UseVisualStyleBackColor = false;
            // 
            // ReplaceShadow
            // 
            this.ReplaceShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ReplaceShadow.Controls.Add(this.ReplaceButton);
            this.ReplaceShadow.Location = new System.Drawing.Point(194, 0);
            this.ReplaceShadow.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.ReplaceShadow.Name = "ReplaceShadow";
            this.ReplaceShadow.Size = new System.Drawing.Size(100, 32);
            this.ReplaceShadow.TabIndex = 8;
            // 
            // ReplaceSearchButton
            // 
            this.ReplaceSearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ReplaceSearchButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ReplaceSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ReplaceSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReplaceSearchButton.ForeColor = System.Drawing.Color.White;
            this.ReplaceSearchButton.Location = new System.Drawing.Point(0, 0);
            this.ReplaceSearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.ReplaceSearchButton.Name = "ReplaceSearchButton";
            this.ReplaceSearchButton.Size = new System.Drawing.Size(100, 30);
            this.ReplaceSearchButton.TabIndex = 0;
            this.ReplaceSearchButton.Text = "検索";
            this.ReplaceSearchButton.UseVisualStyleBackColor = false;
            // 
            // ReplaceSearchShadow
            // 
            this.ReplaceSearchShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ReplaceSearchShadow.Controls.Add(this.ReplaceSearchButton);
            this.ReplaceSearchShadow.Location = new System.Drawing.Point(90, 0);
            this.ReplaceSearchShadow.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.ReplaceSearchShadow.Name = "ReplaceSearchShadow";
            this.ReplaceSearchShadow.Size = new System.Drawing.Size(100, 32);
            this.ReplaceSearchShadow.TabIndex = 9;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.SearchButton;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(300, 265);
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
            this.SearchButtonsPanel.ResumeLayout(false);
            this.SearchNextShadow.ResumeLayout(false);
            this.SearchPrevShadow.ResumeLayout(false);
            this.SearchShadow.ResumeLayout(false);
            this.ReplaceTabPage.ResumeLayout(false);
            this.ReplacePanel.ResumeLayout(false);
            this.ReplacePanel.PerformLayout();
            this.ReplaceButtonsPanel.ResumeLayout(false);
            this.ReplaceAllShadow.ResumeLayout(false);
            this.ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator)).EndInit();
            this.ReplaceShadow.ResumeLayout(false);
            this.ReplaceSearchShadow.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox SearchRangeComboBox;
        private System.Windows.Forms.PictureBox Separator;
        private System.Windows.Forms.Panel ResultPanel;
        private PageListView ResultListView;
        private System.Windows.Forms.CheckBox SearchCaseSensitiveCheckBox;
        private System.Windows.Forms.FlowLayoutPanel SearchButtonsPanel;
        private System.Windows.Forms.Panel SearchNextShadow;
        private Forms.Button SearchNextButton;
        private System.Windows.Forms.FlowLayoutPanel ReplacePanel;
        private System.Windows.Forms.Label Label21;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label Label22;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.Label Label23;
        private System.Windows.Forms.ComboBox ReplaceRangeComboBox;
        private System.Windows.Forms.CheckBox ReplaceCaseSensitiveCheckBox;
        private System.Windows.Forms.FlowLayoutPanel ReplaceButtonsPanel;
        private System.Windows.Forms.Panel ReplaceAllShadow;
        private Forms.Button ReplaceAllButton;
        private System.Windows.Forms.Panel SearchPrevShadow;
        private Forms.Button SearchPrevButton;
        private System.Windows.Forms.Panel SearchShadow;
        private Forms.Button SearchButton;
        private System.Windows.Forms.Panel ReplaceShadow;
        private Forms.Button ReplaceButton;
        private System.Windows.Forms.Panel ReplaceSearchShadow;
        private Forms.Button ReplaceSearchButton;
    }
}