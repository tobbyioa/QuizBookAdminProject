<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate.Master" AutoEventWireup="true" CodeBehind="CandidateView.aspx.cs" Inherits="QuizBook.Views.CandidateView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {

        $("#<%=Button1.ClientID %>").button();

    });
</script>
<style type="text/css">
       
        td
{ 
        padding: 7px 5px;
            font-weight:bold;
            text-align: left;
            font-size: medium;
        }

  .nopadding
{
   
padding-top:0px;
padding-bottom:0px;
padding-right:0px;
padding-left:0px;
}
 .manswer
    {
        vertical-align:top;
        text-align:left;
         width:90%;
         height:100px;
         overflow-x:hidden;
         overflow-y:auto;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 90%; height:auto; margin:0 auto; font-size:10pt;">
 <table style="width: 100%;">
 <tr><td style=" text-align:right;">
     <asp:LinkButton ID="BackToCandidates" runat="server" style="font-weight: 700" 
         onclick="BackToCandidates_Click">Back</asp:LinkButton>
     </td></tr>
 </table>
 <table   style="border: thick solid #000000; height: auto; width: 100%; margin:0 auto;">
 <tr><td style="font-weight: bold;background-color:#00844F;" colspan="4"  >
     <asp:HiddenField ID="candId" runat="server" />
     </td></tr>
 <tr><td style="font-weight: bold" width="15%">Code:</td><td width="35%">
     <asp:Label ID="Label1" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" colspan="2" rowspan="5">
         <asp:Panel ID="Panel2" runat="server" Height="150px" style="">
             <asp:Image ID="Image1" runat="server" Width="128px" Height="128px" />

         </asp:Panel>
     </td></tr>
 <tr><td style="font-weight: bold" width="15%">Last Name:</td><td width="35%">
     <asp:Label ID="Label2" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     </tr>
 <tr><td style="font-weight: bold" width="15%">Other Names:</td><td width="35%">
     <asp:Label ID="Label3" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     </tr>
 <tr><td width="15%">Sex:</td><td width="35%">
     <asp:Label ID="Label4" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     </tr>
 <tr><td style="font-weight: bold" width="15%">Date Of Birth:</td><td width="35%">
     <asp:Label ID="Label5" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     </tr>
 <tr><td style="font-weight: bold" width="15%">Degree:</td><td width="35%">
     <asp:Label ID="Label6" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" width="15%">Test Score:</td><td width="35%">
     <asp:Label ID="Label7" runat="server" Text="-" Width="100%"></asp:Label>
     </td></tr>
 <tr><td style="font-weight: bold" width="15%">Class of Degree:</td><td width="35%">
     <asp:Label ID="Label10" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" width="15%">Psychometric Test View:</td>
     <td width="35%">
         <asp:Label ID="Label8" runat="server" Text="-" Width="100%"></asp:Label>
     </td></tr>
 <tr><td style="font-weight: bold" width="15%">Course:</td><td width="35%">
     <asp:Label ID="Label11" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" width="15%">Essay:</td>
     <td width="35%">
         <asp:Label ID="Label9" runat="server" Text="-" Width="100%"></asp:Label>
     </td></tr>
     <tr><td style="font-weight: bold" width="15%">Referred By:</td><td width="35%">
     <asp:Label ID="Label12" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" width="15%">Email:</td>
     <td width="35%">
         <asp:Label ID="Label13" runat="server" Text="-" Width="100%"></asp:Label>
     </td></tr>
     <tr><td style="font-weight: bold" width="15%">Approval Status:</td><td width="35%">
     <asp:Label ID="Label14" runat="server" Text="-" Width="100%"></asp:Label>
     </td>
     <td style="font-weight: bold" width="15%">&nbsp;</td>
     <td width="35%">
         <asp:Label ID="Label15" runat="server" Text="" Width="100%"></asp:Label>
     </td></tr>
 <tr><td style="font-weight: bold" width="15%">Comments:</td><td colspan="3">
     <asp:TextBox ID="Comment" runat="server" TextMode="MultiLine" Height="100px" CssClass="manswer"></asp:TextBox><br />
     <br />
     <asp:Button ID="Button1" runat="server" Text="Update Comments" class="btnstyle" 
         onclick="Button1_Click" />
     </td>
     </tr>
 <tr><td style="font-weight: bold; background-color:#2E3E3F;" colspan="4" ></td></tr>
 </table>
 </div>
</asp:Content>
