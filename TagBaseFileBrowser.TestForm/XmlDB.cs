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
            if (radioButtonTagDB.Checked)
            {
                labelContent.Text = ParseForTagDB();
            }
            else
            {
                labelContent.Text = ParseForObjDB();
            }
        }

        private string ParseForObjDB()
        {
            var xmlIO = new XmlObjDatabaseIO();
            var xml = xmlIO.Read(textBoxPath.Text);
            var text = "";
            foreach (var t in xml)
            {
                text += $"{t.Name}\n" +
                        $"{t.Path}\n";
                foreach (var pt in t.ParentTags)
                {
                    text += $"{pt.Name},";
                }
                text += $"\n---\n\n";
            }
            return text;
        }

        private string ParseForTagDB()
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
            return text;
        }
    }
}