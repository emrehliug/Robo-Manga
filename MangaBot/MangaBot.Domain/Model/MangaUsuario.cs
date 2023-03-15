using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    public class MangaUsuario
    {
        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
