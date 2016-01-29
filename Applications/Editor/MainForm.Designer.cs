namespace Cube.Note.App.Editor
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ContentsPanel = new System.Windows.Forms.SplitContainer();
            this.PageCollectionControl = new Cube.Note.App.Editor.PageCollectionControl();
            this.TextEditControl = new Cube.Note.App.Editor.TextEditControl();
            this.MenuToolStrip = new System.Windows.Forms.ToolStrip();
            this.VisibleMenuItem = new System.Windows.Forms.ToolStripButton();
            this.MenuSeparator1 = new System.Windows.Forms.ToolStripButton();
            this.NewPageMenuItem = new System.Windows.Forms.ToolStripButton();
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripButton();
            this.SearchMenuItem = new System.Windows.Forms.ToolStripButton();
            this.MenuSeparator2 = new System.Windows.Forms.ToolStripButton();
            this.FontMenuItem = new System.Windows.Forms.ToolStripButton();
            this.VerticalSeparator = new System.Windows.Forms.PictureBox();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).BeginInit();
            this.ContentsPanel.Panel1.SuspendLayout();
            this.ContentsPanel.Panel2.SuspendLayout();
            this.ContentsPanel.SuspendLayout();
            this.MenuToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSeparator)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 2);
            this.LayoutPanel.Controls.Add(this.MenuToolStrip, 0, 0);
            this.LayoutPanel.Controls.Add(this.VerticalSeparator, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(784, 461);
            this.LayoutPanel.TabIndex = 2;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 37);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            // 
            // ContentsPanel.Panel1
            // 
            this.ContentsPanel.Panel1.Controls.Add(this.PageCollectionControl);
            // 
            // ContentsPanel.Panel2
            // 
            this.ContentsPanel.Panel2.Controls.Add(this.TextEditControl);
            this.ContentsPanel.Size = new System.Drawing.Size(784, 424);
            this.ContentsPanel.SplitterDistance = 250;
            this.ContentsPanel.SplitterWidth = 1;
            this.ContentsPanel.TabIndex = 3;
            // 
            // PageCollectionControl
            // 
            this.PageCollectionControl.BackColor = System.Drawing.SystemColors.Window;
            this.PageCollectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageCollectionControl.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PageCollectionControl.Location = new System.Drawing.Point(0, 0);
            this.PageCollectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.PageCollectionControl.Name = "PageCollectionControl";
            this.PageCollectionControl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.PageCollectionControl.Size = new System.Drawing.Size(250, 424);
            this.PageCollectionControl.TabIndex = 0;
            // 
            // TextEditControl
            // 
            this.TextEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEditControl.Location = new System.Drawing.Point(0, 0);
            this.TextEditControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextEditControl.Name = "TextEditControl";
            this.TextEditControl.Size = new System.Drawing.Size(533, 424);
            this.TextEditControl.TabIndex = 0;
            // 
            // MenuToolStrip
            // 
            this.MenuToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.MenuToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuToolStrip.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MenuToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.MenuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VisibleMenuItem,
            this.MenuSeparator1,
            this.NewPageMenuItem,
            this.RemoveMenuItem,
            this.SearchMenuItem,
            this.MenuSeparator2,
            this.FontMenuItem});
            this.MenuToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuToolStrip.Name = "MenuToolStrip";
            this.MenuToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MenuToolStrip.Size = new System.Drawing.Size(784, 36);
            this.MenuToolStrip.TabIndex = 0;
            this.MenuToolStrip.Text = "メニュー";
            // 
            // VisibleMenuItem
            // 
            this.VisibleMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.VisibleMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.ArrowLeft;
            this.VisibleMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VisibleMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VisibleMenuItem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.VisibleMenuItem.Name = "VisibleMenuItem";
            this.VisibleMenuItem.Size = new System.Drawing.Size(28, 28);
            this.VisibleMenuItem.Text = "ノート一覧を非表示";
            // 
            // MenuSeparator1
            // 
            this.MenuSeparator1.AutoSize = false;
            this.MenuSeparator1.AutoToolTip = false;
            this.MenuSeparator1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MenuSeparator1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.MenuSeparator1.Enabled = false;
            this.MenuSeparator1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSeparator1.Name = "MenuSeparator1";
            this.MenuSeparator1.Size = new System.Drawing.Size(1, 34);
            // 
            // NewPageMenuItem
            // 
            this.NewPageMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewPageMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Add;
            this.NewPageMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NewPageMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewPageMenuItem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.NewPageMenuItem.Name = "NewPageMenuItem";
            this.NewPageMenuItem.Size = new System.Drawing.Size(28, 28);
            this.NewPageMenuItem.Text = "ノートを追加";
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Remove;
            this.RemoveMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RemoveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveMenuItem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Size = new System.Drawing.Size(28, 28);
            this.RemoveMenuItem.Text = "ノートを削除";
            // 
            // SearchMenuItem
            // 
            this.SearchMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Search;
            this.SearchMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchMenuItem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.SearchMenuItem.Name = "SearchMenuItem";
            this.SearchMenuItem.Size = new System.Drawing.Size(28, 28);
            this.SearchMenuItem.Text = "検索";
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.AutoSize = false;
            this.MenuSeparator2.AutoToolTip = false;
            this.MenuSeparator2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MenuSeparator2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.MenuSeparator2.Enabled = false;
            this.MenuSeparator2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSeparator2.Name = "MenuSeparator2";
            this.MenuSeparator2.Size = new System.Drawing.Size(1, 34);
            // 
            // FontMenuItem
            // 
            this.FontMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FontMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Font;
            this.FontMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FontMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FontMenuItem.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.FontMenuItem.Name = "FontMenuItem";
            this.FontMenuItem.Size = new System.Drawing.Size(28, 28);
            this.FontMenuItem.Text = "フォントの設定";
            // 
            // VerticalSeparator
            // 
            this.VerticalSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VerticalSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalSeparator.Location = new System.Drawing.Point(0, 36);
            this.VerticalSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.VerticalSeparator.Name = "VerticalSeparator";
            this.VerticalSeparator.Size = new System.Drawing.Size(784, 1);
            this.VerticalSeparator.TabIndex = 2;
            this.VerticalSeparator.TabStop = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.LayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "CubeNote";
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ContentsPanel.Panel1.ResumeLayout(false);
            this.ContentsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            this.MenuToolStrip.ResumeLayout(false);
            this.MenuToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSeparator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.SplitContainer ContentsPanel;
        private PageCollectionControl PageCollectionControl;
        private System.Windows.Forms.ToolStrip MenuToolStrip;
        private System.Windows.Forms.ToolStripButton VisibleMenuItem;
        private System.Windows.Forms.ToolStripButton NewPageMenuItem;
        private System.Windows.Forms.ToolStripButton RemoveMenuItem;
        private System.Windows.Forms.ToolStripButton SearchMenuItem;
        private System.Windows.Forms.PictureBox VerticalSeparator;
        private System.Windows.Forms.ToolStripButton FontMenuItem;
        private System.Windows.Forms.ToolStripButton MenuSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSeparator2;
        private TextEditControl TextEditControl;
    }
}

