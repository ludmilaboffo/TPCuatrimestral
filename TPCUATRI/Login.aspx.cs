using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCUATRI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            Artista artista = new Artista();
            ArtistasNegocio negocio = new ArtistasNegocio();
   
            try
            {

                artista.mailArtista = txtMailLogin.Text;
                artista.contrasenaArtista = txtPassLogin.Text;
                if (negocio.Loguearse(artista))
                {
                    if (artista.estadoArtista)
                    {
                        Session.Add("Artista", artista);
                        Response.Redirect("MenuInicio.aspx", false);
                    }
                    else{
                        Session.Add("error", "Usted ha sido dado de baja por el administrador. No puede ingresar al sistema.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "Email o password incorrecto");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
    }
}