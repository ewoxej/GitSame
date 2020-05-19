using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addRepos_Click(object sender, EventArgs e)
        {

            updateDataGrid();
        }

        public void updateDataGrid()
        {
            //ADD COLUMNS 
           
            //ADD ROWS
            ArrayList row = new ArrayList();
            row.Add("https://github.com/ewoxej/GitSame");
            row.Add("https://github.com/ewoxej");
            row.Add("description");
            row.Add("удалить");
            row.Add("обновить");
            
            dataGridView.Rows.Add(row.ToArray());
         
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsANonHeaderLinkCell(e))
            {
                string url = '"' + dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() + '"';
                System.Diagnostics.Process.Start(url); 
            }
            else if (IsDeleteButtonCell(e))
            {
                
            }
            
        }
        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView.Columns[cellEvent.ColumnIndex] is
                DataGridViewLinkColumn &&
                cellEvent.RowIndex != -1)
            {  
                return true; }
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
    }
}
