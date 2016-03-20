/* ------------------------------------------------------------------------- */
///
/// UpdatePresenter.cs
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
using System.Reflection;
using System.Windows.Forms;
using Cube.Log;
using Cube.Net.Update;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// UpdatePresenter
    /// 
    /// <summary>
    /// アップデート確認のための View と Model を対応付けるクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class UpdatePresenter
        : PresenterBase<NotifyIcon, MessageMonitor>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// UpdatePresenter
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public UpdatePresenter(NotifyIcon view, SettingsFolder settings,
            EventAggregator events, bool activate = false)
            : base(view, new MessageMonitor(), settings, events)
        {
            Settings.User.PropertyChanged += Settings_UserChanged;
            var reader = new AssemblyReader(Assembly.GetExecutingAssembly());
            Model.Execute += Model_Execute;
            Model.Received += Model_Received;
            Model.EndPoint = new Uri(Properties.Resources.UrlUpdate);
            Model.Version = reader.Version;
            Model.VersionDigit = 3;
            Model.OneTimeActivation = activate;
            Update();
        }

        #endregion

        #region Event handlers

        #region Settings

        /* ----------------------------------------------------------------- */
        ///
        /// Settings_UserChanged
        ///
        /// <summary>
        /// Settings.User のプロパティ内容が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Settings_UserChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(Settings.User.ShowUpdate)) return;
            Update();
        }

        #endregion

        #region Model

        /* ----------------------------------------------------------------- */
        ///
        /// Model_Execute
        ///
        /// <summary>
        /// 定期的に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_Execute(object sender, EventArgs e)
        {
            Settings.User.LastUpdate = DateTime.Now;
            this.LogDebug($"Check:{Settings.User.LastUpdate}");
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Model_Received
        ///
        /// <summary>
        /// アップデートメッセージ受信時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Model_Received(object sender, ValueEventArgs<Cube.Net.Update.Message> e)
        {
            this.LogDebug($"Message:{e.Value.Text}");
            this.LogDebug($"Url:{e.Value.Uri}");
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Update
        ///
        /// <summary>
        /// Model の駆動状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Update() => this.LogException(() =>
        {
            if (Settings.User.ShowUpdate)
            {
                Model.InitialDelay = InitialDelay();
                Model.Start();
            }
            else Model.Stop();
        });

        /* ----------------------------------------------------------------- */
        ///
        /// InitialDelay
        ///
        /// <summary>
        /// 初期遅延時間を決定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private TimeSpan InitialDelay()
        {
            this.LogDebug($"LastUpdate:{Settings.User.LastUpdate}");
            var minimum = TimeSpan.FromSeconds(30);
            var diff    = DateTime.Now - Settings.User.LastUpdate;
            var delay   = TimeSpan.FromDays(1) - diff;
            return delay > minimum ? delay : minimum;
        }

        #endregion
    }
}
