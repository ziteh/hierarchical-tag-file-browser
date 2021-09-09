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
        public List<Tag> Read(string path)
        {
            var rootTag = new Tag();
            var tags = new List<Tag>() { rootTag };
            int id = rootTag.Id + 1;
            var nodes = LoadXmlNodeList(path);
            foreach (XmlNode node in nodes)
            {
                var name = node.SelectSingleNode(Define.Name).InnerText.Trim();

                var sType = node.SelectSingleNode(Define.Type).InnerText.Trim();
                TagType type;
                if (!String.IsNullOrWhiteSpace(sType))
                {
                    type = TagTypeParser.Parse(sType);
                }
                else
                {
                    type = TagType.General;
                }

                var sParentTags = node.SelectSingleNode(Define.ParentTags).InnerText.Trim();
                List<Tag> parentTags = new List<Tag>();
                if (!String.IsNullOrWhiteSpace(sParentTags))
                {
                    foreach (var pt in sParentTags.Split(Define.Spliter))
                    {
                        foreach (var t in tags)
                        {
                            if (t.Name == pt.Trim())
                            {
                                parentTags.Add(t);
                            }
                        }
                    }
                }
                else
                {
                    // Add root-tag.
                    parentTags.Add(rootTag);
                }

                var sAlias = node.SelectSingleNode(Define.Alias).InnerText.Trim();
                var alias = new List<string>();
                if (!String.IsNullOrWhiteSpace(sAlias))
                {
                    foreach (var a in sAlias.Split(Define.Spliter))
                    {
                        alias.Add(a.Trim());
                    }
                }

                var remark = node.SelectSingleNode(Define.Remark).InnerText.Trim();
                if (String.IsNullOrWhiteSpace(remark))
                {
                    remark = "";
                }

                var tag = new Tag(name, id, type, parentTags)
                {
                    Alias = alias,
                    Remark = remark
                };
                tags.Add(tag);
                id++;
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