<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaUsuario.aspx.cs" Inherits="TPCUATRI.BajaUsuarios_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table {
            border-collapse: separate;
            border-spacing: 10px;
            border-color: deeppink;
        }

        th {
            padding-inline: 50px;
            column-fill: balance;
        }

        tr {
            border-color: dimgrey;
        }

        .custom-checkbox .custom-control-input:checked ~ .custom-control-label::before {
            background-color: #000000;
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <%

        Dominio.Artista usuario = HttpContext.Current.Session["Artista"] as Dominio.Artista;
        if (!usuario.esArtista)
        { %>
    <div class="row justify-content-center">
        <h1 class="text-center" style="font-family: 'Bebas Neue', sans-serif; color: white; margin-bottom: 10px; margin-top: 30px;">LISTADO DE ARTISTAS</h1>
        <asp:GridView ID="dgvArtistas" runat="server" RowStyle-BackColor="White" RowStyle-ForeColor="Black" HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
            Font-Names="Bahnschrift SemiBold" HeaderStyle-BackColor="#6699ff" CssClass="table table-group-divider" OnSelectedIndexChanged="dgvArtistas_SelectedIndexChanged" DataKeyNames="IdArtista" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField HeaderText="Nombre" DataField="nombreArtista" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Apellido" DataField="apellidoArtista" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Mail" DataField="mailArtista" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Telefono" DataField="telefonoArtista" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Redes Sociales" DataField="redesSociales" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Tipo Espectaculo" DataField="tipoEspectaculo" ItemStyle-ForeColor="black" />
                <asp:BoundField HeaderText="Activo en el sistema" DataField="estadoArtista" ItemStyle-ForeColor="green" />
                <asp:CommandField ShowSelectButton="true" SelectText="Cambiar Estado" HeaderText="Accion" ItemStyle-ForeColor="Red" />
            </Columns>
        </asp:GridView>

        <a href="MenuInicio.aspx">Volver atrás</a>
    </div>
    <%
        }%>
</asp:Content>
