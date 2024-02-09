using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using MinimalAPI.DDD.Domain.EntitiesModels;

namespace MinimalAPI.DDD.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {
            
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:srvminimalapi.database.windows.net,1433;Initial Catalog=DbMinimalApi;Persist Security Info=False;User ID=logonminimalapi;Password=151213@2023Ksrl;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=60;"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>().HasKey(p => p.Id);

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200");

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            modelBuilder.Entity<Fornecedor>()
                .ToTable("TB_Fornecedor");

            base.OnModelCreating(modelBuilder);
        }
    }
}
