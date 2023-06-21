<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lugares.aspx.cs" Inherits="TPCUATRI.Lugares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater runat="server" ID="repLugares">
        <ItemTemplate>
            <div class="card mb-3">
                <img src="<%#Eval ("UrlImagen")%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 CssClass="card-title"><%#Eval("Nombre")%></h5>
                    <p CssClass="card-text"><%#Eval("Direccion")%></p>
                    <p CssClass="card-text"><%#Eval("Descripcion")%></p>
                    <p CssClass="card-text"><%#Eval("Direccion")%></p>            
                 <asp:Button ID="btnPedirTurno" CssClass="btn btn-primary" Text="Pedir turno" runat="server" ommandName="PedirTurno" CommandArgument='<%# Eval("idLugar") %>'  />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
