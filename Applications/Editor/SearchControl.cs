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

            SearchButton.Click += (s, e) => RaiseSearchEvent();
            KeywordTextBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) RaiseSearchEvent(); };

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// ListView
        ///
        /// <summary>
        /// ページ一覧を表示する ListView オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageListView ListView
        {
            get { return PageListView; }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        /// 
        /// <summary>
        /// 検索が実行された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventHandler<DataEventArgs<string>> Search;

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
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnSearch
        /// 
        /// <summary>
        /// Search イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSearch(DataEventArgs<string> e)
        {
            if (Search != null) Search(this, e);
        }

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// RaiseSearchEvent
        ///
        /// <summary>
        /// Search イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RaiseSearchEvent()
        {
            OnSearch(new DataEventArgs<string>(KeywordTextBox.Text));
        }

        #endregion

        #region Fields
        private IList<Control> _controls = new List<Control>();
        #endregion
    }
}
