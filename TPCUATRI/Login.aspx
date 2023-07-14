<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCUATRI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .hover:hover {
            color: cornflowerblue;
        }
    </style>
    <div class="row justify-content-center">
    <div class="col-4">
        <div class="mb-3 m-lg-4 mt-5">
            <h1 class="display-4">Iniciar sesión</h1>
            <div class="form-group">
                <label for="inputEmail3" style="font-family: 'Arial', sans-serif; font-size: 20px;">Email</label>
                <asp:TextBox ID="txtMailLogin" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 m-lg-4">
            <div class="form-group">
                <label for="inputPassword3" style="font-family: 'Arial', sans-serif; font-size: 20px;">Contraseña</label>
                <asp:TextBox ID="txtPassLogin" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
</div>
<div class="row justify-content-center">
    <div class="col-4">
        <div class="mb-3 m-lg-4">
            <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </div>
        <div class="mb-3 m-lg-3">
            <div class="mb-3">
                <h2 class="h5">¿Aun no tenes cuenta?</h2>
                <h5 class="hover"><small><em>¡Únete!</em></small></h5>
            </div>
            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
        </div>
    </div>
</div>

</asp:Content>
