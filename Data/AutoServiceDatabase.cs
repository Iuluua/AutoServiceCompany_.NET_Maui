using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelisaIuliaProiect.Models;
//using Windows.Media.Protection.PlayReady;

namespace MelisaIuliaProiect.Data
{
    public class AutoServiceDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AutoServiceDatabase(string dbPath) 
        { 
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<Department>().Wait(); 
        }

        public Task<List<Department>> GetDepartmentAsync()
        {
            return _database.Table<Department>().ToListAsync();
        }

        public Task<Department> GetDepartmentAsync(int id)
        {
            return _database.Table<Department>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveDepartmentAsync(Department slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }

        public Task<int> DeleteDepartmentAsync(Department slist)
        {
            return _database.DeleteAsync(slist);
        }

        //public async Task<int> GetClientsCountAsync()
        //{
        //    var clients = await Database.Table<Client>().ToListAsync();
        //    return clients.Count;
        //}

        //public async Task<int> GetCitiesCountAsync()
        //{
        //    var cities = await Database.Table<City>().ToListAsync();
        //    return cities.Count;
        //}

        public async Task<int> GetDepartmentsCountAsync()
        {
            var departments = await _database.Table<Department>().ToListAsync();
            return departments.Count;
        }

    }
}
