using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CORE;

namespace BodExpress
{
    public partial class LogOn : System.Web.UI.Page
    {
        public const string URL_DEFAULT_UC = "~/DefaultUC.aspx";
        public const string URL_DEFAULT_Bod = "~/DefaultBod.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btoIngreso_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            USUARIO usrLogin = CRUD_Usuario.Login(txtUser.Text, txtPassword.Text);
            if (usrLogin != null)
            {
                this.Master.ActiveUser = usrLogin;
                if (usrLogin.area.Equals("UC"))
                {
                    Response.Redirect(URL_DEFAULT_UC, true);
                }
                else
                {
                    Response.Redirect(URL_DEFAULT_Bod, true);
                }
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                lblError.Visible = true;
            }
        }
    }
}