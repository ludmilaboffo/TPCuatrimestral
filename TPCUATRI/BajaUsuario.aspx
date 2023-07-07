<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaUsuario.aspx.cs" Inherits="TPCUATRI.BajaUsuarios_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
 <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        {

            if (usuario.isAdmin())
            { %>    
    <h1>LISTADO DE ARTISTAS</h1>
    <asp:GridView ID="dgvArtistas" runat="server" CssClass="table" OnSelectedIndexChanged="dgvArtistas_SelectedIndexChanged" datakeynames="IdArtista" AutoGenerateColumns="false" >
        <Columns>  
            <asp:BoundField HeaderText="ID" DataField="IdArtista" />
            <asp:BoundField HeaderText="Nombre" DataField="nombreArtista" />
            <asp:BoundField HeaderText="Apellido" DataField="apellidoArtista" />
            <asp:BoundField Headertext="Mail" DataField="mailArtista" />
             <asp:BoundField Headertext="Telefono" DataField="telefonoArtista" />
             <asp:BoundField Headertext="Direccion" DataField="direccionArtista" />
             <asp:BoundField Headertext="Estado" DataField="estadoArtista" />
            <asp:CommandField showselectbutton="true"  SelectText="Cambiar Estado" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
        <%}

        }%>
</asp:Content>