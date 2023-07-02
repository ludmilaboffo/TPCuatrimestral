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
    public partial class FormularioTurno : System.Web.UI.Page
    {
        LugaresNegocio lugar = new LugaresNegocio();
        FechaNegocio fecha = new FechaNegocio();
        List<Lugar> ListaLugar;
        List<Fecha> ListaFecha;
        public bool confirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
            txtId.Enabled = false;

            if (Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            try
            {
                    ListaLugar= lugar.listar();
                    ListaFecha = fecha.listar();
                if (!IsPostBack)
                {

                    ddlLugar.DataSource = ListaLugar;
                    ddlLugar.DataValueField = "idLugar";
                    ddlLugar.DataTextField = "Nombre";
                    ddlLugar.DataBind();


                    ddlFecha.DataSource = ListaFecha;
                    ddlFecha.DataValueField = "idFecha";
                    ddlFecha.DataTextField = "numeroFecha";
                    ddlFecha.DataBind();
                }
                /// modificamos
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id!= "" && !IsPostBack)
                {
                    TurnosNegocio turno = new TurnosNegocio();
                    Turno selec = (turno.listar(id))[0];
                    Session.Add("TurnoSeleccionado", selec);

                    /// AHORA PRECARGO
                    txtId.Text = id;
                    ddlFecha.SelectedValue = selec.Fecha.idFecha.ToString();
                    ddlLugar.SelectedValue = selec.Lugar.idLugar.ToString();
                    if (!selec.disponibilidad)
                    {
                        btnInhabilitarTurno.Text = "Rehabilitar";
                    }
                    
                } 
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAceptarAlta_Click(object sender, EventArgs e)
        {

            try
            {
                Turno nuevo = new Turno();
                TurnosNegocio negocio = new TurnosNegocio();
                LugaresNegocio lugarNegocio = new LugaresNegocio(); 

                nuevo.Lugar = new Lugar();
                nuevo.Lugar.idLugar = int.Parse(ddlLugar.SelectedValue);
                nuevo.idUsuario = 1;
                nuevo.Fecha = new Fecha();
                nuevo.Fecha.idFecha = int.Parse(ddlFecha.SelectedValue);

                if(Request.QueryString["id"] != null)
                {
                    nuevo.idTurno = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);

                    Response.Redirect("ListadoTurnos.aspx", false);
                }

                if (validarFecha(nuevo))
                {
                    negocio.alta(nuevo);
                    Response.Redirect("ListadoTurnos.aspx", false);
                }
                    Session.Add("error", "Ya un turno en ese lugar en la misma fecha");
                    Response.Redirect("Error.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chConfirmarEliminar.Checked)
                {
                    TurnosNegocio turno = new TurnosNegocio();
                    turno.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListadoTurnos.aspx", false);
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }
        }


        protected void btnActivar_Click(object sender, EventArgs e)
        {

        }

        protected void btnInhabilitarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                TurnosNegocio turno = new TurnosNegocio();
                Turno seleccionado = (Turno)Session["TurnoSeleccionado"];

                turno.eliminarLogico(int.Parse(txtId.Text), !seleccionado.disponibilidad);
                /// busco, negando la disponibilidad, que tenga la opuesta ///
                Response.Redirect("ListadoTurnos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
        public bool validarFecha(Turno nuevo)
        {
            List<Turno> Listaturno;
            TurnosNegocio negocio = new TurnosNegocio();
            Listaturno = negocio.listarSP();       

            foreach(Turno turno in Listaturno)
            {
                if(turno.Fecha.idFecha == nuevo.Fecha.idFecha && turno.Lugar.idLugar == nuevo.Lugar.idLugar)
                {
                    return false;
                }
            }

            return true;
        }
    }

}