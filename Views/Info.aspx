<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="QuizBook.Views.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainTable" class="row">
            <div id="loginHeader" class="col-xs-12 col-sm-12 col-md-12 headFont">Success</div>
         <table class="table table-striped">
             <tr><td>
                 <asp:Panel ID="messagePanel" runat="server" style="font-size: large; font-weight: 700"></asp:Panel>
                 </td></tr></table></div>
</asp:Content>
