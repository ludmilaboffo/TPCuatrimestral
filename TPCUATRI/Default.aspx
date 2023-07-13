<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCUATRI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hover-h1:hover {
            color:dodgerblue;        
        }
        h1{
            font-size: 50px;
        }
        h4{
            font-size: 22px;
        }
        h5{
            font-style: italic;
            font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container fluir">
        <div class="row justify-content-center menu-container">
            <div class="col-md-6">
                <h1 class="hover-h1">¡Bienvenido al sistema de registro!</h1>
                <h4>Lamentablemente, solo los usuarios pueden ver el contenido.</h4>
                <h5>¿Tienes cuenta?</h5>
                <a href="Login.aspx">¡Inicia sesión!</a>
            </div>
        </div>
        <br />
        <div class="row justify-content-center menu-container">
            <div class="col-md-6">
                <h4 class="hover-h1">¿Viste la presentación de un artista y estás intentando encontrarlo?</h4>
                <h5>¡Aquí te podemos ayudar!</h5>
                <a href="BusquedaInvitado.aspx">Buscar</a>
            </div>
        </div>
    </div>
</asp:Content>
