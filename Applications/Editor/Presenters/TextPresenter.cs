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
using System.ComponentModel;
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

            View.DoubleClick += View_DoubleClick;
            View.Visible = (Settings.Current.Page != null);

            Settings.Current.PageChanged += Settings_PageChanged;
            
            InitializeTextMenu();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// TextMenu
        ///
        /// <summary>
        /// TextMenuControl を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TextMenuControl TextMenu
            => View.ContextMenuStrip as TextMenuControl;

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

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_DoubleClick
        ///
        /// <summary>
        /// テキストのダブルクリック時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var ev = e as IMouseEventArgs;
                if (ev == null || !Settings.User.OpenUri) return;

                var doc = Settings.Current.Page?.Document as Document;
                if (doc == null || ev.Index >= doc.Length || !doc.IsMarked(ev.Index, Marking.Uri)) return;

                var uri = doc.GetMarkedText(ev.Index, Marking.Uri);
                if (string.IsNullOrEmpty(uri)) return;

                System.Diagnostics.Process.Start(uri);
                ev.Handled = true;
            }
            catch (Exception err) { Logger.Error(err); }
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
            => Sync(() =>
        {
            var document = Settings.Current?.Page?.Document as Document;
            if (document == null || document != sender) return;
            Settings.Current.Page.UpdateAbstract(Settings.MaxAbstractLength);
            Settings.Current.CanUndo  = document.CanUndo;
            Settings.Current.CanRedo  = document.CanRedo;
            Settings.Current.CanCopy  = View.GetSelectedTextLength() > 0;
            Settings.Current.CanPaste = View.CanPaste;
        });

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
            => Sync(() =>
        {
            Settings.Current.CanCopy  = View.GetSelectedTextLength() > 0;
            Settings.Current.CanPaste = View.CanPaste;
            View.ScrollToCaret();
        });

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

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_CurrentChanged
        ///
        /// <summary>
        /// Current のプロパティが変更された時に実行されるハンドラです。
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Settings_CurrentChanged(object sender, PropertyChangedEventArgs e)
            => Sync(() =>
        {
            var menu = TextMenu;
            if (menu == null) return;

            switch (e.PropertyName)
            {
                case nameof(Settings.Current.CanCopy):
                    menu.CutMenu.Enabled    = Settings.Current.CanCopy;
                    menu.CopyMenu.Enabled   = Settings.Current.CanCopy;
                    menu.GoogleMenu.Enabled = Settings.Current.CanCopy;
                    break;
                case nameof(Settings.Current.CanPaste):
                    menu.PasteMenu.Enabled = Settings.Current.CanPaste;
                    break;
                case nameof(Settings.Current.CanUndo):
                    menu.UndoMenu.Enabled = Settings.Current.CanUndo;
                    break;
                case nameof(Settings.Current.CanRedo):
                    menu.RedoMenu.Enabled = Settings.Current.CanRedo;
                    break;
                default:
                    break;
            }
        });

        #endregion

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeTextMenu
        ///
        /// <summary>
        /// コンテキストメニューを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeTextMenu()
        {
            var menu = TextMenu;
            if (menu == null) return;

            Settings.Current.PropertyChanged += Settings_CurrentChanged;

            var enabled = View.GetSelectedTextLength() > 0;
            menu.SearchMenu.Click += (s, e) => 
                Events.Search.Raise(new KeyValueEventArgs<int, string>(0,
                View.GetSelectedText()));

            menu.GoogleMenu.Enabled = enabled;
            menu.GoogleMenu.Click += (s, e)
                => Events.Google.Raise(new ValueEventArgs<string>(View.GetSelectedText()));

            menu.UndoMenu.Enabled = View.CanUndo;
            menu.UndoMenu.Click += (s, e) => Events.Undo.Raise();

            menu.RedoMenu.Enabled = View.CanRedo;
            menu.RedoMenu.Click += (s, e) => Events.Redo.Raise();

            menu.CutMenu.Enabled = enabled;
            menu.CutMenu.Click += (s, e) => View.Cut();

            menu.CopyMenu.Enabled = enabled;
            menu.CopyMenu.Click += (s, e) => View.Copy();

            menu.PasteMenu.Enabled = View.CanPaste;
            menu.PasteMenu.Click += (s, e) => View.Paste();

            menu.SelectAllMenu.Click += (s, e) => View.SelectAll();
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
