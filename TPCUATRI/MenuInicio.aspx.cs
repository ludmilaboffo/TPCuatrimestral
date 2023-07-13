using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dominio;
using Negocio;
using System.Web.UI.WebControls;


namespace TPCUATRI
{
    public partial class MenuInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (seguridad.esArtista(Session["Artista"]))
            {
                ArtistasNegocio art = new ArtistasNegocio();
                Artista usuario = (Artista)Session["Artista"];
                string nombreUsuario = art.buscarArtista(usuario.idArtista);
                lblHola.Text = nombreUsuario;
            }
        }

        protected void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("BajaUsuario.aspx", false);
        }

        protected void btnListarTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoTurnos.aspx", false);
        }

        protected void btnListadoLugares_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoLugares.aspx", false);
        }
      

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }

        protected void btnNuevoTurnoART_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoLugares.aspx", false);
        }

        protected void btnAgendaArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgendaArtista.aspx", false);
        }
    }
}