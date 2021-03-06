﻿using System;
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
    public partial class SolicitudCompraNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Continuar(object sender, EventArgs e)
        {
            ASPxButton boton = (ASPxButton)sender;
            Control main = boton.Parent;

            ASPxListBox list = (ASPxListBox)main.FindControl("ASPxListBox1");

            if (list.Items.Count == 0)
                return;

            SOLICITUD_COMPRA compra = new SOLICITUD_COMPRA();
            compra.E_ID = 1;
            compra.SC_FECHA = DateTime.Now;
            CRUD_SolicitudCompra.Create(compra);

            int id_compra = (Int32)CRUD_SolicitudCompra.getEnd().SC_ID;

            foreach (ListEditItem item in list.Items)
            {
                MATERIAL material = CRUD_Material.Read(item.Value.ToString(), 0);
                DETALLE_SOLICITUD_COMPRA detalle = new DETALLE_SOLICITUD_COMPRA();
                detalle.SC_ID = id_compra;
                detalle.M_ID = material.M_ID;
                detalle.DSC_CANTIDAD = material.M_STOCK_IDEAL - material.M_STOCK_REAL;

                CRUD_SolicitudCompraDetalle.Create(detalle);
            }

            Response.Redirect("SolicitudCompra.aspx", true);
        }
    }
}