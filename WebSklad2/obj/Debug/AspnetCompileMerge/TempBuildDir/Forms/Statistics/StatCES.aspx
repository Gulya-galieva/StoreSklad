<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StatCES.aspx.cs" Inherits="WebSklad2.Forms.Statistics.StatCES" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class =" container">
       
    <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Получено ПУ</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <small class="text-muted">/ <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></small></h1>
            <ul class="list-unstyled mt-3 mb-4">
              <li>
                  <asp:Label ID="Label2" runat="server" Text="0 %"></asp:Label>
              </li>
              
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Настроено ПУ</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> 
                <small class="text-muted">/ <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label> </small></h1>
            <ul class="list-unstyled mt-3 mb-4">
                <li>
                    <asp:Label ID="Label6" runat="server" Text="0 %"></asp:Label></li>
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Собрано КДЕ</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title"> <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><small class="text-muted"> / <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></small></h1>
            <ul class="list-unstyled mt-3 mb-4">
              <li>
                  <asp:Label ID="Label9" runat="server" Text="0 %"></asp:Label></li>
              
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
      </div>


        <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Выдано на монтаж</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                <small class="text-muted">/ <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></small></h1>
            <ul class="list-unstyled mt-3 mb-4">
              <li>
                  <asp:Label ID="Label12" runat="server" Text="0 %"></asp:Label>
              </li>
              
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Установленно ТУ</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label> 
                <small class="text-muted">/ <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label> </small></h1>
            <ul class="list-unstyled mt-3 mb-4">
                <li>
                    <asp:Label ID="Label15" runat="server" Text="0 %"></asp:Label></li>
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
        <div class="card mb-4 box-shadow shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal">Брак</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title"> <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label><small class="text-muted"> / <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></small></h1>
            <ul class="list-unstyled mt-3 mb-4">
              <li>
                  <asp:Label ID="Label18" runat="server" Text="0 %"></asp:Label></li>
              
            </ul>
            <button type="button" class="btn btn-lg btn-block btn-secondary">Подробнее</button>
          </div>
        </div>
      </div>
       </div>
</asp:Content>
