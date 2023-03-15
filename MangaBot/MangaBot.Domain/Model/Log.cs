using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    public class Log
    {
        public int Id { get; set; }
        public string execucao { get; set; }
        public string mensagem { get; set; }
        public DateTime dataExecucao { get; set; }
    }
}
