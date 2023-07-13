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
        public bool eliminarLugar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            txtID.Enabled = false;
            if (seguridad.esArtista(Session["Artista"]))
            {
                Session.Add("error", "Solo los administradores pueden acceder a esta sección");
                Response.Redirect("Error.aspx");
            }
            try
            {
                string id = Request.QueryString["idLugar"] != null ? Request.QueryString["idLugar"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    LugaresNegocio lugares = new LugaresNegocio();
                    Lugar seleccionado = (lugares.listar(id))[0];
                    Session.Add("lugarSeleccionado", seleccionado);
                    txtID.Text = seleccionado.idLugar.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDireccion.Text = seleccionado.Direccion;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImgLugar.Text = seleccionado.UrlImagen.ToString();
                    if (!seleccionado.Disponibilidad)
                    {
                        btnInhabilitar.Text = "Rehabilitar";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                Lugar nuevo = new Lugar();
                LugaresNegocio negocio = new LugaresNegocio();
 
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.UrlImagen = txtImgLugar.Text;

                if (Request.QueryString["idLugar"] != null)
                {
                    nuevo.idLugar = int.Parse(txtID.Text);
                    
                    negocio.ModificarConSP(nuevo);
                    if (lugarOcupado(nuevo.idLugar))
                    {
                        TurnosNegocio turno = new TurnosNegocio();
                        turno.bajaLugar(nuevo.idLugar); /// Esto llama a un SP que hace un UPDATE
                                                       /// de "Ocupado" a 0 en todos los turnos que ocupen ese lugar.
                    }
                    Response.Redirect("ListadoLugares.aspx", false);
                }
                else
                {

                     negocio.alta(nuevo);
                }
                Response.Redirect("ListadoLugares.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoLugares.aspx");
        }

        protected void btnConfirmarLugares_Click(object sender, EventArgs e)
        {
            eliminarLugar = true;
            upEliminar.Update();
        }

        protected void btnEliminarLugar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (chConfirmarEliminarLugares.Checked)
                {
                    LugaresNegocio lugar = new LugaresNegocio();
                    lugar.eliminar(int.Parse(txtID.Text));
                    Response.Redirect("ListadoLugares.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void txtImgLugar_TextChanged(object sender, EventArgs e)
        {
            imgLugar.ImageUrl = txtImgLugar.Text;
        }

        protected void btnInhabilitar_Click(object sender, EventArgs e)
        {

            LugaresNegocio negocio = new LugaresNegocio();
            Lugar seleccionado = (Lugar)Session["LugarSeleccionado"];

            negocio.eliminarLogico(int.Parse(txtID.Text), !seleccionado.Disponibilidad);    
            Response.Redirect("ListadoLugares.aspx");


        }
        public bool lugarOcupado(int idLugar)
        {
            List<Turno> Listaturno;
            TurnosNegocio negocio = new TurnosNegocio();
            Listaturno = negocio.listarSP();

            foreach (Turno turno in Listaturno)
            {
                if (turno.Lugar.idLugar == idLugar)
                {
                    return true;
                }
            }
            return false;
        }
    }
}