using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public XmlDB()
        {
            InitializeComponent();
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            var th = new TaggableItemHandler(textBoxPath.Text);

            var target = "TestTag-1";
            var a1 = th.GetChildTags(th.FindTagByName(target));
            var a2 = th.GetChildObjs(th.FindTagByName(target));
            var a3 = th.GetParentTags(th.FindTagByName(target));
        }
    }
}