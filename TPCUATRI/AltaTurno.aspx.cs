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

        protected void btnAceptarAlta_Click(object sender, EventArgs e)
        {

            Response.Redirect("TurnosInicio.aspx");
        }

        protected void ddlLugar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}