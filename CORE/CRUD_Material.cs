using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORE
{
    public class CRUD_Material
    {
        public static List<MATERIAL> getAll()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.ListaMaterial
                               where !mat.M_TIPO.Equals("Kit")
                               orderby mat.M_ID
                               select mat;

                return material.ToList<MATERIAL>();
            }
        }

        public static List<MATERIAL_FALTANTE> getAllComprar()
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.ListaMaterial
                               orderby mat.M_ID
                               select new MATERIAL_FALTANTE
                               {
                                   M_ID = mat.M_ID,
                                   M_NOMBRE = mat.M_NOMBRE,
                                   M_TIPO = mat.M_TIPO,
                                   M_CANTIDAD = mat.M_STOCK_IDEAL - mat.M_STOCK_REAL
                               };

                return material.ToList<MATERIAL_FALTANTE>();
            }
        }

        public static List<MATERIAL_FALTANTE> getAllUC(int uc_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.ListaStockMaterialUnidad
                               where mat.UC_ID.Equals(uc_id)
                               orderby mat.M_ID
                               select new MATERIAL_FALTANTE
                               {
                                   M_ID = mat.M_ID,
                                   M_NOMBRE = CRUD_Material.Read(Int32.Parse(mat.M_ID.ToString())).M_NOMBRE,
                                   M_TIPO = CRUD_Material.Read(Int32.Parse(mat.M_ID.ToString())).M_TIPO,
                                   M_CANTIDAD = mat.SMU_STOCK_IDEAL - mat.SMU_STOCK_REAL
                               };

                return material.ToList<MATERIAL_FALTANTE>();
            }
        }

        public static void updateComprar(MATERIAL_FALTANTE mat_upd)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL_FALTANTE material = (from mat in CRUD_Material.getAllComprar()
                               where mat.M_ID.Equals(mat_upd.M_ID)
                               select mat).First<MATERIAL_FALTANTE>();

                material.M_CANTIDAD = mat_upd.M_CANTIDAD;
                ctx.SubmitChanges();
            }
        }

        public static List<MATERIAL> getAllKit()
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

        public static List<MATERIAL> getMaterial(long? mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                var material = from mat in ctx.ListaMaterial
                               where mat.M_ID.Equals(mat_id)
                               orderby mat.M_ID
                               select mat;

                return material.ToList<MATERIAL>();
            }
        }

        public static void Create(MATERIAL mat_new)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                mat_new.M_STOCK_IDEAL = 100;
                mat_new.M_STOCK_BAJO = 1;
                mat_new.M_STOCK_REAL = 0;
                ctx.ListaMaterial.InsertOnSubmit(mat_new);
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

        public static string ReadNombre(int mat_id)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    var material = from mat in ctx.ListaMaterial
                                   where mat.M_ID.Equals(mat_id)
                                   select mat;
                    return material.First<MATERIAL>().M_NOMBRE;
                }
                catch
                {
                    return "";
                }
            }
        }

        public static int Read(String nombre)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    MATERIAL material = (from mat in ctx.ListaMaterial
                                         where mat.M_NOMBRE.Equals(nombre)
                                         select mat).First<MATERIAL>();
                    return Convert.ToInt32(material.M_ID);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static MATERIAL Read(String nombre, int a)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                try
                {
                    MATERIAL material = (from mat in ctx.ListaMaterial
                                         where mat.M_NOMBRE.Equals(nombre)
                                         select mat).First<MATERIAL>();
                    return material;
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

        public static void Delete(MATERIAL mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL borrar = (from mat in ctx.ListaMaterial
                                   where mat.M_ID.Equals(mat_del.M_ID)
                                   select mat).First<MATERIAL>();

                ctx.ListaMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public static void DeleteKit(MATERIAL mat_del)
        {
            using (BODEXDataContext ctx = new BODEXDataContext())
            {
                MATERIAL_KIT material;

                try
                {
                    material = (from mat in ctx.ListaMaterialKit
                                where mat.M_ID.Equals(mat_del.M_ID)
                                select mat).First<MATERIAL_KIT>();
                }
                catch (Exception e)
                {
                    material = null;
                }

                while (material != null)
                {
                    ctx.ListaMaterialKit.DeleteOnSubmit(material);
                    ctx.SubmitChanges();

                    try
                    {
                        material = (from mat in ctx.ListaMaterialKit
                                    where mat.M_ID.Equals(mat_del.M_ID)
                                    select mat).First<MATERIAL_KIT>();
                    }
                    catch (Exception e)
                    {
                        material = null;
                    }
                    
                }

                MATERIAL borrar = (from mat in ctx.ListaMaterial
                                   where mat.M_ID.Equals(mat_del.M_ID)
                                   select mat).First<MATERIAL>();

                ctx.ListaMaterial.DeleteOnSubmit(borrar);
                ctx.SubmitChanges();
            }
        }

        public class MATERIAL_FALTANTE
        {
            public decimal M_ID { get; set; }
            public string M_NOMBRE { get; set; }
            public string M_TIPO { get; set; }
            public Int32 M_CANTIDAD { get; set; }
            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType())
                    return false;

                return (M_ID == ((MATERIAL_FALTANTE)obj).M_ID);
            }
            public override int GetHashCode()
            {
                return this.M_ID.GetHashCode();
            }
        }
    }
}
