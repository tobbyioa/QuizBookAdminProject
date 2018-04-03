<%@ Page Title=""  Language="C#" MasterPageFile="~/Views/AdminView.Master" AutoEventWireup="true" CodeBehind="ViewBatchResult.aspx.cs" Inherits="QuizBook.Views.ViewBatchResult" %>
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

<style type="text/css">
        .style2
    {        text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<table style="border: thin solid #008080; width: 70%; margin:0 auto; ">
<tr><td style=" text-align:left;" class="style2">
    <input type="button" id="back" name="back" class="btnstyle" style="font-weight: 700" value="Back" onclick="return Back();" /></td><td style=" text-align:right;"><asp:LinkButton ID="print" CssClass="btnstyle" runat="server" 
        style="font-weight: 700"  >Print</asp:LinkButton></td></tr>
        <tr>
            <td class="style2" colspan="2">&nbsp;&nbsp;
            </td>
            </tr>
            <tr>
            <td class="style2" colspan="2">&nbsp;</td>
            </tr>
 <tr>
            <td class="style2" colspan="2">&nbsp;&nbsp;
                <strong>Batch Name:
            </strong>&nbsp;&nbsp;<span id="bname" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="2">
                <strong>Number of Candidates:
            </strong>&nbsp;&nbsp;<span id="Span1" runat="server" style=" font-weight:normal;"></span>
              <strong>&nbsp;</strong>&nbsp;&nbsp;<span id="NoCands" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="2">
                <strong>Date Taken:
            </strong>&nbsp;&nbsp;<span id="dateTaken" runat="server" style=" font-weight:normal;"></span>
              <strong>&nbsp;</strong>&nbsp;&nbsp;<span id="Span2" runat="server" style=" font-weight:normal;"></span>
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="2">&nbsp;</td>
            </tr>
        <tr>
   <td style=" text-align:center;" colspan="2" >
   <asp:GridView ID="BatchScoreList" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" 
                    AllowSorting="True" EmptyDataText="<Empty>" 
            ShowHeaderWhenEmpty="True"  style="margin:0 auto;" >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Code" HeaderText="Code"  />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name"  />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name"  />
                            <asp:BoundField DataField="Sex" HeaderText="Sex" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                            <asp:BoundField DataField="Score" HeaderText="Score"  />
                            <asp:TemplateField HeaderText="Passport">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="60px" Height="60px" AlternateText='<%# Bind("Alt") %>' ImageUrl='<%# Bind("Passport") %>' />
                            
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
</div>
</asp:Content>
