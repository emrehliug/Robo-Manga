using MangaBot.Application.Crawler.Interface;
using MangaBot.Application.Services.UsuarioService;
using MangaBot.Application.Services.EnvioMensagem;
using MangaBot.Infra.Repositories;
using MangaBot.Infra.Repositories.Interfaces;
using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaBot.Domain.Crawler;

namespace MangaBot.Application.Services.MangaService
{
    public class MangaService
    {
        private IMangaRepository reposManga = new MangaRepository();
        private ILogRepository reposLog = new LogRepository();
        private UsuarioService.UsuarioService usuario = new UsuarioService.UsuarioService();
        private ICrawler crawler = new CrawlerMangaYabu();
        int numerador = 0;

        private List<Manga> mangas;
        public void Enviar()
        {
            try //tc para regristrar log, status: sucesso e error
            {
                mangas = reposManga.Buscar();
                foreach (Manga manga in mangas)
                {
                    if (!VerificaCapitulo(manga))
                    {
                        reposManga.Atualizar(manga);
                        var usuariosManga = usuario.BuscarUsuarios(manga.MangaId);

                        if (usuariosManga != null)
                        {
                            foreach (Usuario usuario in usuariosManga)
                            {
                                EnviaWhatsService.enviarMensagem(usuario, manga, numerador);
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
                reposLog.InsereLog(new Log() { execucao = "Sucesso", mensagem = "MangaBot rodou o metodo Enviar com exito", dataExecucao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) });
            }
            catch (Exception ex)
            {
                reposLog.InsereLog(new Log() { execucao = "Error", mensagem = ex.Message.ToString(), dataExecucao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) });
            }
            
        }

        #region Metodo de verificacao
        public bool VerificaCapitulo(Manga manga)
        {
            int totalCapitulos = crawler.RaspaTela(manga);
            if(totalCapitulos <= 0)
            {
                reposLog.InsereLog(new Log() { execucao = "Error", mensagem = "O Site mangaYabu esta com problemas e o bot não conseguiu Raspar a tela.", dataExecucao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")) });
                return true;
            }

            if(totalCapitulos >= manga.TotaldeCapitulos + 2)
            {
                numerador = 1;
            }
            else
            {
                numerador = 0;
            }
            if (manga.TotaldeCapitulos == totalCapitulos)
            {
                return true;
            }
            manga.TotaldeCapitulos = totalCapitulos;
            return false;
        }
        #endregion

    }
}
