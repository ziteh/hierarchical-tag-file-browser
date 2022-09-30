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
                Text = tag.Name
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

        public void AddTag(Tag tag)
        {
            _tagReader.AddTag(tag);
        }
    }
}