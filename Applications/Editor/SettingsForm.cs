/* ------------------------------------------------------------------------- */
///
/// SettingsForm.cs
/// 
/// Copyright (c) 2010 CubeSoft, Inc.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///  http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/* ------------------------------------------------------------------------- */
using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsForm
    /// 
    /// <summary>
    /// 設定画面を表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class SettingsForm : FormBase
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsForm()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeVersionControl();

            Caption = TitleControl;
        }

        #endregion

        #region Initialize methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeEvents
        ///
        /// <summary>
        /// 各種イベントを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeEvents()
        {
            // buttons
            RunButton.Click += (s, e) => Close();
            ExitButton.Click += (s, e) => Close();
            ApplyButton.Click += ApplyButton_Click;

            // colors
            BackColorButton.Click += ColorButton_Click;
            ForeColorButton.Click += ColorButton_Click;
            LineNumberBackColorButton.Click += ColorButton_Click;
            LineNumberForeColorButton.Click += ColorButton_Click;

            // fonts
            FontButton.Click += FontButton_Click;

            // checkboxes
            TabToSpaceCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            LineNumberCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            RulerCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            SpecialCharsCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            EolCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            TabCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            SpaceCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            FullSpaceCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            CurrentLineCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            ModifiedLineCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            RemoveWarningCheckBox.CheckedChanged += CheckBox_CheckedChanged;

            // numeric updown
            TabWidthNumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            AutoSaveNumericUpDown.ValueChanged += NumericUpDown_ValueChanged;

            // others
            SpecialCharsCheckBox.CheckedChanged += (s, e) => EnableSpecialChars();
            LineNumberCheckBox.CheckedChanged += (s, e) => EnableLineNumber();
            RulerCheckBox.CheckedChanged += (s, e) => EnableLineNumber();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeVersionControl
        ///
        /// <summary>
        /// バージョン情報を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeVersionControl()
        {
            var control = new Cube.Forms.VersionControl();

            control.Assembly    = Assembly.GetEntryAssembly();
            control.Description = string.Empty;
            control.Logo        = Properties.Resources.LogoLarge;
            control.Url         = Properties.Resources.WebUrl;
            control.Dock        = DockStyle.Top;
            control.Resize     += (s, e) => ResizeVersionControl(control);

            ResizeVersionControl(control);
            VersionTabPage.Controls.Add(control);
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyChanged
        ///
        /// <summary>
        /// 各種プロパティが変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<KeyValueEventArgs<string, object>> PropertyChanged;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnPropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnPropertyChanged(KeyValueEventArgs<string, object> e)
        {
            if (PropertyChanged != null) PropertyChanged(this, e);
            ApplyButton.Enabled = true;
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoad
        ///
        /// <summary>
        /// ロード時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EnableSpecialChars();
            EnableLineNumber();

            var area = Screen.FromControl(this).WorkingArea.Size;
            if (Width  > area.Width ) Width  = area.Width;
            if (Height > area.Height) Height = area.Height;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ApplyButton_Click
        ///
        /// <summary>
        /// 更新ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ApplyButton.Enabled = false;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ColorButton_Click
        ///
        /// <summary>
        /// 色設定ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ColorButton_Click(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            var dialog = new ColorDialog();
            dialog.Color = control.BackColor;
            dialog.FullOpen = true;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            control.BackColor = dialog.Color;
            control.ForeColor = dialog.Color;

            UpdateControls();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FontButton_Click
        ///
        /// <summary>
        /// フォント設定ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void FontButton_Click(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            var dialog = new FontDialog();
            var font = control.Tag as Font;
            if (font != null) dialog.Font = font;
            dialog.ShowEffects = false;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            control.Tag = dialog.Font;

            UpdateControls();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CheckBox_CheckedChanged
        ///
        /// <summary>
        /// チェックボックスの状態が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            if (control == null) return;

            var name = control.Tag as string;
            if (name == null) return;

            OnPropertyChanged(new KeyValueEventArgs<string, object>(name, control.Checked));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// NumericUpDown_ValueChanged
        ///
        /// <summary>
        /// 数値変更ボックスの値が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var control = sender as NumericUpDown;
            if (control == null) return;

            var name = control.Tag as string;
            if (name == null) return;

            OnPropertyChanged(new KeyValueEventArgs<string, object>(name, (int)control.Value));
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateControls
        ///
        /// <summary>
        /// コントロールを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateControls()
        {
            UpdateColor(BackColorButton, BackColorLabel);
            UpdateColor(ForeColorButton, ForeColorLabel);
            UpdateColor(LineNumberBackColorButton, LineNumberBackColorLabel);
            UpdateColor(LineNumberForeColorButton, LineNumberForeColorLabel);

            UpdateFont(FontButton.Tag as Font, FontLabel);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateColor
        ///
        /// <summary>
        /// 色設定を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateColor(Control control, Label label)
        {
            var color = control.BackColor;
            var text = string.Format("({0}, {1}, {2})", color.R, color.G, color.B);
            if (label.Text == text) return;
            label.Text = text;

            var name = control.Tag as string;
            if (name == null) return;

            OnPropertyChanged(new KeyValueEventArgs<string, object>(name, color));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateFont
        ///
        /// <summary>
        /// フォント設定を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateFont(Font font, Label label)
        {
            if (font == null) return;

            var text = string.Format("({0}, {1}pt)", font.Name, font.Size);
            if (label.Text == text) return;
            label.Text = text;

            OnPropertyChanged(new KeyValueEventArgs<string, object>("Font", font));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableSpecialChars
        ///
        /// <summary>
        /// 特殊文字に関する設定の変更を可能にします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableSpecialChars()
        {
            var enable = SpecialCharsCheckBox.Checked;

            EolCheckBox.Enabled       = enable;
            TabCheckBox.Enabled       = enable;
            SpaceCheckBox.Enabled     = enable;
            FullSpaceCheckBox.Enabled = enable;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableLineNumber
        ///
        /// <summary>
        /// 行番号および水平ルーラーに関する設定の変更を可能にします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableLineNumber()
        {
            var enable = LineNumberCheckBox.Checked || RulerCheckBox.Checked;

            LineNumberBackColorButton.Enabled     = enable;
            LineNumberBackColorLabel.Enabled      = enable;
            LineNumberBackColorTitleLabel.Enabled = enable;
            LineNumberForeColorButton.Enabled     = enable;
            LineNumberForeColorLabel.Enabled      = enable;
            LineNumberForeColorTitleLabel.Enabled = enable;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResizeVersionControl
        ///
        /// <summary>
        /// バージョン画面のレイアウトを調整します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResizeVersionControl(Control control)
        {
            control.Padding = new Padding(40, 40, 0, 0);
            control.Height = Math.Min(VersionTabPage.Height, 200);
        }

        #endregion
    }
}
