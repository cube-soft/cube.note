/* ------------------------------------------------------------------------- */
///
/// TextPresenter.cs
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
    /// TextPresenter
    /// 
    /// <summary>
    /// TextControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TextPresenter : Cube.Forms.PresenterBase<TextControl, PageCollection>
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
        public TextPresenter(TextControl view, PageCollection model)
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
        /* ----------------------------------------------------------------- */
        private void Model_ActiveChanged(object sender, PageChangedEventArgs e)
        {
            try
            {
                if (e.NewPage == null) return;

                var document = e.NewPage.CreateDocument(Model.Directory);
                System.Diagnostics.Debug.Assert(document != null);

                Sync(() =>
                {
                    View.Document = document;
                    View.ResetViewWidth();
                    View.ScrollToCaret();
                    View.Focus();
                });
            }
            finally { UpdateModel(e.NewPage, e.OldPage); }
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
            Model.Active.Abstract = Abstract(Model.Active.Document as Document);
        }

        #endregion

        #region Implementations

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

        /* ----------------------------------------------------------------- */
        ///
        /// Abstract
        ///
        /// <summary>
        /// 概要を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string Abstract(Document document)
        {
            if (document == null) return string.Empty;

            for (var i = 0; i < document.LineCount; ++i)
            {
                var content = document.GetLineContent(i).Trim();
                if (content.Length > 0) return content;
            }
            return string.Empty;
        }

        #endregion
    }
}
