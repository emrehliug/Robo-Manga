using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Interfaces.Services
{
    public interface IMangaService
    {
        List<Manga> GetAllMangas();
        void Atualizar(Manga manga);
        bool VerificaCapitulo(Manga manga);
    }
}
