using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace TagBaseFileBrowser
{
    public static class ConfigHandler
    {
        public const string configFile = "config.json";

        public static Config Read(string path)
        {
            Config config;
            try
            {
                using (var streamReader = new StreamReader(PathHandler(path)))
                {
                    var jsonContent = streamReader.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(jsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't load or parse \"{configFile}\".\r\n{ex.Message}");
                config = null;
            }

            return config;
        }

        private static string PathHandler(string path)
        {
            if (path.IndexOf(configFile) == -1)
            {
                path = path.TrimEnd('\\') + configFile;
            }
            return path;
        }
    }

    public class Config
    {
        public string defaultPath { get; set; }
        public List<string> objDatabases { get; set; }
        public string objDatabaseType { get; set; }
        public string parameterFile { get; set; }
        public List<string> tagDatabases { get; set; }
        public string tagDatabaseType { get; set; }
    }
}