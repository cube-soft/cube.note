namespace Cube.Note.App.Editor
{
    partial class TitleControl
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
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.TitlePictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ExitButton = new Cube.Forms.Button();
            this.MaximizeButton = new Cube.Forms.Button();
            this.MinimizeButton = new Cube.Forms.Button();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 1, 0);
            this.LayoutPanel.Controls.Add(this.TitlePictureBox, 0, 0);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.Size = new System.Drawing.Size(400, 30);
            this.LayoutPanel.TabIndex = 0;
            // 
            // TitlePictureBox
            // 
            this.TitlePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitlePictureBox.Image = global::Cube.Note.App.Editor.Properties.Resources.Title;
            this.TitlePictureBox.Location = new System.Drawing.Point(0, 0);
            this.TitlePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.TitlePictureBox.Name = "TitlePictureBox";
            this.TitlePictureBox.Size = new System.Drawing.Size(120, 30);
            this.TitlePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TitlePictureBox.TabIndex = 0;
            this.TitlePictureBox.TabStop = false;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.ExitButton);
            this.ButtonsPanel.Controls.Add(this.MaximizeButton);
            this.ButtonsPanel.Controls.Add(this.MinimizeButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(120, 0);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(280, 30);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Close;
            this.ExitButton.Location = new System.Drawing.Point(250, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 30);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Maximize;
            this.MaximizeButton.Location = new System.Drawing.Point(204, 0);
            this.MaximizeButton.Margin = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(30, 30);
            this.MaximizeButton.TabIndex = 1;
            this.MaximizeButton.UseVisualStyleBackColor = false;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Image = global::Cube.Note.App.Editor.Properties.Resources.Minimize;
            this.MinimizeButton.Location = new System.Drawing.Point(158, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            // 
            // TitleControl
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.Controls.Add(this.LayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TitleControl";
            this.Size = new System.Drawing.Size(400, 30);
            this.LayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TitlePictureBox)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private Cube.Forms.FlowLayoutPanel ButtonsPanel;
        private Cube.Forms.Button ExitButton;
        private Cube.Forms.Button MaximizeButton;
        private Cube.Forms.Button MinimizeButton;
        private System.Windows.Forms.PictureBox TitlePictureBox;
    }
}
