using Negocio;
using Dominio;
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

            if (!seguridad.sesionActiva(Session["Artista"]) || (imgPerfil.ImageUrl = "~/Img/imgperfil/" + ((Artista)Session["Artista"]).imgPerfil) == null || !seguridad.esArtista((Artista)Session["Artista"]))
            {

                imgPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";
            }
            else
            {
                imgPerfil.ImageUrl = "~/Img/imgperfil/" + ((Artista)Session["Artista"]).imgPerfil;
            }

        }

            protected void Salir_Click(object sender, EventArgs e)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
    }
}