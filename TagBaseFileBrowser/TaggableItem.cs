using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    internal abstract class TaggableItem
    {
       public int Id { get; set; }
       public string[] Names { get; set; }
       public string Description { get; set; }
       public string Path { get; set; }
       public string ThumbnailPath { get; set; }
       public string Remark { get; set; }
       public Tag[] Tags { get; set; }
    }

    class Tag : TaggableItem
    {
        
    }

    class File : TaggableItem
    {
        
    }

    class Folder : TaggableItem
    {
        
    }
}