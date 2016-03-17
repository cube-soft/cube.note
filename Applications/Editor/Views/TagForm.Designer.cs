namespace Cube.Note.App.Editor
{
    partial class TagForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LayoutPanel = new Cube.Forms.TableLayoutPanel();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ExitButtonShadow = new System.Windows.Forms.Panel();
            this.ExitButton = new Cube.Forms.Button();
            this.ApplyButtonShadow = new System.Windows.Forms.Panel();
            this.ApplyButton = new Cube.Forms.Button();
            this.RemoveTagShadow = new System.Windows.Forms.Panel();
            this.RemoveTagButton = new Cube.Forms.Button();
            this.NewTagShadow = new System.Windows.Forms.Panel();
            this.NewTagButton = new Cube.Forms.Button();
            this.NewTagWrapper = new System.Windows.Forms.Panel();
            this.NewTagTextBox = new System.Windows.Forms.TextBox();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.TagsWrapper = new System.Windows.Forms.Panel();
            this.TagsPanel = new Cube.Forms.FlowLayoutPanel();
            this.LayoutPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.ExitButtonShadow.SuspendLayout();
            this.ApplyButtonShadow.SuspendLayout();
            this.RemoveTagShadow.SuspendLayout();
            this.NewTagShadow.SuspendLayout();
            this.NewTagWrapper.SuspendLayout();
            this.TagsWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.ColumnCount = 3;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 0, 3);
            this.LayoutPanel.Controls.Add(this.RemoveTagShadow, 2, 2);
            this.LayoutPanel.Controls.Add(this.NewTagShadow, 1, 2);
            this.LayoutPanel.Controls.Add(this.NewTagWrapper, 0, 2);
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.TagsWrapper, 0, 1);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 4;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(448, 298);
            this.LayoutPanel.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.SetColumnSpan(this.ButtonsPanel, 3);
            this.ButtonsPanel.Controls.Add(this.ExitButtonShadow);
            this.ButtonsPanel.Controls.Add(this.ApplyButtonShadow);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 238);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ButtonsPanel.Size = new System.Drawing.Size(448, 60);
            this.ButtonsPanel.TabIndex = 13;
            // 
            // ExitButtonShadow
            // 
            this.ExitButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ExitButtonShadow.Controls.Add(this.ExitButton);
            this.ExitButtonShadow.Location = new System.Drawing.Point(322, 13);
            this.ExitButtonShadow.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.ExitButtonShadow.Name = "ExitButtonShadow";
            this.ExitButtonShadow.Size = new System.Drawing.Size(110, 37);
            this.ExitButtonShadow.TabIndex = 4;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(0, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(110, 35);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "キャンセル";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // ApplyButtonShadow
            // 
            this.ApplyButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ApplyButtonShadow.Controls.Add(this.ApplyButton);
            this.ApplyButtonShadow.Location = new System.Drawing.Point(186, 13);
            this.ApplyButtonShadow.Name = "ApplyButtonShadow";
            this.ApplyButtonShadow.Size = new System.Drawing.Size(130, 37);
            this.ApplyButtonShadow.TabIndex = 5;
            // 
            // ApplyButton
            // 
            this.ApplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ApplyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ApplyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.ForeColor = System.Drawing.Color.White;
            this.ApplyButton.Location = new System.Drawing.Point(0, 0);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(0);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(130, 35);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "OK";
            this.ApplyButton.UseVisualStyleBackColor = false;
            // 
            // RemoveTagShadow
            // 
            this.RemoveTagShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.RemoveTagShadow.Controls.Add(this.RemoveTagButton);
            this.RemoveTagShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveTagShadow.Location = new System.Drawing.Point(331, 206);
            this.RemoveTagShadow.Margin = new System.Windows.Forms.Padding(3, 8, 16, 3);
            this.RemoveTagShadow.Name = "RemoveTagShadow";
            this.RemoveTagShadow.Size = new System.Drawing.Size(101, 27);
            this.RemoveTagShadow.TabIndex = 12;
            // 
            // RemoveTagButton
            // 
            this.RemoveTagButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RemoveTagButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveTagButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RemoveTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveTagButton.ForeColor = System.Drawing.Color.White;
            this.RemoveTagButton.Location = new System.Drawing.Point(0, 0);
            this.RemoveTagButton.Margin = new System.Windows.Forms.Padding(0);
            this.RemoveTagButton.Name = "RemoveTagButton";
            this.RemoveTagButton.Size = new System.Drawing.Size(101, 25);
            this.RemoveTagButton.TabIndex = 5;
            this.RemoveTagButton.Text = "タグを削除";
            this.RemoveTagButton.UseVisualStyleBackColor = false;
            // 
            // NewTagShadow
            // 
            this.NewTagShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.NewTagShadow.Controls.Add(this.NewTagButton);
            this.NewTagShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewTagShadow.Location = new System.Drawing.Point(201, 206);
            this.NewTagShadow.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.NewTagShadow.Name = "NewTagShadow";
            this.NewTagShadow.Size = new System.Drawing.Size(124, 27);
            this.NewTagShadow.TabIndex = 11;
            // 
            // NewTagButton
            // 
            this.NewTagButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.NewTagButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewTagButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.NewTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewTagButton.ForeColor = System.Drawing.Color.White;
            this.NewTagButton.Location = new System.Drawing.Point(0, 0);
            this.NewTagButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewTagButton.Name = "NewTagButton";
            this.NewTagButton.Size = new System.Drawing.Size(124, 25);
            this.NewTagButton.TabIndex = 4;
            this.NewTagButton.Text = "新しいタグを追加";
            this.NewTagButton.UseVisualStyleBackColor = false;
            // 
            // NewTagWrapper
            // 
            this.NewTagWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewTagWrapper.Controls.Add(this.NewTagTextBox);
            this.NewTagWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewTagWrapper.Location = new System.Drawing.Point(16, 206);
            this.NewTagWrapper.Margin = new System.Windows.Forms.Padding(16, 8, 3, 3);
            this.NewTagWrapper.Name = "NewTagWrapper";
            this.NewTagWrapper.Size = new System.Drawing.Size(179, 25);
            this.NewTagWrapper.TabIndex = 10;
            // 
            // NewTagTextBox
            // 
            this.NewTagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewTagTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewTagTextBox.Location = new System.Drawing.Point(0, 0);
            this.NewTagTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NewTagTextBox.Name = "NewTagTextBox";
            this.NewTagTextBox.Size = new System.Drawing.Size(177, 16);
            this.NewTagTextBox.TabIndex = 3;
            // 
            // TitleControl
            // 
            this.TitleControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.LayoutPanel.SetColumnSpan(this.TitleControl, 3);
            this.TitleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleControl.Location = new System.Drawing.Point(0, 0);
            this.TitleControl.Margin = new System.Windows.Forms.Padding(0);
            this.TitleControl.MaximizeBox = true;
            this.TitleControl.MinimizeBox = true;
            this.TitleControl.Name = "TitleControl";
            this.TitleControl.Size = new System.Drawing.Size(448, 30);
            this.TitleControl.TabIndex = 1;
            // 
            // TagsWrapper
            // 
            this.TagsWrapper.AutoScroll = true;
            this.LayoutPanel.SetColumnSpan(this.TagsWrapper, 3);
            this.TagsWrapper.Controls.Add(this.TagsPanel);
            this.TagsWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagsWrapper.Location = new System.Drawing.Point(3, 33);
            this.TagsWrapper.Name = "TagsWrapper";
            this.TagsWrapper.Padding = new System.Windows.Forms.Padding(12, 12, 12, 0);
            this.TagsWrapper.Size = new System.Drawing.Size(442, 162);
            this.TagsWrapper.TabIndex = 14;
            // 
            // TagsPanel
            // 
            this.TagsPanel.AutoSize = true;
            this.TagsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TagsPanel.Location = new System.Drawing.Point(12, 12);
            this.TagsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TagsPanel.Name = "TagsPanel";
            this.TagsPanel.Size = new System.Drawing.Size(418, 0);
            this.TagsPanel.TabIndex = 3;
            // 
            // TagForm
            // 
            this.AcceptButton = this.NewTagButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.LayoutPanel);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 180);
            this.Name = "TagForm";
            this.ShowInTaskbar = false;
            this.Sizable = true;
            this.Text = "タグの編集";
            this.LayoutPanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.ExitButtonShadow.ResumeLayout(false);
            this.ApplyButtonShadow.ResumeLayout(false);
            this.RemoveTagShadow.ResumeLayout(false);
            this.NewTagShadow.ResumeLayout(false);
            this.NewTagWrapper.ResumeLayout(false);
            this.NewTagWrapper.PerformLayout();
            this.TagsWrapper.ResumeLayout(false);
            this.TagsWrapper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private System.Windows.Forms.Panel NewTagWrapper;
        private System.Windows.Forms.TextBox NewTagTextBox;
        private System.Windows.Forms.Panel NewTagShadow;
        private Forms.Button NewTagButton;
        private System.Windows.Forms.Panel RemoveTagShadow;
        private Forms.Button RemoveTagButton;
        private Forms.FlowLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Panel ExitButtonShadow;
        private Forms.Button ExitButton;
        private System.Windows.Forms.Panel ApplyButtonShadow;
        private Forms.Button ApplyButton;
        private System.Windows.Forms.Panel TagsWrapper;
        private Forms.FlowLayoutPanel TagsPanel;
    }
}