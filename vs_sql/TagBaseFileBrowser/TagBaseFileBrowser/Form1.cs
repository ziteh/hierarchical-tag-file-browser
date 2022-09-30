﻿using System;
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
        public Form1()
        {
            InitializeComponent();
            var tr = new TaggableItemHandler();
            tr.UpdateTreeView(ref treeViewTags);

            tr.AddTag(new Tag("Test_1"));
        }
    }
}