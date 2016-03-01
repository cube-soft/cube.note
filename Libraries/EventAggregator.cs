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
namespace Cube.Note
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
        public RelayEvent NewPage { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// Export
        ///
        /// <summary>
        /// ページをエクスポートするイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Export { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// Property
        ///
        /// <summary>
        /// ページのプロパティ画面を表示するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Property { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// Edit
        ///
        /// <summary>
        /// ページ情報を編集した時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<Page>> Edit { get; }
            = new RelayEvent<ValueEventArgs<Page>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Move
        ///
        /// <summary>
        /// ページを移動するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Move { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        ///
        /// <summary>
        /// 選択ページを削除するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Remove { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// Undo
        ///
        /// <summary>
        /// 元に戻すイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Undo { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// Redo
        ///
        /// <summary>
        /// やり直しを実行するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Redo { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// SearchMode
        ///
        /// <summary>
        /// 検索用の画面を表示します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> SearchMode { get; }
            = new RelayEvent<ValueEventArgs<int>>();

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
        public RelayEvent Settings { get; } = new RelayEvent();

        /* ----------------------------------------------------------------- */
        ///
        /// TagSettings
        ///
        /// <summary>
        /// タグ用の設定フォームを開くイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent TagSettings { get; } = new RelayEvent();
    }
}
