using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagHandler
{
    public class TaggableObjectHandler
    {
        private readonly MySqlTaggableItemReader _tagReader;

        public TaggableObjectHandler()
        {
            _tagReader = new MySqlTaggableItemReader("tag_system");
        }

        #region TreeView

        public void UpdateTreeView(ref TreeView treeView)
        {
            treeView.Nodes.Clear();

            var tags = _tagReader.ReadAllTags();
            foreach (var tag in tags)
            {
                if (tag.IsRoot)
                {
                    var node = MakeTreeNode(tag);
                    treeView.Nodes.Add(node);
                }
            }

            treeView.ExpandAll();
        }

        private TreeNode MakeTreeNode(Tag tag)
        {
            var node = new TreeNode
            {
                Text = tag.Name,
                Tag = tag
            };

            var childTags = _tagReader.ReadChildTags(tag.Id);
            if (childTags.Count > 0)
            {
                foreach (var ct in childTags)
                {
                    var subNode = MakeTreeNode(ct);
                    node.Nodes.Add(subNode);
                }
            }

            return node;
        }

        #endregion TreeView

        public List<Tag> ReadAllTags()
        {
            return _tagReader.ReadAllTags();
        }

        public void AddItem(Item item, string parentTagName)
        {
            var parentTag = _tagReader.QueryTag(parentTagName);
            AddFile(item, parentTag);
        }

        public void AddFile(Item item, Tag parentTag = null)
        {
            try
            {
                _tagReader.AddItem(item);
            }
            catch
            {
                return;
            }

            if (parentTag == null)
            {
                return;
            }

            item = _tagReader.QueryItem(item.Name);
            _tagReader.AddItemRelation(parentTag, item);
        }

        public void AddTag(Tag tag, string parentTagName)
        {
            var parentTag = _tagReader.QueryTag(parentTagName);
            AddTag(tag, parentTag);
        }

        public void AddTag(Tag tag, Tag parentTag = null)
        {
            try
            {
                _tagReader.AddTag(tag);
            }
            catch
            {
                return;
            }

            if (parentTag == null)
            {
                return;
            }

            tag = _tagReader.QueryTag(tag.Name);
            _tagReader.AddTagRelation(parentTag, tag);
        }

        public List<Item> GetChildItems(Tag tag)
        {
            return _tagReader.GetChildItems(tag.Id);
        }
    }
}