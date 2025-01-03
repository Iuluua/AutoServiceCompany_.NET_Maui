using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MelisaIuliaProiect.Models
{
    public class Department
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(250), Unique] 
        public string Description { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
