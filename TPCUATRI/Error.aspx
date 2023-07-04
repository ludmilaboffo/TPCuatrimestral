<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPCUATRI.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row-cols-6">
        <div class="col-4">
            <div class="mb-3 m-lg-4">
                <h1 class="display-4">¡Ups! Parece que ha habido un error...</h1>
                <asp:Label Text="text" runat="server" ID="lblMensaje"></asp:Label>
                <% Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
                    if (usuario != null)
                    { %>
                <div class="row row-cols-6">
                    <div class="mb3-">
                        <a href="MenuInicio.aspx">Atrás </a>
                    </div>
                </div>

                <%}
                    else
                    {%>
                <div class="row-cols-6">
                    <div class="mb3-">
                        <a href="Default.aspx">Atrás </a>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
