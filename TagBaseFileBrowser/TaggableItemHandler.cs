using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagBaseFileBrowser.IO;
using System.Windows.Forms;

namespace TagBaseFileBrowser
{
    public class TaggableItemHandler
    {
        private List<Obj> _objs;
        private List<Tag> _tags;

        public TaggableItemHandler(string path)
        {
            var xmlTagIO = new XmlTagDatabaseIO();
            _tags = xmlTagIO.Read(path + @"\tag_db.xml", out var tagNameIdPaids);

            var xmlObjIO = new XmlObjDatabaseIO(tagNameIdPaids);
            _objs = xmlObjIO.Read(path + @"\obj_db.xml");

            AddObjsIntoTags(_tags, _objs);
        }

        public TaggableItemHandler(List<Tag> tags, List<Obj> objs)
        {
            _tags = tags;
            _objs = objs;
            AddObjsIntoTags(_tags, _objs);
        }

        #region Find

        public Obj FindObjById(string id)
        {
            foreach (var o in _objs)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            return new Obj("null", -1);
        }

        public Obj FindObjByName(string name)
        {
            foreach (var o in _objs)
            {
                if (o.Name == name)
                {
                    return o;
                }
            }
            return new Obj("null", -1);
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

        #endregion Find

        #region Get

        public static string ToString(List<Tag> tags)
        {
            var s = "";
            foreach (var t in tags)
            {
                s += $"{t.Name},";
            }
            s.TrimEnd(',');
            return s;
        }

        public List<Obj> GetChildObjs(Tag tag)
        {
            var objs = new List<Obj>();
            var targetTagChildObjIDs = tag.ChildObjIDs;
            foreach (var id in targetTagChildObjIDs)
            {
                objs.Add(FindObjById(id));
            }
            return objs;
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

        public List<Tag> GetParentTags(Taggable taggable)
        {
            var tags = new List<Tag>();
            var targetTagTarentTagIDs = taggable.ParentTagIDs;
            foreach (var id in targetTagTarentTagIDs)
            {
                tags.Add(FindTagById(id));
            }
            return tags;
        }

        #endregion Get

        #region Info

        public string GetInfo(Obj obj)
        {
            var msg = "";
            msg += $"Name: {obj.Name}\n" +
                   $"ID: {obj.Id}\n" +
                   $"Path: {obj.Path}";
            return msg;
        }

        public string GetInfo(Tag tag)
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

        public void ShowInfo(Obj obj)
        {
            System.Windows.Forms.MessageBox.Show(GetInfo(obj));
        }

        public void ShowInfo(Tag tag)
        {
            System.Windows.Forms.MessageBox.Show(GetInfo(tag));
        }

        #endregion Info

        private void AddObjsIntoTags(List<Tag> tags, List<Obj> objs)
        {
            foreach (var obj in objs)
            {
                foreach (var oParentTagId in obj.ParentTagIDs)
                {
                    var findedTag = FindTagById(oParentTagId);
                    findedTag.ChildObjIDs.Add(obj.Id);
                }
            }
        }

        #region TreeView

        public void CreatTagTreeView(TreeView treeView)
        {
            var index = 0;
            foreach (var tag in _tags)
            {
                var pt = GetParentTags(tag);
                if (tag.Name != "root" &&
                    pt.Count == 1 &&
                    pt[0].Name == "root")
                {
                    var treeNode = CreatTreeNode(tag);
                    treeView.Nodes.Add(treeNode);

                    index++;
                }
            }
            treeView.ExpandAll();
        }

        private TreeNode CreatTreeNode(Tag tag)
        {
            var treeNode = new TreeNode(tag.Name);

            var childTags = GetChildTags(tag);
            if (childTags.Count > 0)
            {
                foreach (var ct in childTags)
                {
                    var subNode = CreatTreeNode(ct);
                    treeNode.Nodes.Add(subNode);
                }
            }

            return treeNode;
        }

        #endregion TreeView

        #region ListView

        public void CreateObjsListView(ListView listView)
        {
            listView.View = View.Details;
            listView.GridLines = true;
            listView.LabelEdit = false;
            listView.FullRowSelect = true;
            listView.MultiSelect = false;
            listView.Columns.Add("Name", 100);
            listView.Columns.Add("Tags", 100);
            listView.Columns.Add("Path", 100);
        }

        public void UpdateObjListView(ListView listView, Tag tag)
        {
            tag = tag ?? new Tag();
            listView.Items.Clear();

            var childObjs = GetChildObjs(tag);
            foreach (var co in childObjs)
            {
                var item = new ListViewItem(co.Name);
                item.SubItems.Add(ToString(GetParentTags(co)));
                item.SubItems.Add(co.Path);

                listView.Items.Add(item);
            }
        }

        #endregion ListView
    }
}