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
