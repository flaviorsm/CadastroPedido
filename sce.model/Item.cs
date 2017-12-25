

namespace sce.model
{
    public class Item
    {
        public int Id { get; set; }
        public decimal Quantidade { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}