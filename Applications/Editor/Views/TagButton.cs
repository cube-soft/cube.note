﻿/* ------------------------------------------------------------------------- */
///
/// TagButton.cs
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
        public TagButton() : this(string.Empty) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagButton
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagButton(Tag tag) : this(tag?.Name) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagButton
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagButton(string tag) : base()
        {
            Size = new Size(75, 25);
            AutoSize = true;
            TextAlign = ContentAlignment.MiddleCenter;
            if (!string.IsNullOrEmpty(tag)) Text = tag;

            Cursor = Cursors.Hand;

            Surface.BackColor = SystemColors.Control;
            Surface.BorderColor = SystemColors.ControlDark;
            Surface.TextColor = SystemColors.GrayText;
            Surface.BorderSize = 1;

            CheckedSurface.BackColor = SystemColors.Highlight;
            CheckedSurface.BorderColor = SystemColors.HotTrack;
            CheckedSurface.TextColor = SystemColors.HighlightText;
            CheckedSurface.BorderSize = 1;
        }

        #endregion
    }
}