<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="PokeApp.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista Pokemon</h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3 row">
                        <div class="col">
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFiltro" />
                        </div>
                        <div class="col-2">
                            <asp:Button Text="Filtrar" ID="btnFiltro" CssClass="btn btn-primary" OnClick="btnFiltro_Click" runat="server" />
                        </div>
                        <div class="col">
                            <asp:CheckBox OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" ID="chkFiltroAvanzado" AutoPostBack="true" runat="server" />
                            <asp:Label Text="FiltroAvanzado" CssClass="form-check-label" for="chkFiltroAvanzado" runat="server" />
                        </div>

                    </div>

                </div>
            </div>

            <%if (FiltroAvanzado)
                { %>
            <div class="row">
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">

                        <asp:ListItem Text="Seleccione una opcion" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Descripcion" />
                        <asp:ListItem Text="Numero" />

                    </asp:DropDownList>
                </div>

                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col">
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>

                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-select">
                        <asp:ListItem Text="Todo" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>

                <div class="col">
                    <asp:Button Text="Buscar" ID="btnFiltroAvanzado" CssClass="btn btn-success" OnClick="btnFiltroAvanzado_Click" runat="server" />
                </div>
            </div>
            <% } %>

            <hr />

            <div class="row">
                <div class="col-8">
                    <asp:GridView runat="server" ID="dgvPokemon" CssClass="table table-dark"
                        DataKeyNames="Id" AutoGenerateColumns="false"
                        OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
                        OnPageIndexChanging="dgvPokemon_PageIndexChanging"
                        AllowPaging="true" PageSize="5">

                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Numero" DataField="Numero" />
                            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Edit" />
                        </Columns>

                    </asp:GridView>
                    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
