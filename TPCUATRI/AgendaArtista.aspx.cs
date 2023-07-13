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
    public partial class AgendaArtista : System.Web.UI.Page
    {
        List<Turno> listaAgenda;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!seguridad.esAdministrador(Session["Artista"]))
            {
                Session.Add("error", "Solo los artistas pueden acceder a esta sección");
                Response.Redirect("Error.aspx");
            }
            
            Artista usuario = (Artista)Session["Artista"];

            TurnosNegocio negocio = new TurnosNegocio();
            listaAgenda = negocio.listarPorArtistas(usuario.idArtista);
            var agendaDGV = listaAgenda.Select(t => new {
                id = t.idTurno,
                FechaNum = t.Fecha.numeroFecha,
                FechaDia = t.Fecha.descripcionFecha + "    " + (t.Fecha.numeroFecha).ToString(),
                NombreLugar = t.Lugar.Nombre + " " + t.Lugar.Direccion,
                Vigente = t.ocupado
            });
            dgvAgenda.DataSource = agendaDGV;
            dgvAgenda.DataBind();

        }

        protected void dgvAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}