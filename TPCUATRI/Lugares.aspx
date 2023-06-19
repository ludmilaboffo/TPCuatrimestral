<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lugares.aspx.cs" Inherits="TPCUATRI.Lugares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Aca se listan los lugares para ambos</h1>

    <h1>Aca al admin le aparece el boton de agregar un nuevo lugar. El boton debe redirigir a una pantalla con los datos a cargar.</h1>
    <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-light" Text="Agregar"/>

    <h1>Aca lo mnismo pero para dar de baja</h1>
    <asp:Button runat="server" ID="btnBajar" CssClass="btn btn-light" Text="Eliminar" />
</asp:Content>
