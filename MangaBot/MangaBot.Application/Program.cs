// See https://aka.ms/new-console-template for more information
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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
services.AddScoped<ICrawler, CrawlerMangaYabu>();

//DI Repositorys
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IBaseRepository<Manga>, BaseRepository<Manga>>();
services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
services.AddScoped<IBaseRepository<MangaUsuario>, BaseRepository<MangaUsuario>>();
services.AddScoped<IBaseRepository<Log>, BaseRepository<Log>>();


var serviceProvider = services.BuildServiceProvider();
var enviarService = serviceProvider.GetRequiredService<IEnviarService>();


Console.WriteLine($"Iniciando envio de mensagens...\n");
enviarService.Enviar();
Console.WriteLine($"--------------------------- FIM ---------------------------------");

