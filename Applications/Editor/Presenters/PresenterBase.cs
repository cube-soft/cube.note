/* ------------------------------------------------------------------------- */
// 
// Copyright (c) 2010 CubeSoft, Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PresenterBase
    /// 
    /// <summary>
    /// CubeNote で作成する Presenter の基底となるクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PresenterBase<TView, TModel> : Cube.Forms.PresenterBase<TView, TModel>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PresenterBase
        /// 
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PresenterBase(TView view, TModel model,
            SettingsFolder settings, EventAggregator events) : base(view, model)
        {
            Settings = settings;
            Events = events;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Settings
        /// 
        /// <summary>
        /// 設定情報を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsFolder Settings { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// Events
        /// 
        /// <summary>
        /// イベント情報を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventAggregator Events { get; }

        #endregion
    }
}
