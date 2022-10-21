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
        private List<Tag> _tags;
        private Action<string, string> _callbackFunc;

        public AddTagForm(List<Tag> existTags, Action<string, string> callbackFunc)
        {
            InitializeComponent();

            _callbackFunc = callbackFunc;
            _tags = existTags ?? new List<Tag>();

            comboBoxParentTag.Items.Clear();
            comboBoxChildTag.Items.Clear();
            foreach (var tag in _tags)
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

            _callbackFunc(parentTagName, tagName);
            this.Close();
        }
    }
}