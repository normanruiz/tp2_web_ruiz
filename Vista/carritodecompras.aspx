<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="carritodecompras.aspx.cs" Inherits="Vista.carritodecompras" %>

<asp:Content ID="carritodecompras" ContentPlaceHolderID="app" runat="server">

    <header>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                    Total a pagar: <% = AcumuladorTotal %>
                </div>
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <a class="btn btn-primary btn-lg" href="CatalogoCompras.aspx" role="button">Realizar la compra</a>
                </div>
            </div>
        </div>
    </header>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Articulo</th>
                                <th scope="col">Precio</th>
                                <th scope="col">cantidad</th>
                                <th scope="col"></th>
                                <th scope="col"></th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (Modelo.Articulo articulo in ListaCarrito)
                                { %>
                            <tr>
                                <td scope="row" style="visibility: hidden;"><% = articulo.Id %></td>
                                <td>
                                    <p>
                                        <a class="btn btn-primary" data-toggle="collapse" href="#collapse-<% =articulo.Id %>" role="button" aria-expanded="false" aria-controls="collapseExample"><% = articulo.Nombre %></a>
                                    </p>
                                    <div class="collapse" id="collapse-<% =articulo.Id %>">
                                        <div class="card card-body">
                                            <div class="card mb-3" style="max-width: 540px;">
                                                <div class="row no-gutters">
                                                    <div class="col-md-4">
                                                        <img src="<% = articulo.Imagen %>" class="card-img" alt="<% = articulo.Nombre %>">
                                                    </div>
                                                    <div class="col-md-8">
                                                        <div class="card-body">
                                                            <h5 class="card-title"><% = articulo.Nombre %></h5>
                                                            <p class="card-text"><% = articulo.Descripcion %></p>
                                                            <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td><% = articulo.Precio %></td>
                                <td><% = listaCarrito[articulo.Id] %></td>
                                <td><a id="btnIncremento<% = articulo.Id %>" class="btn btn-primary btn-lg" href="carritodecompras.aspx?idIncrementar=<% = articulo.Id %>" role="button">+</a></td>
                                <td><a id="btnDecremento<% = articulo.Id %>" class="btn btn-primary btn-lg" href="carritodecompras.aspx?idDecrementar=<% = articulo.Id %>" role="button">-</a></td>
                                <td><a id="btnQuitar<% = articulo.Id %>" class="btn btn-primary btn-lg" href="carritodecompras.aspx?idQuitar=<% = articulo.Id %>" role="button">Quitar</a></td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>

    <footer>
        <div class="container">
            <div class="row">
                <div class="col-sm">
                </div>
                <div class="col-sm">
                    <a class="btn btn-primary btn-lg" href="CatalogoCompras.aspx" role="button">Buscar mas productos</a>
                </div>
                <div class="col-sm">
                    Cantidad de productos recolectados: <% = ContCantidad %>
                </div>
            </div>
        </div>
    </footer>

</asp:Content>
