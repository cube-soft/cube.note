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
using System;
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
            Events.Refresh.Handle += Refresh_Handle;
            Events.Undo.Handle += Undo_Handle;
            Events.Redo.Handle += Redo_Handle;
            Settings.Current.PageChanged += Settings_PageChanged;
        }

        #endregion

        #region Event handlers

        #region EventAggregator

        /* ----------------------------------------------------------------- */
        ///
        /// Refresh_Handle
        ///
        /// <summary>
        /// 再描画時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Refresh_Handle(object sender, EventArgs e)
            => Sync(() => View.Refresh());

        /* ----------------------------------------------------------------- */
        ///
        /// Undo_Handle
        ///
        /// <summary>
        /// Undo 時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Undo_Handle(object sender, EventArgs e)
        {
            var document = Settings.Current?.Page?.Document as Document;
            if (document == null || !document.CanUndo) return;
            document.Undo();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Redo_Handle
        ///
        /// <summary>
        /// Redo 時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Redo_Handle(object sender, EventArgs e)
        {
            var document = Settings.Current?.Page?.Document as Document;
            if (document == null || !document.CanRedo) return;
            document.Redo();
        }

        #endregion

        #region Model

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
            Settings.Current.Page.UpdateAbstract(Settings.MaxAbstractLength);
            Settings.Current.CanUndo = document.CanUndo;
            Settings.Current.CanRedo = document.CanRedo;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_SelectionChanged
        ///
        /// <summary>
        /// 選択範囲が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sync(() => View.ScrollToCaret());
        }

        #endregion

        #region Settings

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

                    Settings.Current.CanUndo = document.CanUndo;
                    Settings.Current.CanRedo = document.CanRedo;
                });
            }
            finally { UpdateModel(e.NewValue, e.OldValue); }
        }

        #endregion

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
                newdoc.ContentChanged   -= Model_ContentChanged;
                newdoc.SelectionChanged -= Model_SelectionChanged;
                newdoc.ContentChanged   += Model_ContentChanged;
                newdoc.SelectionChanged += Model_SelectionChanged;
            }

            var olddoc = oldpage?.Document as Document;
            if (olddoc != null)
            {
                olddoc.ContentChanged   -= Model_ContentChanged;
                olddoc.SelectionChanged -= Model_SelectionChanged;
            }
        }

        #endregion
    }
}
