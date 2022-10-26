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
    public partial class AddTagForm : Form
    {
        private readonly Action<string, Tag> _callbackFunc;

        public AddTagForm(List<Tag> existTags, Action<string, Tag> callbackFunc)
        {
            InitializeComponent();

            _callbackFunc = callbackFunc;
            var tags = existTags ?? new List<Tag>();

            comboBoxParentTag.Items.Clear();
            comboBoxChildTag.Items.Clear();
            foreach (var tag in tags)
            {
                comboBoxParentTag.Items.Add(tag.Name);
                comboBoxChildTag.Items.Add(tag.Name);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var parentTagName = comboBoxParentTag.Text;
            var tagName = comboBoxChildTag.Text;

            if (string.IsNullOrEmpty(parentTagName) ||
                string.IsNullOrEmpty(tagName))
            {
                return;
            }

            var tag = new Tag(tagName);
            _callbackFunc(parentTagName, tag);
            this.Close();
        }
    }
}