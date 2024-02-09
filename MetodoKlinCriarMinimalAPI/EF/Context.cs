using MetodoKlinCriarMinimalAPI.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MetodoKlinCriarMinimalAPI.EF
{
    public class Context : DbContext
    {
        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<TabelasBanco> Tabelas { get; set; }
        public DbSet<Param> Params { get; set; }
        public List<ColunasTabelas> Colunas { get; set; } = new List<ColunasTabelas>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:svdklinmilkfastdev.database.windows.net,1433;Initial Catalog=DbKMilkFastDev;Persist Security Info=False;User ID=KlinMilkFastDev;Password=022711@2024Gmc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acesso>()
                .ToTable("Acesso");

            modelBuilder.Entity<Snippet>()
                .ToTable("Snippet");

            modelBuilder.Entity<Param>()
                .ToTable("Param");

            modelBuilder
            .Entity<ColunasTabelas>()
            .HasNoKey()
            .ToView("ColunasTabelas");

            modelBuilder.Entity<TabelasBanco>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("TabelasBanco");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
