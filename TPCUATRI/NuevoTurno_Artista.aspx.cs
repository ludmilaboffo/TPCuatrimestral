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
   
        protected void Page_Load(object sender, EventArgs e)
        {
            Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
            if (usuario == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            try
            {
                string IDlugar = Request.QueryString["idLugar"] != null ? Request.QueryString["idLugar"].ToString() : "";
                if (IDlugar != "" && !IsPostBack)
                {
                    int idLugar = int.Parse(IDlugar);
                    List<Fecha> listaFechas = fecha.listarFiltrado(idLugar.ToString());
                    ddlFecha.DataSource = listaFechas;
                    ddlFecha.DataValueField = "idFecha";
                    ddlFecha.DataTextField = "numeroFecha";
                    ddlFecha.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnSelecionarFecha_Click(object sender, EventArgs e)
        {
            confirmarFecha = true;
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
            int idLugar = (int)Session["idLugar"];

            string idFecha = ddlFecha.SelectedValue;
            turno.Lugar.idLugar = idLugar;
            turno.Fecha.idFecha = int.Parse(idFecha);

            date.altaSP(turno);
            lblConfirmado.Text = "Su turno ha sido confirmado. Puede verlo en la agenda";

            lblFecha.Text = dia.fechaReservada(int.Parse(idFecha));
            lblLugar.Text = place.buscarLugar(idLugar);
            Response.Redirect("MenuInicio.aspx", false);
        }

    }
}