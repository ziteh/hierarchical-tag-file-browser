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

        // TODO.
        public void CreateNewDatabase()
        {
            throw new NotImplementedException();
        }

        public void AddFile(File file)
        {
            if (QueryFile(file.Name) != null)
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
            if (QueryTag(tag.Name) != null)
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

        public File QueryFile(int id, bool includeParent = true)
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

                var parentTag = includeParent ? ReadParentTagsOfFile(id) : null;

                file = new File(data[0], data[3], id)
                {
                    Remark = data[2],
                    ThumbnailPath = data[4],
                    PreviewPath = data[5],
                    Tags = parentTag
                };
            }
            conn.Close();

            return file;
        }

        public File QueryFile(string name, bool includeParent = true)
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

                var id = int.Parse(data[0]);
                var parentTag = includeParent ? ReadParentTagsOfFile(id) : null;

                file = new File(name, data[4])
                {
                    Id = id,
                    Remark = data[3],
                    ThumbnailPath = data[5],
                    PreviewPath = data[6],
                    Tags = parentTag
                };
            }
            conn.Close();

            return file;
        }

        public Tag QueryTag(string name, bool includeParent = true)
        {
            Tag tag = null;

            var conn = MakeConn();
            conn.Open();
            var cmdText = MakeSelectCmdText(_tagsTable, "name", name);
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

                var id = int.Parse(data[0]);
                var parentTag = includeParent ? ReadParentTagsOfTag(id) : null;

                tag = new Tag(name)
                {
                    Id = id,
                    Remark = data[4],
                    ThumbnailPath = data[5],
                    Tags = parentTag
                };
            }
            conn.Close();

            return tag;
        }

        public Tag QueryTag(int id, bool includeParent = true)
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

                var parentTag = includeParent ? ReadParentTagsOfTag(id) : null;

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
            var tags = new List<Tag>();

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

                var parentTag = ReadParentTagsOfTag(id);

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

        public List<Tag> ReadChildTags(int parentTagId)
        {
            var tags = new List<Tag>();
            var childIds = GetChildTagIds(parentTagId, false);
            foreach (var ci in childIds)
            {
                var tag = QueryTag(ci, false);
                tags.Add(tag);
            }
            return tags;
        }

        public List<File> ReadChildFiles(int parentTagId)
        {
            var files = new List<File>();
            var children = GetChildTagIds(parentTagId);
            foreach (var c in children)
            {
                var file = QueryFile(c, false);
                files.Add(file);
            }
            return files;
        }

        public List<File> GetChildFiles(int parentTagId, bool recusive = true)
        {
            var childFiles = new List<File>();
            var childFileIds = GetChildFileIds(parentTagId, recusive);
            foreach (var childId in childFileIds)
            {
                childFiles.Add(QueryFile(childId, false));
            }
            return childFiles;
        }

        public List<Tag> GetChildTags(int parentTagId, bool recusive = true)
        {
            var childTags = new List<Tag>();
            var childTagIds = GetChildTagIds(parentTagId, recusive);
            foreach (var childId in childTagIds)
            {
                childTags.Add(QueryTag(childId, false));
            }
            return childTags;
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

        private List<int> ReadParentTagsId(int childId, string relationTable, string childColumnName)
        {
            var ids = new List<int>();

            var conn = MakeConn();
            conn.Open();

            var cmdText = MakeSelectCmdText(relationTable, childColumnName, childId);
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

        private List<int> ReadParentTagsIdOfFile(int childFileId)
        {
            return ReadParentTagsId(childFileId, _fileRelationTable, "child_file_id");
        }

        private List<int> ReadParentTagsIdOfTag(int childTagId)
        {
            return ReadParentTagsId(childTagId, _tagRelationTable, "child_tag_id");
        }

        private List<Tag> ReadParentTagsOfFile(int childFileId)
        {
            var parentTags = new List<Tag>();
            var parentIds = ReadParentTagsIdOfFile(childFileId);
            foreach (var pId in parentIds)
            {
                var pTag = QueryTag(pId, false);
                parentTags.Add(pTag);
            }
            return parentTags;
        }

        private List<Tag> ReadParentTagsOfTag(int childTagId)
        {
            var parentTegs = new List<Tag>();
            var parentIds = ReadParentTagsIdOfTag(childTagId);
            foreach (var pId in parentIds)
            {
                var pTag = QueryTag(pId, false);
                parentTegs.Add(pTag);
            }
            return parentTegs;
        }

        private List<int> GetChildIds(int parentTagId, string relationTable)
        {
            var ids = new List<int>();

            var conn = MakeConn();
            conn.Open();

            var cmdText = MakeSelectCmdText(relationTable, "parent_tag_id", parentTagId);
            var cmd = new MySqlCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var col = 2;
                if (reader.IsDBNull(col))
                {
                    continue;
                }

                var childId = reader.GetInt16(col);
                ids.Add(childId);
            }

            conn.Close();
            return ids;
        }

        private List<int> GetChildFileIds(int parentTagId, bool recursive = true)
        {
            var tagIds = new List<int>();
            tagIds.Add(parentTagId);

            if (recursive)
            {
                tagIds.AddRange(GetChildTagIds(parentTagId, true));
            }

            var childFileIds = new List<int>();
            foreach (var id in tagIds)
            {
                childFileIds.AddRange(GetChildIds(id, _fileRelationTable));
            }

            return childFileIds;
        }

        private List<int> GetChildTagIds(int parentTagId, bool recursive = true)
        {
            var childTagIds = GetChildIds(parentTagId, _tagRelationTable);

            if (recursive && childTagIds.Count > 0)
            {
                var resursiveIds = new List<int>();
                foreach (var childTagId in childTagIds)
                {
                    resursiveIds.AddRange(GetChildTagIds(childTagId, true));
                }
                childTagIds.AddRange(resursiveIds);
            }

            return childTagIds;
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