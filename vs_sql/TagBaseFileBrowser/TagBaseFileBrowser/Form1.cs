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
    public partial class Form1 : Form
    {
        private readonly TaggableItemHandler _taggableItemHandler;

        public Form1()
        {
            InitializeComponent();

            _taggableItemHandler = new TaggableItemHandler();
            _taggableItemHandler.UpdateTreeView(ref treeViewTags);
        }

        private void buttonAddTag_Click(object sender, EventArgs e)
        {
            var allTags = _taggableItemHandler.ReadAllTags();

            Action<string, string> callback = (parentName, newTagName) =>
            {
                if (string.IsNullOrEmpty(parentName) ||
                    string.IsNullOrEmpty(newTagName))
                {
                    return;
                }

                _taggableItemHandler.AddTag(new Tag(newTagName), parentName);
                _taggableItemHandler.UpdateTreeView(ref treeViewTags);
            };

            var subForm = new AddTagForm(allTags, callback);
            subForm.Show();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var node = treeViewTags.SelectedNode;
            if (node == null)
            {
                return;
            }

            var pTag = node.Tag as Tag;
            _taggableItemHandler.AddFile(new File("TestFile", "./"), pTag);
            _taggableItemHandler.UpdateTreeView(ref treeViewTags);
        }

        private void treeViewTags_AfterSelect(object sender, TreeViewEventArgs e)
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