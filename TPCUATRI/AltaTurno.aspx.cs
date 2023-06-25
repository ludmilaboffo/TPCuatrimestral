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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            try
            {
                if (!IsPostBack)
                {
                   ListaLugar= lugar.listar();
                    ListaFecha = fecha.listar();

                    ddlLugar.DataSource = ListaLugar;
                    ddlLugar.DataValueField = "idLugar";
                    ddlLugar.DataTextField = "Nombre";
                    ddlLugar.DataBind();


                    ddlFecha.DataSource = ListaFecha;
                    ddlFecha.DataValueField = "idFecha";
                    ddlFecha.DataTextField = "numeroFecha";
                    ddlFecha.DataBind();
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
                nuevo.idUsuario = 1; /// Ver: está hardcodeado
                nuevo.Fecha = new Fecha();
                nuevo.Fecha.idFecha = int.Parse(ddlFecha.SelectedValue);

                negocio.alta(nuevo);
                Response.Redirect("ListadoTurnos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}