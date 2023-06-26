<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuInicio.aspx.cs" Inherits="TPCUATRI.MenuInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%

        Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        {

            if (usuario.isAdmin())
            { %>
    <div class="row justify-content-center">
        <div class="col-md-4">
            <h1 class="text-center display-1">MENU PRINCIPAL</h1>
            <div class="card bg-success text-white mb-3" style="max-width: 38rem;">
                <div class="card-header">USUARIOS</div>
                <div class="card-body">
                    <h5 class="card-title">Dar de baja a un usuario del sistema</h5>
                    <div class="card-body">
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-outline-light" runat="server" Text="Ir" OnClick="btnBajaUsuario_Click" />
                    </div>
                </div>
            </div>
            <div class="card bg-warning mb-3" style="max-width: 38rem;">
                <div class="card-header">ESPACIOS</div>
                <div class="card-body text-white">
                    <h5 class="card-title">Administrar las locaciones disponibles</h5>
                    <div class="card-body">
                        <asp:Button ID="btnListadoLugares" CssClass="btn btn-outline-light" runat="server" Text="Ir" OnClick="btnListadoLugares_Click" />
                    </div>
                </div>
            </div>

            <div class="card bg-primary text-white mb-3" style="max-width: 38rem;">
                <div class="card-header">AGENDA</div>
                <div class="card-body">
                    <h5 class="card-title">Administrar los turnos</h5>
                    <div class="card-body">
                        <asp:Button ID="btnListarTurnos" CssClass="btn btn-outline-light" runat="server" OnClick="btnListarTurnos_Click" Text="Ir" />
                    </div>
                </div>
            </div>

        </div>
    </div>
    <%}
        else if (usuario.isArtista())
        {%>
    <div class="row justify-content-center">
        <div class="col-md-4">
            <h1 class="text-center display-1">Ver locaciones disponibles</h1>
        </div>
        <div class="col-md-4">
            <asp:Button runat="server" ID="btnLugares" Text="Ir" CssClass="btn btn-success" />
        </div>
    </div>
    <%}

        }%>
</asp:Content>
