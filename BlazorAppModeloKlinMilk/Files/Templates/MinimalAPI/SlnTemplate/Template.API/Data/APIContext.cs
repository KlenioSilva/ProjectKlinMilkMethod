using $mapinamespace$.$FolderModels$;
using Microsoft.EntityFrameworkCore;

namespace $mapinamespace$.$FolderData$
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<$Entity$> $PluralEntity$ { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("$DbConnectionName$");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity <$Entity$> ().HasKey(p => p.Id);

            modelBuilder.Entity <$Entity$> ()
                .ToTable("$Tabela$");

            base.OnModelCreating(modelBuilder);
        }
    }
}