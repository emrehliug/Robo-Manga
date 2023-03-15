using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Application.Crawler.Interface
{
    public interface ICrawler
    {
        public int RaspaTela(Manga manga);
    }
}
