// See https://aka.ms/new-console-template for more information
using FluentScheduler;
using MangaBot.Application.Crawler.Interface;
using MangaBot.Domain.Crawler;
using MangaBot.Domain.Interfaces.Repository;
using MangaBot.Domain.Interfaces.Services;
using MangaBot.Domain.Model;
using MangaBot.Domain.Services;
using MangaBot.Infra.DataContext;
using MangaBot.Infra.Repositories;
using MangaBot.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

//Iniciando DI
var services = new ServiceCollection();

//DI Context
services.AddDbContext<MangaBotContext>(options => options.UseLazyLoadingProxies().UseMySql(ConfigurationManager.AppSettings["ConnectionString"],
        ServerVersion.AutoDetect(ConfigurationManager.AppSettings["ConnectionString"])));

//DI Services
services.AddScoped<IWhatsZapService, WhatsZapService>();
services.AddScoped<IMangaService, MangaService>();
services.AddScoped<ILogService, LogService>();
services.AddScoped<IEnviarService, EnviarService>();

//DI CrawlerMangaYabu
services.AddScoped<ICrawler, CrawlerMangaLivre>();

//DI Repositorys
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IBaseRepository<Manga>, BaseRepository<Manga>>();
services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
services.AddScoped<IBaseRepository<MangaUsuario>, BaseRepository<MangaUsuario>>();
services.AddScoped<IBaseRepository<Log>, BaseRepository<Log>>();
var serviceProvider = services.BuildServiceProvider();


JobManager.JobException += JobManager_JobException;

var registry = new Registry();

//Roda de 5 em 5 minutos com o FluentScheduler
registry.Schedule(() => serviceProvider.GetRequiredService<IEnviarService>().Enviar()).ToRunNow().AndEvery(5).Minutes();

JobManager.Initialize(registry);
Thread.Sleep(Timeout.Infinite);

static void JobManager_JobException(JobExceptionInfo obj)
{
    //logService.InsereLog(new Log 
    //{ 
    //    execucao = "Erro scheduler", 
    //    mensagem = $"Erro no scheduler do manga bot, erro: {obj.Exception.Message}", 
    //    dataExecucao = DateTime.Parse(DateTime.Now.ToString()) 
    //});
}