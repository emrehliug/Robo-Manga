using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    [Table("tbMangaUsuario")]
    public class MangaUsuario
    {
        public int MangaId { get; set; }
        public virtual Manga Manga { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
