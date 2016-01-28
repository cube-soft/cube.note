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
    public class ItemCollection : ObservableCollection<Item>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// ItemCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ItemCollection() : this(Assembly.GetExecutingAssembly()) { }

        /* ----------------------------------------------------------------- */
        ///
        /// ItemCollection
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ItemCollection(Assembly assembly)
        {
            var reader = new AssemblyReader(assembly);
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = string.Format(@"{0}\{1}", reader.Company, reader.Product);
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
        public ItemCollection(string directory)
        {
            Directory = directory;
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

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
            var def = IoEx.Path.Combine(Directory, filename);
            if (!IoEx.File.Exists(def)) return;

            var items = Cube.Settings.Load<List<Item>>(def, Cube.Settings.FileType.Json);
            foreach (var item in items)
            {
                var name = item.Creation.ToString("yyyyMMddHHmmssfff");
                var path = IoEx.Path.Combine(Directory, name);
                if (!IoEx.File.Exists(path)) continue;
                Add(item);
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
            if (!IoEx.Directory.Exists(Directory)) IoEx.Directory.CreateDirectory(Directory);
            var dest = IoEx.Path.Combine(Directory, filename);
            Cube.Settings.Save(this.ToList(), dest, Settings.FileType.Json);
        }

        #endregion
    }
}
