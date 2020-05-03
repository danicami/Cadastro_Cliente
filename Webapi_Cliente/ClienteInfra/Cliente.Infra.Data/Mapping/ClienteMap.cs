using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webapi_Cliente.Domain.Entities;

namespace Webapi_Cliente.Infra.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnName("Endereco");

            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnName("Cidade");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnName("Bairro");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnName("Cep");

            builder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnName("Estado");

        }
        

    }
}
