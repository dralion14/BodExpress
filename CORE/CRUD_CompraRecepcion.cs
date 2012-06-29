using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_CompraRecepcion
    {
        public static List<COMPRA_RECEPCION> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var CompraRecepcion = from c_r in ctx.ListaCompraRecepcion
                             orderby c_r.SC_ID
                             select c_r;
                return CompraRecepcion.ToList<COMPRA_RECEPCION>();
            }

        }

        public static void Create(COMPRA_RECEPCION c_r)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaCompraRecepcion.InsertOnSubmit(c_r);
                ctx.SubmitChanges();
            }
        }

        public static COMPRA_RECEPCION Read(int cr_sc_id, int cr_rm_id )
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var CompraRecepcion = from c_r in ctx.ListaCompraRecepcion
                                          where (c_r.SC_ID.Equals(cr_sc_id) && c_r.RM_ID.Equals(cr_rm_id))
                                          select c_r;
                    return CompraRecepcion.First<COMPRA_RECEPCION>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(COMPRA_RECEPCION cr_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                COMPRA_RECEPCION CompraRecepcion = (from c_r in ctx.ListaCompraRecepcion
                                                    where (c_r.SC_ID.Equals(cr_upd.SC_ID) && c_r.RM_ID.Equals(cr_upd.RM_ID))
                                                    select c_r).First<COMPRA_RECEPCION>();

                CompraRecepcion.SC_ID = cr_upd.SC_ID;
                CompraRecepcion.RM_ID = cr_upd.RM_ID;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(COMPRA_RECEPCION cr_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                COMPRA_RECEPCION borrar = (from c_r in ctx.ListaCompraRecepcion
                                           where (c_r.SC_ID.Equals(cr_upd.SC_ID) && c_r.RM_ID.Equals(cr_upd.RM_ID))
                                           select c_r).First<COMPRA_RECEPCION>();

                ctx.ListaCompraRecepcion.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

    }
}
