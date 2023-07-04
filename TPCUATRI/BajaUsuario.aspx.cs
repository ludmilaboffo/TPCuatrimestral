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
            if (!IsPostBack)
            {
                if (!((Dominio.Usuario)Session["user"]).isAdmin())
                {
                    Session.Add("error", "Solo los administradores acceden a esta sección");
                    Response.Redirect("Error.aspx", false);
                }
                ArtistasNegocio negocio = new ArtistasNegocio();
                dgvArtistas.DataSource = negocio.ListarConSp();
                dgvArtistas.DataBind();
            }
        }

        protected void dgvArtistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArtistasNegocio negocio = new ArtistasNegocio();
            GridViewRow selectedRow = dgvArtistas.SelectedRow;
            bool estado = Convert.ToBoolean(selectedRow.Cells[6].Text);
            if (estado == true)
            {
                negocio.eliminarLogico((int)dgvArtistas.SelectedDataKey.Value, false);
            }
            else
            {
                negocio.eliminarLogico((int)dgvArtistas.SelectedDataKey.Value, true);
            }
        }
    }
}