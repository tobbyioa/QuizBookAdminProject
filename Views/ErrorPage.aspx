<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="QuizBook.Views.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="margin:0 auto; width:100%; ">
    <tr>
            <td colspan="2">
               
              <span id="ccode" runat="server">
                  <img src="../Images/delete.png" 
                    style="height: 24px; width: 24px"  /></span>
                    </td>
                   
        </tr>
        
         <tr>
            <td class="style1">
               Application
            </td>
            <td>
              <span id="Span1" runat="server"><%=FidelityEquiz.Helpers.SessionHelper.FetchCurrentErrorApp(Session) %></span>
            </td>
        </tr>
        <tr>
            <td class="style1">
               Message
            </td>
            <td >
                <span id="cname" runat="server"><%=FidelityEquiz.Helpers.SessionHelper.FetchCurrentErrorMessage(Session)%></span>
            </td>
        </tr>
          <tr>
            <td class="style1">
            StackTrace
            </td>
            <td>
                <span id="cgrade" runat="server"><%=FidelityEquiz.Helpers.SessionHelper.FetchCurrentErrorMethod(Session)%></span>
            </td>
        </tr>
    </table>
</asp:Content>
