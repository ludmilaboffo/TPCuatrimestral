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
            Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
            if (usuario == null)
            {

                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            else if(usuario.isAdmin())
            {
                Session.Add("error", "Esta sección es para artistas solamente. Puede chequear la agenda en el listado de artistas");
                Response.Redirect("Error.aspx", false);
            }

            TurnosNegocio negocio = new TurnosNegocio();
            listaAgenda = negocio.listarPorArtistas(usuario.idUsuario);
            var agendaDGV = listaAgenda.Select(t => new {
                id = t.idTurno,
                FechaNum = t.Fecha.numeroFecha,
                FechaDia = t.Fecha.descripcionFecha + "    " + (t.Fecha.numeroFecha).ToString(),
                NombreLugar = t.Lugar.Nombre + " " + t.Lugar.Direccion,
                Vigente = t.disponibilidad
            });
            dgvAgenda.DataSource = agendaDGV;
            dgvAgenda.DataBind();

        }

        protected void dgvAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}