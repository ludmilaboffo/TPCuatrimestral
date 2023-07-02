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
                    int idLugar = (int)Session["idLugar"];
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
    }
}