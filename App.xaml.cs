using System;
using MelisaIuliaProiect.Data;
using System.IO;

namespace MelisaIuliaProiect
{
    public partial class App : Application
    {
        static AutoServiceDatabase database;

        public static AutoServiceDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   AutoServiceDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "AutoService.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
