using GitApi;
using GitSame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSame
{
    public partial class FilterForm : Form
    {
        public DbManager db;

        public FilterForm(DbManager man)
        {
            InitializeComponent();
            db = man;
            foreach (string item in Setting.getInstance().filters)
                listFiles.Items.Add(item);
        }


        public void addFileButton_Click(object sender, EventArgs e)
        {
            string check = inputFiles.Text;
            check = check.Replace(" ", "");

            if (check.Length > 0)
            {
                string file = inputFiles.Text;
                listFiles.Items.Add(file);

                Setting.getInstance().filters.Add(file);
                inputFiles.Text = "";
                listFiles.Invalidate();

            }
        }

        public void deleteItemButton_Click(object sender, EventArgs e)
        {
            var file = listFiles.SelectedItem;
            listFiles.Items.Remove(file);
            listFiles.Invalidate();
            Setting.getInstance().filters.Remove(file.ToString());
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
    }
}
