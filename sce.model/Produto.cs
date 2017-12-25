using System.Collections.Generic;

namespace sce.model
{
    public class Produto
    {
        public Produto()
        {
            this.Itens = new List<Item>();
        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public ICollection<Item> Itens { get; set; }
    }
}
