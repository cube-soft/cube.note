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
            Sgry.Azuki.Document document1 = new Sgry.Azuki.Document();
            Sgry.Azuki.DefaultWordProc defaultWordProc1 = new Sgry.Azuki.DefaultWordProc();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.ContentsPanel = new Cube.Forms.SplitContainer();
            this.PageCollectionControl = new Cube.Note.App.Editor.PageCollectionControl();
            this.TextEditControl = new Cube.Note.App.Editor.TextEditControl();
            this.MenuToolStrip = new System.Windows.Forms.ToolStrip();
            this.VisibleMenuItem = new System.Windows.Forms.ToolStripButton();
            this.MenuSeparator1 = new System.Windows.Forms.ToolStripButton();
            this.NewPageMenuItem = new System.Windows.Forms.ToolStripButton();
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripButton();
            this.MenuSeparator2 = new System.Windows.Forms.ToolStripButton();
            this.SearchMenuItem = new System.Windows.Forms.ToolStripButton();
            this.MenuSeparator3 = new System.Windows.Forms.ToolStripButton();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripButton();
            this.LogoMenuItem = new System.Windows.Forms.ToolStripButton();
            this.VerticalSeparator = new System.Windows.Forms.PictureBox();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
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
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.ColumnCount = 1;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.ContentsPanel, 0, 3);
            this.LayoutPanel.Controls.Add(this.MenuToolStrip, 0, 1);
            this.LayoutPanel.Controls.Add(this.VerticalSeparator, 0, 2);
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 4;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(782, 459);
            this.LayoutPanel.TabIndex = 2;
            // 
            // ContentsPanel
            // 
            this.ContentsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ContentsPanel.Location = new System.Drawing.Point(0, 63);
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
            this.ContentsPanel.Size = new System.Drawing.Size(782, 396);
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
            this.PageCollectionControl.Size = new System.Drawing.Size(250, 396);
            this.PageCollectionControl.TabIndex = 0;
            // 
            // TextEditControl
            // 
            this.TextEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
            document1.Capacity = 5120;
            document1.EolCode = "\r\n";
            document1.Highlighter = null;
            document1.IsDirty = false;
            document1.IsReadOnly = false;
            document1.IsRecordingHistory = true;
            document1.MarksUri = false;
            document1.RectSelectRanges = null;
            document1.SelectionMode = Sgry.Azuki.TextDataType.Normal;
            document1.Tag = null;
            document1.Text = "";
            defaultWordProc1.CharsForbiddenToEndLine = new char[] {
        '(',
        '[',
        '{',
        '«',
        '—',
        '‘',
        '“',
        '‥',
        '…',
        '〈',
        '《',
        '「',
        '『',
        '【',
        '〔',
        '〖',
        '〘',
        '〚',
        '〝',
        '〳',
        '〴',
        '（',
        '［',
        '｛',
        '｟'};
            defaultWordProc1.CharsForbiddenToStartLine = new char[] {
        ')',
        ',',
        '.',
        ':',
        ';',
        ']',
        '»',
        '‐',
        '–',
        '’',
        '”',
        '、',
        '。',
        '々',
        '〉',
        '》',
        '」',
        '』',
        '】',
        '〕',
        '〗',
        '〙',
        '〛',
        '〜',
        '〟',
        '〵',
        '〻',
        'ぁ',
        'ぃ',
        'ぅ',
        'ぇ',
        'ぉ',
        'っ',
        'ゃ',
        'ゅ',
        'ょ',
        'ゎ',
        'ゕ',
        'ゖ',
        '゠',
        'ァ',
        'ィ',
        'ゥ',
        'ェ',
        'ォ',
        'ッ',
        'ャ',
        'ュ',
        'ョ',
        'ヮ',
        'ヵ',
        'ヶ',
        '・',
        'ー',
        'ヽ',
        'ヾ',
        'ㇰ',
        'ㇱ',
        'ㇲ',
        'ㇳ',
        'ㇴ',
        'ㇵ',
        'ㇶ',
        'ㇷ',
        'ㇸ',
        'ㇹ',
        'ㇺ',
        'ㇻ',
        'ㇼ',
        'ㇽ',
        'ㇾ',
        'ㇿ',
        '）',
        '，',
        '－',
        '：',
        '；',
        '＝',
        '］',
        '｝',
        '｠'};
            defaultWordProc1.CharsToBeHanged = new char[] {
        ',',
        '.',
        '、',
        '。',
        '，',
        '．'};
            defaultWordProc1.EnableCharacterHanging = true;
            defaultWordProc1.EnableEolHanging = true;
            defaultWordProc1.EnableLineEndRestriction = true;
            defaultWordProc1.EnableLineHeadRestriction = true;
            defaultWordProc1.EnableWordWrap = true;
            defaultWordProc1.KinsokuDepth = 8;
            document1.WordProc = defaultWordProc1;
            this.TextEditControl.Document = document1;
            this.TextEditControl.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.TextEditControl.Location = new System.Drawing.Point(0, 0);
            this.TextEditControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextEditControl.Name = "TextEditControl";
            this.TextEditControl.Size = new System.Drawing.Size(531, 396);
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
            this.MenuSeparator2,
            this.SearchMenuItem,
            this.MenuSeparator3,
            this.SettingsMenuItem,
            this.LogoMenuItem});
            this.MenuToolStrip.Location = new System.Drawing.Point(0, 30);
            this.MenuToolStrip.Name = "MenuToolStrip";
            this.MenuToolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.MenuToolStrip.Size = new System.Drawing.Size(782, 32);
            this.MenuToolStrip.TabIndex = 0;
            this.MenuToolStrip.Text = "メニュー";
            // 
            // VisibleMenuItem
            // 
            this.VisibleMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.VisibleMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Left;
            this.VisibleMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VisibleMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VisibleMenuItem.Margin = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.VisibleMenuItem.Name = "VisibleMenuItem";
            this.VisibleMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.VisibleMenuItem.Size = new System.Drawing.Size(44, 30);
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
            this.NewPageMenuItem.Margin = new System.Windows.Forms.Padding(6, 1, 1, 1);
            this.NewPageMenuItem.Name = "NewPageMenuItem";
            this.NewPageMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.NewPageMenuItem.Size = new System.Drawing.Size(44, 30);
            this.NewPageMenuItem.Text = "ノートを追加";
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Remove;
            this.RemoveMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RemoveMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveMenuItem.Margin = new System.Windows.Forms.Padding(1, 1, 6, 1);
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.RemoveMenuItem.Size = new System.Drawing.Size(44, 30);
            this.RemoveMenuItem.Text = "ノートを削除";
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
            this.MenuSeparator2.Size = new System.Drawing.Size(1, 29);
            // 
            // SearchMenuItem
            // 
            this.SearchMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Search;
            this.SearchMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SearchMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchMenuItem.Margin = new System.Windows.Forms.Padding(6, 1, 6, 1);
            this.SearchMenuItem.Name = "SearchMenuItem";
            this.SearchMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.SearchMenuItem.Size = new System.Drawing.Size(44, 30);
            this.SearchMenuItem.Text = "検索";
            // 
            // MenuSeparator3
            // 
            this.MenuSeparator3.AutoSize = false;
            this.MenuSeparator3.AutoToolTip = false;
            this.MenuSeparator3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MenuSeparator3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.MenuSeparator3.Enabled = false;
            this.MenuSeparator3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuSeparator3.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSeparator3.Name = "MenuSeparator3";
            this.MenuSeparator3.Size = new System.Drawing.Size(1, 34);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SettingsMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Settings;
            this.SettingsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SettingsMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsMenuItem.Margin = new System.Windows.Forms.Padding(1, 1, 2, 1);
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.SettingsMenuItem.Size = new System.Drawing.Size(44, 30);
            this.SettingsMenuItem.Text = "設定";
            // 
            // LogoMenuItem
            // 
            this.LogoMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LogoMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LogoMenuItem.Image = global::Cube.Note.App.Editor.Properties.Resources.Logo;
            this.LogoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LogoMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogoMenuItem.Margin = new System.Windows.Forms.Padding(1);
            this.LogoMenuItem.Name = "LogoMenuItem";
            this.LogoMenuItem.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.LogoMenuItem.Size = new System.Drawing.Size(44, 30);
            this.LogoMenuItem.Text = "Web ページ";
            // 
            // VerticalSeparator
            // 
            this.VerticalSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VerticalSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalSeparator.Location = new System.Drawing.Point(0, 62);
            this.VerticalSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.VerticalSeparator.Name = "VerticalSeparator";
            this.VerticalSeparator.Size = new System.Drawing.Size(782, 1);
            this.VerticalSeparator.TabIndex = 2;
            this.VerticalSeparator.TabStop = false;
            // 
            // TitleControl
            // 
            this.TitleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleControl.Location = new System.Drawing.Point(0, 0);
            this.TitleControl.Margin = new System.Windows.Forms.Padding(0);
            this.TitleControl.Name = "TitleControl";
            this.TitleControl.Size = new System.Drawing.Size(782, 30);
            this.TitleControl.TabIndex = 4;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.LayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Sizable = true;
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

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private Cube.Forms.SplitContainer ContentsPanel;
        private PageCollectionControl PageCollectionControl;
        private System.Windows.Forms.ToolStrip MenuToolStrip;
        private System.Windows.Forms.ToolStripButton VisibleMenuItem;
        private System.Windows.Forms.ToolStripButton NewPageMenuItem;
        private System.Windows.Forms.ToolStripButton RemoveMenuItem;
        private System.Windows.Forms.ToolStripButton SearchMenuItem;
        private System.Windows.Forms.PictureBox VerticalSeparator;
        private System.Windows.Forms.ToolStripButton SettingsMenuItem;
        private System.Windows.Forms.ToolStripButton MenuSeparator1;
        private System.Windows.Forms.ToolStripButton MenuSeparator3;
        private TextEditControl TextEditControl;
        private System.Windows.Forms.ToolStripButton MenuSeparator2;
        private System.Windows.Forms.ToolStripButton LogoMenuItem;
        private TitleControl TitleControl;
    }
}

