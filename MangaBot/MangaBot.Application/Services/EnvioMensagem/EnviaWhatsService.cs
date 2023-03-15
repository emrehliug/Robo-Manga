using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MangaBot.Domain.Model;
using RestSharp;

namespace MangaBot.Application.Services.EnvioMensagem
{
    public class EnviaWhatsService
    {
        public async static void enviarMensagem(Usuario usuario, Manga manga, int numerador)
        {
            if(usuario.apikey != "0" && usuario.apikey != null)
            {
                string mensagem = String.Empty;
                if (numerador == 1)
                {
                    mensagem = $"Voce tem capitulos acumulados do manga: {manga.Nome.ToUpper()}. " +
                    $"Corre no mangayabu para ler! https://mangayabu.top/manga/{manga.Nome}";
                }
                else
                {
                    mensagem = $"O manga: {manga.Nome.ToUpper()}, tem um novo capitulo hoje: {DateTime.Now.ToString("dd/MM/yyyy")}. " +
                    $"Corre no mangayabu para ler! https://mangayabu.top/manga/{manga.Nome}";
                }
                
                var client = new RestClient($"https://api.callmebot.com/whatsapp.php?phone={usuario.numero_phone}&text={HttpUtility.UrlEncodeUnicode(mensagem)}&apikey={usuario.apikey}");

                var request = new RestRequest("",Method.Get);
                var response = client.Execute(request);
            }
            else
            {
                Console.WriteLine($"O usuario:{usuario.nomecompleto}, não tem apikey para envio de mensagem.");
            }
        }
    }
}
