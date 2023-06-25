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

        protected void btnLugares_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarLugares.aspx", false);
        }

        protected void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("BajaUsuario.aspx", false);
        }

        protected void btnAltaLugar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lugares.aspx", false);
        }

        protected void btnBajaLugar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lugares.aspx", false);
        }

        protected void btnModificarLugar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Lugares.aspx", false);
        }

        protected void btnAltaHorarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTurno.aspx", false);
        }

        protected void btnListarTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoTurnos.aspx", false);
        }
    }
}