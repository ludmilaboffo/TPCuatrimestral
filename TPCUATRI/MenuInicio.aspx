<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuInicio.aspx.cs" Inherits="TPCUATRI.MenuInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Estilos personalizados para el menú de inicio */
        .menu-container {
            margin: 10px;
        }

        .menu-title {
            text-align: center;
            font-size: 2rem;
            margin-bottom: 20px;
        }

        .menu-card {
            background-color: #f8f9fa;
            margin-bottom: 20px;
        }

        .menu-card-header {
            background-color: #343a40;
            color: #fff;
        }

        .menu-card-body {
            padding: 20px;
        }

        .menu-card-title {
            font-size: 1.5rem;
            margin-bottom: 10px;
        }

        .menu-button {
            width: 100%;
        }
    </style>

    <%

        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;

            if (!usuario.esArtista)
            { %>
    <div class="container">
        <div class="row justify-content-center menu-container">
            <div class="col-md-6">
                <h1 class="text-center menu-title">MENU PRINCIPAL</h1>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">USUARIOS</div>
                    <div class="card-body menu-card-body">
                        <h5 class="card-title menu-card-title">Dar de baja a un usuario del sistema</h5>
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-primary menu-button" runat="server" Text="Ir" OnClick="btnBajaUsuario_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">ESPACIOS</div>
                    <div class="card-body menu-card-body">
                        <h5 class="card-title menu-card-title">Administrar las locaciones disponibles</h5>
                        <asp:Button ID="btnListadoLugares" CssClass="btn btn-primary menu-button" runat="server" Text="Ir" OnClick="btnListadoLugares_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">AGENDA</div>
                    <div class="card-body menu-card-body">
                        <h5 class="card-title menu-card-title">Administrar los turnos</h5>
                        <asp:Button ID="btnListarTurnos" CssClass="btn btn-primary menu-button" runat="server" OnClick="btnListarTurnos_Click" Text="Ir" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}
        else if (usuario.esArtista)
        {%>
    <div class="container">
        <div class="row justify-content-center menu-container">
            <div class="col-md-6">
                <h1 class="text-center menu-title">MENU PRINCIPAL</h1>
                <div class="col-md-4 justify-content-center">
                    <div class="mb-3">
                        <asp:Label runat="server" ID="lblHola" CssClass="h5"></asp:Label>
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">MI PERFIL</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnPerfil" CssClass="btn btn-primary menu-button" runat="server" Text="Ver perfil" OnClick="btnPerfil_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">NUEVO TURNO</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnNuevoTurnoART" CssClass="btn btn-primary menu-button" runat="server" Text="Ir" OnClick="btnNuevoTurnoART_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header">MI AGENDA</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnAgendaArtista" CssClass="btn btn-primary menu-button" runat="server" OnClick="btnAgendaArtista_Click" Text="Ir" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
