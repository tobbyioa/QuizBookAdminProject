<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CandidateErrorPage.aspx.cs" Inherits="QuizBook.Views.CandidateErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         .alert
            {
                background-color: #FFE;
                border: 1px solid red;
                margin: 10px 10px;
                overflow: auto;
                padding: 20px;
                word-wrap: break-word;
                -webkit-border-radius: 9px;
                -moz-border-radius: 9px;
                border-radius: 9px;
            }
        .style1
        {
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="alert">
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
    </div>
    </form>
</body>
</html>
