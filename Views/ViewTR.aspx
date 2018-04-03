<%@ Page Title="" Language="C#" MasterPageFile="~/Views/AdminView.Master" AutoEventWireup="true" CodeBehind="ViewTR.aspx.cs" Inherits="QuizBook.Views.ViewTR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=print.ClientID %>").button();
        $("#back").button();
        $("#<%=print.ClientID %>").click(function () {
            window.print()
        });


    }); 
    function Back() {
            history.go(-1);
            return false;
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="border: thin solid #008080; width: 90%; margin:0 auto; ">
<tr><td style=" text-align:left;">
    <input type="button" id="back" name="back" class="btnstyle" style="font-weight: 700" value="Back" onclick="return Back();" /></td><td style=" text-align:right;"><asp:LinkButton ID="print" CssClass="btnstyle" runat="server" 
        style="font-weight: 700"  >Print</asp:LinkButton></td></tr>
  <tr>
   <td style=" text-align:center;" colspan="2" >
   <asp:Image ID="passport" runat="server" Width="128px" Height="128px" Visible="true" />
   </td>
  </tr>
        <tr>
            <td style="width:50%; text-align: right;">
                <strong>Candidate Code:
            </strong>&nbsp;&nbsp;<span id="ccode" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%;">
              <strong>Gender:</strong>&nbsp;&nbsp;<span id="CGender" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
        <tr>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none; text-align: right;">
                <strong>Surname:
            </strong>&nbsp;&nbsp;<span id="Surname" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%;border-top: thin solid #008080; border-left-style: none; border-right-style: none; border-bottom-style: none;" >
                <strong>Other Names:</strong>&nbsp;&nbsp;<span id="COthernames" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
          <tr>
            <td style="border-top: thin solid #008080; width:50%; text-align: right; border-left-style: none; border-right-style: none; border-bottom-style: none;">
                <strong>Date of Birth:
            </strong>&nbsp;&nbsp;<span id="CDob" runat="server" style=" font-weight:normal;"></span>
            </td>
            <td style="width:50%; border-style: solid none none none; border-top-width: thin; border-top-color: #008080;">
                <strong>Test Grade:</strong>&nbsp;&nbsp;<span id="cgrade" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
 <tr>
   <td style=" text-align:center;" colspan="2" >
<asp:GridView ID="ScoreList" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" 
                    AllowSorting="True" EmptyDataText="<Empty>" 
            ShowHeaderWhenEmpty="True"  style="margin:0 auto;" >
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
      </td>
      </tr>
          </table>
</asp:Content>
