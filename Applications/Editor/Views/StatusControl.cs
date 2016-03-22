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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cube.Forms;

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

            _positionLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            _positionLabel.Padding = new Padding(20, 0, 20, 0);

            _countLabel.BorderSides = ToolStripStatusLabelBorderSides.Left;
            _countLabel.Padding = new Padding(20, 0, 20, 0);

            _messageLabel.IsLink = true;
            _messageLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            _messageLabel.LinkColor = Color.FromArgb(64, 64, 64);
            _messageLabel.ActiveLinkColor = Color.Navy;
            _messageLabel.Spring = true;
            _messageLabel.TextAlign = ContentAlignment.MiddleLeft;
            _messageLabel.Click += (s, e) => RaiseUriClick();

            Items.AddRange(new ToolStripItem[]
            {
                _messageLabel,
                _positionLabel,
                _countLabel
            });
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// 文字総数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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
        [Browsable(false)]
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

        /* ----------------------------------------------------------------- */
        ///
        /// Message
        ///
        /// <summary>
        /// メッセージを取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public string Message
        {
            get { return _messageLabel.Text; }
            set { _messageLabel.Text = value; }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Uri
        ///
        /// <summary>
        /// メッセージのクリック時に移動する URL を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public Uri Uri { get; set; }

        #endregion

        #region Events

        /* ----------------------------------------------------------------- */
        ///
        /// UriClick
        ///
        /// <summary>
        /// URL がクリックした時に発生するイベントです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public event EventHandler<KeyValueEventArgs<Uri, string>> UriClick;

        #endregion

        #region Virtual methods

        /* ----------------------------------------------------------------- */
        ///
        /// OnUriClick
        ///
        /// <summary>
        /// UriClick を発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected virtual void OnUriClick(KeyValueEventArgs<Uri, string> e)
            => UriClick?.Invoke(this, e);

        #endregion

        #region Non-virtual protected methods

        /* ----------------------------------------------------------------- */
        ///
        /// RaiseUriClick
        ///
        /// <summary>
        /// UriClick イベントを発生させます。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected void RaiseUriClick()
            => OnUriClick(KeyValueEventArgs.Create(Uri, Message));

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

        /* ----------------------------------------------------------------- */
        ///
        /// OnNcHitTest
        ///
        /// <summary>
        /// ヒットテストの発生時に実行されます。
        /// </summary>
        /// 
        /// <remarks>
        /// TODO: ライブラリ側の不都合を回避するための処理。ライブラリ側を要修正。
        /// </remarks>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnNcHitTest(QueryEventArgs<Point, Position> e)
        {
            var text   = _messageLabel.Text;
            var font   = _messageLabel.Font;
            var gs     = CreateGraphics();
            var width  = gs?.MeasureString(text, font).Width ?? _messageLabel.Width;
            var height = _messageLabel.Height;
            var point  = PointToClient(e.Query);

            if (point.X >= 0 && point.X <= width && point.Y >= 0 && point.Y <= height)
            {
                e.Cancel = false;
                e.Result = Position.Client;
            }
            else base.OnNcHitTest(e);
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
