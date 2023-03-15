using MangaBot.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace MangaBot.Infra.DataContext
{
    public class MangaBotContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                @"Server=186.202.152.149;Database=photobreak3;Uid=Username;Pwd=password;Persist Security Info=True;sslmode=None",
                ServerVersion.AutoDetect(@"Server=186.202.152.149;Database=photobreak3;Uid=Username;Pwd=Password;Persist Security Info=True;sslmode=None")
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MangaUsuario>(builder =>
            {
                builder.ToTable("tbMangaUsuario");
                builder.HasKey(sc => new { sc.UsuarioId, sc.MangaId });
            });
        }

        public DbSet<Manga> tbManga { get; set; }
        public DbSet<Usuario> tbUsuario { get; set; }
        public DbSet<MangaUsuario> tbMangaUsuario { get; set; }
        public DbSet<Log> tbLog { get; set; }
    }
}
