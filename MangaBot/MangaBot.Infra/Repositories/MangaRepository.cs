using MangaBot.Domain.Model;
using MangaBot.Infra.DataContext;
using MangaBot.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Infra.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private MangaBotContext context;

        public List<Manga> Buscar()
        {
            try
            {
                using (context = new MangaBotContext())
                {
                    return context.tbManga.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar buscar os mangas no BD, erro:" + ex.Message);
                return null;
            }
        }
        public void Atualizar(Manga manga)
        {
            try
            {
                using (context = new MangaBotContext())
                {
                    context.tbManga.Update(manga);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar atualizar o manga no BD, erro:" + ex.Message);
            }
        }
    }
}
