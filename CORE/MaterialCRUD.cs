using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class MaterialCRUD
    {
        public static List<MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.Materiales
                              orderby mat.M_ID
                              select mat;

                return material.ToList<MATERIAL>();
            }
        }
        
        public static void Create(MATERIAL mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.Materiales.InsertOnSubmit(mat_new);
                ctx.SubmitChanges();
            }
        }

        public static MATERIAL Read(int mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var material = from mat in ctx.Materiales
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
                MATERIAL material = (from mat in ctx.Materiales
                                   where mat.M_ID.Equals(mat_upd.M_ID)
                                   select mat).First<MATERIAL>();

                material.M_NOMBRE = mat_upd.M_NOMBRE;
                material.M_DESCRIPCION = mat_upd.M_DESCRIPCION;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(MATERIAL mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL borrar = (from mat in ctx.Materiales
                                  where mat.M_ID.Equals(mat_del.M_ID)
                                  select mat).First<MATERIAL>();

                ctx.Materiales.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
}
