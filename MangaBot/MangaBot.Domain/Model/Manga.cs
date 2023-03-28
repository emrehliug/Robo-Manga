using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaBot.Domain.Model
{
    [Table("tbManga")]
    public class Manga
    {
        [Key]
        public int MangaId { get; set; }

        public string Nome { get; set; }

        public int TotaldeCapitulos { get; set; }

        public int codigoManga { get; set; }

        public virtual ICollection<MangaUsuario> UsuariosDoManga { get; set; }
    }
}
