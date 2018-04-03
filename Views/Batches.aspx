<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Batches.aspx.cs" Inherits="QuizBook.Views.Batches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
           // $("#<SearchQuest.ClientID %>").button();

            //$(".datetimepick").first().datetimepicker({
            //    showOn: "button",
            //    minDate: 0,
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: 'dd/mm/yy',
            //    buttonImage: "../Content/themes/calendar.png",
            //    buttonImageOnly: true,

            //    onClose: function (selectedDate) {
            //        $(".datetimepick2").datetimepicker("option", "minDate", selectedDate);
            //    }

            //});

            //$(".datetimepick2").first().datetimepicker({
            //    showOn: "button",
            //    minDate: 0,
            //    changeMonth: true,
            //    changeYear: true,
            //    dateFormat: 'dd/mm/yy',
            //    buttonImage: "../Content/themes/calendar.png",
            //    buttonImageOnly: true,
            //    onClose: function (selectedDate) {
            //        $(".datetimepick").datetimepicker("option", "maxDate", selectedDate);
            //    }
            //});


           // $("#Save.ClientID %>").button(); //$("#Clear.ClientID %>").button();
           // $('.btnstyle2').button();


           // $('#GroupContentList.ClientID %>').listbox({
           //     'searchbar': true
           // });
           // $('#<SelectedGrp.ClientID %>').listbox({
            //    'searchbar': true
           // });

           // $('#B_Desc.ClientID %>').tinymce({
                // Location of TinyMCE script, optional, already loaded in page.
                // General options
               // theme: "advanced",
               // plugins: "pagebreak,style,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,,searchreplace,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",
                // Theme options
                //theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,|,preview,help,code,justifyleft,justifycenter,justifyright,justifyfull",
                //theme_advanced_buttons2: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",

              //  theme_advanced_toolbar_location: "top",
               // theme_advanced_toolbar_align: "left",
               // theme_advanced_statusbar_location: "bottom"
           // });
            $('#<%=Duration.ClientID %>').keyup(function () {

                if (!(isNumeric($('#<%=Duration.ClientID %>').val()))) {

                    alert("Only Numeric inputs are allowed");
                    $('#<%=Duration.ClientID %>').val("");
                }

            });
            $(".checkAlert").click(function () { if (!confirm("Click OK to proceed on this action.")) return false; });
        });
</script>

<style type="text/css">
.style1
{
    font-weight:bold;
}
.style2
{
    font-style:italic;
    vertical-align:middle;

}
 .style3
        {
            width: 100%;
            overflow:auto;
            height:auto;
        }
        .stylex
        {
            width: 100%;
            overflow:auto;
        }
    .auto-style1
    {
        width: 211px;
    }
    .auto-style2
    {
        width: 3px;
    }

</style>
<%--<div style=" width: 100%;  height:auto; margin:0 auto; font-size:10pt;" >--%>
<fieldset>
<legend style="font-weight: 700">Manage Test Batches</legend>
    <asp:Label ID="AlertLbl" runat="server" style="font-weight: bold;color:firebrick; font-size: small;" Text=""></asp:Label>
<br />
<div class="row">

    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                  <asp:HiddenField ID="B_ID" runat="server" />
                  <asp:TextBox ID="B_Name" runat="server" placeholder="Name" CssClass="form-control"></asp:TextBox>
                 </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <asp:TextBox ID="B_Desc" runat="server" Rows="5" TextMode="MultiLine" placeholder="Description" CssClass="form-control"></asp:TextBox>
                 </div>
        </div>
         <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <%--<b>Question Group</b><br />--%>
                 <asp:DropDownList ID="Qgroup" AutoPostBack="true" DataTextField="Name" DataValueField="Id" CssClass="form-control" runat="server"  OnSelectedIndexChanged="bgrp_SelectedIndexChanged"></asp:DropDownList>
                 </div>
        </div>

          <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <div class='input-group date datetimepicker' id='datetimepickerx1'>
                 <asp:TextBox ID="B_StartDate" runat="server" ClientIDMode="Static"  placeholder="Start Date" CssClass="form-control"></asp:TextBox>
                     <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                 </div>
        </div>

         <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <div class='input-group date datetimepicker' id='datetimepickerx2'>
                 <asp:TextBox ID="B_EndDate" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="End Date"></asp:TextBox>
                 <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                 </div>
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <asp:TextBox ID="Duration" runat="server" CssClass="form-control" Text="60" placeholder="Duration" ></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server"
        Text="(minutes)" CssClass="style2"></asp:Label>
                 </div>
        </div>

         <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <asp:TextBox ID="CutOff" runat="server" CssClass="form-control" placeholder="Batch Cut-off" ></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server"
        Text="%" CssClass="style2"></asp:Label>
                 </div>
        </div>

         <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <b>Active?</b>
                 <asp:CheckBox ID="Active" runat="server" />
                 </div>
        </div>

         <div class="col-xs-12 col-sm-12 col-md-12">
             <div class="form-group">
                 <asp:Label ID="alert" runat="server" style="font-weight: 700; font-style: italic; font-size: medium; color: #CC0000; background-color: #FFFFFF"></asp:Label>
                 </div>
        </div>

        </div>

    <div class="col-xs-8 col-sm-8 col-md-8">
           <table class="table">
        <tr><td  colspan="3"><b>Batch Group</b><br />
            <asp:DropDownList ID="bgrp" AutoPostBack="true" DataTextField="Name" DataValueField="Id" Width="930px" runat="server" CssClass="form-control" OnSelectedIndexChanged="bgrp_SelectedIndexChanged">
        </asp:DropDownList>
            <%--</td><td class="auto-style2">&nbsp;</td><td>&nbsp;--%></td></tr>
        <tr><td><b>Group List</b><br />
            <asp:ListBox ID="GroupContentList" runat="server" SelectionMode="Multiple" Width="400px" Height="300px" CssClass="form-control" DataTextField="Name" DataValueField="ID"></asp:ListBox></td>
            <td style="vertical-align:middle;" >
                <asp:LinkButton ID="Button1" runat="server" class="btn btn-default btn-sm" OnClick="Button1_Click" Width="100px" >Add <span class="glyphicon glyphicon-forward" aria-hidden="true"></span></asp:LinkButton>
           <%-- <asp:Button ID="Button1" runat="server" CssClass="btnstyle2" Text="Add >>" Width="100px" OnClick="Button1_Click" />--%>

            <br /><br />
                <asp:LinkButton ID="Button2" runat="server" class="btn btn-default btn-sm" OnClick="Button2_Click" Width="100px"><span class="glyphicon glyphicon-backward" aria-hidden="true"></span> Remove</asp:LinkButton>
            <%--<asp:Button ID="Button2" runat="server" CssClass="btnstyle2" Text="<< Remove" Width="100px" OnClick="Button2_Click" /> --%>

                                                                                                                                                                                                        </td><td>
                <b>Selected</b><br />
            <asp:ListBox ID="SelectedGrp" runat="server" SelectionMode="Multiple" Width="400px" Height="300px" CssClass="form-control" DataTextField="Name" DataValueField="ID"></asp:ListBox>
 </td></tr>
         <tr><td class="auto-style2">
            &nbsp;
             <%--<asp:TextBox ID="al2" runat="server"></asp:TextBox>--%>
            </td><td class="auto-style2">&nbsp;</td><td style="text-align: right">
                <asp:LinkButton ID="Save" runat="server" class="btn btn-default btn-sm"  onclick="Save_Click"><span class="glyphicon glyphicon-save" aria-hidden="true"></span> Save</asp:LinkButton>
                <%--<asp:Button ID="Save" runat="server"  CssClass="btnstyle" Text="Save"  onclick="Save_Click" />--%>

                <%--&nbsp;&nbsp;<asp:Button
        ID="Clear"  runat="server" Text="Clear" CssClass="btnstyle" onclick="Clear_Click" />--%></td></tr>
        </table>
        </div>

   <%-- <table style="width:100%;"><tr>
        <td style="width:40%;">--%>
<%--<table style="width:100%;">--%>
<%--<tr><td class="style1" width="30%">Name</td><td class="auto-style1">
    <asp:HiddenField ID="HiddenField1" runat="server" />
                  <asp:TextBox ID="TextBox1" runat="server" placeholder="Name"></asp:TextBox>
   </td></tr>--%>
<%--<tr><td class="style1" width="30%">Description </td><td class="auto-style1"><asp:TextBox ID="B_Desc" runat="server" Rows="5" TextMode="MultiLine" ></asp:TextBox></td></tr>--%>
<%--<tr><td width="30%" style="font-weight: 700" >Question Group</td><td class="auto-style1"><asp:DropDownList ID="Qgroup" AutoPostBack="true" DataTextField="Name" DataValueField="Id" runat="server" CssClass="inputCSS" OnSelectedIndexChanged="bgrp_SelectedIndexChanged">
        </asp:DropDownList></td></tr>--%>
<%--<tr><td class="style1" width="30%">Start Date </td><td class="auto-style1"><asp:TextBox ID="B_StartDate" runat="server" ClientIDMode="Static" CssClass="datetimepick"></asp:TextBox></td></tr>--%>
<%--<tr><td class="style1" width="30%">End Date</td><td class="auto-style1"><asp:TextBox ID="B_EndDate" runat="server" ClientIDMode="Static" CssClass="datetimepick2"></asp:TextBox></td></tr>--%>
<%--<tr><td class="style1" width="30%">Duration </td><td class="auto-style1"><asp:TextBox ID="Duration" runat="server" Text="60" ></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server"
        Text="(minutes)" CssClass="style2"></asp:Label></td></tr>--%>
<%--<tr style="display:none;"><td class="style1" width="30%">Active?</td><td class="auto-style1"><asp:CheckBox ID="Active" runat="server" /></td></tr>--%>
<%--<tr><td width="30%" colspan="2" >&nbsp;<asp:Label ID="alert" runat="server" style="font-weight: 700; font-style: italic; font-size: medium; color: #CC0000; background-color: #FFFFFF"></asp:Label></td></tr>--%>
<%--</table>--%>

 <%-- </td>


<td style="width:50%;">



</td>

           </tr></table>--%>

<br />
<hr style=" width:100%;"/>
<br />

    <div style="width:100%;"><div style=" float:left; width:40%;"> <asp:Label ID="TotalRecCount" runat="server" Text="Label" CssClass="style1"></asp:Label></div><div style="float:right; width:40%; text-align:right;">
            <asp:TextBox ID="searchText" runat="server" style="background-color:Silver;"></asp:TextBox>

        <asp:LinkButton ID="SearchQuest" runat="server" class="btn btn-default btn-sm" onclick="SearchQuest_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>Search</asp:LinkButton>
       <%-- <asp:Button ID="SearchQuest" runat="server" Text="Search" CssClass="btnstyle2"
                style=" background-color:Lime;" onclick="SearchQuest_Click" />--%>
</div></div>
    <br />
   <asp:GridView ID="BatchList" runat="server" Width="100%" AutoGenerateColumns="False"
          AllowPaging="True"

         EmptyDataText="No Test Batches configured Yet" ShowHeaderWhenEmpty="True"
         PageSize="10" onpageindexchanging="BatchList_PageIndexChanging"
          >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <%--<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />--%>
                            <asp:TemplateField HeaderText="Description" ControlStyle-Width="300px" ControlStyle-Height="55px" SortExpression="Description"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="style3"><%#Eval("Description")%>
                            </asp:Panel>
                        </ItemTemplate>

<ControlStyle Height="55px" Width="300px"></ControlStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BatchType" HeaderText="Batch Type" SortExpression="BatchType" />
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" />
                            <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" />
                             <asp:BoundField DataField="Duration" HeaderText="Duration (min(s))" SortExpression="Duration" />
                             <%--<asp:BoundField DataField="NoOfQuestions" HeaderText="No Of Questions" SortExpression="NoOfQuestions" />--%>
                            <asp:BoundField DataField="IsActive" HeaderText="Active" SortExpression="IsActive" />
                            <asp:BoundField DataField="SessionOn" HeaderText="SessionOn" SortExpression="SessionOn" />
                            <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                            <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditC" runat="server" onclick="lnkeditC_Click" >Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>

    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditB" runat="server" onclick="lnkeditB_Click" CssClass="checkAlert" ><%#Eval("D")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDB" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditResults" runat="server"  CssClass="checkAlert"
                                 onclick="lnkeditResults_Click" ><%#Eval("ViewResults")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDResults" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                            </Columns>
                             <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <PagerSettings PageButtonCount="5" />
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                            </div>
</fieldset>
<%--</div>--%>
</asp:Content>
