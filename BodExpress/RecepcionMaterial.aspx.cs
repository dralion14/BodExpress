﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

namespace BodExpress
{
    public partial class EntregaMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["RM_ID"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void Nuevo(object sender, EventArgs e)
        {
            Response.Redirect("RecepcionMaterialNew.aspx", true);
        }
    }
}