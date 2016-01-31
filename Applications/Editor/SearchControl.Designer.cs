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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.RemoveButton = new Cube.Forms.Button();
            this.FoundationPanel = new System.Windows.Forms.Panel();
            this.PageListView = new Cube.Note.App.Editor.PageListView();
            this.LayoutPanel.SuspendLayout();
            this.FoundationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.Controls.Add(this.KeywordTextBox, 0, 0);
            this.LayoutPanel.Controls.Add(this.SearchButton, 1, 0);
            this.LayoutPanel.Controls.Add(this.StatusLabel, 0, 2);
            this.LayoutPanel.Controls.Add(this.RemoveButton, 1, 2);
            this.LayoutPanel.Controls.Add(this.FoundationPanel, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(200, 300);
            this.LayoutPanel.TabIndex = 0;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordTextBox.Location = new System.Drawing.Point(3, 3);
            this.KeywordTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(165, 23);
            this.KeywordTextBox.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Image = global::Cube.Note.App.Editor.Properties.Resources.SearchSmall;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SearchButton.Location = new System.Drawing.Point(168, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(32, 32);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLabel.Location = new System.Drawing.Point(0, 280);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(168, 20);
            this.StatusLabel.TabIndex = 3;
            // 
            // RemoveButton
            // 
            this.RemoveButton.FlatAppearance.BorderSize = 0;
            this.RemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RemoveButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Exit;
            this.RemoveButton.Location = new System.Drawing.Point(168, 280);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(0);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(32, 20);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.UseVisualStyleBackColor = false;
            // 
            // FoundationPanel
            // 
            this.FoundationPanel.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.SetColumnSpan(this.FoundationPanel, 2);
            this.FoundationPanel.Controls.Add(this.PageListView);
            this.FoundationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoundationPanel.Location = new System.Drawing.Point(0, 32);
            this.FoundationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FoundationPanel.Name = "FoundationPanel";
            this.FoundationPanel.Size = new System.Drawing.Size(200, 248);
            this.FoundationPanel.TabIndex = 5;
            // 
            // PageListView
            // 
            this.PageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PageListView.Converter = pageConverter1;
            this.PageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageListView.FullRowSelect = true;
            this.PageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PageListView.Location = new System.Drawing.Point(0, 0);
            this.PageListView.Margin = new System.Windows.Forms.Padding(0);
            this.PageListView.MultiSelect = false;
            this.PageListView.Name = "PageListView";
            this.PageListView.Size = new System.Drawing.Size(200, 248);
            this.PageListView.TabIndex = 0;
            this.PageListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.PageListView.TileSize = new System.Drawing.Size(200, 70);
            this.PageListView.UseCompatibleStateImageBehavior = false;
            this.PageListView.View = System.Windows.Forms.View.Tile;
            // 
            // SearchControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(200, 300);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.FoundationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private Cube.Forms.Button SearchButton;
        private System.Windows.Forms.Label StatusLabel;
        private Cube.Forms.Button RemoveButton;
        private System.Windows.Forms.Panel FoundationPanel;
        private PageListView PageListView;
    }
}
