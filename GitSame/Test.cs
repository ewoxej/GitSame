using GitApi;
using GitSame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GitSame
{
    class Test
    {   
        private string appDataPath;
        public Test()
        {
            appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GitSame");
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public void printFileEntity(FileEntity ent)
        {
            Console.WriteLine("-FileEntity");
            Console.WriteLine("--owner: {0}", ent.owner);
            Console.WriteLine("--repo_name: {0}", ent.repo_name);
            Console.WriteLine("--path: {0}", ent.path);
            Console.WriteLine("--hash: {0}", ent.hash);
            Console.WriteLine("--andSoOnFiles: {0}", ent.andSoOnFiles);
        }

        public void printFileEntityList(List<FileEntity> ent)
        {
            Console.WriteLine("FileEntityList");
            foreach (var i in ent)
                printFileEntity(i);
        }
        public void printRepoEntity(RepoEntity ent)
        {
            Console.WriteLine("-RepoEntity");
            Console.WriteLine("--owner: {0}", ent.owner);
            Console.WriteLine("--name: {0}", ent.name);
            Console.WriteLine("--description: {0}", ent.name);
            Console.WriteLine("--branch: {0}", ent.branch);
            Console.WriteLine("--last_commit_hash: {0}", ent.last_commit_hash);
            Console.WriteLine("--andSoOnFiles: {0}", ent.andSoOnFiles);
        }

        public void printRepoEntityList(List<RepoEntity> ent)
        {
            Console.WriteLine("RepoEntityList");
            foreach (var i in ent)
                printRepoEntity(i);
        }
        public void dbTest()
        {
            var dbPath = Path.Combine(appDataPath, "gitsamedb.db");
            DbManager man = new DbManager(dbPath);
            man.addRepoInfo(new RepoEntity { owner = "ewoxej", name = "eworepo1", branch = "master", last_commit_hash = "123" });
            man.addRepoInfo(new RepoEntity { owner = "ewoxej", name = "eworepo2", branch = "master", last_commit_hash = "123" });
            man.addRepoInfo(new RepoEntity
            {
                owner = "ewoxej",
                name = "eworepo3",
                branch = "master",
                last_commit_hash = "123"
            });
            man.addRepoInfo(new RepoEntity
            {
                owner = "vetrokot",
                name = "vetrorepo1",
                branch = "master",
                last_commit_hash = "123"
            });
            man.addRepoInfo(new RepoEntity
            {
                owner = "vetrokot",
                name = "vetrorepo2",
                branch = "master",
                last_commit_hash = "123"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "ewoxej",
                repo_name = "eworepo1",
                path = "root/smth",
                hash = "eeeee"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "ewoxej",
                repo_name = "eworepo2",
                path = "root",
                hash = "eeeee"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "ewoxej",
                repo_name = "eworepo3",
                path = "rootw",
                hash = "eee4r"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "ewoxej",
                repo_name = "eworepo2",
                path = "rootw",
                hash = "eee4r"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "vetrokot",
                repo_name = "vetrorepo1",
                path = "rootw",
                hash = "eeeee"
            });
            man.addFileInfo(new FileEntity
            {
                owner = "vetrokot",
                repo_name = "vetrorepo1",
                path = "rootws",
                hash = "eeeee2"
            });

           
            
           

            var files = man.getFiles(new FileEntity {owner="vetrokot"});//get files where ownere = vetrokot
            printFileEntityList(files);
            man.changeFileHash(new FileEntity { owner = "ewoxej", repo_name = "eworepo2", hash = "f32ff" });
            var matches1 = man.getMatchesInFiles(false);
            Console.WriteLine("Matches 1, do not group by owner");
            foreach(var i in matches1)
            {
                printFileEntityList(i);
            }
            var matches2 = man.getMatchesInFiles(true);
            Console.WriteLine("Matches 2, group by owner");
            foreach (var i in matches2)
            {
                printFileEntityList(i);
            }
            man.changeRepoDescription(new RepoEntity { owner = "ewoxej", name = "eworepo1", description = "testrepo" });
            man.changeRepoBranch(new RepoEntity { owner = "ewoxej", name = "eworepo1", branch="develop" });
            man.changeRepoLastCommitHash(new RepoEntity { owner = "ewoxej", name = "eworepo1", last_commit_hash="dwd2d3" });
            var repos = man.getRepos(new RepoEntity { owner = "ewoxej" });
            printRepoEntityList(repos);
            man.deleteFile(new FileEntity { owner = "ewoxej", repo_name = "eworepo1", path = "root/smth" });
            man.deleteFile(new FileEntity { owner = "ewoxej", repo_name = "eworepo1", path = "non-existing file" });
            man.deleteRepo(new RepoEntity { owner = "ewoxej", name = "eworepo1" });
            man.deleteOwner("vetrokot");
            var file = man.getFiles(new FileEntity());
            printFileEntityList(file);
            man.close();
            File.Delete(dbPath);
        }

        public void gitApiTest()
        {
            string repo1 = "https://github.com/ewoxej/ewoxej.github.io";
            //Manager.setToken("Paste here your GitHub API secret token");
            Console.WriteLine(string.Format("Repository address: {0}", repo1));
            var api1 = Manager.toApiUrl(repo1);//convert github url to api url
            Console.WriteLine(string.Format("Repository address for API: {0}", api1));
            var rep1 = Manager.doRequest<Repo>(api1);
            var branches = Manager.getBranchesList(rep1);
            Console.WriteLine(string.Format("Found {0} branches", branches.Count));
            foreach (var item in branches)
            {
                Console.WriteLine(string.Format("Branch: {0}", item.name));
                if (item.name == "master")
                {
                    var commit = Manager.doRequest<Commit>(item.commit.url);
                    Console.WriteLine(string.Format("Commit: {0}", commit.sha));
                    var tree = Manager.getTree(commit, true);
                    Console.WriteLine(string.Format("Found {0} elements in tree", tree.tree.Count));
                    foreach (var treeItem in tree.tree)
                    {
                        if (treeItem.type == "blob")
                        {
                            var element = Manager.getBlob(treeItem);
                            var hash = sha256_hash(element.content);
                            Console.WriteLine(string.Format("File: {0}, hash: {1} ", treeItem.path, hash));
                            Console.WriteLine(string.Format("{0} requests left ", Manager.limitRemain));
                        }
                    }
                }
            }
        }
    }
}
