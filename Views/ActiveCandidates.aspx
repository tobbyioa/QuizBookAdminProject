<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ActiveCandidates.aspx.cs" Inherits="QuizBook.Views.ActiveCandidates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            //$("#<%=rfsh.ClientID %>").button();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="col-md-6 col-sm-6 col-xs-6" style="font-weight: bold;font-size:10pt; vertical-align:bottom;padding:5px;">Active Sessions</div>
    <div class="col-md-6 col-sm-6 col-xs-6" style="font-weight: bold;font-size:10pt;text-align:right;vertical-align:bottom;padding:5px;">
        <asp:LinkButton ID="rfsh" runat="server" class="btn btn-default btn-sm" OnClick="rfsh_Click"><span class="glyphicon glyphicon-refresh" aria-hidden="true"></span>  Refresh</asp:LinkButton><%--<asp:Button ID="rfsh" class="btn btn-default btn-sm" runat="server" Text="Refresh" OnClick="rfsh_Click" />--%></div>
   <%-- <table style="width:100%;">
        <tr><td style="font-weight: bold;font-size:10pt;">Active Candidates</td><td style="text-align:right;"></td></tr>
    </table>--%>
    <br />
  <%--  <p  style="width:100%; text-align:center; height:400px;margin:0 auto; padding:7px; font-size:10pt;">--%>

				<asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"
			CssClass="GridViewStyle" style="width:100%; text-align:center; height:auto;margin:0 auto; padding:7px; font-size:10pt;"
					EmptyDataText="No Active Candidates!"
			ShowHeaderWhenEmpty="True" PageSize="20"
		   >
	  <Columns>
	  <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
							</asp:TemplateField>
		<asp:BoundField DataField="CandidateStaffId" HeaderText="Staff ID"  />
		  <asp:BoundField DataField="CandidateName" HeaderText="Candidate"  />
		 <asp:BoundField DataField="Test" HeaderText="Test Available"  />
		  <asp:BoundField DataField="Time" HeaderText="Start Time"  />
          <asp:BoundField DataField="ETime" HeaderText="End Time"  />
		  <asp:BoundField DataField="Duration" HeaderText="Duration (mins)"  />
           <asp:BoundField DataField="Rem" HeaderText="Remaining (hr:min:sec)" />
          <asp:BoundField DataField="la" HeaderText="Last Action Time"  />
            <asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditCa" CssClass="btn btn-danger" runat="server" OnClick="lnkeditCa_Click"><span class="glyphicon glyphicon-off" aria-hidden="true"></span> End Session</asp:LinkButton>
							<asp:HiddenField ID="hdfIDCa" runat="server" Value='<%# Bind("trackerId") %>'  />
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
    <br />
<%--			</p>--%>
</asp:Content>
