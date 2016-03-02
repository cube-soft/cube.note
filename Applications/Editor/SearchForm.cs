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

            Caption = TitleControl;
            ReplaceLabel.Visible = false;
            ReplaceTextBox.Visible = false;
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
        /// Found
        ///
        /// <summary>
        /// 検索に一致した件数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public int Found { get; set; } = 0;

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
                    ReplaceLabel.Visible   = false;
                    ReplaceTextBox.Visible = false;
                    OptionalButton1.Text   = Properties.Resources.SearchPrev;
                    OptionalButton2.Text   = Properties.Resources.SearchNext;
                    SearchTabPage.Controls.Add(SearchPanel);
                    break;
                case nameof(ReplaceTabPage):
                    SearchTabPage.Controls.Remove(SearchPanel);
                    ReplaceLabel.Visible   = true;
                    ReplaceTextBox.Visible = true;
                    OptionalButton1.Text   = Properties.Resources.ReplaceNext;
                    OptionalButton2.Text   = Properties.Resources.ReplaceAll;
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

        #endregion

        #region RaiseXxxEvent

        /* ----------------------------------------------------------------- */
        ///
        /// RaiseSearchEvent
        ///
        /// <summary>
        /// Search イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RaiseSearchEvent()
            => Aggregator?.Search.Raise(new ValueEventArgs<string>(Keyword));

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

        #endregion
    }
}
