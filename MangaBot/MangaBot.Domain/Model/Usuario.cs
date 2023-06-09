﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Model
{
    [Table("tbUsuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string numero_phone { get; set; }

        public string nomecompleto { get; set; }

        public string email { get; set; }

        public string apikey { get; set; }

        public virtual ICollection<MangaUsuario> MangasDoUsuario { get; set; }
    }
}
