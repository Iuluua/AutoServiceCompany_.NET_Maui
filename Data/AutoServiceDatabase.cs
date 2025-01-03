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
            _database.CreateTableAsync<City>().Wait(); 
            _database.CreateTableAsync<ListDepartment>().Wait();
            _database.CreateTableAsync<Client>().Wait();
        }

        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }
        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }

        public Task<List<Client>> GetClientAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientAsync(int id)
        {
            return _database.Table<Client>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCityAsync(City city)
        {
            if (city.ID != 0)
            {
                return _database.UpdateAsync(city);
            }
            else
            {
                return _database.InsertAsync(city);
            }
        }
        public Task<int> DeleteCityAsync(City city)
        {
            return _database.DeleteAsync(city);
        }

        public Task<List<City>> GetCityAsync()
        {
            return _database.Table<City>().ToListAsync();
        }

        public Task<City> GetCityAsync(int id)
        {
            return _database.Table<City>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
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

        public async Task<int> GetClientsCountAsync()
        {
            var clients = await _database.Table<Client>().ToListAsync();
            return clients.Count;
        }

        public async Task<int> GetCitiesCountAsync()
        {
            var cities = await _database.Table<City>().ToListAsync();
            return cities.Count;
        }

        public async Task<int> GetDepartmentsCountAsync()
        {
            var departments = await _database.Table<Department>().ToListAsync();
            return departments.Count;
        }

        public Task SaveListDepartmentAsync(ListDepartment listDepartment)
        {
            return _database.InsertAsync(listDepartment);
        }

        public async Task<List<ListDepartment>> GetListDepartmentAsync(int departmentId, int cityId)
        {
            return await _database.Table<ListDepartment>()
                .Where(ld => ld.DepartmentID == departmentId && ld.CityID == cityId)
                .ToListAsync();
        }

        public Task DeleteListDepartmentAsync(ListDepartment listDepartment)
        {
            return _database.DeleteAsync(listDepartment);
        }

        public async Task<List<Department>> GetDepartmentsByCityAsync(int cityId)
        {
            var listDepartments = await _database.Table<ListDepartment>()
                                                 .Where(ld => ld.CityID == cityId)
                                                 .ToListAsync();

            var departmentIds = listDepartments.Select(ld => ld.DepartmentID).ToList();

            var departments = await _database.Table<Department>()
                                             .Where(dep => departmentIds.Contains(dep.ID))
                                             .ToListAsync();

            return departments;
        }


    }
}
