using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    public abstract class TaggableItem
    {
        protected int _id;
        protected List<string> _names;
        protected string _description;
        protected string _path;
        protected string _thumbnailPath;
        protected string _remark;
        protected List<string> _tags;

        public virtual int Id
        {
            get => _id;
            set => _id = value;
        }

        public virtual List<string> Names
        {
            get => _names;
            set => _names = value;
        }

        public virtual string Description
        {
            get => _description;
            set => _description = value;
        }

        public virtual string Path
        {
            get => _path;
            set => _path = value;
        }

        public virtual string ThumbnailPath
        {
            get => _thumbnailPath;
            set => _thumbnailPath = value;
        }

        public virtual string Remark
        {
            get => _remark;
            set => _remark = value;
        }

        public virtual List<string> Tags
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

    public class Tag : TaggableItem
    {
        public TaggableItemType Type;
    }

    public class TaggableObject : TaggableItem
    {
    }

   public class File : TaggableItem
    { }

   public class Folder : TaggableItem
    { }
}