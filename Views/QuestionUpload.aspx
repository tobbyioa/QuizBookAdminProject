<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="QuestionUpload.aspx.cs" Inherits="QuizBook.Views.QuestionUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(function () {
       
        
        $("#<%=resultLbl.ClientID %>").fadeOut(10000);



       

        $("#<%=ViewActive.ClientID %>").val("");
        $("#<%=ViewActiveTitle.ClientID %>").val("");

    });
</script>
    <style type="text/css">
        .style1
        {
            height: 334px;
        }
        .style2
        {
            color: #FF3300;
        }
        .red
{
    color:Red;
    text-align:center;
    font-weight:bold;
    float:right;
}

 .box
        {
            width: 100%;
            text-align:left;
            vertical-align:middle;
            overflow:auto;
            height:20px;
        font-weight: 700;
    }
        .style3
        {
            height: 15.75pt;
            width: 98pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            border: thin solid #000000;
        }
        .style4
        {
            width: 86pt;
            color: black;
            font-size: 11.0pt;
            /*font-weight: 700;*/
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            border: thin solid #000000;
        }
        .style5
        {
            width: 88pt;
            color: black;
            font-size: 11.0pt;
                       /*font-weight: 700;*/
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: thin solid #000000;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style6
        {
            width: 85pt;
            color: black;
            font-size: 11.0pt;
                        /*font-weight: 700;*/

            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: thin solid #000000;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style7
        {
            width: 80pt;
            color: black;
            font-size: 11.0pt;
                       /*font-weight: 700;*/

            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: thin solid #000000;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style8
        {
            width: 48pt;
            color: black;
            font-size: 11.0pt;
                        /*font-weight: 700;*/

            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
           border: thin solid #000000;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style9
        {
            width: 48pt;
            color: black;
            font-size: 11.0pt;
                        /*font-weight: 700;*/

            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
            border: thin solid #000000;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .style10
        {
            color: black;
            font-size: 11.0pt;
          /*font-weight: 700;*/
            font-style: normal;
            text-decoration: none;
            font-family: Calibri, sans-serif;
            text-align: general;
            vertical-align: bottom;
            white-space: nowrap;
           border: thin solid #000000;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Upload Questions</legend>

     <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Question: 
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" DataTextField="Name" DataValueField="Id" 
        runat="server" CssClass="form-control" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Visible="true">
        </asp:DropDownList>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">                   
                  <asp:HiddenField ID="HiddenField1" runat="server"/>
                 </div>
       </div>
    <br />
     <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                Upload Questions :
                  <br />
    (<span class="style2">Note:xls format only</span>)
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                  <input id="QuestionFile" class="form-control" name="QuestionFile" type="file" runat="server"/>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
    <br />
     <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                &nbsp;
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                    <asp:LinkButton ID="PreviewUpload" runat="server"  class="btn btn-default btn-sm" data-toggle="modal" data-target="#addpane" onclick="PreviewUpload_Click" Visible="false"><span class="glyphicon glyphicon-th" aria-hidden="true"></span>  Preview</asp:LinkButton>
                  <%--<asp:Button ID="PreviewUpload"  runat="server" Text="Preview" CssClass="btnstyle" onclick="PreviewUpload_Click"/>--%>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="Save" runat="server"  class="btn btn-default btn-sm" OnClick="Save_Click"><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span>  Save</asp:LinkButton>
                    <%--<asp:Button  ID="Save" runat="server" Text="Save" CssClass="btnstyle"  onclick="Save_Click" />--%>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
     <br />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                 SpreadSheet Format: 
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                
                 <table border="0" cellpadding="0" cellspacing="0"  style="border: thin solid #000000; border-collapse:
 collapse; width:533pt" width="709">
                     <tr>
                         <td class="style3" height="21" width="131">
                             Question</td>
                         <td class="style4" width="114">
                             Section</td>
                         <td class="style5" width="117">
                             A</td>
                         <td class="style6" width="113">
                             B</td>
                         <td class="style7" width="106">
                             C</td>
                         <td class="style8" width="64">
                             D</td>
                         <td class="style8" width="64">
                             E</td>
                         <td class="style9" width="64">
                             Answer</td>
                     </tr>
                     <tr>
                         <td class="style3" height="22">
                             What is my name ?</td>
                         <td class="style4">
                             General</td>
                         <td class="style5">
                             Buddy</td>
                         <td class="style6">
                             Bob</td>
                         <td class="style7">
                             Greg</td>
                         <td  class="style8">
                             Matthew</td>
                         <td class="style8">
                             Suezzy</td>
                         <td class="style10">
                             C</td>
                     </tr>
                     <tr>
                         <td class="style3" height="21" width="131">
                             Question</td>
                         <td class="style4" width="114">
                             Section</td>
                         <td class="style5" width="117">
                             A</td>
                         <td class="style6" width="113">
                             B</td>
                         <td class="style7" width="106">
                             C</td>
                         <td class="style8" width="64">
                             D</td>
                         <td class="style8" width="64">
                             E</td>
                         <td class="style9" width="64">
                             Answer</td>
                     </tr>
                 </table>
                 
                 <strong style="color:Red; font-size:8pt;  font-weight:bold;">
                 ***Please ensure the excel file to be uploaded conform with the format above</strong>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
     <br />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                &nbsp; 
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6" >
                  <asp:LinkButton ID="LinkButton1"  runat="server" CssClass="btn btn-default btn-md" style="text-decoration:none;color:green;" OnClick="LinkButton1_Click">Download Question Template&nbsp;<asp:Image ID="Image1" runat="server" Width="32px" Height="32px" Visible="true" ImageUrl="~/Images/file_extension_xls.png" /></asp:LinkButton>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>
     <br />
            <div class="row">
             <div class="col-xs-2 col-sm-2 col-md-2">
                &nbsp;
                 </div>
                <div class="col-xs-6 col-sm-6 col-md-6">
                  <asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label>
                 </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    &nbsp;
                 </div>
            </div>

<table>
<%--<tr><td>Question:</td><td colspan="2"><asp:HiddenField ID="HiddenField1" runat="server"/>
    <asp:DropDownList ID="DropDownList1" AutoPostBack="true" DataTextField="Name" DataValueField="Id" 
        runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Visible="true">
        </asp:DropDownList></td></tr>--%>
        <%--<tr id="preambles" runat="server" visible="false"><td>Preambles:</td>
            <td colspan="2">
            <asp:DropDownList ID="preambleLists" AutoPostBack="true" DataTextField="Name" 
                DataValueField="Id" runat="server" 
                onselectedindexchanged="preambleLists_SelectedIndexChanged">
        </asp:DropDownList></td></tr>--%>
        
         <%-- <tr id="preambleNameRow" runat="server" visible="false"><td>Preamble Name:</td>
              <td colspan="2">
              <asp:HiddenField ID="QPid" runat="server" />
              <asp:TextBox ID="PreambleName" runat="server" ></asp:TextBox>
</td></tr>
        <tr id="preambleRow" runat="server" visible="false"><td>Preamble:</td>
            <td colspan="2"><asp:TextBox ID="preambleText" runat="server" Height="113px" 
        Width="413px" ></asp:TextBox>--%>
<%--</td></tr>--%>
<%--<tr id="preview" runat="server" visible="false"><td class="style1">Preamble Preview:</td>
    <td class="style1" colspan="2">

    <asp:Label ID="PreambleNamePreview" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="PreamblePreview" runat="server" Text="Label" Height="300px" 
        Width="500px" style="  overflow:auto; font-size:10pt;"></asp:Label>
</td></tr>--%>
<%--<tr><td>Upload Questions <strong>
    <br />
    (<span class="style2">Note:xls format only</span>)</strong></td><td><input id="QuestionFile" name="QuestionFile" type="file" runat="server"/></td><td>
    &nbsp;</td></tr>--%>

   <%-- <tr><td style="text-align: right"></td><td colspan="2">
        <asp:Button ID="PreviewUpload" 
            runat="server" Text="Preview" CssClass="btnstyle" onclick="PreviewUpload_Click" 
            />&nbsp;&nbsp;&nbsp;<asp:Button
        ID="Save" runat="server" Text="Save" CssClass="btnstyle" 
            onclick="Save_Click" /></td></tr>--%>

            <%-- <tr><td colspan="3" style="text-align: left">--%>
             <%--<strong style="text-decoration:underline;">SpreadSheet Format:</strong><br />
                 
                 <table border="0" cellpadding="0" cellspacing="0" style="border: thin solid #000000; border-collapse:
 collapse; width:533pt" width="709">
                     <tr>
                         <td class="style3" height="21" width="131">
                             Question</td>
                         <td class="style4" width="114">
                             Section</td>
                         <td class="style5" width="117">
                             A</td>
                         <td class="style6" width="113">
                             B</td>
                         <td class="style7" width="106">
                             C</td>
                         <td class="style8" width="64">
                             D</td>
                         <td class="style8" width="64">
                             E</td>
                         <td class="style9" width="64">
                             Answer</td>
                     </tr>
                     <tr>
                         <td class="style3" height="22">
                             What is my name ?</td>
                         <td class="style4">
                             General</td>
                         <td class="style5">
                             Buddy</td>
                         <td class="style6">
                             Bob</td>
                         <td class="style7">
                             Greg</td>
                         <td  class="style8">
                             Matthew</td>
                         <td class="style8">
                             Suezzy</td>
                         <td class="style10">
                             C</td>
                     </tr>
                     <tr>
                         <td class="style3" height="21" width="131">
                             Question</td>
                         <td class="style4" width="114">
                             Section</td>
                         <td class="style5" width="117">
                             A</td>
                         <td class="style6" width="113">
                             B</td>
                         <td class="style7" width="106">
                             C</td>
                         <td class="style8" width="64">
                             D</td>
                         <td class="style8" width="64">
                             E</td>
                         <td class="style9" width="64">
                             Answer</td>
                     </tr>
                 </table>
                 
                 <strong style="color:Red; font-size:8pt;  font-weight:bold;">
                 ***Please ensure the excel file to be uploaded conform with the format above</strong>--%>

                
                <%-- </td></tr>--%>


    <%--<tr><td colspan="3" style="text-align:right;font-weight:bolder;">
        <asp:LinkButton ID="LinkButton1"  runat="server" style="text-decoration:none;color:green;" OnClick="LinkButton1_Click">Download Question Template&nbsp;<asp:Image ID="Image1" runat="server" Width="32px" Height="32px" Visible="true" ImageUrl="~/Images/file_extension_xls.png" /></asp:LinkButton></td></tr>
    
            <tr><td colspan="3"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>--%>
    
</table>
<br />
<br />

     <div class="modal fade" id="addpane" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Question Upload Preview</h4>
      </div>
      <div class="modal-body">


             <table style="width:100%;"><tr><td style="width:100%;height:300px; overflow:auto;">
 <asp:GridView ID="DetailGrid" runat="server"  Width="100%" AutoGenerateColumns="False" 
         CssClass="GridViewStyle" 
         EmptyDataText="Empty" ShowHeaderWhenEmpty="True">
      <Columns>
           <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>                     
							</ItemTemplate>
							</asp:TemplateField>
      <asp:TemplateField HeaderText="Question" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="box"><%#Eval("Question")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Section" HeaderText="Section" SortExpression="Section" />
          <asp:TemplateField HeaderText="Option A" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel3" runat="server" CssClass="box"><%#Eval("A")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="A" HeaderText="A" SortExpression="A" />--%>
                    <asp:TemplateField HeaderText="Option B" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel4" runat="server" CssClass="box"><%#Eval("B")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>
          <%--<asp:BoundField DataField="B" HeaderText="B" SortExpression="B" />--%>
          <%--<asp:BoundField DataField="C" HeaderText="C" SortExpression="C" />--%>
                              <asp:TemplateField HeaderText="Option C" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel5" runat="server" CssClass="box"><%#Eval("C")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="Option D" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel6" runat="server" CssClass="box"><%#Eval("D")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>
          <%--<asp:BoundField DataField="D" HeaderText="D" SortExpression="D" />--%>
                              <asp:TemplateField HeaderText="Option #" ControlStyle-Width="250px" ControlStyle-Height="30px" SortExpression="Detail"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel7" runat="server" CssClass="box"><%#Eval("E")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="250px"></ControlStyle>
                    </asp:TemplateField>
          <%--<asp:BoundField DataField="E" HeaderText="E" SortExpression="E" />--%>

                    <asp:TemplateField HeaderText="Answer" ControlStyle-Width="150px" ControlStyle-Height="30px" SortExpression="Answer"  >
                        <ItemTemplate>
                            <asp:Panel ID="Panel2" runat="server" CssClass="box"><%#Eval("Answer")%>
                            </asp:Panel>
                        </ItemTemplate>
<ControlStyle Width="150px"></ControlStyle>
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
        </td></tr>
<tr><td style="width:100%;height:50px;text-align:right;">
    <asp:Button ID="proceedtoUpload" runat="server" Text="Upload" CssClass="btnstyle" OnClick="proceedtoUpload_Click" />
</td></tr>
    </table>


           </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" id="saveGrp" class="btn btn-primary">Save</button>
      </div>
    </div>
                </div>
            </div>


<%--<div id="previewpane" runat="server" style=" display:none; width:90%;">
 
</div>--%>
    <asp:HiddenField ID="ViewActive" runat="server" Value="" />
<asp:HiddenField ID="ViewActiveTitle" runat="server" Value="" />
<asp:HiddenField ID="FileID" runat="server" Value="" />
<asp:HiddenField ID="EXT" runat="server" Value="" />
</fieldset>
</div>
</asp:Content>
