<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoLugares.aspx.cs" Inherits="TPCUATRI.Lugares" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            border: none;
            border-radius: 0;
            background-color: transparent;
        }

        .card-img-top {
            width: 700px;
            height: auto;
            margin: 0 auto;
            margin-top: 40px;
            margin-bottom: 20px;
            transition: transform 0.3s;
            box-shadow: 0px 1px 4px 0px rgba(255, 255, 255, 0.1);

        }

            .card-img-top:hover {
                transform: scale(1.1);
            }

        .card-body {
            text-align: center;
            margin-top: 20px;
        }

        .card-title,
        .card-text {
            margin-bottom: 10px;
        }

        .card-title,
        .card-text {
            margin-bottom: 10px;
        }

        .centered-button {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }

        .small-button {
            padding: 5px 10px;
            font-size: 12px;
        }

        h5{
            font-family: 'Bebas Neue', sans-serif;
            font-size: 50px;
        }
        h5, p{
           color: white;
        }
    </style>
    <%    
        Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];

        if (usuario != null)
        {
    %>
    <asp:Repeater runat="server" ID="repLugares">
        <ItemTemplate>
            <div class="card mb-3">
                <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="..." onerror="this.src='https://media.istockphoto.com/id/1193046540/es/vector/foto-pr%C3%B3ximamente-icono-de-imagen-ilustraci%C3%B3n-vectorial-aislado-sobre-fondo-blanco-no-hay.jpg?s=612x612&w=0&k=20&c=sblCjtqWoLEpWnqGZMr5yuiltE2bsiuH-WwsecNGSIA=';">
                <div class="card-body">
                    <h5 cssclass="card-title"><%#Eval("Nombre")%></h5>
                    <p id="direccion" cssclass="card-text"><%#Eval("Direccion")%></p>
                    <p cssclass="card-text"><%#Eval("Descripcion")%></p>
                    <p cssclass="card-text"><%#Eval("Direccion")%></p>
                    <div class="mb-3">
                        <em cssclass="card-text" style="color: red;">
                            <%# (bool)Eval("Disponibilidad") ? "Disponible" : "No disponible" %>
                        </em>
                     </div>
                   
                    <% if (((Dominio.Usuario)Session["user"]).isArtista())
                        { %>
                    <div class="centered-button">
                        <asp:Button ID="btnPedirTurno" CssClass="btn btn-primary m mb-4" Text="Pedir turno" runat="server" CommandName="PedirTurno" CommandArgument='<%# Eval("idLugar") %>' OnClick="btnPedirTurno_Click" />
                    </div>
                </div>
            </div>
            <% 
                }
                else if (((Dominio.Usuario)Session["user"]).isAdmin())
                {%>
            <asp:Button ID="btnModificarLugar" OnClick="btnModificarLugar_Click" CssClass="btn btn-warning" runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("idLugar") %>' />
            </div>
            <%}%>
        </ItemTemplate>
    </asp:Repeater>
    <%if (((Dominio.Usuario)Session["user"]).isAdmin())
        {%>
    <div class="centered-button">
        <asp:Button ID="btnAltaLugar" OnClick="btnAltaLugar_Click" CssClass="btn btn-primary" Text="Agregar nuevo" runat="server" />
    </div>

    <%}%>
    <%} %>
</asp:Content>
