using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace TP_Programacion3
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArtistasNegocio negocio = new ArtistasNegocio();
                Artista user = (Artista)Session["Artista"];
                string ruta = Server.MapPath("./ImgPerfil/");
                txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + user.idArtista + ".jpg");

                user.imgPerfil = "Perfil-" + user.idArtista + ".jpg"; //agregar campo de imagen a usuarios
                user.nombreArtista = txtNombre.Text;
                user.apellidoArtista = txtApellido.Text;
                user.direccionArtista = txtDireccion.Text;
                user.telefonoArtista = txtTelefono.Text;

                negocio.actualizar(user);
                Response.Redirect("Menuinicio.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}