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


namespace GitSame
{
    
    public partial class FinalForm : Form
    {
        public DbManager db;
        public DataGridView rows;
        
        public FinalForm(DbManager man, List<RepoEntity> repos)
        {
            InitializeComponent();
            db = man;

            dataGridViewFinal.Rows.Clear();
            bool group = !Setting.getInstance().findAutoplagiat;
            var matches1 = db.getMatchesInFiles(group);
            
            foreach (var i in matches1)
            {
                        printFileEntityList(i);
                        dataGridViewFinal.Rows.Add();
            }

            foreach (RepoEntity rep in db.getRepos(new RepoEntity { }))
            db.checkRepo(rep, false);
                
        }


        public void printFileEntity(FileEntity ent, RepoEntity rep)
        {       
                ArrayList row = new ArrayList();

                row.Add(ent.repo_name);
                row.Add(ent.owner);
                row.Add(rep.branch);
                row.Add(ent.path);

                dataGridViewFinal.Rows.Add(row.ToArray());
                dataGridViewFinal.EndEdit();
        }

        public void printFileEntityList(List<FileEntity> ent)
        {
            Console.WriteLine("FileEntityList");
            RepoEntity rep;
            foreach (var i in ent)
            {   
                rep = db.getRepos(new RepoEntity { owner = i.owner, name = i.repo_name })[0];
                printFileEntity(i, rep);
            }
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
                else if (e.ColumnIndex == 3)
                {
                    string owner = dataGridViewFinal[1, e.RowIndex].Value.ToString();
                    string repo_name = dataGridViewFinal[0, e.RowIndex].Value.ToString();
                   string branch = dataGridViewFinal[2, e.RowIndex].Value.ToString();
                    string url3 = '"' + "http://github.com/" + owner + '/' + repo_name + "/blob/" + branch + '/' + dataGridViewFinal[e.ColumnIndex, e.RowIndex].Value.ToString() + '"';
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
