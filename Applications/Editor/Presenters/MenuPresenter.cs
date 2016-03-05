/* ------------------------------------------------------------------------- */
///
/// MenuPresenter.cs
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
    /// MenuPresenter
    /// 
    /// <summary>
    /// MenuControl とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class MenuPresenter
        : PresenterBase<MenuControl, PageCollection>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MenuPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MenuPresenter(MenuControl view, PageCollection model,
            SettingsFolder settings, EventAggregator events)
            : base(view, model, settings, events)
        {
            Events.Settings.Handle += (s, e) => ShowSettings(0);
            Events.TagSettings.Handle += (s, e) => ShowTagSettings();

            View.UndoMenu.Click += (s, e) => Events.Undo.Raise();
            View.RedoMenu.Click += (s, e) => Events.Redo.Raise();
            View.SettingsMenu.Click += (s, e) => Events.Settings.Raise();
            View.LogoMenu.Click += View_LogoMenu;

            Settings.Current.PropertyChanged += Settings_CurrentChanged;
        }

        #endregion

        #region Event handlers

        #region View

        /* ----------------------------------------------------------------- */
        ///
        /// View_LogoMenu
        /// 
        /// <summary>
        /// ロゴメニューがクリックされた時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_LogoMenu(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(Properties.Resources.WebUrl); }
            catch (Exception err) { Logger.Error(err); }
        }

        #endregion

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_CurrentChanged
        /// 
        /// <summary>
        /// プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_CurrentChanged(object sender,
            PropertyChangedEventArgs e) => Sync(() =>
        {
            switch (e.PropertyName)
            {
                case nameof(Settings.Current.CanUndo):
                    View.UndoMenu.Enabled = Settings.Current.CanUndo;
                    break;
                case nameof(Settings.Current.CanRedo):
                    View.RedoMenu.Enabled = Settings.Current.CanRedo;
                    break;
                default:
                    break;
            }
        });

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// ShowSettings
        /// 
        /// <summary>
        /// 設定フォームを開きます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShowSettings(int index)
            => Sync(() =>
        {
            var dialog = new SettingsForm(Settings.User, index);
            using (var presenter = new SettingsPresenter(dialog, /* User, */ Settings, Events))
            {
                dialog.ShowDialog();
                Events.Refresh.Raise();
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// ShowTagSettings
        /// 
        /// <summary>
        /// タグ設定フォームを開きます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ShowTagSettings()
            => Sync(() =>
        {
            var dialog = new TagForm(Model.Tags);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.Cancel) return;

            var add = dialog.NewTags;
            var remove = dialog.RemoveTags;

            Async(() =>
            {
                foreach (var tag in add) Events.NewTag.Raise(new ValueEventArgs<Tag>(tag));
                foreach (var tag in remove) Events.RemoveTag.Raise(new ValueEventArgs<Tag>(tag));
            });
        });

        #endregion
    }
}
