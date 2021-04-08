using System.Collections.Generic;
using System.IO;

namespace TagBaseFileBrowser
{
    public class Csv
    {
        public static List<List<string>> Read(string path,
                                              bool includeColumnName = false,
                                              char symbolSeparated = ',',
                                              char symbolStringDelimiter = '\"')
        {
            var csvContent = new List<List<string>>();

            if (System.IO.File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var row = new List<string>();
                        var line = reader.ReadLine();
                        var values = line.Split(symbolSeparated);
                        foreach (var t in values)
                        {
                            row.Add(t.Trim().Trim(symbolStringDelimiter).Trim());
                        }
                        csvContent.Add(row);
                    }
                    reader.Close();
                }
            }

            if (!includeColumnName)
            {
                csvContent.RemoveAt(0);
            }

            return csvContent;
        }
    }
}