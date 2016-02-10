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

            BackColorButton.BackColor           = settings.BackColor;
            BackColorButton.ForeColor           = settings.BackColor;
            ForeColorButton.BackColor           = settings.ForeColor;
            ForeColorButton.ForeColor           = settings.ForeColor;
            HighlightBackColorButton.BackColor  = settings.HighlightBackColor;
            HighlightBackColorButton.ForeColor  = settings.HighlightBackColor;
            HighlightForeColorButton.BackColor  = settings.HighlightForeColor;
            HighlightForeColorButton.ForeColor  = settings.HighlightForeColor;
            LineNumberBackColorButton.BackColor = settings.LineNumberBackColor;
            LineNumberBackColorButton.ForeColor = settings.LineNumberBackColor;
            LineNumberForeColorButton.BackColor = settings.LineNumberForeColor;
            LineNumberForeColorButton.ForeColor = settings.LineNumberForeColor;
            SpecialCharsColorButton.BackColor   = settings.SpecialCharsColor;
            SpecialCharsColorButton.ForeColor   = settings.SpecialCharsColor;
            CurrentLineColorButton.BackColor    = settings.CurrentLineColor;
            CurrentLineColorButton.ForeColor    = settings.CurrentLineColor;

            FontButton.Tag                      = settings.Font;

            TabToSpaceCheckBox.Checked          = settings.TabToSpace;
            WardWrapCheckBox.Checked            = settings.WardWrap;
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
            RunButton.Click                            += RunButton_Click;
            ExitButton.Click                           += ExitButton_Click;
            ApplyButton.Click                          += ApplyButton_Click;
            ResetButton.Click                          += (s, e) => OnReset(e);

            FontButton.Click                           += FontButton_Click;

            BackColorButton.Click                      += ColorButton_Click;
            ForeColorButton.Click                      += ColorButton_Click;
            HighlightBackColorButton.Click             += ColorButton_Click;
            HighlightForeColorButton.Click             += ColorButton_Click;
            LineNumberBackColorButton.Click            += ColorButton_Click;
            LineNumberForeColorButton.Click            += ColorButton_Click;
            SpecialCharsColorButton.Click              += ColorButton_Click;
            CurrentLineColorButton.Click               += ColorButton_Click;

            TabToSpaceCheckBox.CheckedChanged          += CheckBoxChanged;
            WardWrapCheckBox.CheckedChanged            += CheckBoxChanged;
            LineNumberVisibleCheckBox.CheckedChanged   += CheckBoxChanged;
            RulerVisibleCheckBox.CheckedChanged        += CheckBoxChanged;
            SpecialCharsVisibleCheckBox.CheckedChanged += CheckBoxChanged;
            EolVisibleCheckBox.CheckedChanged          += CheckBoxChanged;
            TabVisibleCheckBox.CheckedChanged          += CheckBoxChanged;
            SpaceVisibleCheckBox.CheckedChanged        += CheckBoxChanged;
            FullSpaceVisibleCheckBox.CheckedChanged    += CheckBoxChanged;
            CurrentLineVisibleCheckBox.CheckedChanged  += CheckBoxChanged;
            ModifiedLineVisibleCheckBox.CheckedChanged += CheckBoxChanged;
            BracketVisibleCheckBox.CheckedChanged      += CheckBoxChanged;
            RemoveWarningCheckBox.CheckedChanged       += CheckBoxChanged;

            TabWidthNumericUpDown.ValueChanged         += NumericUpDownChanged;
            AutoSaveTimeNumericUpDown.ValueChanged     += NumericUpDownChanged;

            SpecialCharsVisibleCheckBox.CheckedChanged += (s, e) => EnableSpecialChars();
            LineNumberVisibleCheckBox.CheckedChanged   += (s, e) => EnableLineNumber();
            RulerVisibleCheckBox.CheckedChanged        += (s, e) => EnableLineNumber();
            CurrentLineVisibleCheckBox.CheckedChanged  += (s, e) => EnableCurrentLine();
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
        public event EventHandler Applied;

        /* ----------------------------------------------------------------- */
        ///
        /// Canceled
        ///
        /// <summary>
        /// キャンセルボタンが押下された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Canceled;

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
        public event EventHandler<KeyValueEventArgs<string, object>> PropertyChanged;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnApplied
        ///
        /// <summary>
        /// Applied イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnApplied(EventArgs e)
        {
            if (Applied != null) Applied(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnCanceled
        ///
        /// <summary>
        /// Canceled イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnCanceled(EventArgs e)
        {
            if (Canceled != null) Canceled(this, e);
        }

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
        {
            if (Reset != null) Reset(this, e);
        }

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

            var area = Screen.FromControl(this).WorkingArea.Size;
            if (Width  > area.Width ) Width  = area.Width;
            if (Height > area.Height) Height = area.Height;

            UpdateControls();
            ApplyButton.Enabled = false;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// RunButton_Click
        ///
        /// <summary>
        /// OK ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RunButton_Click(object sender, EventArgs e)
        {
            ApplyButton_Click(sender, e);
            Close();
        }

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
            OnApplied(e);
            ApplyButton.Enabled = false;
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
            OnCanceled(e);
            Close();
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
            UpdateColor(BackColorButton, BackColorLabel);
            UpdateColor(ForeColorButton, ForeColorLabel);
            UpdateColor(HighlightBackColorButton, HighlightBackColorLabel);
            UpdateColor(HighlightForeColorButton, HighlightForeColorLabel);
            UpdateColor(LineNumberBackColorButton, LineNumberBackColorLabel);
            UpdateColor(LineNumberForeColorButton, LineNumberForeColorLabel);
            UpdateColor(SpecialCharsColorButton, SpecialCharsColorLabel);
            UpdateColor(CurrentLineColorButton, CurrentLineColorLabel);

            UpdateFont(FontButton.Tag as Font, FontLabel);

            EnableLineNumber();
            EnableSpecialChars();
            EnableCurrentLine();
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

            RaisePropertyChanged(control, color);
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
            var enable = SpecialCharsVisibleCheckBox.Checked;

            SpecialCharsColorTitleLabel.Enabled = enable;
            SpecialCharsColorButton.Enabled     = enable;
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
            CurrentLineColorButton.Enabled     = enable;
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

            LineNumberBackColorButton.Enabled     = enable;
            LineNumberBackColorLabel.Enabled      = enable;
            LineNumberBackColorTitleLabel.Enabled = enable;
            LineNumberForeColorButton.Enabled     = enable;
            LineNumberForeColorLabel.Enabled      = enable;
            LineNumberForeColorTitleLabel.Enabled = enable;
        }

        #endregion

        #region RaiseEvent methods

        /* ----------------------------------------------------------------- */
        ///
        /// CheckBoxChanged
        ///
        /// <summary>
        /// チェックボックスの状態が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// Value には CheckBox.Checked が設定されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected void CheckBoxChanged(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            if (control == null) return;
            RaisePropertyChanged(control, control.Checked);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ComboBoxChanged
        ///
        /// <summary>
        /// コンボボックスの状態が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// Value には ComboBox.SelectedIndex が設定されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected void ComboBoxChanged(object sender, EventArgs e)
        {
            var control = sender as ComboBox;
            if (control == null) return;
            RaisePropertyChanged(control, control.SelectedIndex);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// NumericUpDownChanged
        ///
        /// <summary>
        /// NumericUpDown の状態が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// Value には NumericUpDown.Value が設定されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected void NumericUpDownChanged(object sender, EventArgs e)
        {
            var control = sender as NumericUpDown;
            if (control == null) return;
            RaisePropertyChanged(control, control.Value);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RadioButtonChanged
        ///
        /// <summary>
        /// ラジオボタンの状態が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// Value には RadioButton.Checked が設定されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected void RadioButtonChanged(object sender, EventArgs e)
        {
            var control = sender as RadioButton;
            if (control == null) return;
            RaisePropertyChanged(control, control.Checked);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TextBoxChanged
        ///
        /// <summary>
        /// ラジオボタンの状態が変化した時に実行されるハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// Value には TextBox.Text が設定されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected void TextBoxChanged(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            if (control == null) return;
            RaisePropertyChanged(control, control.Text);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RaisePropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected void RaisePropertyChanged(Control control, object value)
        {
            var name = control.Tag is string ?
                       control.Tag as string :
                       control.Name.Replace(control.GetType().Name, string.Empty);
            if (string.IsNullOrEmpty(name)) return;

            OnPropertyChanged(new KeyValueEventArgs<string, object>(name, value));
        }

        #endregion
    }
}
