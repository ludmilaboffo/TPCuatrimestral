<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="TP_Programacion3.TurnosClass" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%    
         Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
    %>
    <div id="calendarioSemanal" class="m-lg-5">
        <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-dark" DataKeyNames="idTurno" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nº" DataField="FechaNum" />
                <asp:BoundField HeaderText="Día" DataField="FechaDia" />
                <asp:BoundField HeaderText="Lugar" DataField="NombreLugar"/>
                <asp:CommandField  ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Eliminar"/>
            </Columns>

        </asp:GridView>
    </div>
    <%} %>
</asp:Content>
