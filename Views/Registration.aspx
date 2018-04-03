<%@ Page Title="" Language="C#" MasterPageFile="~/Views/CandidateRegistration.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="QuizBook.Views.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.auto-style1
		{
			width: 30%;
			height: 45px;
		}
		.auto-style2
		{
			width: 70%;
			height: 45px;
		}
		td{
			padding:5px;
		}
	    .auto-style3
        {
            font-weight: bold;
            height: 34px;
        }
        .auto-style4
        {
            height: 34px;
        }
	</style>

    <script type="text/javascript">

        function checkInput() {
        if (($("#<%=grades.ClientID %>").val()) == "" || ($("#<%=grades.ClientID %>").val() == "-1")) {
	        alert("Please select a Grade");
	        $("#<%=grades.ClientID %>").focus();
	        return false;
        }

        if (($("#<%=branches.ClientID %>").val()) == "" || ($("#<%=branches.ClientID %>").val() == "-1")) {
	        alert("Please select a Branch");
	        $("#<%=branches.ClientID %>").focus();
	        return false;
        }
        if (($("#<%=Sector.ClientID %>").val()) == "" || ($("#<%=Sector.ClientID %>").val() == "-1")) {
	        alert("Please select a Sector");
	        $("#<%=Sector.ClientID %>").focus();
	        return false;
        }
        if (($("#<%=divisions.ClientID %>").val()) == "" || ($("#<%=divisions.ClientID %>").val() == "-1")) {
	        alert("Please select a Division");
	        $("#<%=divisions.ClientID %>").focus();
	        return false;

        }
        if (($("#<%=Region.ClientID %>").val()) == "" || ($("#<%=Region.ClientID %>").val() == "-1")) {
	        alert("Please select a Region");
	        $("#<%=Region.ClientID %>").focus();
	            return false;

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<br />
<br />
<%--<div id="accordion" style="width:100%; height:auto;margin:0 auto; font-size:8pt;">
	<h3><a href="#" style=" font-weight:bold;">Profile Setup</a></h3>
	<div style=" margin:0 auto;height:auto;">--%>
<table style="width: 100%;margin:0 auto;height:auto;">
		 <tr><td colspan="2"></td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Staff ID:</td><td style="width:70%;">
			<asp:Label ID="staff_id" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Surname:</td><td style="width:70%;">
			 <asp:Label ID="surname" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Other Name(s):</td><td style="width:70%;">
		 <asp:Label ID="othername" runat="server" 
			 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
		 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Email:</td><td style="width:70%;">
			 <asp:Label ID="email" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Grade:</td><td style="width:70%;">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="grades" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Branch:</td><td style="width:70%;">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="branches" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <tr><td class="ui-priority-primary">Division/Unit:</td><td class="style3">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="divisions" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
	 <tr><td class="ui-priority-primary">Directorate:</td><td class="style3">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="Sector" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
	 <tr><td class="auto-style3">Bank:</td><td class="auto-style4">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="Region" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <%--<tr><td style="width:30%;" class="style1">Supervisor Email:</td><td style="width:70%;">
			 <asp:TextBox  ID="sup_email" runat="server" CssClass="inputCSS"></asp:TextBox>
			 </td></tr>--%>
		 <tr><td class="auto-style1"></td><td class="auto-style2"><asp:Button ID="submit" 
				 runat="server" Text="Submit" CssClass="btnstyle2" OnClick="submit_Click"  OnClientClick="return checkInput();" />&nbsp;&nbsp;&nbsp;<asp:Button 
				 ID="cancel2" runat="server" Text="Cancel" CssClass="btnstyle2" OnClick="cancel2_Click" 
				  /><br />
				<%-- <asp:Label ID="alertLbl" runat="server" Text="" 
				 style="color: #CC3300; font-weight: 700; font-style: italic"></asp:Label>--%>
				 </td></tr>
		 <tr><td colspan="2" 
				 style="text-align: center; font-weight: 700; font-style: italic; font-size: medium; color: #CC0000">
			 <asp:Label ID="alertLbl" runat="server" Text=""></asp:Label>
			 </td></tr>
</table>
<%--</div>
</div>--%>
</div> 

</asp:Content>
