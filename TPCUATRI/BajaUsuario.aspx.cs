using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPCUATRI
{
    public partial class BajaUsuarios_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (seguridad.esArtista(Session["Artista"]))
            {
                Session.Add("error", "Solo los administradores pueden acceder a esta sección");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {

                ArtistasNegocio negocio = new ArtistasNegocio();

                dgvArtistas.DataSource = negocio.ListarConSp();
                dgvArtistas.DataBind();
            }
        }

        protected void dgvArtistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArtistasNegocio negocio = new ArtistasNegocio();

            GridViewRow selectedRow = dgvArtistas.SelectedRow;
            bool estado = bool.Parse(selectedRow.Cells[6].Text);
            int selectedArtistId = (int)dgvArtistas.SelectedDataKey.Value;

            if (estado == true)
            {
                negocio.eliminarLogico(selectedArtistId, false);
                TurnosNegocio BajaTurno = new TurnosNegocio();
                BajaTurno.BajaTurnoUsuarioEliminado(selectedArtistId, false);
            }
            else if (estado == false)
            {
                negocio.eliminarLogico(selectedArtistId, true);
            }


            dgvArtistas.DataSource = negocio.ListarConSp();
            dgvArtistas.DataBind();
        }
    }
}