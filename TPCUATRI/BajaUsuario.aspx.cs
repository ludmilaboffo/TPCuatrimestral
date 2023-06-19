using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCUATRI
{
    public partial class BajaUsuarios_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((Dominio.Usuario)Session["user"]).isAdmin())
            {
                Session.Add("error", "Solo los administradores acceden a esta sección");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}