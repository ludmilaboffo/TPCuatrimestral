<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarLugares.aspx.cs" Inherits="TPCUATRI.EditarLugares" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager2"></asp:ScriptManager>
    <%    
        Dominio.Artista usuario = (Dominio.Artista)HttpContext.Current.Session["Artista"];
            if (!usuario.esArtista) { 
    %>

    <div class="row justify-content-center">
        <div class="col-md-4">
            <div class="mb-3 mt-5 display-none">
                <label class="form-label">ID</label>
                <asp:TextBox ID="txtID" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <asp:UpdatePanel runat="server" ID="udModificar" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Direccion</label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Descripcion</label>
                        <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    </div>
       
                   <div class="mb-3">
                       <label for="txtImgLugar" class="form-label">URL Imagen: </label>
                       <asp:TextBox runat="server" ID="txtImgLugar" CssClass="form-control"
                           AutoPostBack="true" OnTextChanged="txtImgLugar_TextChanged" />
                   </div>
                   <asp:Image ImageUrl="https://media.istockphoto.com/vectors/thumbnail-image-vector-graphic-vector-id1147544807?k=20&m=1147544807&s=612x612&w=0&h=pBhz1dkwsCMq37Udtp9sfxbjaMl27JUapoyYpQm0anc="
                       runat="server" ID="imgLugar" Width="60%" Style="margin-left: 110px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row justify-content-center">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar cambios" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar cambios" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
            </div>
               <div class="mb-3">
                <asp:Button ID="btnInhabilitar" runat="server" Text="Inhabilitar" CssClass="btn btn-light" OnClick="btnInhabilitar_Click" />
            </div>
        </div>
    </div>
    <div class="row justify-content-center">
        <div class="col-6">
            <asp:UpdatePanel ID="upEliminar" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button runat="server" Text="Eliminar" ID="btnEliminarLugar" CssClass="btn btn-danger" OnClick="btnEliminarLugar_Click1" />
                        <a href="MenuInicio.aspx">Volver al menú de inicio</a>
                    </div>

                    <%if (eliminarLugar)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox runat="server" Text="Confirmar eliminacion" ID="chConfirmarEliminarLugares" />
                        <asp:Button runat="server" Text="Confirmar" ID="btnConfirmarLugares" CssClass="btn btn-outline-danger" OnClick="btnConfirmarLugares_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <%}%>
</asp:Content>
