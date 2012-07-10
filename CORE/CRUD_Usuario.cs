using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_Usuario
    {
        public static List<USUARIO> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var usuario = from usu in ctx.ListaUsuario
                              orderby usu.nombre
                              select usu;

                return usuario.ToList<USUARIO>();
            }
        }
        public static void Create(USUARIO usu_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaUsuario.InsertOnSubmit(usu_new);
                ctx.SubmitChanges();
            }
        }
        public static USUARIO Read(string nombre)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var usuario = from usu in ctx.ListaUsuario
                                  where usu.nombre.Equals(nombre)
                                  select usu;
                    return usuario.First<USUARIO>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static USUARIO Login(string nombre, string pass)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var usuario = from usu in ctx.ListaUsuario
                                  where usu.nombre.Equals(nombre) && usu.pass.Equals(pass)
                                  select usu;
                    return usuario.First<USUARIO>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void Update(USUARIO usu_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                USUARIO usuario = (from usu in ctx.ListaUsuario
                                   where usu.nombre.Equals(usu_upd.nombre)
                                   select usu).First<USUARIO>();

                usuario.nombre = usu_upd.nombre;
                usuario.pass = usu_upd.pass;
                usuario.area = usu_upd.area;

                ctx.SubmitChanges();
            }
        }
        public static void Delete(USUARIO usuario)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                USUARIO borrar = (from u in ctx.ListaUsuario
                                  where u.nombre.Equals(usuario.nombre)
                                  select u).First<USUARIO>();

                ctx.ListaUsuario.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
        public static bool TienePermiso(USUARIO usuarioLogin,
                                        string UrlConsulta)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var EsBase = from pa in ctx.ListaPagina
                             where pa.P_BASE.Equals(true)
                                    && pa.P_NAVIGATE.Equals(UrlConsulta)
                             select pa;

                if (EsBase.Count<PAGINA>() > 0)
                    return true;

                //Obtengo el Perfil del Usuario
                var Retorno = from PePa in ctx.ListaPagina
                              where PePa.P_NAVIGATE.Equals(UrlConsulta) && (PePa.P_PERFIL.Equals(usuarioLogin.area) || PePa.P_PERFIL.Equals("All"))
                              select PePa;

                if (Retorno.Count<PAGINA>() > 0)
                    return true;
                else
                    return false;
            }
        }

        public static PAGINA getPagina(string NavigateUrl)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var Retorno = from Pa in ctx.ListaPagina
                              where Pa.P_NAVIGATE.Equals(NavigateUrl)
                              select Pa;
                if (Retorno.Count<PAGINA>() == 0)
                    return null;
                else
                    return Retorno.First<PAGINA>();
            }
        }

        public static PAGINA ReadPagina(long PaginaId)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                return (from Pa in ctx.ListaPagina
                        where Pa.P_ID.Equals(PaginaId)
                        select Pa).First<PAGINA>();
            }
        }
    }
}
