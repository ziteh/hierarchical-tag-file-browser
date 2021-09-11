using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TagBaseFileBrowser.IO
{
    public class XmlParametersIO
    {
        public Dictionary<string, string> Read(string path)
        {
            var dic = new Dictionary<string, string>();

            var xmlNodes = LoadXmlNodeList(path);
            foreach (XmlNode xmlNode in xmlNodes)
            {
                var nodeAttributes = xmlNode.Attributes;
                var name = nodeAttributes.GetNamedItem(Define.Name).Value;
                var value = nodeAttributes.GetNamedItem(Define.Value).Value;
                dic.Add(name, value);
            }

            return dic;
        }

        private XmlNodeList LoadXmlNodeList(string path)
        {
            var sr = MakeStreamReader(path);
            var xd = new XmlDocument();
            xd.LoadXml(sr.ReadToEnd());
            sr.Close();
            return xd.SelectNodes($"/{Define.Root}/{Define.Paramemter}");
        }

        private StreamReader MakeStreamReader(string path)
        {
            return new StreamReader(path);
        }
    }
}