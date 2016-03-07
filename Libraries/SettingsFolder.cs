﻿/* ------------------------------------------------------------------------- */
///
/// SettingsFolder.cs
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
using System.Reflection;
using IoEx = System.IO;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsFolder
    /// 
    /// <summary>
    /// 各種設定を保持するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class SettingsFolder
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsFolder
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsFolder(string path)
        {
            Path = path;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsFolder
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsFolder(Assembly assembly) : this(assembly, DefaultFileName) { }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsFolder
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsFolder(Assembly assembly, string filename)
        {
            var reader = new AssemblyReader(assembly);
            var head = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var tail = $@"{reader.Company}\{reader.Product}\{filename}";
            Path = IoEx.Path.Combine(head, tail);
            UriQuery = new Dictionary<string, string>
            {
                { "utm_source", "cube" },
                { "utm_medium", "note" },
            };
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
        public static string DefaultFileName => "Settings.json";

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
        /// Path
        ///
        /// <summary>
        /// 設定ファイルの保存先を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Path { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// MaxAbstractLength
        ///
        /// <summary>
        /// 概要を表す文字列の最大長を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int MaxAbstractLength => 100;

        /* ----------------------------------------------------------------- */
        ///
        /// UriQuery
        ///
        /// <summary>
        /// URL に付与するクエリーを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public IDictionary<string, string> UriQuery { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// User
        ///
        /// <summary>
        /// アプリケーション終了後も内容を保持する設定を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsValue User { get; private set; } = null;

        /* ----------------------------------------------------------------- */
        ///
        /// Current
        ///
        /// <summary>
        /// アプリケーション実行中のみ内容を保持する設定を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ConditionsValue Current { get; } = new ConditionsValue();

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Load
        ///
        /// <summary>
        /// 設定をロードします。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Load()
        {
            User = !string.IsNullOrEmpty(Path) && IoEx.File.Exists(Path) ?
                   Settings.Load<SettingsValue>(Path, Settings.FileType.Json) :
                   new SettingsValue();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// 設定を保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Save() => Save(Path);
        public void Save(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            var directory = IoEx.Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directory)) return;
            if (!IoEx.Directory.Exists(directory)) IoEx.Directory.CreateDirectory(directory);

            Settings.Save(User, path, FileType);
        }

        #endregion
    }
}
