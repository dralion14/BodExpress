using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class UnidadCRUD
    {
         public static List<UNIDAD_CLINICA> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var unidades = from uni in ctx.Unidades
                              orderby uni.UC_ID
                              select uni;

                return unidades.ToList<UNIDAD_CLINICA>();
            }
        }
        
        public static void Create(UNIDAD_CLINICA uni_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.Unidades.InsertOnSubmit(uni_new);
                ctx.SubmitChanges();
            }
        }

        public static UNIDAD_CLINICA Read(int uni_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var material = from mat in ctx.Unidades
                                  where mat.UC_ID.Equals(uni_id)
                                  select mat;
                    return material.First<UNIDAD_CLINICA>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(UNIDAD_CLINICA uni_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                UNIDAD_CLINICA material = (from mat in ctx.Unidades
                                   where mat.UC_ID.Equals(uni_upd.UC_ID)
                                   select mat).First<UNIDAD_CLINICA>();

                material.UC_NOMBRE = uni_upd.UC_NOMBRE;
                material.UC_ENCARGADO = uni_upd.UC_ENCARGADO;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(UNIDAD_CLINICA uni_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                UNIDAD_CLINICA borrar = (from mat in ctx.Unidades
                                  where mat.UC_ID.Equals(uni_del.UC_ID)
                                  select mat).First<UNIDAD_CLINICA>();

                ctx.Unidades.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
    
}
