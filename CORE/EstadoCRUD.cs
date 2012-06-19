using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class EstadoCRUD
    {
        public static List<ESTADO> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var estado = from e in ctx.Estados
                              orderby e.E_ID
                              select e;

                return estado.ToList<ESTADO>();
            }
        }
        
        public static void Create(ESTADO estado_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.Estados.InsertOnSubmit(estado_new);
                ctx.SubmitChanges();
            }
        }

        public static ESTADO Read(int estado_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var estado = from e in ctx.Estados
                                  where e.E_ID.Equals(estado_id)
                                  select e;
                    return estado.First<MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(ESTADO estado_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ESTADO estado = (from e in ctx.Estados
                                     where e.E_ID.Equals(estado_upd.E_ID)
                                   select e).First<MATERIAL>();

                estado.E_NOMBRE = estado_upd.E_NOMBRE;
                estado.E_DESCRIPCION = estado_upd.E_DESCRIPCION;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(ESTADO estado_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ESTADO borrar = (from e in ctx.Estados
                                 where e.E_ID.Equals(estado_del.E_ID)
                                  select e).First<MATERIAL>();

                ctx.Estados.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
