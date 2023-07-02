<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoTurno_Artista.aspx.cs" Inherits="TPCUATRI.NuevoTurno_Artista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        { %>

    <div class="row justify-content-center">
        <div class="col-md-4 text-center">
            <div class="mb-3 display-none">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control d-none"> </asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3" ">                        
                        <label class="form-label" id="lblLugarDisponible"><label>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Fecha </label>
                        <br />
                        <asp:DropDownList ID="ddlFecha" CssClass="btn btn-warning dropdown-toggle" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                </div>
        </div>
            <%}%>
</asp:Content>
