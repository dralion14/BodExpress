using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_DevolucionProveedor
    {

        public static List<DEVOLUCION_A_PROVEEDOR> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var DevolucionProveedor = from dev_pro in ctx.ListaDevolucionProveedor
                                         orderby dev_pro.DP_ID
                                         select dev_pro;
                return DevolucionProveedor.ToList<DEVOLUCION_A_PROVEEDOR>();
            }
        }
        public static void Create(DEVOLUCION_A_PROVEEDOR dev_pro_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaDevolucionProveedor.InsertOnSubmit(dev_pro_new);
                ctx.SubmitChanges();
            }
        }
        public static DEVOLUCION_A_PROVEEDOR Read(int dev_pro_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var DevolucionProveedor = from dev_pro in ctx.ListaDevolucionProveedor
                                             where dev_pro.DP_ID.Equals(dev_pro_id)
                                             select dev_pro;
                    return DevolucionProveedor.First<DEVOLUCION_A_PROVEEDOR>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void Update(DEVOLUCION_A_PROVEEDOR dev_pro_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DEVOLUCION_A_PROVEEDOR DevolucionProveedor = (from dev_pro in ctx.ListaDevolucionProveedor
                                                             where dev_pro.DP_ID.Equals(dev_pro_upd.DP_ID)
                                                          select dev_pro).First<DEVOLUCION_A_PROVEEDOR>();

                DevolucionProveedor.DP_FECHA = dev_pro_upd.DP_FECHA;

                ctx.SubmitChanges();
            }
        }
        public static void Delete(DEVOLUCION_A_PROVEEDOR dev_pro_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DEVOLUCION_A_PROVEEDOR borrar = (from dev_pro in ctx.ListaDevolucionProveedor
                                              where dev_pro.DP_ID.Equals(dev_pro_del.DP_ID)
                                              select dev_pro).First<DEVOLUCION_A_PROVEEDOR>();

                ctx.ListaDevolucionProveedor.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
