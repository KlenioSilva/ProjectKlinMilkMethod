using MetodoKlinMilk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetodoKlinMilk.Data
{
    public class Context : DbContext
    {
        public DbSet<AcessoEntityModel> Acessos { get; set; }
        public DbSet<SnippetEntityModel> Snippets { get; set; }
        public DbSet<TabelasBancoEntityModel> Tabelas { get; set; }
        public DbSet<ColunasTabelasEntityModel> Colunas { get; set; }
        public DbSet<EstruturaEntityModel> Estruturas { get; set; }
        public DbSet<ParamEntityModel> Params { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Utilização com Provider SqlServer
                optionsBuilder.UseSqlServer("Server=tcp:svdklinmilkfastdev.database.windows.net,1433;Initial Catalog=DbKMilkFastDev;Persist Security Info=False;User ID=KlinMilkFastDev;Password=022711@2024Gmc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcessoEntityModel>()
                .ToTable("Acesso");

            modelBuilder.Entity<SnippetEntityModel>()
                .ToTable("Snippet");

            modelBuilder.Entity<ParamEntityModel>()
                .ToTable("Param");

            modelBuilder.Entity<ColunasTabelasEntityModel>()
            .ToTable("ColunasTabelas");

            modelBuilder.Entity<TabelasBancoEntityModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TabelasBanco");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
