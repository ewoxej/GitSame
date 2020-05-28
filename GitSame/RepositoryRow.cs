using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitSame
{
    public class RepositoryRow
    {
        public string Repository{ get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public string Delete = "удалить";
        
        public string Update = "обновить";
        public bool Check { get; set; }

        public RepositoryRow(string repository, string author, string description, bool check = false) 
        {
            Repository = repository;
            Author = author;
            Description = description;
            Delete = "удалить";
            Update = "обновить";
            
        }
    }
}
