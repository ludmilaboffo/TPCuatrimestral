﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarTurnos.aspx.cs" Inherits="TPCUATRI.FormularioTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        label {                
            font-family: 'Bebas Neue', sans-serif;
            color: white;
            font-size: 40px;
        }
    .custom-dropdown {
        background-color: #00a7e4; /* Color de fondo celeste */
        color: black; /* Color de texto negro */
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.4);
        width: 100%; /* Ancho del control */
    }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;

            if (!usuario.esArtista)
            { %>
    <div class="row justify-content-center">
        <div class="col-md-4 text-center">
            <div class="mb-3 display-none">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control d-none"> </asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-4 mt-5">                        
                        <label class="form-label">Lugar</label>
                        <br />
                        <asp:DropDownList ID="ddlLugar" CssClass="btn btn-info dropdown-toggle" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="mb-5">
                        <label class="form-label">Fecha </label>
                        <br />
                        <asp:DropDownList ID="ddlFecha" CssClass="btn btn-info dropdown" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-2">
                <asp:Button runat="server" Text="Aceptar" ID="btnAceptarAlta" OnClick="btnAceptarAlta_Click" CssClass="btn btn-primary" />
            </div>
            <div class="mb-5">
                <asp:Button runat="server" Text="Inhabilitar" ID="btnInhabilitarTurno" OnClick="btnInhabilitarTurno_Click" CssClass="btn btn-light" />
            </div>
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <asp:UpdatePanel ID="upEliminar" runat="server">
                        <ContentTemplate>
                             <div class="mb-3">
                                <asp:Button runat="server" Text="Eliminar definitivamente" ID="btnEliminarTurno" CssClass="btn btn-danger" OnClick="btnEliminarTurno_Click" />
                            </div>
                            <div class="mb-3" >
                                <a href="MenuInicio.aspx">Volver al menú de inicio</a>
                            </div>

                            <%if (confirmarEliminacion)
                                { %>
                            <div class="mb-3">
                                <asp:CheckBox runat="server" Text="Confirmar eliminacion" ID="chConfirmarEliminar" />
                                <asp:Button runat="server" Text="Confirmar" ID="btnConfirmarEliminacion" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
                            </div>
                            <%} %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <%}
        else if (usuario.esArtista)
        {%>
    <div class="row justify-content-center">
        <div class="col-md-4">
            <h1 class="h1">Esta seccion solo está disponible para administradores</h1>
        </div>
    </div>
    <%}
%>
</asp:Content>
