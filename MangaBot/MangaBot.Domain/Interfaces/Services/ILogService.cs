using MangaBot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Domain.Interfaces.Services
{
    public interface ILogService
    {
        void InsereLog(Log log);
    }
}
