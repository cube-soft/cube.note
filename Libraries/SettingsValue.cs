﻿/* ------------------------------------------------------------------------- */
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
                OnPropertyChanged(nameof(FontName));
                OnPropertyChanged(nameof(Font));
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
                OnPropertyChanged(nameof(FontSize));
                OnPropertyChanged(nameof(Font));
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
                OnPropertyChanged(nameof(FontStyle));
                OnPropertyChanged(nameof(Font));
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
        public Font Font => new Font(FontName, (float)FontSize, FontStyle, GraphicsUnit.Point);

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
                OnPropertyChanged(nameof(BackColor));
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
                OnPropertyChanged(nameof(ForeColor));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// HighlightBackColor
        ///
        /// <summary>
        /// 強調表示時の背景色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color HighlightBackColor
        {
            get { return _highlightBackColor; }
            set
            {
                if (_highlightBackColor == value) return;
                _highlightBackColor = value;
                OnPropertyChanged(nameof(HighlightBackColor));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// HighlightForeColor
        ///
        /// <summary>
        /// 強調表示時の前景色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color HighlightForeColor
        {
            get { return _highlightForeColor; }
            set
            {
                if (_highlightForeColor == value) return;
                _highlightForeColor = value;
                OnPropertyChanged(nameof(HighlightForeColor));
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
                OnPropertyChanged(nameof(LineNumberBackColor));
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
                OnPropertyChanged(nameof(LineNumberForeColor));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// SpecialCharsColor
        ///
        /// <summary>
        /// 特殊文字の表示色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color SpecialCharsColor
        {
            get { return _specialCharsColor; }
            set
            {
                if (_specialCharsColor == value) return;
                _specialCharsColor = value;
                OnPropertyChanged(nameof(SpecialCharsColor));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CurrentLineColor
        ///
        /// <summary>
        /// 現在行の表示色を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public Color CurrentLineColor
        {
            get { return _currentLineColor; }
            set
            {
                if (_currentLineColor == value) return;
                _currentLineColor = value;
                OnPropertyChanged(nameof(CurrentLineColor));
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
                OnPropertyChanged(nameof(AutoSaveTime));
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
                OnPropertyChanged(nameof(TabWidth));
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
                OnPropertyChanged(nameof(TabToSpace));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrap
        ///
        /// <summary>
        /// テキストを折り返し表示するかどうかを示す値を取得または
        /// 設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool WordWrap
        {
            get { return _wordWrap; }
            set
            {
                if (_wordWrap == value) return;
                _wordWrap = value;
                OnPropertyChanged(nameof(WordWrap));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrapAsWindow
        ///
        /// <summary>
        /// ウィンドウ幅でテキストを折り返し表示するかどうかを示す値を
        /// 取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool WordWrapAsWindow
        {
            get { return _wordWrapAsWindow; }
            set
            {
                if (_wordWrapAsWindow == value) return;
                _wordWrapAsWindow = value;
                OnPropertyChanged(nameof(WordWrapAsWindow));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrapCount
        ///
        /// <summary>
        /// 折り返し表示する文字数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public int WordWrapCount
        {
            get { return _wordWrapCount; }
            set
            {
                if (_wordWrapCount == value) return;
                _wordWrapCount = value;
                OnPropertyChanged(nameof(WordWrapCount));
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
                OnPropertyChanged(nameof(LineNumberVisible));
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
                OnPropertyChanged(nameof(RulerVisible));
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
                OnPropertyChanged(nameof(SpecialCharsVisible));
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
                OnPropertyChanged(nameof(EolVisible));
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
                OnPropertyChanged(nameof(TabVisible));
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
                OnPropertyChanged(nameof(SpaceVisible));
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
                OnPropertyChanged(nameof(FullSpaceVisible));
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
                OnPropertyChanged(nameof(CurrentLineVisible));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ModifiedLineVisible
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
                OnPropertyChanged(nameof(ModifiedLineVisible));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// BracketVisible
        ///
        /// <summary>
        /// 対応する括弧を強調表示するかどうかを示す値を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public bool BracketVisible
        {
            get { return _bracketVisible; }
            set
            {
                if (_bracketVisible == value) return;
                _bracketVisible = value;
                OnPropertyChanged(nameof(BracketVisible));
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
                OnPropertyChanged(nameof(RemoveWarning));
            }
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Assign
        ///
        /// <summary>
        /// プロパティの内容を代入します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void Assign(SettingsValue src)
        {
            FontName            = src.FontName;
            FontSize            = src.FontSize;
            FontStyle           = src.FontStyle;

            BackColor           = src.BackColor;
            ForeColor           = src.ForeColor;
            HighlightBackColor  = src.HighlightBackColor;
            HighlightForeColor  = src.HighlightForeColor;
            LineNumberBackColor = src.LineNumberBackColor;
            LineNumberForeColor = src.LineNumberForeColor;
            SpecialCharsColor   = src.SpecialCharsColor;
            CurrentLineColor    = src.CurrentLineColor;

            AutoSaveTime        = src.AutoSaveTime;
            TabWidth            = src.TabWidth;
            TabToSpace          = src.TabToSpace;
            WordWrap            = src.WordWrap;
            WordWrapAsWindow    = src.WordWrapAsWindow;
            WordWrapCount       = src.WordWrapCount;
            LineNumberVisible   = src.LineNumberVisible;
            RulerVisible        = src.RulerVisible;
            SpecialCharsVisible = src.SpecialCharsVisible;
            EolVisible          = src.EolVisible;
            TabVisible          = src.TabVisible;
            SpaceVisible        = src.SpaceVisible;
            FullSpaceVisible    = src.FullSpaceVisible;
            CurrentLineVisible  = src.CurrentLineVisible;
            ModifiedLineVisible = src.ModifiedLineVisible;
            BracketVisible      = src.BracketVisible;
            RemoveWarning       = src.RemoveWarning;
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
        private void OnDeserializing(StreamingContext context) => InitializeValues();

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
            FontName            = "Meiryo";
            FontSize            = 11.25;
            FontStyle           = FontStyle.Regular;

            BackColor           = SystemColors.Window;
            ForeColor           = SystemColors.WindowText;
            HighlightBackColor  = SystemColors.Highlight;
            HighlightForeColor  = SystemColors.HighlightText;
            LineNumberBackColor = SystemColors.Control;
            LineNumberForeColor = SystemColors.ControlDark;
            SpecialCharsColor   = SystemColors.ControlDark;
            CurrentLineColor    = SystemColors.ControlDark;

            AutoSaveTime        = TimeSpan.FromSeconds(30);
            TabWidth            = 8;
            WordWrapCount       = 80;

            TabToSpace          = false;
            WordWrap            = false;
            WordWrapAsWindow    = false;
            LineNumberVisible   = true;
            RulerVisible        = false;
            SpecialCharsVisible = true;
            EolVisible          = true;
            TabVisible          = true;
            SpaceVisible        = false;
            FullSpaceVisible    = true;
            CurrentLineVisible  = false;
            ModifiedLineVisible = false;
            BracketVisible      = false;
            RemoveWarning       = true;
        }

        #endregion

        #region Fields
        private Color _backColor;
        private Color _foreColor;
        private Color _highlightBackColor;
        private Color _highlightForeColor;
        private Color _lineNumberBackColor;
        private Color _lineNumberForeColor;
        private Color _specialCharsColor;
        private Color _currentLineColor;
        private TimeSpan _autoSaveTime;
        private string _fontName;
        private double _fontSize;
        private FontStyle _fontStyle;
        private int _tabWidth;
        private int _wordWrapCount;
        private bool _tabToSpace;
        private bool _wordWrap;
        private bool _wordWrapAsWindow;
        private bool _lineNumberVisible;
        private bool _rulerVisible;
        private bool _specialCharsVisible;
        private bool _eolVisible;
        private bool _tabVisible;
        private bool _spaceVisible;
        private bool _fullSpaceVisible;
        private bool _currentLineVisible;
        private bool _modifiedLineVisible;
        private bool _bracketVisible;
        private bool _removeWarning;
        #endregion
    }
}
