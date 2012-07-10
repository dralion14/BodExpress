using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_RecepcionMaterialDetalle
    {

        public static List<DETALLE_RECEPCION> getAll(int rm_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var recepcion_mat_det = from rec_mat_det in ctx.ListaRecepcionMaterialDetalle
                               where rec_mat_det.RM_ID.Equals(rm_id)
                                        select new DETALLE_RECEPCION
                                       {
                                           RM_ID = rec_mat_det.RM_ID,
                                           M_ID = rec_mat_det.M_ID,
                                           M_NOMBRE = CRUD_Material.ReadNombre(Int32.Parse(rec_mat_det.M_ID.ToString())),
                                           D_CANTIDAD = rec_mat_det.DRM_CANTIDAD
                                       };

                return recepcion_mat_det.ToList<DETALLE_RECEPCION>();
            }
        }

        public static void Create(DETALLE_RECEPCION_MATERIAL rec_mat_det_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaRecepcionMaterialDetalle.InsertOnSubmit(rec_mat_det_new);
                ctx.SubmitChanges();
            }
        }

        public static DETALLE_RECEPCION_MATERIAL Read(int rm_mat_det_id, int m_mat_det_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var recepcion_mat_det = from rec_mat_det in ctx.ListaRecepcionMaterialDetalle
                                   where rec_mat_det.RM_ID.Equals(rm_mat_det_id) 
                                   && rec_mat_det.M_ID.Equals(m_mat_det_id)
                                   select rec_mat_det;
                    return recepcion_mat_det.First<DETALLE_RECEPCION_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(DETALLE_RECEPCION_MATERIAL rec_mat_det_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_RECEPCION_MATERIAL recepcion_mat_det = (from rec_mat_det in ctx.ListaRecepcionMaterialDetalle
                                     where rec_mat_det.RM_ID.Equals(rec_mat_det_upd.RM_ID) 
                                     && rec_mat_det.M_ID.Equals(rec_mat_det_upd.M_ID)
                                     select rec_mat_det).First<DETALLE_RECEPCION_MATERIAL>();

                recepcion_mat_det.DRM_CANTIDAD= rec_mat_det_upd.DRM_CANTIDAD;
             
                ctx.SubmitChanges();
            }
        }

        public static void Delete(DETALLE_RECEPCION_MATERIAL rec_mat_det_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_RECEPCION_MATERIAL borrar = (from rec_mat_det in ctx.ListaRecepcionMaterialDetalle
                                   where rec_mat_det.RM_ID.Equals(rec_mat_det_del.RM_ID) 
                                   && rec_mat_det.M_ID.Equals(rec_mat_det_del.M_ID)
                                   select rec_mat_det).First<DETALLE_RECEPCION_MATERIAL>();

                ctx.ListaRecepcionMaterialDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public class DETALLE_RECEPCION
        {
            public decimal RM_ID { get; set; }
            public decimal M_ID { get; set; }
            public string M_NOMBRE { get; set; }
            public Int32 D_CANTIDAD { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType())
                    return false;

                return (RM_ID == ((DETALLE_RECEPCION)obj).RM_ID && M_ID == ((DETALLE_RECEPCION)obj).M_ID);
            }
            public override int GetHashCode()
            {
                return this.RM_ID.GetHashCode() ^ this.M_ID.GetHashCode();
            }
        }
    }
}
