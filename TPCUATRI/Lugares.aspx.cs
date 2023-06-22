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
                if (Session["user"] == null)
                {
                    Session.Add("error", "Debes loguearte para entrar");
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

        protected void btnModificarLugar_Click(object sender, EventArgs e)
        {
            try
            {
                LugaresNegocio lugares = new LugaresNegocio();
               // lugares.eliminarLogico(int.Parse(txtid.text));    //necesito traer el id de lugar*
                Response.Redirect("Lugares.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }
    }
}