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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            try
            {

                Artista artista = new Artista();
                ArtistasNegocio artistasNegocio = new ArtistasNegocio();
                ServicioEmail mail = new ServicioEmail();

                artista.mailArtista = txtMailRegistro.Text;
                artista.contrasenaArtista = txtPassRegistro.Text;
                artista.idArtista = artistasNegocio.insertarNuevo(artista);

                mail.correoAEnviar(txtMailRegistro.Text, "¡Te has registado de manera exitosa!", "Bienvenidx al sistema, de ahora en adelante vas a poder loguearte y acceder a los turnos.");
                mail.enviarCorreo();
                Response.Redirect("Default.aspx", false);
            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}