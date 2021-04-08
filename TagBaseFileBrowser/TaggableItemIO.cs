using System.Collections.Generic;

namespace TagBaseFileBrowser
{
    public interface ITaggableItemIO
    {
        List<TaggableItem> Read(string file);

        void Write(string file, TaggableItem taggableItem);
        void Write(string file, List<TaggableItem> taggableItems);
    }
    
    public class TaggableItemIO : ITaggableItemIO
    {
        public List<TaggableItem> Read(string file)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string file, TaggableItem taggableItem)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string file, List<TaggableItem> taggableItems)
        {
            throw new System.NotImplementedException();
        }
    }
}