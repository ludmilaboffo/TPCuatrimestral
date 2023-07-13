<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaInvitado.aspx.cs" Inherits="TPCUATRI.BusquedaInvitado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <div class="mb-3">
                        <asp:Label ID="lblFiltro" runat="server" Text="Ingrese el nombre del artista o el tipo de espectaculo que dio"></asp:Label>
                       </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtFiltro" runat="server" AutoPostBack="true" CssClass="fa-search" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                    </div>
                </div>
            </div>
            <h1>Artistas</h1>
            <asp:GridView ID="dgvBusquedaArtistas" runat="server" OnSelectedIndexChanged="dgvBusquedaArtistas_SelectedIndexChanged" DataKeyNames="IdArtista" AutoGenerateColumns="false"
                RowStyle-BackColor="White" RowStyle-ForeColor="Black" HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
                Font-Names="Bahnschrift SemiBold" HeaderStyle-BackColor="#6699ff" CssClass="table table-group-divider" OnPageIndexChanging="dgvBusquedaArtistas_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="nombreArtista" />
                    <asp:BoundField HeaderText="Redes sociales" DataField="redesSociales" />
                    <asp:BoundField HeaderText="Tipo de espectaculo" DataField="tipoEspectaculo" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
