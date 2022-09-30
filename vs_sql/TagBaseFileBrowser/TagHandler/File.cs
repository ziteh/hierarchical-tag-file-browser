using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagHandler
{
    public class File : Taggable
    {
        public string Path;

        public string PreviewPath;

        public File(string name, string path, int id = -1) : base(name, id)
        {
            Path = path;
        }
    }
}