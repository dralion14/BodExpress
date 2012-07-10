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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public const string URL_LOGIN = "~/LogIn.aspx";
        public const string URL_SINACC = "~/SinPermiso.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && !Page.IsCallback)
            {
                lblUsuario.Visible = false;
                lnkSalir.Visible = false;

                //Si hay un usuario activo pero no se debe redireccionar
                if (ActiveUser != null)
                {
                    //pregunto si tiene permiso
                    //this.generaMenu();
                    if (!TienePermiso(Request.AppRelativeCurrentExecutionFilePath))
                    {
                        //Si no tiene permiso se redirige
                        //Response.Redirect(, true);
                        PAGINA Pag = CRUD_Usuario.getPagina(Request.AppRelativeCurrentExecutionFilePath);
                        if (Pag == null)
                            PaginaSinPermiso = "S/I";
                        else
                            PaginaSinPermiso = Pag.P_TEXTO;

                        Response.Redirect(URL_SINACC, true);
                        return;
                    }
                    //Usuario con permiso y logueado
                    lblUsuario.Visible = true;
                    lnkSalir.Visible = true;
                    this.lblUsuario.Text = String.Format("{0}", ActiveUser.nombre);
                    Session["SessionIDActiveUser"] = ActiveUser.nombre;
                }
                else  //Usuario no logueado
                {

                    //Si va al login que siga de largo
                    if (Request.AppRelativeCurrentExecutionFilePath.Contains(URL_LOGIN))
                        return;

                    //si no va al login
                    //Se guarda la página a la que va
                    URL_ORIGINAL = Request.AppRelativeCurrentExecutionFilePath;
                    URL_REDIRECT = "~/" + Request.RawUrl;
                    //se redirige
                    Response.Redirect(URL_LOGIN, true);
                    return;
                }

            }
        }

        public Label userName
        {
            get
            {
                return lblUsuario;
            }
        }

        public LinkButton salir
        {
            get
            {
                return lnkSalir;
            }
        }

        public USUARIO ActiveUser
        {
            get
            {
                if (Session["ACTIVE_USER"] == null)
                    return null;
                else
                    return (USUARIO)Session["ACTIVE_USER"];
            }
            set
            {
                Session["ACTIVE_USER"] = value;
            }
        }
        public string PaginaSinPermiso
        {
            get
            {
                if (Session["PAG_SIN_PER"] == null)
                    return null;
                else
                    return Session["PAG_SIN_PER"].ToString();
            }
            set
            {
                Session["PAG_SIN_PER"] = value;
            }
        }
        public string URL_ORIGINAL
        {
            get
            {
                if (Session["URL_ORIGINAL"] == null)
                    return null;
                else
                    return Session["URL_ORIGINAL"].ToString();
            }
            set
            {
                Session["URL_ORIGINAL"] = value;
            }
        }
        public string URL_REDIRECT
        {
            get
            {
                if (Session["URL_REDIRECT"] == null)
                    return null;
                else
                    return Session["URL_REDIRECT"].ToString();
            }
            set
            {
                Session["URL_REDIRECT"] = value;
            }
        }
        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            ActiveUser = null;
            Session.Abandon();
            Response.Redirect(URL_LOGIN, true);
        }
        public bool TienePermiso(string urlConsulta)
        {
            return CRUD_Usuario.TienePermiso(this.ActiveUser,
                                            urlConsulta);
        }
    }
}
