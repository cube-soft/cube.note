/* ------------------------------------------------------------------------- */
///
/// SettingsControl.cs
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
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsControl
    /// 
    /// <summary>
    /// 設定画面の補助用クラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class SettingsControl : Cube.Forms.SettingsControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsControl
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsControl() : base() { }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// ColorButtonChanged
        ///
        /// <summary>
        /// 色設定ボタンの内容が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void ColorButtonChanged(object sender, EventArgs e)
        {
            base.ColorButtonChanged(sender, e);

            var src  = sender as Control;
            var dest = src?.Parent.GetNextControl(src, true) as Label;
            if (dest == null) return;

            var color = src.BackColor;
            var text  = $"({color.R}, {color.G}, {color.B})";
            if (dest.Text == text) return;

            dest.Text = text;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FontButtonChanged
        ///
        /// <summary>
        /// フォント設定ボタンの内容が変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void FontButtonChanged(object sender, EventArgs e)
        {
            base.FontButtonChanged(sender, e);

            var src  = sender as Control;
            var dest = src?.Parent.GetNextControl(src, true) as Label;
            if (dest == null) return;

            var font = src.Font;
            var text = $"({font.Name}, {font.Size}pt)";
            if (dest.Text == text) return;

            dest.Text = text;
        }

        protected override void CheckUpdateType(Control control, string propertyname, object value)
        {
            if (propertyname == "AutoSaveTime")
            {
                if (!(value is TimeSpan)) return;
                var numeric = (NumericUpDown)control;
                numeric.Value = (int)((TimeSpan)value).TotalSeconds;
            }
            else base.CheckUpdateType(control, propertyname, value);
        }
        #endregion
    }
}
