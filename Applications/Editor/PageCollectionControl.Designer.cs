namespace Cube.Note.App.Editor
{
    partial class PageCollectionControl
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
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.NewPageButton = new System.Windows.Forms.Button();
            this.TagComboBox = new System.Windows.Forms.ComboBox();
            this.Separator1 = new System.Windows.Forms.PictureBox();
            this.ContentsPanel = new Cube.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PageListView = new Cube.Note.App.Editor.PageListView();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).BeginInit();
            this.ContentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.NewPageButton, 0, 4);
            this.LayoutPanel.Controls.Add(this.TagComboBox, 0, 0);
            this.LayoutPanel.Controls.Add(this.Separator1, 0, 1);
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 2);
            this.LayoutPanel.Controls.Add(this.pictureBox1, 0, 3);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 5;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.TabIndex = 0;
            // 
            // NewPageButton
            // 
            this.NewPageButton.BackColor = System.Drawing.SystemColors.Control;
            this.NewPageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPageButton.FlatAppearance.BorderSize = 0;
            this.NewPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPageButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NewPageButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Add;
            this.NewPageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewPageButton.Location = new System.Drawing.Point(0, 270);
            this.NewPageButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewPageButton.Name = "NewPageButton";
            this.NewPageButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.NewPageButton.Size = new System.Drawing.Size(300, 30);
            this.NewPageButton.TabIndex = 5;
            this.NewPageButton.Text = "ノートを追加";
            this.NewPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NewPageButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewPageButton.UseVisualStyleBackColor = false;
            // 
            // TagComboBox
            // 
            this.TagComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TagComboBox.FormattingEnabled = true;
            this.TagComboBox.Location = new System.Drawing.Point(8, 3);
            this.TagComboBox.Margin = new System.Windows.Forms.Padding(8, 3, 8, 0);
            this.TagComboBox.MaxDropDownItems = 10;
            this.TagComboBox.Name = "TagComboBox";
            this.TagComboBox.Size = new System.Drawing.Size(284, 26);
            this.TagComboBox.TabIndex = 3;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Separator1.Location = new System.Drawing.Point(0, 32);
            this.Separator1.Margin = new System.Windows.Forms.Padding(0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(300, 1);
            this.Separator1.TabIndex = 1;
            this.Separator1.TabStop = false;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ContentsPanel.Controls.Add(this.PageListView);
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 33);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            this.ContentsPanel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.ContentsPanel.Size = new System.Drawing.Size(300, 236);
            this.ContentsPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 269);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 1);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // PageListView
            // 
            this.PageListView.Aggregator = null;
            this.PageListView.AllowNoSelect = false;
            this.PageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PageListView.Converter = pageConverter1;
            this.PageListView.DataSource = null;
            this.PageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageListView.FullRowSelect = true;
            this.PageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PageListView.Location = new System.Drawing.Point(4, 0);
            this.PageListView.Margin = new System.Windows.Forms.Padding(0);
            this.PageListView.MultiSelect = false;
            this.PageListView.Name = "PageListView";
            this.PageListView.Size = new System.Drawing.Size(296, 232);
            this.PageListView.TabIndex = 0;
            this.PageListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.PageListView.TileSize = new System.Drawing.Size(296, 115);
            this.PageListView.UseCompatibleStateImageBehavior = false;
            this.PageListView.View = System.Windows.Forms.View.Tile;
            // 
            // PageCollectionControl
            // 
            this.Controls.Add(this.LayoutPanel);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PageCollectionControl";
            this.Size = new System.Drawing.Size(300, 300);
            this.LayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.PictureBox Separator1;
        private Cube.Forms.Panel ContentsPanel;
        private PageListView PageListView;
        private System.Windows.Forms.ComboBox TagComboBox;
        private System.Windows.Forms.Button NewPageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
