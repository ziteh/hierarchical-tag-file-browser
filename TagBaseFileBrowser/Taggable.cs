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
    }

    public class Item : Taggable
    {
        public string Path { get; set; }
    }

    public class Tag : Taggable
    {
        public TagType Type { get; set; } = TagType.GeneralTag;
        public Color FontColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.White;
    }
}