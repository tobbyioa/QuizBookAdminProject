<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="UploadQuestionImage.aspx.cs" Inherits="QuizBook.Views.UploadQuestionImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        $("#<%=UploadQImage.ClientID %>").button(); $("#<%=SearchQuest.ClientID %>").button();
    });
</script>
<style type="text/css">

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Add a Question Image</legend>
<table>
<tr><td>Image Name:</td><td><asp:TextBox ID="ImageName" runat="server"></asp:TextBox></td></tr> 
<tr><td>Question Image:</td><td><input id="QImage" name="QImage" type="file" runat="server"/> </td></tr>
<tr><td></td><td><asp:Button ID="UploadQImage" runat="server" CssClass="btnstyle" Text="Upload" 
        onclick="UploadQImage_Click"/></td></tr>  
</table>
<hr style="width:100%;" />
<div style="width:100%;"><div style=" float:left; width:40%;"><asp:Label ID="IMGIndex" runat="server" Text="Label" Width="100%" 
        style="font-weight: 700;"></asp:Label></div><div style="float:right; width:40%; text-align:right;">
            <asp:TextBox ID="searchText" runat="server" style="background-color:Silver;"></asp:TextBox> 
            <asp:Button ID="SearchQuest" runat="server" Text="Search" CssClass="btnstyle2" style=" background-color:Lime;" onclick="SearchQuest_Click"/></div></div>
<asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle"  EmptyDataText="No Images Available!" 
            ShowHeaderWhenEmpty="True" PageSize="10" 
            >
      <Columns>
       <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ImageName" HeaderText="Image Name" SortExpression="ImageName" />
                            <asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="FileName" />
                            <asp:BoundField DataField="Usage" HeaderText="Usage" SortExpression="Usage" />
                            <asp:TemplateField HeaderText="Preview" ControlStyle-Width="48px" ControlStyle-Height="48px" SortExpression="Preview"  >
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="48px" Height="48px" ImageUrl='<%#Eval("Path") %>'/>
                        </ItemTemplate>
<ControlStyle Width="48px"></ControlStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkedIMG" runat="server" onclick="lnkedIMG_Click"><%#Eval("Delete")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIMG" runat="server" Value='<%# Eval("FileName") %>'  />
                            
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
</fieldset>
</div>
</asp:Content>
