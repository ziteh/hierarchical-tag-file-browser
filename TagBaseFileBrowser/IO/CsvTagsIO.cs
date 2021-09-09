using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser.IO
{
    public class CsvTagsIo : ITagsIO
    {
        public List<Tag> Read(string file)
        {
            //var tags = new List<Tag>();
            //var csvContent = Csv.Read(file);

            //foreach (var rowOfCsv in csvContent)
            //{
            //    var tag = new Tag(rowOfCsv[1].Split(';'))
            //    {
            //        ThumbnailPath = rowOfCsv[7],
            //        Remark = rowOfCsv[8]
            //    };
            //    tag.AddTag(rowOfCsv[3].Split(';'));

            //    tags.Add(tag);
            //}

            //return tags;
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