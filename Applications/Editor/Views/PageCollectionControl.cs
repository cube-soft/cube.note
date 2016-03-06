/* ------------------------------------------------------------------------- */
///
/// PageCollectionControl.cs
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
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionControl
    /// 
    /// <summary>
    /// ページ一覧を表示するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class PageCollectionControl : Cube.Forms.UserControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// ItemListControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollectionControl()
        {
            InitializeComponent();

            NewPageButton.Click += (s, e)
                => Aggregator?.NewPage.Raise(ValueEventArgs.Create(0));

            Pages.ContextMenuStrip = CreateContextMenu();
            Pages.AllowDrop = true;
            Pages.KeyDown += (s, e) => OnKeyDown(e);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        /// 
        /// <summary>
        /// ページ一覧を表示する ListView オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageListView Pages => PageListView;

        /* ----------------------------------------------------------------- */
        ///
        /// Tags
        /// 
        /// <summary>
        /// タグ一覧を表示する ComboBox オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ComboBox Tags => TagComboBox;

        /* ----------------------------------------------------------------- */
        ///
        /// Aggregator
        ///
        /// <summary>
        /// イベントを集約するオブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventAggregator Aggregator
        {
            get { return Pages.Aggregator; }
            set { Pages.Aggregator = value; }
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnKeyDown
        ///
        /// <summary>
        /// キーが押下された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnKeyDown(KeyEventArgs e)
        {
            try
            {
                var result = true;
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        Aggregator?.Remove.Raise(EventAggregator.SelectedPage);
                        break;
                    default:
                        result = false;
                        break;
                }
                e.Handled = result;
            }
            finally { base.OnKeyDown(e); }
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// CreateContextMenu
        /// 
        /// <summary>
        /// コンテキストメニューを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private ContextMenuStrip CreateContextMenu()
        {
            var dest = new ContextMenuStrip();

            dest.Items.Add(Properties.Resources.NewPageMenu, null,
                (s, e) => Aggregator?.NewPage.Raise(EventAggregator.SelectedPage));
            dest.Items.Add(Properties.Resources.DuplicateMenu, null,
                (s, e) => Aggregator?.Duplicate.Raise(EventAggregator.SelectedPage));
            dest.Items.Add(Properties.Resources.ImportMenu, null,
                (s, e) => Aggregator?.Import.Raise(KeyValueEventArgs.Create(-1, "")));

            dest.Items.Add("-");

            dest.Items.Add(Properties.Resources.UpMenu, null,
                (s, e) => Aggregator?.Move.Raise(ValueEventArgs.Create(-1)));
            dest.Items.Add(Properties.Resources.DownMenu, null,
                (s, e) => Aggregator?.Move.Raise(ValueEventArgs.Create(1)));

            dest.Items.Add("-");

            dest.Items.Add(Properties.Resources.ExportMenu, null,
                (s, e) => Aggregator?.Export.Raise(EventAggregator.SelectedPage));
            dest.Items.Add(Properties.Resources.RemoveMenu, null,
                (s, e) => Aggregator?.Remove.Raise(EventAggregator.SelectedPage));

            dest.Items.Add("-");

            dest.Items.Add(Properties.Resources.PropertyMenu, null,
                (s, e) => Aggregator?.Property.Raise(EventAggregator.SelectedPage));

            return dest;
        }

        #endregion
    }
}
