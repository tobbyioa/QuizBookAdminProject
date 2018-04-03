<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CandidateReg.aspx.cs" Inherits="QuizBook.Views.CandidateReg" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $.getJSON("http://freegeoip.net/json/", function (data) {
             var ctry = data.country_name;
            var ip = data.ip;
            if (ctry != '' && ctry != undefined) {
                $("#<%=Location.ClientID %>").val(ctry);
             }

            });
         });

    </script>
     <div id="mainTable" class="row">
            <div id="loginHeader" class="col-xs-12 col-sm-12 col-md-12 headFont">Registration</div>
            <div class="col-xs-12 col-sm-12 col-md-12"><asp:Label ID="lblAlert" runat="server" style="color: #666666; font-weight: 700; font-size: small" Text=""></asp:Label></div>
            <%--<div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>
            <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>--%>
            <div class="col-xs-4 col-sm-4 col-md-4">
                &nbsp;
            </div>
            <div class="col-xs-4 col-sm-4 col-md-4">
                 <div class="form-group">
                   <%-- <asp:TextBox ID="tsname" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Tenant Short Name" required OnTextChanged="tsname_TextChanged"></asp:TextBox>--%>
                      <asp:TextBox ID="tsname" runat="server"  CssClass="form-control" placeholder="Tenant Short Name" required ></asp:TextBox>
                </div>
                 <div class="form-group">
                    <asp:TextBox ID="fname" runat="server" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
                </div>
               <%-- <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>--%>
                 <div class="form-group">
                    <asp:TextBox ID="lname" runat="server" CssClass="form-control" placeholder="Last Name" required></asp:TextBox>
                      <asp:HiddenField ID="Location" runat="server" />
                </div>

               <%--  <div class="form-group">
                    <asp:TextBox ID="Address" runat="server" TextMode="MultiLine"  Rows="5" CssClass="form-control" placeholder="Address" required></asp:TextBox>
                </div>
                 <div class="form-group">


                    <asp:DropDownList ID="country" runat="server" CssClass="form-control crs-country" data-region-id="state" ClientIDMode="Static" required></asp:DropDownList>
                    
                </div>

                <div class="form-group">

                   <asp:DropDownList ID="state" runat="server"  CssClass="form-control" ClientIDMode="Static" required></asp:DropDownList>
                </div>--%>
                 <div class="form-group">
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Email" type="email" data-error="The email address is invalid" required ></asp:TextBox>
                      <div class="help-block with-errors"></div>
                </div>

                 

                <div class="form-group">
                    <asp:DropDownList ID="RoleList" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" placeholder="Role" Visible="false"></asp:DropDownList>
                </div>

                 <div class="form-group">
                     <asp:DropDownList ID="sex" runat="server" CssClass="form-control" placeholder="Sex">
                         <asp:ListItem Value="-1" Text="Select" />
                         <asp:ListItem Value="Male" Text="Male" />
                         <asp:ListItem Value="Female" Text="Female" />
                         <asp:ListItem Value="Others" Text="Others" />
                     </asp:DropDownList>
                </div>

              <%--   <div class="form-group">
                      <div class='input-group date' id='datetimepicker1'>
                    <asp:TextBox ID="dob" runat="server" CssClass="form-control" placeholder="Date of Birth" required></asp:TextBox>
                     <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                     </div>--%>

                <div class="form-group">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" maxlength="50" placeholder="Username" required></asp:TextBox>
                </div>

                <div class="form-group has-feedback">
                    <%--<asp:TextBox ID="password" name="password" runat="server" TextMode="Password" CssClass="form-control passwordField" data-error="Minimum of 6 characters" placeholder="Password" type="password" data-minlength="6" required></asp:TextBox>--%>
                     <input class="form-control passwordField"  id="userPw" type="password" name="userPw" data-error="Minimum of 6 characters" placeholder="Password"  data-minlength="6" required/>
                    <%--<span class="help-block">Minimum of 6 characters</span>--%>
                    <span class="glyphicon form-control-feedback"></span>
                    <span class="help-block with-errors"></span>
                </div>
                <div class="form-group has-feedback">
                    <%--<asp:TextBox ID="cPass" name="cPass"  runat="server" TextMode="Password" data-match="#password" type="password" CssClass="form-control passwordField" placeholder="Confirm Password" data-minlength="6" data-match-error="Whoops, these don't match the password"  required></asp:TextBox>--%>
                    <input id="userPw2" type="password"  class="form-control passwordField" name="userPw2" data-match="#userPw" placeholder="Confirm Password" data-minlength="6" data-match-error="Whoops, these don't match the password" required/>
                    <%--<div class="help-block with-errors"></div>--%>
                    <span class="glyphicon form-control-feedback"></span>
                    <span class="help-block with-errors"></span>
                </div>
                 <div class="form-group">
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LdH0hMTAAAAACd1GM9mpDHrLZte4a45wqY2qtFT" PrivateKey="6LdH0hMTAAAAABUfvQkl-_r5gDIkUy2s5xKFYJBG"
    />
                </div>
                <asp:Button ID="regBtn" runat="server" class="btn btn-default" Text="Register" OnClick="regBtn_Click" />
                <%--<button type="submit" class="btn btn-default">Register</button>--%>
            </div>

            <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
        </div>
    <script type="text/javascript">
        $(function () {
            $('.passwordField').password();
            //$('#datetimepicker1').datetimepicker({
            //    format: 'DD/MM/YYYY'
            //    //pickTime: false
            //});
        });
    </script>
</asp:Content>
