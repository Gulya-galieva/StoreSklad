<%@ Page Title="Отчет по подрядчикам" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerReport.aspx.cs" Inherits="WebSklad2.Forms.WorkerReport" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class ="text-py-left">
        <h2>Отчет по подрядчикам</h2>
        </div>
    <div class="row">
        <div class="col-sm-12">
            <h4>Варианты построения отчета</h4>
            
            <div class="row">
                <div class="col-9">
                <asp:Button ID="Button1" runat="server" Text="Сводный" CssClass="btn btn-secondary" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Краткий по фамилии" CssClass="btn btn-secondary" OnClick="Button2_Click"  />
                <asp:Button ID="Button3" runat="server" Text="Полный по фамилии"  CssClass="btn btn-secondary" OnClick="Button3_Click" />
                <asp:Button ID="Button5" runat="server" Text="Для куратора" CssClass="btn btn-warning" OnClick="Button5_Click"/>
                </div>
                <div class="col-3">
                   <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text="" placeholder="Фамилия"></asp:TextBox>
                </div>
                </div>

            </div>
        
    </div>
    
    <div class="w-100"> 
        <h4> </h4>
    </div>
    
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-10">
                        <h5><asp:Label ID="Label1" runat="server" Text="Сводный отчет"></asp:Label></h5>
                        <asp:Panel ID="Panel1" runat="server">
                            <label for ="DropDownList1">Тип ПУ</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                            </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                             <label for ="DropDownList2">ФИО подрядчика</label>
                            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label for ="DropDownList3" ID="Label3" runat="server" Text="Дата получения оборудования"></asp:Label>
                            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </asp:Panel>
                    </div>
                    <div class="text-right">
                        <asp:Button ID="Button4" runat="server" Text="Сохранить в Excel" class="btn btn-lght" OnClick="Button4_Click" />
                    </div>
                 </div>
            </div>
            <div class="card-body">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-sm"></asp:GridView></div>
            </div>
        </div>
    </div>
   

</asp:Content>
