<%@ Page Title="Статистика УГЭС" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatUGES.aspx.cs" Inherits="WebSklad2.Forms.Statistics.StatUGES" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="py-3 text-left">
        <h2>Статистика УГЭС</h2>
    </div>
    
<%--    <div class="row">
        <div class="col-sm-12">
            
            <div class="row">
                <div class="col-sm-3">
                    <div class="row">
                        <div class="w-100"> 
                            <h5><asp:Label ID="Label3" runat="server" Text=" &nbsp"></asp:Label></h5>   
                        </div>
                    <asp:Button ID="Button_stats" runat="server" Text="Сформировать" class="btn btn-light" OnClick="Button_stats_Click" />
                        </div>
                 </div>
             
             </div>
          </div>
        </div>--%>

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
                        <asp:Button ID="Button_xlc" runat="server" Text="Сохранить в Excel" class="btn btn-lght" OnClick="Button_xlc_Click1" />
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