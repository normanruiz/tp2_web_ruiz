<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Vista.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="app" runat="server">

    <div class="container">
        <div class="jumbotron">
            <img src="<% = articuloDetalle.Imagen %>" alt="<% = articuloDetalle.Nombre %>" />
            <h1 class="display-4"><% = articuloDetalle.Nombre %></h1>
            <p class="lead"><% = articuloDetalle.Precio %></p>
            <hr class="my-4">
            <p><% = articuloDetalle.Descripcion %></p>
            <a class="btn btn-primary btn-lg" href="CatalogoCompras.aspx" role="button">Ir al catalogo</a>
            <asp:Button id="btnCArgarCArrito" cssClass="btn btn-primary btn-lg" Text="Cargar al carrito" runat="server" OnClick="btnCArgarCArrito_Click" />
        </div>
    </div>

</asp:Content>
