using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    public class TaggableItem
    {
        private int _id;
        private List<string> _names;
        private string _description;
        private string _path;
        private string _thumbnailPath;
        private string _remark;
        private List<string> _tags;
        private TaggableItemType _type;

        public TaggableItemType Type
        {
            get => _type;
            set => _type = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public List<string> Names
        {
            get => _names;
            set => _names = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Path
        {
            get => _path;
            set => _path = value;
        }

        public string ThumbnailPath
        {
            get => _thumbnailPath;
            set => _thumbnailPath = value;
        }

        public string Remark
        {
            get => _remark;
            set => _remark = value;
        }

        public List<string> Tags
        {
            get => _tags;
            set => _tags = value;
        }

        public void AddTag(string tag)
        {
            _tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            _tags.Remove(tag);
        }
    }

    public class TaggableObject : TaggableItem
    {
    }
}