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
    public partial class TurnosClass : System.Web.UI.Page
    {
        List<Turno> ListaTurnos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (seguridad.esAdministrador(Session["Artista"]))
            {
                Session.Add("error", "Solo los administradores pueden acceder a esta sección");
                Response.Redirect("Error.aspx");
            }
            TurnosNegocio negocio = new TurnosNegocio();
                ListaTurnos = negocio.listarSP();
                var turnosDGV =(ListaTurnos).Select(t => new {
                    id = t.idTurno,
                    FechaNum = t.Fecha.numeroFecha,
                    FechaDia = t.Fecha.descripcionFecha +"    "+ (t.Fecha.numeroFecha).ToString(),
                    NombreLugar = t.Lugar.Nombre,
                    Disponibilidad= t.disponibilidad,
                    Ocupado = t.ocupado
                });
              gvTurnos.DataSource = turnosDGV;
              gvTurnos.DataBind();              

        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvTurnos.SelectedDataKey.Value.ToString();
            Session.Add("idTurnoSeleccionado", id);
            Response.Redirect("AdministrarTurnos.aspx?id=" + id);

        }

        protected void btnAltaTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarTurnos.aspx", false);
        }
    }
}