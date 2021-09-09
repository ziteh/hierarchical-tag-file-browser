using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    public class Obj : Taggable
    {
        public string Path { get; set; }
    }

    public class Tag : Taggable
    {
        public Tag()
        {
            Name = "root";
            Type = TagType.General;
            Id = "0";
        }

        public Tag(string name, TagType type = TagType.General, List<Tag> parentTags = null)
        {
            Name = name;
            Type = type;
            ParentTags = parentTags ?? new List<Tag>() { new Tag() };

            Id = ParseId();
        }

        public Color BackgroundColor { get; set; } = Color.White;
        public Color FontColor { get; set; } = Color.Black;
        public TagType Type { get; set; }

        private string ParseId()
        {
            var parentTag = "";
            if (this.ParentTags != null && this.ParentTags.Count > 0)
            {
                for (var i = 0; i < this.ParentTags.Count; i++)
                {
                    parentTag += ParentTags[i].Name;
                }
            }

            var keyString = $"{this.Name}{this.Type}{parentTag}";
            return keyString.ToMD5();
        }
    }

    public abstract class Taggable
    {
        public List<string> Alias { get; set; }
        public string Id { get; protected set; }
        public string Name { get; set; }
        public List<Tag> ParentTags { get; set; }
        public string Remark { get; set; }
        public string ThumbnailPath { get; set; }

        public void AddTag(Tag tag)
        {
            ParentTags.Add(tag);
        }

        public void AddTag(Tag[] tags)
        {
            foreach (var tag in tags)
            {
                ParentTags.Add(tag);
            }
        }
    }
}