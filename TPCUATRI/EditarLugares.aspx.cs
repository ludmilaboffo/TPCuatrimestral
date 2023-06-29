using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCUATRI
{
    public partial class EditarLugares : System.Web.UI.Page

    {
        public Lugar lugaress { get; set; }
        public Lugar Lugar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
            if (usuario != null)
                if (usuario.isAdmin()) //TIRA ERROR DE REFERENCIA
                {
                    Session.Add("error", "Solo los administradores acceden a esta sección");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                        if (id != "" && !IsPostBack)
                        {
                            LugaresNegocio lugares = new LugaresNegocio();
                            Lugar seleccionado = (lugares.listar(id))[0];
                            Session.Add("lugarSeleccionado", seleccionado);
                            txtID.Enabled = false;
                            txtID.Text = id;
                            txtNombre.Text = seleccionado.Nombre;
                            txtDescripcion.Text = seleccionado.Descripcion;

                            imgLugar.ImageUrl = seleccionado.UrlImagen.ToString();
                            if (!seleccionado.Disponibilidad)
                                btnEliminarLugar.Text = "Reactivar";

                        }
                    }
                }

        }

        protected void btnEliminarLugar_Click(object sender, EventArgs e)
        {
            LugaresNegocio lugares = new LugaresNegocio();
            Lugar seleccionado = (Lugar)Session["lugarSeleccionado"];

            lugares.eliminarLogico(seleccionado.idLugar, !seleccionado.Disponibilidad);
            Response.Redirect("Lugares.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Lugar nuevo = new Lugar();
                LugaresNegocio negocio = new LugaresNegocio();
                if (Request.QueryString["id"] != null)
                {
                    nuevo.idLugar = int.Parse(txtID.Text);
                    nuevo.Descripcion = txtDescripcion.Text;
                    nuevo.Direccion = txtDireccion.Text;
                    nuevo.Nombre = txtNombre.Text;
                    nuevo.UrlImagen = imgLugar.ImageUrl;
                    negocio.ModificarConSP(nuevo);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoLugares.aspx");
        }
    }
}