using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sce.model
{
    public class Cliente
    {
        public Cliente()
        {
            this.Pedidos = new List<Pedido>();
        }
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
