using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagHandler
{
    public class Tag : Taggable
    {
        public Tag(string name, int id = -1) : base(name, id)
        {
        }

        public bool Equals(Tag tag)
        {
            var id = this.Id == tag.Id;
            var name = this.Name == tag.Name;
            return id && name;
        }
    }
}