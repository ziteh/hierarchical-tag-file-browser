using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagHandler;

namespace TagBaseFileBrowser
{
    public partial class MainForm : Form
    {
        private readonly TaggableObjectHandler _taggableItemHandler;

        public MainForm()
        {
            InitializeComponent();

            _taggableItemHandler = new TaggableObjectHandler();
            _taggableItemHandler.UpdateTreeView(ref treeViewTags);
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            var allTags = _taggableItemHandler.ReadAllTags();

            Action<string, Tag> callback = (parentName, childTag) =>
            {
                if (string.IsNullOrEmpty(parentName))
                {
                    return;
                }

                _taggableItemHandler.AddTag(childTag, parentName);
                _taggableItemHandler.UpdateTreeView(ref treeViewTags);
            };

            var subForm = new AddTagForm(allTags, callback);
            subForm.Show();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var allTags = _taggableItemHandler.ReadAllTags();

            Action<string, File> callback = (parentName, childFile) =>
            {
                if (string.IsNullOrEmpty(parentName))
                {
                    return;
                }

                _taggableItemHandler.AddFile(childFile, parentName);
                UpdateListView();
            };

            var subForm = new AddFileForm(allTags, callback);
            subForm.Show();
        }

        private void treeViewTags_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateListView();
        }

        private void UpdateListView()
        {
            var node = treeViewTags.SelectedNode;
            if (node == null)
            {
                return;
            }

            listViewChildren.Items.Clear();

            var pTag = node.Tag as Tag;
            var childFiles = _taggableItemHandler.GetChildFiles(pTag);
            foreach (var file in childFiles)
            {
                var item = new System.Windows.Forms.ListViewItem();
                item.SubItems[0].Text = file.Name;
                item.SubItems.Add(file.Path);

                listViewChildren.Items.Add(item);
            }

            if (listViewChildren.Items.Count > 0)
            {
                listViewChildren.Items[0].Selected = true;
            }
        }
    }
}