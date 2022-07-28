using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagHandler
{
    public abstract class Taggable
    {
        public string Remark = "";

        public string ThumbnailPath = "";

        public List<string> Alias = new List<string>();

        public List<Tag> Tags = new List<Tag>();

        private readonly string _name;

        private readonly int _id;

        public Taggable(string name, int id)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("'name' can't be null or empty.");
            }

            _name = name;
            _id = id;
        }

        public string Name => _name;

        public int Id => _id;

        public bool Equals(Taggable taggable)
        {
            var id = this.Id == taggable.Id;
            var name = this.Name == taggable.Name;
            return id && name;
        }
    }
}