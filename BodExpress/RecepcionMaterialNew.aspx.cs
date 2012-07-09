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
            ASPxGridView1.Visible = false;
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["SC_ID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void ASPxComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Continuar(object sender, EventArgs e)
        {
            string id_compra = ASPxComboBox1.SelectedItem.Value.ToString();
            ASPxGridView1.DataSource = CRUD_SolicitudCompraDetalle.getAll(Int32.Parse(id_compra));
            ASPxGridView1.Visible = true;
        }
    }
}