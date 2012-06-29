using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE
{
    public class CRUD_RecepcionMaterial
    {
        public static List<RECEPCION_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var RecepcionMaterial = from recep_mat in ctx.ListaRecepcionMaterial
                                        orderby recep_mat.RM_ID
                                        select recep_mat;

                return RecepcionMaterial.ToList<RECEPCION_MATERIAL>();
            }
        }

        public static void Create(RECEPCION_MATERIAL recep_mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaRecepcionMaterial.InsertOnSubmit(recep_mat_new);
                ctx.SubmitChanges();
            }
        }

        public static RECEPCION_MATERIAL Read(int recep_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var RecepcionMaterial = from recep_mat in ctx.ListaRecepcionMaterial
                                            where recep_mat.RM_ID.Equals(recep_mat_id)
                                            select recep_mat;
                    return RecepcionMaterial.First<RECEPCION_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(RECEPCION_MATERIAL recep_mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                RECEPCION_MATERIAL RecepcionMaterial = (from recep_mat in ctx.ListaRecepcionMaterial
                                                        where recep_mat.RM_ID.Equals(recep_mat_upd.RM_ID)
                                                        select recep_mat).First<RECEPCION_MATERIAL>();

                RecepcionMaterial.RM_ENCARGADO_RECEPCION = recep_mat_upd.RM_ENCARGADO_RECEPCION;
                RecepcionMaterial.RM_FECHA = recep_mat_upd.RM_FECHA;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(RECEPCION_MATERIAL recep_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                RECEPCION_MATERIAL borrar = (from recep_mat in ctx.ListaRecepcionMaterial
                                             where recep_mat.RM_ID.Equals(recep_mat_del.RM_ID)
                                             select recep_mat).First<RECEPCION_MATERIAL>();

                ctx.ListaRecepcionMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }

}