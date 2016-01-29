/* ------------------------------------------------------------------------- */
///
/// PageCollectionPresenter.cs
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollectionPresenter
    /// 
    /// <summary>
    /// PageCollectionControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageCollectionPresenter : Cube.Forms.PresenterBase<PageCollectionControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollectionPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollectionPresenter(PageCollectionControl view, PageCollection model)
            : base(view, model)
        {
            Model.CollectionChanged += Model_CollectionChanged;
            View.FindForm().FormClosing += View_Closing;

            var _ = InitializeAsync();
        }

        #endregion

        #region Event handlers

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_Closing
        /// 
        /// <summary>
        /// フォームを閉じる時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Closing(object sender, FormClosingEventArgs e)
        {
            Model.Save(Properties.Resources.OrderFileName);
        }

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_CollectionChanged
        /// 
        /// <summary>
        /// コレクションの内容に変更があった時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Send(() =>
                    {
                        var index = e.NewStartingIndex;
                        View.Insert(index, Model[index]);
                    });
                    break;
            }
        }

        #endregion

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeAsync
        /// 
        /// <summary>
        /// View および Model を非同期で初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Task InitializeAsync()
        {
            return Task.Run(() =>
            {
                Model.Load(Properties.Resources.OrderFileName);
                if (Model.Count <= 0) Model.NewPage();
                Post(() => View.Select(0));
            });
        }

        #endregion
    }
}
