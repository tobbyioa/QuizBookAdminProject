<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="ViewTestScore.aspx.cs" Inherits="QuizBook.Views.ViewTestScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#<%=check.ClientID %>").button();
            $("#<%=resultLbl.ClientID %>").fadeOut(10000);
            $("#<%=check.ClientID %>").click(function () {
                if ($("#<%=check.ClientID %>").val().length < 1) {
                    return false;
                }
            });
            //            ('[id$=check]')
//            $(".JPrint").click(function () {
//            printDiv();
//            });
        });
        function printDiv() {
       var cid = $("#<%=CID.ClientID %>").val();
       var bid = $("#<%=BID.ClientID %>").val();
       var URL = "ViewTR.aspx?z=" + cid + "&y=" + bid;
       alert(URL);
       var newWin = window.open(URL); 
        newWin.print();
        newWin.close();
    }
    </script>
<style type="text/css">
.red
{
    color:Red;
    text-align:center;
    font-weight:bold;
}

.black
{
    color:Black;
    font-weight:bold;
}
    .style1
    {
        width: 200px;
    }
</style>
    <div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">
 <fieldset>
<legend>Test Scores</legend>
<hr style="width:100%;" />
<br />
<table>
<tr><td style="font-weight: bold;">Enter Candidate Code:</td><td>
    <asp:TextBox ID="Code" runat="server"></asp:TextBox>
    </td><td colspan="2" class="style1"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>
<tr><td></td><td><asp:Button ID="check" runat="server" Text="Check" 
        CssClass="btnstyle" onclick="check_Click" /></td><td class="style1"></td></tr>
   <tr><td colspan="3">
       <asp:Panel ID="batchHistoryPanel" runat="server" Width="100%" Visible="false">
       <asp:GridView ID="batchHistory" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" 
                    AllowSorting="True" EmptyDataText="<Empty>" 
            ShowHeaderWhenEmpty="True" >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Previous Test">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditBa" runat="server" onclick="lnkeditCa_Click"  ><%#Eval("BatchName")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDBa" runat="server" Value='<%# Bind("Code") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:BoundField DataField="DateTaken" HeaderText="Date"  />

                            </Columns>
                            <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <PagerSettings PageButtonCount="10" />
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
      </asp:GridView>
       </asp:Panel>
       </td></tr>     
</table>
<br />
<hr style="width:100%;" />
<asp:Panel ID="ScoreListPanel" runat="server" Width="100%" Visible="false">
<div style="width:100%; text-align:right;">
<asp:LinkButton ID="print" CssClass="JPrint" runat="server" 
        style="font-weight: 700" onclick="print_Click" >Print Result</asp:LinkButton>
</div>
    <asp:HiddenField ID="CID" runat="server" />
    <asp:HiddenField ID="BID" runat="server" />
<asp:Label ID="name" runat="server" Width="100%" Text="" CssClass="black"></asp:Label>
<br />
<br />

<asp:GridView ID="ScoreList" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" 
                    AllowSorting="True" EmptyDataText="<Empty>" 
            ShowHeaderWhenEmpty="True" >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="QuestionNo" HeaderText="Question No"  />
                            <asp:BoundField DataField="OptionType" HeaderText="Option Type"  />
                            <asp:BoundField DataField="CandidateOptions" HeaderText="Candidate Option(s)" />
                            <asp:TemplateField HeaderText="Status">
                        <ItemTemplate >
                            <asp:Image ID="Image1" runat="server" Width="16px" Height="16px" AlternateText='<%# Bind("Alt") %>' ImageUrl='<%# Bind("Url") %>' />
                            <%--<asp:HiddenField ID="hdfID1" runat="server" Value='<%# Bind("ID") %>'  />--%>
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
      </asp:Panel>
</fieldset>
 </div>
</asp:Content>
