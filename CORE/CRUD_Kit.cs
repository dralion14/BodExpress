using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_Kit
    {

        public static List<MATERIAL_KIT> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material_kit = from mat_kit in ctx.ListaMaterialKit
                               orderby mat_kit.M_ID,mat_kit.MAT_M_ID
                               select mat_kit;

                return material_kit.ToList<MATERIAL_KIT>();
            }
        }

        public static void Create(MATERIAL_KIT mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaMaterialKit.InsertOnSubmit(mat_new);
                ctx.SubmitChanges();
            }
        }

        public static MATERIAL_KIT Read(int mat_id, int mat_m_kit)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var material_kit = from mat_kit in ctx.ListaMaterialKit
                                   where mat_kit.M_ID.Equals(mat_id) && mat_kit.MAT_M_ID.Equals(mat_m_kit)
                                   select mat_kit;
                    return material_kit.First<MATERIAL_KIT>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(MATERIAL_KIT mat_kit_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL_KIT material_kit = (from mat_kit in ctx.ListaMaterialKit
                                     where mat_kit.M_ID.Equals(mat_kit_upd.M_ID) && mat_kit.MAT_M_ID.Equals(mat_kit_upd.MAT_M_ID)
                                     select mat_kit).First<MATERIAL_KIT>();

                material_kit.M_ID = mat_kit_upd.M_ID;
                material_kit.MAT_M_ID = mat_kit_upd.MAT_M_ID;
                material_kit.MK_CANTIDAD = mat_kit_upd.MK_CANTIDAD;
              

                ctx.SubmitChanges();
            }
        }

        public static void Delete(MATERIAL_KIT mat_kit_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL_KIT borrar = (from mat_kit in ctx.ListaMaterialKit
                                   where mat_kit.M_ID.Equals(mat_kit_del.M_ID) && mat_kit.MAT_M_ID.Equals(mat_kit_del.MAT_M_ID)
                                   select mat_kit).First<MATERIAL_KIT>();

                ctx.ListaMaterialKit.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }

}
