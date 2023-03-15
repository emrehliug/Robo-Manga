using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Infra.Repositories.Interfaces
{
    public interface IMangaRepository
    {
        public List<Manga> Buscar();
        public void Atualizar(Manga manga);
    }
}
