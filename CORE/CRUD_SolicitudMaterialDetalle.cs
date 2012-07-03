﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_SolicitudMaterialDetalle
    {

        public static List<DETALLE_SOLICITUD_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var solicitud_mat_det = from sol_mat_det in ctx.ListaSolicitudMaterialDetalle
                               
                               orderby sol_mat_det.SM_ID,sol_mat_det.M_ID
                               select sol_mat_det;

                return solicitud_mat_det.ToList<DETALLE_SOLICITUD_MATERIAL>();
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

        public static DETALLE_SOLICITUD_MATERIAL Read(int sol_mat_id, int mat_id )
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var solicitud_mat_det = from sol_mat_det in ctx.ListaSolicitudMaterialDetalle
                                            where sol_mat_det.SM_ID.Equals(sol_mat_id) && sol_mat_det.M_ID.Equals(mat_id)
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
    }
}
