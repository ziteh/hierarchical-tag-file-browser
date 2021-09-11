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
        private Dictionary<string, string> _tagNameIdPairs;

        public XmlObjDatabaseIO(Dictionary<string, string> tagNameIdPairs)
        {
            _tagNameIdPairs = tagNameIdPairs;
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

                objs.Add(new Obj(name, id) { Path = objPath, ParentTagNames = parentTagNames });
                id++;
            }
            return objs;
        }

        #region Parse

        private string ParseName(XmlNode node)
        {
            var name = node.SelectSingleNode(Define.Name).InnerText;

            if (String.IsNullOrWhiteSpace(name))
                name = Define.Error;
            else
                name = name.Trim();

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
            /// TODO: resolve SelectSingleNode return null.
            var path = node.SelectSingleNode(Define.Path).InnerText;

            if (String.IsNullOrWhiteSpace(path))
                path = Define.Error;
            else
                path = path.Trim();

            return path;
        }

        #endregion Parse

        private XmlNodeList LoadXmlNodeList(string path)
        {
            var sr = MakeStreamReader(path);
            var xd = new XmlDocument();
            xd.LoadXml(sr.ReadToEnd());
            return xd.SelectNodes($"/{Define.Root}/{Define.Obj}");
        }

        private StreamReader MakeStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}