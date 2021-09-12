using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser.IO
{
    public class CsvTagDatabaseIo : ITagDatabaseIO
    {
        public List<Tag> Read(string path)
        {
            throw new NotImplementedException();
        }

        public void Write(string path, Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Write(string path, List<Tag> tags)
        {
            throw new NotImplementedException();
        }
    }
}