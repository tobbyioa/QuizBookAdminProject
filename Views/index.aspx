<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuizBook.Views.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {

            font-size: large;
            font-weight:900;
            color: #006600;
            font-family: 'Varela Round';

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:400px;
       /*background-image: url(../Images/e_Quiz.gif);*/
        background-repeat:no-repeat;
        background-position:bottom center;" class="backImg">
        <div style="width:50%;margin-top:7%;margin-left:22%;clear:both; text-align: center;"
            class="style1">Welcome to QuizBook Admin Console</div>

</div>
</asp:Content>
