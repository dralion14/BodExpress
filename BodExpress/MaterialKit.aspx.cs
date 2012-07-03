using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using CORE;

namespace BodExpress
{
    public partial class MaterialKit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["M_ID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void GRID_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            ASPxTextBox txtNombre = (ASPxTextBox)grid.FindEditFormTemplateControl("ASPxNombre");
            ASPxListBox cmbMateriales = (ASPxListBox)grid.FindEditFormTemplateControl("ASPxListBox");

            MATERIAL newKit = new MATERIAL();
            newKit.M_NOMBRE = txtNombre.Text;
            newKit.M_TIPO = "Kit";
            newKit.M_MEDIDA_COMPRA = 1;
            newKit.M_MEDIDA_DISTRIBUCION = 1;
            newKit.M_STOCK_BAJO = 1;
            newKit.M_STOCK_IDEAL = 1;
            newKit.M_STOCK_REAL = 1;

            CRUD_Material.Create(newKit);
            int kit_id = CRUD_Material.Read(newKit.M_NOMBRE);

            foreach (ListEditItem item in cmbMateriales.Items)
            {
                MATERIAL_KIT mat = new MATERIAL_KIT();
                    mat.M_ID = kit_id;
                    mat.MAT_M_ID = CRUD_Material.Read(item.Value.ToString());
                    mat.MK_CANTIDAD = 1;

                    CRUD_Kit.Create(mat);
            }

            e.Cancel = true;
            grid.CancelEdit();
        }
    }
}