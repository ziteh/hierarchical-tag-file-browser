using System;
using System.Collections.Generic;

namespace TagBaseFileBrowser.IO
{
    public interface ITagsIO
    {
        List<Tag> Read(string path);

        void Write(string path, Tag tag);

        void Write(string path, List<Tag> tags);
    }

    public class CsvTagsIo : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            var tags = new List<Tag>();
            var csvContent = Csv.Read(file);

            foreach (var rowOfCsv in csvContent)
            {
                var tag = new Tag(rowOfCsv[1].Split(';'))
                {
                    Id = int.Parse(rowOfCsv[0]),
                    Description = rowOfCsv[2],
                    ThumbnailPath = rowOfCsv[7],
                    Remark = rowOfCsv[8]
                };
                tag.AddTag(rowOfCsv[3].Split(';'));

                tags.Add(tag);
            }

            return tags;
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

    public class FakeTagsIO : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            return new List<Tag>
            {
                new Tag(new []{"fake name-1"})
                {
                    Id = -1,
                    Description = "fake description",
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
                    Id = 0,
                    Description = "fake description",
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