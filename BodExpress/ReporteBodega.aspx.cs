using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BodExpress
{
    public partial class ReporteBodega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ReporteMaterial(object sender, EventArgs e)
        {
            Response.Redirect("~/ReporteMaterial.aspx", true);
        }
 
        public void ReporteSolicitudCompra(object sender, EventArgs e)
        {
            Response.Redirect("~/ReporteSolicitudCompra.aspx", true);
        }

        public void ReporteDevolucionMaterial(object sender, EventArgs e)
        {
            Response.Redirect("~/ReporteDevolucionMaterial.aspx", true);
        }
        public void ReporteSolicitudMaterial(object sender, EventArgs e)
        {
            Response.Redirect("~/ReporteSolicitudMaterial.aspx", true);
        }
        public void ReporteRecepcionMaterial(object sender, EventArgs e)
        {
            Response.Redirect("~/ReporteRecepcionMaterial.aspx", true);
        }
    }
}