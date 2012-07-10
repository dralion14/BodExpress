using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_SolicitudMaterialDetalle
    {

        public static List<DETALLE_SOLICITUD> getAll(int sm_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var solicitud_mat_det = from sol_mat_det in ctx.ListaSolicitudMaterialDetalle 
                                        where sol_mat_det.SM_ID.Equals(sm_id)
                                        select new DETALLE_SOLICITUD
                                        {
                                            SM_ID = sol_mat_det.SM_ID,
                                            M_ID = sol_mat_det.M_ID,
                                            M_NOMBRE = CRUD_Material.ReadNombre(Int32.Parse(sol_mat_det.M_ID.ToString())),
                                            D_CANTIDAD = sol_mat_det.DSM_CANTIDAD
                                        };

                return solicitud_mat_det.ToList<DETALLE_SOLICITUD>();
            }
        }

        public static void Create(DETALLE_SOLICITUD_MATERIAL sol_mat_det_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaSolicitudMaterialDetalle.InsertOnSubmit(sol_mat_det_new);
                ctx.SubmitChanges();
            }
        }

        public static DETALLE_SOLICITUD_MATERIAL Read(int sm_mat_det_id, int m_mat_det_id )
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var solicitud_mat_det = from sol_mat_det in ctx.ListaSolicitudMaterialDetalle
                                   where sol_mat_det.SM_ID.Equals(sm_mat_det_id) 
                                   && sol_mat_det.M_ID.Equals(m_mat_det_id)
                                            select sol_mat_det;
                    return solicitud_mat_det.First<DETALLE_SOLICITUD_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(DETALLE_SOLICITUD_MATERIAL sol_mat_det_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_SOLICITUD_MATERIAL solicitud_mat_det = (from sol_mat_det in ctx.ListaSolicitudMaterialDetalle
                                                                where sol_mat_det.M_ID.Equals(sol_mat_det_upd.M_ID) 
                                                                && sol_mat_det.SM_ID.Equals(sol_mat_det_upd.SM_ID)
                                                                select sol_mat_det).First<DETALLE_SOLICITUD_MATERIAL>();

                solicitud_mat_det.DSM_CANTIDAD = sol_mat_det_upd.DSM_CANTIDAD;
                
                ctx.SubmitChanges();
            }
        }

        public static void Delete(DETALLE_SOLICITUD_MATERIAL sol_mat_det_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_SOLICITUD_MATERIAL borrar = (from sol_mat_det in ctx.ListaSolicitudMaterialDetalle
                                                    where sol_mat_det.M_ID.Equals(sol_mat_det_del.M_ID) 
                                                      && sol_mat_det.SM_ID.Equals(sol_mat_det_del.SM_ID)
                                                     select sol_mat_det).First<DETALLE_SOLICITUD_MATERIAL>();

                ctx.ListaSolicitudMaterialDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public class DETALLE_SOLICITUD
        {
            public decimal SM_ID { get; set; }
            public decimal M_ID { get; set; }
            public string M_NOMBRE { get; set; }
            public Int32 D_CANTIDAD { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType())
                    return false;

                return (SM_ID == ((DETALLE_SOLICITUD)obj).SM_ID && M_ID == ((DETALLE_SOLICITUD)obj).M_ID);
            }
            public override int GetHashCode()
            {
                return this.SM_ID.GetHashCode() ^ this.M_ID.GetHashCode();
            }
        }
    }
}
