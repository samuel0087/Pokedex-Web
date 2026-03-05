<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DropDownListEnlazados.aspx.cs" Inherits="PokeApp.DropDownListEnlazados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <asp:DropDownList runat="server" ID="ddlTipo" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        
        <div class="col">
            <asp:Label Text="Pokemons" runat="server" />
            <asp:DropDownList runat="server" ID="ddlPokemonsFiltrados" CssClass="btn btn-outline-dark dropdown-toggle" ></asp:DropDownList>
        </div>
    </div>
</asp:Content>
