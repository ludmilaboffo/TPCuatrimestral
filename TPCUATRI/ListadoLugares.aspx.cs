﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!IsPostBack)
                {
                    LugaresNegocio negocio = new LugaresNegocio();
                    ListaLugar = negocio.listarSP();
                    Session.Add("ListaLugar", ListaLugar);
                    repLugares.DataSource = (List<Lugar>)(Session["ListaLugar"]);
                    repLugares.DataBind();
                }
                ListaLugar = (List<Lugar>)(Session["ListaLugar"]);
        }

        protected void btnModificarLugar_Click(object sender, EventArgs e)
        {
           Button btnModificarLugar = (Button)sender; 
            int idlugar = int.Parse(btnModificarLugar.CommandArgument);
            Session.Add("idLugar", idlugar );
            Response.Redirect("EditarLugares.aspx?idLugar=" + idlugar);

        }

        protected void btnPedirTurno_Click(object sender, EventArgs e)
        {
            Button btnPedirTurno = (Button)sender;
            int idLugar = int.Parse(btnPedirTurno.CommandArgument);
            bool disponible = estaDisponible(idLugar);
            if (disponible)
            {
                Session.Add("idLugar", idLugar);
                Response.Redirect("NuevoTurno_Artista.aspx?idLugar=" + idLugar);

            }
            else
            {
                Session.Add("error", "Lo sentimos. No puede tomar un turno en un lugar no disponible");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAltaLugar_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditarLugares.aspx");
        }


        public bool estaDisponible(int id)
        {
            List<Lugar> listalugar;
            LugaresNegocio negocio = new LugaresNegocio();
            listalugar = negocio.listarSP();
            foreach(Lugar lugar in listalugar)
            {
                if(lugar.idLugar == id && lugar.Disponibilidad == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}