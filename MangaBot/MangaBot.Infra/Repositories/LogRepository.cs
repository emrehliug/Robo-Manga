using MangaBot.Domain.Model;
using MangaBot.Infra.DataContext;
using MangaBot.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaBot.Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        public void InsereLog(Log log)
        {
            try
            {
                using(var context = new MangaBotContext())
                {
                    context.Add(log);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
