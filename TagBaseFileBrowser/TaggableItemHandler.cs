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
        private List<Tag> _tags;

        public TaggableItemHandler(List<Tag> tags)
        {
            _tags = tags;
            //UpdateIdTaggablePairs(tags);
            //AddObjsIntoTags(tags, objs);
        }

        public Tag FindTagById(string id)
        {
            foreach (var t in _tags)
            {
                if (t.Id == id)
                {
                    return t;
                }
            }
            return new Tag();
        }

        public Tag FindTagByName(string name)
        {
            foreach (var t in _tags)
            {
                if (t.Name == name)
                {
                    return t;
                }
            }
            return new Tag();
        }

        public List<Tag> GetChildTags(Tag tag)
        {
            var tags = new List<Tag>();
            var targetTagChildTagIDs = tag.ChildTagIDs;
            foreach (var id in targetTagChildTagIDs)
            {
                tags.Add(FindTagById(id));
            }
            return tags;
        }

        public string GetTagInfo(Tag tag)
        {
            var msg = "";
            msg += $"Name: {tag.Name}\n" +
                   $"ID: {tag.Id}\n" +
                   $"Type: {tag.Type}\n" +
                   $"Child Tags: ";

            var childTags = GetChildTags(tag);
            foreach (var ct in childTags)
            {
                msg += $"{ct.Name},";
            }
            msg.Trim(',');

            return msg;
        }

        public void ShowTagInfo(Tag tag)
        {
            System.Windows.Forms.MessageBox.Show(GetTagInfo(tag));
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