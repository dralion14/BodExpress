using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using CORE;

namespace BodExpress
{
    public partial class RecepcionMaterialNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SC_ID"] = 0;
        }

        protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_compra = ASPxComboBox1.SelectedItem.Value.ToString();
            Session["SC_ID"] = Int32.Parse(id_compra);
        }

        protected void Continuar(object sender, EventArgs e)
        {
            string id_compra = ASPxComboBox1.SelectedItem.Value.ToString();
            Session["SC_ID"] = Int32.Parse(id_compra);
        }

        protected void Ingresar(object sender, EventArgs e)
        {
            ASPxButton boton = (ASPxButton)sender;
            Control main = boton.Parent;

            string encargado = "Bodega";
            Label usuario = (Label)main.Parent.Parent.FindControl("lblUsuario");
            if (usuario != null)
                encargado = usuario.Text;

            ASPxListBox list = (ASPxListBox)main.FindControl("ASPxListBox1");
            ASPxComboBox combo = (ASPxComboBox)main.FindControl("ASPxComboBox1");
            string id_compra = ASPxComboBox1.SelectedItem.Value.ToString();

            if (list.Items.Count == 0)
                return;

            SOLICITUD_COMPRA compra = CRUD_SolicitudCompra.Read(Int32.Parse(id_compra));

            RECEPCION_MATERIAL recepcion = new RECEPCION_MATERIAL();
            recepcion.RM_ENCARGADO_RECEPCION = encargado;
            recepcion.RM_FECHA = DateTime.Now;
            CRUD_RecepcionMaterial.Create(recepcion);

            int id_recep = (Int32)CRUD_RecepcionMaterial.getEnd().RM_ID;

            foreach (ListEditItem item in list.Items)
            {
                MATERIAL material = CRUD_Material.Read(Int32.Parse(item.GetValue("M_ID").ToString()));
                DETALLE_RECEPCION_MATERIAL detalle = new DETALLE_RECEPCION_MATERIAL();
                detalle.RM_ID = id_recep;
                detalle.M_ID = material.M_ID;
                detalle.DRM_CANTIDAD = Int32.Parse(item.GetValue("D_CANTIDAD").ToString());

                CRUD_RecepcionMaterialDetalle.Create(detalle);
            }

            compra.E_ID = 2;
                CRUD_SolicitudCompra.Update(compra);

            COMPRA_RECEPCION ligar = new COMPRA_RECEPCION();
            ligar.SC_ID = compra.SC_ID;
            ligar.RM_ID = id_recep;
            CRUD_CompraRecepcion.Create(ligar);

            Response.Redirect("~/RecepcionMaterial.aspx");
        }
    }
}