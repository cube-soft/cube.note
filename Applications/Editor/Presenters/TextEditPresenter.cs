/* ------------------------------------------------------------------------- */
///
/// TextEditPresenter.cs
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
using System.Threading.Tasks;
using Sgry.Azuki;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TextEditPresenter
    /// 
    /// <summary>
    /// TextEditControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextEditPresenter : Cube.Forms.PresenterBase<TextEditControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TextEditPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextEditPresenter(TextEditControl view, PageCollection model)
            : base(view, model)
        {
            Model.ActiveChanged += Model_ActiveChanged;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ActiveChanged
        ///
        /// <summary>
        /// 編集対象となる Page オブジェクトが変更された時に実行される
        /// ハンドラです。
        /// </summary>
        /// 
        /// <remarks>
        /// TODO: ここで View.Focus() を実行しても ListView の MouseUp
        /// 発生時にフォーカスを奪われてしまう模様。対応方法を検討する。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_ActiveChanged(object sender, PageChangedEventArgs e)
        {
            if (e.NewPage == null) return;

            var document = e.NewPage.CreateDocument(Model.Directory);
            document.ContentChanged -= Model_ContentChanged;
            document.ContentChanged += Model_ContentChanged;

            View.Document = document;
            View.Focus();
            View.Refresh();

            Clean(e.OldPage);
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
            if (Model.Active == null || Model.Active.Document != sender) return;

            var document = Model.Active.Document as Document;
            if (document == null) return;

            Model.Active.Abstract = document.GetLineContent(0);
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Clean
        ///
        /// <summary>
        /// 編集対象ではなくなった Page オブジェクトの後処理を行います。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Clean(Page page)
        {
            if (page == null) return;

            Task.Run(() =>
            {
                var document = page.Document as Document;
                if (document != null) document.ContentChanged -= Model_ContentChanged;

                page.SaveDocument(Model.Directory);
            });
        }

        #endregion
    }
}
