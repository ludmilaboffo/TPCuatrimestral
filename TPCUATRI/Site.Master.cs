﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPCUATRI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Default) && !(Page is Registro) && !(Page is BusquedaInvitado) && !(Page is Login) && !(Page is Error))
            {
                if (!seguridad.sesionActiva(Session["Artista"]))
                {
                    
                    Response.Redirect("Default.aspx");

                }
            }
        }



        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}