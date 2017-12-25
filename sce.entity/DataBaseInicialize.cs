using sce.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sce.entity
{
    public class DataBaseInicialize : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Produtos.Add(
                new model.Produto
                {                    
                    Descricao = "Produto 1",
                    Preco = 250
                });

            context.Produtos.Add(
                new model.Produto
                {
                    Descricao = "Produto 2",
                    Preco = 300
                });

            context.Produtos.Add(
                new model.Produto
                {
                    Descricao = "Produto 3",
                    Preco = 350
                });

            

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
