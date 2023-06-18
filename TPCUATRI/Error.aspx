<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPCUATRI.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
            <div class="mb-3 m-lg-4">
                <h1 class="display-4">¡Ups! Parece que ha habido un error</h1>
                <a href="Inicio.aspx">Volver al inicio</a>
                <asp:Label Text="text" runat="server" ID="lblMensaje"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
