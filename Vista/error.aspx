<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Vista.error" %>

<asp:Content ID="error" ContentPlaceHolderID="app" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm">
                <div class="jumbotron">
                    <h1 class="display-4">Ups !!!</h1>
                    <p class="lead">Algo a ocurrido...</p>
                    <hr class="my-4">
                    <p>Cuando la logica me funcione o se me caiga alguna idea, aca va a llegar magicamente el detalle del error.</p>
                    <p><%: Session["Session_id_" + Session.SessionID + "_error"].ToString() %></p>
                    <a class="btn btn-primary btn-lg" href="./catalogocompras.aspx" role="button">Volver al inicio</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
