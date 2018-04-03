<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CandidateTest.Master" AutoEventWireup="true" CodeBehind="_CandidateTestPage.aspx.cs" Inherits="QuizBook.Views._CandidateTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.countdown.js" type="text/javascript"></script>
    <link href="../Content/fidelity-theme/jquery-ui-1.10.3.custom.css" type="text/css" rel="stylesheet" />
    <link href="../Content/jquery.countdown.css" rel="stylesheet"  type="text/css"/>--%>

    <style type="text/css">

    .top td
    {
         padding: 10px 5px 10px 5px;
    }
    .i_top td
    {
         padding: 10px 4px 10px 4px;
    }
    .auto-style1
    {
        width: 10%;
    }
        .lowerBorder {
            border-bottom:1px solid #FFFFFF;
        }
        .optPad {
            padding: 5px 5px 5px 5px;
        }


</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function FinalLogin_Click() {
            $("#<%=zel.ClientID %>").val("elapsed");
                <%= GetfinishedPostBack() %>;
        }

        function btnIs_Click() {
            $("#<%=zel.ClientID %>").val("buttonClk");
        }
        $(function () {

            var time = $.trim($("#minutes").val());
           // var candid = $.trim($("#candid").val());
           // alert(time);

            $("#countdown").countdown({
                image: '../Content/themes/digits.png',
                startTime: time,
                timerEnd: function () { FinalLogin_Click(); },
                format: 'hh:mm:ss'
            });
            //location.href = "_CandidateTestPage.aspx?z=" + $("#<%=zel.ClientID %>").val();
            function fncsave() {
                document.getElementById('<%= finish_btn.ClientID %>').click();
            }

            $("#<%=back_btn.ClientID %>").button(); $("#<%=next_btn.ClientID %>").button();
            $("#<%=finish_btn.ClientID %>").button();
            $(".btnstyle").button();
            


            $("#<%=finish_btn.ClientID %>").click(function () {

                var rem = $("#rem").html();
                //var dur = $("#dur").html();
                //alert(rem);
                if (rem != "0") {
                    var st = confirm("Are you sure you want finish this test?");
                    if (st) {
                        return true;
                    }
                    return false;
                }

            });

            //            $("#back.ClientID %>").click(function () {
            //                var timeRem = $("#timerem").val();
            //                //alert(timeRem);
            //                var candid = $("#candid").val();
            //                var batchid = $("#batchid").val();
            //                return UpdateNextTime(timeRem, candid, batchid);

            //            });

            //            $("#next.ClientID %>").click(function () {
            //                var timeRem = $("#timerem").val();
            //                //alert(timeRem);
            //                var candid = $("#candid").val();
            //                var batchid = $("#batchid").val();
            //                return UpdateNextTime(timeRem, candid, batchid);

            //            });

            //            $("#finish.ClientID %>").click(function () {
            //                var timeRem = $("#timerem").val();
            //                //alert(timeRem);
            //                var candid = $("#candid").val();
            //                var batchid = $("#batchid").val();
            //                return UpdateNextTime(timeRem, candid, batchid);

            //            });


            function ExpireSubmit() {



                //var ans1 = $("#Q1Answered%>").val();
                //alert(ans1+" h1");
                //var Q1 = $("#Q1Id%>").val();
                //alert(Q1+"h2");
                var ans2 = $("Q2Answered").val();
                var Q2 = $("#Q2Id").val();
                var ans3 = $("#Q3Answered").val();
                var Q3 = $("#Q3Id").val();
                var ans4 = $("#Q4Answered").val();
                var Q4 = $("#Q4Id").val();
                var ans5 = $("#Q5Answered").val();
                var Q5 = $("#Q5Id").val();
                var ans6 = $("#Q6Answered").va();
                var Q6 = $("#Q6Id").val();
                alert(Q6);

                var ans = new Array(ans1, ans2, ans3, ans4, ans5, ans6);
                var ques = new Array(Q1, Q2, Q3, Q4, Q5, Q6);



                var singleA1 = $("#single1").val();
                alert(singleA1);
                var singleA2 = $("#single2").val();
                var singleA3 = $("#single3").val();
                var singleA4 = $("#single4").val();
                var singleA5 = $("#single5").val();
                var singleA6 = $("#single6").val();
                
                var ansSingle = new Array(singleA1, singleA2, singleA3, singleA4, singleA5, singleA6);

                var MultiA1 = $("#Multi1").val();
                var MultiA2 = $("#Multi2").val();
                var MultiA3 = $("#Multi3").val();
                var MultiA4 = $("#Multi4").val();
                var MultiA5 = $("#Multi5").val();
                var MultiA6 = $("#Multi6").val();
                alert(MultiA6);
                var ansMulti = new Array(MultiA1, MultiA2, MultiA3, MultiA4, MultiA5, MultiA6);

                $.ajax({
                    type: "POST",
                    url: "CandidateTestPage.aspx/ExpireSubmit", //?zd=" + $(e).attr('id'),
                    data: "{ 'ansd': '" + ans.join() + "','ansdQ':'" + ques.join() + "','sAnss':'" + ansSingle.join() + "','mAnss':'" + ansMulti.join() + "','candId':'" + candid + "' }", //,'qid':'" + $(e).attr('name') + "'
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // Replace the div's content with the page method's return.
                        if (data == 'success') {
                            location.href = "CandidateTestResult.aspx?z=elapsed";
                        } else {
                            alert(data);
                            return false;

                        }
                    }
                });

            }


        });

        var inFormOrLink = false;
        //$('a').live('click', function () { inFormOrLink = true; });
        $('a').bind('click', function () { inFormOrLink = true; });
        $('form').bind('submit', function () { inFormOrLink = true; });
        

        $(window).bind("beforeunload", function () {
            
            $("#<%=zel.ClientID %>").val() == "elapsed" || $("#<%=zel.ClientID %>").val() == "buttonClk" ? inFormOrLink = true : inFormOrLink = false;
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
       
        //jQuery(window).bind('beforeunload', function (e) {
        //    //var message = "Why are you leaving?";
        //    $.ajax({
        //        type: "POST",
        //        url: "_CandidateTestPage.aspx/logout", //?zd=" + $(e).attr('id'),
        //        // data: "{ 'id': '" + s + "','cid':'" + x + "','bid':'" + y + "' }", //,'qid':'" + $(e).attr('name') + "'
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            // Replace the div's content with the page method's return.
        //            if (data == 'success') {

        //                return true;
        //            } else {
        //                alert(data.d);
        //                return false;

        //            }
        //        }
        //    });

        //    //   e.returnValue = message;
        //    // return message;
        //});

        function UpdateNextTime(s, x, y) {
            //alert($(e).attr('name'));
           // var st = confirm("Are you sure you want perform this action?");

//            if (st) {
                $.ajax({
                    type: "POST",
                    url: "CandidateTestPage.aspx/UpdateNextTime", //?zd=" + $(e).attr('id'),
                    data: "{ 'id': '" + s + "','cid':'" + x + "','bid':'" + y + "' }", //,'qid':'" + $(e).attr('name') + "'
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // Replace the div's content with the page method's return.
                        if (data = 'success') {
                            return true;
                        } else {
                            alert(data);
                            return false;

                        }
                    }
                });

            //}
        }
</script>

<div style="border: 1px solid #FFFFFF; background-color:#F5F5F5; width: 90%;  margin:0 auto; overflow:auto;  font-size:10pt; padding:20px 20px 20px 20px;" class="inforounded">

<%--<asp:Panel ID="GroupPanel" runat="server"  style=" width:100%; height:auto; margin:0 auto; font-size:12pt;">
<span id="grpSpan" runat="server" style=" font-weight:bold;">Grouping Span</span>
</asp:Panel>--%>
<%-- <asp:Panel ID="PreamblePanel" runat="server" CssClass="preambleStyle" style=" width:80%; height:auto; margin:0 auto;">
 <span id="ppSpan" runat="server" class="preambleStyle" >Preamble Span</span>
 </asp:Panel>--%>
<%-- <br />
 <br />--%>
<%--<asp:Panel ID="Panel1" runat="server" CssClass="questStyle">
<table style=" width:90%; height:100%; margin:0 auto;">
<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label1" runat="server" Text="Label" style="font-weight: 700"></asp:Label></td>
<td style="vertical-align:top;">
    <asp:Panel ID="Q1" runat="server">
    <span id="q1Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A1" runat="server">
        <span id="a1span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
    <input id="Q1Id" name="Q1Id" type="hidden"  runat="server"/>
    <input id="Q1Answered" name="Q1Answered" type="hidden"  runat="server"/>
    </td>
</tr>
</table>
</asp:Panel>--%>
    
<%--<br />--%>
<%--<asp:Panel ID="Panel2" runat="server" CssClass="questStyle">
<table style=" width:90%; height:100%; margin:0 auto;">
<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label2" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
</td>
<td style="vertical-align:top;">
<asp:Panel ID="Q2" runat="server">
<span id="q2Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A2" runat="server">
        <span id="a2span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
        <input id="Q2Id" name="Q2Id" type="hidden"  runat="server"/>
        <input id="Q2Answered" name="Q2Answered" type="hidden"  runat="server"/>
</td>
</tr>
</table>
</asp:Panel>--%>
<%--<br />--%>
<%--<asp:Panel ID="Panel3" runat="server" CssClass="questStyle">
<table style=" width:90%; height:100%; margin:0 auto;">
<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label3" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
</td>
<td style="vertical-align:top;">
<asp:Panel ID="Q3" runat="server">
<span id="q3Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A3" runat="server">
         <span id="a3span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
         <input id="Q3Id" name="Q3Id" type="hidden"  runat="server"/>
          <input id="Q3Answered" name="Q3Answered" type="hidden"  runat="server"/>
</td>
</tr>
</table>
</asp:Panel>--%>
<%--<br />--%>
<%--<asp:Panel ID="Panel4" runat="server" CssClass="questStyle">
<table style=" width:90%; height:100%; margin:0 auto;">
<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label4" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
</td>
<td style="vertical-align:top;">
<asp:Panel ID="Q4" runat="server">
<span id="q4Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A4" runat="server">
        <span id="a4span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
        <input id="Q4Id" name="Q4Id" type="hidden"  runat="server"/>
         <input id="Q4Answered" name="Q4Answered" type="hidden"  runat="server"/>
</td>
</tr>

    
</table>
    
</asp:Panel>--%>
<%--<br />--%>
<%--<asp:Panel ID="Panel5" runat="server" CssClass="questStyle">
<table style=" width:90%; height:100%; margin:0 auto;">
<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label5" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
</td>
<td style="vertical-align:top;">
<asp:Panel ID="Q5" runat="server">
<span id="q5Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A5" runat="server">
         <span id="a5span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
         <input id="Q5Id" name="Q5Id" type="hidden"  runat="server"/>
          <input id="Q5Answered" name="Q5Answered" type="hidden"  runat="server"/>
</td>
</tr>
</table>
</asp:Panel>--%>
<%--<br />--%>

<asp:Panel ID="Panel6" runat="server" CssClass="questStyle" Width="90%">
<%--<table style=" width:90%; height:auto; margin:0 auto;">--%>
<%--<tr>
<td style="width:10%; text-align:center; vertical-align:top;">
<asp:Label ID="Label6" runat="server" Text="Label" style="font-weight: 700"></asp:Label>
</td>
<td style="vertical-align:top;">
<asp:Panel ID="Q6" runat="server">
<span id="q6Span" runat="server" class="questionStyle"></span>
    </asp:Panel>
    <br />
        <asp:Panel ID="A6" runat="server">
         <span id="a6span" runat="server" class="AnswerStyle"></span>
        </asp:Panel>
         <input id="Q6Id" name="65Id" type="hidden"  runat="server"/>
          <input id="Q6Answered" name="Q6Answered" type="hidden"  runat="server"/>
</td>
</tr>--%>
<%--<tr>--%>
<%--<td style="text-align:center; vertical-align:top;" class="auto-style1">

</td>--%>

<%--<td>--%>
<asp:Panel ID="Panel1" runat="server">



</asp:Panel>
    <br />
    <div  style=" width:100%;text-align: right">
<%--<asp:Button ID="back_btn" runat="server" 
        Text="<< Back" CssClass="btnstyle" OnClientClick ="btnIs_Click();" onclick="back_Click" />--%>
        <asp:LinkButton ID="back_btn" runat="server" class="btn btn-default" OnClientClick ="btnIs_Click();" onclick="back_Click"><span class="glyphicon glyphicon-step-backward"></span>  Back</asp:LinkButton>
       
        &nbsp;&nbsp;
        
       <%--   <asp:Button 
      ID="next_btn" runat="server" Text="Next >>" CssClass="btnstyle" OnClientClick ="btnIs_Click();" 
        onclick="next_Click" />--%>

        <asp:LinkButton ID="next_btn" runat="server" class="btn btn-default" OnClientClick ="btnIs_Click();" onclick="next_Click"><span class="glyphicon glyphicon-step-forward" ></span>  Next</asp:LinkButton>

   &nbsp;&nbsp; 
        
        <%--<asp:Button ID="finish_btn" runat="server" Text="Finish"  OnClientClick ="btnIs_Click();"
         CssClass="btnstyle" onclick="finish_Click" />--%>

        <asp:LinkButton ID="finish_btn" runat="server" class="btn btn-default" OnClientClick ="btnIs_Click();" onclick="finish_Click"><span class="glyphicon glyphicon glyphicon-stop" ></span>  Finish</asp:LinkButton>
    </div>
<%--</td>--%>
<%--</tr>
</table>--%>
</asp:Panel>
<%--<table style=" width:100%; height:100%;">
<tr><td></td><td style="text-align: right">
    </td></tr>
</table>--%>
<asp:HiddenField ID="prevPage" runat="server" /><asp:HiddenField ID="currPage" runat="server" /><asp:HiddenField ID="nextPage" runat="server"  />
<asp:HiddenField ID="zel" runat="server" />
</div>
</asp:Content>
