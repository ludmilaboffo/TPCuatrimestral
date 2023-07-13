<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaUsuario.aspx.cs" Inherits="TPCUATRI.BajaUsuarios_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;
        if (!usuario.esArtista)
        { %>
    <h1>LISTADO DE ARTISTAS</h1>
    <asp:GridView ID="dgvArtistas" runat="server" CssClass="table" OnSelectedIndexChanged="dgvArtistas_SelectedIndexChanged" DataKeyNames="IdArtista" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="IdArtista" />
            <asp:BoundField HeaderText="Nombre" DataField="nombreArtista" />
            <asp:BoundField HeaderText="Apellido" DataField="apellidoArtista" />
            <asp:BoundField HeaderText="Mail" DataField="mailArtista" />
            <asp:BoundField HeaderText="Telefono" DataField="telefonoArtista" />
            <asp:BoundField HeaderText="RedesSociales" DataField="redesSociales" />
            <asp:BoundField HeaderText="RedesSociales" DataField="tipoEspectaculo" />
            <asp:BoundField HeaderText="Estado" DataField="estadoArtista" />
            <asp:CommandField ShowSelectButton="true" SelectText="Cambiar Estado" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
    <%
        }%>
</asp:Content>
