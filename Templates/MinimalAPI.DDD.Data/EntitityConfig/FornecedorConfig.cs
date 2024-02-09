using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalAPI.DDD.Domain.EntitiesModels;

namespace MinimalAPI.DDD.Domain.EntitityConfig
{
    internal class FornecedorConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("NVARCHAR(200)");

        }
    }
}
