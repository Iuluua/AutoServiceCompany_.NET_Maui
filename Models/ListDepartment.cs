using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MelisaIuliaProiect.Models
{
    public class ListDepartment
    {
        [PrimaryKey, AutoIncrement] 
        public int ID { get; set; }

        [ForeignKey(typeof(Department))] 
        public int DepartmentID { get; set; }

        public int CityID { get; set; }
    }
}
