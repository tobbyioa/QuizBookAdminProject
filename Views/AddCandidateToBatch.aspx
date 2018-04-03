<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="AddCandidateToBatch.aspx.cs" Inherits="QuizBook.Views.AddCandidateToBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<script type="text/javascript">
    $(function () {
       

        $("#<%=B_StartDate.ClientID %>").datetimepicker({
            showOn: "button",
            // minDate: 0,
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            buttonImage: "../Content/themes/calendar.png",
            buttonImageOnly: true
        });

 $("#<%=Button1.ClientID %>").button(); $("#<%=Button2.ClientID %>").button();
        $("#<%=Button3.ClientID %>").button(); $("#<%=Button4.ClientID %>").button();
        $("#<%=Button5.ClientID %>").button();
        $("#<%=SendInvite.ClientID %>").button();
        $("#<%=msglabel.ClientID %>").fadeOut(10000);

        $('#<%=Duration.ClientID %>').keyup(function () {

            if (!(isNumeric($('#<%=Duration.ClientID %>').val()))) {

                alert("Only Numeric inputs are allowed");
                $('#<%=Duration.ClientID %>').val("");
            }

        });

        $("#<%=Button1.ClientID %>").click(function () {

            var contents = $("#<%=ActiveContentList.ClientID %>").val();

            if ($("#<%=ActiveCandidateList.ClientID %>").val() != null) {



                var candidates = $("#<%=ActiveCandidateList.ClientID %>").val();

                //  var candidates = candidateString.split(',');
                if (contents != null) {
                    // var contents = contentString.split(',');
                    for (var i = 0; i < candidates.length; i++) {
                        if ($.inArray(candidates[i], contents) > -1) { alert("Existing Entries will be ignored"); break; };
                    }
                }
                return true;
            } else {
                return false;
            }
        });

        $("#<%=Button2.ClientID %>").click(function () {
            if ($("#<%=ActiveContentList.ClientID %>").val() != null) {
                return true;
            } else {
                return false;
            }
        });
        $("#<%=CheckBox1.ClientID %>").click(function () {
            if ($("#<%=CheckBox1.ClientID %>").attr("checked") == "checked") {
                $("#batchdrop").hide();
                $(".multi").hide();
                $(".single").show();
                
            } else {
                $(".single").hide();
                $("#batchdrop").show();
                $(".multi").slideDown();
               
            }
        });

        //        $("#<%=Button3.ClientID %>").click(function () {
        //            if ($("#<%=ActiveCandidateList.ClientID %>").val() != null) {

        //                return true;
        //            } else {
        //                return false;
        //            }
        //        });

        //        $("#<%=Button4.ClientID %>").click(function () {
        //            if ($("#<%=ActiveContentList.ClientID %>").val() != null) {
        //                return true;
        //            } else {
        //                return false;
        //            }
        //        });
    });
    function Check() {
        $("#<%=Button1.ClientID %>").val();
    }
</script>
<style type="text/css">
.style1
{
    font-weight:bold;
}
 .style2
        {
            width:200px;
        }
 .style3
        {
            overflow-x:auto;
            overflow-y:auto;
            height:auto;
        }
        .btnstyle
        {
            font-size:8pt;
            font-weight:bold;
        }
        .single
        {
            display:none;
        }
        
</style>
<fieldset>
<legend style="font-weight: 700">Assign Candidate to Batch</legend>
<br />
<table>
    
<tr><td><asp:CheckBox ID="CheckBox1" runat="server" Text="Single Student Test " 
        style="font-weight: bold" /></td><td>&nbsp;&nbsp;</td><td id="batchdrop">
    <asp:Label ID="l1" runat="server" Text="Active Batches" style="font-weight: 700"></asp:Label><br />
    <asp:DropDownList ID="Batches" runat="server" DataTextField="Name" 
        DataValueField="Id" CssClass="style2"  AutoPostBack="True" 
        onselectedindexchanged="Batches_SelectedIndexChanged"></asp:DropDownList>
    </td></tr>
<tr class="multi"><td><asp:Label ID="Label2" runat="server" Text="Active Candidates" 
        style="font-weight: 700"></asp:Label><br /><asp:ListBox ID="ActiveCandidateList" runat="server" SelectionMode="Multiple" Width="200px" Height="300px" CssClass="style3" DataTextField="Name" DataValueField="ID"></asp:ListBox></td>
    <td style="text-align: center">
    <asp:Button ID="Button1" runat="server" Text="Add >>" CssClass="btnstyle" 
            onclick="Button1_Click" /><br /><br />
    <asp:Button ID="Button2" runat="server" Text="<<Remove" CssClass="btnstyle" 
            onclick="Button2_Click" />
    <br /><br />
    <br /><br />
    <asp:Button ID="Button3" runat="server" Text="Add All" CssClass="btnstyle" 
            onclick="Button3_Click" /><br /><br />
    <asp:Button ID="Button4" runat="server" Text="Remove All" CssClass="btnstyle" 
            onclick="Button4_Click" />
    </td><td>
    <asp:Label ID="Label1" runat="server" Text="Batch Content" style="font-weight: 700"></asp:Label><br />
    <asp:ListBox ID="ActiveContentList" runat="server" SelectionMode="Multiple" Width="200px" Height="300px" CssClass="style3" DataTextField="Name" DataValueField="Id"></asp:ListBox>
    </td></tr>
    <tr class="multi"><td colspan="2">
        <asp:Label ID="msglabel" runat="server" Text="" Width="100%" 
            style="font-weight: 700; color: #FF0000; text-align: center"></asp:Label>
        </td><td  style=" text-align:right;">
        <asp:Button ID="SendInvite" runat="server" Text="Send Invite(s)" 
            CssClass="btnstyle" onclick="Button6_Click" /></td></tr>
    <tr class="single"><td class="style1">Active Candidates
    </td><td><asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Name" 
        DataValueField="Id" CssClass="style2"></asp:DropDownList></td><td></td></tr>
             <tr class="single"><td class="style1 ">Start Date: </td><td><asp:TextBox ID="B_StartDate" runat="server"></asp:TextBox></td><td style="text-align: center"></td></tr>
<tr class="single"><td class="style1">Duration: </td><td><asp:TextBox ID="Duration" runat="server" Text="60" Enabled="false"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label5" runat="server"
        Text="(minutes)" CssClass="style2"></asp:Label></td><td style="text-align: center"></td></tr>
<tr style="display:none;"><td class="style1">Active?: </td><td><asp:CheckBox ID="Active" runat="server" /></td><td style="text-align: center"></td></tr>
<tr  class="single"><td class="style1"></td><td><asp:Button 
                ID="Button5" runat="server" Text="Save" CssClass="btnstyle" onclick="Button5_Click"  
             /></td><td style="text-align: center"></td></tr>
      
</table>
</fieldset>
        
</div>
</asp:Content>
