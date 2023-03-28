using HtmlAgilityPack;
using MangaBot.Application.Crawler.Interface;
using MangaBot.Domain.Model;
using System;
using System.Net;
using System.Text;

namespace MangaBot.Domain.Crawler
{
    public class CrawlerMangaYabu_decraped : ICrawler
    {
        string dominio = "https://mangayabu.top";
        string rota = "/manga/";

        public int RaspaTela(Manga mangayabu)
        {
            try
            {
                mangayabu.Nome = mangayabu.Nome.Replace(" ", "-").ToLower();

                WebClient webc = new WebClient();
                string pagina = webc.DownloadString(dominio + rota + mangayabu.Nome + "/");
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(pagina);

                var capitulosDesform = document.DocumentNode.SelectSingleNode("//*[contains(.,'chapters')]").InnerText.ToString();

                int index = capitulosDesform.IndexOf("chapters");
                StringBuilder str = new StringBuilder(capitulosDesform);
                str.Remove(0, index);

                string[] separador = str.Remove(20, str.Length - 20).ToString().Split(":");
                return Convert.ToInt32(separador[1].Split(",")[0]);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}