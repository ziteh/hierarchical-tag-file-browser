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
        public Obj(string name, int id)
        {
            Name = name;
            Id = $"o{id}";
        }

        public string Path { get; set; }
        public string PreviewPath { get; set; }
    }

    public class Tag : Taggable
    {
        public Tag()
        {
            Name = "root";
            Type = TagType.General;
            Id = "tr";
            ParentTagNames = new List<string>();
            ChildTagNames = new List<string>();
            ChildObjNames = new List<string>();
        }

        public Tag(string name, int id, TagType type = TagType.General, List<string> parentTags = null)
        {
            Name = name;
            Id = $"t{id}";
            Type = type;
            ParentTagNames = parentTags ?? new List<string>() { new Tag().Id };
            ChildTagNames = new List<string>();
            ChildObjNames = new List<string>();
        }

        public Color BackgroundColor { get; set; } = Color.White;
        public List<string> ChildObjNames { get; set; }
        public List<string> ChildTagNames { get; set; }
        public Color FontColor { get; set; } = Color.Black;
        public TagType Type { get; private set; }

        public bool Equals(Tag tagToMatch)
        {
            return tagToMatch.Id.Equals(this.Id);
        }
    }

    public abstract class Taggable
    {
        public List<string> Alias { get; set; }
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public List<string> ParentTagNames { get; set; }
        public string Remark { get; set; }
        public string ThumbnailPath { get; set; }
    }
}