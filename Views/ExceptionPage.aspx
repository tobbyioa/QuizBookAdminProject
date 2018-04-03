<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="ExceptionPage.aspx.cs" Inherits="QuizBook.Views.ExceptionPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="mainTable" class="row">
            <div id="loginHeader" class="col-xs-12 col-sm-12 col-md-12 headFont">Exception</div>
         <table class="table table-striped">
             <tr><td>
                 <asp:Label ID="msg" runat="server"><b>Message:</b></asp:Label><br />
                 <asp:Panel ID="messagePanel" runat="server" style="font-size: large; font-weight: 700"></asp:Panel>
                 
                 </td></tr>
             <tr>
                 <td>
                     <asp:Label ID="Label1" runat="server"><b>Stacktrace:</b></asp:Label><br />
                     <asp:Panel ID="Stacktrace" runat="server" style="font-size: large; font-weight: 700"></asp:Panel>
                 </td>
             </tr>

         </table></div>
</asp:Content>
