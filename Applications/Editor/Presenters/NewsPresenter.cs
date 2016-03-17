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
using System.ComponentModel;
using System.Collections.Generic;
using System.Timers;

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
        : PresenterBase<StatusControl, Cube.Net.News.Monitor>
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
            : base(view, new Cube.Net.News.Monitor(), settings, events)
        {
            Settings.User.PropertyChanged += Settings_UserChanged;
            Settings.Current.PageChanged += Settings_PageChanged;

            Remover.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
            Remover.Elapsed += (s, e) =>
            {
                if (Model.Result.Count <= 1) return;
                Model.Result.RemoveAt(0);
            };

            View.UriClick += View_UriClick;

            Model.ResultChanged += Model_ResultChanged;
            Model.Interval = TimeSpan.FromMinutes(5);
            Model.InitialDelay = TimeSpan.FromSeconds(5);
            Model.Start();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Remover
        ///
        /// <summary>
        /// 記事の更新タイミングを管理するオブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Timer Remover { get; } = new Timer();

        #endregion

        #region Event handlers

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_PropertyChanged
        ///
        /// <summary>
        /// User プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_UserChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName != nameof(Settings.User.ShowNews)) return;

                UpdateNews();
                if (Settings.User.ShowNews) Model.Start();
                else Model.Stop();
            }
            catch (Exception err) { Logger.Error(err); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_CurrentChanged
        ///
        /// <summary>
        /// Current プロパティの内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_PageChanged(object sender, ValueChangedEventArgs<Page> e)
        {
            try { UpdateNews(); }
            catch (Exception err) { Logger.Error(err); }
        }

        #endregion

        #region View

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

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_ResultChanged
        ///
        /// <summary>
        /// 新着記事が更新された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_ResultChanged(object sender, ValueEventArgs<IList<Cube.Net.News.Article>> e)
        {
            try
            {
                Logger.Debug($"Articles:{e.Value.Count}\tFailed:{Model.FailedCount}");

                UpdateNewsIfEmpty();
                Remover.Stop();
                Remover.Start();
            }
            catch (Exception err) { Logger.Error(err); }
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateNews
        ///
        /// <summary>
        /// ニュース記事を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateNews() => SyncWait(() =>
        {
            var visible  = Settings.User.ShowNews && Model.Result.Count > 0;
            View.Message = visible ?
                           string.Format(Properties.Resources.NewsFormat, Model.Result[0].Title) :
                           string.Empty;
            View.Uri     = visible ?
                           new Uri(Model.Result[0].Url) :
                           null;
        });

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateNewsIfEmpty
        ///
        /// <summary>
        /// ニュース記事を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateNewsIfEmpty() => SyncWait(() =>
        {
            if (!Settings.User.ShowNews ||
                !string.IsNullOrEmpty(View.Message)) return;
            UpdateNews();
        });

        #endregion
    }
}
