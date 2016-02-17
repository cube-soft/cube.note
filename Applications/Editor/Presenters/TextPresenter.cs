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
    public class TextPresenter
        : PresenterBase<TextControl, PageCollection>
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
        public TextPresenter(TextControl view, PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            Settings.Current.PageChanged += Settings_PageChanged;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_PageChanged
        ///
        /// <summary>
        /// 編集対象となる Page オブジェクトが変更された時に実行されるハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Settings_PageChanged(object sender, ValueChangedEventArgs<Page> e)
        {
            try
            {
                var document = e.NewValue?.CreateDocument(Model.Directory);

                Sync(() =>
                {
                    View.Visible = (document != null);
                    if (document == null) return;

                    View.Document = document;
                    View.ResetViewWidth();
                    View.ScrollToCaret();
                });
            }
            finally { UpdateModel(e.NewValue, e.OldValue); }
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
            var document = Settings.Current?.Page?.Document as Document;
            if (document == null || document != sender) return;
            Settings.Current.Page.Abstract = GetAbstract(document);
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
            var newdoc = newpage?.Document as Document;
            if (newdoc != null)
            {
                newdoc.ContentChanged -= Model_ContentChanged;
                newdoc.ContentChanged += Model_ContentChanged;
            }

            var olddoc = oldpage?.Document as Document;
            if (olddoc != null) olddoc.ContentChanged -= Model_ContentChanged;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetAbstract
        ///
        /// <summary>
        /// 概要を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string GetAbstract(Document document)
        {
            for (var i = 0; i < document.LineCount; ++i)
            {
                var content = document.GetLineContent(i).Trim();
                if (content.Length <= 0) continue;

                return content.Length > Settings.MaxAbstractLength ?
                       content.Substring(0, Settings.MaxAbstractLength) :
                       content;
            }
            return string.Empty;
        }

        #endregion
    }
}
