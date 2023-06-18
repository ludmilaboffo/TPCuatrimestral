<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCUATRI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row">
        <div class="col-4">
            <div class="mb-3 m-lg-4">
                <h1 class="display-4">Iniciar sesión</h1>
                <div class="form-group">
                    <label for="inputEmail3">Email</label>
                     <asp:TextBox ID="txtMailLogin" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>          
                </div>
            </div>
            <div class="mb-3 m-lg-4">
                <div class="form-group">
                    <label for="inputPassword3">Contraseña</label>
                    <asp:TextBox ID="txtPassLogin" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 m-lg-4">
                <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" Text="Ingresar"  OnClick="btnIngresar_Click"/>
            </div>
            <div class="mb-3 m-lg-3">
                <div class="mb-3">
                    <h2 class="h5">¿Aun no tienes cuenta?</h2>
                    <h5 class="text-muted"><small><em>¡Únite!</em></small></h5>
                </div>
                <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" Text="Registrarse" />
            </div>
        </div>
    </div>
</asp:Content>
