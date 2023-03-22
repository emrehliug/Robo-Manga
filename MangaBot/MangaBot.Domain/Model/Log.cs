using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    [Table("tbLog")]
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string execucao { get; set; }
        public string mensagem { get; set; }
        public DateTime dataExecucao { get; set; }
    }
}
