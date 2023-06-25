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
            <div class="card border-info mb-3" style="max-width: 38rem;">
                <div class="card-header">USUARIOS</div>
                <div class="card-body">
                    <h5 class="card-title">Dar de baja a un usuario del sistema</h5>
                    <div class="card-body">
                        <asp:Button ID="btnBajaUsuario" CssClass="btn btn-outline-primary" runat="server" Text="Ir" OnClick="btnBajaUsuario_Click" />
                    </div>
                </div>
            </div>
            <div class="card border-success mb-3" style="max-width: 38rem;">
                <div class="card-header">ESPACIOS</div>
                <div class="card-body text-success">
                    <h5 class="card-title">Administrar las locaciones disponibles</h5>
                    <div class="card-body">
                        <asp:Button ID="btnAltaLugar" CssClass="btn btn-outline-success" runat="server" Text="Ir" OnClick="btnAltaLugar_Click" />
                    </div>
                </div>
            </div>
            <div class="card border-dark mb-3" style="max-width: 38rem;">
                <div class="card-header">AGENDA</div>
                <div class="card-body">
                    <h5 class="card-title">Agregar turnos</h5>
                    <div class="card-body">
                        <asp:Button ID="btnAltaHorarios" CssClass="btn btn-outline-dark" runat="server" OnClick="btnAltaHorarios_Click" Text="Ir" />
                    </div>
                </div>
                <div class="card-body">
                    <h5 class="card-title">Eliminar turnos</h5>
                    <div class="card-body">
                        <asp:Button ID="btnAltaTurnos" CssClass="btn btn-outline-dark" runat="server" Text="Ir" />
                    </div>
                </div>
                <div class="card-body">
                    <h5 class="card-title">Listado de turnos</h5>
                    <div class="card-body">
                        <asp:Button ID="btnListarTurnos" CssClass="btn btn-outline-dark" runat="server" OnClick="btnListarTurnos_Click" Text="Ir" />
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
            <asp:Button runat="server" ID="btnLugares" Text="Ir" CssClass="btn btn-success" OnClick="btnLugares_Click" />
        </div>
    </div>
    <%}

        }%>
</asp:Content>
