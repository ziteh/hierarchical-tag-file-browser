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
        public Obj(string name)
        {
            Name = name;
        }

        public string Path { get; set; }
    }

    public class Tag : Taggable
    {
        public Tag()
        {
            Name = "root";
            Type = TagType.General;
            Id = -1;
            ParentTags = new List<Tag>();
            ChildTags = new List<Tag>();
        }

        public Tag(string name, int id, TagType type = TagType.General, List<Tag> parentTags = null)
        {
            Name = name;
            Id = id;
            Type = type;
            ParentTags = parentTags ?? new List<Tag>() { new Tag() };
            ChildTags = new List<Tag>();
        }

        public Color BackgroundColor { get; set; } = Color.White;
        public Color FontColor { get; set; } = Color.Black;
        public TagType Type { get; private set; }

        public bool Equals(Tag tagToMatch)
        {
            return tagToMatch.Id.Equals(this.Id);
        }

        private string GetTagId(Tag tag)
        {
            var parentTag = "";
            if (tag.ParentTags != null)
            {
                if (tag.ParentTags.Count > 0)
                {
                    for (var i = 0; i < tag.ParentTags.Count; i++)
                    {
                        parentTag += tag.ParentTags[i].Name;
                    }
                }
            }

            var keyString = $"{tag.Name}{tag.Type}{parentTag}";
            return keyString.ToMD5();
        }
    }

    public abstract class Taggable
    {
        public List<string> Alias { get; set; }
        public List<Tag> ChildTags { get; set; }
        public int Id { get; protected set; }
        public string Name { get; protected set; }
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