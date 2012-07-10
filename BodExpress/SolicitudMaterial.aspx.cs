using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using CORE;

namespace BodExpress
{
    public partial class SolicitudMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMaster master = (SiteMaster)this.Master.Master;
            UNIDAD_CLINICA uc = CRUD_UnidadClinica.Read(master.ActiveUser.nombre);
            try
            {
                Session["S_UC"] = Int32.Parse(uc.UC_ID.ToString());
            }
            catch
            {
                Session["S_UC"] = 0;
            }
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["SM_ID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void Nuevo(object sender, EventArgs e)
        {
            Response.Redirect("SolicitudMaterialNew.aspx", true);
        }
    }
}