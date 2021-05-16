using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    public abstract class Taggable
    {
        public int Id { get; set; }
        public List<string> Names { get; set; }
        public string Description { get; set; }
        public string ThumbnailPath { get; set; }
        public string Remark { get; set; }
        public List<Tag> Tags { get; set; }

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }
        
        public void AddTag(string tagName)
        {
            Tags.Add(new Tag(tagName));
        }
        
        public void AddTag(Tag[] tags)
        {
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }
        
        public void AddTag(string[] tagNames)
        {
            foreach (var tagName in tagNames)
            {
                Tags.Add(new Tag(tagName));
            }
        }
    }

    public class Item : Taggable
    {
        public string Path { get; set; }
    }

    public class Tag : Taggable
    {
        public TagType Type { get; set; }
        public Color FontColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.White;

        public Tag(string name , TagType type = TagType.GeneralTag)
        {
           Names = new List<string>{name};
           Type = type;
        }
        
        public Tag(string[] name , TagType type = TagType.GeneralTag)
        {
           Names = new List<string>(name);
           Type = type;
        }
    }
}