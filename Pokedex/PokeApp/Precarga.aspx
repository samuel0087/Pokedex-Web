<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Precarga.aspx.cs" Inherits="PokeApp.Precarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Pre carga de imagen</h3>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="bm-3 row">
                <div class="col">
                    <label class="form-label">Url de la imagen solicitada</label>
                    <asp:TextBox runat="server" ID="txtImagen" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" />
                </div>
            </div>

            <div class="mb-8">
                <div class="col">
                    <img src="<%: urlImagen %>" alt="Alternate Text" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
