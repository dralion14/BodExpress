﻿using System;
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
    public partial class MaterialUC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label usuario = (Label)this.FindControl("lblUsuario");
            UNIDAD_CLINICA uc = CRUD_UnidadClinica.Read(usuario.Text);
            Session["UC_ID"] = Int32.Parse(uc.UC_ID.ToString());
        }
    }
}