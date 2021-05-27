<%@ Page Title="Движение оборудования" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeviceMovingUGES.aspx.cs" Inherits="WebSklad2.Forms.DeviceMovingUGES" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row"><h2>Движение оборудования по складу УГЭС</h2></div>
    </div>
    <div class="row">
        <div class="col-3">
            <label for="DropDownList1">Тип оборудования</label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass ="form-control" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DataConnectionUGES %>" SelectCommand="SELECT DISTINCT [Name] FROM [Reg_device_type]"></asp:SqlDataSource>
        </div>
        <div class="col-3">
           <label for="TextBox1">Заводской номер ПУ</label>
           <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-6">
            <div class="row">
                <div class="w-100"> 
                    <h5><asp:Label ID="Label3" runat="server" Text=" &nbsp"></asp:Label></h5>   
                </div>
                <asp:Button ID="Button1" runat="server" Text="Поиск" class="btn btn-secondary" OnClick="Button1_Click"/>
            </div>
        </div>
    </div>

    <div class="py-3 text-left">
        <h5><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h5>
    
    <asp:Panel ID="Panel1" runat="server">
    <div class="card" id="report">
            <div class="card-header">
                <div class="row">
                    <div class="col-10">
                        <h5><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h5>
                    </div>
                    <div class="col">
                        <asp:Button ID="Button4" runat="server" Text="Сохранить в Excel" class="btn btn-lght" />
                    </div>
                 </div>
            </div>
        <div class="card-body">
            <div>
                 <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered"></asp:GridView></div>                
            </div>
            <div>
                <asp:Panel ID="Panel2" runat="server">
                    <p>Адрес места установки ТУ: </p>
                    <asp:GridView ID="GridView2" runat="server" class="table table-sm table-bordered"></asp:GridView>
                </asp:Panel>
            </div>
            </div>
        </div>
        </asp:Panel>
        <div>
            <asp:Panel ID="Panel3" runat="server">
                <h5><asp:Label ID="Label4" runat="server" Text=""></asp:Label></h5>
            </asp:Panel>
        </div>
   </div>

</asp:Content>