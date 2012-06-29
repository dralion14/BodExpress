using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_DevolucionMaterial
    {

        public static List<DEVOLUCION_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var DevolucionMaterial = from dev_mat in ctx.ListaDevolucionMaterial
                                         orderby dev_mat.DM_ID
                                         select dev_mat;
                return DevolucionMaterial.ToList<DEVOLUCION_MATERIAL>();
            }
        }
        public static void Create(DEVOLUCION_MATERIAL dev_mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaDevolucionMaterial.InsertOnSubmit(dev_mat_new);
                ctx.SubmitChanges();
            }
        }
        public static DEVOLUCION_MATERIAL Read(int dev_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var DevolucionMaterial = from dev_mat in ctx.ListaDevolucionMaterial
                                             where dev_mat.DM_ID.Equals(dev_mat_id)
                                             select dev_mat;
                    return DevolucionMaterial.First<DEVOLUCION_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void Update(DEVOLUCION_MATERIAL dev_mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DEVOLUCION_MATERIAL DevolucionMaterial = (from dev_mat in ctx.ListaDevolucionMaterial
                                                          where dev_mat.DM_ID.Equals(dev_mat_upd.DM_ID)
                                                          select dev_mat).First<DEVOLUCION_MATERIAL>();

                DevolucionMaterial.UC_ID = dev_mat_upd.UC_ID;
                DevolucionMaterial.DM_FECHA = dev_mat_upd.DM_FECHA;

                ctx.SubmitChanges();
            }
        }
        public static void Delete(DEVOLUCION_MATERIAL dev_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DEVOLUCION_MATERIAL borrar = (from dev_mat in ctx.ListaDevolucionMaterial
                                              where dev_mat.DM_ID.Equals(dev_mat_del.DM_ID)
                                              select dev_mat).First<DEVOLUCION_MATERIAL>();

                ctx.ListaDevolucionMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
