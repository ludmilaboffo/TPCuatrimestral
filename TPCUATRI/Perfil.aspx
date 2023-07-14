<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPCUATRI.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row justify-content-center">
        <div class="col-md-6 mt-5">
            <div class="mb-3">
                <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;" >Tipo de espectaculo (musical/teatro/otros)</label>
                <asp:TextBox ID="txtTipoEspectaculo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;">Redes sociales</label>
                <asp:TextBox ID="txtRedes" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4 mt-5">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label"  style="font-family: 'Arial', sans-serif; font-size: 20px;">Imagen Perfil</label>
                        <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                    <asp:Image ID="imgFotoPerfil" runat="server" CssClass="img-fluid mb-3" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class=" text-center">
                <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnatras" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnatras_Click" />              
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="text-center  mt-3">
                      <asp:Button ID="btnBaja" runat="server" Text="Desactivar cuenta" CssClass="btn btn-danger" OnClick="btnBaja_Click" />                
                          </div>
                        <%if (confirmarEliminacion)
                            { %>
                        <div class="mb-3 mt-2">
                            <asp:CheckBox runat="server" Text="Confirmar eliminacion" ID="chEliminar" />
                         </div>
                         <div class="mb-3 mt-2">
                            <asp:Button runat="server" Text="Confirmar" ID="btnConfirmarEliminacion" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminacion_Click" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
