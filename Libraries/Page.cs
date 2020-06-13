/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// Page
    ///
    /// <summary>
    /// ページを表すクラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [DataContract]
    public class Page : INotifyPropertyChanged
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// Page
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Page()
        {
            InitializeValues();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// FileName
        ///
        /// <summary>
        /// ファイル名を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public string FileName
        {
            get { return _filename; }
            set
            {
                if (_filename == value) return;
                _filename = value;
                RaisePropertyChanged(nameof(FileName));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Abstract
        ///
        /// <summary>
        /// 概要を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public string Abstract
        {
            get { return _abstract; }
            set
            {
                if (_abstract == value) return;
                _abstract = value;
                RaisePropertyChanged(nameof(Abstract));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Creation
        ///
        /// <summary>
        /// 生成日時を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public DateTime Creation
        {
            get { return _creation; }
            set
            {
                if (_creation == value) return;
                _creation = value;
                RaisePropertyChanged(nameof(Creation));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LastUpdate
        ///
        /// <summary>
        /// 生成日時を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public DateTime LastUpdate
        {
            get { return _update; }
            set
            {
                if (_update == value) return;
                _update = value;
                RaisePropertyChanged(nameof(LastUpdate));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Tags
        ///
        /// <summary>
        /// タグ一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DataMember]
        public ObservableCollection<string> Tags { get; private set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Document
        ///
        /// <summary>
        /// Document オブジェクトを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public object Document
        {
            get { return _document; }
            set
            {
                if (_document == value) return;
                _document = value;
                RaisePropertyChanged(nameof(Document));
            }
        }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyChanged
        ///
        /// <summary>
        /// プロパティの内容が変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnPropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            => PropertyChanged?.Invoke(this, e);

        #endregion

        #region Non-virtual protected methods

        /* ----------------------------------------------------------------- */
        ///
        /// RaisePropertyChanged
        ///
        /// <summary>
        /// PropertyChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
            => OnPropertyChanged(new PropertyChangedEventArgs(name));

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
            FileName   = Guid.NewGuid().ToString("N");
            Abstract   = string.Empty;
            Creation   = DateTime.Now;
            LastUpdate = DateTime.Now;
            Tags       = new ObservableCollection<string>();
            Document   = null;
        }

        #endregion

        #region Fields
        private string _filename;
        private string _abstract;
        private DateTime _creation;
        private DateTime _update;
        private object _document;
        #endregion
    }
}
