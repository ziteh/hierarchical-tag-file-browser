using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagHandler
{
    public abstract class Taggable
    {
        public string Remark;

        public string ThumbnailPath;

        public List<string> Alias = new List<string>();

        public List<Tag> Tags = new List<Tag>();

        public int Id;

        private readonly string _name;

        public Taggable(string name, int id = -1)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "'name' can't be null or empty.");
            }

            _name = name;
            Id = id;
        }

        public string Name => _name;

        public bool IsRoot
        {
            get
            {
                if (Tags == null)
                {
                    return true;
                }

                if (Tags.Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Equals(Taggable taggable)
        {
            var id = this.Id == taggable.Id;
            var name = this.Name == taggable.Name;
            return id && name;
        }
    }
}