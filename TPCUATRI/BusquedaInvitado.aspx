<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaInvitado.aspx.cs" Inherits="TPCUATRI.BusquedaInvitado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table-container {
            width: 600px;
            height: 600px;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            color: white;
        }

            .table th,
            .table td {
                padding: 8px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }

            .table th {
                background-color: transparent;
                font-weight: bold;
            }

            .table tr:hover {
                background-color: lightblue;
            }

        .hover-h1:hover {
            color: lightblue;
        }

        h1 {
            font-size: 80px;
            font-family: 'Bebas Neue', sans-serif;
        }


    </style>



    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <h1 class="hover-h1">BUSQUEDA DE ARTISTAS</h1>
                    <div class="mb-3">
                        <asp:Label ID="lblFiltro" style=" font-size: 15px; font-style:italic;" runat="server" Text="Ingrese el nombre del artista o el tipo de espectaculo que dio"></asp:Label>
                    </div>
                    <div class="mb-3">
                        <asp:TextBox ID="txtFiltro" runat="server" AutoPostBack="true" CssClass="fa-search" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="table-container">
                    <asp:GridView ID="dgvBusquedaArtistas" runat="server" OnSelectedIndexChanged="dgvBusquedaArtistas_SelectedIndexChanged" DataKeyNames="IdArtista" AutoGenerateColumns="false"
                        HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
                        Font-Names="Bahnschrift SemiBold" CssClass="table table-hover" OnPageIndexChanging="dgvBusquedaArtistas_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Artista" DataField="nombreArtista" />
                            <asp:BoundField HeaderText="Más información de sus espectáculos..." DataField="redesSociales" />
                            <asp:BoundField HeaderText="Show" DataField="tipoEspectaculo" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

