using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_SolicitudCompra
    {
        public static List<SOLICITUD_COMPRA> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var solicitud_compra = from sol_comp in ctx.ListaSolicitudCompra
                                       orderby sol_comp.SC_ID
                                       select sol_comp;

                return solicitud_compra.ToList<SOLICITUD_COMPRA>();
            }
        }

        public static List<SOLICITUD_COMPRA> getPendientes()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var solicitud_compra = from sol_comp in ctx.ListaSolicitudCompra
                                       where sol_comp.E_ID.Equals(1)
                                       orderby sol_comp.SC_ID
                                       select sol_comp;

                return solicitud_compra.ToList<SOLICITUD_COMPRA>();
            }
        }

        public static SOLICITUD_COMPRA getEnd()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                List<SOLICITUD_COMPRA> solicitud_compra = (from sol_comp in ctx.ListaSolicitudCompra
                                                           orderby sol_comp.SC_ID
                                                           select sol_comp).ToList<SOLICITUD_COMPRA>();

                return solicitud_compra.Last<SOLICITUD_COMPRA>();
            }
        }

        public static void Create(SOLICITUD_COMPRA sol_comp_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaSolicitudCompra.InsertOnSubmit(sol_comp_new);
                ctx.SubmitChanges();
            }
        }


        public static SOLICITUD_COMPRA Read(int sol_comp_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var solicitud_compra = from sol_comp in ctx.ListaSolicitudCompra
                                           where sol_comp.SC_ID.Equals(sol_comp_id)
                                           select sol_comp;
                    return solicitud_compra.First<SOLICITUD_COMPRA>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(SOLICITUD_COMPRA sol_comp_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                SOLICITUD_COMPRA solicitud_compra = (from sol_comp in ctx.ListaSolicitudCompra
                                                     where sol_comp.SC_ID.Equals(sol_comp_upd.SC_ID)
                                                     select sol_comp).First<SOLICITUD_COMPRA>();

                solicitud_compra.SC_FECHA = sol_comp_upd.SC_FECHA;
                solicitud_compra.E_ID = sol_comp_upd.E_ID;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(SOLICITUD_COMPRA sol_comp_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_SOLICITUD_COMPRA material;

                try
                {
                    material = (from mat in ctx.ListaSolicitudCompraDetalle
                                where mat.SC_ID.Equals(sol_comp_del.SC_ID)
                                select mat).First<DETALLE_SOLICITUD_COMPRA>();
                }
                catch (Exception e)
                {
                    material = null;
                }

                while (material != null)
                {
                    ctx.ListaSolicitudCompraDetalle.DeleteOnSubmit(material);
                    ctx.SubmitChanges();

                    try
                    {
                        material = (from mat in ctx.ListaSolicitudCompraDetalle
                                    where mat.SC_ID.Equals(sol_comp_del.SC_ID)
                                    select mat).First<DETALLE_SOLICITUD_COMPRA>();
                    }
                    catch (Exception e)
                    {
                        material = null;
                    }

                }


                SOLICITUD_COMPRA borrar = (from sol_comp in ctx.ListaSolicitudCompra
                                           where sol_comp.SC_ID.Equals(sol_comp_del.SC_ID)
                                           select sol_comp).First<SOLICITUD_COMPRA>();

                ctx.ListaSolicitudCompra.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }

        }
    }
}
