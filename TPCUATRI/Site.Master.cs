using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPCUATRI;

namespace TP_Programacion3
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  if(!(Page is TPCUATRI.Login) || !(Page is Registro))
            if (!seguridad.sesionActiva(Session["user"]))
                Response.Redirect("Login.aspx", false);*/
        }



        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login,aspx");
        }
    }
}