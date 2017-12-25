using sce.entity.mapping;
using sce.model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace sce.entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbPedido")
        {
            Database.SetInitializer<DataContext>(new DataBaseInicialize());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}