﻿/* ------------------------------------------------------------------------- */
///
/// SettingsPresenter.cs
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
using System.Drawing;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsPresenter
    /// 
    /// <summary>
    /// SettingsForm とモデルを関連付けるためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class SettingsPresenter : Cube.Forms.PresenterBase<SettingsForm, SettingsFolder>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsPresenter(SettingsForm view, SettingsFolder model) : base(view, model)
        {
            View.Applied         += View_Applied;
            View.Canceled        += View_Canceled;
            View.Reset           += View_Reset;
            View.PropertyChanged += View_PropertyChanged;

            _backup.Assign(Model.User);
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        /// 
        /// <summary>
        /// オブジェクトを破棄する際に必要な終了処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (!disposing) return;

            View.Applied         -= View_Applied;
            View.Canceled        -= View_Canceled;
            View.Reset           -= View_Reset;
            View.PropertyChanged -= View_PropertyChanged;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// View_Applied
        /// 
        /// <summary>
        /// 適用ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Applied(object sender, EventArgs e)
        {
            await Async(() =>
            {
                _backup.Assign(Model.User);
                Model.Save();
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Canceled
        /// 
        /// <summary>
        /// キャンセルボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Canceled(object sender, EventArgs e)
        {
            Model.User.Assign(_backup);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Canceled
        /// 
        /// <summary>
        /// キャンセルボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Reset(object sender, EventArgs e)
        {
            await Async(() => Model.User.Assign(new SettingsValue()));
            Sync(() => View.Update(Model.User));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_PropertyChanged
        /// 
        /// <summary>
        /// View の内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_PropertyChanged(object sender, KeyValueEventArgs<string, object> e)
        {
            try
            {
                switch (e.Key)
                {
                    case "Font":
                        var font = (Font)e.Value;
                        Model.User.FontName = font.Name;
                        Model.User.FontSize = font.Size;
                        Model.User.FontStyle = font.Style;
                        break;
                    case "BackColor":
                        Model.User.BackColor = (Color)e.Value;
                        break;
                    case "ForeColor":
                        Model.User.ForeColor = (Color)e.Value;
                        break;
                    case "HighlightBackColor":
                        Model.User.HighlightBackColor = (Color)e.Value;
                        break;
                    case "HighlightForeColor":
                        Model.User.HighlightForeColor = (Color)e.Value;
                        break;
                    case "LineNumberBackColor":
                        Model.User.LineNumberBackColor = (Color)e.Value;
                        break;
                    case "LineNumberForeColor":
                        Model.User.LineNumberForeColor = (Color)e.Value;
                        break;
                    case "SpecialCharsColor":
                        Model.User.SpecialCharsColor = (Color)e.Value;
                        break;
                    case "CurrentLineColor":
                        Model.User.CurrentLineColor = (Color)e.Value;
                        break;
                    case "AutoSaveTime":
                        Model.User.AutoSaveTime = TimeSpan.FromSeconds((int)((decimal)e.Value));
                        break;
                    case "TabWidth":
                        Model.User.TabWidth = (int)((decimal)e.Value);
                        break;
                    case "TabToSpace":
                        Model.User.TabToSpace = (bool)e.Value;
                        break;
                    case "WordWrap":
                        Model.User.WordWrap = (bool)e.Value;
                        break;
                    case "WordWrapAsWindow":
                        Model.User.WordWrapAsWindow = (bool)e.Value;
                        break;
                    case "WordWrapCount":
                        Model.User.WordWrapCount = (int)((decimal)e.Value);
                        break;
                    case "LineNumberVisible":
                        Model.User.LineNumberVisible = (bool)e.Value;
                        break;
                    case "RulerVisible":
                        Model.User.RulerVisible = (bool)e.Value;
                        break;
                    case "SpecialCharsVisible":
                        Model.User.SpecialCharsVisible = (bool)e.Value;
                        break;
                    case "EolVisible":
                        Model.User.EolVisible = (bool)e.Value;
                        break;
                    case "TabVisible":
                        Model.User.TabVisible = (bool)e.Value;
                        break;
                    case "SpaceVisible":
                        Model.User.SpaceVisible = (bool)e.Value;
                        break;
                    case "FullSpaceVisible":
                        Model.User.FullSpaceVisible = (bool)e.Value;
                        break;
                    case "CurrentLineVisible":
                        Model.User.CurrentLineVisible = (bool)e.Value;
                        break;
                    case "ModifiedLineVisible":
                        Model.User.ModifiedLineVisible = (bool)e.Value;
                        break;
                    case "BracketVisible":
                        Model.User.BracketVisible = (bool)e.Value;
                        break;
                    case "RemoveWarning":
                        Model.User.RemoveWarning = (bool)e.Value;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception err) { Logger.Error(err); }
        }

        #endregion

        #region Fields
        private bool _disposed = false;
        private SettingsValue _backup = new SettingsValue();
        #endregion
    }
}
