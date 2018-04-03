<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="EditCandidate.aspx.cs" Inherits="QuizBook.Views.EditCandidate" %>
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
			padding:10px;
		}
	        .auto-style3
            {
                font-weight: bold;
                text-align: left;
                padding:5px 5px 5px 100px;
            }
	</style>
    <script type="text/javascript">
        $(function () {
            $(".btnstyle2").button();
        });
    </script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<%--<div id="accordion" style="width:100%; height:auto;margin:0 auto; font-size:8pt;">
	<h3><a href="#" style=" font-weight:bold;">Profile Setup</a></h3>
	<div style=" margin:0 auto;height:auto;">--%>
        <br />
<table style="width: 100%;margin:0 auto;height:auto;">
		 <tr><td colspan="2" style="padding:5px 5px 5px 100px; font-weight:bold; font-size:15pt; text-decoration:underline;" class="ui-widget-content inforounded" >Edit Candidate&nbsp;-&nbsp;Staff ID&nbsp;<asp:Label ID="stID" runat="server" Text=""></asp:Label></td></tr>
     <tr><td colspan="2" >
         <asp:HiddenField ID="cidHdn" runat="server" />
         </td></tr>
		<%-- <tr><td style="width:30%; " class="auto-style3">Staff ID:</td><td style="width:70%;">
			<asp:Label ID="staff_id" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>--%>
		 <tr><td style="width:30%; " class="auto-style3">Surname:</td><td style="width:70%;">
			 <asp:Label ID="surname" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>
		 <tr><td style="width:30%;" class="auto-style3">Other Name(s):</td><td style="width:70%;">
		 <asp:Label ID="othername" runat="server" 
			 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
		 </td></tr>
		 <tr><td style="width:30%;" class="auto-style3">Email:</td><td style="width:70%;">
			 <asp:Label ID="email" runat="server" 
				 style="font-weight: 700; font-style: italic" Text="Label"></asp:Label>
			 </td></tr>
		 <tr><td style="width:30%;" class="auto-style3">Grade:</td><td style="width:70%;">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="grades" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <tr><td style="width:30%;" class="auto-style3">Branch:</td><td style="width:70%;">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="branches" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <tr><td class="auto-style3">Division/Unit:</td><td class="style3">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="divisions" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
	 <tr><td class="auto-style3">Sector:</td><td class="style3">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="Sector" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
	 <tr><td class="auto-style3">Region:</td><td class="style3">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="Region" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>
		 <%--<tr><td style="width:30%;" class="style1">Supervisor Email:</td><td style="width:70%;">
			 <asp:TextBox  ID="sup_email" runat="server" CssClass="inputCSS"></asp:TextBox>
			 </td></tr>--%>
		 <tr><td class="auto-style1"></td><td class="auto-style2"><asp:Button ID="submit" 
				 runat="server" Text="Submit" CssClass="btnstyle2" OnClick="submit_Click"  />&nbsp;&nbsp;&nbsp;<asp:Button 
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
