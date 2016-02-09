/* ------------------------------------------------------------------------- */
///
/// StatusPresenter.cs
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
using Sgry.Azuki;
using Cube.Note.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// StatusPresenter
    /// 
    /// <summary>
    /// StatusControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class StatusPresenter : Cube.Forms.PresenterBase<StatusControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// StatusPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        /// 
        /// <remarks>
        /// TODO: TextControl を引数に渡さない方法がないか検討する。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public StatusPresenter(StatusControl view, PageCollection model, TextControl control) : base(view, model)
        {
            Model.ActiveChanged += Model_ActiveChanged;
            control.CaretMoved  += (s, e) => UpdatePosition(control.Document);
        }

        #endregion

        #region Event handlers

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ActiveChanged
        ///
        /// <summary>
        /// 編集対象となる Page オブジェクトが変更された時に実行される
        /// ハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Model_ActiveChanged(object sender, PageChangedEventArgs e)
        {
            lock (e.NewPage)
            {
                Sync(() => UpdateView(
                    e.NewPage != null ?
                    e.NewPage.CreateDocument(Model.Directory) :
                    null
                ));
            }

            UpdateModel(e.NewPage, e.OldPage);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ContentChanged
        ///
        /// <summary>
        /// Document オブジェクトの内容が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_ContentChanged(object sender, ContentChangedEventArgs e)
        {
            Sync(() => UpdateView(
                Model.Active != null ?
                Model.Active.Document as Document :
                null
            ));
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateView
        ///
        /// <summary>
        /// View の状態を更新します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void UpdateView(Document src)
        {
            var count = (src != null) ? src.Length    : 0;
            var line  = (src != null) ? src.LineCount : 0;

            View.Count     = count - line + 1;
            View.LineCount = line;

            UpdatePosition(src);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdatePosition
        ///
        /// <summary>
        /// キャレット位置の表示を更新します。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void UpdatePosition(Document src)
        {
            var line   = 0;
            var column = 0;
            if (src != null) src.GetCaretIndex(out line, out column);

            View.LineNumber   = line + 1;
            View.ColumnNumber = column + 1;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateModel
        ///
        /// <summary>
        /// Model の状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateModel(Page newpage, Page oldpage)
        {
            if (newpage != null)
            {
                var document = newpage.Document as Document;
                if (document != null)
                {
                    document.ContentChanged -= Model_ContentChanged;
                    document.ContentChanged += Model_ContentChanged;
                }
            }

            if (oldpage != null)
            {
                var document = oldpage.Document as Document;
                if (document != null) document.ContentChanged -= Model_ContentChanged;
            }
        }

        #endregion
    }
}
