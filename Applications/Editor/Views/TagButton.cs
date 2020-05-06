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
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TagButton
    /// 
    /// <summary>
    /// タグの編集用ボタンを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TagButton : Cube.Forms.ToggleButton
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TagButton
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagButton() : this(string.Empty, 1.0) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagButton
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagButton(Tag tag, double ratio) : this(tag?.Name, ratio) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagButton
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagButton(string tag, double ratio) : base()
        {
            var font   = new Font("Meiryo UI", (float)(12.0 * ratio), FontStyle.Regular, GraphicsUnit.Pixel, 128);
            var size   = TextRenderer.MeasureText(tag, font);
            var margin = (int)(4 * ratio);

            Font = font;
            Size = new Size(size.Width + margin, size.Height + margin);
            TextAlign = ContentAlignment.MiddleCenter;
            if (!string.IsNullOrEmpty(tag)) Content = tag;

            Cursor = Cursors.Hand;

            Styles.NormalStyle.BackColor = SystemColors.Control;
            Styles.NormalStyle.BorderColor = SystemColors.ControlDark;
            Styles.NormalStyle.ContentColor = SystemColors.GrayText;
            Styles.NormalStyle.BorderSize = 1;

            Styles.CheckedStyle.BackColor = SystemColors.Highlight;
            Styles.CheckedStyle.BorderColor = SystemColors.HotTrack;
            Styles.CheckedStyle.ContentColor = SystemColors.HighlightText;
            Styles.CheckedStyle.BorderSize = 1;
        }

        #endregion
    }
}
