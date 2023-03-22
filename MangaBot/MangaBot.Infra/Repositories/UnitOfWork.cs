using MangaBot.Domain.Interfaces.Repository;
using MangaBot.Domain.Model;
using MangaBot.Infra.DataContext;
using MangaBot.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public MangaBotContext context;
        public UnitOfWork(MangaBotContext _context)
        {
            context = _context;
        }

        private IBaseRepository<Manga> mangaRepository;
        private IBaseRepository<MangaUsuario> mangaUsuarioRepository;
        private IBaseRepository<Usuario> usuarioRepository;
        private IBaseRepository<Log> logRepository;
        

        public IBaseRepository<Manga> MangaRepository 
        { 
            get 
            { 
                if(mangaRepository == null)
                    mangaRepository = new BaseRepository<Manga>(context);
                return mangaRepository;
            } 
        }
        public IBaseRepository<MangaUsuario> MangaUsuarioRepository
        {
            get
            {
                if (mangaUsuarioRepository == null)
                    mangaUsuarioRepository = new BaseRepository<MangaUsuario>(context);
                return mangaUsuarioRepository;
            }
        }
        public IBaseRepository<Usuario> UsuarioRepository
        {
            get
            {
                if (usuarioRepository == null)
                    usuarioRepository = new BaseRepository<Usuario>(context);
                return usuarioRepository;
            }
        }
        public IBaseRepository<Log> LogRepository
        {
            get
            {
                if (logRepository == null)
                    logRepository = new BaseRepository<Log>(context);
                return logRepository;
            }
        }
    }
}
