using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BodExpress
{
    public partial class index : System.Web.UI.Page
    {
        public const string URL_HOME = "~/AppHome.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(URL_HOME, true);
            return;
        }
    }
}