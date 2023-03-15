using MangaBot.Domain.Model;
using MangaBot.Infra.Repositories;
using MangaBot.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Application.Services.UsuarioService
{
    public class UsuarioService
    {
        private IUsuarioRepository repos = new UsuarioRepository();

        public List<Usuario> BuscarUsuarios(int MangaId)
        {
            return repos.BuscarPorManga(MangaId);
        }
    }
}
