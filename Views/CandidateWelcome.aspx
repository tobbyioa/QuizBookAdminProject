<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="CandidateWelcome.aspx.cs" Inherits="QuizBook.Views.CandidateWelcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainTable" class="row">
        <div id="r" class="col-xs-3 col-sm-3 col-md-3" style="text-align:left; vertical-align:bottom;"><a href="NewTenant.aspx" >New Tenant</a></div><div id="loginHeader" class="col-xs-6 col-sm-6 col-md-6 headFont">Welcome!!!</div><div id="l" class="col-xs-3 col-sm-3 col-md-3 ">&nbsp;</div>
        <table class="table table-striped">
            <tr>
                <td>
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        &nbsp;
                    </div>
                    <div class="col-xs-4 col-sm-4 col-md-4">
                        <div class="form-group">
                            <asp:TextBox ID="tnCode" runat="server" CssClass="form-control" MaxLength="6" placeholder="Enter your Tenant Code e.g. QUIZBK" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="regBtn" runat="server" class="btn btn-default" Text="Proceed" OnClick="regBtn_Click"/>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12">&nbsp;<asp:Label ID="lblAlert" runat="server" style="color: #666666; font-weight: 700; font-size: small" Text=""></asp:Label>
                    </div>
                  </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
