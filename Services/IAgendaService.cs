using MauiSQLite.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Services
{
    public interface IAgendaService
    {
        Task InitializeAsync();
        Task<List<ModelContato>> GetContatos();
        Task<ModelContato> GetContato(int contatoId);
        Task<int> AddContato(ModelContato contato);
        Task<int> UpdateContato(ModelContato contato);
        Task<int> DeleteContato(ModelContato contato);
    }
}
