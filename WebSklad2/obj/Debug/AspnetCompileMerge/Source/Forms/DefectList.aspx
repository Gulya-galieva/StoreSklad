<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DefectList.aspx.cs" Inherits="WebSklad2.Forms.DefectList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class ="text-py-left">
          </div>
    
    
    <div class="w-100"> 
        <h4> </h4>
    </div>
    
        <div class="card">
            <div class="card-header">
                <div class="row">
                    <div class="col-10">
                       <h2>Список браковонного оборудования</h2>
                    </div>
                    <div class="text-right">
                        <asp:Button ID="Button4" runat="server" Text="Сохранить в Excel" class="btn btn-lght" OnClick="Button4_Click" />
                    </div>
                 </div>
            </div>
            <div class="card-body">
                <div class ="py-3 text-left"> <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-sm"></asp:GridView></div>
            </div>
        </div>
    </div>
   

</asp:Content>

