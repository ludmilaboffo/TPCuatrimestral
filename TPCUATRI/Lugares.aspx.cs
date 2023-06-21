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
    public partial class Lugares : System.Web.UI.Page
    {

        public List<Lugar> ListaLugar { get; set; }
        public Lugar Lugar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                if (!((Dominio.Usuario)Session["user"]).isAdmin() && !((Dominio.Usuario)Session["user"]).isArtista())
                {
                    Session.Add("error", "No te has logueado. No puedes ver esta sección");
                    Response.Redirect("Error.aspx", false);
                }
                if (!IsPostBack)
                {
                        LugaresNegocio negocio = new LugaresNegocio();
                        ListaLugar= negocio.listar();
                        Session.Add("ListaLugar", ListaLugar);
                        repLugares.DataSource = (List<Lugar>)(Session["ListaLugar"]);
                        repLugares.DataBind();
                }
                ListaLugar = (List<Lugar>)(Session["ListaLugar"]);
            }
        }
    }
}