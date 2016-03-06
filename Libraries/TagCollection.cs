/* ------------------------------------------------------------------------- */
///
/// TagCollection.cs
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
    /// TagCollection
    /// 
    /// <summary>
    /// タグ一覧を管理するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class TagCollection : ObservableCollection<Tag>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TagCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection(string path) : base()
        {
            Path = path;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TagCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection(Assembly assembly) : this(assembly, DefaultFileName) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagCollection(Assembly assembly, string filename) : base()
        {
            var reader = new AssemblyReader(assembly);
            var head = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var tail = $@"{reader.Company}\{reader.Product}\{filename}";
            Path = IoEx.Path.Combine(head, tail);
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
        public static string DefaultFileName => "Tags.json";

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
        /// タグ一覧を保持しているファイルへのパスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Path { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// SystemTagCount
        ///
        /// <summary>
        /// システムタグの個数を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int SystemTagCount => 2;

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

        /* ----------------------------------------------------------------- */
        ///
        /// Nothing
        ///
        /// <summary>
        /// 一つもタグが設定されていない事を示すタグを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Nothing
        {
            get { return _nothing; }
            set
            {
                if (_nothing == value) return;
                _nothing = value;
                if (_nothing != null) _nothing.Count = Count;
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// Loaded
        ///
        /// <summary>
        /// タグ情報の読み込みが完了した時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler Loaded;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Contains
        ///
        /// <summary>
        /// 指定された名前を持つタグが存在するかどうかを判別します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool Contains(string name) => Items.Any(x => x.Name == name);

        /* ----------------------------------------------------------------- */
        ///
        /// IndexOf
        ///
        /// <summary>
        /// 指定された名前を持つタグのインデックスを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int IndexOf(string name)
        {
            var dest = Get(name);
            return dest != null ? IndexOf(dest) : -1;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Get
        ///
        /// <summary>
        /// 指定された名前を持つタグを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Get(string name)
        {
            return Everyone.Name == name ? Everyone :
                   Nothing.Name  == name ? Nothing  :
                   Items.FirstOrDefault(x => x.Name == name);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// 指定された名前を持つタグを生成します。
        /// </summary>
        /// 
        /// <remarks>
        /// 同名のタグが既に存在する場合は、該当タグを返します。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Create(string name)
        {
            var dest = Get(name);
            if (dest != null) return dest;

            var newtag = new Tag(name);
            Add(newtag);
            return newtag;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Remove
        ///
        /// <summary>
        /// 指定された名前を持つタグを削除します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Remove(string name)
        {
            var dest = Get(name);
            if (dest == null) return;
            Remove(dest);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Increment
        ///
        /// <summary>
        /// 指定されたタグの Count を 1 増加させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Increment(IEnumerable<string> tags)
        {
            foreach (var name in tags) Create(name)?.Increment();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Decrement
        ///
        /// <summary>
        /// 指定されたタグの Count を 1 減少させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Decrement(IEnumerable<string> tags)
        {
            foreach (var name in tags) Get(name)?.Decrement();
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
        public void Load()
        {
            if (!IoEx.File.Exists(Path)) return;
            foreach (var name in Settings.Load<List<string>>(Path, FileType)) Create(name);
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
        public void Save() => Save(Path);
        public void Save(string path)
        {
            CreateDirectory(path);
            Settings.Save(
                Items.Select(x => x.Name).OrderBy(x => x).ToList(),
                path,
                FileType
            );
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

        #region Others

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
            var directory = IoEx.Path.GetDirectoryName(path);
            if (IoEx.Directory.Exists(directory)) return;
            IoEx.Directory.CreateDirectory(directory);
        }

        #endregion

        #region Fields
        private Tag _everyone = new Tag("Everyone");
        private Tag _nothing  = new Tag("Nothing");
        #endregion
    }
}
