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
        FechaNegocio fecha = new FechaNegocio();
        List<Lugar> ListaLugar;
        List<Fecha> ListaFecha;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (Session["user"] == null)
            {
                Session.Add("error", "Debes loguearte para entrar");
                Response.Redirect("Error.aspx", false);
            }
            try
            {
                    ListaLugar= lugar.listar();
                    ListaFecha = fecha.listar();
                if (!IsPostBack)
                {

                    ddlLugar.DataSource = ListaLugar;
                    ddlLugar.DataValueField = "idLugar";
                    ddlLugar.DataTextField = "Nombre";
                    ddlLugar.DataBind();


                    ddlFecha.DataSource = ListaFecha;
                    ddlFecha.DataValueField = "idFecha";
                    ddlFecha.DataTextField = "numeroFecha";
                    ddlFecha.DataBind();
                }
                /// modificamos
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id!= "" && !IsPostBack)
                {
                    TurnosNegocio turno = new TurnosNegocio();
                    Turno selec = (turno.listar(id))[0];

                    /// AHORA PRECARGO
                    txtId.Text = id;
                    ddlFecha.SelectedValue = selec.Fecha.idFecha.ToString();
                    ddlLugar.SelectedValue = selec.Lugar.idLugar.ToString();
                } 
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnAceptarAlta_Click(object sender, EventArgs e)
        {

            try
            {
                Turno nuevo = new Turno();
                TurnosNegocio negocio = new TurnosNegocio();
                LugaresNegocio lugarNegocio = new LugaresNegocio(); 

                nuevo.Lugar = new Lugar();
                nuevo.Lugar.idLugar = int.Parse(ddlLugar.SelectedValue);
                nuevo.idUsuario = 1; /// Ver: está hardcodeado
                nuevo.Fecha = new Fecha();
                nuevo.Fecha.idFecha = int.Parse(ddlFecha.SelectedValue);

                if(Request.QueryString["id"] != null)
                {
                    nuevo.idTurno = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);

                    string mensaje = "¡Modificacion exitosa!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('" + mensaje + "');", true);
                    Response.Redirect("ListadoTurnos.aspx", false);
                }
                negocio.alta(nuevo);
                Response.Redirect("ListadoTurnos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}