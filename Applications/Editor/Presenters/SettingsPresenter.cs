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
    public class SettingsPresenter : Cube.Forms.PresenterBase<SettingsForm, SettingsValue>, IDisposable
    {
        #region Constructors and destructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsPresenter
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsPresenter(SettingsForm view, SettingsValue model) : base(view, model)
        {
            View.Applied         += View_Applied;
            View.Canceled        += View_Canceled;
            View.PropertyChanged += View_PropertyChanged;

            _backup.Assign(Model);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ~SettingsPresenter()
        /// 
        /// <summary>
        /// オブジェクトを破棄します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        ~SettingsPresenter()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        /// 
        /// <summary>
        /// オブジェクトを破棄する際に必要な終了処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
            if (!disposing) return;

            View.Applied         -= View_Applied;
            View.Canceled        -= View_Canceled;
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
        private void View_Applied(object sender, EventArgs e)
        {
            _backup.Assign(Model);
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
            Model.Assign(_backup);
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
                        Model.FontName = font.Name;
                        Model.FontSize = font.Size;
                        Model.FontStyle = font.Style;
                        break;
                    case "BackColor":
                        Model.BackColor = (Color)e.Value;
                        break;
                    case "ForeColor":
                        Model.ForeColor = (Color)e.Value;
                        break;
                    case "LineNumberBackColor":
                        Model.LineNumberBackColor = (Color)e.Value;
                        break;
                    case "LineNumberForeColor":
                        Model.LineNumberForeColor = (Color)e.Value;
                        break;
                    case "AutoSaveTime":
                        Model.AutoSaveTime = TimeSpan.FromSeconds((int)((decimal)e.Value));
                        break;
                    case "TabWidth":
                        Model.TabWidth = (int)((decimal)e.Value);
                        break;
                    case "TabToSpace":
                        Model.TabToSpace = (bool)e.Value;
                        break;
                    case "LineNumberVisible":
                        Model.LineNumberVisible = (bool)e.Value;
                        break;
                    case "RulerVisible":
                        Model.RulerVisible = (bool)e.Value;
                        break;
                    case "SpecialCharsVisible":
                        Model.SpecialCharsVisible = (bool)e.Value;
                        break;
                    case "EolVisible":
                        Model.EolVisible = (bool)e.Value;
                        break;
                    case "TabVisible":
                        Model.TabVisible = (bool)e.Value;
                        break;
                    case "SpaceVisible":
                        Model.SpaceVisible = (bool)e.Value;
                        break;
                    case "FullSpaceVisible":
                        Model.FullSpaceVisible = (bool)e.Value;
                        break;
                    case "CurrentLineVisible":
                        Model.CurrentLineVisible = (bool)e.Value;
                        break;
                    case "ModifiedLineVisible":
                        Model.ModifiedLineVisible = (bool)e.Value;
                        break;
                    case "BracketVisible":
                        Model.BracketVisible = (bool)e.Value;
                        break;
                    case "RemoveWarning":
                        Model.RemoveWarning = (bool)e.Value;
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
