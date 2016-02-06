/* ------------------------------------------------------------------------- */
///
/// TitleControl.cs
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
    /// TitleControl
    /// 
    /// <summary>
    /// タイトルバーを表すクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class TitleControl : Cube.Forms.UserControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TitleControl
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TitleControl()
        {
            InitializeComponent();

            ExitButton.Click += (s, e) => OnCloseRequired(e);
            MaximizeButton.Click += (s, e) => OnMaximizeRequired(e);
            MinimizeButton.Click += (s, e) => OnMinimizeRequired(e);
            ButtonsPanel.Resize += ButtonsPanel_Resize;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// MaximizeBox
        ///
        /// <summary>
        /// 最大化ボタンを表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool MaximizeBox
        {
            get { return MaximizeButton.Visible; }
            set { MaximizeButton.Visible = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// MinimizeBox
        ///
        /// <summary>
        /// 最小化ボタンを表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool MinimizeBox
        {
            get { return MinimizeButton.Visible; }
            set { MinimizeButton.Visible = value; }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// CloseRequired
        ///
        /// <summary>
        /// 終了の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler CloseRequired;

        /* ----------------------------------------------------------------- */
        ///
        /// MaximizeRequired
        ///
        /// <summary>
        /// 最大化の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler MaximizeRequired;

        /* ----------------------------------------------------------------- */
        ///
        /// MinimizeRequired
        ///
        /// <summary>
        /// 最小化の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler MinimizeRequired;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCloseRequired
        ///
        /// <summary>
        /// Close イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnCloseRequired(EventArgs e)
        {
            if (CloseRequired != null) CloseRequired(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnMaximizeRequired
        ///
        /// <summary>
        /// MaximizeRequired イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnMaximizeRequired(EventArgs e)
        {
            if (MaximizeRequired != null) MaximizeRequired(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnMinimizeRequired
        ///
        /// <summary>
        /// MinimizeRequired イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnMinimizeRequired(EventArgs e)
        {
            if (MinimizeRequired != null) MinimizeRequired(this, e);
        }

        #endregion

        #region Override methods

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

            ExitButton.ForeColor     = BackColor;
            MaximizeButton.ForeColor = BackColor;
            MinimizeButton.ForeColor = BackColor;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ButtonsPanel_Resize
        ///
        /// <summary>
        /// リサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ButtonsPanel_Resize(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            var height = control.Height;
            ExitButton.Height = height;
            MaximizeButton.Height = height;
            MinimizeButton.Height = height;
        }

        #endregion
    }
}
