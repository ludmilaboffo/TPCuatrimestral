﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="TPCUATRI.TurnosClass" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <div id="calendarioSemanal" class="m-lg-5 mt-5">
        <asp:GridView ID="gvTurnos" runat="server" RowStyle-BackColor="White" RowStyle-ForeColor="Black" HeaderStyle-Font-Names="Bahnschrift SemiBold" HeaderStyle-Font-Size="Larger"
            Font-Names="Bahnschrift SemiBold" HeaderStyle-BackColor="#6699ff" CssClass="table table-group-divider" DataKeyNames="id" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Dia" DataField="FechaDia"></asp:BoundField>
                <asp:BoundField HeaderText="Lugar" DataField="NombreLugar"></asp:BoundField>
               <asp:CheckBoxField HeaderText="Alta del turno" DataField="Disponibilidad" />
                 <asp:TemplateField HeaderText="Está ocupado">
                    <ItemTemplate>
                        <asp:Label ID="lblOcupado" runat="server" Text='<%# (bool)Eval("ocupado") ? "Si" : "No" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Administrar" ShowSelectButton="true" SelectText="Ver detalles"></asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:Button runat="server" CssClass="btn btn-outline-info" Text="Alta nuevo turno" ID="btnAltaTurno" OnClick="btnAltaTurno_Click" />
    </div>
</asp:Content>
