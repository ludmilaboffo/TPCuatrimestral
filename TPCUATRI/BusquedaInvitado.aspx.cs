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
    public partial class BusquedaInvitado : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ArtistasNegocio negocio = new ArtistasNegocio();
                List<Artista> listaArtistas = negocio.ListarConSp();

                Session.Add("listaArtistas", listaArtistas);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            List<Artista> lista = (List<Artista>)(Session["listaArtistas"]);

            List<Artista> listaFiltrada = lista.FindAll(x => x.nombreArtista != null && x.nombreArtista.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.tipoEspectaculo  != null && x.tipoEspectaculo.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            dgvBusquedaArtistas.DataSource = listaFiltrada;
            dgvBusquedaArtistas.DataBind();
        }
    protected void dgvBusquedaArtistas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void dgvBusquedaArtistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvBusquedaArtistas.PageIndex = e.NewPageIndex;
        dgvBusquedaArtistas.DataBind();
    }
    }
}