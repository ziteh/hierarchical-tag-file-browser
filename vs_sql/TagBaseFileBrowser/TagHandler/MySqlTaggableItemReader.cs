﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TagHandler
{
    public class MySqlTaggableItemReader
    {
        #region Table

        private readonly string _tagsTable = "tags";
        private readonly string _tagRelationTable = "tag_relation";

        private readonly string _filesTable = "files";
        private readonly string _fileRelationTable = "file_relation";

        #endregion Table

        #region Connection

        private string _server;
        private string _database;
        private string _user;
        private string _password;
        private int _port;

        #endregion Connection

        public MySqlTaggableItemReader(string database, string user = "root", string password = null, string server = "localhost", int port = 3306)
        {
            _server = server;
            _database = database;
            _user = user;
            _password = password;
            _port = port;
        }

        ~MySqlTaggableItemReader()
        {
        }

        public File ReadFile(int id, bool resursive = true)
        {
            File file = null;

            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_filesTable, "id", id);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = new List<string>();
                for (int col = 1; col < reader.FieldCount; col++)
                {
                    string s;
                    if (reader.IsDBNull(col))
                    {
                        s = "";
                    }
                    else
                    {
                        s = reader.GetString(col);
                    }
                    data.Add(s);
                }

                var parentTag = resursive ? ReadParentTags(id) : null;

                file = new File(data[1], data[4], id)
                {
                    Remark = data[3],
                    ThumbnailPath = data[5],
                    PreviewPath = data[6],
                    Tags = parentTag
                };
            }
            conn.Close();

            return file;
        }

        public void AddFile(File file)
        {
            if (ReadFile(file.Name) != null)
            {
                throw new Exception("File already exists.");
            }

            var conn = MakeConn();
            conn.Open();

            var colValPairs = new Dictionary<string, string>();
            colValPairs.Add("name", file.Name);
            colValPairs.Add("alias", null); // TODO
            colValPairs.Add("remark", file.Remark);
            colValPairs.Add("path", file.Path);
            colValPairs.Add("thumbnail_path", file.ThumbnailPath);
            colValPairs.Add("preview_path", file.PreviewPath);

            var cmdText = MakeInsertCmdText(_filesTable, colValPairs);
            var cmd = new MySqlCommand(cmdText, conn);
            var n = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddTag(Tag tag)
        {
            if (ReadTag(tag.Name) != null)
            {
                throw new Exception("Tag already exists.");
            }

            var conn = MakeConn();
            conn.Open();

            // TODO
            var cmdText = $"INSERT INTO `{_tagsTable}` (`id`, `type`, `name`, `alias`, `remark`, `thumbnail_path`, `font_color`, `back_color`) VALUES (NULL, '1', '{tag.Name}', NULL, NULL, NULL, NULL, NULL);";
            var cmd = new MySqlCommand(cmdText, conn);
            var n = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddFileRelation(Tag parentTag, File childFile)
        {
            var conn = MakeConn();
            conn.Open();

            var colValPairs = new Dictionary<string, string>();
            colValPairs.Add("parent_tag_id", parentTag.Id.ToString());
            colValPairs.Add("child_file_id", childFile.Id.ToString());

            var cmdText = MakeInsertCmdText(_fileRelationTable, colValPairs);
            var cmd = new MySqlCommand(cmdText, conn);
            var n = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AddTagRelation(Tag parentTag, Tag childTag)
        {
            var conn = MakeConn();
            conn.Open();

            var cmdText = $"INSERT INTO `{_tagRelationTable}` (`id`, `parent_tag_id`, `child_tag_id`) VALUES (NULL, '{parentTag.Id}', '{childTag.Id}');";
            var cmd = new MySqlCommand(cmdText, conn);
            var n = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public File ReadFile(string name)
        {
            File file = null;

            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_filesTable, "name", name);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = new List<string>();
                for (int col = 0; col < reader.FieldCount; col++)
                {
                    string s;
                    if (reader.IsDBNull(col))
                    {
                        s = null;
                    }
                    else
                    {
                        s = reader.GetString(col);
                    }
                    data.Add(s);
                }

                // TODO
                //var parentTag = resursive ? ReadParentTags(id) : null;

                file = new File(name, data[4])
                {
                    Id = int.Parse(data[0]),
                    Remark = data[3],
                    ThumbnailPath = data[5],
                    PreviewPath = data[6],
                    Tags = null
                };
            }
            conn.Close();

            return file;
        }

        public Tag ReadTag(string name)
        {
            Tag tag = null;

            var conn = MakeConn();
            conn.Open();
            var cmdText = $"SELECT * FROM `{_tagsTable}` WHERE `name` LIKE '{name}'";
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = new List<string>();
                for (int col = 0; col < reader.FieldCount; col++)
                {
                    string s;
                    if (reader.IsDBNull(col))
                    {
                        s = "";
                    }
                    else
                    {
                        s = reader.GetString(col);
                    }
                    data.Add(s);
                }

                // TODO
                //var parentTag = resursive ? ReadParentTags(id) : null;

                tag = new Tag(name)
                {
                    Id = int.Parse(data[0]),
                    Remark = data[4],
                    ThumbnailPath = data[5],
                    Tags = null
                };
            }
            conn.Close();

            return tag;
        }

        public Tag ReadTag(int id, bool resursive = true)
        {
            Tag tag = null;

            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_tagsTable, "id", id);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var data = new List<string>();
                for (int col = 1; col < reader.FieldCount; col++)
                {
                    string s;
                    if (reader.IsDBNull(col))
                    {
                        s = "";
                    }
                    else
                    {
                        s = reader.GetString(col);
                    }
                    data.Add(s);
                }

                var parentTag = resursive ? ReadParentTags(id) : null;

                tag = new Tag(data[1], id)
                {
                    Remark = data[3],
                    ThumbnailPath = data[4],
                    Tags = parentTag
                };
            }
            conn.Close();

            return tag;
        }

        public List<Tag> ReadAllTags()
        {
            List<Tag> tags = new List<Tag>();

            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_tagsTable);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(0) || reader.IsDBNull(1))
                {
                    continue;
                }
                var id = reader.GetInt32(0);
                var name = reader.GetString(2);

                string remakr = "";
                if (!reader.IsDBNull(4))
                {
                    remakr = reader.GetString(4);
                }

                string thumbnail = "";
                if (!reader.IsDBNull(5))
                {
                    thumbnail = reader.GetString(5);
                }

                var parentTag = ReadParentTags(id);

                var tag = new Tag(name, id)
                {
                    Remark = remakr,
                    ThumbnailPath = thumbnail,
                    Tags = parentTag
                };

                tags.Add(tag);
            }
            conn.Close();

            return tags;
        }

        public int GetRowCount(string table)
        {
            var conn = MakeConn();
            conn.Open();
            var cmdText = $"SELECT COUNT(*) FROM `{table}`";
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var count = reader.GetInt32(0);
            conn.Close();
            return count;
        }

        public List<Tag> ReadChildTags(int id)
        {
            var tags = new List<Tag>();
            var childIds = ReadChildTagsId(id);
            foreach (var ci in childIds)
            {
                var tag = ReadTag(ci, false);
                tags.Add(tag);
            }
            return tags;
        }

        public List<File> ReadChildFiles(int id)
        {
            var files = new List<File>();
            var children = ReadChildTagsId(id);
            foreach (var c in children)
            {
                var file = ReadFile(c, false);
                files.Add(file);
            }
            return files;
        }

        private MySqlConnection MakeConn()
        {
            var connText = $"server={_server};" +
                           $"port={_port};" +
                           $"database={_database};" +
                           $"user id={_user}";
            if (_password != null)
            {
                connText += $";password={_password}";
            }

            return new MySqlConnection(connText);
        }

        private List<int> ReadParentTagsId(int id)
        {
            var ids = new List<int>();
            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_tagRelationTable, "child_tag_id", id);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var col = 1;
                if (reader.IsDBNull(col))
                {
                    continue;
                }

                var parentTagId = reader.GetInt16(col);
                ids.Add(parentTagId);
            }
            conn.Close();
            return ids;
        }

        private List<Tag> ReadParentTags(int id)
        {
            var tags = new List<Tag>();
            var parentIds = ReadParentTagsId(id);
            foreach (var pi in parentIds)
            {
                var tag = ReadTag(pi, false);
                tags.Add(tag);
            }
            return tags;
        }

        private List<int> ReadChildTagsId(int id)
        {
            var ids = new List<int>();
            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_tagRelationTable, "parent_tag_id", id);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var col = 2;
                if (reader.IsDBNull(col))
                {
                    continue;
                }

                var childTagId = reader.GetInt16(col);
                ids.Add(childTagId);
            }
            conn.Close();
            return ids;
        }

        #region Make Command Text

        private string MakeSelectCmdText(string table, string column = "*")
        {
            return $"SELECT {column} FROM `{table}`;";
        }

        private string MakeSelectCmdText(string table, string columnName, int value)
        {
            return $"SELECT * FROM `{table}` WHERE `{columnName}` = {value};";
        }

        private string MakeSelectCmdText(string table, string columnName, string value)
        {
            return $"SELECT * FROM `{table}` WHERE `{columnName}` LIKE '{value}';";
        }

        private string MakeInsertCmdText(string table, Dictionary<string, string> colValuePairs)
        {
            var cols = "`id`, ";
            var vals = "NULL, ";

            foreach (var cv in colValuePairs)
            {
                if (string.IsNullOrEmpty(cv.Key))
                {
                    throw new Exception("Column name shouldn't be null or empty.");
                }
                else
                {
                    cols += $"`{cv.Key}`, ";
                }

                if (cv.Value == null)
                {
                    vals += "NULL, ";
                }
                else
                {
                    vals += $"'{cv.Value}', ";
                }
            }

            // Remove the last ", ".
            cols = cols.TrimEnd().TrimEnd(',');
            vals = vals.TrimEnd().TrimEnd(',');

            return $"INSERT INTO `{table}` ({cols}) VALUES ({vals});";
        }

        #endregion Make Command Text
    }
}