using System;
using System.Collections.Generic;

namespace TagBaseFileBrowser
{
    public interface ITaggableItemIO
    {
        List<TaggableObject> Read(string file);

        void Write(string file, TaggableItem taggableItem);

        void Write(string file, List<TaggableItem> taggableItems);
    }

    public class CsvTaggableItemIO : ITaggableItemIO
    {
        public List<TaggableObject> Read(string file)
        {
            var objs = new List<TaggableObject>();
            var csv = Csv.Read(file);

            foreach (var rowOfCsv in csv)
            {
                var taggableObject = new TaggableObject()
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

        public void Write(string file, TaggableItem taggableItem)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string file, List<TaggableItem> taggableItems)
        {
            throw new System.NotImplementedException();
        }
    }
}