using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCUATRI
{
    public partial class MenuInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
        }

        public bool isAdmin()
        {
            if(Session["user"]!= null && ((Dominio.Usuario)Session["user"]).userTipo == Dominio.TipoUsuario.ADMIN)
            {
                return true;
            }
            return false;
        }
        public bool isArtista()
        {
            if (Session["user"] != null && ((Dominio.Usuario)Session["user"]).userTipo == Dominio.TipoUsuario.ARTISTA)
            {
                return true;
            }
            return false;
        }

        protected void btnLugares_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lugares.aspx", false);
        }

    }
}