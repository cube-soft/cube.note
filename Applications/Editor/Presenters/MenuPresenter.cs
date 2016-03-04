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
        : PresenterBase<MenuControl, ConditionsValue>
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
        public MenuPresenter(MenuControl view, SettingsFolder settings, EventAggregator events)
            : base(view, settings.Current, settings, events)
        {
            Events.TagSettings.Handle += Settings_Handle;
            Events.Settings.Handle += Settings_Handle;

            View.UndoMenu.Click += (s, e) => Events.Undo.Raise();
            View.RedoMenu.Click += (s, e) => Events.Redo.Raise();
            View.LogoMenu.Click += View_LogoMenu;
            View.SettingsMenu.Click += Settings_Handle;

            Model.PropertyChanged += Model_PropertyChanged;
        }

        #endregion

        #region Event handlers

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_Handle
        /// 
        /// <summary>
        /// 設定メニューがクリックされた時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_Handle(object sender, EventArgs e)
            => Sync(() =>
        {
            var dialog = new SettingsForm(Settings.User);
            using (var presenter = new SettingsPresenter(dialog, /* User, */ Settings, Events))
            {
                dialog.ShowDialog();
                Events.Refresh.Raise();
            }
        });

        #endregion

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

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        /// 
        /// <summary>
        /// プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender,
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
    }
}
