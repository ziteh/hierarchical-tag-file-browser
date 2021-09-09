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
        private readonly XmlDocument _xmlDocument = new XmlDocument();

        public List<Tag> Read(string path)
        {
            var tags = new List<Tag>();
            var nodes = LoadXml(path);
            foreach (XmlNode node in nodes)
            {
                var tag = new Tag(node.SelectSingleNode(XmlNodeDefine.Name).InnerText.Trim());

                var tAlias = node.SelectSingleNode(XmlNodeDefine.Alias).InnerText.Trim();
                if (!String.IsNullOrWhiteSpace(tAlias))
                {
                    tag.Alias = new List<string>(tAlias.Split(','));
                }

                var tType = node.SelectSingleNode(XmlNodeDefine.Type).InnerText.Trim();
                if (!String.IsNullOrWhiteSpace(tType))
                {
                    tag.Type = TagTypeParser.Parse(tType);
                }
                else
                {
                    tag.Type = TagType.General;
                }
            }

            throw new NotImplementedException();
        }

        public void Write(string path, Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Write(string path, List<Tag> tags)
        {
            throw new NotImplementedException();
        }

        private XmlNodeList LoadXml(string path)
        {
            var sr = MakeStreamReader(path);
            var xd = new XmlDocument();
            xd.LoadXml(sr.ReadToEnd());
            return xd.SelectNodes($"/{XmlNodeDefine.Root}/{XmlNodeDefine.Tag}");
        }

        private StreamReader MakeStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}