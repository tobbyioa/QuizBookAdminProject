<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="AuditTrail.aspx.cs" Inherits="QuizBook.Views.AuditTrail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=SearchAuditTrail.ClientID %>").button();

        $("#<%=AuditDate.ClientID %>").datetimepicker({
            showOn: "button",
            // minDate: 0,
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            buttonImage: "../Content/themes/calendar.png",
            buttonImageOnly: true
        });

        $("#<%=detail.ClientID %>").dialog({
            show: "show",
            hide: "hide",
            height: 500,
            width: 700,
            draggable: true,
            autoOpen: false
        });

        var viewactive = $("#<%=ViewActive.ClientID %>").val();
        var viewactiveTitle = $("#<%=ViewActiveTitle.ClientID %>").val();
        // alert(parseInt(viewactive));
        if (!isNaN(parseInt(viewactive))) {
            $("#<%=detail.ClientID %>").dialog("open");
            $("#<%=detail.ClientID %>").dialog('option', 'title', viewactiveTitle);

        }

        $("#<%=ViewActive.ClientID %>").val("");
        $("#<%=ViewActiveTitle.ClientID %>").val("");
    });
</script>
<style type="text/css">
  .box
        {
            width: 100%;
            text-align:left;
            vertical-align:middle;
            overflow-x:auto;
            overflow-y:auto;
        font-weight: 700;
    }
    .style1
{
    width:200px;
}
.style2
{
   font-weight:bold;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Audit Trail</legend>
<table>

<tr><td class="style2">User:</td><td>
    <asp:TextBox ID="username" runat="server" CssClass="style1"></asp:TextBox></td>
    <td class="style2">Action:</td><td><asp:TextBox ID="Action" runat="server" CssClass="style1"></asp:TextBox>&nbsp;</td>
    <td class="style2">Table:</td><td><asp:TextBox ID="tablename" runat="server" CssClass="style1"></asp:TextBox>&nbsp;</td>
</tr>
<tr><td class="style2">Date Logged:</td><td><select id="cond" name="cond" style=" width:50px" runat="server">
    <option value="=">=</option>
    <option value="<"><</option>
    <option value=">">></option>
    </select><asp:TextBox ID="AuditDate" runat="server" style="width:100px;"></asp:TextBox></td><td class="style2"></td><td></td><td class="style2"></td><td>
    
    </td></tr>
    <tr><td class="style2">&nbsp;</td><td><asp:Button ID="SearchAuditTrail" runat="server" Text="Search" 
                CssClass="btnstyle" onclick="SearchAuditTrail_Click" /></td><td class="style2">&nbsp;</td><td>&nbsp;</td><td class="style2">
        &nbsp;</td><td>
    </td></tr>
        </table>
        <hr style=" width:100%;"/>
<asp:Label ID="TotalRecCount" runat="server" Text="Label" CssClass="style1"></asp:Label>
    <br />
    <%--<div class="fidelity-grid-theme2" style="width:100%;">--%>
   <asp:GridView ID="AudiTrailGrid" runat="server"  Width="100%"  AutoGenerateColumns="False" 
         CssClass="GridViewStyle" AllowPaging="True" 
                    AllowSorting="True" PageSize="10"
         EmptyDataText="No Logs Available" ShowHeaderWhenEmpty="True" 
        onpageindexchanging="AudiTrailGrid_PageIndexChanging" 
        onsorting="AudiTrailGrid_Sorting" >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="UserName" />
                            <asp:BoundField DataField="Action" HeaderText="Action" SortExpression="Action" />
                            <asp:BoundField DataField="TableName" HeaderText="Table Name" SortExpression="TableName" />
                           <%-- <asp:BoundField DataField="MemberName" HeaderText="Table Column" SortExpression="MemberName" />--%>
                       
                         <%--   <asp:TemplateField HeaderText="Old Value" ControlStyle-Width="200px" ControlStyle-Height="35px" SortExpression="OldValue"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="box"><%#Eval("OldValue") %>
                            </asp:Panel>
                        </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Value" ControlStyle-Width="200px" ControlStyle-Height="35px" SortExpression="NewValue"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel2" runat="server" CssClass="box" style=" font-weight:900;"><%#Eval("NewValue") %>
                            </asp:Panel>
                        </ItemTemplate></asp:TemplateField>--%>
                            <asp:BoundField DataField="AuditDate" HeaderText="Date Logged" SortExpression="AuditDate" />
                                 <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditDetail" runat="server" 
                                onclick="lnkeditDetail_Click" >Details</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDDetail" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                            
                             </Columns>
                      <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <PagerSettings PageButtonCount="7" />
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
        <%--</div>--%>
</fieldset>
       
<div id="detail" runat="server" style=" display:none; width:auto; height:auto;  overflow:auto;">
 <asp:GridView ID="DetailGrid" runat="server"  Width="100%" AutoGenerateColumns="False" 
         CssClass="GridViewStyle" 
         EmptyDataText="No Logs Available" ShowHeaderWhenEmpty="True" 
        >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MemberName" HeaderText="Table Column" SortExpression="MemberName" />
                            <asp:TemplateField HeaderText="Old Value" ControlStyle-Width="200px" ControlStyle-Height="35px" SortExpression="OldValue"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="box"><%#Eval("OldValue") %>
                            </asp:Panel>
                        </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Value" ControlStyle-Width="200px" ControlStyle-Height="35px" SortExpression="NewValue"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel2" runat="server" CssClass="box" style=" font-weight:900;"><%#Eval("NewValue") %>
                            </asp:Panel>
                        </ItemTemplate></asp:TemplateField>
                            </Columns>
                      <RowStyle CssClass="RowStyle" />
                    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                    <PagerSettings PageButtonCount="7" />
                    <PagerStyle CssClass="PagerStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
</div>
<asp:HiddenField ID="ViewActive" runat="server" Value="" />
<asp:HiddenField ID="ViewActiveTitle" runat="server" Value="" />

</div>
</asp:Content>
