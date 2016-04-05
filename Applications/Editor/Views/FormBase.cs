/* ------------------------------------------------------------------------- */
///
/// FormBase.cs
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
    /// FormBase
    /// 
    /// <summary>
    /// フォーム外観の共通部分を定義したクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class FormBase : Cube.Forms.WidgetForm
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// FormBase
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public FormBase()
        {
            InitializeComponent();

            Activated  += (s, e) => BackColor = Color.FromArgb(0, 169, 157);
            Deactivate += (s, e) => BackColor = Color.FromArgb(186, 224, 215);
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoad
        ///
        /// <summary>
        /// ロード時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var control = Caption as TitleControl;
            if (control == null) return;

            control.CloseExecuted    += (s, ev) => Close();
            control.MaximizeExecuted += (s, ev) => Maximize();
            control.MinimizeExecuted += (s, ev) => Minimize();

            control.MaximizeBox = MaximizeBox && Sizable;
            control.MinimizeBox = MinimizeBox;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnBackColorChanged
        ///
        /// <summary>
        /// 背景色が変更された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (Caption == null) return;
            Caption.BackColor = BackColor;
        }

        #endregion
    }
}
