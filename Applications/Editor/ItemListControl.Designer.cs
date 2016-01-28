namespace Cube.Note.App.Editor
{
    partial class ItemListControl
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
            this.ItemListView = new Cube.Forms.ListView();
            this.SuspendLayout();
            // 
            // ItemListView
            // 
            this.ItemListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemListView.Location = new System.Drawing.Point(0, 0);
            this.ItemListView.Margin = new System.Windows.Forms.Padding(0);
            this.ItemListView.MultiSelect = false;
            this.ItemListView.Name = "ItemListView";
            this.ItemListView.Size = new System.Drawing.Size(200, 200);
            this.ItemListView.TabIndex = 0;
            this.ItemListView.Theme = Cube.Forms.WindowTheme.Explorer;
            this.ItemListView.TileSize = new System.Drawing.Size(248, 80);
            this.ItemListView.UseCompatibleStateImageBehavior = false;
            this.ItemListView.Resize += new System.EventHandler(this.ItemListView_Resize);
            // 
            // ItemListControl
            // 
            this.Controls.Add(this.ItemListView);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "ItemListControl";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.ListView ItemListView;
    }
}
