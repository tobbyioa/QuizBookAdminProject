<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="QuestionsList.aspx.cs" Inherits="QuizBook.Views.QuestionsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {


            $("#saveGrp").click(function () {
                var val = $('#<%=QG.ClientID %>').val()
                var name = $('#<%=uEmail.ClientID %>').val();
                $.ajax({
                    type: "POST",
                    url: "QuestionsList.aspx/NewQuestionGroup",
                    data: "{ 'id':'" + val + "', 'name':'" + name + "'}",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.statusText);
                        alert(thrownError);
                    },
                    success: function (data) {
                        //  alert(data);
                        if (data.d == "success") {

                            $('#<%=msg.ClientID %>').html("The request was successful")
                            //alert();
                            //location.href = "QuestionsList.aspx";
                        } else if (data.d == "exist") {
                            $('#<%=msg.ClientID %>').html("This entry already exist")
                           // alert("");
                        } else {
                            $('#<%=msg.ClientID %>').html(data.d)
                           // alert();
                        }
                    }

                });
            });
        });

        tinymce.init({
            selector: '.mce',
            height: 200,
            plugins: [
                    "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
                    "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
                    "save table contextmenu directionality emoticons template paste textcolor"
            ],

            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css',
              "Content/bootstrap.min.css"
            ],
            toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
            file_browser_callback: function (field, url, type, win) {
                tinyMCE.activeEditor.windowManager.open({
                   url: '/QuizBook/FileBrowser/FileBrowser.aspx?caller=tinymce4&langCode=en&type=' + type,
                   // url: 'http://localhost:23191/dialog.aspx',
                    title: 'File Browser',
                    width: 700,
                    height: 500,
                    inline: true,
                    close_previous: false
                }, {
                    window: win,
                    field: field
                });
                return false;
            }
        });

</script>

<style type="text/css">

    .ui-dialog{
position:absolute;
top:70px;
left:600px;
z-index:103;
}
.ui-widget-overlay{
z-index:102;
}
  .box
        {
            width: 300px;
            height:50px;
            text-align:left;
            vertical-align:middle;
            overflow:auto;
        font-weight: 700;
    }
            .stylex
        {
            width: 100%;
        }
            td{
padding:5px 5px 5px 5px;
            }
    .auto-style1
    {
        height: 38px;
    }
    .auto-style2
    {
        height: 38px;
        width: 102px;
    }
    .auto-style3
    {
        width: 102px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">

<fieldset>
<legend style="font-weight: 700">Add Question</legend>
<div style="margin:0 auto;font-size:10pt;" class="stylex">
    <div class="row"><asp:Label ID="EditLbl" runat="server" Text="" Width="100%"
        style="font-weight: 700"></asp:Label></div>

    <div class="row">
         <div class="col-xs-2 col-sm-2 col-md-2">Question Group:</div>
       <%-- <div class="col-xs-10 col-sm-10 col-md-10">--%>
            <div class="col-xs-5 col-sm-5 col-md-5">

            <asp:HiddenField ID="HiddenField1" runat="server"/>
            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" CssClass="form-control" DataTextField="Name" DataValueField="Id"
        runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Visible="true">
        </asp:DropDownList>
                </div>
            <div class="col-xs-1 col-sm-1 col-md-1">
            <button type="button" class="btn btn-default anewgrp" data-toggle="modal" data-target="#addpane"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>  Add New</button>
                </div>
            <div class="col-xs-4 col-sm-4 col-md-4">
             <button type="button" class="btn btn-default alistgrp" ><span class="glyphicon glyphicon-remove" aria-hidden="true"></span>  Deactivate Question Group</button>
                </div>
        <%--</div>--%>
    </div>
    <br />
    <div id="preambleNameRow" runat="server" visible="false" class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Preamble Name:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:HiddenField ID="QPid" runat="server" />
              <asp:TextBox ID="PreambleName" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
        </div>

    <div id="preambleRow" runat="server" visible="false" class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Preamble:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:TextBox ID="preambleText" runat="server" CssClass="form-control" Height="113px"
        Width="413px" ></asp:TextBox>
            </div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
        </div>

    <div id="preview" runat="server" visible="false" class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Preamble Preview:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
             <asp:Label ID="PreambleNamePreview" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="PreamblePreview" runat="server" Text="Label" Height="300px"
        Width="500px" style=" overflow-x:auto;  overflow-y:auto; font-size:10pt;"></asp:Label>
            </div>
        </div>
    <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div> <br />
        </div>

    <div  class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Section:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:TextBox ID="Section" CssClass="mce form-control" runat="server"  TextMode="MultiLine" Height="113px"></asp:TextBox>
            </div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div>

        </div>
    <br />
    <div  class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Question:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:TextBox ID="TextBox1" CssClass="mce form-control" runat="server"  TextMode="MultiLine" Height="113px"
        Width="413px"  ></asp:TextBox>
            </div>
         <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div>
        </div>
    <br />
    <%--visible="false"--%>
     <div runat="server"  class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Question Options Type:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:DropDownList ID="DropDownList2" DataTextField="Name" DataValueField="Id" CssClass="form-control" runat="server">
        </asp:DropDownList>
            </div>
          <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
         </div>
    <br />
     <div runat="server"  class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Mark:</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
           <asp:TextBox ID="markTxt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
          <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
         </div>
    <br />
     <div runat="server"  class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">Make Option % of Mark</div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            <asp:CheckBox ID="percentOption" CssClass="form-control" runat="server" />
            </div>
          <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
         </div>
    <br />

    <div id="Div1" runat="server"   class="row">
      <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
        <div class="col-xs-5 col-sm-5 col-md-5" style="text-align: right">
            <%--<asp:Button ID="Button1" runat="server" Text="Save" CssClass="btnstyle" onclick="Button1_Click" OnClientClick="return checkInput();" />--%>

            <asp:LinkButton ID="Button1" runat="server" class="btn btn-default btn-sm" OnClick="Button1_Click"  OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</asp:LinkButton>

            <%--<asp:LinkButton ID="Button1" runat="server" class="btn btn-default btn-sm" OnClick="Button1_Click"  OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</asp:LinkButton>--%>
           <%-- <asp:Button ID="Button3" runat="server" Text="Submit Changes" CssClass="btnstyle" Visible="false"
        onclick="Button3_Click" OnClientClick="return checkInput();" />--%>
            <asp:LinkButton ID="Button3" runat="server" class="btn btn-default btn-sm" Visible="false" OnClick="Button3_Click"  OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Submit Changes</asp:LinkButton>
            </div>
        <div class="col-xs-5 col-sm-5 col-md-5">
            &nbsp;
            </div><br />
        </div>

<%--<table>--%>
<%--<tr><td>Question Group:</td><td style=""><table><tr>
    <td></td>
    <td><a class="anewgrp" href="#"><span class="ui-icon ui-icon-circle-plus"></span></a>
</td>
    <td>
        <a class="anewgrp" href="#"  >Add New</a>


    </td><td></td><td><a class="alistgrp" href="#"><span class="ui-icon ui-icon-circle-close"></span></a></td><td>

        <a class="alistgrp" href="#">Deactivate Question Group</a>


                                                                                                              </td></tr></table>
    &nbsp;</td></tr>--%>

<%--          <tr id="preambleNameRow" runat="server" visible="false"><td>Preamble Name:</td><td>
              <asp:HiddenField ID="QPid" runat="server" />
              <asp:TextBox ID="PreambleName" runat="server" ></asp:TextBox>
</td></tr>--%>
  <%--      <tr id="preambleRow" runat="server" visible="false"><td>Preamble:</td><td><asp:TextBox ID="preambleText" runat="server" Height="113px"
        Width="413px" ></asp:TextBox>
</td></tr>--%>
<%--<tr id="preview" runat="server" visible="false"><td>Preamble Preview:</td><td>

    <asp:Label ID="PreambleNamePreview" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="PreamblePreview" runat="server" Text="Label" Height="300px"
        Width="500px" style=" overflow-x:auto;  overflow-y:auto; font-size:10pt;"></asp:Label>
</td></tr>--%>
   <%-- <tr><td>Section:</td><td><asp:TextBox ID="Section" runat="server"></asp:TextBox>
</td></tr>--%>
<%--<tr><td>Question:</td><td><asp:TextBox ID="TextBox1" CssClass="mce" runat="server" TextMode="MultiLine" Height="113px"
        Width="413px" ></asp:TextBox>
</td></tr>--%>
<%--<tr runat="server" visible="false"><td>Question Options Type:</td><td><asp:DropDownList ID="DropDownList2" DataTextField="Name" DataValueField="Id" runat="server">
        </asp:DropDownList></td></tr>--%>
<%--<tr><td style="text-align: right"></td><td></td></tr>
</table>--%>

  <hr style="width:100%;" />
    <%--<div class="row">
        <div class="col-xs-6 col-sm-6 col-md-6">

        </div>
        <div class="col-xs-6 col-sm-6 col-md-6" style="text-align:right;">

            <asp:LinkButton ID="SearchQuest" runat="server" class="btn btn-default btn-sm" OnClick="SearchQuest_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>

             <asp:Button ID="SearchQuest" runat="server" Text="Search" CssClass="btnstyle" style=" background-color:Lime;" onclick="SearchQuest_Click"/>
        </div>
    </div>--%>
    <asp:Button ID="saveQGrp" runat="server" Text="Save" CssClass="btnstyle" Style="display: none" />
  <div style="width:100%;"><div style=" float:left; width:40%;"> <asp:Label ID="QuestionIndex" runat="server" Text="Label" Width="100%"
        style="font-weight: 700;"></asp:Label></div>
      <div style="float:right; width:60%;text-align:right;">
          <asp:TextBox ID="searchText" runat="server" style="background-color:Silver;"></asp:TextBox>
          <asp:LinkButton ID="SearchQuest" runat="server"  class="btn btn-default btn-sm" OnClick="SearchQuest_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>
            </div>
  </div>
    <br />
    <br />

    <div class="row">
      <asp:GridView ID="GridView1" Width="100%"  runat="server" AutoGenerateColumns="False"
             AllowPaging="True"
                    AllowSorting="True" EmptyDataText="No Questions Available!"
            ShowHeaderWhenEmpty="True" PageSize="20"
            onpageindexchanging="GridView1_PageIndexChanging" onsorting="GridView1_Sorting">
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="Question ID"/>
                            <asp:TemplateField HeaderText="Question" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="box"><%#Eval("Detail") %>
                            </asp:Panel>
                        </ItemTemplate>

<ControlStyle Width="400px"></ControlStyle>
                    </asp:TemplateField>
                     <asp:BoundField DataField="Type" HeaderText="Type" />
                      <asp:BoundField DataField="OptionType" HeaderText="Options Type"  />
                       <asp:BoundField DataField="Section" HeaderText="Section" />
                       <asp:BoundField DataField="IsActive" HeaderText="Active" />
       <asp:TemplateField HeaderText="Options" SortExpression="OptionsCount">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkedit2" runat="server"
                                Text='<%# Bind("OptionsCount") %>' onclick="lnkedit2_Click" />
                            <asp:HiddenField ID="hdfID1" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkedit3" runat="server" onclick="lnkedit3_Click" >Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfID3" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditQ" runat="server" onclick="lnkeditQ_Click" ><%#Eval("D") %></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDQ" runat="server" Value='<%# Bind("ID") %>'  />
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
      </div>
      </fieldset>
  </div>

    <%--<div id="addpane" style="display:none">--%>
        <div class="modal fade" id="addpane" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Add New Question Group</h4>
      </div>
      <div class="modal-body">
          <script type="text/javascript">
              $(function () {

              });
          </script>
        <table>
            <tr><td style="font-weight:bold;">Name</td><td class="auto-style1">
                 <div class="form-group">
                <asp:TextBox ID="QG" runat="server" style="width:500px;" CssClass="form-control" ></asp:TextBox><asp:HiddenField ID="uEmail" runat="server" />
                     </div>
                <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                     </td>

                <td class="auto-style1">&nbsp</td>
            </tr>
         <tr runat ="server" visible="false"><td style="font-weight:bold;">List</td><td class="auto-style1">

             <asp:ListBox ID="QGroupList" runat="server" Width="250px" Height="300px" CssClass="inputCSS" DataTextField="Name" DataValueField="ID"></asp:ListBox>
             </td>
             <td class="auto-style1">
                <button id="DeleteGroup" type="button" class="btn">Delete</button>
             </td>
         </tr>
        </table>
          </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" id="saveGrp" class="btn btn-primary">Save</button>
      </div>
    </div>
                </div>
            </div>
    <div id="listpane" style="display:none; overflow: auto;">
        <table id="QtypeGrid" class="mygrid">
            <thead>
                <tr>
                    <th width="15%">Name</th>
                    <th width="20%">Status</th>
                    <th width="25%">-</th>
                </tr>
            </thead>
        </table>
    </div>
</asp:Content>
