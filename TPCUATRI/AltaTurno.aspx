<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="TPCUATRI.FormularioTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Fecha</label>
                <asp:TextBox runat="server" ID="txtFechaTurno" CssClass="form-control" TextMode="Date"> </asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Lugar</label>
                        <asp:DropDownList ID="ddlLugar" CssClass="btn dropdown-menu-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLugar_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha</label>
                        <asp:DropDownList ID="ddlFecha" CssClass="btn dropdown-menu-dark" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Usuario</label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control"> </asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button runat="server" Text="Aceptar" ID="btnAceptarAlta" OnClick="btnAceptarAlta_Click" CssClass="btn btn-outline-danger" />
                <a href="MenuInicio.aspx">Volver al menú de inicio</a>
            </div>
        </div>
    </div>


</asp:Content>
