<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ActivateCandidateSession.aspx.cs" Inherits="QuizBook.Views.ActivateCandidateSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
      $(function () {
          $("#<%=check.ClientID %>").button();
          $("#<%=resultLbl.ClientID %>").fadeOut(10000);
          $("#<%=check.ClientID %>").click(function () {
              if ($("#<%=check.ClientID %>").val().length < 1) {
                  return false;
              }
          });

          $('#<%=check.ClientID %>').keyup(function () {
              var txt = $('#<%=Code.ClientID %>').val();
              if (txt.length < 1) {
                  alert("Please enter a Candidate code.");
                  return false;
              }
          });
      });
    </script>
    <style type="text/css">
.red
{
    color:Red;
    text-align:center;
    font-weight:bold;
}

.black
{
    color:Black;
    font-weight:bold;
}
    .style1
    {
        width: 200px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Activate Test Session</legend>
<hr style="width:100%;" />

<table>
<tr><td style="font-weight: bold;">Enter Candidate Code:</td><td>
    <asp:TextBox ID="Code" runat="server"></asp:TextBox>
    </td><td colspan="2" class="style1"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>
<tr><td></td><td>
    <asp:Button ID="check" runat="server" Text="Activate" 
        CssClass="btnstyle" onclick="check_Click"/></td><td class="style1"></td></tr>
        
</table>
<hr style="width:100%;" />
</fieldset>
</div>
</asp:Content>
