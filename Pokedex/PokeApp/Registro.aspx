<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PokeApp.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Registro Trainee</h2>

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password"/>
            </div>
            <asp:Button Text="Registrarse" runat="server" ID="btnRegistro" CssClass="btn btn-primary" OnClick="btnRegistro_Click"/>
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
