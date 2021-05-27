<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="uspd.aspx.cs" Inherits="WebSklad2.Forms.uspd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container">
       <h3>
           УСПД
       </h3>
       <div class="w-100"> 
                    <h6>&nbsp</h6>
       </div>
        <div class="row">
        <div class="col-sm-12">
            <h4>Привязка УСПД к ТП</h4>
            
                        </div>
        
    </div>
         <div class="w-100"> 
                    <h6>&nbsp</h6>
       </div>
        <div class ="row">
           <div class ="col-2">
                <label for="DropDownList1">РЭС</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
           </div>
           <div class ="col-2">
                <label for="DropDownList2">ТП/РП</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>
             <div class ="col-3">
                <label for="DropDownList3">Заводской № УСПД</label>
                 <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"></asp:DropDownList> 
            </div>
            <div class ="col-2">
                <label for="TextBox1">Номер сим</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
           <div class="col-3">
                   <div class="col">
                       <div class="w-100"> 
                    <h5><asp:Label ID="Label3" runat="server" Text=" &nbsp"></asp:Label></h5>   
                </div>
                        <asp:Button ID="Button4" runat="server" Text="Привязать" class="btn btn-seconadary" OnClick="Button4_Click"/>
                    </div>
           </div>

       </div>
       </div>
</asp:Content>
