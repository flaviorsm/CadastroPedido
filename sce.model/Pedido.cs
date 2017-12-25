using System;
using System.Collections.Generic;

namespace sce.model
{
    public class Pedido
    {
        public Pedido()
        {
            this.Itens = new List<Item>();
        }
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }   
        public decimal ValorPedido { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Item> Itens { get; set; }
    }
}
