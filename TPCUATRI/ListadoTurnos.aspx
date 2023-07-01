<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="TP_Programacion3.TurnosClass" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <style>

  table {
    border-collapse: separate;
    border-spacing: 10px;
    border-color: deeppink;
  }

  th {
    padding-inline : 50px;
    column-fill:balance;
  }
  tr{
      border-color: dimgrey;
  }
</style>


    <%    
         Dominio.Usuario usuario = (Dominio.Usuario)HttpContext.Current.Session["user"];
        if (usuario != null)
        {
    %>
    <div id="calendarioSemanal" class="m-lg-5">
 <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-dark" DataKeyNames="id" AutoGenerateColumns="false" OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged">      
<Columns>
    <asp:TemplateField>
        <HeaderTemplate>
            <table>
                <tr>
                    <th></th> <!-- Celda vacía para el espacio en la esquina superior izquierda -->
                    <th>TURNOS AGENDADOS: LUGAR/DIA</th> <!-- Columna para mostrar "Lugar" como encabezado -->
                    <th></th> <!-- Columna para mostrar el día como encabezado -->
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table>
                <tr>
                    <td><%# Eval("NombreLugar") %></td> <!-- Columna para mostrar el nombre del lugar -->
                </tr>
                <tr>
                    <td><%# Eval("FechaDia") %> <%# Eval("FechaNum") %></td> <!-- Columna para mostrar el número de la fecha -->
                    <td>
                       <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" Text="Seleccionar"></asp:LinkButton> <!-- Botón de seleccionar/modificar/eliminar -->
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
        <asp:Button runat="server" CssClass="btn btn-outline-info" Text="Alta nuevo turno" ID="btnAltaTurno" OnClick="btnAltaTurno_Click" />
    </div>
    <%} %>
</asp:Content>
