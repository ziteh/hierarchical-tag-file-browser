using System;
using System.Collections.Generic;

namespace TagBaseFileBrowser
{
    public interface ITagsIO
    {
        List<Tag> Read(string path);

        void Write(string path, Tag tag);

        void Write(string path, List<Tag> tags);
    }

    public class FakeTagsIO : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            return new List<Tag>
            {
                new Tag
                {
                    Id = -1,
                    Names = new List<string> { "fake name-1" },
                    Description = "fake description",
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    Tags = new List<Tag>
                    {
                        new Tag{Names = new List<string>{"fake tag-1"}},
                        new Tag{Names = new List<string>{"fake tag-2"}}
                    }
                },
                new Tag
                {
                    Id = 0,
                    Names = new List<string> { "fake name-2" },
                    Description = "fake description",
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    Tags = new List<Tag>
                    {
                        new Tag{Names = new List<string>{"fake tag-1"}},
                        new Tag{Names = new List<string>{"fake tag-2"}}
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

    public class CsvTagsIo : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            var tags = new List<Tag>();
            var csvContent = Csv.Read(file);

            foreach (var rowOfCsv in csvContent)
            {
                var tag = new Tag()
                {
                    Id = int.Parse(rowOfCsv[0]),
                    Names = new List<string>(rowOfCsv[1].Split(';')),
                    Description = rowOfCsv[2],
                    ThumbnailPath = rowOfCsv[7],
                    Remark = rowOfCsv[8]
                };

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
}