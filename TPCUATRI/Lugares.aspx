<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lugares.aspx.cs" Inherits="TPCUATRI.Lugares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%    
          Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
    %>
    <asp:Repeater runat="server" ID="repLugares">
        <ItemTemplate>
            <div class="card mb-3">
                <img src="<%#Eval ("UrlImagen")%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 CssClass="card-title"><%#Eval("Nombre")%></h5>
                    <p CssClass="card-text"><%#Eval("Direccion")%></p>
                    <p CssClass="card-text"><%#Eval("Descripcion")%></p>
                    <p CssClass="card-text"><%#Eval("Direccion")%></p>            
           <% if (((Dominio.Usuario)Session["user"]).isArtista()) 
            { %>
                    <asp:Button ID="btnPedirTurno" CssClass="btn btn-primary" Text="Pedir turno" runat="server" commandName="PedirTurno" CommandArgument='<%# Eval("idLugar") %>'  />
                    </div>
                </div>
             <% 
             } else if(((Dominio.Usuario)Session["user"]).isAdmin()){%>
                    <asp:Button ID="btnModificarLugar" CssClass="btn btn-primary" Text="Modificar" runat="server" commandName="Modificar" CommandArgument='<%# Eval("idLugar") %>'  />
                    </div>
            <%}%>
        </ItemTemplate>
    </asp:Repeater>
    <%} %>

</asp:Content>
