<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosInicio.aspx.cs" Inherits="TP_Programacion3.TurnosClass" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%    
         Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
    %>
    <div id="calendarioSemanal" class="m-lg-5">
        <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-dark" DataKeyNames="idTurno" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Fecha turno" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:BoundField HeaderText="Lugar turno" DataField="nombreLugar"/>
                <asp:BoundField HeaderText="Disponibilidad" DataField="disponibilidad" />
                <asp:CommandField  ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Eliminar"/>
            </Columns>

        </asp:GridView>
    </div>
    <%} %>
</asp:Content>
