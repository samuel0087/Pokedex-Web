<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PokeApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Ingresa a la aplicacion</h2>

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password"/>
            </div>
            <asp:Button Text="Ingresar" runat="server" ID="btnLogin" CssClass="btn btn-primary" OnClick="btnLogin_Click"/>
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
