<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="CandidateSearch.aspx.cs" Inherits="QuizBook.Views.CandidateSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

    $(function () {

        $("#<%=SearchCandidate.ClientID %>").button();
        $("#<%=resultLbl.ClientID %>").fadeOut(10000);
        $('#<%=Age.ClientID %>').keyup(function () {

            if (!(isNumeric($('#<%=Age.ClientID %>').val()))) {

                alert("Only Numeric inputs are allowed");
                $('#<%=Age.ClientID %>').val("");
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
    float:right;
}
    
.style1
{
    width:200px;
}
.style2
{
   font-weight:bold;
}
.style3
{
    width:143px;
}
</style>
<div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Candidate Search</legend>
<br />
<table>

<tr><td class="style2">Name:</td><td>
    <asp:TextBox ID="Name" runat="server" CssClass="style1"></asp:TextBox></td>
    <td class="style2">Age:</td><td><select id="cond" name="cond" style=" width:50px" runat="server">
    <option value="=">=</option>
    <option value="<"><</option>
    <option value=">">></option>
    </select>&nbsp;<asp:TextBox ID="Age" runat="server" CssClass="style3"></asp:TextBox>&nbsp;</td>
    <td class="style2">Course:</td><td><asp:TextBox ID="Course" runat="server" CssClass="style1"></asp:TextBox>&nbsp;</td>
</tr>
<tr><td class="style2">Degree:</td><td><select id="Degree" name="degree_types" class="style1" runat="server">
	<option value="0">Select a graduate degree...</option>
	<option value="Au.D.">Au.D.</option>
    <option value="B.Sc.">B.Sc.</option>
    <option value="B.A.">B.A.</option>
    <option value="B.Ed.">B.Ed.</option>
    <option value="B.A.">B.A.</option>
	<option value="D.M.A.">D.M.A.</option>
	<option value="Ed.D.">Ed.D.</option>
    <option value="H.N.D.">H.N.D.</option>
	<option value="M.A.">M.A.</option>
	<option value="M.A.S.">M.A.S.</option>
	<option value="M.B.A.">M.B.A.</option>
	<option value="M.D.">M.D.</option>
	<option value="M.Ed.">M.Ed.</option>
	<option value="M.Eng.">M.Eng.</option>
	<option value="M.F.A.">M.F.A.</option>
	<option value="M.I.A.">M.I.A.</option>
	<option value="M.P.I.A.">M.P.I.A.</option>
	<option value="M.S.">M.Sc.</option>
    <option value="M.S.">M.Sc.</option>
	<option value="O.N.D.">O.N.D.</option>
	<option value="Pharm.D.">Pharm.D.</option>
	</select></td><td class="style2">Class Of Degree:</td><td><select id="ClassOfDegree" name="ClassOfDegree" class="style1" runat="server">
        <option value="0">Class Of Degree ...</option>
        <option value="1st Class">First Class</option>
        <option value="2nd Class Upper">Second Class Upper</option>
        <option value="2nd Class Lower">Second Class Lower</option>
        <option value="3nd Class">Third Class</option>
        <option value="Distinction">Distinction</option>
        <option value="Credit">Credit</option>
        <option value="Pass">Pass</option>
    </select></td><td class="style2">Referal:</td><td>
    <asp:TextBox ID="Referal" runat="server" CssClass="style1"></asp:TextBox>
    </td></tr>
    <tr><td class="style2">Candidate<br />
        Code:</td><td><asp:TextBox ID="code" runat="server" CssClass="style1"></asp:TextBox></td><td class="style2">&nbsp;</td><td>&nbsp;</td><td class="style2">
        &nbsp;</td><td>
            <asp:Button ID="SearchCandidate" runat="server" Text="Search" CssClass="btnstyle" 
                onclick="SearchCandidate_Click" />
    </td></tr>
     <tr><td colspan="6" style="text-align: center"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>
        </table>
<br />
<hr style=" width:100%;"/>
<br />
    <asp:Label ID="TotalRecCount" runat="server" Text="Label" CssClass="style1"></asp:Label>
    <br />
   <asp:GridView ID="CandidateList" runat="server" AutoGenerateColumns="False" 
         CssClass="GridViewStyle" AllowPaging="True" 
                    AllowSorting="True" 
         EmptyDataText="No Candidate Available" ShowHeaderWhenEmpty="True" 
         PageSize="10" onpageindexchanging="CandidateList_PageIndexChanging" 
        onsorting="CandidateList_Sorting" onrowcreated="CandidateList_RowCreated" >
      <Columns>
      <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>                     
                            </ItemTemplate>
                            </asp:TemplateField>
  <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
  <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
  <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
  <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
  <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" SortExpression="DateOfBirth" />
  <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
  <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" />
  <asp:BoundField DataField="Degree" HeaderText="Degree" SortExpression="Degree" />
  <asp:BoundField DataField="ClassOfDegree" HeaderText="Class Of Degree" SortExpression="ClassOfDegree" />
  <asp:BoundField DataField="Passport" HeaderText="Passport?" SortExpression="Passport" />
  <asp:BoundField DataField="Active" HeaderText="Active?" SortExpression="Active" />
  <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval" SortExpression="ApprovalStatus" />
  <asp:BoundField DataField="Referal" HeaderText="Referral" SortExpression="Referal" />
  <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditV" runat="server" onclick="lnkeditV_Click" >View</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDV" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditC" runat="server" onclick="lnkeditC_Click" >Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
   <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditCS" runat="server" onclick="lnkeditCS_Click" ><%#Eval("D") %></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDCS" runat="server" Value='<%# Bind("ID") %>'  />
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditApp" runat="server" onclick="lnkeditApp_Click" ><%#Eval("ApprovalLink")%></asp:LinkButton>
                            <asp:HiddenField ID="hdfIDApp" runat="server" Value='<%# Bind("ID") %>'  />
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
