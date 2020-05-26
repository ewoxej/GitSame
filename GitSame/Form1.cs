using GitApi;
using GitSame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace GitSame
{
    public partial class Form1 : Form
    {
        public string appDataPath;
        public string dbPath;
        public DbManager man;

        public Form1()
        {
            InitializeComponent();
            
            appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GitSame");
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);
            dbPath = Path.Combine(appDataPath, "gitsamedb.db");

            man = new DbManager(dbPath);

            var repos = man.getRepos(new RepoEntity { });
            printRepoEntityList(repos);

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


        public void printRepoEntity(RepoEntity ent)
        {
            ArrayList row = new ArrayList();

            row.Add(ent.name);
            row.Add(ent.owner);
            row.Add(ent.branch);
            row.Add("удалить");
            row.Add("обновить");

            dataGridView.Rows.Add(row.ToArray());
            dataGridView.EndEdit();
        }


        public void printRepoEntityList(List<RepoEntity> ent)
        {
            Console.WriteLine("RepoEntityList");
            foreach (var i in ent)
                printRepoEntity(i);
        }


        public void AddNewRepos()
        {
            string repo1 = inputRepos.Text;
            //Manager.setToken("Paste here your GitHub API secret token");
           
            var api1 = Manager.toApiUrl(repo1);
            var rep1 = Manager.doRequest<Repo>(api1);
            var branches = Manager.getBranchesList(rep1);
            
            foreach (var item in branches)
            {
                Console.WriteLine(string.Format("Branch: {0}", item.name));
                if (item.name == "master")
                {
                    var commit = Manager.doRequest<Commit>(item.commit.url);
                    Console.WriteLine(string.Format("Commit: {0}", commit.sha));
                    var tree = Manager.getTree(commit, true);
                    man.addRepoInfo(new RepoEntity { owner = rep1.owner.login, name = rep1.name, branch = item.name, last_commit_hash = item.commit.url });

                    ArrayList row = new ArrayList();

                    row.Add(rep1.name);
                    row.Add(rep1.owner.login);
                    row.Add(item.name);
                    row.Add("удалить");
                    row.Add("обновить");
                    dataGridView.Rows.Add(row.ToArray());
                    dataGridView.EndEdit();
                }
            }
        }
        public void DeleteRow(DataGridViewCellEventArgs e)
        {
            string name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string owner = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            man.deleteRepo(new RepoEntity { owner = owner, name = name });
            dataGridView.Rows.RemoveAt(e.RowIndex);
        }

        public void UpdateRow(DataGridViewCellEventArgs e)
        {
            string name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string owner = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            
            man.deleteFile(new FileEntity { owner = owner, repo_name = name });
            List<RepoEntity> repos = man.getRepos(new RepoEntity { owner = owner, name = name });
            addFiles(repos);
            dataGridView.Rows[e.RowIndex].Cells["updateRepos"].Value = "обновлено";
            
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
                if (e.ColumnIndex == 0 )
                {
                    string url1 = '"' + "http://github.com/" + dataGridView[1, e.RowIndex].Value.ToString() + '/' + dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() + '"';
                    System.Diagnostics.Process.Start(url1);
                }
                else if (e.ColumnIndex == 1)
                {
                    string url2 = '"' + "http://github.com/" + dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() + '/' + '"';
                    System.Diagnostics.Process.Start(url2);
                }
                
            }
            else if (IsDeleteButtonCell(e))
            {
                DeleteRow(e);
            }
            else if (IsUpdateButtonCell(e))
            {
                UpdateRow(e);
            }
        }
        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            {
                return true;
            }
            else { return false; }
        }

        private bool IsDeleteButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1 &&
                dataGridView.Columns[cellEvent.ColumnIndex].Name == "deleteRepos")
            { return true; }
            else { return (false); }
        }

        private bool IsUpdateButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1 &&
                dataGridView.Columns[cellEvent.ColumnIndex].Name == "updateRepos")
            { return true; }
            else { return (false); }
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[5].Selected)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView.Rows[e.RowIndex].Cells[5];
                if (chk.Value == null || (bool)chk.Value == false)
                {
                    chk.Value = true;
                }
                else
                {
                    chk.Value = false;
                }
            }
            dataGridView.EndEdit();
        }

        private void addRepos_Click(object sender, EventArgs e)
        {
            AddNewRepos();
        }
        
        public void filterButton_Click(object sender, EventArgs e)
        {
            Form filterForm = new FilterForm(man);
            filterForm.Show();
        }

        string reponame;
        string repoowner;
        List<RepoEntity> repos = new List<RepoEntity>();
        private void checkButton_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                reponame = row.Cells["address"].Value.ToString();
                repoowner = row.Cells["author"].Value.ToString();
                RepoEntity checkrepo = man.getRepos(new RepoEntity { name = reponame, owner = repoowner })[0];
                if (row.Cells[5].Value == null)
                {
                man.checkRepo(checkrepo, false);
                    continue;
                } 
                man.checkRepo(checkrepo, Convert.ToBoolean(row.Cells[5].Value));
            }

            repos = man.getRepos(new RepoEntity { is_checked = true });

            addFiles(repos);
            List<FileEntity> file;
            file = man.getFiles(new FileEntity { });

            foreach (FileEntity item in file)
                if (Setting.getInstance().isInFilters(item.path) == true)
                    man.deleteFile(item);

            FinalForm finalForm = new FinalForm(man);
            finalForm.Show();
        }

     
        public void addFiles(List<RepoEntity> repoEntities)
        {
            foreach (RepoEntity i in repoEntities)
            {
                if (i.last_commit_hash == "")
                { continue; }
                string repo1 = "https://github.com/" + i.owner + '/' + i.name;
                //Manager.setToken("Paste here your GitHub API secret token");

                var api1 = Manager.toApiUrl(repo1);                             
                var rep1 = Manager.doRequest<Repo>(api1);
                var branches = Manager.getBranchesList(rep1);
                
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
                                
                                try
                                {
                                man.addFileInfo(new FileEntity { owner = rep1.owner.login, repo_name = rep1.name, path = treeItem.path, hash = hash });

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.WriteLine(string.Format("File: {0}, hash: {1} ", treeItem.path, hash));
                                Console.WriteLine(string.Format("{0} requests left ", Manager.limitRemain));
                            }
                        }
                        i.last_commit_hash = commit.sha;
                        man.changeRepoLastCommitHash(i);
                    }
                }


            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked == true)
            {
                DataGridViewCheckBoxCell chk;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    chk = (DataGridViewCheckBoxCell)row.Cells[5];
                    chk.Value = true;
                }
                dataGridView.EndEdit();
            }
            else if (checkAll.Checked == false)
            {
                DataGridViewCheckBoxCell chk;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    chk = (DataGridViewCheckBoxCell)row.Cells[5];
                    chk.Value = false;
                }
                dataGridView.EndEdit();
            }
        }

        private void autoplagiatCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoplagiatCheck.Checked == true)
                Setting.getInstance().findAutoplagiat = true; 
            else if (autoplagiatCheck.Checked == false)
                 Setting.getInstance().findAutoplagiat = false; 
        }
    }

}

