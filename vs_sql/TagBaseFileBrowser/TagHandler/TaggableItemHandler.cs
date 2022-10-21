using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagHandler
{
    public class TaggableItemHandler
    {
        private readonly MySqlTaggableItemReader _tagReader;

        public TaggableItemHandler()
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

        public void AddFile(File file, Tag parentTag = null)
        {
            try
            {
                _tagReader.AddFile(file);
            }
            catch
            { }

            if (parentTag == null)
            {
                return;
            }

            file = _tagReader.QueryFile(file.Name);
            _tagReader.AddFileRelation(parentTag, file);
        }

        public void AddTag(Tag tag, string parentTagName)
        {
            try
            {
                _tagReader.AddTag(tag);
            }
            catch
            { }

            var parentTag = _tagReader.QueryTag(parentTagName);
            tag = _tagReader.QueryTag(tag.Name);
            _tagReader.AddTagRelation(parentTag, tag);
        }

        public void AddTag(Tag tag, Tag parentTag = null)
        {
            try
            {
                _tagReader.AddTag(tag);
            }
            catch
            { }

            if (parentTag == null)
            {
                return;
            }

            tag = _tagReader.QueryTag(tag.Name);
            _tagReader.AddTagRelation(parentTag, tag);
        }

        public List<File> GetChildFiles(Tag tag)
        {
            return _tagReader.GetChildFiles(tag.Id);
        }
    }
}