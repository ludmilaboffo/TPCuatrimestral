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
    <asp:GridView ID="dgvArtistas" runat="server" CssClass="table" OnSelectedIndexChanged="dgvArtistas_SelectedIndexChanged" datakeynames="Id" AutoGenerateColumns="false" >
        <Columns>  
            <asp:BoundField HeaderText="ID" DataField="IdArtista" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField Headertext="Mail" DataField="Mail" />
             <asp:BoundField Headertext="Telefono" DataField="Telefono" />
             <asp:BoundField Headertext="Direccion" DataField="Direccion" />
             <asp:BoundField Headertext="Estado" DataField="Estado" />
            <asp:CommandField showselectbutton="true"  SelectText="Suspender" HeaderText="Accion" />
        </Columns>
    </asp:GridView>
        <%}

        }%>
</asp:Content>