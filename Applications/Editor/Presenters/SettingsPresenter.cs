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
    public class SettingsPresenter
        : PresenterBase<SettingsForm, SettingsValue>
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
        public SettingsPresenter(SettingsForm view, SettingsFolder settings,
            EventAggregator events)
            : base(view, settings.User, settings, events)
        {
            View.Apply  += View_Apply;
            View.Cancel += View_Cancel;
            View.Reset  += View_Reset;
            View.PropertyChanged += View_PropertyChanged;

            _backup.Assign(Model);
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

            View.Apply  -= View_Apply;
            View.Cancel -= View_Cancel;
            View.Reset  -= View_Reset;
            View.PropertyChanged -= View_PropertyChanged;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// View_Apply
        /// 
        /// <summary>
        /// 適用ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Apply(object sender, EventArgs e)
        {
            await Async(() =>
            {
                _backup.Assign(Model);
                Settings.Save();
            });
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Cancel
        /// 
        /// <summary>
        /// キャンセルボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_Cancel(object sender, EventArgs e)
        {
            Settings.User.Assign(_backup);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// View_Reset
        /// 
        /// <summary>
        /// リセットボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Reset(object sender, EventArgs e)
        {
            await Async(() => Model.Assign(new SettingsValue()));
            Sync(() => View.Update(Model));
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
                    case nameof(Model.Font):
                        var font = (Font)e.Value;
                        Model.FontName = font.Name;
                        Model.FontSize = font.Size;
                        Model.FontStyle = font.Style;
                        break;
                    case nameof(Model.BackColor):
                        Model.BackColor = (Color)e.Value;
                        break;
                    case nameof(Model.ForeColor):
                        Model.ForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.HighlightBackColor):
                        Model.HighlightBackColor = (Color)e.Value;
                        break;
                    case nameof(Model.HighlightForeColor):
                        Model.HighlightForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.LineNumberBackColor):
                        Model.LineNumberBackColor = (Color)e.Value;
                        break;
                    case nameof(Model.LineNumberForeColor):
                        Model.LineNumberForeColor = (Color)e.Value;
                        break;
                    case nameof(Model.SpecialCharsColor):
                        Model.SpecialCharsColor = (Color)e.Value;
                        break;
                    case nameof(Model.CurrentLineColor):
                        Model.CurrentLineColor = (Color)e.Value;
                        break;
                    case nameof(Model.AutoSaveTime):
                        Model.AutoSaveTime = TimeSpan.FromSeconds((int)((decimal)e.Value));
                        break;
                    case nameof(Model.TabWidth):
                        Model.TabWidth = (int)((decimal)e.Value);
                        break;
                    case nameof(Model.TabToSpace):
                        Model.TabToSpace = (bool)e.Value;
                        break;
                    case nameof(Model.WordWrap):
                        Model.WordWrap = (bool)e.Value;
                        break;
                    case nameof(Model.WordWrapAsWindow):
                        Model.WordWrapAsWindow = (bool)e.Value;
                        break;
                    case nameof(Model.WordWrapCount):
                        Model.WordWrapCount = (int)((decimal)e.Value);
                        break;
                    case nameof(Model.LineNumberVisible):
                        Model.LineNumberVisible = (bool)e.Value;
                        break;
                    case nameof(Model.RulerVisible):
                        Model.RulerVisible = (bool)e.Value;
                        break;
                    case nameof(Model.SpecialCharsVisible):
                        Model.SpecialCharsVisible = (bool)e.Value;
                        break;
                    case nameof(Model.EolVisible):
                        Model.EolVisible = (bool)e.Value;
                        break;
                    case nameof(Model.TabVisible):
                        Model.TabVisible = (bool)e.Value;
                        break;
                    case nameof(Model.SpaceVisible):
                        Model.SpaceVisible = (bool)e.Value;
                        break;
                    case nameof(Model.FullSpaceVisible):
                        Model.FullSpaceVisible = (bool)e.Value;
                        break;
                    case nameof(Model.CurrentLineVisible):
                        Model.CurrentLineVisible = (bool)e.Value;
                        break;
                    case nameof(Model.ModifiedLineVisible):
                        Model.ModifiedLineVisible = (bool)e.Value;
                        break;
                    case nameof(Model.BracketVisible):
                        Model.BracketVisible = (bool)e.Value;
                        break;
                    case nameof(Model.RemoveWarning):
                        Model.RemoveWarning = (bool)e.Value;
                        break;
                    default:
                        Logger.Warn($"Skip:{e.Key}");
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
