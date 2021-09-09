using System;
using System.Collections.Generic;

namespace TagBaseFileBrowser.IO
{
    public interface ITagsIO
    {
        List<Tag> Read(string path);

        void Write(string path, Tag tag);

        void Write(string path, List<Tag> tags);
    }
}