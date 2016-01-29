/* ------------------------------------------------------------------------- */
///
/// ItemCollection.cs
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
    /// ItemCollection
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
        public PageCollection(Assembly assembly)
        {
            var reader = new AssemblyReader(assembly);
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = string.Format(@"{0}\{1}\Inbox", reader.Company, reader.Product);
            Directory = IoEx.Path.Combine(appdata, folder);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ItemCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PageCollection(string directory)
        {
            Directory = directory;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// FileType
        ///
        /// <summary>
        /// 設定ファイルのファイル形式を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Settings.FileType FileType
        {
            get { return Settings.FileType.Json; }
        }

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
        /// Target
        ///
        /// <summary>
        /// 対象とする Page オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Page Target
        {
            get { return _target; }
            set
            {
                if (_target == value) return;

                var before = _target;
                _target = value;
                OnTargetChanged(new PageChangedEventArgs(before, value));
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// TargetChanged
        ///
        /// <summary>
        /// 対象となる Page オブジェクトが変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public EventHandler<PageChangedEventArgs> TargetChanged;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// NewPage
        ///
        /// <summary>
        /// 新しいページを先頭に追加します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void NewPage()
        {
            var page = new Page();
            Touch(page);
            Insert(0, page);
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
        public void Load(string filename)
        {
            var def = ToPath(filename);
            if (!IoEx.File.Exists(def)) return;

            var pages = Settings.Load<List<Page>>(def, FileType);
            foreach (var page in pages)
            {
                if (!IoEx.File.Exists(ToPath(page))) continue;
                Add(page);
            }
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
        public void Save(string filename)
        {
            CreateDirectory(Directory);
            Settings.Save(this.ToList(), ToPath(filename), FileType);
        }

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnTargetChanged
        ///
        /// <summary>
        /// 対象となる Page オブジェクトが変更された時に実行される
        /// ハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnTargetChanged(PageChangedEventArgs e)
        {
            if (TargetChanged != null) TargetChanged(this, e);
        }

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
            Clean(Items[index]);
            base.RemoveItem(index);
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
        private Page _target = null;
        #endregion
    }
}
