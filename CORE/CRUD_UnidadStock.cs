using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_UnidadStock
    {

        public static List<STOCK_MATERIAL_UNIDAD> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var stock_unidad = from stock_un in ctx.ListaStockMaterialUnidad
                               orderby stock_un.M_ID, stock_un.UC_ID
                               select stock_un;

                return stock_unidad.ToList<STOCK_MATERIAL_UNIDAD>();
            }
        }

        public static List<MATERIAL_UC> getAll(int uc_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var stock_unidad = from stock_un in ctx.ListaStockMaterialUnidad
                                   where stock_un.UC_ID.Equals(uc_id)
                                   orderby stock_un.M_ID
                                   select new MATERIAL_UC
                                   {
                                       M_ID = Int32.Parse(stock_un.M_ID.ToString()),
                                       M_NOMBRE = CRUD_Material.ReadNombre(Int32.Parse(stock_un.M_ID.ToString())),
                                       M_STOCK_IDEAL = stock_un.SMU_STOCK_IDEAL,
                                       M_STOCK_REAL = stock_un.SMU_STOCK_REAL,
                                       M_STOCK_BAJO = stock_un.SMU_STOCK_BAJO,
                                       UC_ID = Int32.Parse(stock_un.UC_ID.ToString())
                                   };

                return stock_unidad.ToList<MATERIAL_UC>();
            }
        }

        public static void Create(STOCK_MATERIAL_UNIDAD stockmatunidad_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                ctx.ListaStockMaterialUnidad.InsertOnSubmit(stockmatunidad_new);
                ctx.SubmitChanges();
            }
        }


        public static STOCK_MATERIAL_UNIDAD Read(int mat_id, int unidad_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var stock_unidad = from stock_un in ctx.ListaStockMaterialUnidad
                                   where stock_un.M_ID.Equals(mat_id) && stock_un.UC_ID.Equals(unidad_id)
                                   select stock_un;
                    return stock_unidad.First<STOCK_MATERIAL_UNIDAD>();
                }
                catch
                {
                    return null;
                }
            }
        }


        public static void Update(STOCK_MATERIAL_UNIDAD stock_mat_unidad_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                STOCK_MATERIAL_UNIDAD stock_unidad = (from stock_un in ctx.ListaStockMaterialUnidad
                                     where stock_un.M_ID.Equals(stock_mat_unidad_upd.M_ID) &&
                                            stock_un.UC_ID.Equals(stock_mat_unidad_upd.UC_ID)
                                     select stock_un).First<STOCK_MATERIAL_UNIDAD>();

                stock_unidad.M_ID = stock_mat_unidad_upd.M_ID;
                stock_unidad.SMU_STOCK_REAL = stock_mat_unidad_upd.SMU_STOCK_REAL;
                stock_unidad.SMU_STOCK_IDEAL = stock_mat_unidad_upd.SMU_STOCK_IDEAL;
                stock_unidad.UC_ID = stock_mat_unidad_upd.UC_ID;
               

                ctx.SubmitChanges();
            }
        }


        public static void Delete(STOCK_MATERIAL_UNIDAD stock_mat_unidad_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                STOCK_MATERIAL_UNIDAD borrar = (from stock_un in ctx.ListaStockMaterialUnidad
                                   where  stock_un.M_ID.Equals(stock_mat_unidad_del.M_ID)
                                          && stock_un.UC_ID.Equals(stock_mat_unidad_del.UC_ID) 
                                   select stock_un).First<STOCK_MATERIAL_UNIDAD>();

                ctx.ListaStockMaterialUnidad.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

    }

    public class MATERIAL_UC
    {
        public Int32 M_ID { get; set; }
        public Int32 UC_ID { get; set; }
        public string M_NOMBRE { get; set; }
        public Int32 M_STOCK_REAL { get; set; }
        public Int32 M_STOCK_IDEAL { get; set; }
        public Int32 M_STOCK_BAJO { get; set; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            return (M_ID == ((MATERIAL_UC)obj).M_ID &&
                UC_ID == ((MATERIAL_UC)obj).UC_ID);
        }
        public override int GetHashCode()
        {
            return this.M_ID.GetHashCode() ^ this.UC_ID.GetHashCode();
        }
    }
}
