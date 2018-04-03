<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Admins.aspx.cs" Inherits="QuizBook.Views.Admins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
        $(function () {
            $(".btnstyle2").button();
            $.getJSON("http://freegeoip.net/json/", function (data) {
                var ctry = data.country_name;
                var ip = data.ip;
                if (ctry != '' && ctry != undefined) {
                    $("#<%=Location.ClientID %>").val(ctry);
                }

            });

            $("#saveRl").click(function () {
                var val = $('#<%=roleTxt.ClientID %>').val()
               
                $.ajax({
                    type: "POST",
                    url: "Admins.aspx/NewRole",
                    data: "{ 'id':'" + val + "'}",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.statusText);
                        alert(thrownError);
                    },
                    success: function (data) {
                        //  alert(data);
                        if (data.d == "success") {

                            //$('#<%=msg.ClientID %>').html("The request was successful")
                            alert("The request was successful");
                            location.href = "Admins.aspx";
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

            $("#disableRole").click(function () {
                var val = $('#<%=RoleList.ClientID %>').val()
                if (val == "-1") {

                } else {
                    $.ajax({
                        type: "POST",
                        url: "Admins.aspx/DisableRole",
                        data: "{ 'id':'" + val + "'}",
                        contentType: "application/json; charset=utf-8",
                        error: function (xhr, ajaxOptions, thrownError) {
                            alert(xhr.statusText);
                            alert(thrownError);
                        },
                        success: function (data) {
                            //  alert(data);
                            if (data.d == "success") {

                                //$('#<%=msg.ClientID %>').html("The request was successful")
                                alert("The request was successful");
                                location.href = "Admins.aspx";
                                //alert();
                                //location.href = "QuestionsList.aspx";
                            } else if (data.d == "exist") {
                                //$('#<%=msg.ClientID %>').html("This entry already exist")
                                alert("This entry already exist")
                                // alert("This entry already exist");
                            } else {
                                // $('#<%=msg.ClientID %>').html(data.d)
                                alert(data.d);
                                // alert();
                            }
                        }

                    });
                }
            });

<%--            $("#<%=fname.ClientID %>").keyup(function () {

                var f = $("#<%=fname.ClientID %>").val();

                  var l = $("#<%=lname.ClientID %>").val();

           $("#<%=username.ClientID %>").val(f.toLowerCase() + "." + l.toLowerCase());
            });

            $("#<%=lname.ClientID %>").keyup(function () {

                  var f = $("#<%=fname.ClientID %>").val();

            var l = $("#<%=lname.ClientID %>").val();

            $("#<%=username.ClientID %>").val(f.toLowerCase() + "." + l.toLowerCase());
              });--%>


        });
       function checkInput() {
           <%-- var xx = $("#<%=rname.ClientID %>").val(ctry);
            if (xx.length > 0) {
                return true;
            } else {
                return false;
            }--%>
        }
    </script>
    <div style="width: 100%; height: auto; margin: 0 auto; font-size: 10pt;">
        <fieldset>
            <legend style="font-weight: 700">My Administrator</legend>
            <asp:HiddenField ID="Location" runat="server" />
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-12" style="text-align:center;">
                    <asp:Label ID="messageBox" runat="server" Text="" style="font-weight: 700; font-size: small; color: #CC0000"></asp:Label>
                    </div>
                </div>
            <div class="row">
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" maxlength="50" placeholder="Username" required></asp:TextBox>
                        <asp:HiddenField ID="adminId" runat="server" />
                         </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:DropDownList ID="RoleList" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" placeholder="Role"></asp:DropDownList>

                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <button type="button" class="btn btn-default anewgrp" data-toggle="modal" data-target="#addpane" title="Add Role"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> </button>
                            </div>
                            <div class="col-md-9">
                                <button type="button" id="disableRole" class="btn btn-default alistgrp" title="Disable Role" ><span class="glyphicon glyphicon-remove" aria-hidden="true" ></span> </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="firstname" runat="server" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="lname" runat="server" CssClass="form-control" placeholder="Last Name" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="Address" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Address" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Email" type="email" data-error="The email address is invalid" required></asp:TextBox>
                        <div class="help-block with-errors"></div>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:DropDownList ID="sex" runat="server" CssClass="form-control" placeholder="Sex">
                            <asp:ListItem Value="-1" Text="Select" />
                            <asp:ListItem Value="Male" Text="Male" />
                            <asp:ListItem Value="Female" Text="Female" />
                            <asp:ListItem Value="Others" Text="Others" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <div class='input-group date' id='datetimepicker1'>
                            <asp:TextBox ID="dob" runat="server" CssClass="form-control" placeholder="Date of Birth" required></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
                    </div>
                </div>
            </div>

             <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">
                    <%--<asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control passwordField" placeholder="Password" type="password" data-minlength="6" required></asp:TextBox>
                    <span class="help-block">Minimum of 6 characters</span>--%>
             <asp:DropDownList ID="country" runat="server" CssClass="form-control crs-country" data-region-id="state" ClientIDMode="Static" required></asp:DropDownList>
         </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    <%-- <asp:TextBox ID="cPass"  runat="server" TextMode="Password" data-match="#password" type="password" CssClass="form-control passwordField" placeholder="Confirm Password" data-match-error="Whoops, these don't match the password"  required></asp:TextBox>
                    <div class="help-block with-errors"></div>--%>
             <asp:DropDownList ID="state" runat="server"  CssClass="form-control" ClientIDMode="Static" required></asp:DropDownList>
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    </div>

                         <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">
                   <asp:CheckBox ID="supervisor" CssClass="form-control" Text="Supervisor?" runat="server" />
         </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    </div>

             <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">

             <%--<button type="button" id="saveRoleBtn" runat="server" class="btn btn-default btn-md" ><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</button>--%>
            <%-- <asp:Button ID="saveBtn" runat="server" class="btn btn-default btn-md"><span class="glyphicon glyphicon-save" aria-hidden="true"></span> Save</asp:Button>--%>

                     <%--<asp:LinkButton ID="reg" runat="server" class="btn btn-default btn-sm" OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</asp:LinkButton>--%>
             <asp:LinkButton ID="saveRole" runat="server" class="btn btn-default btn-md" OnClientClick="return checkInput();" OnClick="saveRole_Click"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</asp:LinkButton>
         </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group" >
                    &nbsp;
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                     &nbsp;
        </div>
    </div>
    </div>

        </fieldset>
    </div>
     <br />
            <hr style="width: 100%;" />
            <br />

    <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">&nbsp;&nbsp;
                    </td>
                    <td style="text-align: right;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="TotalRecCount" runat="server" Text="" CssClass="style1"></asp:Label></td>
                    <td style="text-align: right;">
                        <asp:TextBox ID="searchText" runat="server" Style="background-color: Silver;"></asp:TextBox>
                        <asp:LinkButton ID="SearchQuest" runat="server" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>
                    </td>
                </tr>
            </table>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                AllowPaging="False"
                EmptyDataText="No Admin(s)" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="username" HeaderText="Username" />
                     <asp:BoundField DataField="firstname" HeaderText="First Name" />
                     <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                     <asp:BoundField DataField="role" HeaderText="Role" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                     <asp:BoundField DataField="supervisor" HeaderText="Supervisor?" />
                     <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditC" runat="server" OnClick="lnkeditC_Click"><%#Eval("edittxt")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("adminId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditD" runat="server" OnClick="lnkeditD_Click"><%#Eval("ends")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDD" runat="server" Value='<%# Bind("adminId") %>' />
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

    <div class="modal fade" id="addpane" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Add Role</h4>
      </div>
      <div class="modal-body">
        <asp:TextBox ID="roleTxt" runat="server" style="width:500px;" CssClass="form-control" placeHolder="Enter Role Name" ></asp:TextBox><br />
          <asp:Label ID="msg" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button"  id="saveRl" class="btn btn-primary">Save Role</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>
