<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuInicio.aspx.cs" Inherits="TPCUATRI.MenuInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-4">
            <h1 class="text-center display-1">MENU PRINCIPAL</h1>
            <div class="card border-info mb-3" style="max-width: 38rem;">
                <div class="card-header">USUARIOS</div>
                <div class="card-body">
                    <h5 class="card-title">Dar de baja a un usuario del sistema</h5>
                    <a hrf="#">Ir</a>
                </div>
            </div>
            <div class="card border-success mb-3" style="max-width: 38rem;">
                <div class="card-header">ESPACIOS</div>
                <div class="card-body text-success">
                    <h5 class="card-title">Agregar un nuevo espacio para espectaculos</h5>
                    <a hrf="#">Ir</a>
                    <h5 class="card-title">Dar de baja un espacio existente</h5>
                    <a hrf="#">Ir</a>
                    <h5 class="card-title">Modificar un espacio existente</h5>
                    <a hrf="#">Ir</a>
                </div>
            </div>
            <div class="card border-dark mb-3" style="max-width: 38rem;">
                <div class="card-header">AGENDA</div>
                <div class="card-body">
                    <h5 class="card-title">Dar de alta nuevos horarios</h5>
                    <a hrf="#">Ir</a>
                    <h5 class="card-title">Dar de baja horarios ya disponibles</h5>
                    <a hrf="#">Ir</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
