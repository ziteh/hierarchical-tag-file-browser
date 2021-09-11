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
            Process.Start(@"c:\test.png");
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            _taggableItemHandler = new TaggableItemHandler(textBoxPath.Text);
            _taggableItemHandler.CreatTagTreeView(treeViewTags);
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