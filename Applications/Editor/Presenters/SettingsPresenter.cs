/* ------------------------------------------------------------------------- */
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
                    case nameof(Model.User.Font):
                        var font = (Font)e.Value;
                        Model.User.FontName = font.Name;
                        Model.User.FontSize = font.Size;
                        Model.User.FontStyle = font.Style;
                        break;
                    case nameof(Model.User.BackColor):
                        Model.User.BackColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.ForeColor):
                        Model.User.ForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.HighlightBackColor):
                        Model.User.HighlightBackColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.HighlightForeColor):
                        Model.User.HighlightForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.LineNumberBackColor):
                        Model.User.LineNumberBackColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.LineNumberForeColor):
                        Model.User.LineNumberForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.SpecialCharsColor):
                        Model.User.SpecialCharsColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.CurrentLineColor):
                        Model.User.CurrentLineColor = (Color)e.Value;
                        break;
                    case nameof(Model.User.AutoSaveTime):
                        Model.User.AutoSaveTime = TimeSpan.FromSeconds((int)((decimal)e.Value));
                        break;
                    case nameof(Model.User.TabWidth):
                        Model.User.TabWidth = (int)((decimal)e.Value);
                        break;
                    case nameof(Model.User.TabToSpace):
                        Model.User.TabToSpace = (bool)e.Value;
                        break;
                    case nameof(Model.User.WordWrap):
                        Model.User.WordWrap = (bool)e.Value;
                        break;
                    case nameof(Model.User.WordWrapAsWindow):
                        Model.User.WordWrapAsWindow = (bool)e.Value;
                        break;
                    case nameof(Model.User.WordWrapCount):
                        Model.User.WordWrapCount = (int)((decimal)e.Value);
                        break;
                    case nameof(Model.User.LineNumberVisible):
                        Model.User.LineNumberVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.RulerVisible):
                        Model.User.RulerVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.SpecialCharsVisible):
                        Model.User.SpecialCharsVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.EolVisible):
                        Model.User.EolVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.TabVisible):
                        Model.User.TabVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.SpaceVisible):
                        Model.User.SpaceVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.FullSpaceVisible):
                        Model.User.FullSpaceVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.CurrentLineVisible):
                        Model.User.CurrentLineVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.ModifiedLineVisible):
                        Model.User.ModifiedLineVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.BracketVisible):
                        Model.User.BracketVisible = (bool)e.Value;
                        break;
                    case nameof(Model.User.RemoveWarning):
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
