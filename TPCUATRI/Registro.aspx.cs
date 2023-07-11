using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Programacion3
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            Artista user = new Artista();
            ArtistasNegocio artistasNegocio = new ArtistasNegocio();

            user.mailArtista = txtMailRegistro.Text;
            user.contrasenaArtista = txtPassRegistro.Text;
            string apellido = apellidoRegistro.Text;
            string nombre = nombreRegistro.Text;
            user.idArtista = artistasNegocio.insertarNuevo(user, nombre, apellido);
            Session.Add("user", user);

            Response.Redirect("MenuInicio.aspx");
        }
    }
}