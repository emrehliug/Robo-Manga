using MangaBot.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace MangaBot.Infra.DataContext
{
    public class MangaBotContext : DbContext
    {
        public MangaBotContext(DbContextOptions<MangaBotContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MangaUsuario>().HasKey(sc => new { sc.UsuarioId, sc.MangaId });
        }               

        public DbSet<Manga> tbManga { get; set; }
        public DbSet<Usuario> tbUsuario { get; set; }
        public DbSet<MangaUsuario> tbMangaUsuario { get; set; }
        public DbSet<Log> tbLog { get; set; }
    }
}
