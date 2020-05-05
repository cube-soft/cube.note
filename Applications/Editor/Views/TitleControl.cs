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
using System.Drawing;

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
    public partial class TitleControl : Cube.Forms.CaptionControl, IDpiAwarable
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

            ExitButton.Click += (s, e) => OnCloseExecuted(e);
            MaximizeButton.Click += (s, e) => OnMaximizeExecuted(e);
            MinimizeButton.Click += (s, e) => OnMinimizeExecuted(e);
            ButtonsPanel.Resize += ButtonsPanel_Resize;

            if (DesignMode) UpdateLayout(1.0);
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateLayout
        ///
        /// <summary>
        /// レイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void UpdateLayout(double ratio)
        {
            _maximize  = Images.Get("maximize", ratio);
            _normalize = Images.Get("normalize", ratio);

            LayoutPanel.ColumnStyles[0].Width = (int)(120 * ratio);

            var size = new Size((int)(45 * ratio), (int)(30 * ratio));

            TitlePictureBox.Image = Images.Get("title", ratio);

            MaximizeButton.Image = _maximize;
            MaximizeButton.Size  = size;

            MinimizeButton.Image = Images.Get("minimize", ratio);
            MinimizeButton.Size  = size;

            ExitButton.Image = Images.Get("close", ratio);
            ExitButton.Size  = size;
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// CloseExecuted
        ///
        /// <summary>
        /// 終了の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler CloseExecuted;

        /* ----------------------------------------------------------------- */
        ///
        /// MaximizeExecuted
        ///
        /// <summary>
        /// 最大化の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler MaximizeExecuted;

        /* ----------------------------------------------------------------- */
        ///
        /// MinimizeExecuted
        ///
        /// <summary>
        /// 最小化の要求時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler MinimizeExecuted;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCloseExecuted
        ///
        /// <summary>
        /// CloseExecuted イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnCloseExecuted(EventArgs e)
            => CloseExecuted?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnMaximizeExecuted
        ///
        /// <summary>
        /// MaximizeExecuted イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnMaximizeExecuted(EventArgs e)
            => MaximizeExecuted?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnMinimizeExecuted
        ///
        /// <summary>
        /// MinimizeExecuted イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnMinimizeExecuted(EventArgs e)
            => MinimizeExecuted?.Invoke(this, e);

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnCreateControl
        ///
        /// <summary>
        /// コントロールが生成された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ResetEvents();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnParentChanged
        ///
        /// <summary>
        /// 親コントロールが変更された時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            ResetEvents();
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

            ExitButton.ForeColor     = BackColor;
            MaximizeButton.ForeColor = BackColor;
            MinimizeButton.ForeColor = BackColor;
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// Form_Resize
        ///
        /// <summary>
        /// フォームのリサイズ時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Form_Resize(object sender, EventArgs e)
        {
            var form = sender as Form;
            if (form == null) return;

            MaximizeButton.Image = form.WindowState == FormWindowState.Maximized ?
                                   _normalize :
                                   _maximize;
        }

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

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// ResetEvents
        ///
        /// <summary>
        /// イベントに関する設定をリセットします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ResetEvents()
        {
            var form = FindForm();
            if (form == null) return;

            form.Resize -= Form_Resize;
            form.Resize += Form_Resize;
        }

        #endregion

        #region Fields
        private Image _maximize  = null;
        private Image _normalize = null;
        #endregion
    }
}
