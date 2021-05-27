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
                <asp:Button ID="Button1" runat="server" Text="Сводный" CssClass="btn btn-light" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Краткий по фамилии" CssClass="btn btn-light" OnClick="Button2_Click"  />
                <asp:Button ID="Button3" runat="server" Text="Полный по фамилии"  CssClass="btn btn-light" OnClick="Button3_Click" />
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
                    </div>
                    <div class="text-right">
                        <asp:Button ID="Button4" runat="server" Text="Сохранить в Excel" class="btn btn-lght" OnClick="Button4_Click" />
                    </div>
                 </div>
            </div>
            <div class="card-body">
                 <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered"></asp:GridView></div>
            </div>
        </div>
    </div>
   

</asp:Content>
