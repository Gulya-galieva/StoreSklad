<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSklad2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="Images/логотип%20КУРС%20склад.png" />
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Остатки на складе</h2>
            <p>
               Отчет по остаткам материалов и оборудования на складе.
            </p>
            <p>
                <a runat="server" class="btn btn-light" href="~/Forms/RemainingMaterials">Перейти &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Поступления на склад</h2>
            <p>
                ...
            </p>
            <p>
                <a class="btn btn-light" href="#">Перейти &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Выдача со склада</h2>
            <p>
                ...
            </p>
            <p>
                <a class="btn btn-light" href="#">Перейти &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
