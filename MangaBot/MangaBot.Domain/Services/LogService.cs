using MangaBot.Domain.Interfaces.Repository;
using MangaBot.Domain.Interfaces.Services;
using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork uow;
        public LogService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public void InsereLog(Log log)
        {
            uow.LogRepository.Insert(log);
        }
    }
}
