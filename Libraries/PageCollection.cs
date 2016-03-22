/* ------------------------------------------------------------------------- */
///
/// PageCollection.cs
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
using System.Collections.ObjectModel;
using System.Linq;
using IoEx = System.IO;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// PageCollection
    /// 
    /// <summary>
    /// ノート一覧を管理するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class PageCollection : ObservableCollection<Page>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection(string root) : this(root, DefaultInbox) { }

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection(string root, string inbox)
        {
            Directory = IoEx.Path.Combine(root, inbox);
            Tags = new TagCollection(root);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// DefaultInbox
        ///
        /// <summary>
        /// データを格納するフォルダのデフォルト名を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static string DefaultInbox => "Inbox";

        /* ----------------------------------------------------------------- */
        ///
        /// DefaultFileName
        ///
        /// <summary>
        /// 設定ファイルのデフォルト名を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static string DefaultFileName => "Order.json";

        /* ----------------------------------------------------------------- */
        ///
        /// FileType
        ///
        /// <summary>
        /// 設定ファイルのファイル形式を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Settings.FileType FileType => Settings.FileType.Json;

        /* ----------------------------------------------------------------- */
        ///
        /// Directory
        ///
        /// <summary>
        /// 対象とするディレクトリへのパスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Directory { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// Tags
        ///
        /// <summary>
        /// タグ一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection Tags { get; }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Loaded
        ///
        /// <summary>
        /// ページ情報の読み込みが完了した時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Loaded;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページを指定されたインデックスの位置に追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void NewPage(int index = 0) => NewPage(Tags.Everyone, index, null);
        public void NewPage(Tag tag, int index) => NewPage(tag, index, null);
        public void NewPage(Tag tag, int index, Action<Page> initialize)
        {
            var page = new Page();
            Touch(page);

            Tags.Everyone.Increment();
            if (tag != null && tag != Tags.Everyone && tag != Tags.Nothing)
            {
                tag.Increment();
                page.Tags.Add(tag.Name);
            }
            else Tags.Nothing.Increment();

            if (initialize != null) initialize(page);
            Insert(index, page);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Duplicate
        ///
        /// <summary>
        /// 新しいページを指定されたインデックスの位置に追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Duplicate(int index, Page src)
            => NewPage(null, index, (page) =>
        {
            page.Abstract = src.Abstract;
            CopyFile(src, page);
            if (src.Tags.Count > 0)
            {
                foreach (var tag in src.Tags)
                {
                    Tags.Create(tag).Increment();
                    page.Tags.Add(tag);
                }
                Tags.Nothing.Decrement();
            }
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Search
        ///
        /// <summary>
        /// タグに合致する項目一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public IEnumerable<Page> Search(Tag tag)
        {
            return Items.Where(item
                => tag == Tags.Everyone ||
                   tag == Tags.Nothing && item.Tags.Count == 0 ||
                   item.Tags.Contains(tag.Name)
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Load
        ///
        /// <summary>
        /// 定義ファイルを読み込みます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Load() => Load(DefaultFileName);
        public void Load(string filename)
        {
            try
            {
                Tags.Load();

                var order = ToPath(filename);
                if (!IoEx.File.Exists(order)) return;

                foreach (var page in Settings.Load<List<Page>>(order, FileType))
                {
                    if (!IoEx.File.Exists(ToPath(page))) continue;
                    Add(page);
                    Tags.Everyone.Increment();
                    if (page.Tags.Count == 0) Tags.Nothing.Increment();
                    else foreach (var tag in page.Tags) Tags.Create(tag).Increment();
                }
            }
            finally { OnLoaded(EventArgs.Empty); }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// 定義ファイルを保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Save() => Save(DefaultFileName);
        public void Save(string filename)
        {
            Tags.Save();
            CreateDirectory(Directory);
            Settings.Save(Items, ToPath(filename), FileType);
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnLoaded
        ///
        /// <summary>
        /// Loaded イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnLoaded(EventArgs e)
            => Loaded?.Invoke(this, e);

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveItem
        ///
        /// <summary>
        /// 項目を削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void RemoveItem(int index)
        {
            try
            {
                var page = Items[index];
                if (page == null) return;

                Tags.Everyone.Decrement();
                if (page.Tags.Count == 0) Tags.Nothing.Decrement();
                else Tags.Decrement(page.Tags);
                Clean(page);
            }
            finally { base.RemoveItem(index); }
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Touch
        ///
        /// <summary>
        /// 空のファイルを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Touch(Page page)
        {
            var path = ToPath(page);
            CreateDirectory(IoEx.Path.GetDirectoryName(path));
            IoEx.File.Create(path).Close();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CopyFile
        ///
        /// <summary>
        /// ファイルをコピーします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void CopyFile(Page src, Page dest)
        {
            var sp = ToPath(src);
            var dp = ToPath(dest);
            CreateDirectory(IoEx.Path.GetDirectoryName(dp));
            IoEx.File.Copy(sp, dp, true);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Clean
        ///
        /// <summary>
        /// 削除するための処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Clean(Page page) => IoEx.File.Delete(ToPath(page));

        /* ----------------------------------------------------------------- */
        ///
        /// ToPath
        ///
        /// <summary>
        /// パスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string ToPath(Page item) => ToPath(item.FileName);
        private string ToPath(string filename)
            => IoEx.Path.Combine(Directory, filename);

        /* ----------------------------------------------------------------- */
        ///
        /// CreateDirectory
        ///
        /// <summary>
        /// ディレクトリを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void CreateDirectory(string path)
        {
            if (IoEx.Directory.Exists(path)) return;
            IoEx.Directory.CreateDirectory(path);
        }

        #endregion
    }
}
