<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="TPCUATRI.FormularioTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        {

            if (usuario.isAdmin())
            { %>
    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"> </asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Lugar</label>
                        <asp:DropDownList ID="ddlLugar" CssClass="btn dropdown-menu-dark" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha</label>
                        <asp:DropDownList ID="ddlFecha" CssClass="btn dropdown-menu-dark" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <asp:Button runat="server" Text="Aceptar" ID="btnAceptarAlta" OnClick="btnAceptarAlta_Click" CssClass="btn btn-outline-danger" />
                <a href="MenuInicio.aspx">Volver al menú de inicio</a>
            </div>
        </div>
    </div>
        <%}
        else if (usuario.isArtista())
        {%>
    <div class="row justify-content-center">
        <div class="col-md-4">
            <h1 class="h1">Esta seccion solo está disponible para administradores</h1>
        </div>
    </div>
    <%}

        }%>
</asp:Content>
