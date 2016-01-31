﻿/* ------------------------------------------------------------------------- */
///
/// MainForm.cs
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
using System.Reflection;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// MainForm
    /// 
    /// <summary>
    /// メイン画面を表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class MainForm : Cube.Forms.Form
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public MainForm()
        {
            InitializeComponent();
            InitializeEvents();
            InitializePresenters();
        }

        #endregion

        #region Initialize methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeEvents
        ///
        /// <summary>
        /// 各種イベントハンドラを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeEvents()
        {
            PageCollectionControl.ParentChanged += PageCollectionControl_ParentChanged;
            RemoveMenuItem.Click += RemoveMenuItem_Click;
            SearchMenuItem.Click += SearchMenuItem_Click;
            FontMenuItem.Click += (s, e) => TextEditControl.SelectFont();
            VisibleMenuItem.Click += (s, e) => ChangeMenuPanelVisibility();
            NewPageMenuItem.Click += (s, e) => PageCollectionControl.NewPage();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeLayout
        ///
        /// <summary>
        /// レイアウトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeLayout()
        {
            VisibleMenuItem.Tag = true;

            var area = Screen.FromControl(this).WorkingArea.Size;
            Width  = (int)(area.Width  * 0.7);
            Height = (int)(area.Height * 0.7);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializePresenters
        ///
        /// <summary>
        /// 各種 Presenter を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializePresenters()
        {
            new TextEditPresenter(TextEditControl, Pages);
            new PageCollectionPresenter(PageCollectionControl, Pages);
            new SearchPresenter(SearchControl, Pages);
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoad
        ///
        /// <summary>
        /// ロード時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeLayout();
            Saver = new AutoSaver(Pages);
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollectionControl_ParentChanged
        ///
        /// <summary>
        /// 親コントロールが変更された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void PageCollectionControl_ParentChanged(object sender, EventArgs e)
        {
            var active = IsActive(PageCollectionControl);
            NewPageMenuItem.Enabled = active;
            RemoveMenuItem.Enabled = active;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveMenuItem_Click
        ///
        /// <summary>
        /// 削除メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            var index = PageCollectionControl.SelectedIndex;
            PageCollectionControl.Remove(index);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMenuItem_Click
        ///
        /// <summary>
        /// 検索メニューが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            SearchControl.Switch(ContentsPanel.Panel1);
            SearchMenuItem.Image = IsActive(SearchControl) ?
                                   Properties.Resources.SearchEnd :
                                   Properties.Resources.Search;
        }

        #endregion

        #region Other private methods

        /* ----------------------------------------------------------------- */
        ///
        /// IsActive
        ///
        /// <summary>
        /// コントロールがアクティブ状態になっているかどうかを判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private bool IsActive(Control control)
        {
            return control.Parent == ContentsPanel.Panel1;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ChangeMenuPanelVisibility
        ///
        /// <summary>
        /// 左側のメニューパネルの表示状態を変更します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ChangeMenuPanelVisibility()
        {
            var visible = !(bool)VisibleMenuItem.Tag;
            var text    = visible ?
                          Properties.Resources.HideMenu :
                          Properties.Resources.VisibleMenu;
            var image   = visible ?
                          Properties.Resources.ArrowLeft :
                          Properties.Resources.ArrowRight;

            VisibleMenuItem.Image = image;
            VisibleMenuItem.Text = text;
            VisibleMenuItem.ToolTipText = text;
            VisibleMenuItem.Tag = visible;
            ContentsPanel.Panel1Collapsed = !visible;
        }

        #endregion

        #region Models
        private PageCollection Pages = new PageCollection(Assembly.GetEntryAssembly());
        private AutoSaver Saver = null;
        #endregion

        #region Views
        private SearchControl SearchControl = new SearchControl();
        #endregion
    }
}
