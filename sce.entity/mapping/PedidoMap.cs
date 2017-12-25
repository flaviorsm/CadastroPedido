using sce.model;
using System.Data.Entity.ModelConfiguration;

namespace sce.entity.mapping
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            //Nome da tabela
            ToTable("Pedido");

            //Chave primária
            HasKey(p => p.Id);
            
            Property(p => p.DataPedido).HasColumnType("datetime").IsRequired();

            HasMany(p => p.Itens);
        }
    }
}
