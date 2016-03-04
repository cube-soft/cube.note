/* ------------------------------------------------------------------------- */
///
/// StatusControl.cs
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
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// StatusControl
    /// 
    /// <summary>
    /// 現在のステータスを表示するためのコントロールクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class StatusControl : Cube.Forms.StatusStrip
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// StatusControl
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public StatusControl() : base()
        {
            GripMargin = new Padding(0);
            Items.AddRange(new ToolStripItem[] {
                _messageLabel,
                _positionLabel,
                _countLabel
            });

            _messageLabel.Spring = true;

            _positionLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            _positionLabel.Padding = new Padding(20, 0, 20, 0);

            _countLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            _countLabel.Padding = new Padding(20, 0, 20, 0);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Message
        ///
        /// <summary>
        /// メッセージを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Message
        {
            get { return _messageLabel.Text; }
            set { _messageLabel.Text = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// 文字総数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Count
        {
            get { return _count; }
            set
            {
                if (_count == value) return;
                _count = value;
                UpdateCountLabel();
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LineCount
        ///
        /// <summary>
        /// 総行数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int LineCount
        {
            get { return _lineCount; }
            set
            {
                if (_lineCount == value) return;
                _lineCount = value;
                UpdateCountLabel();
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LineNumber
        ///
        /// <summary>
        /// カーソルの存在する行番号を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int LineNumber
        {
            get { return _lineNumber; }
            set
            {
                if (_lineNumber == value) return;
                _lineNumber = value;
                UpdatePositionLabel();
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ColumnNumber
        ///
        /// <summary>
        /// カーソルの存在する桁数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int ColumnNumber
        {
            get { return _columnNumber; }
            set
            {
                if (_columnNumber == value) return;
                _columnNumber = value;
                UpdatePositionLabel();
            }
        }

        #endregion

        #region Override methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnParentChanged
        ///
        /// <summary>
        /// 親コントロールが変化した時に実行されます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            var form = FindForm();
            if (form == null) return;

            Font = form.Font;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateCountLabel
        ///
        /// <summary>
        /// 文字総数の表示を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdateCountLabel()
        {
            _countLabel.Text = string.Format(
                Properties.Resources.CountFormat,
                Count,
                LineCount
            );
        }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdatePositionLabel
        ///
        /// <summary>
        /// カーソル位置の表示を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void UpdatePositionLabel()
        {
            _positionLabel.Text = string.Format(
                Properties.Resources.PositionFormat,
                LineNumber,
                ColumnNumber
            );
        }

        #endregion

        #region Fields
        private int _count        = 0;
        private int _lineCount    = 0;
        private int _lineNumber   = 0;
        private int _columnNumber = 0;
        private ToolStripStatusLabel _messageLabel  = new ToolStripStatusLabel();
        private ToolStripStatusLabel _countLabel    = new ToolStripStatusLabel();
        private ToolStripStatusLabel _positionLabel = new ToolStripStatusLabel();
        #endregion
    }
}
