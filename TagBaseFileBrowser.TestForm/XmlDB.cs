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
            var xmlTagIO = new XmlTagDatabaseIO();
            var tagDB = xmlTagIO.Read(textBoxPath.Text + @"\tag_db.xml", out var tagNameIdPaids);

            var xmlObjIO = new XmlObjDatabaseIO(tagNameIdPaids);
            var objDB = xmlObjIO.Read(textBoxPath.Text + @"\obj_db.xml");

            var th = new TaggableItemHandler(tagDB, objDB);
        }
    }
}