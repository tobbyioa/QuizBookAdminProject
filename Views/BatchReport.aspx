<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Report.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="BatchReport.aspx.cs" Inherits="QuizBook.Views.BatchReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <div id="printDiv" style="width:80%; margin: 0 auto;">
			  <asp:LinkButton ID="backBtn" runat="server"  class="btn btn-primary btn-sm" OnClick="backBtn_Click"><span class="glyphicon glyphicon-backward" aria-hidden="true"></span> Back</asp:LinkButton>
			  &nbsp;&nbsp;&nbsp;
			   <asp:LinkButton ID="pdfBtn" runat="server"  class="btn btn-success btn-sm" OnClick="pdfBtn_Click" ><span class="glyphicon glyphicon-download" aria-hidden="true"></span> PDF</asp:LinkButton>
		<hr style="width:100%; color:#808080;" />
         <asp:Panel ID="bresult" runat="server">
		<table style="width:100%">
			<tr>
				<td style="width:30%;text-align:left;font-weight:900;font-size:20pt;">QuizBook <%--<asp:Image ID="logoCtrl" runat="server"  AlternateText="QB" Width="30px" Height="39px" />--%><img id="logoCt" runat="server" src="../Images/book.png" alt="QB" style="height:30px;width:39px;" /></td>
				<%--<td style="width:70%;text-align:right;font-weight:bold;"></td>--%>
				<td style="width:70%;text-align:right;font-weight:bold;">
					Batch Test Report
					</td>
				</tr>
			</table>
					<hr style="width:100%; color:#808080;" />
							 <table  style="width:100%"  >
						<tr>
							<td style="width:30%;">&nbsp;</td>
							<td style="width:70%;text-align:right;">

								<table style="width:100%;text-align:right;">
									<tr>
										<td><strong>BatchName</strong></td>
										<td><asp:Label ID="batchName" runat="server" Text=""></asp:Label></td>
									</tr>
									<tr>
										<td><strong>Numbers of Candidates</strong></td>
										<td><asp:Label ID="candCount" runat="server" Text=""></asp:Label></td>
									</tr>
									<tr>
										<td><strong>Percentage Passed</strong></td>
										<td><asp:Label ID="ppassed" runat="server" Text=""></asp:Label></td>
									</tr>
									<tr>
										<td><strong>Percentage Failed</strong></td>
										<td><asp:Label ID="pfailed" runat="server" Text=""></asp:Label></td>
									</tr>

								</table>
							</td>
						</tr>
					</table>
					<hr style="width:100%; color:#808080;" />
		  <asp:GridView ID="ResultList" runat="server" Width="100%" AutoGenerateColumns="False"
		 AllowPaging="True"
					AllowSorting="True"
		 EmptyDataText="Empty" ShowHeaderWhenEmpty="True" >
	  <Columns>
	  <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
							</asp:TemplateField>

  <asp:BoundField DataField="BatchName" HeaderText="Batch Name"  />
  <asp:BoundField DataField="username" HeaderText="Username"  />
  <asp:BoundField DataField="FirstName" HeaderText="First Name"/>
  <asp:BoundField DataField="LastName" HeaderText="Last Name" />
		   <asp:BoundField DataField="TotalCorrect" HeaderText="Total Correct"  />
           <asp:BoundField DataField="TotalPartial" HeaderText="Total Partial"  />
  <asp:BoundField DataField="TotalWrong" HeaderText="Total Wrong"  />
  <asp:BoundField DataField="TotalUnanswered" HeaderText="Total Unanswered"/>
  <asp:BoundField DataField="TotalQuestions" HeaderText="Total Question" />
		  <asp:BoundField DataField="Percentage" HeaderText="Percentage Score"/>
  <asp:BoundField DataField="DateMarked" HeaderText="Date" />

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
             </asp:Panel>
		 </div>
</asp:Content>
