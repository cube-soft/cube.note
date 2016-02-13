/* ------------------------------------------------------------------------- */
///
/// TagCollectionPresenter.cs
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
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TagCollectionPresenter
    /// 
    /// <summary>
    /// タグ一覧と Model を関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TagCollectionPresenter
        : PresenterBase<ComboBox, TagCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TagCollectionPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollectionPresenter(ComboBox view, PageCollection pages,
            SettingsFolder settings, EventAggregator events)
            : base(view, pages.Tags, settings, events)
        {
            SystemTags = pages.SystemTags;

            Model.CollectionChanged += Model_CollectionChanged;
            View.SelectedIndexChanged += View_SelectedIndexChanged;

            System.Diagnostics.Debug.Assert(SystemTags.Count > 0);
            foreach (var tag in SystemTags) View.Items.Add(tag);
            View.SelectedIndex = 0;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// SystemTags
        ///
        /// <summary>
        /// システムで予約されているタグ一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection SystemTags { get; }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// View_SelectedIndexChanged
        ///
        /// <summary>
        /// 選択されている項目が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Settings.Current.Tag = View.SelectedItem as Tag;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_CollectionChanged
        ///
        /// <summary>
        /// タグの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    SyncWait(() => View.Items.Add(Model[e.NewStartingIndex]));
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
