using MangaBot.Application.Crawler.Interface;
using MangaBot.Domain.Crawler;
using MangaBot.Domain.Interfaces.Services;
using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Services
{
    public class EnviarService : IEnviarService
    {
        private readonly IMangaService _mangaService;
        private readonly ILogService _logService;
        private readonly IWhatsZapService _whatsZapService;
        private List<Manga> mangas;

        public EnviarService(IMangaService mangaService, ILogService logService, IWhatsZapService whatsZapService)
        {
            _mangaService = mangaService;
            _logService = logService;
            _whatsZapService = whatsZapService;
        }

        public void Enviar()
        {
            try //tc para regristrar log, status: sucesso e error
            {
                mangas = _mangaService.GetAllMangas();

                foreach (Manga manga in mangas)
                {
                    if (!_mangaService.VerificaCapitulo(manga))
                    {
                        _mangaService.Atualizar(manga); 

                        if (manga.UsuariosDoManga != null)
                        {
                            foreach (MangaUsuario usuario in manga.UsuariosDoManga)
                            {
                                _whatsZapService.enviarMensagem(usuario.Usuario, manga);
                            }
                            Console.WriteLine($"Mensagens enviadas com sucesso para usuarios do manga: {manga.Nome.ToUpper()}!\n");
                        }
                        else
                        {
                            Console.WriteLine($"Manga: {manga.Nome.ToUpper()} atualizado com sucesso, porem nenhuma mensagem enviada porque não existe usuario para esse manga.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"O Manga:{manga.Nome.ToUpper()} não teve alteração nos capitulos! Não sera necessario o envio de mensagens.\n");
                    }
                }
                _logService.InsereLog(new Log() { execucao = "Sucesso", mensagem = "MangaBot rodou o metodo Enviar com exito", dataExecucao = DateTime.Parse(DateTime.Now.ToString()) });
            }
            catch (Exception ex)
            {
                _logService.InsereLog(new Log() { execucao = "Error", mensagem = ex.Message.ToString(), dataExecucao = DateTime.Parse(DateTime.Now.ToString()) });
            }

        }
    }
}
