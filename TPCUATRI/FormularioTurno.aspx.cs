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
    public partial class FormularioTurno : System.Web.UI.Page
    {
        LugaresNegocio lugar = new LugaresNegocio();    
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    List<Lugar> listaLugares = lugar.listar();
                    Session["ListaLugares"] = listaLugares;

                    //configuro desplegable POKEMONS desde db pero solo lo cargo
                    //ddlPokemonsFiltrados.DataSource = listaPokemon;
                    //ddlPokemonsFiltrados.DataBind();  

                    //configuro desplegable TIPOS desde db con id y desc
                    ddlLugar.DataSource = listaLugares;
                    ddlLugar.DataTextField = "Nombre";
                    ddlLugar.DataValueField = "idLugar";
                    ddlLugar.DataBind();
                }

            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void btnAceptarAlta_Click(object sender, EventArgs e)
        {
            Turno turno = new Turno();
            // turno.idTurno 
            turno.Fecha = DateTime.Parse(txtFechaTurno.Text);
            turno.disponibilidad = true;


            List<Turno> listaT = ((List<Turno>)Session["ListaTurnos"]);
            listaT.Add(turno);

            Response.Redirect("TurnosInicio.aspx");
        }

        protected void ddlLugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int id = int.Parse(ddlTFecha.SelectedItem.Value);
                ddlTFecha.DataSource = ((List<Lugares>)Session["ListaLugares"]).FindAll(x => x.Lugar.idLugar == id);
                ddlTFecha.DataBind();
            }
        }
    }
}