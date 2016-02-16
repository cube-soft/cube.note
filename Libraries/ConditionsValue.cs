/* ------------------------------------------------------------------------- */
///
/// ConditionsValue.cs
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
using System.Runtime.CompilerServices;

namespace Cube.Note
{
    /* --------------------------------------------------------------------- */
    ///
    /// ConditionsValue
    /// 
    /// <summary>
    /// アプリケーションの状態を表す値を保持するためのクラスです。
    /// </summary>
    /// 
    /// <remarks>
    /// このクラスが保持する値は、アプリケーション終了時に破棄されます。
    /// アプリケーションの次回起動時にも必要な値に関しては SettingsValue に
    /// 定義して下さい。
    /// </remarks>
    /// 
    /* --------------------------------------------------------------------- */
    public class ConditionsValue : INotifyPropertyChanged
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// ConditionsValue
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ConditionsValue() { }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Page
        ///
        /// <summary>
        /// アクティブな Page オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Page Page
        {
            get { return _page; }
            set
            {
                if (_page == value) return;

                var before = _page;
                _page = value;
                OnPageChanged(new ValueChangedEventArgs<Page>(before, value));
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Tag
        ///
        /// <summary>
        /// アクティブな Tag オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Tag Tag
        {
            get { return _tag; }
            set
            {
                if (_tag == value) return;

                var before = _tag;
                _tag = value;
                OnTagChanged(new ValueChangedEventArgs<Tag>(before, value));
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

        /* ----------------------------------------------------------------- */
        ///
        /// PageChanged
        ///
        /// <summary>
        /// ページが変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<ValueChangedEventArgs<Page>> PageChanged;

        /* ----------------------------------------------------------------- */
        ///
        /// TagChanged
        ///
        /// <summary>
        /// タグが変更された時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<ValueChangedEventArgs<Tag>> TagChanged;

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

        /* ----------------------------------------------------------------- */
        ///
        /// OnPageChanged
        ///
        /// <summary>
        /// TagChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnPageChanged(ValueChangedEventArgs<Page> e)
            => PageChanged?.Invoke(this, e);

        /* ----------------------------------------------------------------- */
        ///
        /// OnTagChanged
        ///
        /// <summary>
        /// TagChanged イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnTagChanged(ValueChangedEventArgs<Tag> e)
            => TagChanged?.Invoke(this, e);

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

        #region Fields
        private Page _page;
        private Tag _tag;
        #endregion
    }
}
