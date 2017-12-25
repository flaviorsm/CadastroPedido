using sce.model;
using System.Data.Entity.ModelConfiguration;

namespace sce.entity.mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            //Tabela
            ToTable("Item");
            //Chave primária
            HasKey(i => i.Id);

            Property(i => i.Quantidade).IsRequired();

            //Produto é obrigatório no item do pedido
            HasRequired(i => i.Produto)
                .WithMany() //Produto pode conter em vários itens 
                .Map(m => m.MapKey("ProdutoID"));

            //1:N - 1 ItemPedido contém 1 Pedido e 1 Pedido pode ter muitos Itens de pedido
            HasRequired(i => i.Pedido)
                .WithMany() //Pedido tem uma lista de itens
                .Map(m => m.MapKey("PedidoID"));
        }
    }
}
