using sce.model.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sce.model;
using sce.entity;
using System.Data.Entity;

namespace Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        DataContext context = new DataContext();

        public void Adicionar(Pedido entity)
        {
            context.Pedidos.Add(entity);
            context.SaveChanges();
        }

        public void Editar(Pedido entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Pedido> ObterListaPedido()
        {
            return context.Pedido;
        }

        public Pedido ObterListaPorId(int id)
        {
            return (from p in context.Pedido where p.PedidoID == id select p).FirstOrDefault();
        }

        public void Remover(int id)
        {
            var pedido = context.Pedido.Find(id);
            context.Pedido.Remove(pedido);
            context.SaveChanges();
        }
    }
}
