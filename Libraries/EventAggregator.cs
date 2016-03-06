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
        #region EventArgs

        /* ----------------------------------------------------------------- */
        ///
        /// SelectedPage
        ///
        /// <summary>
        /// 選択ページを表す EventArgs オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ValueEventArgs<int> SelectedPage { get; }
            = ValueEventArgs.Create(-1);

        /* ----------------------------------------------------------------- */
        ///
        /// TopPage
        ///
        /// <summary>
        /// 最初のページを表す EventArgs オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ValueEventArgs<int> TopPage { get; }
            = ValueEventArgs.Create(0);

        #endregion

        #region Events

        #region TextControl and document events

        /* ----------------------------------------------------------------- */
        ///
        /// Refresh
        ///
        /// <summary>
        /// 再描画するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent Refresh { get; } = new RelayEvent();

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

        #endregion

        #region Page events

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページを追加するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> NewPage { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Duplicate
        ///
        /// <summary>
        /// ページを複製するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Duplicate { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Import
        ///
        /// <summary>
        /// ファイルをインポートするイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<KeyValueEventArgs<int, string>> Import { get; }
            = new RelayEvent<KeyValueEventArgs<int, string>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Export
        ///
        /// <summary>
        /// ページをエクスポートするイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Export { get; }
           = new RelayEvent<ValueEventArgs<int>>();

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
        /// Remove
        ///
        /// <summary>
        /// ページを削除するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Remove { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Move
        ///
        /// <summary>
        /// ページを移動するイベントです。
        /// </summary>
        /// 
        /// <remarks>
        /// Move イベントの Value に設定される値はインデックスではなく移動量に
        /// なります。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Move { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        #endregion

        #region Tag events

        /* ----------------------------------------------------------------- */
        ///
        /// NewTag
        ///
        /// <summary>
        /// 新しいタグを追加するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<Tag>> NewTag { get; }
            = new RelayEvent<ValueEventArgs<Tag>>();

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveTag
        ///
        /// <summary>
        /// タグを削除するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<Tag>> RemoveTag { get; }
            = new RelayEvent<ValueEventArgs<Tag>>();

        #endregion

        #region Additional dialog events

        /* ----------------------------------------------------------------- */
        ///
        /// Property
        ///
        /// <summary>
        /// ページのプロパティ画面を表示するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<int>> Property { get; }
            = new RelayEvent<ValueEventArgs<int>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        ///
        /// <summary>
        /// 検索フォームを開くイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<KeyValueEventArgs<int, string>> Search { get; }
            = new RelayEvent<KeyValueEventArgs<int, string>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Google
        ///
        /// <summary>
        /// インターネットで検索するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<string>> Google { get; }
            = new RelayEvent<ValueEventArgs<string>>();

        /* ----------------------------------------------------------------- */
        ///
        /// Web
        ///
        /// <summary>
        /// 既定のブラウザで URL を開くイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public RelayEvent<ValueEventArgs<string>> Web { get; }
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

        #endregion

        #endregion
    }
}
