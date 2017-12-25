using sce.model;
using System.Data.Entity.ModelConfiguration;

namespace sce.entity.mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            HasKey(x => x.Id);

            Property(p => p.CPF).HasMaxLength(11).IsRequired();
            Property(p => p.Nome).IsRequired();
            Property(p => p.CEP).HasMaxLength(8).IsRequired();
            Property(p => p.Endereco).IsRequired();

            HasMany(x => x.Pedidos);
        }
    }
}
