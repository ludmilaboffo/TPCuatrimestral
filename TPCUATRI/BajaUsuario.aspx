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
            <asp:BoundField HeaderText="Nombre" DataField="nombreArtista" ItemStyle-ForeColor="white" />
            <asp:BoundField HeaderText="Apellido" DataField="apellidoArtista" ItemStyle-ForeColor="white" />
            <asp:BoundField HeaderText="Mail" DataField="mailArtista" ItemStyle-ForeColor="white"/>
            <asp:BoundField HeaderText="Telefono" DataField="telefonoArtista" ItemStyle-ForeColor="white"/>
            <asp:BoundField HeaderText="Redes Sociales" DataField="redesSociales" ItemStyle-ForeColor="white" />
            <asp:BoundField HeaderText="Tipo Espectaculo" DataField="tipoEspectaculo" ItemStyle-ForeColor="white" />
            <asp:BoundField HeaderText="Estado" DataField="estadoArtista" ItemStyle-ForeColor="green"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Cambiar Estado" HeaderText="Accion" ItemStyle-ForeColor="Red" />
        </Columns>
    </asp:GridView>
    <%
        }%>
</asp:Content>