<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="QuestionOptions.aspx.cs" Inherits="QuizBook.Views.QuestionOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 213px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(function () {
           // alert($("#<%=QuestID.ClientID %>").val());
            $("#accordion").accordion({ active: 1, event: "mouseover" });
            $("#<%=Button1.ClientID %>").button();
            $("#<%=Button2.ClientID %>").button();

            loadTable(true, $("#<%=QuestID.ClientID %>").val());
        });

        tinymce.init({
            selector: '.mce',
            height: 200,
            plugins: [
              'advlist autolink lists link image charmap print preview anchor',
              'searchreplace visualblocks code fullscreen',
              'insertdatetime media table contextmenu paste code'
            ],
            toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        function loadTable(destroyvalue,Qval) {
            $('#QuestionOptionList').dataTable({
                "bJQueryUI": true,
                "sPaginationType": "full_numbers",
                "bServerSide": true,
                "sAjaxSource": 'CandidateList.ashx',
                "bDestroy": destroyvalue,
                "sServerMethod": "POST",
                "bDeferRender": true,
                //"fnServerData": fnDataTablesPipeline,
                "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
                    aoData.push({ "name": "action", "value": "QuestOptList" });
                    aoData.push({ "name": "z", "value": Qval });
                    oSettings.jqXHR = $.ajax({
                        "dataType": 'json',
                        "type": "POST",
                        "url": sSource,
                        "data": aoData,
                        "success": fnDataTablesPipeline(sSource, aoData, fnCallback)
                    });
                }
            });
        }
    </script>
    <div style="width: 95%; height: auto; margin: 0 auto; font-size: 10pt;">
        <fieldset>
            <legend>Question Options</legend>
            <div style="text-align: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" class="btn btn-default"><span class="glyphicon glyphicon-backward" aria-hidden="true"></span>&nbsp;&nbsp;Back</asp:LinkButton></div>
            <hr style="width: 100%;" />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                 Question :
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:HiddenField ID="QuestID" runat="server" />
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
            <br />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Question Type :
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
            <br />
             <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Option Type:
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                  <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
           <%-- <table>--%>
               <%-- <tr>
                    <td style="font-weight: 700" class="style1">Question : </td>
                    <td>

                    </td>
                </tr>--%>
                <%--<tr>
                    <td style="font-weight: 700" class="style1"></td>
                    <td>
                        </td>
                </tr>--%>
               <%-- <tr>
                    <td style="font-weight: 700" class="style1">Type of Option Required: </td>
                    <td>
                        </td>
                </tr>--%>
            <%--</table>
            <br />--%>
            <hr style="width: 100%;" />
          <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Option Details :
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                   <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="mce form-control" Height="50px"
                            Width="413px"></asp:TextBox>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
            <br />
             <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Answer? :
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                   <asp:CheckBox ID="CheckBox1" runat="server" />
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
            <br />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                &nbsp;
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                   <asp:LinkButton ID="Button1" runat="server"  class="btn btn-default btn-sm" OnClick="Button1_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Save</asp:LinkButton>
                   <asp:LinkButton ID="Button2" runat="server"  Visible="false" class="btn btn-default btn-sm" OnClick="Button2_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Save Changes</asp:LinkButton>
                 </div>

                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
            <%--<table>--%>
               <%-- <tr>
                    <td style="font-weight: 700"></td>
                    <td>
                       </td>
                </tr>--%>
                <%--<tr>
                    <td style="font-weight: 700">Answer? : </td>
                    <td>

                    </td>
                </tr>--%>
               <%-- <tr>
                    <td style="font-weight: 700"></td>
                    <td>
                        <asp:Button ID="Button1" runat="server"
                            Text="Save" OnClick="Button1_Click" CssClass="btnstyle" /><asp:Button ID="Button2"
                                runat="server" Text="Save Changes" Visible="false"
                                OnClick="Button2_Click" CssClass="btnstyle" /></td>
                </tr>--%>
            <%--</table>--%>
             <hr style="width: 100%;" />


           <%-- <div style="width: 50%; overflow: auto;">
                <table id="QuestionOptionList" class="mygrid">
                    <thead>
                        <tr>
                            <th width="15%">Option ID</th>
                            <th width="20%">Answers</th>
                            <th width="25%">Correct</th>
                            <th width="25%">-</th>
                            <th width="25%">-</th>
                        </tr>
                    </thead>
                </table>
            </div>--%>



            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                 &nbsp;
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">

                 <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
          AllowPaging="True"
         EmptyDataText="No Options for This Question!" ShowHeaderWhenEmpty="True"
         PageSize="5" onpageindexchanging="GridView1_PageIndexChanging"
         onsorting="GridView1_Sorting">
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="Option ID"/>
                            <asp:TemplateField HeaderText="Answer" ControlStyle-Width="400px"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" ><%#Eval("Detail") %>
                            </asp:Panel>
                        </ItemTemplate>

<ControlStyle Width="400px"></ControlStyle>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Answer" HeaderText="Answer ?" />

                        <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkedit3" runat="server" onclick="lnkedit3_Click" >Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfID3" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditO" runat="server" onclick="lnkeditO_Click" ><%#Eval("D") %></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDO" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>

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
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
        </fieldset>

    </div>
</asp:Content>
