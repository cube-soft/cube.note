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
            RunButton.Click  += (s, e) => Close();
            ExitButton.Click += (s, e) => Close();

            BackColorButton.Click += ColorButton_Click;
            ForeColorButton.Click += ColorButton_Click;
            LineNumberBackColorButton.Click += ColorButton_Click;
            LineNumberForeColorButton.Click += ColorButton_Click;

            FontButton.Click += FontButton_Click;

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
            control.Dock        = DockStyle.Fill;
            control.Resize     += (s, e) => ResizeVersionControl(control);

            ResizeVersionControl(control);
            VersionTabPage.Controls.Add(control);
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
            dialog.ShowEffects = false;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
        }

        #endregion

        #region Others

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
            var left   = Math.Max(Math.Min((int)(VersionTabPage.Width  * 0.1), 100), 20);
            var top    = Math.Max(Math.Min((int)(VersionTabPage.Height * 0.1), 100), 20);
            var bottom = Math.Max(Math.Min((int)(VersionTabPage.Height * 0.1), 100), 20);

            control.Padding = new Padding(left, top, 0, bottom);
        }

        #endregion
    }
}
