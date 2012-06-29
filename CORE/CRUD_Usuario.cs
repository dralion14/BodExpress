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

    }
}
