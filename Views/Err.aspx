<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Err.aspx.cs" Inherits="QuizBook.Views.Err" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="margin:0 auto; width:100%; ">
    <tr>
            <td colspan="2">
               
              <span id="ccode" runat="server">
                  <img src="../Images/delete.png" 
                    style="height: 24px; width: 24px"  /></span>
                    </td>
                   
        </tr>
        
         <tr>
            <td class="auto-style1">
               Application
            </td>
            <td>
              <span id="Span1" runat="server"><%=FidelityEquiz.Helpers.SessionHelper.FetchCurrentErrorApp(Session) %></span>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
               Message
            </td>
            <td >
                <span id="cname" runat="server"><%=FidelityEquiz.Helpers.SessionHelper.FetchCurrentErrorMessage(Session)%></span>
            </td>
        </tr>
          <tr>
            <td class="auto-style1">
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
