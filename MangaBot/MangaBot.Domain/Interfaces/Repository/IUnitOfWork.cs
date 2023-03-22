using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IBaseRepository<Manga> MangaRepository { get; }

        IBaseRepository<MangaUsuario> MangaUsuarioRepository { get; }

        IBaseRepository<Usuario> UsuarioRepository { get; }

        IBaseRepository<Log> LogRepository { get; }
    }
}
