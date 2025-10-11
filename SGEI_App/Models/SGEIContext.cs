using System.Data.Entity;
using SGEI_App.Models;

namespace SGEI_App.Models
{
    public  class SGEIContext : DbContext //Herda de DbContext
    {
        //Construtor que chama o construtor da classe base (DbContext) com a string de conexão
        public SGEIContext() : base("name=SGEIConnection")
        {
        }
        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Produtos> PRODUTOS { get; set; }
    }
}