/* ------------------------------------------------------------------------- */
///
/// NewsPresenter.cs
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

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// NewsPresenter
    /// 
    /// <summary>
    /// CubeNew に関する Presenter クラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class NewsPresenter
        : PresenterBase<StatusControl, SettingsValue>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// NewsPresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public NewsPresenter(StatusControl view,
            SettingsFolder settings, EventAggregator events)
            : base(view, settings.User, settings, events)
        {
            Model.PropertyChanged += Model_PropertyChanged;
            View.UriClick += View_UriClick;
            ForDebug();
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// View_UriClick
        ///
        /// <summary>
        /// URL のクリック時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void View_UriClick(object sender, KeyValueEventArgs<Uri, string> e)
            => Events.Web.Raise(ValueEventArgs.Create(e.Key.ToString()));

        /* ----------------------------------------------------------------- */
        ///
        /// Model_PropertyChanged
        ///
        /// <summary>
        /// プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Model.ShowNews)) return;
            ForDebug();
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// ForDebug
        ///
        /// <summary>
        /// デバッグ用の処理です。
        /// </summary>
        /// 
        /// <remarks>
        /// 将来的に除去されます。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        private void ForDebug()
        {
            View.Message = Model.ShowNews ?
                           "ニュース：Cube ニュース新着記事のタイトルを表示します。" :
                           string.Empty;
            View.Uri     = Model.ShowNews ?
                           new Uri("http://news.cube-soft.jp/") :
                           null;
        }

        #endregion
    }
}
