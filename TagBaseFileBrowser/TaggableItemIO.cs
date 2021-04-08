using System.Collections.Generic;

namespace TagBaseFileBrowser
{
    public interface ITaggableItemIO
    {
        List<TaggableItem> Read(string file);
    }
    
    public class TaggableItemIO
    {
        
    }
}