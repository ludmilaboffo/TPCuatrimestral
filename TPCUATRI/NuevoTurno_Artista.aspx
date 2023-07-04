<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTurno_Artista.aspx.cs" Inherits="TPCUATRI.NuevoTurno_Artista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <% Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        {
            if (fechaLibre)
            { %>
    <div class="row justify-content-center">
        <div class="col-md-4 text-center">
            <div class="mb-3 display-none">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control d-none"></asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label" id="lblLugarDisponible"></label>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha </label>
                        <br />
                        <asp:DropDownList ID="ddlFecha" CssClass="btn btn-warning dropdown-toggle" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <asp:Button runat="server" ID="btnSelecionarFecha" OnClick="btnSelecionarFecha_Click" CssClass="btn btn-outline-danger" Text="Aceptar" />
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-md-6">
                            <div class="mb-3" runat="server" id="divConfirmarTurno" visible="false">
                                <asp:CheckBox runat="server" Text="Confirmar turno" ID="chConfirmarTurno" />
                                <asp:Button runat="server" Text="Confirmar" ID="btnConfirmarTurno" CssClass="btn btn-close-white" OnClick="btnConfirmarTurno_Click" OnSelectedItem="ddlSeleccionarFecha" />
                            </div>
                            <div class="mb-3" runat="server" id="divConfirmado" visible="false">
                                <asp:Label runat="server" ID="lblConfirmado" CssClass="h3"></asp:Label>
                            </div>
                            <div class="mb-3" runat="server" id="divFecha" visible="false">
                                <asp:Label runat="server" ID="lblFecha" CssClass="h5"></asp:Label>
                            </div>
                            <div class="mb-3" runat="server" id="divLugar" visible="false">
                                <asp:Label runat="server" ID="lblLugar" CssClass="h5"></asp:Label>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <% }
        else
        { %>
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblNoHayTurno" CssClass="h5"></asp:Label>
            </div>
        </div>
    </div>
    <% } %>
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="mb-3">
                <asp:Button runat="server" ID="regresarAtras" CssClass="btn btn-info" OnClick="regresarAtras_Click" Text="Volver atras" />
            </div>
        </div>
    </div>
    <% }%>
</asp:Content>
