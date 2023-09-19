using SQLite;
using MauiSQLite.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Services
{
    public class AgendaService : IAgendaService
    {
        private SQLiteAsyncConnection _dbConnection;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb()
        {
            if(_dbConnection== null)
            {
                string dbPath = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agenda.db3");

                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ModelContato>();

            }
        }
        public async Task<int> AddContato(ModelContato modelContato)
        {
            return await _dbConnection.InsertAsync(modelContato);
        }
        public async Task<int> DeleteContato(ModelContato modelContato)
        {
            return await _dbConnection.DeleteAsync(modelContato);
        }
        public async Task<int> UpdateContato(ModelContato modelContato)
        {
            return await _dbConnection.UpdateAsync(modelContato);
        }
        public async Task<List<ModelContato>> GetContatos()
        {
            return await _dbConnection.Table<ModelContato>().ToListAsync();
        }
        public async Task<ModelContato> GetContato(int id)
        {
            return await _dbConnection.Table<ModelContato>().FirstOrDefaultAsync(x=>x.Id==id);
        }       
    }
}
