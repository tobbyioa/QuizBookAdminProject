<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuizBook.Views.Login" %>
<%@ MasterType VirtualPath="~/Views/OuterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div id="mainTable" class="clearfix">
            <div id="r" class="col-xs-3 col-sm-3 col-md-3" style="text-align:left; vertical-align:bottom;"><asp:LinkButton ID="lnk1" runat="server" CssClass="btn btn-default" OnClick="lnk1_Click">Switch Tenant&nbsp;<span class="glyphicon glyphicon-transfer" aria-hidden="true"></span></asp:LinkButton></div><div id="loginHeader" class="col-xs-6 col-sm-6 col-md-6 headFont">Administrator Login</div><div id="Div1" class="col-xs-3 col-sm-3 col-md-3" style="text-align:left; vertical-align:bottom;"><a href="NewTenant.aspx" >&nbsp;</a></div>
            <%--<div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>
            <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>
            <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>--%>
            <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;<asp:Label ID="lblAlert" runat="server" style="color: #666666; font-weight: 700; font-size: small" Text=""></asp:Label>
            </div>
            <table class="table table-striped">
            <tr>
                <td>
            <div class="col-xs-4 col-sm-4 col-md-4">
                &nbsp;
            </div>
            <div class="col-xs-4 col-sm-4 col-md-4">
                <div class="form-group">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Username" required></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>
                <div class="form-group">
                    <asp:TextBox ID="password" runat="server" TextMode="Password" type="password" data-minlength="6" data-match-error="Minimum of 6 character length" CssClass="form-control" placeholder="Password" required></asp:TextBox>
                    <div class="help-block with-errors"></div>
                </div>
                <div class="checkbox">
                    <label>
                        <input type="checkbox" />
                        Remember Me
                    </label>
                </div>
                <asp:Button ID="loginBtn" runat="server" class="btn btn-default" Text="Proceed" OnClick="loginBtn_Click" />
                <div class="etc-login-form">
				<p>forgot your password? <a href="#" data-toggle="modal" data-target="#addpane">click here</a></p>
				<%--<p>new user? <a href="CandidateReg.aspx">Kindly Register</a></p>--%>
			</div>
                <div class="form-group">

                    </div>
            </div>
            <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
                    </td>
            </tr>
        </table>
        </div>

        <div style="width: 100%; margin: 0; clear: both; text-align: center;" class="">
        </div>


    <div class="modal fade" id="addpane" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Reset your password</h4>
      </div>
      <div class="modal-body">
          <script type="text/javascript">
              $(function () {

              });
          </script>
        <%--<table>
            <tr><td style="font-weight:bold;">Username or Email</td><td class="auto-style1">--%>
           <div class="row">
                 <div class="form-group" style="padding:10px;">
                <asp:TextBox ID="QG" runat="server" style="" CssClass="form-control" placeholder="Username or Email" ></asp:TextBox><asp:HiddenField ID="uEmail" runat="server" />
                     <asp:Label ID="msg" runat="server" Text=""></asp:Label>
                     </div>
               </div>

                  <%--   </td>

                <td class="auto-style1">&nbsp</td>
            </tr>
        </table>--%>
          </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" id="resetBtn" class="btn btn-primary">Reset</button>
      </div>
    </div>
                </div>
            </div>


    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap-show-password.js" type="text/javascript"></script>
    <script src="../Scripts/validator.js"  type="text/javascript" ></script>
    <script type="text/javascript">
        $(function () {
            $('#password').password();


            $("#resetBtn").click(function () {
                var val = $('#<%=QG.ClientID %>').val()

                $.ajax({
                    type: "POST",
                    url: "CandLogin.aspx/ResetMth",
                    data: "{ 'name':'" + val + "'}",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.statusText);
                        alert(thrownError);
                    },
                    success: function (data) {
                        //  alert(data);
                        if (data.d == "success") {

                            $('#<%=msg.ClientID %>').html("You have successfully reset your password.")
                             //alert();
                             //location.href = "QuestionsList.aspx";
                         } else if (data.d == "exist") {
                             $('#<%=msg.ClientID %>').html("There is an issue resetting your password. Kindly retry later of contact the Administrator.")
                            // alert("");
                        } else {
                            $('#<%=msg.ClientID %>').html(data.d)
                            // alert();
                        }
                     }

                 });
            });

        });
    </script>
    </asp:Content>
