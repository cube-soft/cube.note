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
            this.Separator1 = new System.Windows.Forms.PictureBox();
            this.ContentsPanel = new System.Windows.Forms.Panel();
            this.PageListView = new Cube.Note.App.Editor.PageListView();
            this.KeywordPanel = new System.Windows.Forms.Panel();
            this.SearchButton = new Cube.Forms.Button();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).BeginInit();
            this.ContentsPanel.SuspendLayout();
            this.KeywordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.Separator1, 0, 1);
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 2);
            this.LayoutPanel.Controls.Add(this.KeywordPanel, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.TabIndex = 0;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Separator1.Location = new System.Drawing.Point(0, 36);
            this.Separator1.Margin = new System.Windows.Forms.Padding(0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(300, 1);
            this.Separator1.TabIndex = 6;
            this.Separator1.TabStop = false;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.Controls.Add(this.PageListView);
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 37);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            this.ContentsPanel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.ContentsPanel.Size = new System.Drawing.Size(300, 263);
            this.ContentsPanel.TabIndex = 7;
            // 
            // PageListView
            // 
            this.PageListView.BackColor = System.Drawing.SystemColors.Control;
            this.PageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PageListView.Converter = pageConverter1;
            this.PageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageListView.FullRowSelect = true;
            this.PageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PageListView.Location = new System.Drawing.Point(4, 0);
            this.PageListView.Margin = new System.Windows.Forms.Padding(0);
            this.PageListView.MultiSelect = false;
            this.PageListView.Name = "PageListView";
            this.PageListView.Size = new System.Drawing.Size(296, 259);
            this.PageListView.TabIndex = 8;
            this.PageListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.PageListView.TileSize = new System.Drawing.Size(296, 70);
            this.PageListView.UseCompatibleStateImageBehavior = false;
            this.PageListView.View = System.Windows.Forms.View.Tile;
            // 
            // KeywordPanel
            // 
            this.KeywordPanel.BackColor = System.Drawing.SystemColors.Window;
            this.KeywordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeywordPanel.Controls.Add(this.SearchButton);
            this.KeywordPanel.Controls.Add(this.KeywordTextBox);
            this.KeywordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordPanel.Location = new System.Drawing.Point(8, 4);
            this.KeywordPanel.Margin = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.KeywordPanel.Name = "KeywordPanel";
            this.KeywordPanel.Size = new System.Drawing.Size(284, 28);
            this.KeywordPanel.TabIndex = 8;
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Window;
            this.SearchButton.Image = global::Cube.Note.App.Editor.Properties.Resources.SearchPale;
            this.SearchButton.Location = new System.Drawing.Point(256, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(26, 26);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KeywordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KeywordTextBox.Location = new System.Drawing.Point(6, 4);
            this.KeywordTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(250, 18);
            this.KeywordTextBox.TabIndex = 0;
            // 
            // SearchControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LayoutPanel);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(128)));
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            this.KeywordPanel.ResumeLayout(false);
            this.KeywordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.PictureBox Separator1;
        private System.Windows.Forms.Panel ContentsPanel;
        private PageListView PageListView;
        private System.Windows.Forms.Panel KeywordPanel;
        private Forms.Button SearchButton;
        private System.Windows.Forms.TextBox KeywordTextBox;
    }
}
