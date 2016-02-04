﻿namespace Cube.Note.App.Editor
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
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new Cube.Forms.Button();
            this.PageCollectionControl = new Cube.Note.App.Editor.PageCollectionControl();
            this.Separator1 = new System.Windows.Forms.PictureBox();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.Controls.Add(this.KeywordTextBox, 0, 0);
            this.LayoutPanel.Controls.Add(this.SearchButton, 1, 0);
            this.LayoutPanel.Controls.Add(this.PageCollectionControl, 0, 2);
            this.LayoutPanel.Controls.Add(this.Separator1, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 3;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(200, 300);
            this.LayoutPanel.TabIndex = 0;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeywordTextBox.Location = new System.Drawing.Point(4, 3);
            this.KeywordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(164, 23);
            this.KeywordTextBox.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Search;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SearchButton.Location = new System.Drawing.Point(168, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(32, 32);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.UseVisualStyleBackColor = false;
            // 
            // PageCollectionControl
            // 
            this.PageCollectionControl.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.SetColumnSpan(this.PageCollectionControl, 2);
            this.PageCollectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageCollectionControl.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PageCollectionControl.Location = new System.Drawing.Point(0, 33);
            this.PageCollectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.PageCollectionControl.Name = "PageCollectionControl";
            this.PageCollectionControl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.PageCollectionControl.Size = new System.Drawing.Size(200, 267);
            this.PageCollectionControl.TabIndex = 5;
            // 
            // Separator1
            // 
            this.Separator1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LayoutPanel.SetColumnSpan(this.Separator1, 2);
            this.Separator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Separator1.Location = new System.Drawing.Point(0, 32);
            this.Separator1.Margin = new System.Windows.Forms.Padding(0);
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(200, 1);
            this.Separator1.TabIndex = 6;
            this.Separator1.TabStop = false;
            // 
            // SearchControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LayoutPanel);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(200, 300);
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Separator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private Cube.Forms.Button SearchButton;
        private PageCollectionControl PageCollectionControl;
        private System.Windows.Forms.PictureBox Separator1;
    }
}