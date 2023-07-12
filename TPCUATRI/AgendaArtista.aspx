<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendaArtista.aspx.cs" Inherits="TPCUATRI.AgendaArtista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%
        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;

            if (usuario.esArtista)
            { %>
    <div id="turnosArtists" class="m-lg-5">
        <asp:GridView ID="dgvAgenda" runat="server" RowStyle-BackColor="White" RowStyle-ForeColor="Black" HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
            Font-Names="Bahnschrift SemiBold" HeaderStyle-BackColor="#6699ff" CssClass="table table-group-divider" DataKeyNames="id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvAgenda_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Dia" DataField="FechaDia"></asp:BoundField>
                <asp:BoundField HeaderText="Lugar" DataField="NombreLugar"></asp:BoundField>
                <asp:TemplateField HeaderText="Vigente">
                    <ItemTemplate>
                        <asp:Label ID="lblVigente" runat="server" Text='<%# (bool)Eval("Vigente") ? "Si" : "No" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>        
        </asp:GridView>
    </div>
    <footer>
        En caso que su turno aparezca como "no vigente" consulte la disponiblidad del lugar. Es posible que el administrador haya realizado un cambio imprevisto.
    </footer>
    <%}%>
</asp:Content>
