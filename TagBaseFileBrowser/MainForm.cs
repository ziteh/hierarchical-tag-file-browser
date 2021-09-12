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
                var ofd = new OpenFileDialog() { Title = "Select a file", Multiselect = false };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var path = ofd.FileName;
                    _taggableItemHandler.AddTag(path, select.Text);
                }
            }
            else
            {
                MessageBox.Show("No tag selected.");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var loadPath = textBoxPath.Text ?? "";
            _taggableItemHandler = new TaggableItemHandler(loadPath);
            _taggableItemHandler.CreatTagTreeView(treeViewTags);
            _taggableItemHandler.CreateObjsListView(listViewObjs);
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