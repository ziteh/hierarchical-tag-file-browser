using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    internal abstract class TaggableItem
    {
        protected int _id;
        protected List<string> _names;
        protected string _description;
        protected string _path;
        protected string _thumbnailPath;
        protected string _remark;
        protected List<Tag> _tags;

        public void AddTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void RemoveTag(Tag tag)
        {
            _tags.Remove(tag);
        }
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