<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminView.Master" AutoEventWireup="true" CodeBehind="SessionExpired.aspx.cs" Inherits="QuizBook.Views.SessionExpired" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
        .style2
        {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 80%; height:auto; margin-top:20%;clear:both; text-align: center; margin-left: auto; margin-right: auto; margin-bottom: 0;" 
        class="style1">
    <strong><span class="style2">Your Session has Expired.</span><br /><br />Please <asp:LinkButton ID="LinkButton1" 
        runat="server" onclick="LinkButton1_Click">Click Here</asp:LinkButton>&nbsp;to re-login
    </strong>
</div>
</asp:Content>
