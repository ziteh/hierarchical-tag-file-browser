using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TagBaseFileBrowser.IO
{
    public class XmlObjDatabaseIO : IObjDatabaseIO
    {
        public XmlObjDatabaseIO()
        {
        }

        public List<Obj> Read(string path)
        {
            var objs = new List<Obj>();
            int id = 0;
            var nodes = LoadXmlNodeList(path);
            foreach (XmlNode node in nodes)
            {
                var name = ParseName(node);
                var objPath = ParsePath(node);
                var parentTagNames = ParseParentTagNames(node);

                if (String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(objPath))
                {
                    var ops = objPath.TrimEnd('\\').Split('\\');
                    name = ops[ops.Length - 1];
                }

                objs.Add(new Obj(name, id) { Path = objPath, ParentTagNames = parentTagNames });
                id++;
            }
            return objs;
        }

        #region Parse

        private string ParseName(XmlNode node)
        {
            string name = null;

            var n = node.SelectSingleNode(Define.Name);
            if (n != null)
            {
                name = n.InnerText;

                if (!String.IsNullOrWhiteSpace(name))
                    name = name.Trim();
            }

            return name;
        }

        private List<string> ParseParentTagNames(XmlNode node)
        {
            List<string> parentTagIDs = new List<string>();
            var nodes = node.SelectNodes(Define.ParentTag);
            if (nodes != null)
            {
                foreach (XmlNode n in nodes)
                {
                    var name = n.InnerText;
                    if (String.IsNullOrWhiteSpace(name))
                    {
                        name = Define.Error;
                    }
                    parentTagIDs.Add(name.Trim());
                }
            }
            else
            {
                parentTagIDs.Add(new Tag().Id);
            }
            return parentTagIDs;
        }

        private string ParsePath(XmlNode node)
        {
            return node.Attributes.GetNamedItem(Define.Path).Value.Trim();
        }

        #endregion Parse

        private XmlNodeList LoadXmlNodeList(string path)
        {
            var sr = MakeStreamReader(path);
            var xd = new XmlDocument();
            xd.LoadXml(sr.ReadToEnd());
            sr.Close();
            return xd.SelectNodes($"/{Define.Root}/{Define.Obj}");
        }

        private StreamReader MakeStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}