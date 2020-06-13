/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.Drawing;
using Cube.Generics;
using Cube.Log;

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
            => await Async(() =>
        {
            _backup.Assign(Model);
            Settings.Save();
        });

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
            => Model.Assign(_backup);

        /* ----------------------------------------------------------------- */
        ///
        /// View_Reset
        ///
        /// <summary>
        /// リセットボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /// <remarks>
        /// LastUpdate の項目のみリセット前の状態を受け継ぎます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private async void View_Reset(object sender, EventArgs e)
        {
            await Async(() => Model.Assign(new SettingsValue
            {
                LastUpdate = Model.LastUpdate
            }));
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
            => this.LogWarn(() =>
        {
            switch (e.Key)
            {
                case nameof(Model.Font):
                    var font = e.Value as Font;
                    if (font == null) break;
                    Model.FontName = font.Name;
                    Model.FontSize = font.Size;
                    Model.FontStyle = font.Style;
                    break;
                case nameof(Model.AutoSaveTime):
                    Model.AutoSaveTime = TimeSpan.FromSeconds((int)((decimal)e.Value));
                    break;
                case nameof(Model.PrintMargin):
                case "PrintLeftMargin":
                    Model.PrintMargin.Left = (int)((decimal)e.Value);
                    break;
                case "PrintRightMargin":
                    Model.PrintMargin.Right = (int)((decimal)e.Value);
                    break;
                case "PrintTopMargin":
                    Model.PrintMargin.Top = (int)((decimal)e.Value);
                    break;
                case "PrintBottomMargin":
                    Model.PrintMargin.Bottom = (int)((decimal)e.Value);
                    break;
                default:
                    SetValue(e.Key, e.Value);
                    break;
            }
        });

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// SetValue
        ///
        /// <summary>
        /// 値を設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SetValue(string name, object value)
        {
            var info = typeof(SettingsValue).GetProperty(name);
            if (info == null) return;

            var convert = Convert.ChangeType(value, info.PropertyType);
            info.SetValue(Model, convert);
        }

        #endregion

        #region Fields
        private bool _disposed = false;
        private SettingsValue _backup = new SettingsValue();
        #endregion
    }
}
