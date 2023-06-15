<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="TP_Programacion3.TurnosClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="calendarioSemanal" class="m-lg-5">
    <asp:GridView ID="dgvCalendario" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Hora" HeaderText="Hora" />
            <asp:BoundField DataField="Lunes" HeaderText="Lunes" />
            <asp:BoundField DataField="Martes" HeaderText="Martes" />
            <asp:BoundField DataField="Miércoles" HeaderText="Miércoles" />
            <asp:BoundField DataField="Jueves" HeaderText="Jueves" />
            <asp:BoundField DataField="Viernes" HeaderText="Viernes" />
        </Columns>
    </asp:GridView>
    </div>

</asp:Content>
