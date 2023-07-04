<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaArtista.aspx.cs" Inherits="TPCUATRI.AgendaArtista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%
        Dominio.Usuario usuario = HttpContext.Current.Session["user"] as Dominio.Usuario;
        if (usuario != null)
        {
            if (usuario.isArtista())
            { %>  
            <div id="turnosArtists" class="m-lg-5">
                <asp:GridView ID="dgvAgenda" runat="server" RowStyle-BackColor="White" RowStyle-ForeColor="Black" HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
                    Font-Names="Bahnschrift SemiBold" HeaderStyle-BackColor="#6699ff" CssClass="table table-group-divider" DataKeyNames="id" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Dia" DataField="FechaDia"></asp:BoundField>
                        <asp:BoundField HeaderText="Lugar" DataField="NombreLugar"></asp:BoundField>
                        <asp:BoundField HeaderText="Vigente" DataField="ocupado"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                </div>
        <%}

        }%>
</asp:Content>