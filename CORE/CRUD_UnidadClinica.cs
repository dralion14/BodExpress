using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_UnidadClinica
    {
         public static List<UNIDAD_CLINICA> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var unidades = from uni in ctx.ListaUnidadClinica
                              orderby uni.UC_ID
                              select uni;

                return unidades.ToList<UNIDAD_CLINICA>();
            }
        }
        
        public static void Create(UNIDAD_CLINICA uni_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaUnidadClinica.InsertOnSubmit(uni_new);
                ctx.SubmitChanges();
            }
        }

        public static UNIDAD_CLINICA Read(int uni_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var unidad = from uni in ctx.ListaUnidadClinica
                                  where uni.UC_ID.Equals(uni_id)
                                  select uni;
                    return unidad.First<UNIDAD_CLINICA>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static UNIDAD_CLINICA Read(string uni_nom)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var unidad = from uni in ctx.ListaUnidadClinica
                                 where uni.UC_NOMBRE.Equals(uni_nom)
                                 select uni;
                    return unidad.First<UNIDAD_CLINICA>();
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
                UNIDAD_CLINICA unidad = (from uni in ctx.ListaUnidadClinica
                                   where uni.UC_ID.Equals(uni_upd.UC_ID)
                                   select uni).First<UNIDAD_CLINICA>();

                unidad.UC_NOMBRE = uni_upd.UC_NOMBRE;
                unidad.UC_ENCARGADO = uni_upd.UC_ENCARGADO;
                unidad.UC_PRIORIDAD = uni_upd.UC_PRIORIDAD;
                ctx.SubmitChanges();
            }
        }

        public static void Delete(UNIDAD_CLINICA uni_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                UNIDAD_CLINICA borrar = (from uni in ctx.ListaUnidadClinica
                                  where uni.UC_ID.Equals(uni_del.UC_ID)
                                  select uni).First<UNIDAD_CLINICA>();

                ctx.ListaUnidadClinica.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }
    }
    
}
