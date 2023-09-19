using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.MVVM.Models
{
    [Table("Contatos")]
    public class ModelContato
    {
        private int _id;
        private string _nome;
        private string _email;
        
        [PrimaryKey, AutoIncrement]
        public int Id { get => _id; set => _id = value; }
        [MaxLength(100),NotNull]
        public string Nome { get => _nome; set => _nome = value; }
        [MaxLength(200),NotNull]
        public string Email { get => _email; set => _email = value; }
    }
}
