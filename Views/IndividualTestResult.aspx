<%@ Page Language="C#" MasterPageFile="~/Views/Report.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IndividualTestResult.aspx.cs" Inherits="QuizBook.Views.IndividualTestResult" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <div id="printDiv" style="width:70%; margin: 0 auto;">
              <asp:LinkButton ID="backBtn" runat="server"  class="btn btn-primary btn-sm" OnClick="backBtn_Click"><span class="glyphicon glyphicon-backward" aria-hidden="true"></span> Back</asp:LinkButton>
              &nbsp;&nbsp;&nbsp;
               <asp:LinkButton ID="pdfBtn" runat="server"  class="btn btn-success btn-sm" OnClick="pdfBtn_Click" ><span class="glyphicon glyphicon-download" aria-hidden="true"></span> PDF</asp:LinkButton>
        <hr style="width:100%; color:#808080;" />
              <asp:HiddenField ID="userFld" runat="server" />
              <asp:HiddenField ID="batchFld" runat="server" />
              <asp:Panel ID="Panel1" runat="server">
        <table style="width:100%">
            <tr>
                <td style="width:30%;text-align:left;font-weight:900;font-size:20pt;">QuizBook <img id="logoCt" runat="server" src="../Images/book.png" alt="QB" style="height:30px;width:39px;" /></td>
                <td style="width:70%;text-align:right;font-weight:bold;">
                    Individual Test Report
                    </td>
                </tr>
            </table>
                    <hr style="width:100%; color:#808080;" />

                    <table style="width:100%">
                        <tr>
                            <td style="width:30%;">&nbsp;</td>
                            <td style="width:70%;text-align:right;">

                                <table style="width:100%">
                                    <tr>
                                        <td>Candidate Id</td>
                                        <td><asp:Label ID="candidateId" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Candidate Name</td>
                                        <td><asp:Label ID="candidateName" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Test Batch</td>
                                        <td><asp:Label ID="batchName" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Organization</td>
                                        <td><asp:Label ID="tenantName" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Test Date</td>
                                        <td><asp:Label ID="tstDate" runat="server" Text=""></asp:Label></td>
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
              <asp:TemplateField HeaderText="Question" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("question") %>
                        </ItemTemplate>
                    </asp:TemplateField>
 <%-- <asp:BoundField DataField="Question" HeaderText="Question"  />--%>
  <%--<asp:BoundField DataField="Answer" HeaderText="Answer"  />--%>
          <asp:TemplateField HeaderText="Answer" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("chosenAnswer") %>
                        </ItemTemplate>
                    </asp:TemplateField>
  <%--<asp:BoundField DataField="CorrectAnswer" HeaderText="Correct Answer"/>--%>
           <asp:TemplateField HeaderText="CorrectAnswer" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("correctAnswer") %>
                        </ItemTemplate>
                    </asp:TemplateField>

          <asp:TemplateField HeaderText="Marck" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("Mark") %>
                        </ItemTemplate>
                    </asp:TemplateField>

          <asp:TemplateField HeaderText="Score" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("Score") %>
                        </ItemTemplate>
                    </asp:TemplateField>
  <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>
                    <asp:TemplateField HeaderText="Status" ControlStyle-Width="400px" ControlStyle-Height="30px"   >
                        <ItemTemplate>
                            <%#Eval("Status") %>
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

                    <hr style="width:100%; color:#808080;" />

                  <table style="width:100%;text-align:right;" >
                                    <tr>
                                        <th style="text-align:right;">
                                            -
                                        </th>
                                        <th style="text-align:right;">
                                            Score
                                        </th>
                                        <th style="text-align:right;">
                                            Percentage
                                        </th>
                                        <th style="text-align:right;">
                                            -
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="result_correct" runat="server" Text=""></asp:Label></td>
                                        <td><asp:Label ID="Correct" runat="server" Text=""></asp:Label></td>
                                        <td><b>Correct</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="result_partial" runat="server" Text=""></asp:Label></td>
                                        <td><asp:Label ID="Partial" runat="server" Text=""></asp:Label></td>
                                        <td><b>Partial</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="result_wrong" runat="server" Text=""></asp:Label></td>
                                        <td><asp:Label ID="Wrong" runat="server" Text=""></asp:Label></td>
                                        <td><b>Wrong</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td><asp:Label ID="result_unanswered" runat="server" Text=""></asp:Label></td>
                                        <td><asp:Label ID="Unanswered" runat="server" Text=""></asp:Label></td>
                                        <td><b>Unanswered</b></td>
                                    </tr>
                                    <tr>
                                        <td><b>Total</b></td>
                                        <td><asp:Label ID="sumation_result" runat="server" Text=""></asp:Label><%--@Html.Raw((Model.result.Correct + Model.result.Partial)) out of @Html.Raw((Model.totalQuestionMark))--%></td>
                                        <td><asp:Label ID="percentage" runat="server" Text=""></asp:Label>&nbsp;&nbsp;</td>
                                        <td><b>&nbsp;</b></td>
                                    </tr>
                                </table>


                    <%--<table style="width:100%">
                        <tr>
                            <td style="width:70%;">&nbsp;</td>
                            <td style="width:30%;text-align:right;">
                                <table style="width:100%">
                                    <tr>
                                        <td> &nbsp;&nbsp;&nbsp;</td>
                                        <td><b>Correct</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;</td>
                                        <td><b>Wrong</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;</td>
                                        <td><b>Unanswered</b></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;&nbsp;</td>
                                        <td><b>Percent(%)</b></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>--%>
                    <hr style="width:100%; color:#808080;" />
                  </asp:Panel>

    </div>

   <%-- <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="70%" Height="1500px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="12pt">
            <LocalReport ReportEmbeddedResource="FidelityEquiz.Views.IndividualTestReport.rdlc" ReportPath="Reports\IndividualTestReport.rdlc" EnableExternalImages="true">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="IndividualTestReport" TypeName="FidelityEquiz.Helpers.ReportFactory.ERecruitReportFactory, FidelityEquiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="candid" SessionField="CandId" Type="Int64" />
                <asp:SessionParameter DefaultValue="" Name="batchid" SessionField="BatchId" Type="Int64" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>--%>

</asp:Content>