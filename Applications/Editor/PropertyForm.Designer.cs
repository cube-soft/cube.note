namespace Cube.Note.App.Editor
{
    partial class PropertyForm
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
            this.NewTagButton = new Cube.Forms.Button();
            this.TitleControl = new Cube.Note.App.Editor.TitleControl();
            this.TagsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ButtonsPanel = new Cube.Forms.FlowLayoutPanel();
            this.ExitButtonShadow = new System.Windows.Forms.Panel();
            this.ExitButton = new Cube.Forms.Button();
            this.ApplyButtonShadow = new System.Windows.Forms.Panel();
            this.ApplyButton = new Cube.Forms.Button();
            this.AbstractLabel = new System.Windows.Forms.Label();
            this.CreationLabel = new System.Windows.Forms.Label();
            this.LastUpdateLabel = new System.Windows.Forms.Label();
            this.NewTagWrapper = new System.Windows.Forms.Panel();
            this.NewTagTextBox = new System.Windows.Forms.TextBox();
            this.LayoutPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.ExitButtonShadow.SuspendLayout();
            this.ApplyButtonShadow.SuspendLayout();
            this.NewTagWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.LayoutPanel.Controls.Add(this.NewTagButton, 1, 5);
            this.LayoutPanel.Controls.Add(this.TitleControl, 0, 0);
            this.LayoutPanel.Controls.Add(this.TagsPanel, 0, 4);
            this.LayoutPanel.Controls.Add(this.ButtonsPanel, 0, 6);
            this.LayoutPanel.Controls.Add(this.AbstractLabel, 0, 1);
            this.LayoutPanel.Controls.Add(this.CreationLabel, 0, 2);
            this.LayoutPanel.Controls.Add(this.LastUpdateLabel, 0, 3);
            this.LayoutPanel.Controls.Add(this.NewTagWrapper, 0, 5);
            this.LayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 7;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LayoutPanel.Size = new System.Drawing.Size(398, 348);
            this.LayoutPanel.TabIndex = 0;
            // 
            // NewTagButton
            // 
            this.NewTagButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(39)))), ((int)(((byte)(45)))));
            this.NewTagButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewTagButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.NewTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewTagButton.ForeColor = System.Drawing.Color.White;
            this.NewTagButton.Location = new System.Drawing.Point(261, 251);
            this.NewTagButton.Margin = new System.Windows.Forms.Padding(3, 3, 16, 0);
            this.NewTagButton.Name = "NewTagButton";
            this.NewTagButton.Size = new System.Drawing.Size(121, 25);
            this.NewTagButton.TabIndex = 8;
            this.NewTagButton.Text = "新しいタグを追加";
            this.NewTagButton.UseVisualStyleBackColor = false;
            // 
            // TitleControl
            // 
            this.TitleControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.LayoutPanel.SetColumnSpan(this.TitleControl, 2);
            this.TitleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleControl.Location = new System.Drawing.Point(0, 0);
            this.TitleControl.Margin = new System.Windows.Forms.Padding(0);
            this.TitleControl.MaximizeBox = true;
            this.TitleControl.MinimizeBox = true;
            this.TitleControl.Name = "TitleControl";
            this.TitleControl.Size = new System.Drawing.Size(398, 30);
            this.TitleControl.TabIndex = 0;
            // 
            // TagsPanel
            // 
            this.TagsPanel.AutoScroll = true;
            this.LayoutPanel.SetColumnSpan(this.TagsPanel, 2);
            this.TagsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagsPanel.Location = new System.Drawing.Point(0, 128);
            this.TagsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TagsPanel.Name = "TagsPanel";
            this.TagsPanel.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.TagsPanel.Size = new System.Drawing.Size(398, 120);
            this.TagsPanel.TabIndex = 2;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.SetColumnSpan(this.ButtonsPanel, 2);
            this.ButtonsPanel.Controls.Add(this.ExitButtonShadow);
            this.ButtonsPanel.Controls.Add(this.ApplyButtonShadow);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 288);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ButtonsPanel.Size = new System.Drawing.Size(398, 60);
            this.ButtonsPanel.TabIndex = 3;
            // 
            // ExitButtonShadow
            // 
            this.ExitButtonShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.ExitButtonShadow.Controls.Add(this.ExitButton);
            this.ExitButtonShadow.Location = new System.Drawing.Point(272, 13);
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
            this.ApplyButtonShadow.Location = new System.Drawing.Point(136, 13);
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
            // AbstractLabel
            // 
            this.AbstractLabel.AutoEllipsis = true;
            this.LayoutPanel.SetColumnSpan(this.AbstractLabel, 2);
            this.AbstractLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AbstractLabel.Location = new System.Drawing.Point(0, 30);
            this.AbstractLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AbstractLabel.Name = "AbstractLabel";
            this.AbstractLabel.Padding = new System.Windows.Forms.Padding(16, 12, 16, 4);
            this.AbstractLabel.Size = new System.Drawing.Size(398, 50);
            this.AbstractLabel.TabIndex = 4;
            this.AbstractLabel.Text = "ノートの概要を表示します";
            this.AbstractLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // CreationLabel
            // 
            this.LayoutPanel.SetColumnSpan(this.CreationLabel, 2);
            this.CreationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreationLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CreationLabel.Location = new System.Drawing.Point(0, 80);
            this.CreationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CreationLabel.Name = "CreationLabel";
            this.CreationLabel.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.CreationLabel.Size = new System.Drawing.Size(398, 20);
            this.CreationLabel.TabIndex = 5;
            this.CreationLabel.Text = "2016/01/01 23:59 作成";
            this.CreationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LastUpdateLabel
            // 
            this.LayoutPanel.SetColumnSpan(this.LastUpdateLabel, 2);
            this.LastUpdateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LastUpdateLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LastUpdateLabel.Location = new System.Drawing.Point(0, 100);
            this.LastUpdateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LastUpdateLabel.Name = "LastUpdateLabel";
            this.LastUpdateLabel.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.LastUpdateLabel.Size = new System.Drawing.Size(398, 28);
            this.LastUpdateLabel.TabIndex = 6;
            this.LastUpdateLabel.Text = "2016/02/15 12:29 更新";
            // 
            // NewTagWrapper
            // 
            this.NewTagWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewTagWrapper.Controls.Add(this.NewTagTextBox);
            this.NewTagWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            this.NewTagWrapper.Location = new System.Drawing.Point(16, 251);
            this.NewTagWrapper.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.NewTagWrapper.Name = "NewTagWrapper";
            this.NewTagWrapper.Size = new System.Drawing.Size(239, 25);
            this.NewTagWrapper.TabIndex = 9;
            // 
            // NewTagTextBox
            // 
            this.NewTagTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NewTagTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewTagTextBox.Location = new System.Drawing.Point(0, 1);
            this.NewTagTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NewTagTextBox.Name = "NewTagTextBox";
            this.NewTagTextBox.Size = new System.Drawing.Size(239, 16);
            this.NewTagTextBox.TabIndex = 8;
            // 
            // PropertyForm
            // 
            this.AcceptButton = this.ApplyButton;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(157)))));
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.LayoutPanel);
            this.MaximizeBox = true;
            this.Name = "PropertyForm";
            this.Sizable = true;
            this.Text = "PropertyForm";
            this.LayoutPanel.ResumeLayout(false);
            this.ButtonsPanel.ResumeLayout(false);
            this.ExitButtonShadow.ResumeLayout(false);
            this.ApplyButtonShadow.ResumeLayout(false);
            this.NewTagWrapper.ResumeLayout(false);
            this.NewTagWrapper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Cube.Forms.TableLayoutPanel LayoutPanel;
        private TitleControl TitleControl;
        private Cube.Forms.FlowLayoutPanel TagsPanel;
        private Cube.Forms.FlowLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Panel ExitButtonShadow;
        private Cube.Forms.Button ExitButton;
        private System.Windows.Forms.Panel ApplyButtonShadow;
        private Cube.Forms.Button ApplyButton;
        private System.Windows.Forms.Label AbstractLabel;
        private System.Windows.Forms.Label CreationLabel;
        private System.Windows.Forms.Label LastUpdateLabel;
        private Forms.Button NewTagButton;
        private System.Windows.Forms.Panel NewTagWrapper;
        private System.Windows.Forms.TextBox NewTagTextBox;
    }
}