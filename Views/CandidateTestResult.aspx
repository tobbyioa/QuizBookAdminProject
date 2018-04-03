<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Candidate.Master" AutoEventWireup="true" CodeBehind="CandidateTestResult.aspx.cs" Inherits="QuizBook.Views.CandidateTestResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
        $("#<%=ProceedToEssay.ClientID %>").button();
     
        
    });

        var inFormOrLink = false;
        $('a').live('click', function () { inFormOrLink = true; });
        $('form').bind('submit', function () { inFormOrLink = true; });


        $(window).bind("beforeunload", function () {
           
            if (!inFormOrLink) {

                $.ajax({
                    type: "POST",
                    url: "_CandidateTestPage.aspx/logout", //?zd=" + $(e).attr('id'),
                    data: "{ 'id': '" + inFormOrLink + "' }", //,'qid':'" + $(e).attr('name') + "'
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // Replace the div's content with the page method's return.
                        //if (data == 'success') {

                        //    return true;
                        //} else {
                        //    alert(data.d);
                        //    return false;

                        //}
                    }
                })
            }
        });

    </script>
<style type="text/css">
.align
{
    text-align:center;
}

.red
{
    color:Red;
}
.green
{
    color:Green;
}
    #Div2
    {
        text-align: center;
        font-weight: 700;
        color: #CC3300;
        font-style: italic;
    }
    #AlertDiv
    {
        font-weight: 700;
        text-align: center;
        color: #CC3300;
    }
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
          .alert2
            {
                background-color:#F2F2F2 ;
                border: 1px solid #B0B0B0;
                margin: 10px 10px;
                overflow: auto;
                padding: 20px;
                word-wrap: break-word;
                -webkit-border-radius: 9px;
                -moz-border-radius: 9px;
                border-radius: 9px;
            }
    </style>
<div style="width: 80%; height:auto; margin:0 auto; font-size:10pt;">
<div id="TestResultDiv" runat="server">
<table   style=" height: auto; width: 80%; margin:0 auto;">
<tr><td colspan="2" style="font-weight: bold; text-align: center;" >Test Results</td></tr>
<tr><td style=" text-align:center;">
    <asp:Image ID="Image1" runat="server" Width="128px" Height="128px" Visible="true" ImageUrl="~/Content/themes/user_1.png" />
    </td></tr>
    <tr><td><div id="Div1" style="font-size:12pt; font-weight:bold; text-align:center;"><asp:Label ID="CandName" runat="server" Text=""></asp:Label></div></td></tr>
    <tr><td colspan="2" style="font-weight: bold; text-align: center; vertical-align:middle;">
        <div>
    <asp:Label ID="resultLblp" runat="server" Width="100%" Text="" CssClass="alert2" Visible="false"></asp:Label>
        </div>
        <%--<asp:Label ID="resultLblf" runat="server" Width="100%" Text="" CssClass="red" Visible="false"></asp:Label>&nbsp;--%></td></tr>
        <tr><td colspan="2" style="font-weight: bold; text-align: center;">
            <asp:Button ID="ProceedToEssay" runat="server" Text="Back Home" 
                CssClass="btnstyle" Visible="false" /></td></tr>
</table>
</div>
</div>
    
</asp:Content>
