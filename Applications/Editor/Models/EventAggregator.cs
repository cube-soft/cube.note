/* ------------------------------------------------------------------------- */
///
/// EventAggregator.cs
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
    /// EventAggregator
    /// 
    /// <summary>
    /// CubeNote で発生するイベントを集約するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class EventAggregator
    {
        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページを追加するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<EventArgs> NewPage { get; }
            = new RelayEvent<EventArgs>();

        /* ----------------------------------------------------------------- */
        ///
        /// Edit
        ///
        /// <summary>
        /// ページのプロパティを編集するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Edit { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        ///
        /// <summary>
        /// 指定されたページを削除するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int[]>> Remove { get; }
            = new RelayEvent<ValueEventArgs<int[]>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        ///
        /// <summary>
        /// 指定されたキーワードで検索するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<string>> Search { get; }
            = new RelayEvent<ValueEventArgs<string>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Settings
        ///
        /// <summary>
        /// 設定フォームを開くイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<EventArgs> Settings { get; }
            = new RelayEvent<EventArgs>();
    }
}
