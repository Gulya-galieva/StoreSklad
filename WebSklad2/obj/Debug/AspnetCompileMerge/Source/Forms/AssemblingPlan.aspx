<%@ Page Title="План сборки" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssemblingPlan.aspx.cs" Inherits="WebSklad2.Forms.AssemblingPlan" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <h3>Возможное количество шкафов учета при текущем количестве материалов и оборудования
           ( на <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> )
       </h3>
       <div class="w-100"> 
                    <h6>&nbsp</h6>
       </div>

       <div class="card-deck mb-3 text-center">
           
           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">КДЕ-1 PLC</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                   </h1>
                   
               </div>
            </div>
        

           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">КДЕ-1 GSM</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                   </h1>
                  
               </div>
            </div>

           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">КДЕ-3 PLC</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                   </h1>
                   
               </div>
            </div>
       
       
       </div>

          <div class="card-deck mb-3 text-center">
           
           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">КДЕ-3 GSM</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                   </h1>
                   
               </div>
            </div>
        

           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">Шкаф УСПД + Вводной ПУ</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                   </h1>
                  
               </div>
            </div>

           <div class="card mb-4 box-shadow shadow">
               <div class="card-header">
                   <h4 class="my-0 font-weight-normal">Шкаф Вводной</h4>
               </div>
               <div class="card-body">
                   <h1 class="card-title pricing-card-title">
                       <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                   </h1>
                   
               </div>
            </div>
       
       
       </div>

   </div>
</asp:Content>
