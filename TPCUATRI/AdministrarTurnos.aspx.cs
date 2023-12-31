﻿using System;
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
        public bool confirmarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            confirmarEliminacion = false;
            txtId.Enabled = false;

            if (seguridad.esArtista(Session["Artista"]))
            {
                Session.Add("error", "Solo los administradores pueden acceder a esta sección");
                Response.Redirect("Error.aspx");
            }

            try
            {
                ListaLugar = lugar.listar();
                ListaFecha = fecha.listar();

                // ordeno la lista de forma descendente
                ListaLugar.Sort((l1, l2) => l1.Nombre.CompareTo(l2.Nombre));
                ListaFecha.Sort((f1, f2) => f1.numeroFecha.CompareTo(f2.numeroFecha));
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
                if (id != "" && !IsPostBack)
                {
                    TurnosNegocio turno = new TurnosNegocio();
                    Turno selec = (turno.listar(id))[0];
                    Session.Add("TurnoSeleccionado", selec);

                    /// AHORA PRECARGO
                    txtId.Text = id;
                    ddlFecha.SelectedValue = selec.Fecha.idFecha.ToString();
                    ddlLugar.SelectedValue = selec.Lugar.idLugar.ToString();
                    if (!selec.disponibilidad)
                    {
                        btnInhabilitarTurno.Text = "Rehabilitar";
                    }

                }
                else
                {
                    btnInhabilitarTurno.Visible = false;
                    btnEliminarTurno.Visible = false;
                }
            }
            catch (Exception ex)
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
                Artista usuario = HttpContext.Current.Session["Artista"] as Artista;

                /// A esta ventana solo se ingresa si el usuario es admin. 

                nuevo.Lugar = new Lugar();
                nuevo.Lugar.idLugar = int.Parse(ddlLugar.SelectedValue);
                nuevo.idUsuario = usuario.idArtista;
                nuevo.Fecha = new Fecha();
                nuevo.Fecha.idFecha = int.Parse(ddlFecha.SelectedValue);

                
                if (Request.QueryString["id"] != null)
                {
                    nuevo.idTurno = int.Parse(txtId.Text);
                    if (nuevo.ocupado) {
                        Session.Add("error", "No puede modificar turnos que ya están ocupados por artistas.");
                        Response.Redirect("Error.aspx", false);
                    }
                    negocio.inhabilitarTurno(nuevo.idTurno);

                    if(validarFecha(nuevo)){
                        negocio.modificarConSP(nuevo);
                        Response.Redirect("ListadoTurnos.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "No puede duplicar los turnos.");
                        Response.Redirect("Error.aspx", false);
                    }
                }

                if (validarFecha(nuevo) && !usuario.esArtista)
                {
                    negocio.alta(nuevo);
                    Response.Redirect("ListadoTurnos.aspx", false);
                }
                else
                {
                    Session.Add("error", "No puede duplicar los turnos.");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chConfirmarEliminar.Checked)
                {
                    TurnosNegocio turno = new TurnosNegocio();
                    turno.inhabilitarTurno(int.Parse(txtId.Text));
                    turno.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListadoTurnos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }


        protected void btnInhabilitarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                TurnosNegocio turno = new TurnosNegocio();
                Turno seleccionado = (Turno)Session["TurnoSeleccionado"];
                turno.inhabilitarTurno(seleccionado.idTurno);
                turno.eliminarLogico(int.Parse(txtId.Text), !seleccionado.disponibilidad);
                /// busco, negando la disponibilidad, que tenga la opuesta ///
                Response.Redirect("ListadoTurnos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
        public bool validarFecha(Turno nuevo)
        {
            List<Turno> Listaturno;
            TurnosNegocio negocio = new TurnosNegocio();
            Listaturno = negocio.listarSP();

            foreach (Turno turno in Listaturno)
            {
                if (turno.Fecha.idFecha == nuevo.Fecha.idFecha && turno.Lugar.idLugar == nuevo.Lugar.idLugar)
                {
                    return false;
                }
            }

            return true;
        }

        public bool turnoOcupado(int idTurno)
        {
            List<Turno> Listaturno;
            TurnosNegocio negocio = new TurnosNegocio();
            Listaturno = negocio.listarSP();

            foreach (Turno turno in Listaturno)
            {
                if (turno.idTurno == idTurno)
                {
                    return false;
                }
            }

            return true;
        }
    }
}