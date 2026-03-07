<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="PokeApp.UpdatePanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
    <hr />

    <h3>Update Panel</h3>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <div class="row">
                    <div class="col">
                        <asp:Label Text="text" ID="lblNombre" runat="server" />
                    </div>

                    <div class="col">
                        <asp:TextBox runat="server" ID="txtNombre" AutoPostBack="true" OnTextChanged="txtNombre_TextChanged" CssClass="form-control"/>
                    </div>

                    <div class="col">
                        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <hr />

    <h3>Mas ejemplos</h3>

</asp:Content>


