<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="PokeApp.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-5">
            <h1>Pefil de usuario</h1>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"/>
            </div>
            

        </div>

        <div class="col-5">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
            </div>


            <asp:Image ID="imgNuevoPerfil"  ImageUrl="imageurl" runat="server" CssClass="img-fluid mb-3" />
            
        </div>
    </div>
</asp:Content>
