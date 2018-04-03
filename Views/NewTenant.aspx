<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="NewTenant.aspx.cs" EnableEventValidation="false" Inherits="QuizBook.Views.NewTenant" %>
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
            <div id="r" class="col-xs-3 col-sm-3 col-md-3" style="text-align:left; vertical-align:bottom;"><a href="Welcome.aspx" class="btn btn-default" ><span class="glyphicon glyphicon-backward" aria-hidden="true"></span>&nbsp;Back</a></div><div id="loginHeader" class="col-xs-6 col-sm-6 col-md-6 headFont">New Tenant</div><div id="Div1" class="col-xs-3 col-sm-3 col-md-3" style="text-align:left; vertical-align:bottom;">&nbsp;</div>
         <table class="table table-striped">
             <tr><td>
            <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;<asp:Label ID="lblAlert" runat="server" style="color: #666666; font-weight: 700; font-size: small" Text=""></asp:Label>
            </div>
          <div class="col-xs-4 col-sm-4 col-md-4">
                &nbsp;
            </div>
          <div class="col-xs-4 col-sm-4 col-md-4">
                 <div class="form-group">
                    <asp:TextBox ID="name" runat="server" CssClass="form-control" placeholder="Name" required></asp:TextBox>
                </div>
               <div class="form-group">
                    <asp:TextBox ID="shortName" runat="server" CssClass="form-control" placeholder="Short Name" data-minlength="6" required></asp:TextBox>
                   <span class="help-block">Minimum of 6 characters</span>
                </div>

               <div class="form-group">
                    <asp:TextBox ID="Address" runat="server" TextMode="MultiLine"  Rows="5" CssClass="form-control" placeholder="Address" required></asp:TextBox>
                </div>

                <div class="form-group">
                   <%-- <select id="country" name ="country" class="form-control"></select>--%>

                    <asp:DropDownList ID="country" runat="server" CssClass="form-control crs-country" data-region-id="state" ClientIDMode="Static" required></asp:DropDownList>
                </div>

                <div class="form-group">
                    <%--<select name ="state" id ="state" class="form-control"></select>--%>
                   <asp:DropDownList ID="state" runat="server"  CssClass="form-control" ClientIDMode="Static" required></asp:DropDownList>
                </div>
               <div class="form-group">
                    <input id="tLogo" name="tLogo" type="file"  class="form-control" runat="server" placeholder="Tenant Logo" required/>
                </div></div>


             </td></tr>
              <tr><td>
                   <div id="subHeader" class="col-xs-12 col-sm-12 col-md-12 headFont">Tenant Administrator</div>
              </td></tr>
             <tr><td>
                  <div class="col-xs-4 col-sm-4 col-md-4">
                &nbsp;
            </div>

          <div class="col-xs-4 col-sm-4 col-md-4">

              <div class="form-group">
                    <asp:TextBox ID="firstname" runat="server" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
                </div>
               <%-- <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;</div>--%>
                 <div class="form-group">
                    <asp:TextBox ID="lname" runat="server" CssClass="form-control" placeholder="Last Name" required></asp:TextBox>
                </div>

                 <div class="form-group">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"  Rows="5" CssClass="form-control" placeholder="Address" required></asp:TextBox>
                </div>

                 <div class="form-group">
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Email" type="email" data-error="The email address is invalid" required ></asp:TextBox>
                      <div class="help-block with-errors"></div>
                </div>

                 <div class="form-group">
                     <asp:DropDownList ID="sex" runat="server" CssClass="form-control" placeholder="Sex">
                         <asp:ListItem Value="-1" Text="Select" />
                         <asp:ListItem Value="Male" Text="Male" />
                         <asp:ListItem Value="Female" Text="Female" />
                         <asp:ListItem Value="Others" Text="Others" />
                     </asp:DropDownList>
                      <asp:HiddenField ID="Location" runat="server" />
                </div>

                 <div class="form-group">
                      <div class='input-group date' id='datetimepicker1'>
                    <asp:TextBox ID="dob" runat="server" CssClass="form-control" placeholder="Date of Birth" required></asp:TextBox>
                     <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                     </div>

                <div class="form-group">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" maxlength="50" placeholder="Username" required></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control passwordField" placeholder="Password" type="password" data-minlength="6" required></asp:TextBox>
                    <span class="help-block">Minimum of 6 characters</span>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="cPass"  runat="server" TextMode="Password" data-match="#password" type="password" CssClass="form-control passwordField" placeholder="Confirm Password" data-match-error="Whoops, these don't match the password"  required></asp:TextBox>
                    <div class="help-block with-errors"></div>
                </div>
                 <div class="form-group">
                    <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LdH0hMTAAAAACd1GM9mpDHrLZte4a45wqY2qtFT" PrivateKey="6LdH0hMTAAAAABUfvQkl-_r5gDIkUy2s5xKFYJBG"/>
                </div>
                <asp:Button ID="regBtn" runat="server" class="btn btn-default" Text="Register" OnClick="regBtn_Click"/>
              </div>
                 </td></tr></table>

         </div>
    <script type="text/javascript">
        $(function () {
            $('.passwordField').password();
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
                //pickTime: false
            });
        });
    </script>
</asp:Content>
