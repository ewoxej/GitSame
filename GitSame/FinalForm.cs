using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using GitApi; 

namespace GitSame
{
    
    public partial class FinalForm : Form
    {
        public DbManager db;
        public DataGridView rows;
        public List<RepoEntity> repos;
        public FinalForm(DbManager man)
        {
            InitializeComponent();
            db = man;


            //var files = db.getFiles(new FileEntity { });
            //printFileEntityList(files);
            dataGridViewFinal.Rows.Clear();
            bool group = !Setting.getInstance().findAutoplagiat;
            var matches1 = db.getMatchesInFiles(group);
            Console.WriteLine("Matches 1, do not group by owner");
            foreach (var i in matches1)
            {
                
                        printFileEntityList(i);
                        dataGridViewFinal.Rows.Add();
                   

                    //dataGridViewFinal.Rows[rowNumber].Cells["description"].Value = " "; 
             
                //var reps = db.getRepos(new RepoEntity { });
                // //printRepoEntityList(repos);
                // foreach (RepoEntity item in reps)
                // { db.cleanRepo(item); }



            }
        }

        
        public void printRepoEntity(RepoEntity ent)
        {

            ArrayList row = new ArrayList();

            row.Add(ent.name);
            row.Add(ent.owner);
            row.Add(ent.branch);
            
            dataGridViewFinal.Rows.Add(row.ToArray());
            dataGridViewFinal.EndEdit();
        }

        public void printRepoEntityList(List<RepoEntity> ent)
        {
            Console.WriteLine("RepoEntityList");
            foreach (var i in ent)
                printRepoEntity(i);
        }

        public void printFileEntity(FileEntity ent)
        {
            Console.WriteLine("-FileEntity");
            Console.WriteLine("--owner: {0}", ent.owner);
            Console.WriteLine("--repo_name: {0}", ent.repo_name);
            Console.WriteLine("--path: {0}", ent.path);
            Console.WriteLine("--hash: {0}", ent.hash);
            Console.WriteLine("--andSoOnFiles: {0}", ent.andSoOnFiles);

            
                ArrayList row = new ArrayList();

                row.Add(ent.repo_name);
                row.Add(ent.owner);
                row.Add(ent.path);

                dataGridViewFinal.Rows.Add(row.ToArray());
                dataGridViewFinal.EndEdit();
           
            
        }

        public void printFileEntityList(List<FileEntity> ent)
        {
            Console.WriteLine("FileEntityList");
            foreach (var i in ent)
                printFileEntity(i);
        }

        private void dataGridViewFinal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
                if (e.ColumnIndex == 0)
                {
                    string url1 = '"' + "http://github.com/" + dataGridViewFinal[1, e.RowIndex].Value.ToString() + '/' + dataGridViewFinal[e.ColumnIndex, e.RowIndex].Value.ToString() + '"';
                    System.Diagnostics.Process.Start(url1);
                }
                else if (e.ColumnIndex == 1)
                {
                    string url2 = '"' + "http://github.com/" + dataGridViewFinal[e.ColumnIndex, e.RowIndex].Value.ToString() + '/' + '"';
                    System.Diagnostics.Process.Start(url2);
                }
                else if (e.ColumnIndex == 2)
                {
                    string url3 = '"' + "http://github.com/" + dataGridViewFinal[1, e.RowIndex].Value.ToString() + '/' + dataGridViewFinal[e.ColumnIndex, e.RowIndex].Value.ToString() + '/' + '"';
                    System.Diagnostics.Process.Start(url3);
                }

            }
            
        }

        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridViewFinal.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            {
                return true;
            }
            else { return false; }
        }
    }
}
