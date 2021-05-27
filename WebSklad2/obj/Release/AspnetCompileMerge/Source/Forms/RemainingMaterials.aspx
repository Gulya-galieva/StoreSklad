<%@ Page Title="Остатки материалов и оборудования" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RemainingMaterials.aspx.cs" Inherits="WebSklad2.Forms.RemainingMaterials" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row"><h2>Остаток материалов на складе</h2></div>
    </div>
    <div class="row">
        <div class="col-2">
            <asp:Button ID="Button1" runat="server" Text="Материалы" class="btn btn-lght" OnClick="Button1_Click" />
        </div>
        <div class="col-2">
            <asp:Button ID="Button2" runat="server" Text="Оборудование" class="btn btn-lght" OnClick="Button2_Click" />
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
                 <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered"></asp:GridView></div>
            </div>
        </div>
        </asp:Panel>
   </div>

</asp:Content>