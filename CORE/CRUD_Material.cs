﻿using System;
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
    }
}
