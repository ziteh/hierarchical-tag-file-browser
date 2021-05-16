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

    public class FakeTagsOjectIo : ITagsIO
    {
        public List<Item> Read(string file)
        {
            return new List<Item>
            {
                new Item()
                {
                    Id = 1,
                    Names = new List<string> { "fake name-1" },
                    Description = "fake description",
                    Path = "fake path",
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    Tags = new List<string> { "fake tag-1", "fake tag-2" }
                },
                new Item()
                {
                    Id = 2,
                    Names = new List<string> { "fake name-2" },
                    Description = "fake description",
                    Path = "fake path",
                    ThumbnailPath = "fake thumbnail path",
                    Remark = "fake remark",
                    Tags = new List<string> { "fake tag-1", "fake tag-2" }
                }
            };
        }

        public void Write(string path, Taggable taggable)
        {
            throw new NotImplementedException();
        }

        public void Write(string path, List<Taggable> taggableItems)
        {
            throw new NotImplementedException();
        }
    }

    public class CsvTagsIo : ITagsIO
    {
        public List<Item> Read(string file)
        {
            var objs = new List<Item>();
            var csv = Csv.Read(file);

            foreach (var rowOfCsv in csv)
            {
                var taggableObject = new Item()
                {
                    Id = int.Parse(rowOfCsv[0]),
                    Names = new List<string> { rowOfCsv[1] },
                    Description = rowOfCsv[2],
                    Path = rowOfCsv[4],
                    Remark = rowOfCsv[5]
                };

                var tags = rowOfCsv[3].Split(';');
                foreach (var tag in tags)
                {
                    taggableObject.Tags.Add(tag);
                }

                objs.Add(taggableObject);
            }

            return objs;
        }

        public void Write(string path, Taggable taggable)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string path, List<Taggable> taggableItems)
        {
            throw new System.NotImplementedException();
        }
    }
}