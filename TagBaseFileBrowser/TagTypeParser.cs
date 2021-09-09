using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    internal static class TagTypeParser
    {
        public static TagType Parse(string typeString)
        {
            TagType type;
            switch (typeString)
            {
                case "folder":
                    type = TagType.Folder;
                    break;

                case "tag-set":
                case "tag_set":
                case "tagSet":
                    type = TagType.TagSet;
                    break;

                case "general":
                default:
                    type = TagType.General;
                    break;
            }
            return type;
        }
    }
}