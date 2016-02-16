/* ------------------------------------------------------------------------- */
///
/// SearchControl.cs
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
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SearchControl
    /// 
    /// <summary>
    /// 検索画面を表示するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class SearchControl : Cube.Forms.UserControl
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SearchControl
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SearchControl()
        {
            InitializeComponent();

            SearchButton.Click += (s, e) => RaiseSearchExecuted();
            KeywordTextBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) RaiseSearchExecuted(); };

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Found
        ///
        /// <summary>
        /// 検索に一致した件数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Found { get; set; } = 0;

        /* ----------------------------------------------------------------- */
        ///
        /// Pages
        ///
        /// <summary>
        /// ページ一覧を表示する ListView オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageListView Pages => PageListView;

        /* ----------------------------------------------------------------- */
        ///
        /// Aggregator
        ///
        /// <summary>
        /// イベントを集約するオブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventAggregator Aggregator { get; set; }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Attached
        ///
        /// <summary>
        /// コントロールがパネルに追加された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Attached;

        /* ----------------------------------------------------------------- */
        ///
        /// Attached
        ///
        /// <summary>
        /// コントロールがパネルから削除された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Detached;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Switch
        /// 
        /// <summary>
        /// 現在状態に応じて Attach または Detach を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Switch(Control parent)
        {
            if (Parent == parent) Detach();
            else Attach(parent);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Attach
        /// 
        /// <summary>
        /// コントロールから他の子要素を退避させ、自コントロールを挿入します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Attach(Control parent)
        {
            if (Parent == parent) return;

            _controls.Clear();
            foreach (Control control in parent.Controls) _controls.Add(control);
            parent.Controls.Clear();
            parent.Controls.Add(this);
            KeywordTextBox.Focus();

            OnAttached(EventArgs.Empty);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Detach
        /// 
        /// <summary>
        /// 自コントロールを除去し、退避させた子要素を元に戻します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Detach()
        {
            if (Parent == null) return;

            var parent = Parent;
            Parent.Controls.Remove(this);
            foreach (var control in _controls) parent.Controls.Add(control);
            _controls.Clear();

            OnDetached(EventArgs.Empty);
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnAttached
        /// 
        /// <summary>
        /// Attached イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnAttached(EventArgs e)
            => Attached?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnDetached
        /// 
        /// <summary>
        /// Detached イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnDetached(EventArgs e)
            => Detached?.Invoke(this, e);

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// RaiseSearchExecuted
        ///
        /// <summary>
        /// Search イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RaiseSearchExecuted()
            => Aggregator?.Search.Raise(new ValueEventArgs<string>(KeywordTextBox.Text));

        #endregion

        #region Fields
        private IList<Control> _controls = new List<Control>();
        #endregion
    }
}
