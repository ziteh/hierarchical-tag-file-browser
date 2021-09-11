using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TagBaseFileBrowser.IO
{
    public class XmlTagDatabaseIO : ITagDatabaseIO
    {
        public List<Tag> Read(string path, out Dictionary<string, string> tagNameIdPairs)
        {
            tagNameIdPairs = new Dictionary<string, string>();
            var tags = new List<Tag>() { new Tag() };
            int id = 0;
            var nodes = LoadXmlNodeList(path);
            foreach (XmlNode node in nodes)
            {
                try
                {
                    // Parse xml node.
                    var name = ParseName(node);
                    var type = ParseTagType(node);
                    var parentTagNames = ParseParentTagNames(node);
                    var alias = ParesAlias(node);
                    var remark = ParseRemark(node);

                    // Add to tags.
                    var tag = new Tag(name, id, type, parentTagNames)
                    {
                        Alias = alias,
                        Remark = remark
                    };
                    tags.Add(tag);

                    // Add self to child-list of parent-tag.
                    foreach (var parentName in parentTagNames)
                    {
                        foreach (var t in tags)
                        {
                            if (parentName == t.Name)
                            {
                                if (t.ChildTagNames == null)
                                    t.ChildTagNames = new List<string>();

                                t.ChildTagNames.Add(name);
                            }
                        }
                    }

                    tagNameIdPairs.Add(name, $"t{id}");
                    id++;
                }
                catch
                {
                    continue;
                }
            }
            return tags;
        }

        public void Write(string path, Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Write(string path, List<Tag> tags)
        {
            throw new NotImplementedException();
        }

        #region Parse

        private List<string> ParesAlias(XmlNode node)
        {
            List<string> alias = new List<string>();
            var nodes = node.SelectNodes(Define.Alias);
            if (nodes != null)
            {
                foreach (XmlNode n in nodes)
                {
                    var name = n.InnerText;
                    if (String.IsNullOrWhiteSpace(name))
                    {
                        name = Define.Error;
                    }
                    alias.Add(name.Trim());
                }
            }
            return alias;
        }

        private string ParseName(XmlNode node)
        {
            return node.SelectSingleNode(Define.Name).InnerText.Trim();
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

        private string ParseRemark(XmlNode node)
        {
            try
            {
                return node.SelectSingleNode(Define.Remark).InnerText.Trim();
            }
            catch
            {
                return "";
            }
        }

        private TagType ParseTagType(XmlNode node)
        {
            TagType type;
            var typeNode = node.SelectSingleNode(Define.Type);
            if (typeNode != null)
            {
                var stringType = typeNode.InnerText.Trim();
                if (!String.IsNullOrWhiteSpace(stringType))
                {
                    type = TagTypeParser.Parse(stringType);
                }
                else
                {
                    type = TagType.General;
                }
            }
            else
            {
                type = TagType.General;
            }

            return type;
        }

        #endregion Parse

        private XmlNodeList LoadXmlNodeList(string path)
        {
            var sr = MakeStreamReader(path);
            var xd = new XmlDocument();
            xd.LoadXml(sr.ReadToEnd());
            return xd.SelectNodes($"/{Define.Root}/{Define.Tag}");
        }

        private StreamReader MakeStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}