<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPCUATRI.Registro"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3 m-lg-4">
                <h1 class="display-4">Registrate</h1>
                <div class="form-group">
                    <label for="inputEmail3">Email</label>
                    <asp:TextBox ID="txtMailRegistro" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 m-lg-4">
                <div class="form-group">
                    <label for="inputPassword3">Contraseña</label>
                    <asp:TextBox ID="txtPassRegistro" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 m-lg-4">
                <div class="form-group">
                    <label for="lblNombreRegistro">Nombre</label>
                    <asp:TextBox ID="nombreRegistro" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 m-lg-4">
                <div class="form-group">
                    <label for="lblApellidoRegistro">Apellido</label>
                    <asp:TextBox ID="apellidoRegistro" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 m-lg-3">
                <asp:Button ID="btnReg" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnReg_Click" />
                <h5 cssclass="h5">¿Ya tenes una cuenta?</h5>
                <a href="Login.aspx">Volver al inicio de sesión</a>
            </div>
        </div>
    </div>
</asp:Content>
