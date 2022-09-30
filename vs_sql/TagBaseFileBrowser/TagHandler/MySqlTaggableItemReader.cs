using System;
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
            var cmdText = MakeCmdText(_filesTable, "id", "=", id.ToString());
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

                file = new File(data[1], id)
                {
                    Remark = data[3],
                    ThumbnailPath = data[4],
                    Tags = parentTag
                };
            }
            conn.Close();

            return file;
        }

        public void AddTag(Tag tag)
        {
            var conn = MakeConn();
            conn.Open();

            // TODO
            var cmdText = $"INSERT INTO `{_tagsTable}` (`id`, `type`, `name`, `alias`, `remark`, `thumbnail_path`, `font_color`, `back_color`) VALUES (NULL, '1', '{tag.Name}', NULL, NULL, NULL, NULL, NULL);";
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
            var cmdText = MakeCmdText(_tagsTable, "id", "=", id.ToString());
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
            var cmdText = MakeCmdText(_tagsTable);
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
            var cmdText = MakeCmdText(_tagRelationTable, "child_tag_id", "=", id.ToString());
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
            var cmdText = MakeCmdText(_tagRelationTable, "parent_tag_id", "=", id.ToString());
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

        private string MakeCmdText(string table, string column = "*")
        {
            return $"SELECT {column} FROM `{table}`";
        }

        private string MakeCmdText(string table, string where, string op, string value)
        {
            return $"SELECT * FROM `{table}` WHERE `{where}` {op} {value}";
        }
    }
}