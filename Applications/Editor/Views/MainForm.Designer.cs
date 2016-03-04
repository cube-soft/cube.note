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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.ContentsPanel = new System.Windows.Forms.SplitContainer();
            this.PageCollectionControl = new Cube.Note.App.Editor.PageCollectionControl();
            this.RightContentsPanel = new Cube.Forms.TableLayoutPanel();
            this.TextControl = new Cube.Note.App.Editor.TextControl();
            this.VerticalSeparator = new System.Windows.Forms.PictureBox();
            this.MenuControl = new Cube.Note.App.Editor.MenuControl();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.FooterStatusControl = new Cube.Note.App.Editor.StatusControl();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).BeginInit();
            this.ContentsPanel.Panel1.SuspendLayout();
            this.ContentsPanel.Panel2.SuspendLayout();
            this.ContentsPanel.SuspendLayout();
            this.RightContentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSeparator)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 1);
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.FooterStatusControl, 0, 2);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(782, 459);
            this.LayoutPanel.TabIndex = 2;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ContentsPanel.IsSplitterFixed = true;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 30);
            this.ContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentsPanel.Name = "ContentsPanel";
            // 
            // ContentsPanel.Panel1
            // 
            this.ContentsPanel.Panel1.Controls.Add(this.PageCollectionControl);
            // 
            // ContentsPanel.Panel2
            // 
            this.ContentsPanel.Panel2.Controls.Add(this.RightContentsPanel);
            this.ContentsPanel.Size = new System.Drawing.Size(782, 407);
            this.ContentsPanel.SplitterDistance = 270;
            this.ContentsPanel.SplitterWidth = 1;
            this.ContentsPanel.TabIndex = 3;
            // 
            // PageCollectionControl
            // 
            this.PageCollectionControl.Aggregator = null;
            this.PageCollectionControl.BackColor = System.Drawing.SystemColors.Window;
            this.PageCollectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageCollectionControl.Location = new System.Drawing.Point(0, 0);
            this.PageCollectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.PageCollectionControl.Name = "PageCollectionControl";
            this.PageCollectionControl.Size = new System.Drawing.Size(270, 407);
            this.PageCollectionControl.TabIndex = 0;
            // 
            // RightContentsPanel
            // 
            this.RightContentsPanel.ColumnCount = 1;
            this.RightContentsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightContentsPanel.Controls.Add(this.TextControl, 0, 2);
            this.RightContentsPanel.Controls.Add(this.VerticalSeparator, 0, 1);
            this.RightContentsPanel.Controls.Add(this.MenuControl, 0, 0);
            this.RightContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightContentsPanel.Location = new System.Drawing.Point(0, 0);
            this.RightContentsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightContentsPanel.Name = "RightContentsPanel";
            this.RightContentsPanel.RowCount = 3;
            this.RightContentsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.RightContentsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.RightContentsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightContentsPanel.Size = new System.Drawing.Size(511, 407);
            this.RightContentsPanel.TabIndex = 0;
            // 
            // TextControl
            // 
            this.TextControl.BackColor = System.Drawing.SystemColors.Window;
            this.TextControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextControl.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.TextControl.FirstVisibleLine = 0;
            this.TextControl.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo1.Name = "MS UI Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.TextControl.FontInfo = fontInfo1;
            this.TextControl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextControl.LeftMargin = 8;
            this.TextControl.Location = new System.Drawing.Point(0, 33);
            this.TextControl.Margin = new System.Windows.Forms.Padding(0);
            this.TextControl.Name = "TextControl";
            this.TextControl.ScrollPos = new System.Drawing.Point(0, 0);
            this.TextControl.Size = new System.Drawing.Size(511, 374);
            this.TextControl.Status = null;
            this.TextControl.TabIndex = 1;
            this.TextControl.TopMargin = 6;
            this.TextControl.ViewWidth = 104;
            this.TextControl.WordWrapCount = -1;
            // 
            // VerticalSeparator
            // 
            this.VerticalSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.VerticalSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalSeparator.Location = new System.Drawing.Point(0, 32);
            this.VerticalSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.VerticalSeparator.Name = "VerticalSeparator";
            this.VerticalSeparator.Size = new System.Drawing.Size(511, 1);
            this.VerticalSeparator.TabIndex = 3;
            this.VerticalSeparator.TabStop = false;
            // 
            // MenuControl
            // 
            this.MenuControl.BackColor = System.Drawing.SystemColors.Control;
            this.MenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuControl.Location = new System.Drawing.Point(0, 0);
            this.MenuControl.Name = "MenuControl";
            this.MenuControl.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.MenuControl.Size = new System.Drawing.Size(511, 32);
            this.MenuControl.TabIndex = 4;
            this.MenuControl.Text = "menuControl1";
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
            this.TitleControl.Size = new System.Drawing.Size(782, 30);
            this.TitleControl.TabIndex = 4;
            // 
            // FooterStatusControl
            // 
            this.FooterStatusControl.ColumnNumber = 0;
            this.FooterStatusControl.Count = 0;
            this.FooterStatusControl.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FooterStatusControl.GripMargin = new System.Windows.Forms.Padding(0);
            this.FooterStatusControl.LineCount = 0;
            this.FooterStatusControl.LineNumber = 0;
            this.FooterStatusControl.Location = new System.Drawing.Point(0, 437);
            this.FooterStatusControl.Message = "";
            this.FooterStatusControl.Name = "FooterStatusControl";
            this.FooterStatusControl.Size = new System.Drawing.Size(782, 22);
            this.FooterStatusControl.TabIndex = 5;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.LayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.Sizable = true;
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ContentsPanel.Panel1.ResumeLayout(false);
            this.ContentsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            this.RightContentsPanel.ResumeLayout(false);
            this.RightContentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSeparator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.SplitContainer ContentsPanel;
        private PageCollectionControl PageCollectionControl;
        private TitleControl TitleControl;
        private Cube.Forms.TableLayoutPanel RightContentsPanel;
        private TextControl TextControl;
        private System.Windows.Forms.PictureBox VerticalSeparator;
        private StatusControl FooterStatusControl;
        private MenuControl MenuControl;
    }
}

