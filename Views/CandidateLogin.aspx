<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate.Master" AutoEventWireup="true" CodeBehind="CandidateLogin.aspx.cs" Inherits="QuizBook.Views.CandidateLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    $(function () {
        $("#<%=C_TestStart.ClientID %>").button();
      //  $("#<%=Info.ClientID %>").fadeOut(10000);
    });
</script>
<style type="text/css">
    .alert
    {
        color:Red;
        font-weight:bold;
    }
</style>

<div style="width: 100%; height:600px; margin:0 auto; font-size:10pt;background-image:url(../Images/E-Recruitment.png);
        background-repeat:no-repeat;
        background-position:bottom center; ">
        <table style="width:50%;margin-top:5%;margin-left:22%;clear:both">
        <tr><td><span><strong><em>Please read the instructions below before proceeding with the test:
            </em></strong>
        <ul style="font-size:10pt;">
<li><strong><em>Login with the Candidate Code given to you.</em></strong></li> 
<li><strong><em>This test contains 60 questions. Answer all questions. </em>
    </strong> </li>
<li><strong><em>Time Allowed for this test is 60 minutes. </em></strong> </li>
<li><strong><em>Read the questions carefully before answering. </em></strong> </li>
<li><strong><em>Select the correct answer from the multiple options available by clicking on the radio button. 
    </em></strong> </li>
<li><strong><em>Proceed to the next question without clicking any option for a question you wish to answer later. 
    </em></strong> </li>
<li><strong><em>Once you have finished with a section, click 'Next' to proceed to the next section. 
    </em></strong> </li>
<li><strong><em>Do not spend too much time on any question since you must try to get as many correct answers as possible. 
    </em></strong> </li>
<li><strong><em>Note that the form will auto-submit once the duration of the test elapses. 
    </em></strong> </li>
</ul>
</span></td></tr>
        <tr><td > <div style="font-weight:bold;font-size:12pt;text-align:center;">Please Enter Your Candidate Code</div><br />
        <div style=" font-style:italic; font-size:10pt; text-align:center;">(Click Start to start test.)</div></td></tr>
        <tr><td style="text-align: center"><asp:TextBox ID="Code" runat="server"></asp:TextBox></td></tr>
        <tr><td style="text-align: center"><asp:Button ID="C_TestStart" runat="server" Text="Start" CssClass="btnstyle" onclick="C_TestStart_Click" /></td></tr>
            <tr><td style="text-align: center">
                <asp:Label ID="Info" runat="server" Text="" Width="100%" CssClass="alert"></asp:Label></td></tr>
        </table>
    
</div>
</asp:Content>
