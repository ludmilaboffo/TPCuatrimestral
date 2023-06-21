<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCUATRI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>¡BIENVENIDO AL SISTEMA!</h1>
    <h2>Debes estar registrado para ver los venues</h2>
    <a href="Login.aspx">Iniciar sesion</a>
    <h2>¿No tenes cuenta</h2>
    <a href="Registro.aspx">Registrate</a>
</asp:Content>
