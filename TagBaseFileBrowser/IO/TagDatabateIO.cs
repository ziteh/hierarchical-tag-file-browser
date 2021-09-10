using System;
using System.Collections.Generic;

namespace TagBaseFileBrowser.IO
{
    public interface ITagDatabaseIO
    {
        List<Tag> Read(string path, out Dictionary<string, string> tagNameIdPairs);

        void Write(string path, Tag tag);

        void Write(string path, List<Tag> tags);
    }
}