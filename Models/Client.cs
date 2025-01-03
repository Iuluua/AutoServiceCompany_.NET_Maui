using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MelisaIuliaProiect.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Persoana { get; set; }

        public string Nume { get; set; }

        public string Email { get; set; }

        public string Adresa { get; set; }
    }
}
