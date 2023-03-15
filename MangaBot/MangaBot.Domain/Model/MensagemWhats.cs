using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    public class MensagemWhats
    {
        public int phone_number { get; set; }

        public string message { get; set; }

        public int apikey { get; set; }
    }
}
