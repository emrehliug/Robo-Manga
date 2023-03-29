using MangaBot.Application.Crawler.Interface;
using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaBot.Domain.Crawler;
using MangaBot.Domain.Interfaces.Services;
using MangaBot.Domain.Interfaces.Repository;

namespace MangaBot.Domain.Services
{
    public class MangaService : IMangaService
    {
        private readonly IUnitOfWork uow;
        private readonly ICrawler crawlerManga;
        private readonly ILogService logService;
        int numerador = 0;

        public MangaService(IUnitOfWork _uow, ICrawler _crawlerManga, ILogService _logService)
        {
            uow = _uow;
            crawlerManga = _crawlerManga;
            logService = _logService;
        }

        public List<Manga> GetAllMangas()
        {
            return uow.MangaRepository.GetAll().ToList();
        }
        public void Atualizar(Manga manga)
        {
            uow.MangaRepository.Update(manga);
        }

        public bool VerificaCapitulo(Manga manga)
        {
            int totalCapitulos = crawlerManga.RaspaTela(manga);
            if (totalCapitulos <= 0)
            {
                logService.InsereLog(new Log() { execucao = $"Error no Manga: {manga.Nome}", mensagem = $"O Site manga livre esta com problemas e o bot não conseguiu Raspar a tela para o manga: {manga.MangaId}.", dataExecucao = DateTime.Parse(DateTime.Now.ToString()) });
                return true;
            }

            if (manga.TotaldeCapitulos == totalCapitulos)
            {
                return true;
            }
            manga.TotaldeCapitulos = totalCapitulos;
            return false;
        }
    }
}
