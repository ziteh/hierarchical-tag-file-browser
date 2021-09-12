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
        private Dictionary<string, string> _parametersValuePairs = new Dictionary<string, string>();
        private string _path;
        private List<Tag> _tags;

        public TaggableItemHandler(string path)
        {
            _path = path;

            var xmlTagIO = new XmlTagDatabaseIO();
            _tags = xmlTagIO.Read(path + @"\tag_db.xml", out var tagNameIdPaids);

            var xmlObjIO = new XmlObjDatabaseIO();
            _objs = xmlObjIO.Read(path + @"\obj_db.xml");

            var xmlParamIO = new XmlParametersIO();
            _parametersValuePairs = xmlParamIO.Read(path + @"\parameters.xml");

            AddObjsIntoTags(_tags, _objs);
        }

        public TaggableItemHandler(List<Tag> tags, List<Obj> objs)
        {
            _tags = tags;
            _objs = objs;
            AddObjsIntoTags(_tags, _objs);
        }

        public void AddTag(string objPath, List<string> tagNames)
        {
            var xmlObjIO = new XmlObjDatabaseIO();
            xmlObjIO.Write($"{_path}\\obj_db.xml", objPath, tagNames);
            _objs = xmlObjIO.Read($"{_path}\\obj_db.xml");
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

        public static string ToString(List<Tag> tags, char splicer = ',')
        {
            var s = "";
            foreach (var t in tags)
            {
                s += $"{t.Name}{splicer}";
            }
            s = s.TrimEnd(splicer);
            return s;
        }

        public List<Obj> GetChildObjs(Tag tag)
        {
            var objs = new List<Obj>();
            var targetTagChildObjNames = tag.ChildObjNames;
            foreach (var name in targetTagChildObjNames)
            {
                objs.Add(FindObjByName(name));
            }
            return objs;
        }

        public List<Tag> GetChildTags(Tag tag)
        {
            var tags = new List<Tag>();
            var targetTagChildTagNames = tag.ChildTagNames;
            foreach (var name in targetTagChildTagNames)
            {
                tags.Add(FindTagByName(name));
            }
            return tags;
        }

        public List<Tag> GetParentTags(Taggable taggable)
        {
            var tags = new List<Tag>();
            var targetTagTarentTagNames = taggable.ParentTagNames;
            foreach (var name in targetTagTarentTagNames)
            {
                tags.Add(FindTagByName(name));
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
                   $"Path: {obj.Path}\n" +
                   $"Tags: {ToString(GetParentTags(obj))}";
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
            msg = msg.Trim(',');

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
                foreach (var oParentTagName in obj.ParentTagNames)
                {
                    var findedTag = FindTagByName(oParentTagName);
                    findedTag.ChildObjNames.Add(obj.Name);
                }
            }
        }

        #region TreeView

        public void CreatTagTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();
            foreach (var tag in _tags)
            {
                if (tag.Name != "root" &&
                    tag.ParentTagNames.Count == 1 &&
                    tag.ParentTagNames[0] == "root")
                {
                    var treeNode = CreatTreeNode(tag);
                    treeView.Nodes.Add(treeNode);
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

        #region Parameters

        public string ReplaceParameter(string text)
        {
            while (CheckParameter(text, out var index, out var length))
            {
                var param = text.Substring(index, length);
                text = text.Replace($"{Define.ParameterHead}{param}{Define.ParameterEnd}",
                                    _parametersValuePairs[param]);
            }
            return text;
        }

        private bool CheckParameter(string text, out int index, out int length)
        {
            bool check;

            var headIndex = text.IndexOf(Define.ParameterHead);
            var endIndex = text.IndexOf(Define.ParameterEnd);
            if (headIndex != -1 && endIndex != -1 && endIndex > headIndex)
            {
                check = true;
                index = headIndex + 1;
                length = endIndex - headIndex - 1;
            }
            else
            {
                check = false;
                index = 0;
                length = 0;
            }

            return check;
        }

        #endregion Parameters
    }
}