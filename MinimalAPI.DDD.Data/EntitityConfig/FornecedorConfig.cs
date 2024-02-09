using MetodoKlinMilk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalAPI.DDD.Domain.EntitityConfig
{
    internal class AcessoConfig : IEntityTypeConfiguration<AcessoEntityModel>
    {
        public void Configure(EntityTypeBuilder<AcessoEntityModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
