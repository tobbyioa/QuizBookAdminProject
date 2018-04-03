<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="TestReport.aspx.cs" Inherits="QuizBook.Views.TestReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1
        {
            height: 31px;
        }
        .auto-style2
        {
            height: 31px;
            text-align: right;
        }
        .auto-style3
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    $(function () {

   <%--     var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!

        var yyyy = today.getFullYear();
        if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = dd + '/' + mm + '/' + yyyy;

        $("#<%=from.ClientID %>").val(today);
        $("#<%=to.ClientID %>").val(today)--%>


       <%-- $("#<%=submit.ClientID %>").button();
        $("#<%=from.ClientID %>").datepicker({
            showOn: "button",
            // minDate: 0,
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',

            buttonImage: "../Content/themes/calendar.png",
            buttonImageOnly: true
        });
        $("#<%=to.ClientID %>").datepicker({
            showOn: "button",
            // minDate: 0,
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',

            buttonImage: "../Content/themes/calendar.png",
            buttonImageOnly: true
        });--%>

        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' }//,
            //'.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
       // $('.chosen-container').attr('style', 'width:100%');

    });
</script>
   <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Test Batch Report</legend>
<hr style="width:100%;" />
<table style="width:100%;">
    <%--<tr><td style="font-weight: bold;width:20%;">Group&nbsp;</td><td style="font-weight: bold;"><asp:DropDownList ID="bgrp" AutoPostBack="true" DataTextField="Name" DataValueField="Id" runat="server" CssClass="inputCSS" OnSelectedIndexChanged="bgrp_SelectedIndexChanged" ></asp:DropDownList></td></tr>--%>
   <%--<tr><td style="font-weight: bold;" class="auto-style3">Group List&nbsp;</td><td style="font-weight: bold;"><asp:DropDownList ID="GroupContentList" DataTextField="Name" DataValueField="Id" runat="server" CssClass="inputCSS" ></asp:DropDownList></td></tr>--%>
    <tr><td style="font-weight: bold;width:20%; padding:5px 5px 5px 5px;">&nbsp;</td><td style="font-weight: bold;;width:80%; padding:5px 5px 5px 5px;"><asp:DropDownList  data-placeholder="Choose a Test Batch..." ID="GroupContentList" DataTextField="Name" DataValueField="Id" runat="server"  CssClass="chosen-select form-control" Width="300px" ></asp:DropDownList></td></tr>
     <tr><td style="font-weight: bold;width:20%; padding:5px 5px 5px 5px;" >&nbsp;</td><td style="font-weight: bold;;width:80%; padding:5px 5px 5px 5px;">
         <div class='input-group date datetimepicker' id='datetimepickerx1' style="width:300px;">
         <asp:TextBox ID="from" runat="server" ClientIDMode="Static" CssClass="form-control"  placeholder="Date From"></asp:TextBox>
          <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
         <%--<asp:TextBox ID="from" runat="server" ></asp:TextBox>--%></td></tr>
<tr><td style="font-weight: bold;width:20%; padding:5px 5px 5px 5px;">&nbsp;</td><td style="font-weight: bold;width:80%; padding:5px 5px 5px 5px;">
    <div class='input-group date datetimepicker' id='datetimepickerx2'style="width:300px;" >
    <asp:TextBox ID="to" runat="server" ClientIDMode="Static"  placeholder="Date To"  CssClass="form-control"></asp:TextBox>
     <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
    <%--<asp:TextBox ID="to" runat="server" ></asp:TextBox>--%>
    </td></tr>
<tr><td  style="font-weight: bold; text-align: right;" >&nbsp;</td>
    <td  style="font-weight: bold; text-align: left; padding:5px 5px 5px 5px;" >
      <%--  <asp:Button ID="submit" runat="server"
        Text="Report" onclick="submit_Click" CssClass="btnstyle"/>--%>

        <asp:LinkButton ID="submit" runat="server" class="btn btn-default btn-sm" onclick="submit_Click" Width="100px"><span class="glyphicon glyphicon-list" aria-hidden="true"></span> Get Report</asp:LinkButton>
    </td>
    </tr>
</table>
<hr style="width:100%;" />
</fieldset>
</div>
</asp:Content>
