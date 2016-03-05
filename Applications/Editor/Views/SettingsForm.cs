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
        public SettingsForm() : this(null) { }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsForm(SettingsValue settings, int index = 0)
        {
            InitializeComponent();
            InitializeVersionControl();
            Update(settings);
            InitializeEvents();

            Caption = TitleControl;
            SettingsControl.OKButton = ApplyButton;
            SettingsControl.CancelButton = ExitButton;
            TabControl.SelectTab(index);
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Update
        ///
        /// <summary>
        /// 各種コントロールの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Update(SettingsValue settings)
        {
            if (settings == null) return;
            SettingsControl.Update(settings);
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
            ApplyButton.Click += (s, e) => Close();
            ExitButton.Click  += (s, e) => Close();
            ResetButton.Click += (s, e) => OnReset(e);

            SpecialCharsVisibleCheckBox.CheckedChanged += (s, e) => EnableSpecialChars();
            LineNumberVisibleCheckBox.CheckedChanged   += (s, e) => EnableLineNumber();
            RulerVisibleCheckBox.CheckedChanged        += (s, e) => EnableLineNumber();
            CurrentLineVisibleCheckBox.CheckedChanged  += (s, e) => EnableCurrentLine();
            WordWrapCheckBox.CheckedChanged            += (s, e) => EnableWordWrap();
            WordWrapAsWindowCheckBox.CheckedChanged    += (s, e) => EnableWordWrap();
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

            control.Assembly     = Assembly.GetEntryAssembly();
            control.VersionDigit = 3;
            control.Description  = string.Empty;
            control.Logo         = Properties.Resources.LogoLarge;
            control.Url          = Properties.Resources.WebUrl;
            control.Dock         = DockStyle.Fill;
            control.Padding      = new Padding(40, 40, 0, 0);

            VersionTabPage.Controls.Add(control);
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Apply
        ///
        /// <summary>
        /// OK または適用ボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Apply
        {
            add    { SettingsControl.Apply += value; }
            remove { SettingsControl.Apply -= value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Cancel
        ///
        /// <summary>
        /// キャンセルボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Cancel
        {
            add    { SettingsControl.Cancel += value; }
            remove { SettingsControl.Cancel -= value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Reset
        ///
        /// <summary>
        /// リセットボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Reset;

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyChanged
        ///
        /// <summary>
        /// 各種プロパティが変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<KeyValueEventArgs<string, object>> PropertyChanged
        {
            add    { SettingsControl.PropertyChanged += value; }
            remove { SettingsControl.PropertyChanged -= value; }
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnReset
        ///
        /// <summary>
        /// Reset イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnReset(EventArgs e)
            => Reset?.Invoke(this, e);
        
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

            var area = Screen.FromControl(this).WorkingArea.Size;
            if (Width  > area.Width ) Width  = area.Width;
            if (Height > area.Height) Height = area.Height;

            UpdateControls();
        }

        #endregion

        #region Update methods

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
            EnableLineNumber();
            EnableSpecialChars();
            EnableCurrentLine();
            EnableWordWrap();
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
            var enable = SpecialCharsVisibleCheckBox.Checked;

            SpecialCharsColorTitleLabel.Enabled  = enable;
            SpecialCharsColorColorButton.Enabled = enable;
            SpecialCharsColorLabel.Enabled       = enable;
            EolVisibleCheckBox.Enabled           = enable;
            TabVisibleCheckBox.Enabled           = enable;
            SpaceVisibleCheckBox.Enabled         = enable;
            FullSpaceVisibleCheckBox.Enabled     = enable;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableCurrentLine
        ///
        /// <summary>
        /// 現在行に関する設定の変更を可能にします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableCurrentLine()
        {
            var enable = CurrentLineVisibleCheckBox.Checked;

            CurrentLineColorTitleLabel.Enabled  = enable;
            CurrentLineColorColorButton.Enabled = enable;
            CurrentLineColorLabel.Enabled       = enable;
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
            var enable = LineNumberVisibleCheckBox.Checked || RulerVisibleCheckBox.Checked;

            LineNumberBackColorColorButton.Enabled = enable;
            LineNumberBackColorLabel.Enabled       = enable;
            LineNumberBackColorTitleLabel.Enabled  = enable;
            LineNumberForeColorColorButton.Enabled = enable;
            LineNumberForeColorLabel.Enabled       = enable;
            LineNumberForeColorTitleLabel.Enabled  = enable;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableWordWrap
        ///
        /// <summary>
        /// 行番号および水平ルーラーに関する設定の変更を可能にします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableWordWrap()
        {
            var enable = WordWrapCheckBox.Checked;
            var cmode  = WordWrapCheckBox.Checked && !WordWrapAsWindowCheckBox.Checked;

            WordWrapTitleLabel.Enabled         = enable;
            WordWrapAsWindowCheckBox.Enabled   = enable;
            WordWrapCountNumericUpDown.Enabled = cmode;
        }

        #endregion
    }
}
