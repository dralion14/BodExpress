using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using CORE;
using DevExpress.Web.ASPxEditors;

namespace BodExpress
{
    public partial class SolicitudMaterialNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteMaster master = (SiteMaster)this.Master.Master;
                UNIDAD_CLINICA uc = CRUD_UnidadClinica.Read(master.ActiveUser.nombre);
                Session["UC_ID"] = Int32.Parse(uc.UC_ID.ToString());

                ASPxComboBox1.Items.Insert(0, new ListEditItem("Bodega"));
                ASPxComboBox1.DataBound += new EventHandler(addItem_DataBound);
            }
        }

        private void addItem_DataBound(object sender, EventArgs e)
        {
            ListEditItem noneItem = new ListEditItem("Bodega", "Bodega");
            (sender as ASPxComboBox).Items.Insert(0, noneItem);
            (sender as ASPxComboBox).SelectedIndex = 0;
        }

        protected void Continuar(object sender, EventArgs e)
        {
            ASPxButton boton = (ASPxButton)sender;
            Control main = boton.Parent;

            ASPxListBox list = (ASPxListBox)main.FindControl("ASPxListBox1");

            if (list.Items.Count == 0)
                return;

            SOLICITUD_MATERIAL solicitud = new SOLICITUD_MATERIAL();
            solicitud.E_ID = 1;
            solicitud.SM_FECHA = DateTime.Now;
            solicitud.UC_ID = Int32.Parse(Session["UC_ID"].ToString());
            string uc = ASPxComboBox1.SelectedItem.Value.ToString();
            if (uc.Equals("Bodega") || uc == null)
                solicitud.UNI_UC_ID = 0;
            else
                solicitud.UNI_UC_ID = CRUD_UnidadClinica.Read(uc).UC_ID;
            solicitud.SM_TIPO = "Primaria";
            solicitud.SM_ID_RECTIFICADA = 0;
            CRUD_SolicitudMaterial.Create(solicitud);

            int id_sol = (Int32)CRUD_SolicitudMaterial.getEnd().SM_ID;

            foreach (ListEditItem item in list.Items)
            {
                MATERIAL material = CRUD_Material.Read(item.Value.ToString(), 0);
                DETALLE_SOLICITUD_MATERIAL detalle = new DETALLE_SOLICITUD_MATERIAL();
                detalle.SM_ID = id_sol;
                detalle.M_ID = material.M_ID;
                detalle.DSM_CANTIDAD = CRUD_UnidadStock.Read(Int32.Parse(material.M_ID.ToString()), Int32.Parse(solicitud.UC_ID.ToString())).SMU_STOCK_IDEAL - CRUD_UnidadStock.Read(Int32.Parse(material.M_ID.ToString()), Int32.Parse(solicitud.UC_ID.ToString())).SMU_STOCK_REAL;

                CRUD_SolicitudMaterialDetalle.Create(detalle);
            }

            Response.Redirect("SolicitudMaterial.aspx", true);
        }
    }
}