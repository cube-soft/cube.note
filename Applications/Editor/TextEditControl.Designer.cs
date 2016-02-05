namespace Cube.Note.App.Editor
{
    partial class TextEditControl
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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditControl));
            this.AzukiTextControl = new Sgry.Azuki.WinForms.AzukiControl();
            this.SizeGripControl = new Cube.Forms.SizeGripControl();
            ((System.ComponentModel.ISupportInitialize)(this.SizeGripControl)).BeginInit();
            this.SuspendLayout();
            // 
            // AzukiTextControl
            // 
            this.AzukiTextControl.BackColor = System.Drawing.SystemColors.Window;
            this.AzukiTextControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AzukiTextControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AzukiTextControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AzukiTextControl.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.AzukiTextControl.FirstVisibleLine = 0;
            this.AzukiTextControl.Font = new System.Drawing.Font("メイリオ", 11F);
            fontInfo1.Name = "メイリオ";
            fontInfo1.Size = 11;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.AzukiTextControl.FontInfo = fontInfo1;
            this.AzukiTextControl.ForeColor = System.Drawing.Color.Black;
            this.AzukiTextControl.HighlightsCurrentLine = false;
            this.AzukiTextControl.LeftMargin = 8;
            this.AzukiTextControl.Location = new System.Drawing.Point(0, 0);
            this.AzukiTextControl.Margin = new System.Windows.Forms.Padding(0);
            this.AzukiTextControl.Name = "AzukiTextControl";
            this.AzukiTextControl.ScrollPos = new System.Drawing.Point(0, 0);
            this.AzukiTextControl.ShowsDirtBar = false;
            this.AzukiTextControl.Size = new System.Drawing.Size(150, 150);
            this.AzukiTextControl.TabIndex = 0;
            this.AzukiTextControl.ViewWidth = 130;
            // 
            // SizeGripControl
            // 
            this.SizeGripControl.BackColor = System.Drawing.SystemColors.Control;
            this.SizeGripControl.Image = ((System.Drawing.Image)(resources.GetObject("SizeGripControl.Image")));
            this.SizeGripControl.Location = new System.Drawing.Point(137, 137);
            this.SizeGripControl.Margin = new System.Windows.Forms.Padding(0);
            this.SizeGripControl.Name = "SizeGripControl";
            this.SizeGripControl.Size = new System.Drawing.Size(13, 13);
            this.SizeGripControl.TabIndex = 1;
            this.SizeGripControl.TabStop = false;
            // 
            // TextEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SizeGripControl);
            this.Controls.Add(this.AzukiTextControl);
            this.Name = "TextEditControl";
            ((System.ComponentModel.ISupportInitialize)(this.SizeGripControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sgry.Azuki.WinForms.AzukiControl AzukiTextControl;
        private Cube.Forms.SizeGripControl SizeGripControl;
    }
}
