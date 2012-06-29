using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_DevolucionProveedorDetalle
    {

        public static List<DETALLE_DEVOLUCION_A_PROVEEDOR> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var DevolucionProveedorDetalle = from det_dev_p in ctx.ListaDevolucionProveedorDetalle
                                         orderby det_dev_p.DP_ID
                                         select det_dev_p;
                return DevolucionProveedorDetalle.ToList<DETALLE_DEVOLUCION_A_PROVEEDOR>();
            }
        }
        public static void Create(DETALLE_DEVOLUCION_A_PROVEEDOR det_dev_p_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaDevolucionProveedorDetalle.InsertOnSubmit(det_dev_p_new);
                ctx.SubmitChanges();
            }
        }
        public static DETALLE_DEVOLUCION_A_PROVEEDOR Read(int det_dev_p_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var DevolucionProveedorDetalle = from det_dev_p in ctx.ListaDevolucionProveedorDetalle
                                                     where det_dev_p.DP_ID.Equals(det_dev_p_id)
                                                     select det_dev_p;
                    return DevolucionProveedorDetalle.First<DETALLE_DEVOLUCION_A_PROVEEDOR>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void Update(DETALLE_DEVOLUCION_A_PROVEEDOR det_dev_p_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_DEVOLUCION_A_PROVEEDOR DevolucionProveedorDetalle = (from dev_mat in ctx.ListaDevolucionProveedorDetalle
                                                          where dev_mat.DP_ID.Equals(det_dev_p_upd.DP_ID)
                                                          select dev_mat).First<DETALLE_DEVOLUCION_A_PROVEEDOR>();

                DevolucionProveedorDetalle.DDP_CANTIDAD = det_dev_p_upd.DDP_CANTIDAD;
                DevolucionProveedorDetalle.DDP_MOTIVO = det_dev_p_upd.DDP_MOTIVO;
                ctx.SubmitChanges();
            }
        }
        public static void Delete(DETALLE_DEVOLUCION_A_PROVEEDOR dev_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_DEVOLUCION_A_PROVEEDOR borrar = (from dev_mat in ctx.ListaDevolucionProveedorDetalle
                                              where dev_mat.DP_ID.Equals(dev_mat_del.DP_ID)
                                              select dev_mat).First<DETALLE_DEVOLUCION_A_PROVEEDOR>();

                ctx.ListaDevolucionProveedorDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
