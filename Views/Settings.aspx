<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="QuizBook.Views.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-weight: 700;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#<%=CutOff.ClientID %>").button();
            $("#<%=Qptbtn.ClientID %>").button();

            $('#<%=Coff.ClientID %>').keyup(function () {

                if (!(isNumeric($('#<%=Coff.ClientID %>').val()))) {

                    alert("Only Numeric inputs are allowed");
                    $('#<%=Coff.ClientID %>').val("");
                }

            });
            $('#<%=Qpt.ClientID %>').keyup(function () {

                if (!(isNumeric($('#<%=Qpt.ClientID %>').val()))) {

                    alert("Only Numeric inputs are allowed");
                    $('#<%=Qpt.ClientID %>').val("");
                }

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend>Update Settings</legend>
<br />
<table>
<tr><td class="style1">Cut-Off: </td><td>
    <asp:HiddenField ID="coffId" runat="server" />
    <asp:TextBox ID="Coff" runat="server"></asp:TextBox></td>
    <td style="font-weight: 700">%</td><td>
    <asp:Button ID="CutOff" runat="server" 
        CssClass="btnstyle" Text="Update" onclick="CutOff_Click" /></td></tr>
<tr><td class="style1">Questions Per Type: </td><td>
    <asp:HiddenField ID="qptId" runat="server" />
    <asp:TextBox ID="Qpt" runat="server"></asp:TextBox></td><td>&nbsp;</td><td>
    <asp:Button ID="Qptbtn" runat="server" CssClass="btnstyle" Text="Update" onclick="Qptbtn_Click" 
         /></td></tr>
</table>
</fieldset>
</div>
</asp:Content>

