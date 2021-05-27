<%@ Page Title="Поступление материалов и оборудования" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaterialsIncomeByDate.aspx.cs" Inherits="WebSklad2.Forms.MaterialsIncomeByDate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.3.1.js"></script>
    <link href="Scripts/air-datepicker/dist/css/datepicker.css" rel="stylesheet" type="text/css">
    <script src="Scripts/air-datepicker/dist/js/datepicker.js"></script>
    
<%--    <script>
        $('.datepicker-here').datepicker([options])

        // Доступ к экземпляру объекта
        $('.datepicker-here').data('datepicker')

    </script>--%>

    <div class="container">
        <div class="row"><h2>Поступление материалов на склад</h2></div>
    </div>
    <div class="row">
        <div class="col-3">
            <label for="TextBox1">Диапозон дат</label>
            <asp:TextBox ID="TextBox1" autocomplete="off" runat="server" data-range="true" data-multiple-dates-separator=" - " class="datepicker-here" Width =" 200"></asp:TextBox>
           </div>
        
       
        <div class="col-4">
        <div class="row">
                <div class="w-100"> 
                    <asp:Label ID="Label3" runat="server" Text=" &nbsp"></asp:Label>
                </div>
                <asp:Button ID="Button3" runat="server" Text="Сформировать" class="btn btn-light" OnClick="Button1_Click"/>
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
                 <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-sm"></asp:GridView></div>
            </div>
        </div>
        </asp:Panel>
   </div>

</asp:Content>