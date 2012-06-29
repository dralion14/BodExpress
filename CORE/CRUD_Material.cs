using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_EntregaMaterialDetalle
    {
        public static List<DETALLE_ENTREGA_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var EntregaMaterialDetalle = from det_entr_mat in ctx.ListaEntregaMaterialDetalle                             
                                             orderby det_entr_mat.M_ID
                                             select det_entr_mat;

                return EntregaMaterialDetalle.ToList<DETALLE_ENTREGA_MATERIAL>();
            }
        }

        public static void Create(DETALLE_ENTREGA_MATERIAL det_entr_mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaEntregaMaterialDetalle.InsertOnSubmit(det_entr_mat_new);
                ctx.SubmitChanges();
            }
        }

        public static DETALLE_ENTREGA_MATERIAL Read(int det_entr_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var EntregaMaterialDetalle = from det_entr_mat in ctx.ListaEntregaMaterialDetalle
                                                 where det_entr_mat.M_ID.Equals(det_entr_mat_id)
                                                 select det_entr_mat;
                    return EntregaMaterialDetalle.First<DETALLE_ENTREGA_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(DETALLE_ENTREGA_MATERIAL det_entr_mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_ENTREGA_MATERIAL EntregaMaterialDetalle = (from det_entr_mat in ctx.ListaEntregaMaterialDetalle
                                   where det_entr_mat.M_ID.Equals(det_entr_mat_upd.M_ID)
                                   select det_entr_mat).First<DETALLE_ENTREGA_MATERIAL>();

                EntregaMaterialDetalle.DEM_CANTIDAD = det_entr_mat_upd.DEM_CANTIDAD;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(DETALLE_ENTREGA_MATERIAL det_entr_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_ENTREGA_MATERIAL borrar = (from det_entr_mat in ctx.ListaEntregaMaterialDetalle
                                  where det_entr_mat.M_ID.Equals(det_entr_mat_del.M_ID)
                                  select det_entr_mat).First<DETALLE_ENTREGA_MATERIAL>();

                ctx.ListaEntregaMaterialDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
