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
    public class UsuarioRepository : IUsuarioRepository
    {
        private MangaBotContext context;

        public List<Usuario> BuscarPorManga(int mangaId)
        {
            try
            {
                using (context = new MangaBotContext())
                {
                    List<Usuario> usuarios = new List<Usuario>();
                    
                    var resultado = from u in context.tbUsuario
                                    join mu in context.tbMangaUsuario on u.UsuarioId equals mu.Usuario.UsuarioId
                                    join m in context.tbManga on mu.Manga.MangaId equals m.MangaId
                                    where m.MangaId == mangaId
                                    select new
                                    {
                                        numero_phone = u.numero_phone,
                                        nomecompleto = u.nomecompleto,
                                        email = u.email,
                                        apikey = u.apikey
                                    };

                    foreach (var usuario in resultado)
                    {
                        usuarios.Add(new Usuario
                        {
                            numero_phone = usuario.numero_phone,
                            nomecompleto = usuario.nomecompleto,
                            email = usuario.email,
                            apikey = usuario.apikey
                        });
                    }
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                //TODO: terminar tratativa de erro
                return null;
            }
        }
    }
}
