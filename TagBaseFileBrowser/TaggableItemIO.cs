using System.Collections.Generic;

namespace TagBaseFileBrowser
{
    public interface ITaggableItemIO
    {
        List<TaggableItem> Read(string file);

        void Write(string file, TaggableItem taggableItem);
        void Write(string file, List<TaggableItem> taggableItems);
    }
    
    public class TaggableItemIO
    {
        
    }
}