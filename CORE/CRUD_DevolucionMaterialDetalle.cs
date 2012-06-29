using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_DevolucionMaterialDetalle
    {

        public static List<DETALLE_DEVOLUCION_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var DevolucionMaterialDetalle = from d_d_m in ctx.ListaDevolucionMaterialDetalle
                                                orderby d_d_m.DM_ID
                                                select d_d_m;

                return DevolucionMaterialDetalle.ToList<DETALLE_DEVOLUCION_MATERIAL>();
            }
        }

        public static void Create(DETALLE_DEVOLUCION_MATERIAL d_d_m_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaDevolucionMaterialDetalle.InsertOnSubmit(d_d_m_new);
                ctx.SubmitChanges();
            }
        }

        public static DETALLE_DEVOLUCION_MATERIAL Read(int d_m_id, int m_id )
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var DevolucionMaterialDetalle = from d_d_m in ctx.ListaDevolucionMaterialDetalle
                                   where (d_d_m.DM_ID.Equals(d_m_id) && d_d_m.M_ID.Equals(m_id))
                                   select d_d_m;
                    return DevolucionMaterialDetalle.First<DETALLE_DEVOLUCION_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(DETALLE_DEVOLUCION_MATERIAL d_d_m_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_DEVOLUCION_MATERIAL DevolucionMaterialDetalle = (from d_d_m in ctx.ListaDevolucionMaterialDetalle
                                                        where (d_d_m.DM_ID.Equals(d_d_m_upd.DM_ID) && d_d_m.M_ID.Equals(d_d_m_upd.M_ID))
                                                        select d_d_m).First<DETALLE_DEVOLUCION_MATERIAL>();

                DevolucionMaterialDetalle.DDM_MOTIVO = d_d_m_upd.DDM_MOTIVO;
                DevolucionMaterialDetalle.DDM_CANTIDAD = d_d_m_upd.DDM_CANTIDAD;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(DETALLE_DEVOLUCION_MATERIAL mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_DEVOLUCION_MATERIAL borrar = (from d_d_m in ctx.ListaDevolucionMaterialDetalle
                                                      where (d_d_m.M_ID.Equals(mat_del.M_ID) && d_d_m.DM_ID.Equals(d_d_m.DM_ID))
                                                      select d_d_m).First<DETALLE_DEVOLUCION_MATERIAL>();

                ctx.ListaDevolucionMaterialDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }



    }
}
