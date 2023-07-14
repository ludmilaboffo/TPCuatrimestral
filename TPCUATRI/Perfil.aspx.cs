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
        public bool confirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
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

                        seleccionado.imgPerfil = "Perfil-" + seleccionado.idArtista + ".jpg".ToString();
                        imgFotoPerfil.ImageUrl = "~/Img/imgperfil/" + seleccionado.imgPerfil;

                    }
                    else
                    {
                        Session.Add("error", "Si quiere ver un perfil, debe registrarse o iniciar sesion.");
                        Response.Redirect("Error.aspx", false);
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
            Response.Redirect("MenuInicio.aspx", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)

        {
            try
            {
                if (IsPostBack)
                {
                  
                    ArtistasNegocio negocio = new ArtistasNegocio();
                    Artista user = (Artista)Session["Artista"];
                    string ruta = Server.MapPath("./Img/imgperfil/ ");
                    txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + user.idArtista + ".jpg");

                    user.imgPerfil = "Perfil-" + user.idArtista + ".jpg"; //agregar campo de imagen a usuarios
                    user.nombreArtista = txtNombre.Text;
                    user.apellidoArtista = txtApellido.Text;
                    user.tipoEspectaculo = txtTipoEspectaculo.Text;
                    user.redesSociales = txtRedes.Text;
                    user.telefonoArtista = txtTelefono.Text;

                    negocio.actualizar(user);
                    Image img = (Image)Master.FindControl("ImgPerfil");
                    imgFotoPerfil.ImageUrl = "~/Img/imgperfil/" + user.imgPerfil;
                    img.ImageUrl= "~/Img/imgperfil/" + user.imgPerfil;
                    Response.Redirect("Menuinicio.aspx",false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {

            try
            {
                if (chEliminar.Checked)
                {
                    ArtistasNegocio artista = new ArtistasNegocio();
                    Artista user = (Artista)Session["Artista"];
                    artista.eliminarLogico(user.idArtista);
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}