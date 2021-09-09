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
        public Tag(string name, TagType type = TagType.General)
        {
            Name = name;
            Type = type;
        }

        public Tag(string[] name, TagType type = TagType.General)
        {
            Name = name[0];
            Type = type;
            if (name.Length > 1)
            {
                for (var i = 1; i < name.Length; i++)
                {
                    Alias.Add(name[i]);
                }
            }
        }

        public Color BackgroundColor { get; set; } = Color.White;
        public Color FontColor { get; set; } = Color.Black;
        public TagType Type { get; set; }
    }

    public abstract class Taggable
    {
        public List<string> Alias { get; set; }
        public int Id { get; }
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