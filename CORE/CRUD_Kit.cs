using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_Kit
    {
        public static List<MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.ListaMaterial
                               where mat.M_TIPO.Equals("Kit")
                               orderby mat.M_ID
                               select mat;

                return material.ToList<MATERIAL>();
            }
        }

        public static List<MATERIAL> getAllMaterial(int kit_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from kit in ctx.ListaMaterialKit
                               join mat in ctx.ListaMaterial
                               on kit.MAT_M_ID equals mat.M_ID
                               where kit.M_ID.Equals(kit_id)
                               select mat;

                return material.ToList<MATERIAL>();
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

        public static MATERIAL Read(int mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var material = from mat in ctx.ListaMaterial
                                   where mat.M_ID.Equals(mat_id)
                                   select mat;
                    return material.First<MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(MATERIAL mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL material = (from mat in ctx.ListaMaterial
                                     where mat.M_ID.Equals(mat_upd.M_ID)
                                     select mat).First<MATERIAL>();

                material.M_NOMBRE = mat_upd.M_NOMBRE;
                material.M_DESCRIPCION = mat_upd.M_DESCRIPCION;
                material.M_TIPO = mat_upd.M_TIPO;
                material.M_MEDIDA_DISTRIBUCION = mat_upd.M_MEDIDA_DISTRIBUCION;
                material.M_MEDIDA_COMPRA = mat_upd.M_MEDIDA_COMPRA;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(int kit_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var borrar = from mat in ctx.ListaMaterialKit
                                      where mat.M_ID.Equals(kit_del)
                                      select mat;

                foreach (var del in borrar.ToList<MATERIAL_KIT>())
                {
                    ctx.ListaMaterialKit.DeleteOnSubmit(del);
                    ctx.SubmitChanges();
                }
            }
        }
    }
}
