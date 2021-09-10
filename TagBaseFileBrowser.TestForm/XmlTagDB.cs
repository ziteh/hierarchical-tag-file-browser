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
    public partial class XmlTagDB : Form
    {
        public XmlTagDB()
        {
            InitializeComponent();
        }

        private void buttonReadXml_Click(object sender, EventArgs e)
        {
            var xmlIO = new XmlTagDatabaseIO();
            var xml = xmlIO.Read(textBoxPath.Text);
            var text = "";
            foreach (var t in xml)
            {
                text += $"{t.Name}\n" +
                        $"{t.Id}\n" +
                        $"{t.Type}\n";
                foreach (var p in t.ParentTags)
                {
                    text += $"{p.Name},";
                }
                text += $"\n";
                foreach (var c in t.ChildTags)
                {
                    text += $"{c.Name},";
                }
                text += $"\n---\n\n";
            }
            labelContent.Text = text;
        }
    }
}