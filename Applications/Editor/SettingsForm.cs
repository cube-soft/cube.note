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
        public SettingsForm(SettingsValue settings)
        {
            InitializeComponent();
            MainSettingControl.OKButton = ApplyButton;
            MainSettingControl.CancelButton = ExitButton;
            InitializeVersionControl();
            Update(settings);
            InitializeEvents();

            Caption = TitleControl;
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

            BackColorColorButton.BackColor           = settings.BackColor;
            BackColorColorButton.ForeColor           = settings.BackColor;
            ForeColorColorButton.BackColor           = settings.ForeColor;
            ForeColorColorButton.ForeColor           = settings.ForeColor;
            HighlightBackColorColorButton.BackColor  = settings.HighlightBackColor;
            HighlightBackColorColorButton.ForeColor  = settings.HighlightBackColor;
            HighlightForeColorColorButton.BackColor  = settings.HighlightForeColor;
            HighlightForeColorColorButton.ForeColor  = settings.HighlightForeColor;
            LineNumberBackColorColorButton.BackColor = settings.LineNumberBackColor;
            LineNumberBackColorColorButton.ForeColor = settings.LineNumberBackColor;
            LineNumberForeColorColorButton.BackColor = settings.LineNumberForeColor;
            LineNumberForeColorColorButton.ForeColor = settings.LineNumberForeColor;
            SpecialCharsColorColorButton.BackColor   = settings.SpecialCharsColor;
            SpecialCharsColorColorButton.ForeColor   = settings.SpecialCharsColor;
            CurrentLineColorColorButton.BackColor    = settings.CurrentLineColor;
            CurrentLineColorColorButton.ForeColor    = settings.CurrentLineColor;

            FontFontButton.Tag                      = settings.Font;

            TabToSpaceCheckBox.Checked          = settings.TabToSpace;
            WordWrapCheckBox.Checked            = settings.WordWrap;
            WordWrapAsWindowCheckBox.Checked    = settings.WordWrapAsWindow;
            LineNumberVisibleCheckBox.Checked   = settings.LineNumberVisible;
            RulerVisibleCheckBox.Checked        = settings.RulerVisible;
            SpecialCharsVisibleCheckBox.Checked = settings.SpecialCharsVisible;
            EolVisibleCheckBox.Checked          = settings.EolVisible;
            TabVisibleCheckBox.Checked          = settings.TabVisible;
            SpaceVisibleCheckBox.Checked        = settings.SpaceVisible;
            FullSpaceVisibleCheckBox.Checked    = settings.FullSpaceVisible;
            CurrentLineVisibleCheckBox.Checked  = settings.CurrentLineVisible;
            ModifiedLineVisibleCheckBox.Checked = settings.ModifiedLineVisible;
            BracketVisibleCheckBox.Checked      = settings.BracketVisible;
            RemoveWarningCheckBox.Checked       = settings.RemoveWarning;

            TabWidthNumericUpDown.Value         = settings.TabWidth;
            AutoSaveTimeNumericUpDown.Value     = (int)settings.AutoSaveTime.TotalSeconds;
            WordWrapCountNumericUpDown.Value    = settings.WordWrapCount;
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
            ApplyButton.Click                          += ApplyButton_Click;
            ExitButton.Click                           += ExitButton_Click;
            ResetButton.Click                          += (s, e) => OnReset(e);
            PropertyChanged                            += OnPropertyChanged;

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
        /// Applied
        ///
        /// <summary>
        /// OK または適用ボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Applied
        {
            add
            {
                MainSettingControl.Apply += value;
            }
            remove
            {
                MainSettingControl.Apply -= value;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Canceled
        ///
        /// <summary>
        /// キャンセルボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Canceled
        {
            add
            {
                MainSettingControl.Cancel += value;
            }
            remove
            {
                MainSettingControl.Cancel -= value;
            }
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
            add
            {
                MainSettingControl.PropertyChanged += value;
            }
            remove
            {
                MainSettingControl.PropertyChanged -= value;
            }
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

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ApplyButton_Click
        ///
        /// <summary>
        /// OK ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            //OnApplied(e);
            Close();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ExitButton_Click
        ///
        /// <summary>
        /// キャンセルボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ExitButton_Click(object sender, EventArgs e)
        {
            //OnCanceled(e);
            Close();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnPropertyChanged
        ///
        /// <summary>
        /// プロパティが変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void OnPropertyChanged(object sender, KeyValueEventArgs<string, object> e)
        {
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
            UpdateColor(BackColorColorButton, BackColorLabel);
            UpdateColor(ForeColorColorButton, ForeColorLabel);
            UpdateColor(HighlightBackColorColorButton, HighlightBackColorLabel);
            UpdateColor(HighlightForeColorColorButton, HighlightForeColorLabel);
            UpdateColor(LineNumberBackColorColorButton, LineNumberBackColorLabel);
            UpdateColor(LineNumberForeColorColorButton, LineNumberForeColorLabel);
            UpdateColor(SpecialCharsColorColorButton, SpecialCharsColorLabel);
            UpdateColor(CurrentLineColorColorButton, CurrentLineColorLabel);

            UpdateFont(FontFontButton.Font, FontLabel);

            EnableLineNumber();
            EnableSpecialChars();
            EnableCurrentLine();
            EnableWordWrap();
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
            var text = $"({color.R}, {color.G}, {color.B})";
            if (label.Text == text) return;
            label.Text = text;

            //RaisePropertyChanged(control, color);
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

            var text = $"({font.Name}, {font.Size}pt)";
            if (label.Text == text) return;
            label.Text = text;

            //OnPropertyChanged(new KeyValueEventArgs<string, object>("Font", font));
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

            SpecialCharsColorTitleLabel.Enabled = enable;
            SpecialCharsColorColorButton.Enabled     = enable;
            SpecialCharsColorLabel.Enabled      = enable;
            EolVisibleCheckBox.Enabled          = enable;
            TabVisibleCheckBox.Enabled          = enable;
            SpaceVisibleCheckBox.Enabled        = enable;
            FullSpaceVisibleCheckBox.Enabled    = enable;
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

            CurrentLineColorTitleLabel.Enabled = enable;
            CurrentLineColorColorButton.Enabled     = enable;
            CurrentLineColorLabel.Enabled      = enable;
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

            LineNumberBackColorColorButton.Enabled     = enable;
            LineNumberBackColorLabel.Enabled      = enable;
            LineNumberBackColorTitleLabel.Enabled = enable;
            LineNumberForeColorColorButton.Enabled     = enable;
            LineNumberForeColorLabel.Enabled      = enable;
            LineNumberForeColorTitleLabel.Enabled = enable;
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

            WordWrapLabel.Enabled              = enable;
            WordWrapAsWindowCheckBox.Enabled   = enable;
            WordWrapCountNumericUpDown.Enabled = cmode;
        }

        #endregion
    }
}
