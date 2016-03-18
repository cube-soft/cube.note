/* ------------------------------------------------------------------------- */
///
/// TagForm.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cube.Note.App.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// TagForm
    /// 
    /// <summary>
    /// タグの設定画面を表示するクラスです。
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public partial class TagForm : FormBase
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// TagForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagForm() : this(null) { }

        /* ----------------------------------------------------------------- */
        ///
        /// TagForm
        ///
        /// <summary>
        /// オブジェクトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public TagForm(IEnumerable<Tag> tags)
        {
            InitializeComponent();
            InitializeLayout();
            InitializeTags(tags);

            Caption = TitleControl;
            Count = 0;
            ActiveControl = NewTagTextBox;

            NewTagButton.Click += NewTagButton_Click;
            RemoveTagButton.Click += RemoveTagButton_Click;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// NewTags
        ///
        /// <summary>
        /// 新たに作成されたタグの一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public IList<Tag> NewTags { get; } = new List<Tag>();

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveTags
        ///
        /// <summary>
        /// 削除されたタグの一覧を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        public IList<Tag> RemoveTags { get; } = new List<Tag>();

        /* ----------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// 選択されている個数を取得または設定します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Browsable(false)]
        private int Count
        {
            get { return _count; }
            set
            {
                _count = Math.Max(value, 0);
                RemoveTagButton.Enabled = value > 0;
            }
        }

        #endregion

        #region Event handlers

        /* ----------------------------------------------------------------- */
        ///
        /// NewTagButton_Click
        ///
        /// <summary>
        /// タグの追加ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void NewTagButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewTagTextBox.Text)) return;

            var name = NewTagTextBox.Text;
            NewTagTextBox.Text = string.Empty;

            var found = TagsPanel.Controls.Cast<CheckBox>()
                .Any(x => (x.Tag as Tag)?.Name == name);
            if (found) return;

            TagsPanel.Controls.Add(Create(new Tag(name)));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RemoveTagButton_Click
        ///
        /// <summary>
        /// タグの削除ボタンが押下された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void RemoveTagButton_Click(object sender, EventArgs e)
        {
            var controls = TagsPanel.Controls.Cast<CheckBox>().Where(x => x.Checked).ToArray();
            foreach (var control in controls)
            {
                control.Checked = false;
                control.CheckedChanged -= CheckBox_CheckedChanged;
                TagsPanel.Controls.Remove(control);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TagsPanel_ControlAdded
        ///
        /// <summary>
        /// コントロールが追加された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void TagsPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            var tag = e.Control.Tag as Tag;
            if (tag == null) return;

            var result = RemoveTags.FirstOrDefault(x => x.Name == tag.Name);
            if (result != null) RemoveTags.Remove(result);
            else NewTags.Add(tag);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TagsPanel_ControlRemoved
        ///
        /// <summary>
        /// コントロールが削除された時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void TagsPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            var tag = e.Control.Tag as Tag;
            if (tag == null) return;

            var result = NewTags.FirstOrDefault(x => x.Name == tag.Name);
            if (result != null) NewTags.Remove(result);
            else RemoveTags.Add(tag);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CheckBox_CheckedChanged
        ///
        /// <summary>
        /// チェックボックスのチェック状態が変化した時に実行されるハンドラです。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var control = sender as CheckBox;
            if (control == null) return;
            if (control.Checked) Count++;
            else Count--;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeLayout
        ///
        /// <summary>
        /// レイアウトを初期化します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeLayout()
        {
            var margin = Math.Max((NewTagWrapper.Height - NewTagTextBox.Height) / 2 - 1, 0);
            NewTagWrapper.Padding = new Padding(4, margin, 0, 0);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// InitializeTags
        ///
        /// <summary>
        /// 各種タグの状態を更新します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void InitializeTags(IEnumerable<Tag> tags)
        {
            try {
                TagsPanel.SuspendLayout();
                if (tags == null) return;

                TagsPanel.Controls.Clear();
                foreach (var tag in tags) TagsPanel.Controls.Add(Create(tag));
            }
            finally
            {
                TagsPanel.ControlAdded   -= TagsPanel_ControlAdded;
                TagsPanel.ControlAdded   += TagsPanel_ControlAdded;
                TagsPanel.ControlRemoved -= TagsPanel_ControlRemoved;
                TagsPanel.ControlRemoved += TagsPanel_ControlRemoved;

                TagsPanel.ResumeLayout();
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// 新しい CheckBox オブジェクトを取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private CheckBox Create(Tag tag)
        {
            var dest = new CheckBox();
            dest.AutoSize = true;
            dest.Text = tag.ToString();
            dest.Tag = tag;
            dest.Margin = new Padding(3, 3, 6, 6);
            dest.CheckedChanged -= CheckBox_CheckedChanged;
            dest.CheckedChanged += CheckBox_CheckedChanged;
            return dest;
        }

        #endregion

        #region Fields
        private int _count = 0;
        #endregion
    }
}
