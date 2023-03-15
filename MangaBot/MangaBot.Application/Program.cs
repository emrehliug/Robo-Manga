// See https://aka.ms/new-console-template for more information
using MangaBot.Application.Services.MangaService;

MangaService GerManga = new MangaService();

Console.WriteLine($"Iniciando envio de mensagens...\n");
GerManga.Enviar();
Console.WriteLine($"--------------------------- FIM ---------------------------------");