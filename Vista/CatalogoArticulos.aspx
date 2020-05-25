<%@ Page Title="Catalogo de Articulos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoArticulos.aspx.cs" Inherits="Vista.CatalogoArticulos" %>

<asp:Content ID="CatalogoArticulos" ContentPlaceHolderID="app" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-3 container">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/img/Logo.png" />
            </div>
            <div class="col-6 container">
                <asp:Label ID="lblTitulo" Text="Catalogo de articulos" runat="server" Font-Size="Medium" />
            </div>
            <div class="col-3 container">
                <asp:ImageButton ID="btnSalir" CssClass="btn btn-primary" runat="server" ImageUrl="~/img/btnSalirVolver.png" />
            </div>
        </div>

        <div class="row">
            <div class="col-2">
            </div>
            <div class="col-10">
                <nav class="navbar navbar-expand-lg navbar-light bg-light">

                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav mr-auto">
                            <li>
                                <asp:TextBox ID="tbxCodigo" class="form-control" placeholder="Filtrar por codigo..." runat="server"></asp:TextBox>
                            </li>
                            <li>
                                <asp:TextBox ID="tbxNombre" class="form-control" placeholder="Filtrar por Nombre..." runat="server"></asp:TextBox>
                            </li>
                            <li>
                                <asp:TextBox ID="tbxDescripcion" class="form-control" placeholder="Filtrar por descripcion..." runat="server"></asp:TextBox>
                            </li>
                            <li>
                                <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
                            </li>
                            <li>
                                <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>

        </div>

        <div class="row">
            <div class="col-2">
                <div class="row">
                    <div class="col-sm">
                        <asp:ImageButton ID="btnNuevo" CssClass="btn btn-primary" runat="server" ImageUrl="~/img/btnNuevo.png" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm">
                        <asp:ImageButton ID="btnModificar" CssClass="btn btn-primary" runat="server" ImageUrl="~/img/btnModificar.png" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm">
                        <asp:ImageButton ID="btnElimnar" CssClass="btn btn-primary" runat="server" ImageUrl="~/img/btnEliminar.png" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm">
                        <asp:ImageButton ID="btnDetalle" CssClass="btn btn-primary" runat="server" ImageUrl="~/img/btnDetalle.png" />
                    </div>
                </div>
            </div>
            <div class="col-10">
                <asp:GridView ID="gvCatalogo" CssClass="table table-striped table-dark" runat="server" AllowSorting="False"></asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-sm">
            </div>
            <div class="col-sm">
                <nav aria-label="Page navigation example">
                    <ul class="pagination justify-content-center">
                        <li class="page-item disabled">
                            <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
                        </li>
                        <li class="page-item"><a class="page-link" href="#">1</a></li>
                        <li class="page-item"><a class="page-link" href="#">2</a></li>
                        <li class="page-item"><a class="page-link" href="#">3</a></li>
                        <li class="page-item">
                            <a class="page-link" href="#">Next</a>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="col-sm">
            </div>
        </div>

    </div>

</asp:Content>
