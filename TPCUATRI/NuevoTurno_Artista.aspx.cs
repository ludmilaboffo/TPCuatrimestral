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
    public partial class NuevoTurno_Artista : System.Web.UI.Page
    {
        FechaNegocio fecha = new FechaNegocio();
        public bool confirmarFecha = false;
        Turno turno = new Turno();
        public string idFechaTurno { get; set; }
        public bool fechaLibre { get; set; }
        public string idLugar { get; set; }
        List<Fecha> listaFechas;


        protected void Page_Load(object sender, EventArgs e)
        {
            fechaLibre = true;
            Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
            if (usuario == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            try
            {
                idLugar = Request.QueryString["idLugar"] != null ? Request.QueryString["idLugar"].ToString() : "";
                listaFechas = fecha.listarFiltrado(idLugar.ToString());
                listaFechas.RemoveAll(f => f.Estado == false);

                if (!IsPostBack)
                {
                    if (listaFechas.Count > 0 && listaFechas!= null)
                    {
                        ddlFecha.DataSource = listaFechas;
                        ddlFecha.DataValueField = "idFecha";
                        ddlFecha.DataTextField = "numeroFecha";
                        ddlFecha.DataBind();
                        idFechaTurno = ddlFecha.SelectedValue;

                        FechaNegocio fecha = new FechaNegocio();
                        Fecha selec = (fecha.listarFiltrado(idLugar))[0];
                        Session.Add("FechaSeleccionada", selec);

                        /// AHORA PRECARGO
                        ddlFecha.SelectedValue = selec.ToString();
                    }
                    else
                    {
                        fechaLibre = false;
                        ddlFecha.Visible = false;
                        lblNoHayTurno.Text = "Lo sentimos. Parece que no hay turnos para el lugar elegido.";
                    }
                }
            }

            ////--------------
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
        protected void btnSelecionarFecha_Click(object sender, EventArgs e)
        {
            confirmarFecha = true;
            divConfirmarTurno.Visible = true;
            divConfirmado.Visible = false;
            divFecha.Visible = false;
            divLugar.Visible = false;
        }

        protected void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            Usuario usuario = HttpContext.Current.Session["user"] as Usuario;
            ArtistasNegocio negocio = new ArtistasNegocio();
            string id = negocio.buscarArtista(usuario.idUsuario);
            Turno turno = new Turno();
            TurnosNegocio date = new TurnosNegocio();
            FechaNegocio dia = new FechaNegocio();
            LugaresNegocio place = new LugaresNegocio();

            /// al nuevo turno le guardo el id de la fecha, el id del turno y el id del lugar
            turno.idUsuario = usuario.idUsuario;

            turno.Lugar = new Lugar();
            turno.Fecha = new Fecha();
            turno.Lugar.idLugar = int.Parse(idLugar);
            turno.Fecha.idFecha = int.Parse(ddlFecha.SelectedValue);
            if (!existe(turno))
            {
                date.altaSP(turno);
                divConfirmarTurno.Visible = false;
                divConfirmado.Visible = true;
                divFecha.Visible = true;
                divLugar.Visible = true;
                lblConfirmado.Text = "Su turno ha sido confirmado. Puede verlo en la agenda";
                lblFecha.Text = dia.fechaReservada(turno.Fecha.idFecha);
                lblLugar.Text = place.buscarLugar(turno.Lugar.idLugar);
            }
            else
            {
                Session.Add("error", "El turno seleccionado no está disponible");
                Response.Redirect("Error.aspx", false);
            }
        }

        public bool existe(Turno nuevo)
        {
            List<Turno> Listaturno;
            TurnosNegocio negocio = new TurnosNegocio();
            Listaturno = negocio.listarSP();

            foreach (Turno turno in Listaturno)
            {
                if ((turno.Fecha.idFecha == nuevo.Fecha.idFecha) && (turno.Lugar.idLugar == nuevo.Lugar.idLugar) && (turno.ocupado == true))
                {
                    return true;
                }
            }
            return false;
        }

        protected void regresarAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuInicio.aspx", false);
        }
    }
}