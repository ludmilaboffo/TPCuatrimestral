using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace TPCUATRI
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (seguridad.esArtista(Session["Artista"]))
                    {
                        ArtistasNegocio artista = new ArtistasNegocio();
                        Artista usuario = (Artista)Session["Artista"];
                        int id = usuario.idArtista;


                        Artista seleccionado = artista.listar(id.ToString())[0];

                        txtNombre.Text = seleccionado.nombreArtista;
                        txtApellido.Text = seleccionado.apellidoArtista;
                        txtRedes.Text = seleccionado.redesSociales;
                        txtTipoEspectaculo.Text = seleccionado.tipoEspectaculo;
                        txtTelefono.Text = seleccionado.telefonoArtista;
                        imgFotoPerfil.DescriptionUrl = seleccionado.imgPerfil;
                        seleccionado.imgPerfil = "Perfil-" + seleccionado.idArtista + ".jpg".ToString();
                    }
                    else
                    {
                        Session.Add("error", "Si quiere ver un perfil, vaya a la seccion de baja de usuarios");
                        Response.Redirect("Error.aspx");
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnatras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuInicio.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)

        {
            try
            {
                if (!IsPostBack)
                {
                    ArtistasNegocio negocio = new ArtistasNegocio();
                    Artista user = (Artista)Session["Artista"];
                    string ruta = Server.MapPath("./ImgPerfil/");
                    txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + user.idArtista + ".jpg");

                    user.imgPerfil = "Perfil-" + user.idArtista + ".jpg"; //agregar campo de imagen a usuarios
                    user.nombreArtista = txtNombre.Text;
                    user.apellidoArtista = txtApellido.Text;
                    user.tipoEspectaculo = txtTipoEspectaculo.Text;
                    user.redesSociales = txtRedes.Text;
                    user.telefonoArtista = txtTelefono.Text;

                    negocio.actualizar(user);
                    Response.Redirect("Menuinicio.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}