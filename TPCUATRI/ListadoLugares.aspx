<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoLugares.aspx.cs" Inherits="TPCUATRI.Lugares" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            border: none;
            border-radius: 0;
        }

        .card-img-top {
            width: 700px;
            height: auto;
            margin: 0 auto;
            margin-top: 40px;
            margin-bottom: 20px;
            transition: transform 0.3s;
            box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.3);
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



    </style>
    <%    
        Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
    %>
    <asp:Repeater runat="server" ID="repLugares">
        <ItemTemplate>
            <div class="card mb-3">
                <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 cssclass="card-title"><%#Eval("Nombre")%></h5>
                    <p id="direccion" cssclass="card-text"><%#Eval("Direccion")%></p>
                    <p cssclass="card-text"><%#Eval("Descripcion")%></p>
                    <p cssclass="card-text"><%#Eval("Direccion")%></p>
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
