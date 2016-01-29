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
            this.PageListView = new Cube.Forms.ListView();
            this.SuspendLayout();
            // 
            // PageListView
            // 
            this.PageListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PageListView.Converter = null;
            this.PageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageListView.FullRowSelect = true;
            this.PageListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PageListView.Location = new System.Drawing.Point(5, 0);
            this.PageListView.Margin = new System.Windows.Forms.Padding(0);
            this.PageListView.MultiSelect = false;
            this.PageListView.Name = "PageListView";
            this.PageListView.Size = new System.Drawing.Size(195, 200);
            this.PageListView.TabIndex = 0;
            this.PageListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.PageListView.TileSize = new System.Drawing.Size(248, 80);
            this.PageListView.UseCompatibleStateImageBehavior = false;
            this.PageListView.SelectedIndexChanged += new System.EventHandler(this.PageListView_SelectedIndexChanged);
            this.PageListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PageListView_MouseUp);
            this.PageListView.Resize += new System.EventHandler(this.PageListView_Resize);
            // 
            // PageCollectionControl
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PageListView);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PageCollectionControl";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.ListView PageListView;
    }
}
