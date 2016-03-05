﻿/* ------------------------------------------------------------------------- */
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
using System.Reflection;
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
        public PageCollection() : this(Assembly.GetExecutingAssembly()) { }

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection(Assembly assembly) : base()
        {
            var reader = new AssemblyReader(assembly);
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = $@"{reader.Company}\{reader.Product}\Inbox";

            Directory = IoEx.Path.Combine(appdata, folder);
            Tags = new TagCollection(assembly);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection(string directory)
        {
            Directory = directory;
            Tags = new TagCollection(IoEx.Path.Combine(directory, TagCollection.DefaultFileName));
        }

        #endregion

        #region Properties

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

        /* ----------------------------------------------------------------- */
        ///
        /// Everyone
        ///
        /// <summary>
        /// すべてのノートを表示する事に該当するタグを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Everyone
        {
            get { return _everyone; }
            set
            {
                if (_everyone == value) return;
                _everyone = value;
                if (_everyone != null) _everyone.Count = Count;
            }
        }

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
        public void NewPage(int index = 0) => NewPage(Everyone, index);
        public void NewPage(Tag tag, int index = 0)
        {
            var page = new Page();
            if (tag != null && tag != Everyone) page.Tags.Add(tag.Name);
            Touch(page);
            Insert(index, page);
            if (Everyone != null) Everyone.Count++;
            if (tag != null && tag != Everyone) tag.Count++;
        }

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
                => item.Tags.Contains(tag.Name) ||
                   tag == Everyone
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
            Tags.Load();

            var order = ToPath(filename);
            if (!IoEx.File.Exists(order)) return;

            foreach (var page in Settings.Load<List<Page>>(order, FileType))
            {
                if (!IoEx.File.Exists(ToPath(page))) continue;
                Add(page);
                if (Everyone != null) Everyone.Count++;
                foreach (var tag in page.Tags) Tags.Create(tag).Count++;
            }

            OnLoaded(EventArgs.Empty);
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

                Tags.Decrease(page.Tags);
                if (Everyone != null) Everyone.Count--;
                Clean(page);
            }
            finally { base.RemoveItem(index); }
        }

        #endregion

        #region Other private methods

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
        /// Clean
        ///
        /// <summary>
        /// 削除するための処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Clean(Page page)
        {
            IoEx.File.Delete(ToPath(page));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ToPath
        ///
        /// <summary>
        /// 指定されたオブジェクトに対応するパスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string ToPath(Page item)
        {
            return ToPath(item.FileName);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ToPath
        ///
        /// <summary>
        /// 指定されたファイル名に対応するパスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string ToPath(string filename)
        {
            return IoEx.Path.Combine(Directory, filename);
        }

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

        #region Fields
        private Tag _everyone;
        #endregion
    }
}
