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
            font-size: 70px;
            margin-bottom: 0px;
            font-family: 'Bebas Neue', sans-serif;
            color: white;
        }

        .menu-card {
            background-color: #f8f9fa;
            margin-bottom: 20px;
        }

        .menu-card-header {
            background: rgb(33,102,138);
            background: linear-gradient(157deg, rgba(33,102,138,1) 0%, rgba(255,255,255,1) 100%);
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

        .hover:hover {
           color:cornflowerblue;
        }
        .fontCard{
            font-family: 'Bebas Neue', sans-serif;
            font-size: 30px;
        }
        h5{
            font-family: 'Bebas Neue', sans-serif;
            color:cornflowerblue;
            font-size: 25px;
        }

    </style>


    <%

        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;

        if (!usuario.esArtista)
        { %>
    <div class="container">
        <div class="row justify-content-center menu-container">
            <div class="col-md-6  mt-5">
                <h1 class="text-center menu-title">MENU PRINCIPAL</h1>
                <div class="card menu-card mt-3">
                    <div class="card-header menu-card-header fontCard">USUARIOS</div>
                    <div class="card-body menu-card-body">
                        <h5>Dar de baja a un usuario del sistema</h5>
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-outline-primary menu-button" runat="server" Text="Ir" OnClick="btnBajaUsuario_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header fontCard">ESPACIOS</div>
                    <div class="card-body menu-card-body">
                        <h5>Administrar las locaciones disponibles</h5>
                        <asp:Button ID="btnListadoLugares" CssClass="btn btn-outline-primary menu-button" runat="server" Text="Ir" OnClick="btnListadoLugares_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header fontCard">AGENDA</div>
                    <div class="card-body menu-card-body">
                        <h5>Administrar los turnos</h5>
                        <asp:Button ID="btnListarTurnos" CssClass="btn btn-outline-primary menu-button" runat="server" OnClick="btnListarTurnos_Click" Text="Ir" />
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
                <div class="col-md-8">
                    <div class="mb-5  d-inline">
                        <label  style=" font-family: 'Pacifico', cursive; font-size:30px; margin-right: 10px;">¡Hola de vuelta,</label>
                        <asp:Label runat="server" ID="lblHola" style="font-size:40px; " CssClass="h5 hover"></asp:Label>
                          <label  style=" font-family: 'Pacifico', cursive; font-size:30px; margin-right: 10px;">!</label>                     
                    </div>
                </div>
                <div class="card menu-card mt-3">
                    <div class="card-header menu-card-header hover fontCard">Perfil</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnPerfil" CssClass="btn btn-outline-primary menu-button" runat="server" Text="Ver perfil" OnClick="btnPerfil_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header hover fontCard">Nuevo turno</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnNuevoTurnoART" CssClass="btn btn-outline-primary menu-button" runat="server" Text="Ir" OnClick="btnNuevoTurnoART_Click" />
                    </div>
                </div>
                <div class="card menu-card">
                    <div class="card-header menu-card-header hover fontCard">Agenda de turnos</div>
                    <div class="card-body menu-card-body">
                        <asp:Button ID="btnAgendaArtista" CssClass="btn btn-outline-primary menu-button" runat="server" OnClick="btnAgendaArtista_Click" Text="Ir" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
