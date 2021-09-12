using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagBaseFileBrowser
{
    public partial class MainForm : Form
    {
        private List<string> _selectedFiles = new List<string>();
        private List<string> _selectedTagNames = new List<string>();
        private TaggableItemHandler _taggableItemHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            var select = treeViewTags.SelectedNode;
            if (select != null)
            {
                _selectedTagNames.Add(select.Text);
                textBoxSelectedTags.Text += select.Text + "\r\n";
            }
        }

        private void buttonClearFile_Click(object sender, EventArgs e)
        {
            _selectedFiles.Clear();
            textBoxSelectedObjs.Text = "";
        }

        private void buttonClearTags_Click(object sender, EventArgs e)
        {
            _selectedTagNames.Clear();
            textBoxSelectedTags.Text = "";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var loadPath = textBoxPath.Text ?? "";
            _taggableItemHandler = new TaggableItemHandler(loadPath);
            _taggableItemHandler.CreatTagTreeView(treeViewTags);
            _taggableItemHandler.CreateObjsListView(listViewObjs);
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Select a file", Multiselect = true };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var f in ofd.FileNames)
                {
                    _selectedFiles.Add(f);
                    textBoxSelectedObjs.Text += f + "\r\n";
                }
            }
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                var sel = listViewObjs.SelectedItems[0];
                _selectedFiles.Add(sel.SubItems[2].Text);
                textBoxSelectedObjs.Text += sel.SubItems[2].Text + "\r\n";
            }
            catch
            { }
        }

        private void buttonWriteAndClear_Click(object sender, EventArgs e)
        {
            buttonWriteObj.PerformClick();
            buttonClearTags.PerformClick();
        }

        private void buttonWriteObj_Click(object sender, EventArgs e)
        {
            if (_selectedTagNames.Count > 0 && _selectedFiles.Count > 0)
            {
                foreach (var f in _selectedFiles)
                {
                    _taggableItemHandler.AddTag(f, _selectedTagNames);
                }
            }
        }

        private void listViewObjs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var path = listViewObjs.SelectedItems[0].SubItems[2].Text;
                Process.Start(_taggableItemHandler.ReplaceParameter(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewObjs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                var selectedObjName = listViewObjs.SelectedItems[0].Text;
                var objInfo = _taggableItemHandler.GetInfo(_taggableItemHandler.FindObjByName(selectedObjName));
                textBoxObjInfo.Text = objInfo;
            }
            catch { }
        }

        private void treeViewTags_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selected = treeViewTags.SelectedNode;
            if (selected != null)
            {
                var selectedTag = _taggableItemHandler.FindTagByName(selected.Text);
                _taggableItemHandler.UpdateObjListView(listViewObjs, selectedTag);
            }
        }
    }
}