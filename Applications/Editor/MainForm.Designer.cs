﻿namespace Cube.Note.App.Editor
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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.ContentsPanel = new System.Windows.Forms.SplitContainer();
            this.PageCollectionControl = new Cube.Note.App.Editor.PageCollectionControl();
            this.SizeGripControl = new Cube.Forms.SizeGripControl();
            this.TextControl = new Cube.Note.App.Editor.TextControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.SizeGripControl)).BeginInit();
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
            this.ContentsPanel.IsSplitterFixed = true;
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
            this.ContentsPanel.Panel2.Controls.Add(this.SizeGripControl);
            this.ContentsPanel.Panel2.Controls.Add(this.TextControl);
            this.ContentsPanel.Size = new System.Drawing.Size(782, 396);
            this.ContentsPanel.SplitterDistance = 270;
            this.ContentsPanel.SplitterWidth = 1;
            this.ContentsPanel.TabIndex = 3;
            // 
            // PageCollectionControl
            // 
            this.PageCollectionControl.BackColor = System.Drawing.SystemColors.Window;
            this.PageCollectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageCollectionControl.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PageCollectionControl.Location = new System.Drawing.Point(0, 0);
            this.PageCollectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.PageCollectionControl.Name = "PageCollectionControl";
            this.PageCollectionControl.Size = new System.Drawing.Size(270, 396);
            this.PageCollectionControl.TabIndex = 0;
            // 
            // SizeGripControl
            // 
            this.SizeGripControl.BackColor = System.Drawing.SystemColors.Control;
            this.SizeGripControl.Image = ((System.Drawing.Image)(resources.GetObject("SizeGripControl.Image")));
            this.SizeGripControl.Location = new System.Drawing.Point(495, 380);
            this.SizeGripControl.Margin = new System.Windows.Forms.Padding(0);
            this.SizeGripControl.Name = "SizeGripControl";
            this.SizeGripControl.Size = new System.Drawing.Size(16, 16);
            this.SizeGripControl.TabIndex = 1;
            this.SizeGripControl.TabStop = false;
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
            this.TextControl.Location = new System.Drawing.Point(0, 0);
            this.TextControl.Margin = new System.Windows.Forms.Padding(0);
            this.TextControl.Name = "TextControl";
            this.TextControl.ScrollPos = new System.Drawing.Point(0, 0);
            this.TextControl.Size = new System.Drawing.Size(511, 396);
            this.TextControl.TabIndex = 0;
            this.TextControl.ViewWidth = 104;
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
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.LayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.Sizable = true;
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            this.ContentsPanel.Panel1.ResumeLayout(false);
            this.ContentsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentsPanel)).EndInit();
            this.ContentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SizeGripControl)).EndInit();
            this.MenuToolStrip.ResumeLayout(false);
            this.MenuToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSeparator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.SplitContainer ContentsPanel;
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
        private System.Windows.Forms.ToolStripButton MenuSeparator2;
        private System.Windows.Forms.ToolStripButton LogoMenuItem;
        private TitleControl TitleControl;
        private TextControl TextControl;
        private Forms.SizeGripControl SizeGripControl;
    }
}

