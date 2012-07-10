using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_SolicitudCompraDetalle
    {

        public static List<DETALLE_SOLICITUD> getAll(int sc_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var detalle_sol_comp = from det_sol_comp in ctx.ListaSolicitudCompraDetalle
                                       where det_sol_comp.SC_ID.Equals(sc_id)
                                       select new DETALLE_SOLICITUD
                                       {
                                           SC_ID = det_sol_comp.SC_ID,
                                           M_ID = det_sol_comp.M_ID,
                                           M_NOMBRE = CRUD_Material.ReadNombre(Int32.Parse(det_sol_comp.M_ID.ToString())),
                                           D_CANTIDAD = det_sol_comp.DSC_CANTIDAD
                                       };

                return detalle_sol_comp.ToList<DETALLE_SOLICITUD>();
            }
        }

        public static void Create(DETALLE_SOLICITUD_COMPRA det_sol_comp_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaSolicitudCompraDetalle.InsertOnSubmit(det_sol_comp_new);
                ctx.SubmitChanges();
            }
        }

        public static DETALLE_SOLICITUD_COMPRA Read(int sc_mat_id, int m_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var detalle_sol_comp = from det_sol_comp in ctx.ListaSolicitudCompraDetalle
                                           where det_sol_comp.SC_ID.Equals(sc_mat_id) && det_sol_comp.M_ID.Equals(m_mat_id)
                                           select det_sol_comp;
                    return detalle_sol_comp.First<DETALLE_SOLICITUD_COMPRA>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(DETALLE_SOLICITUD_COMPRA det_sol_comp_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_SOLICITUD_COMPRA detalle_sol_comp = (from det_sol_comp in ctx.ListaSolicitudCompraDetalle
                                                             where det_sol_comp.M_ID.Equals(det_sol_comp_upd.SC_ID)
                                     && det_sol_comp.SC_ID.Equals(det_sol_comp_upd.SC_ID)
                                                             select det_sol_comp).First<DETALLE_SOLICITUD_COMPRA>();

                detalle_sol_comp.DSC_CANTIDAD = det_sol_comp_upd.DSC_CANTIDAD;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(DETALLE_SOLICITUD_COMPRA det_sol_comp_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                DETALLE_SOLICITUD_COMPRA borrar = (from det_sol_comp in ctx.ListaSolicitudCompraDetalle
                                                   where det_sol_comp.M_ID.Equals(det_sol_comp_del.M_ID)
                                                   && det_sol_comp.SC_ID.Equals(det_sol_comp_del.SC_ID)
                                                   select det_sol_comp).First<DETALLE_SOLICITUD_COMPRA>();

                ctx.ListaSolicitudCompraDetalle.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public class DETALLE_SOLICITUD
        {
            public decimal SC_ID { get; set; }
            public decimal M_ID { get; set; }
            public string M_NOMBRE { get; set; }
            public Int32 D_CANTIDAD { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType())
                    return false;

                return (SC_ID == ((DETALLE_SOLICITUD)obj).SC_ID && M_ID == ((DETALLE_SOLICITUD)obj).M_ID);
            }
            public override int GetHashCode()
            {
                return this.SC_ID.GetHashCode() ^ this.M_ID.GetHashCode();
            }
        }
    }
}
