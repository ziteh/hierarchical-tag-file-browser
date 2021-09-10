using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    public class TaggableItemHandler
    {
        private Dictionary<string, string> _idTaggablePairs = new Dictionary<string, string>();

        public TaggableItemHandler(List<Tag> tags, List<Obj> objs)
        {
            UpdateIdTaggablePairs(tags);
            AddObjsIntoTags(tags, objs);
        }

        private void AddObjsIntoTags(List<Tag> tags, List<Obj> objs)
        {
            foreach (var t in tags)
            {
                foreach (var o in objs)
                {
                    foreach (var ptid in o.ParentTagIDs)
                    {
                        if (_idTaggablePairs.ContainsKey(ptid))
                        {
                            if (_idTaggablePairs[ptid] == t.Name)
                            {
                                t.ChildObjIDs.Add(o.Id);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateIdTaggablePairs(List<Tag> tags)
        {
            foreach (var t in tags)
            {
                _idTaggablePairs.Add(t.Id, t.Name);
            }
        }
    }
}