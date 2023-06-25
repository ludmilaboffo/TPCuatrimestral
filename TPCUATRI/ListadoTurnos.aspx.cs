using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Programacion3
{
    public partial class TurnosClass : System.Web.UI.Page
    {
        List<Turno> ListaTurnos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {

                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
                TurnosNegocio negocio = new TurnosNegocio();
                ListaTurnos = negocio.listarSP();
                var turnosDGV =(ListaTurnos).Select(t => new {
                    id = t.idTurno,
                    FechaNum = t.Fecha.numeroFecha,
                    FechaDia = t.Fecha.descripcionFecha,
                    NombreLugar = t.Lugar.Nombre,
                });
              gvTurnos.DataSource = turnosDGV;
              gvTurnos.DataBind();              

        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvTurnos.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaTurno.aspx?id=" + id);

        }
    }
}