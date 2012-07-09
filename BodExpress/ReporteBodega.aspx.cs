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
    }
}