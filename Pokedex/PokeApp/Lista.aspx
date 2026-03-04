<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="PokeApp.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista Pokemon</h1>

    <asp:GridView runat="server" ID="dgvPokemon" CssClass="table table-dark" 
        DataKeyNames="Id" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemon_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Edit"/>
        </Columns>

    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
