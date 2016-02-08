/* ------------------------------------------------------------------------- */
///
/// SettingsValue.cs
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
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Drawing;
using IoEx = System.IO;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingsValue
    /// 
    /// <summary>
    /// 各種設定を保持するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    [DataContract]
    public class SettingsValue : ObservableSettingsValue
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingsValue
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public SettingsValue()
        {
            InitializeValues();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Path
        ///
        /// <summary>
        /// 設定ファイルの保存先を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Path { get; set; }

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
        /// FontName
        ///
        /// <summary>
        /// フォント名を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public string FontName
        {
            get { return _fontName; }
            set
            {
                if (_fontName == value) return;
                _fontName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FontName"));
                OnPropertyChanged(new PropertyChangedEventArgs("Font"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FontSize
        ///
        /// <summary>
        /// フォントサイズを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public double FontSize
        {
            get { return _fontSize; }
            set
            {
                if (_fontSize == value) return;
                _fontSize = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FontSize"));
                OnPropertyChanged(new PropertyChangedEventArgs("Font"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FontStyle
        ///
        /// <summary>
        /// フォントスタイルを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set
            {
                if (_fontStyle == value) return;
                _fontStyle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FontStyle"));
                OnPropertyChanged(new PropertyChangedEventArgs("Font"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Font
        ///
        /// <summary>
        /// フォントオブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Font Font
        {
            get
            {
                return new Font(FontName, (float)FontSize, FontStyle, GraphicsUnit.Point);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// BackColor
        ///
        /// <summary>
        /// 背景色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                if (_backColor == value) return;
                _backColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BackColor"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ForeColor
        ///
        /// <summary>
        /// テキスト色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color ForeColor
        {
            get { return _foreColor; }
            set
            {
                if (_foreColor == value) return;
                _foreColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ForeColor"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LineNumberBackColor
        ///
        /// <summary>
        /// 行番号および水平ルーラー部の背景色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color LineNumberBackColor
        {
            get { return _lineNumberBackColor; }
            set
            {
                if (_lineNumberBackColor == value) return;
                _lineNumberBackColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LineNumberBackColor"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LineNumberForeColor
        ///
        /// <summary>
        /// 行番号および水平ルーラー部の前景色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color LineNumberForeColor
        {
            get { return _lineNumberForeColor; }
            set
            {
                if (_lineNumberForeColor == value) return;
                _lineNumberForeColor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LineNumberForeColor"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// AutoSaveTime
        ///
        /// <summary>
        /// 自動保存間隔を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public TimeSpan AutoSaveTime
        {
            get { return _autoSaveTime; }
            set
            {
                if (_autoSaveTime == value) return;
                _autoSaveTime = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AutoSaveTime"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TabWidth
        ///
        /// <summary>
        /// タブ幅を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public int TabWidth
        {
            get { return _tabWidth; }
            set
            {
                if (_tabWidth == value) return;
                _tabWidth = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TabWidth"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TabToSpace
        ///
        /// <summary>
        /// タブの代わりにスペースを挿入するかどうかを示す値を取得または
        /// 設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool TabToSpace
        {
            get { return _tabToSpace; }
            set
            {
                if (_tabToSpace == value) return;
                _tabToSpace = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TabToSpace"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LineNumberVisible
        ///
        /// <summary>
        /// 行番号を表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool LineNumberVisible
        {
            get { return _lineNumberVisible; }
            set
            {
                if (_lineNumberVisible == value) return;
                _lineNumberVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LineNumberVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RulerVisible
        ///
        /// <summary>
        /// 水平方向に目盛りを表示するかどうかを示す値を取得または
        /// 設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool RulerVisible
        {
            get { return _rulerVisible; }
            set
            {
                if (_rulerVisible == value) return;
                _rulerVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("RulerVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SpecialCharsVisible
        ///
        /// <summary>
        /// 特殊文字を表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool SpecialCharsVisible
        {
            get { return _specialCharsVisible; }
            set
            {
                if (_specialCharsVisible == value) return;
                _specialCharsVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SpecialCharsVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// EolVisible
        ///
        /// <summary>
        /// 改行を表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool EolVisible
        {
            get { return _eolVisible; }
            set
            {
                if (_eolVisible == value) return;
                _eolVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EolVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TabVisible
        ///
        /// <summary>
        /// タブを表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool TabVisible
        {
            get { return _tabVisible; }
            set
            {
                if (_tabVisible == value) return;
                _tabVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TabVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SpaceVisible
        ///
        /// <summary>
        /// 半角スペースを表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool SpaceVisible
        {
            get { return _spaceVisible; }
            set
            {
                if (_spaceVisible == value) return;
                _spaceVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SpaceVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FullSpaceVisible
        ///
        /// <summary>
        /// 全角スペースを表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool FullSpaceVisible
        {
            get { return _fullSpaceVisible; }
            set
            {
                if (_fullSpaceVisible == value) return;
                _fullSpaceVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FullSpaceVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CurrentLineVisible
        ///
        /// <summary>
        /// 現在の行を強調表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool CurrentLineVisible
        {
            get { return _currentLineVisible; }
            set
            {
                if (_currentLineVisible == value) return;
                _currentLineVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentLineVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CurrentLineVisible
        ///
        /// <summary>
        /// 修正行を強調表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool ModifiedLineVisible
        {
            get { return _modifiedLineVisible; }
            set
            {
                if (_modifiedLineVisible == value) return;
                _modifiedLineVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModifiedLineVisible"));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveWarning
        ///
        /// <summary>
        /// ページ削除時に警告メッセージを表示するかどうかを示す値を取得
        /// または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool RemoveWarning
        {
            get { return _removeWarning; }
            set
            {
                if (_removeWarning == value) return;
                _removeWarning = value;
                OnPropertyChanged(new PropertyChangedEventArgs("RemoveWarning"));
            }
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// SettingsValue オブジェクトを保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Save()
        {
            Save(Path);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Save
        ///
        /// <summary>
        /// SettingsValue オブジェクトを保存します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Save(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return;

                var directory = IoEx.Path.GetDirectoryName(path);
                if (string.IsNullOrEmpty(directory)) return;
                if (!IoEx.Directory.Exists(directory)) IoEx.Directory.CreateDirectory(directory);

                Settings.Save(this, path, FileType);
            }
            catch (Exception /* err */) { /* ignore errors */ }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// SettingsValue オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static SettingsValue Create(Assembly assembly, string filename)
        {
            var reader  = new AssemblyReader(assembly);
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var leaf    = string.Format(@"{0}\{1}\{2}", reader.Company, reader.Product, filename);
            var path    = IoEx.Path.Combine(appdata, leaf);
            return Create(path);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// SettingsValue オブジェクトを生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static SettingsValue Create(string path)
        {
            var dest = !string.IsNullOrEmpty(path) && IoEx.File.Exists(path) ?
                       Settings.Load<SettingsValue>(path, Settings.FileType.Json) :
                       new SettingsValue();
            dest.Path = path;
            return dest;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// OnDeserializing
        ///
        /// <summary>
        /// デシリアライズ時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            InitializeValues();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeValues
        ///
        /// <summary>
        /// 値を初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeValues()
        {
            // path
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Path = IoEx.Path.Combine(appdata, @"CubeSoft\CubeNote\Settings.json");

            // fonts
            FontName = "メイリオ";
            FontSize = 11.0;
            FontStyle = FontStyle.Regular;

            // colors
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
            LineNumberBackColor = SystemColors.Control;
            LineNumberForeColor = SystemColors.ControlDark;

            // others
            AutoSaveTime = TimeSpan.FromSeconds(30);
            TabWidth = 8;

            TabToSpace = false;
            LineNumberVisible = true;
            RulerVisible = false;
            SpecialCharsVisible = true;
            EolVisible = true;
            TabVisible = true;
            SpaceVisible = false;
            FullSpaceVisible = true;
            CurrentLineVisible = false;
            ModifiedLineVisible = false;
            RemoveWarning = true;
        }

        #endregion

        #region Fields
        public Color _backColor;
        public Color _foreColor;
        public Color _lineNumberBackColor;
        public Color _lineNumberForeColor;
        public TimeSpan _autoSaveTime;
        public string _fontName;
        public double _fontSize;
        public FontStyle _fontStyle;
        public int _tabWidth;
        public bool _tabToSpace;
        public bool _lineNumberVisible;
        public bool _rulerVisible;
        public bool _specialCharsVisible;
        public bool _eolVisible;
        public bool _tabVisible;
        public bool _spaceVisible;
        public bool _fullSpaceVisible;
        public bool _currentLineVisible;
        public bool _modifiedLineVisible;
        public bool _removeWarning;
        #endregion
    }
}
