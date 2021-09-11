using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagBaseFileBrowser.IO;

namespace TagBaseFileBrowser.TestForm
{
    public partial class XmlDB : Form
    {
        private TaggableItemHandler _taggableItemHandler;

        public XmlDB()
        {
            InitializeComponent();

            var x = new XmlObjDatabaseIO();
            x.Write(@"C:\Users\htf\GoogleDrive\01-Projects\hierarchical-tag-file-browser\Test\obj_db.xml", "321",
                new List<string> { "A1", "B2", "C3" });
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            _taggableItemHandler = new TaggableItemHandler(textBoxPath.Text);
            _taggableItemHandler.CreatTagTreeView(treeViewTags);
            _taggableItemHandler.CreateObjsListView(listViewObjs);
        }

        private void listViewObjs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var selected = listViewObjs.SelectedItems[0];
                var path = selected.SubItems[2].Text;
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
                labelObjInfo.Text = objInfo;
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

        private void treeViewTags_DoubleClick(object sender, EventArgs e)
        {
            var selected = treeViewTags.SelectedNode;
            if (selected != null)
            {
                MessageBox.Show(_taggableItemHandler.GetInfo(
                    _taggableItemHandler.FindTagByName(selected.Text)));
            }
        }
    }
}