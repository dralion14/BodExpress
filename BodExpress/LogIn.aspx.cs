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
        public const string URL_DEFAULT_Adm = "~/DefaultAdm.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.userName.Visible = false;
            this.Master.salir.Visible = false;
        }

        public string URL_DEFAULT(string area)
        {
            if (area.Equals("UC"))
            {
                return URL_DEFAULT_UC;
            }
            else if (area.Equals("Bod"))
            {
                return URL_DEFAULT_Bod;
            }
            else
            {
                return URL_DEFAULT_Adm;
            }
        }

        protected void btoIngreso_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            USUARIO usrLogin = CRUD_Usuario.Login(txtUser.Text, txtPassword.Text);
            if (usrLogin != null)
            {
                this.Master.ActiveUser = usrLogin;
                if (this.Master.URL_ORIGINAL == null)
                    Response.Redirect(URL_DEFAULT(usrLogin.area));
                else
                {

                    if (this.Master.TienePermiso(this.Master.URL_ORIGINAL))
                    {
                        string url_red = this.Master.URL_REDIRECT;
                        this.Master.URL_REDIRECT = null;
                        this.Master.URL_ORIGINAL = null;
                        Response.Redirect(url_red);
                    }
                    else
                    {
                        this.Master.URL_ORIGINAL = null;
                        this.Master.URL_REDIRECT = null;
                        Response.Redirect(URL_DEFAULT(usrLogin.area));
                    }
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