<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ObjectRegistry.aspx.cs" Inherits="WebSklad2.Forms.ObjectRegistry" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
       <h3>
           Реестр по ТП/РП (ПНР)
       </h3>
       <div class="w-100"> 
                    <h6>&nbsp</h6>
       </div>
        <div class="row">
        <div class="col-sm-12">
            <h4>Варианты построения отчета</h4>
            
            <div class="row">
                <div class="col-9">
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                        <asp:ListItem>Реестр ПУ по ТП ПНР</asp:ListItem>
                        <asp:ListItem>Список ПУ для УСПД</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                </div>

            </div>
        
    </div>
         <div class="w-100"> 
                    <h6>&nbsp</h6>
       </div>
        <div class ="row">
           <div class ="col-3">
                <label for="DropDownList1">РЭС</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
           </div>
           <div class ="col-3">
                <label for="DropDownList2">ТП/РП</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
            </div>
           <div class="col-3">
                   <div class="col">
                       <div class="w-100"> 
                    <h5><asp:Label ID="Label3" runat="server" Text=" &nbsp"></asp:Label></h5>   
                </div>
                        <asp:Button ID="Button4" runat="server" Text="Сохранить в Excel" class="btn btn-seconadary" OnClick="Button4_Click" />
                    </div>
           </div>
            
       </div>
        <div class="row">
            <div class="col">
                <div class="w-100"> 
                    <h6>&nbsp</h6>
                </div>
                <label for="CheckBox1">Одним файлом</label>
                <asp:CheckBox ID="CheckBox1" runat="server" />
             </div>
        </div>
       </div>
</asp:Content>
