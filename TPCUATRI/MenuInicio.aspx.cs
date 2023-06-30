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
            Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
                if (Session["user"] == null)
                {
                    Session.Add("error", "Debes loguearte para entrar");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    Artista art = new Artista();
                    string nombreUsuario = buscarArtista(usuario.idUsuario);
                    lblHola.Text = "Bienvenido " + nombreUsuario;

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
        public string buscarArtista(int id)
        {
            List<Artista> ListaArtista;
            ArtistasNegocio art = new ArtistasNegocio();
            ListaArtista = art.listar();

            foreach (Artista artista in ListaArtista)
            {
                if (artista.idArtista == id)
                {
                    return artista.nombreArtista;
                }
            }
            return " ";
        }
    }
}