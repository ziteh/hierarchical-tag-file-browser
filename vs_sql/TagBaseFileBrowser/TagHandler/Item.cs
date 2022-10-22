using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagHandler
{
    public class Item : Taggable
    {
        public string Path;

        public string PreviewPath;

        public Item(string name, string path, int id = -1) : base(name, id)
        {
            Path = path;
        }
    }
}