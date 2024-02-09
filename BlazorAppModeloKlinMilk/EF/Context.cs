using BlazorAppModeloKlinMilk.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppModeloKlinMilk.EF
{
    public class Context : DbContext
    {
        public DbSet<AcessoEntityModel> Acessos { get; set; }
        public DbSet<SnippetEntityModel> Snippets { get; set; }
        public DbSet<TabelasBancoEntityModel> Tabelas { get; set; }
        public DbSet<ParamEntityModel> Params { get; set; }
        public DbSet<EstruturaEntityModel> Estruturas { get; set; }
        public List<ColunasTabelasEntityModel> Colunas { get; set; } = new List<ColunasTabelasEntityModel>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Utilização com Provider SqLite
                //optionsBuilder.UseSqlite("Data Source=C:\\Projetos\\TesteRabbitMQ\\SqLite\\DbProtocolo.db;");

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
            
            modelBuilder.Entity<EstruturaEntityModel>()
                .ToTable("Estrutura");

            modelBuilder
            .Entity<ColunasTabelasEntityModel>()
            .HasNoKey()
            .ToView("ColunasTabelas");

            modelBuilder.Entity<TabelasBancoEntityModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TabelasBanco");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
