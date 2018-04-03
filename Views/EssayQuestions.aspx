<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="EssayQuestions.aspx.cs" Inherits="QuizBook.Views.EssayQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function () {
        $('#<%=ESave.ClientID %>').button();
        $('#<%=Echanges.ClientID %>').button();
        $('#<%=EssayText.ClientID %>').tinymce({
            // Location of TinyMCE script, optional, already loaded in page.
            // General options
            theme: "advanced",
            plugins: "pagebreak,style,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,,searchreplace,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template",
            // Theme options
            //            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,preview,help,code,",
            //            theme_advanced_buttons2: "tablecontrols",
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,|,preview,help,code,justifyleft,justifycenter,justifyright,justifyfull,|,link,unlink,anchor,image,cleanup,help,code,|,forecolor,backcolor",
            theme_advanced_buttons2: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",

            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom"
        });

        $('#<%=EssayDuration.ClientID %>').keyup(function () {

            if (!(isNumeric($('#<%=EssayDuration.ClientID %>').val()))) {

                alert("Only Numeric inputs are allowed");
                $('#<%=EssayDuration.ClientID %>').val("");
            }

        });

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

</style>
 <div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">
 <fieldset>
<legend style="font-weight: bold">Add Essay Questions</legend>
<table>
<tr><td>Question: </td><td><asp:HiddenField ID="essayId" runat="server"/>
<asp:TextBox ID="EssayText" runat="server" Height="113px" 
        Width="413px"></asp:TextBox>
    </td></tr>
    <tr><td>Duration:</td><td>
        <asp:TextBox ID="EssayDuration" runat="server"></asp:TextBox>
    </td></tr>
     <tr><td style="font-weight: bold" >Active : </td><td>
     <asp:CheckBox ID="Q_Active" runat="server" />
     </td></tr>
    <tr><td>&nbsp;</td><td>

        <asp:Button ID="ESave" runat="server" Text="Save" CssClass="btnstyle" 
            onclick="ESave_Click" /><asp:Button
            ID="Echanges" runat="server" Text="Submit Changes" CssClass="btnstyle" 
            Visible="false" onclick="Echanges_Click" />

    </td></tr>
        </table>
        <hr style="width:100%;" />
    <asp:Label ID="EssayIndex" runat="server" Text="Label" Width="100%" 
        style="font-weight: bold"></asp:Label>

    <br />
    <asp:GridView ID="EssayList" runat="server" AutoGenerateColumns="False" 
            CssClass="GridViewStyle" AllowPaging="True" 
                    AllowSorting="True" EmptyDataText="No Questions Available!" 
            ShowHeaderWhenEmpty="True" PageSize="5">
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Question" ControlStyle-Width="400px" ControlStyle-Height="55px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="box"><%#Eval("Detail") %>
                            </asp:Panel>
                        </ItemTemplate>

<ControlStyle Width="400px"></ControlStyle>
                    </asp:TemplateField>
                     <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />

                      <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditE" runat="server" onclick="lnkeditE_Click" >Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDE" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
             
                    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditEs" runat="server" onclick="lnkeditEs_Click" ><%#Eval("D") %></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDEs" runat="server" Value='<%# Bind("ID") %>'  />
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
