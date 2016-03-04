/* ------------------------------------------------------------------------- */
///
/// SearchForm.cs
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
using System.ComponentModel;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SearchForm
    /// 
    /// <summary>
    /// 検索画面を表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class SearchForm : FormBase
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SearchForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SearchForm()
        {
            InitializeComponent();

            TabControl.Selecting += TabControl_Selecting;
            SearchPanel.Resize += SearchPanel_Resize;
            SearchButton.Click += (s, e) => OnSearch(EventArgs.Empty);
            OptionalButton1.Click += OptionalButton1_Click;
            OptionalButton2.Click += OptionalButton2_Click;

            // for optional buttons
            Pages.Added += (s, e) => EnableOptionalButtons();
            Pages.Removed += (s, e) => EnableOptionalButtons();
            Pages.Cleared += (s, e) => EnableOptionalButtons();
            SearchTextBox.TextChanged += (s, e) => EnableOptionalButtons(false);
            CaseSensitiveCheckBox.CheckedChanged += (s, e) => EnableOptionalButtons(false);

            Caption = TitleControl;

            EnableReplaceControls(false);
            EnableOptionalButtons(false);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Keyword
        ///
        /// <summary>
        /// 検索キーワードを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public string Keyword
        {
            get { return SearchTextBox.Text; }
            set { SearchTextBox.Text  = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Replace
        ///
        /// <summary>
        /// 置換後の文字列を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public string Replace
        {
            get { return ReplaceTextBox.Text; }
            set { ReplaceTextBox.Text = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CaseSensitive
        ///
        /// <summary>
        /// 大文字と小文字を区別するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public bool CaseSensitive
        {
            get { return CaseSensitiveCheckBox.Checked; }
            set { CaseSensitiveCheckBox.Checked = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Message
        ///
        /// <summary>
        /// メッセージを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public string Message
        {
            get { return MessageLabel.Text; }
            set { MessageLabel.Text = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ShowPages
        ///
        /// <summary>
        /// ページ一覧を表示するかどうかを判別する値を取得または設定します。
        /// </summary>
        /// 
        /// <remarks>
        /// Pages 表示時に最低限の表示領域を確保できるように Height を
        /// 調整します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public bool ShowPages
        {
            get { return !ContentsPanel.Panel2Collapsed; }
            set
            {
                if (ContentsPanel.Panel2Collapsed == !value) return;
                ContentsPanel.Panel2Collapsed = !value;

                if (!value) Height = MinimumSize.Height;
                else if (Height < MinimumSize.Height * 2) Height = MinimumSize.Height * 2;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        ///
        /// <summary>
        /// ページ一覧を表示する ListView オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public PageListView Pages => ResultListView;

        /* ----------------------------------------------------------------- */
        ///
        /// SearchRange
        ///
        /// <summary>
        /// 検索範囲を指定するための ComboBox オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public ComboBox SearchRange => RangeComboBox;

        /* ----------------------------------------------------------------- */
        ///
        /// Aggregator
        ///
        /// <summary>
        /// イベントを集約するオブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public EventAggregator Aggregator
        {
            get { return Pages.Aggregator; }
            set { Pages.Aggregator = value; }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        ///
        /// <summary>
        /// 検索時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Search;

        /* ----------------------------------------------------------------- */
        ///
        /// SearchNext
        ///
        /// <summary>
        /// 次を検索時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler SearchNext;

        /* ----------------------------------------------------------------- */
        ///
        /// SearchPrev
        ///
        /// <summary>
        /// 前を検索時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler SearchPrev;

        /* ----------------------------------------------------------------- */
        ///
        /// ReplaceNext
        ///
        /// <summary>
        /// 次を置換時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler ReplaceNext;

        /* ----------------------------------------------------------------- */
        ///
        /// ReplaceAll
        ///
        /// <summary>
        /// すべて置換時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler ReplaceAll;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnSearch
        ///
        /// <summary>
        /// Search イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSearch(EventArgs e)
            => Search?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnSearchNext
        ///
        /// <summary>
        /// SearchNext イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSearchNext(EventArgs e)
            => SearchNext?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnSearchPrev
        ///
        /// <summary>
        /// SearchPrev イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSearchPrev(EventArgs e)
            => SearchPrev?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnReplaceNext
        ///
        /// <summary>
        /// ReplaceNext イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnReplaceNext(EventArgs e)
            => ReplaceNext?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnReplaceAll
        ///
        /// <summary>
        /// ReplaceAll イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnReplaceAll(EventArgs e)
            => ReplaceAll?.Invoke(this, e);

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnShown
        ///
        /// <summary>
        /// フォームの初回表示時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ShowPages = false;
            Height = MinimumSize.Height;
            SearchTextBox.Focus();
            new Cube.Forms.SizeHacker(ContentsPanel, SizeGrip);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnFormClosing
        ///
        /// <summary>
        /// フォームが閉じる時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true;
            Hide();
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// MenuTabControl_Selecting
        ///
        /// <summary>
        /// MenuTabControl のタブが選択される前に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            SearchPanel.SuspendLayout();

            switch (e.TabPage.Name)
            {
                case nameof(SearchTabPage):
                    ReplaceTabPage.Controls.Remove(SearchPanel);
                    EnableReplaceControls(false);
                    OptionalButton1.Text = Properties.Resources.SearchPrev;
                    OptionalButton2.Text = Properties.Resources.SearchNext;
                    SearchTabPage.Controls.Add(SearchPanel);
                    break;
                case nameof(ReplaceTabPage):
                    SearchTabPage.Controls.Remove(SearchPanel);
                    EnableReplaceControls(true);
                    OptionalButton1.Text = Properties.Resources.ReplaceNext;
                    OptionalButton2.Text = Properties.Resources.ReplaceAll;
                    ReplaceTabPage.Controls.Add(SearchPanel);
                    break;
                default:
                    break;
            }

            SearchPanel.ResumeLayout();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchPanel_Resize
        ///
        /// <summary>
        /// ReplacePanel のリサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SearchPanel_Resize(object sender, EventArgs e)
        {
            SearchPanel.SuspendLayout();

            var width = SearchPanel.Width - SearchPanel.Padding.Right;
            SetWidth(ButtonsPanel,   width);
            SetWidth(SearchTextBox,  width);
            SetWidth(ReplaceTextBox, width);
            SetWidth(RangeComboBox,  width);

            SearchPanel.ResumeLayout();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OptionalButton1_Click
        ///
        /// <summary>
        /// ボタンのクリック時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void OptionalButton1_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Parent == SearchTabPage) OnSearchPrev(EventArgs.Empty);
            else OnReplaceNext(EventArgs.Empty);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OptionalButton2_Click
        ///
        /// <summary>
        /// ボタンのクリック時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void OptionalButton2_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Parent == SearchTabPage) OnSearchNext(EventArgs.Empty);
            else OnReplaceAll(EventArgs.Empty);
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// SetWidth
        ///
        /// <summary>
        /// 幅を設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SetWidth(Control control, int width)
        {
            var x = control.Location.X;
            var margin  = control.Margin.Left + control.Margin.Right;
            var padding = control.Padding.Left + control.Padding.Right;

            control.Width = width - x - margin - padding;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableOptionalButtons
        ///
        /// <summary>
        /// オプション的なボタンの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableOptionalButtons()
            => EnableOptionalButtons(Pages.Items.Count > 0);

        /* ----------------------------------------------------------------- */
        ///
        /// EnableOptionalButtons
        ///
        /// <summary>
        /// オプション的なボタンの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableOptionalButtons(bool enabled)
        {
            OptionalShadow1.Enabled = enabled;
            OptionalShadow2.Enabled = enabled;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EnableReplaceControls
        ///
        /// <summary>
        /// 置換用コントロールの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void EnableReplaceControls(bool enabled)
        {
            ReplaceLabel.Visible   = enabled;
            ReplaceTextBox.Visible = enabled;
        }

        #endregion
    }
}
