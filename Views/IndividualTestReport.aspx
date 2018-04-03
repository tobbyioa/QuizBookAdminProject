<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="IndividualTestReport.aspx.cs" Inherits="QuizBook.Views.IndividualTestReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(function () {
        $(".btnstyle2").button();
    });

    </script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="DAlert" runat="server" style="width: 100%; height:auto; margin:0 auto; font-size:10pt;" visible="false">
        <span id="alert" runat="server" style="width:100%; color:red;font-weight:bold;">You do not have the permission to view this page.</span>
    </div>
    <div id="DMain" runat="server" style="width: 100%; height:auto; margin:0 auto; font-size:10pt;" visible="false">
        <span style="width:100%; font-weight: 700; font-size: small;">Individual Test Result</span>
        <br />
        <table style="width: 70%;height:auto;">
            <tr><td style="text-align:right;">
                <asp:TextBox ID="staffId" runat="server" placeholder="Enter Candidate's Username" Width="200px" ></asp:TextBox>&nbsp;

                <%--<asp:Button ID="Button1" CssClass="btnstyle2" runat="server" Text="Check" OnClick="Button1_Click" />--%>

                <asp:LinkButton ID="Button1" runat="server" class="btn btn-default btn-sm" OnClick="Button1_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>
                </td></tr>
            <tr><td>

                <asp:GridView ID="CandidateTestList" runat="server" Width="100%" AutoGenerateColumns="False"
		 CssClass="GridViewStyle"
		 EmptyDataText="No Finished Test(s)" ShowHeaderWhenEmpty="True"  >
	  <Columns>
	  <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
							</asp:TemplateField>
          <asp:BoundField DataField="Name" HeaderText="Batch Name" />
          <asp:BoundField DataField="TimeFinished" HeaderText="Test Date"/>
          <asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditApp" runat="server" OnClick="lnkeditApp_Click" >View Result</asp:LinkButton>
							<asp:HiddenField ID="CandId" runat="server" Value='<%# Bind("Candidate") %>' />
                            <asp:HiddenField ID="BatchId" runat="server" Value='<%# Bind("Batch") %>'  />
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
                </td></tr>
         </table>
    </div>
</asp:Content>
