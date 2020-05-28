using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace GitSame
{
    public class FileEntity
    {
        [DataMember]
        public string owner { get; set; }
        [DataMember]
        public string repo_name { get; set; }
        [DataMember]
        public string path { get; set; }
        [DataMember]
        public string hash { get; set; }
        [DataMember]
        public int andSoOnFiles { get; set; }
        /*
         * The field will be filled in if the grouping by owner mode is set.
         * If a situation arises when there are matches in several repositories of the same owner,
         * as well as in the repository of another owner, this field will indicate the number 
         * of repositories of the same owner with the same file. For instance:
         * owner A file1
         * owner A file2
         * owner B file3
         * (files are same)
         * result:
         * owner A file1 andSoOnFiles=2( it means we have 2 files with the same content owes to one person)
         * owner B file3 andSoOnFiles=1
        */
    }

    public class RepoEntity
    {
        [DataMember]
        public string owner { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string branch { get; set; }
        [DataMember]
        public string last_commit_hash { get; set; }
        [DataMember]
        public int andSoOnFiles { get; set; }
        [DataMember]
        public bool is_checked { get; set; }
    }

    public class DbManager
    {
        private string m_pathToDb;
        private SqliteConnection m_dbConn;
        private SqliteCommand m_sqlCmd;
        public DbManager(string pathToDb)
        {
            m_pathToDb = pathToDb;
            m_sqlCmd = new SqliteCommand();
            createDb();
        }

        private void createDb()
        {
            m_dbConn = new SqliteConnection("Data Source=" + m_pathToDb + ";");
            m_dbConn.Open();
            m_sqlCmd.Connection = m_dbConn;
            m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Repos (owner TEXT ,name TEXT , description TEXT, branch TEXT, last_commit_hash TEXT,is_checked INTEGER, PRIMARY KEY(owner,name))";
            m_sqlCmd.ExecuteNonQuery();
            m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Files (owner TEXT, repo_name TEXT, path TEXT, hash TEXT,PRIMARY KEY(owner,repo_name,path,hash))";
            m_sqlCmd.ExecuteNonQuery();
        }

        private SqliteDataReader doSelectRequest(string request)
        {
            var command = new SqliteCommand();
            command.Connection = m_dbConn;
            command.CommandText = request;
            command.CommandType = CommandType.Text;
            return command.ExecuteReader();
        }

        public void changeFileHash(FileEntity file)
        {
            var req = string.Format("UPDATE Files SET hash=\"{0}\" WHERE owner=\"{1}\" AND repo_name=\"{2}\"",
            file.hash, file.owner, file.repo_name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void checkRepo(RepoEntity repo, bool isChecked)
        {
            var req = string.Format("UPDATE Repos SET is_checked=\"{0}\" WHERE owner=\"{1}\" AND name=\"{2}\"",
            (isChecked) ? 1 : 0, repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void changeRepoBranch(RepoEntity repo)
        {
            var req = string.Format("UPDATE Repos SET branch=\"{0}\" WHERE owner=\"{1}\" AND name=\"{2}\"",
            repo.branch, repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void changeRepoDescription(RepoEntity repo)
        {
            var req = string.Format("UPDATE Repos SET description=\"{0}\" WHERE owner=\"{1}\" AND name=\"{2}\"",
            repo.description, repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void changeRepoLastCommitHash(RepoEntity repo)
        {
            var req = string.Format("UPDATE Repos SET last_commit_hash=\"{0}\" WHERE owner=\"{1}\" AND name=\"{2}\"",
            repo.last_commit_hash, repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public List<FileEntity> getFiles(FileEntity filter, string groupBy = "")
        {
            var whereString = "WHERE ";
            whereString += string.IsNullOrEmpty(filter.repo_name) ? "" : string.Format(" repo_name = \"{0}\" AND ", filter.repo_name);
            whereString += string.IsNullOrEmpty(filter.path) ? "" : string.Format(" path = \"{0}\" AND ", filter.path);
            whereString += string.IsNullOrEmpty(filter.owner) ? "" : string.Format(" owner = \"{0}\" AND ", filter.owner);
            whereString += string.IsNullOrEmpty(filter.hash) ? "" : string.Format(" hash = \"{0}\" AND ", filter.hash);
            whereString += " TRUE ";
            List<FileEntity> matches = new List<FileEntity>();
            string countFilter = "";
            if (!string.IsNullOrEmpty(groupBy))
            {
                whereString += "GROUP BY \"" + groupBy + "\"";
                countFilter = string.Format(",COUNT({0}) as andSoOn", groupBy);
            }
            var r = doSelectRequest(string.Format("SELECT path,hash,repo_name,owner{0} from Files {1}", countFilter, whereString));
            while (r.Read())
            {
                var path = r["path"].ToString();
                FileEntity newFile = new FileEntity
                {
                    path = r["path"].ToString(),
                    hash = r["hash"].ToString(),
                    repo_name = r["repo_name"].ToString(),
                    owner = r["owner"].ToString()
                };
                if (!string.IsNullOrEmpty(groupBy))
                    newFile.andSoOnFiles = Int32.Parse(r["andSoOn"].ToString());
                matches.Add(newFile);
            }
            r.Close();
            return matches;
        }

        public List<RepoEntity> getRepos(RepoEntity filter, string groupBy = "")
        {
            var whereString = "WHERE ";
            whereString += string.IsNullOrEmpty(filter.name) ? "" : string.Format(" name = \"{0}\" AND ", filter.name);
            whereString += string.IsNullOrEmpty(filter.branch) ? "" : string.Format(" branch = \"{0}\" AND ", filter.branch);
            whereString += string.IsNullOrEmpty(filter.description) ? "" : string.Format(" description = \"{0}\" AND ", filter.owner);
            whereString += string.IsNullOrEmpty(filter.owner) ? "" : string.Format(" owner = \"{0}\" AND ", filter.owner);
            whereString += string.IsNullOrEmpty(filter.last_commit_hash) ? "" : string.Format(" last_commit_hash = \"{0}\" AND ", filter.last_commit_hash);
            whereString += (!filter.is_checked) ? "" : string.Format(" is_checked = \"{0}\" AND ", 1);
            whereString += " TRUE ";
            List<RepoEntity> matches = new List<RepoEntity>();
            string countFilter = "";
            if (!string.IsNullOrEmpty(groupBy))
            {
                whereString += "GROUP BY \"" + groupBy + "\"";
                countFilter = string.Format(",COUNT({0}) as andSoOn", groupBy);
            }
            var r = doSelectRequest(string.Format("SELECT name,owner,branch,description,last_commit_hash,is_checked{0} from Repos {1}", countFilter, whereString));
            while (r.Read())
            {
                RepoEntity newFile = new RepoEntity
                {
                    name = r["name"].ToString(),
                    owner = r["owner"].ToString(),
                    branch = r["branch"].ToString(),
                    description = r["description"].ToString(),
                    last_commit_hash = r["last_commit_hash"].ToString(),
                    is_checked = Convert.ToBoolean(r["is_checked"])

                };
                if (!string.IsNullOrEmpty(groupBy))
                    newFile.andSoOnFiles = Int32.Parse(r["andSoOn"].ToString());
                matches.Add(newFile);
            }
            r.Close();
            return matches;
        }

        public List<List<FileEntity>> getMatchesInFiles(bool groupByOwner)
        {
            var matches = new List<List<FileEntity>>();
            var r = doSelectRequest("SELECT hash,COUNT(hash) as matches FROM Files JOIN Repos ON Files.owner = Repos.owner AND Files.repo_name = Repos.name WHERE is_checked=1 GROUP BY hash ORDER by matches DESC");
            while (r.Read())
            {
                FileEntity newFile = new FileEntity
                {
                    hash = r["hash"].ToString()
                };
                int matchesCount = Int32.Parse(r["matches"].ToString());
                var matchesList = getFiles(newFile, groupByOwner ? ("owner") : "");
                if (matchesCount > 1 && (matchesList.Count > 1 || !groupByOwner))
                    matches.Add(matchesList);
                else//because the list sorted in reverse order. It makes no sense to search matches anymore.
                    break;
            }
            r.Close();
            return matches;
        }

        public void addFileInfo(FileEntity ent)
        {
            var req = string.Format("INSERT INTO Files(owner,repo_name, path, hash) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\")",
            ent.owner, ent.repo_name, ent.path, ent.hash);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void addRepoInfo(RepoEntity ent)
        {
            var req = string.Format("INSERT INTO Repos(owner,name,description,branch,last_commit_hash,is_checked) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",1)",
            ent.owner, ent.name, ent.description, ent.branch, ent.last_commit_hash);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void deleteFile(FileEntity ent)
        {
            var req = string.Format("DELETE FROM Files WHERE owner=\"{0}\" AND repo_name =\"{1}\" AND path =\"{2}\"",
            ent.owner, ent.repo_name, ent.path);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void cleanRepo(RepoEntity repo)
        {
            var req = string.Format("DELETE FROM Files WHERE owner=\"{0}\" AND repo_name =\"{1}\"",
            repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }
        public void deleteRepo(RepoEntity repo)
        {
            var req = string.Format("DELETE FROM Repos WHERE owner=\"{0}\" AND name =\"{1}\"", repo.owner, repo.name);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
            cleanRepo(repo);
        }

        public void deleteOwner(string owner)
        {
            var req = string.Format("DELETE FROM Files WHERE owner=\"{0}\"", owner);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
            req = string.Format("DELETE FROM Repos WHERE owner=\"{0}\"", owner);
            m_sqlCmd.CommandText = req;
            m_sqlCmd.ExecuteNonQuery();
        }

        public void close()
        {
            m_dbConn.Close();
        }

    }
}
