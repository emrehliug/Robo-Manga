using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MangaBot.Domain.Interfaces.Services;
using MangaBot.Domain.Model;
using RestSharp;

namespace MangaBot.Domain.Services
{
    public class WhatsZapService : IWhatsZapService
    {
        public void enviarMensagem(Usuario usuario, Manga manga)
        {
            if (usuario.apikey != "0" && usuario.apikey != null)
            {
                string mensagem = string.Empty;
                //if (manga.TotaldeCapitulos >= 1)
                //{
                //    mensagem = $"Voce tem capitulos acumulados do manga: {manga.Nome.ToUpper()}. " +
                //    $"Corre no mangalivre para ler! https://mangalivre.net/manga/{manga.Nome}/{manga.codigoManga}";
                //}
                //else
                //{
                    mensagem = $"O manga: {manga.Nome.ToUpper()}, tem um novo capitulo hoje: {DateTime.Now.ToString("dd/MM/yyyy")}. " +
                    $"Corre no mangalivre para ler! https://mangalivre.net/manga/{manga.Nome}/{manga.codigoManga}";
                //}

                var client = new RestClient($"https://api.callmebot.com/whatsapp.php?phone={usuario.numero_phone}&text={HttpUtility.UrlEncodeUnicode(mensagem)}&apikey={usuario.apikey}");

                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
            }
            else
            {
                Console.WriteLine($"O usuario:{usuario.nomecompleto}, não tem apikey para envio de mensagem.");
            }
        }
    }
}
