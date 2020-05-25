<%@ Page Title="Catalogo de compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoCompras.aspx.cs" Inherits="Vista.CatalogoDeCompras" %>

<asp:Content ID="CatalogodeCompras" ContentPlaceHolderID="app" runat="server">


    <div class="container">

        <header class="container-header">
            <div class="row">
                <div class="col-sm-3 container">
                    <asp:Image ID="imgLogo" cssClass="imgLogo" runat="server" ImageUrl="~/img/Logo.png" />
                </div>
                <div class="col-sm-6 container">
                    <nav class="navbar navbar-expand-lg navbar-light bg-light">
                        <asp:TextBox ID="tbxFiltro" CssClass="form-control mr-sm-2" placeholder="Que busca..." runat="server"></asp:TextBox>
                        <asp:Button ID="btnBuscar" CssClass="btn btn-outline-success my-2 my-sm-0" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </nav>
                </div>
                <div class="col-sm-3 container">
                    <asp:ImageButton ID="btnCarrito" cssClass="btnCarrito" runat="server" ImageUrl="~/img/btnCarrito.jpg" OnClick="ibtCarrito_Click" />
                </div>
            </div>
        </header>

        <section class="container-section-articulos">
            <div class="row">

                <div class="col-sm-12">
                    <article class=" panel-articulos">
                        <div class="card-columns">
                            <% foreach (var articulo in listaArticulos)
                                {%>

                            <div class="card tarjeta-catalogo" style="width: 18rem;">
                                <img class="card-img-top" src="<% = articulo.Imagen %>" alt="Card image cap">
                                <div class="card-body">
                                    <h5 class="card-title"><% = articulo.Nombre %></h5>
                                    <h6 class="card-title"><% = articulo.Precio %></h6>
                                    <a href="Detalle.aspx?idArticulo=<% = articulo.Id.ToString() %>" class="btn btn-primary">Detalle</a>
                                </div>
                            </div>

                            <%} %>
                        </div>
                    </article>
                </div>
            </div>
    </section>

        <footer class="container-footer">
            <div class="row">
                <div class="col-sm-4">
                    <p>Derecho de copyrigth</p>
                </div>
                <div class="col-sm-4">
                    <p>Autor</p>
                </div>
                <div class="col-sm-4">
                    <p>Fecha</p>
                </div>
            </div>
        </footer>

    </div>
</asp:Content>
