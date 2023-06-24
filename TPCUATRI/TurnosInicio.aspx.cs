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
            if (Session["ListaTurnos"] == null) { 
                TurnosNegocio negocio = new TurnosNegocio();
                ListaTurnos = negocio.listar();
                Session.Add("ListaTurnos", ListaTurnos);                       
            }

              gvTurnos.DataSource = (List<Turno>)(Session["ListaTurnos"]);
              gvTurnos.DataBind();              
              ListaTurnos = (List<Turno>)(Session["ListaTurnos"]);  
        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gvTurnos.SelectedDataKey.Value.ToString(); /// CAPTURO EL ID DEL ELEMENTO SELECCIONADO
            /// agregar una pantalla para eliminar/agregar
            /// Response.Redirect("TurnosBaja.aspx?=id" +id);  -- me lleva el id seleccionado
        }
    }
}