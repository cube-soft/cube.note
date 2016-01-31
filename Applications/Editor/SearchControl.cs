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

            SearchButton.Click += (s, e) => OnSearch(new DataEventArgs<string>(KeywordTextBox.Text));
            PageCollectionControl.Added += (s, e) => OnAdded(e);
            PageCollectionControl.Cleared += (s, e) => OnCleared(e);
            PageCollectionControl.SelectedIndexChanged += (s, e) => OnSelectedIndexChanged(e);

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Added
        ///
        /// <summary>
        /// ページが追加された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<DataEventArgs<int>> Added;

        /* ----------------------------------------------------------------- */
        ///
        /// Cleared
        ///
        /// <summary>
        /// ページが全て削除された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Cleared;

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

        /* ----------------------------------------------------------------- */
        ///
        /// SelectedIndexChanged
        ///
        /// <summary>
        /// 選択項目が変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler SelectedIndexChanged;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        /// 
        /// <summary>
        /// ページを追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Add(Page item)
        {
            PageCollectionControl.Add(item);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Clear
        /// 
        /// <summary>
        /// ページを全て削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Clear()
        {
            PageCollectionControl.Clear();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Select
        /// 
        /// <summary>
        /// ページを削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Select(int index)
        {
            PageCollectionControl.Select(index);
        }

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
        /// OnAdded
        ///
        /// <summary>
        /// Added イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnAdded(DataEventArgs<int> e)
        {
            if (Added != null) Added(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnCleared
        ///
        /// <summary>
        /// Cleared イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnCleared(EventArgs e)
        {
            if (Cleared != null) Cleared(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnSearch
        /// 
        /// <summary>
        /// 検索時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSearch(DataEventArgs<string> e)
        {
            if (Search != null) Search(this, e);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnSelectedIndexChanged
        ///
        /// <summary>
        /// SelectedIndexChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null) SelectedIndexChanged(this, e);
        }

        #endregion

        #region Fields
        private IList<Control> _controls = new List<Control>();
        #endregion
    }
}
