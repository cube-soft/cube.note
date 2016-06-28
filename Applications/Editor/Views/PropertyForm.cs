/* ------------------------------------------------------------------------- */
///
/// PropertyForm.cs
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
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PropertyForm
    /// 
    /// <summary>
    /// ページのプロパティを表示するためのクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class PropertyForm : FormBase, IDpiAwarable
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PropertyForm()
        {
            InitializeComponent();
            InitializeEvents();

            Caption = TitleControl;
            ActiveControl = NewTagTextBox;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PropertyForm(Page src, IEnumerable<Tag> tags) : this()
        {
            InitializeLayout(src, tags);
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Tags
        ///
        /// <summary>
        /// ページに関連付けられたタグ一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public IList<string> Tags { get; } = new List<string>();

        #endregion

        #region Initialize methods

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeEvents
        ///
        /// <summary>
        /// 各種イベントを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeEvents()
        {
            ApplyButton.Click += ApplyButton_Click;
            NewTagButton.Click += NewTagButton_Click;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeLayout
        ///
        /// <summary>
        /// レイアウトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeLayout(Page src, IEnumerable<Tag> tags)
        {
            AbstractLabel.Text = src.GetAbstract();
            CreationLabel.Text = src.Creation.ToString(Properties.Resources.CreationFormat);
            LastUpdateLabel.Text = src.LastUpdate.ToString(Properties.Resources.LastUpdateFormat);

            TagsPanel.SuspendLayout();
            foreach (var tag in tags)
            {
                var button = new TagButton(tag);
                button.Name = tag.Name;
                if (src.Tags.Contains(tag.Name)) button.Checked = true;
                TagsPanel.Controls.Add(button);
            }
            TagsPanel.ResumeLayout();

            UpdateLayout(Dpi / BaseDpi);
        }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateLayout
        ///
        /// <summary>
        /// レイアウトを更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public void UpdateLayout(double ratio)
        {
            MinimumSize = new Size((int)(300 * ratio), (int)(270 * ratio));
            Size = new Size((int)(450 * ratio), (int)(330 * ratio));

            LayoutPanel.ColumnStyles[1].Width = (int)(140 * ratio);

            LayoutPanel.RowStyles[0].Height = (int)(30 * ratio);
            LayoutPanel.RowStyles[1].Height = (int)(50 * ratio);
            LayoutPanel.RowStyles[2].Height = (int)(20 * ratio);
            LayoutPanel.RowStyles[3].Height = (int)(28 * ratio);
            LayoutPanel.RowStyles[5].Height = (int)(40 * ratio);
            LayoutPanel.RowStyles[6].Height = (int)(60 * ratio);

            var caption = Caption as IDpiAwarable;
            caption?.UpdateLayout(ratio);

            ButtonsPanel.Padding = new Padding(0, (int)(10 * ratio), 0, 0);
            ApplyButton.Size = new Size((int)(130 * ratio), (int)(35 * ratio));
            ExitButton.Size  = new Size((int)(110 * ratio), (int)(35 * ratio));

            NewTagWrapper.Height = (int)(25 * ratio);
            NewTagButton.Height  = (int)(25 * ratio);

            var margin = (NewTagWrapper.Height - Font.Height) / 2.0;
            NewTagWrapper.Padding = new Padding(4, (int)margin, 4, 0);
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// ApplyButton_Click
        ///
        /// <summary>
        /// OK ボタンが押下される時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Tags.Clear();
            foreach (TagButton button in TagsPanel.Controls)
            {
                if (button.Checked) Tags.Add(button.Text);
            }
            Close();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// NewTagButton_Click
        ///
        /// <summary>
        /// 新しいタグが追加される時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewTagButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NewTagTextBox.Text)) return;

                var tag = NewTagTextBox.Text.Trim();
                if (string.IsNullOrEmpty(tag)) return;

                var contains = TagsPanel.Controls.ContainsKey(tag);
                var button   = contains ?
                               TagsPanel.Controls[tag] as TagButton :
                               new TagButton(tag);
                button.Name = tag;
                button.Checked = true;

                if (!contains) TagsPanel.Controls.Add(button);
            }
            finally { NewTagTextBox.Text = string.Empty; }
        }

        #endregion
    }
}
