using sce.model;
using System.Data.Entity.ModelConfiguration;

namespace sce.entity.mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            //Nome da tabela
            ToTable("Produto");

            //Chave primária
            HasKey(p => p.Id);

            //Descrição será no maximo 150 caracteres e not null
            Property(p => p.Descricao).HasMaxLength(150).IsRequired();

            //Definindo tipo da coluna 
            Property(p => p.Preco).HasColumnType("Money").IsRequired();

            HasMany(p => p.Itens);

        }
    }
}
