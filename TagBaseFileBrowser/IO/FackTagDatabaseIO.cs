using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser.IO
{
    public class FakeTagDatabaseIO : ITagDatabaseIO
    {
        public List<Tag> Read(string file)
        {
            //return new List<Tag>
            //{
            //    new Tag("fake tag-1")
            //    {
            //        ThumbnailPath = "fake thumbnail path",
            //        Remark = "fake remark",
            //        ParentTags = new List<Tag>
            //        {
            //            new Tag("fake tag-1a"),
            //            new Tag("fake tag-1b"),
            //        },
            //    },
            //    new Tag("fake tag-2")
            //    {
            //        ThumbnailPath = "fake thumbnail path",
            //        Remark = "fake remark",
            //        ParentTags = new List<Tag>
            //        {
            //            new Tag("fake tag-2a"),
            //            new Tag("fake tag-2b"),
            //        }
            //    }
            //};
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