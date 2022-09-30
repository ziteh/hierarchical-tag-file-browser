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
            var node = treeViewTags.SelectedNode;
            if (node == null)
            {
                return;
            }

            var pTag = node.Tag as Tag;
            _taggableItemHandler.AddTag(new Tag("Test"), pTag);

            _taggableItemHandler.UpdateTreeView(ref treeViewTags);
        }
    }
}