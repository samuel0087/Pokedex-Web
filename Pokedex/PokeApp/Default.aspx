<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokeApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="col-10">
        <div class="row row-cols-1 row-cols-md-4 g-4">

<%--            <%foreach(dominio.Pokemon pokemon in listaPokemon) { %>

                <div class="col">
                    <div class="card h-100">
                        <img src="<%: pokemon.UrlImagen == "" ? "https://www.vhv.rs/dpng/d/424-4249607_poke-ball-png-pokeball-png-transparent-png.png" : pokemon.UrlImagen %>" class="card-img-top" alt="<%: pokemon.Nombre %>">
                        <div class="card-body">
                            <h5 class="card-title"><%: pokemon.Nombre %></h5>
                            <p class="card-text"><%: pokemon.Descripcion %></p>
                            <a href="detalles.aspx?id=<%: pokemon.Id %>" class="btn btn-primary">Ver detalles</a>
                        </div>
                    </div>
                </div>

            <%} %>--%>

            <asp:Repeater runat="server" ID="repRepeater">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%# Eval("UrlImagen") == "" ? "https://www.vhv.rs/dpng/d/424-4249607_poke-ball-png-pokeball-png-transparent-png.png" : Eval("UrlImagen") %>" class="card-img-top" alt="<%# Eval("Nombre")%>">
                            <div class="card-body">
                                <h5 class="card-title"><%#  Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion")%></p>
                                <a href="detalles.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Ver detalles</a>
                                <asp:Button Text="Ejemplo" ID="btnEjemplo" CssClass="btn btn-danger"  runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="pokemonId" OnClick="btnEjemplo_Click" />
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>



            
        </div>
    </main>

</asp:Content>
