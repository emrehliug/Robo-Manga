using HtmlAgilityPack;
using MangaBot.Application.Crawler.Interface;
using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Crawler
{
    public class CrawlerMangaLivre : ICrawler
    {
        string dominio = "https://mangalivre.net";
        string rota = "/manga/";

        public int RaspaTela(Manga mangalivre)
        {
            try
            {
                mangalivre.Nome = mangalivre.Nome.Replace(" ", "-").ToLower();

                WebClient webc = new WebClient();
                string pagina = webc.DownloadString(dominio + rota + mangalivre.Nome + "/" + mangalivre.codigoManga);
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(pagina);

                string capitulos = document.DocumentNode.SelectSingleNode("//*[@id=\"chapter-list\"]/div[3]/h2/span").InnerText.ToString();

                return Convert.ToInt32(capitulos);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
