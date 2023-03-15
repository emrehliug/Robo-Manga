using System.ComponentModel.DataAnnotations;

namespace MangaBot.Domain.Model
{
    public class Manga
    {
        [Key]
        public int MangaId { get; set; }

        public string Nome { get; set; }

        public int TotaldeCapitulos { get; set; }
    }
}
