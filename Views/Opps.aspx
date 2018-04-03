<%@ Page Title="" Language="C#" MasterPageFile="~/Views/OuterPage.Master" AutoEventWireup="true" CodeBehind="Opps.aspx.cs" Inherits="QuizBook.Views.Opps" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
        <div class="col-xs-4 col-sm-4 col-md-4" style="font-size:12pt;text-align:center;"><h2>Opps</h2></div>
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
        <div class="col-xs-4 col-sm-4 col-md-4" style="font-size:12pt;text-align:center;"><img src="../Images/error.png" style="height:100px;width:100px;"  /></div>
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
    </div>
     <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;"><asp:Label ID="FriendlyErrorMsg" runat="server" Text="Label" Font-Size="Large" style="color: red"></asp:Label></div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>

    <div id="DetailedErrorPanel" runat="server" Visible="false">

    <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;font-weight:bold;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;"><strong>Detailed Error:</strong>&nbsp;<asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /></div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;font-weight:bold;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;"><%--<strong>Error Handler:</strong>&nbsp;<asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" />--%>&nbsp;</div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>
     <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;font-weight:bold;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;"><strong>Detailed Error Message:</strong>&nbsp;<asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /></div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>
      <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;font-weight:bold;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;">&nbsp;</div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>
    <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;"><asp:Label ID="InnerTrace" runat="server"  /></div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>

 <div class="row">
        <div class="col-xs-2 col-sm-2 col-md-2" style="font-size:12pt;text-align:right;font-weight:bold;">&nbsp;</div>
        <div class="col-xs-8 col-sm-8 col-md-8" style="font-size:12pt;text-align:left;">&nbsp;</div>
        <div class="col-xs-2 col-sm-2 col-md-2">&nbsp;</div>
    </div>

         <div class="row">
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
        <div class="col-xs-4 col-sm-4 col-md-4" style="font-size:12pt;text-align:center;">
            <button onclick="window.history.go(-1);" class="btn btn-default"><span class="glyphicon glyphicon-backward" aria-hidden="true"></span>&nbsp;&nbsp;Go back</button></div>
        <div class="col-xs-4 col-sm-4 col-md-4">&nbsp;</div>
    </div>

    </div>

</asp:Content>
