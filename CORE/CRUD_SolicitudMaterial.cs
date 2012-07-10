using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_SolicitudMaterial
    {

        public static List<SOLICITUD_MATERIAL> getAll(int uc_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var solicitud_material = from sol_mat in ctx.ListaSolicitudMaterial
                                         where sol_mat.UC_ID.Equals(uc_id)
                                         select sol_mat;

                return solicitud_material.ToList<SOLICITUD_MATERIAL>();
            }
        }

        public static SOLICITUD_MATERIAL getEnd()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                List<SOLICITUD_MATERIAL> solicitud_compra = (from sol_comp in ctx.ListaSolicitudMaterial
                                                           orderby sol_comp.SM_ID
                                                           select sol_comp).ToList<SOLICITUD_MATERIAL>();

                return solicitud_compra.Last<SOLICITUD_MATERIAL>();
            }
        }

        public static void Create(SOLICITUD_MATERIAL sol_mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaSolicitudMaterial.InsertOnSubmit(sol_mat_new);
                ctx.SubmitChanges();
            }
        }

        public static SOLICITUD_MATERIAL Read(int sol_mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var solicitud_material = from sol_mat in ctx.ListaSolicitudMaterial
                                   where sol_mat.SM_ID.Equals(sol_mat_id)
                                   select sol_mat;
                    return solicitud_material.First<SOLICITUD_MATERIAL>();
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void Update(SOLICITUD_MATERIAL sol_mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                SOLICITUD_MATERIAL solicitud_material = (from sol_mat in ctx.ListaSolicitudMaterial
                                                         where sol_mat.SM_ID.Equals(sol_mat_upd.SM_ID)
                                                         select sol_mat).First<SOLICITUD_MATERIAL>();

                solicitud_material.E_ID = sol_mat_upd.E_ID;
                solicitud_material.UNI_UC_ID = sol_mat_upd.UNI_UC_ID;
                solicitud_material.UC_ID = sol_mat_upd.UC_ID;
                solicitud_material.SM_TIPO = sol_mat_upd.SM_TIPO;
                solicitud_material.SM_FECHA =sol_mat_upd.SM_FECHA;
                solicitud_material.SM_ID_RECTIFICADA = sol_mat_upd.SM_ID_RECTIFICADA;

                ctx.SubmitChanges();
            }
        }

        public static void Delete(SOLICITUD_MATERIAL sol_mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                SOLICITUD_MATERIAL borrar = (from sol_mat in ctx.ListaSolicitudMaterial
                                             where sol_mat.SM_ID.Equals(sol_mat_del.SM_ID)
                                             select sol_mat).First<SOLICITUD_MATERIAL>();

                ctx.ListaSolicitudMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public class SOLICITUD_UC
        {
            public decimal S_UC { get; set; }
            public decimal SM_ID { get; set; }
            public decimal S_EST { get; set; }
            public decimal S_UC_DEST { get; set; }
            public string S_TIPO { get; set; }
            public int? S_SM_REC { get; set; }
            public DateTime S_FECHA { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType())
                    return false;

                return (S_UC == ((SOLICITUD_UC)obj).S_UC && SM_ID == ((SOLICITUD_UC)obj).SM_ID);
            }
            public override int GetHashCode()
            {
                return this.S_UC.GetHashCode() ^ this.SM_ID.GetHashCode();
            }
        }
    }
}
