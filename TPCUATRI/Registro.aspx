<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPCUATRI.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row justify-content-center">
    <div class="col-4">
        <div class="mb-3 m-lg-4">
            <h1 class="display-4">Registrate</h1>
            <div class="form-group">
                <label for="inputEmail3" class="mt-2" style="font-family: 'Arial', sans-serif; font-size: 20px;">Email</label>
                <asp:TextBox ID="txtMailRegistro" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ControlToValidate="txtMailRegistro"
                    ErrorMessage="Por favor, ingrese su email"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="mb-3 m-lg-4">
            <div class="form-group">
                <label for="inputPassword3" style="font-family: 'Arial', sans-serif; font-size: 20px;">Contraseña</label>
                <asp:TextBox ID="txtPassRegistro" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server" ControlToValidate="txtPassRegistro"
                    ErrorMessage="Por favor, ingrese una contraseña"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="mb-3 m-lg-3">
            <asp:Button ID="btnReg" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnReg_Click" />
            <h5 class="h5 mt-4">¿Ya tenes una cuenta?</h5>
            <a href="Login.aspx">Volver al inicio de sesión</a>
            </div>
       <div class="mb-3 m-lg-3">
            <a href="Default.aspx">Ir a la página principal</a>
        </div>
    </div>
</div>

</asp:Content>
