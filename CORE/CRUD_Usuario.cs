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
        public static USUARIO Read(int nombre)
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
    }
}
