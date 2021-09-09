using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser.IO
{
    public class FakeTagsIO : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            return new List<Tag>
            {
                new Tag(new []{"fake name-1"})
                {
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    ParentTags = new List<Tag>
                    {
                        new Tag("fake tag-1"),
                        new Tag("fake tag-2"),
                    }
                },
                new Tag(new []{"fake name-2"})
                {
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    ParentTags = new List<Tag>
                    {
                        new Tag("fake tag-1"),
                        new Tag("fake tag-2"),
                    }
                }
            };
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