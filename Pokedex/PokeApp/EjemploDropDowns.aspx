<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EjemploDropDowns.aspx.cs" Inherits="PokeApp.EjemploDropDowns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col">
            <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlColores">
                <asp:ListItem Text="Rojo" />
                <asp:ListItem Text="Azul" />
                <asp:ListItem Text="Negro" />
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlPokemons"></asp:DropDownList>
        </div>

        <a href="DropDownListEnlazados.aspx">DropDownlist Enlazados</a>
        <a href="#">Update Panel</a>
        <a href="#">DropDownList con UpdatePanel</a>
        <a href="#">Seccion de elementos</a>

    </div>

</asp:Content>
