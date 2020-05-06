/* ------------------------------------------------------------------------- */
// 
// Copyright (c) 2010 CubeSoft, Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using IoEx = System.IO;

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
            UpdateLayout(Dpi / BaseDpi);
            Update(settings);
            InitializeEvents();

            Caption = TitleControl;
            Caption.MinimizeControl.Visible = false;
            SettingsControl.OKButton = ApplyButton;
            SettingsControl.CancelButton = ExitButton;
            TabControl.SelectTab(index);

            DataFolderButton.Click += DataFolderButton_Click;
        }

        #endregion

        #region Properties

        /* --------------------------------------------------------------------- */
        ///
        /// Version
        /// 
        /// <summary>
        /// バージョン情報を取得または設定します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(false)]
        public string Version
        {
            get { return _version.Version; }
            set { _version.Version = value; }
        }

        /* --------------------------------------------------------------------- */
        ///
        /// DataFolder
        /// 
        /// <summary>
        /// データフォルダを取得または設定します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataFolder
        {
            get { return DataFolderTextBox.Text; }
            set
            {
                DataFolderTextBox.Text = value;
                DataFolderTextBox.Select(DataFolderTextBox.TextLength, 0);
            }
        }

        /* --------------------------------------------------------------------- */
        ///
        /// RestartRequired
        /// 
        /// <summary>
        /// データフォルダ変更後にアプリケーションを再起動するかどうかを示す値を取得
        /// または設定します。
        /// </summary>
        ///
        /* --------------------------------------------------------------------- */
        [Browsable(true)]
        [DefaultValue(true)]
        public bool RestartRequired
        {
            get { return RestartCheckBox.Checked; }
            set { RestartCheckBox.Checked = value; }
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

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateLayout
        ///
        /// <summary>
        /// レイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public override void UpdateLayout(double ratio)
        {
            base.UpdateLayout(ratio);

            MinimumSize = new Size((int)(480 * ratio), (int)(320 * ratio));
            Size = new Size((int)(500 * ratio), (int)(560 * ratio));

            LayoutPanel.RowStyles[0].Height = (int)(30 * ratio);
            LayoutPanel.RowStyles[2].Height = (int)(27 * ratio);
            LayoutPanel.RowStyles[3].Height = (int)(55 * ratio);

            TitleControl.UpdateLayout(ratio);

            ResetButton.Size = new Size((int)(120 * ratio), (int)(25 * ratio));
            ApplyButton.Size = new Size((int)(130 * ratio), (int)(35 * ratio));
            ExitButton.Size = new Size((int)(110 * ratio), (int)(35 * ratio));

            UpdateMarginLayout(ratio);
            UpdateTitleLabelLayout(ratio);
            UpdateColorLabelLayout(ratio);
            UpdateButtonLayout(ratio);
            UpdateOthersLayout(ratio);
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnShown
        ///
        /// <summary>
        /// フォーム表示直後に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnShown(EventArgs e)
        {
            _version.Description = string.Empty;
            _version.Image       = Properties.Resources.LogoLarge;
            _version.Uri         = new Uri(Properties.Resources.UrlWeb);
            _version.Dock        = DockStyle.Fill;
            _version.Padding     = new Padding(40, 40, 0, 0);

            VersionTabPage.Controls.Add(_version);
            base.OnShown(e);
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

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// DataFolderButton_Click
        ///
        /// <summary>
        /// 各種コントロールの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void DataFolderButton_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = Properties.Resources.DataFolderDescription;
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = DataFolder;
            if (dialog.ShowDialog() == DialogResult.Cancel ||
                string.IsNullOrEmpty(dialog.SelectedPath)) return;

            if (!IsWritable(dialog.SelectedPath))
            {
                MessageBox.Show(
                    Properties.Resources.WarnWritable,
                    Properties.Resources.WarnWritableTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            DataFolder = dialog.SelectedPath;
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

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// IsWritable
        ///
        /// <summary>
        /// フォルダが書き込み可能かどうか判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private bool IsWritable(string dir)
        {
            try
            {
                var filename = Guid.NewGuid().ToString("N");
                var path = IoEx.Path.Combine(dir, filename);
                using (var dummy = IoEx.File.Create(path, 1, IoEx.FileOptions.DeleteOnClose)) { }
                return true;
            }
            catch { return false; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetMargin
        ///
        /// <summary>
        /// 余白の値をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetMargin(Control src, int value)
        {
            foreach (var obj in src.Controls)
            {
                var control = obj as Control;
                if (control == null) continue;
                control.Margin = new Padding(value);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateMarginLayout
        ///
        /// <summary>
        /// 余白を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateMarginLayout(double ratio)
        {
            var margin = (int)(3 * ratio);

            ResetMargin(GeneralSettingsPanel, margin);
            ResetMargin(VisibleSettinsPanel, margin);
            ResetMargin(BehaviorSettingsPanel, margin);

            FontTitleLabel.Margin        =
            FontFontButton.Margin        =
            FontLabel.Margin             =
            TabWidthTitleLabel.Margin    =
            TabWidthNumericUpDown.Margin =
            TabToSpaceCheckBox.Margin    =
            RemoveWarningCheckBox.Margin =
            new Padding(margin, margin + 20, margin, margin);

            WordWrapTitleLabel.Margin            =
            LineNumberBackColorTitleLabel.Margin =
            LineNumberForeColorTitleLabel.Margin =
            CurrentLineColorTitleLabel.Margin    =
            EolVisibleCheckBox.Margin            =
            SpecialCharsColorTitleLabel.Margin   =
            new Padding(margin + 15, margin, margin, margin);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateTitleLabelLayout
        ///
        /// <summary>
        /// タイトル用ラベルのレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateTitleLabelLayout(double ratio)
        {
            FontTitleLabel.Size                =
            BackColorTitleLabel.Size           =
            ForeColorTitleLabel.Size           =
            UriColorTitleLabel.Size            =
            HighlightBackColorTitleLabel.Size  =
            HighlightForeColorTitleLabel.Size  =
            SearchBackColorTitleLabel.Size     =
            SearchForeColorTitleLabel.Size     =
            TabWidthTitleLabel.Size            =
            PrintMarginTitleLabel.Size         =
            label5.Size          =
            SearchQueryTitleLabel.Size         =
            AutoSaveTimeTitleLabel.Size        =
            DataFolderTitleLabel.Size          =
            new Size((int)(100 * ratio), (int)(23 * ratio));

            WordWrapTitleLabel.Size            =
            LineNumberBackColorTitleLabel.Size =
            LineNumberForeColorTitleLabel.Size =
            CurrentLineColorTitleLabel.Size    =
            SpecialCharsColorTitleLabel.Size   =
            new Size((int)(85 * ratio), (int)(23 * ratio));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateColorLabelLayout
        ///
        /// <summary>
        /// 色情報用ラベルのレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateColorLabelLayout(double ratio)
        {
            FontLabel.Size                =
            BackColorLabel.Size           =
            ForeColorLabel.Size           =
            UriColorLabel.Size            =
            HighlightBackColorLabel.Size  =
            HighlightForeColorLabel.Size  =
            SearchBackColorLabel.Size     =
            SearchForeColorLabel.Size     =
            LineNumberBackColorLabel.Size =
            LineNumberForeColorLabel.Size =
            CurrentLineColorLabel.Size    =
            SpecialCharsColorLabel.Size   =
            new Size((int)(190 * ratio), (int)(23 * ratio));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateButtonLayout
        ///
        /// <summary>
        /// 各種ボタンのレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateButtonLayout(double ratio)
        {
            FontFontButton.Image = Images.Get("font", ratio);
            DataFolderButton.Size = new Size((int)(50 * ratio), DataFolderTextBox.Height);

            FontFontButton.Size                 =
            BackColorColorButton.Size           =
            ForeColorColorButton.Size           =
            UriColorColorButton.Size            =
            HighlightBackColorColorButton.Size  =
            HighlightForeColorColorButton.Size  =
            SearchBackColorColorButton.Size     =
            SearchForeColorColorButton.Size     =
            LineNumberBackColorColorButton.Size =
            LineNumberForeColorColorButton.Size =
            CurrentLineColorColorButton.Size    =
            SpecialCharsColorColorButton.Size   =
            new Size((int)(50 * ratio), (int)(23 * ratio));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateOthersLayout
        ///
        /// <summary>
        /// その他のレイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateOthersLayout(double ratio)
        {
            RestartCheckBox.Margin = new Padding((int)(109 * ratio), 3, 3, 3);

            PrintLeftMarginTitleLabel.Size   =
            PrintRightMarginTitleLabel.Size  =
            PrintTopMarginTitleLabel.Size    =
            PrintBottomMarginTitleLabel.Size =
            new Size((int)(23 * ratio), (int)(23 * ratio));

            PrintLeftMarginUnitLabel.Size    =
            PrintRightMarginUnitLabel.Size   =
            PrintTopMarginUnitLabel.Size     =
            PrintBottomMarginUnitLabel.Size  =
            AutoSaveTimeUnitLabel.Size       =
            new Size((int)(35 * ratio), (int)(23 * ratio));
        }

        #endregion

        #region Fields
        private Cube.Forms.VersionControl _version = new Forms.VersionControl();
        #endregion
    }
}
