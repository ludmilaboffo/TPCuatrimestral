<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarLugares.aspx.cs" Inherits="TPCUATRI.EditarLugares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%    
        Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
            if (((Dominio.Usuario)Session["user"]).isAdmin())
            {
    %>
    <div class="card mb-3">
        <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"><%# Eval("Nombre") %></h5>
            <p class="card-text"><%# Eval("Direccion") %></p>
            <p class="card-text"><%# Eval("Descripcion") %></p>
            <p class="card-text"><%# Eval("Direccion") %></p>

            <asp:Button ID="btnEliminarLugar" runat="server" Text="Eliminar lugar" CssClass="btn btn-danger" Onclick="btnEliminarLugar_Click" />
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar cambios" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar cambios" CssClass="btn btn-secondary" Onclick="btnCancelar_Click" />
        </div>
    </div>
     <%}%>
    <%else
        {
            Session.Add("error", "No tienes permiso de administrador");
            Response.Redirect("Error.aspx", false);
        }%>
    <%}%>
</asp:Content>