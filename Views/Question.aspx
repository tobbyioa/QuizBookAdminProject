<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="QuizBook.Views.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    $(function () {
           $("#accordion").accordion({ active: 1, event: "mouseover" });

        $("#Button1").button();


        $('#<%=Button1.ClientID %>').click(function () {
            if (!$('#<%=Button1.ClientID %>').val().lenght < 0) {
                alert("Please enter a question!")
            }
        });
        $('#<%=TextBox1.ClientID %>').tinymce({
            // Location of TinyMCE script, optional, already loaded in page.
            // General options
            theme: "advanced",
            plugins: "pagebreak,style,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,,searchreplace,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,responsivefilemanager",
            // Theme options
//            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,preview,help,code,",
            //            theme_advanced_buttons2: "tablecontrols",
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,|,preview,help,code,justifyleft,justifycenter,justifyright,justifyfull",
            theme_advanced_buttons2: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emoticons,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",

            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom"
        });

    });
</script>
    <div style="width: 95%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend>Add Question</legend>
<div style="text-align:right;"><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Back</asp:LinkButton>&nbsp;</div>
<hr style="width:100%;" />
<table>
<tr><td>Question:</td><td><asp:HiddenField ID="HiddenField1" runat="server" /><asp:DropDownList ID="DropDownList1" DataTextField="Name" DataValueField="Id" runat="server">
        </asp:DropDownList></td></tr>
        <tr><td>Options Type:</td><td><asp:DropDownList ID="DropDownList2" DataTextField="Name" DataValueField="Id" runat="server">
        </asp:DropDownList></td></tr>
<tr><td>Question:</td><td><asp:TextBox ID="TextBox1" runat="server" Height="113px"
        Width="413px" ></asp:TextBox>
</td></tr>
<tr><td style="text-align: right"></td><td><asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" /><asp:Button
        ID="Button3" runat="server" Text="Submit Changes" Visible="false"
        onclick="Button3_Click" /></td></tr>
</table>
</fieldset>
</div>
</asp:Content>
