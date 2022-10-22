using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            Action<string, Item> callback = (parentName, childItem) =>
            {
                if (string.IsNullOrEmpty(parentName))
                {
                    return;
                }

                _taggableItemHandler.AddItem(childItem, parentName);
                UpdateListView();
            };

            var subForm = new AddItemForm(allTags, callback);
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
            var childItems = _taggableItemHandler.GetChildItems(pTag);
            foreach (var childItem in childItems)
            {
                var listItem = new System.Windows.Forms.ListViewItem();
                listItem.SubItems[0].Text = childItem.Name;
                listItem.SubItems.Add(childItem.Path);
                listItem.Tag = childItem;

                listViewChildren.Items.Add(listItem);
            }

            if (listViewChildren.Items.Count > 0)
            {
                listViewChildren.Items[0].Selected = true;
            }
        }

        private void listViewChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var index = listViewChildren.SelectedIndices[0];
                var selectedItem = listViewChildren.Items[index].Tag as Item;
                var path = _taggableItemHandler.RootPath + selectedItem.Path;
                var file = File.OpenRead(path);
                pictureBoxPreview.Image = Image.FromStream(file);

                textBoxItemInfo.Text = "";
                foreach (var tag in selectedItem.Tags)
                {
                    textBoxItemInfo.Text += tag.Name;
                    textBoxItemInfo.Text += ", ";
                }
                textBoxItemInfo.Text = textBoxItemInfo.Text.TrimEnd().TrimEnd(',');
            }
            catch
            {
                textBoxItemInfo.Text = "";
                pictureBoxPreview.Image = null;
            }
        }
    }
}