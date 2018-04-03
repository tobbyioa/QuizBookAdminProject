<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="PsychTestResults.aspx.cs" Inherits="QuizBook.Views.PsychTestResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=check.ClientID %>").button();
        $("#<%=resultLbl.ClientID %>").fadeOut(10000);
        $("#<%=check.ClientID %>").click(function () {
            if ($("#<%=check.ClientID %>").val().length < 1) {
                return false;
            }
        });

        $('#<%=check.ClientID %>').keyup(function () {
            var txt = $('#<%=Code.ClientID %>').val();
            if (txt.length < 1) {
                alert("Please enter a Candidate code.");
                return false;
            }
        });
    });
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">ViewCandidate Psychometric Test Result</legend>
<hr style="width:100%;" />
<table>
<tr><td style="font-weight: bold;">Enter Candidate Code:</td><td>
    <asp:TextBox ID="Code" runat="server"></asp:TextBox>
    </td><td colspan="2" class="style1"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>
<tr><td></td><td>
    <asp:Button ID="check" runat="server" Text="Check" 
        CssClass="btnstyle" onclick="check_Click"  /></td><td class="style1"></td></tr>
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
                            <asp:TemplateField HeaderText="Previous Results">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditBa" runat="server" onclick="lnkeditBa_Click" ><%#Eval("BatchName")%></asp:LinkButton>
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
<hr style="width:100%;" />
</fieldset>


</div>
</asp:Content>
