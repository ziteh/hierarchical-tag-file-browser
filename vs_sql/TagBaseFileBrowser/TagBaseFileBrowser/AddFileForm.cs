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
    public partial class AddFileForm : Form
    {
        private readonly Action<string, File> _callbackFunc;

        public AddFileForm(List<Tag> existTags, Action<string, File> callbackFunc)
        {
            InitializeComponent();

            _callbackFunc = callbackFunc;

            comboBoxParentTag.Items.Clear();
            foreach (var tag in existTags)
            {
                comboBoxParentTag.Items.Add(tag.Name);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxParentTag.SelectedIndex == -1)
            {
                return;
            }

            var parentTagName = comboBoxParentTag.SelectedItem.ToString();
            var fileName = textBoxFileName.Text;
            var filePath = textBoxPath.Text;

            if (string.IsNullOrEmpty(parentTagName) ||
                string.IsNullOrEmpty(fileName) ||
                string.IsNullOrEmpty(filePath))
            {
                return;
            }

            var file = new File(fileName, filePath);
            _callbackFunc(parentTagName, file);
            this.Close();
        }
    }
}