using System;
using System.Collections.Generic;
using System.Linq;

namespace CORE
{
    public class CRUD_EntregaMaterial
    {

        public static List<ENTREGA_MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var entrega_material = from entrg_mat in ctx.ListaEntregaMaterial
                                       orderby entrg_mat.EM_ID
                                       select entrg_mat;

                return entrega_material.ToList<ENTREGA_MATERIAL>();
            }
        }
        public static void Create(ENTREGA_MATERIAL entrg_mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaEntregaMaterial.InsertOnSubmit(entrg_mat_new);
                ctx.SubmitChanges();
            }
        }
        public static ENTREGA_MATERIAL Read(int entrg_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var entrega_material = from entrg_mat in ctx.ListaEntregaMaterial
                                           where entrg_mat.EM_ID.Equals(entrg_mat_id)
                                           select entrg_mat;
                    return entrega_material.First<ENTREGA_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }
        public static void Update(ENTREGA_MATERIAL entrg_mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ENTREGA_MATERIAL entrega_material = (from entrg_mat in ctx.ListaEntregaMaterial
                                                     where entrg_mat.EM_ID.Equals(entrg_mat.EM_ID)
                                                     select entrg_mat).First<ENTREGA_MATERIAL>();

                entrega_material.SM_ID                  = entrg_mat_upd.SM_ID;
                //entrega_material.UN_ID                  = entrg_mat_upd.UN_ID;
                entrega_material.EM_ENCARGADO_ENTREGA   = entrg_mat_upd.EM_ENCARGADO_ENTREGA;
                entrega_material.EM_FECHA               = entrg_mat_upd.EM_FECHA;

                ctx.SubmitChanges();
            }
        }
        public static void Delete(ENTREGA_MATERIAL entrg_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ENTREGA_MATERIAL borrar = (from entrg_mat in ctx.ListaEntregaMaterial
                                           where entrg_mat.EM_ID.Equals(entrg_mat_del.EM_ID)
                                           select entrg_mat).First<ENTREGA_MATERIAL>();

                ctx.ListaEntregaMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

    }
}