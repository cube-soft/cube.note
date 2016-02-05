namespace Cube.Note.App.Editor
{
    partial class SearchControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Cube.Note.App.Editor.PageConverter pageConverter1 = new Cube.Note.App.Editor.PageConverter();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new Cube.Forms.Button();
            this.Separator1 = new System.Windows.Forms.PictureBox();
            this.ContentsPanel = new System.Windows.Forms.Panel();
            this.PageListView = new Cube.Note.App.Editor.PageListView();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).BeginInit();
            this.ContentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.Controls.Add(this.KeywordTextBox, 0, 0);
            this.LayoutPanel.Controls.Add(this.SearchButton, 1, 0);
            this.LayoutPanel.Controls.Add(this.Separator1, 0, 1);
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 2);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.TabIndex = 0;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KeywordTextBox.Location = new System.Drawing.Point(6, 6);
            this.KeywordTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(262, 19);
            this.KeywordTextBox.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Search;
            this.SearchButton.Location = new System.Drawing.Point(268, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(32, 32);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LayoutPanel.SetColumnSpan(this.Separator1, 2);
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Separator1.Location = new System.Drawing.Point(0, 32);
            this.Separator1.Margin = new System.Windows.Forms.Padding(0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(300, 1);
            this.Separator1.TabIndex = 6;
            this.Separator1.TabStop = false;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.SetColumnSpan(this.ContentsPanel, 2);
            this.ContentsPanel.Controls.Add(this.PageListView);
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 33);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            this.ContentsPanel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.ContentsPanel.Size = new System.Drawing.Size(300, 267);
            this.ContentsPanel.TabIndex = 7;
            // 
            // PageListView
            // 
            this.PageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PageListView.Converter = pageConverter1;
            this.PageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageListView.FullRowSelect = true;
            this.PageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PageListView.Location = new System.Drawing.Point(4, 0);
            this.PageListView.Margin = new System.Windows.Forms.Padding(0);
            this.PageListView.MultiSelect = false;
            this.PageListView.Name = "PageListView";
            this.PageListView.Size = new System.Drawing.Size(296, 263);
            this.PageListView.TabIndex = 8;
            this.PageListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.PageListView.TileSize = new System.Drawing.Size(296, 70);
            this.PageListView.UseCompatibleStateImageBehavior = false;
            this.PageListView.View = System.Windows.Forms.View.Tile;
            // 
            // SearchControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private Cube.Forms.Button SearchButton;
        private System.Windows.Forms.PictureBox Separator1;
        private System.Windows.Forms.Panel ContentsPanel;
        private PageListView PageListView;
    }
}
