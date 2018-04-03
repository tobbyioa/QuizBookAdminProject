<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Candidate.aspx.cs" Inherits="QuizBook.Views.Candidate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
	$(function () {
	    $(".btnstyle2").button();
	    $.getJSON("http://freegeoip.net/json/", function (data) {
	        var ctry = data.country_name;
	        var ip = data.ip;
	        if (ctry != '' && ctry != undefined) {
	            $("#<%=Location.ClientID %>").val(ctry);
            }

          });
		//$("resultLbl.ClientID %>").fadeOut(10000);
		//$("#DoB.ClientID %>").datepicker({
		//	showOn: "button",
		//	// minDate: 0,
		//	changeMonth: true,
		//	changeYear: true,
		//	dateFormat: 'dd/mm/yy',
		//	buttonImage: "../Content/themes/calendar.png",
		//	buttonImageOnly: true
		//});

		//$('#RequestList').dataTable({
		//	"bJQueryUI": true,
		//	"sPaginationType": "full_numbers",
		//	"bServerSide": true,
		//	"sAjaxSource": 'CandidateList.ashx',

		//	"sServerMethod": "POST",
		//	"bDeferRender": true,
		//	//"fnServerData": fnDataTablesPipeline,

		//	"fnServerData": function (sSource, aoData, fnCallback, oSettings) {
		//	    aoData.push({ "name": "action", "value": "CandidateList" });
		//	oSettings.jqXHR = $.ajax({
		//		"dataType": 'json',
		//		"type": "POST",
		//		"url": sSource,
		//		"data": aoData,
		//		"success": fnDataTablesPipeline(sSource, aoData, fnCallback)
		//	});
		//}
	    //});
	    $("#<%=fname.ClientID %>").keyup(function () {

	       var f =  $("#<%=fname.ClientID %>").val();

	        var l = $("#<%=lname.ClientID %>").val();

	        $("#<%=username.ClientID %>").val(f.toLowerCase() + "." + l.toLowerCase());
	    });

	    $("#<%=lname.ClientID %>").keyup(function () {

	        var f = $("#<%=fname.ClientID %>").val();

              var l = $("#<%=lname.ClientID %>").val();

	        $("#<%=username.ClientID %>").val(f.toLowerCase() + "." + l.toLowerCase());
          });


	});



	    function SwitchActivity(e) {

	            var bidID = $(e).attr('id');
	            // alert(bidID);
	            $.ajax({
	                url: 'CandidateList.ashx',
	                datatype: 'html',
	                data: { id: bidID, action: "SwitchActivity" },
	                error: function (xhr, ajaxOptions, thrownError) {
	                    alert(xhr.statusText);
	                    alert(thrownError);
	                },
	                success: function (data) {
	                    alert("The request was successful");
	                    location.href = "Candidate.aspx";
	                }

	            });
	        }
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
	height:auto;
	margin:0 auto;
	font-size:10pt;
}
.style2
{
	font-weight:bold;
}
	</style>

<div style="width: 100%; height:auto; margin:0 auto; font-size:10pt;">
<fieldset>
<legend style="font-weight: 700">Candidates</legend>
<div id="CandidateDetailsPane" runat="server" class="row" style="padding:0px 0px 0px 20px;">
    <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">
                    <asp:TextBox ID="fname" runat="server" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
         </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    <asp:TextBox ID="lname" runat="server" CssClass="form-control" placeholder="Last Name" required></asp:TextBox>
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    </div>

        <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">

                    <asp:DropDownList ID="country" runat="server" CssClass="form-control crs-country" data-region-id="state" ClientIDMode="Static" required></asp:DropDownList>
                     <asp:HiddenField ID="Location" runat="server" />
                </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">

        <div class="form-group">
                      <div class='input-group date' id='datetimepicker1'>
                    <asp:TextBox ID="dob" runat="server" CssClass="form-control" placeholder="Date of Birth" required></asp:TextBox>
                     <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                     </div>

    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    </div>

    <div class="row">
    <div class="col-xs-4 col-sm-4 col-md-4">
          <div class="form-group">

                   <asp:DropDownList ID="state" runat="server"  CssClass="form-control" ClientIDMode="Static" required></asp:DropDownList>
                </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
         <div class="form-group">
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Email" type="email" data-error="The email address is invalid" required ></asp:TextBox>
                      <div class="help-block with-errors"></div>
                </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
    </div>


     <div class="row">
      <div class="col-xs-4 col-sm-4 col-md-4">
          <div class="form-group">
                     <asp:DropDownList ID="sex" runat="server" CssClass="form-control" placeholder="Sex">
                         <asp:ListItem Value="-1" Text="Select" />
                         <asp:ListItem Value="Male" Text="Male" />
                         <asp:ListItem Value="Female" Text="Female" />
                         <asp:ListItem Value="Others" Text="Others" />
                     </asp:DropDownList>
                </div>
    </div>

     <div class="col-xs-4 col-sm-4 col-md-4">

           <div class="form-group">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" maxlength="50" placeholder="Username" ReadOnly="true"></asp:TextBox>
                    <asp:HiddenField ID="InitUsername" runat="server" />
                </div>

    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
</div>


     <div class="row">
      <div class="col-xs-4 col-sm-4 col-md-4">

          <div class="form-group">
                    <asp:TextBox ID="Address" runat="server" TextMode="MultiLine"  Rows="5" CssClass="form-control" placeholder="Address" required></asp:TextBox>
                </div>
    </div>

     <div class="col-xs-4 col-sm-4 col-md-4" style="text-align:right;">
        <div class="form-group">
         <asp:DropDownList ID="RoleList" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" placeholder="Role"></asp:DropDownList>
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
</div>

     <div class="row">
      <div class="col-xs-4 col-sm-4 col-md-4">

          <div class="form-group">
                    &nbsp;
                </div>
    </div>

     <div class="col-xs-4 col-sm-4 col-md-4" style="text-align:right;">
        <div class="form-group">
       <asp:LinkButton ID="submit" runat="server" class="btn btn-default btn-sm" OnClick="submit_Click"  OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Submit</asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="cancel2" runat="server" class="btn btn-default btn-sm" OnClick="cancel2_Click"><span class="glyphicon glyphicon-erase" aria-hidden="true"></span>  Clear</asp:LinkButton>
        </div>
    </div>
    <div class="col-xs-4 col-sm-4 col-md-4">
        <div class="form-group">
                    &nbsp;
        </div>
    </div>
</div>


   <%-- <table style="width: 100%;margin:0 auto;height:auto;">
		 <tr><td colspan="2">
             <asp:HiddenField ID="objID" runat="server" />
             </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Staff ID:</td><td style="width:70%;">
             <asp:TextBox ID="staffIdtxt" runat="server"></asp:TextBox>

			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Surname:</td><td style="width:70%;">
			              <asp:TextBox ID="Surnametxt" runat="server"></asp:TextBox>
			 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Other Name(s):</td><td style="width:70%;">
             <asp:TextBox ID="OtherNamestxt" runat="server"></asp:TextBox>

		 </td></tr>
		 <tr><td style="width:30%;" class="ui-priority-primary">Email:</td><td style="width:70%;">
             <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>

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
	 <tr><td class="ui-priority-primary">Bank:</td><td class="auto-style4">
			 <asp:DropDownList DataTextField="Name" DataValueField="Id" ID="Region" runat="server" CssClass="inputCSS">
			 </asp:DropDownList>
			 </td></tr>

		 <tr><td class="auto-style1"></td><td class="auto-style2"><asp:Button ID="submit"
				 runat="server" Text="Submit" CssClass="btnstyle2" OnClick="submit_Click"  OnClientClick="return checkInput();" />&nbsp;&nbsp;&nbsp;<asp:Button
				 ID="cancel2" runat="server" Text="Clear" CssClass="btnstyle2" OnClick="cancel2_Click"
				  /><br />

				 </td></tr>
		 <tr><td colspan="2"
				 style="text-align: center; font-weight: 700; font-style: italic; font-size: medium; color: #CC0000">
			 <asp:Label ID="alertLbl" runat="server" Text=""></asp:Label>
			 </td></tr>
</table>--%>

    <div class="col-xs-12 col-sm-12 col-md-12"><asp:Label ID="alertLbl" runat="server" style="color: #666666; font-weight: 700; font-size: small" Text=""></asp:Label></div>

<%--<table ><tr>
<td>
<table>

<tr><td class="style2">First Name:</td>
	<td>
		<asp:HiddenField ID="C_Id" runat="server" />
		<asp:TextBox ID="FN" runat="server"></asp:TextBox></td><td class="style2">Last Name:</td><td>
		<asp:TextBox ID="LN" runat="server"></asp:TextBox></td></tr>
<tr><td class="style2">Middle Name:</td><td>
	<asp:TextBox ID="MN" runat="server"></asp:TextBox></td><td class="style2">Maiden Name:</td><td>
		<asp:TextBox ID="MaN" runat="server"></asp:TextBox></td></tr>
<tr><td class="style2">Sex:</td><td>
	<select id="Sex" name="Sex"  runat="server">
		<option value="Male">Male</option>
		<option value="Female">Female</option>
	</select></td><td class="style2">Date Of Birth:</td><td>
	<asp:TextBox ID="DoB" runat="server" ></asp:TextBox></td></tr>
<tr><td class="style2">Degree:</td><td><select id="Degree" name="degree_types" runat="server">
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
	</select></td><td class="style2">Course:</td><td><asp:TextBox ID="Course" runat="server"></asp:TextBox></td></tr>
<tr><td class="style2">Class Of Degree:</td><td>
	<select id="ClassOfDegree" name="ClassOfDegree" runat="server">
		<option value="1st Class">First Class</option>
		<option value="2nd Class Upper">Second Class Upper</option>
		<option value="2nd Class Lower">Second Class Lower</option>
		<option value="3nd Class">Third Class</option>
		<option value="Distinction">Distinction</option>
		<option value="Credit">Credit</option>
		<option value="Pass">Pass</option>
	</select></td><td class="style2">Referer:</td><td>
	<asp:TextBox ID="Referal" runat="server"></asp:TextBox>
	</td></tr>
<tr><td class="style2">Passport:</td><td><input id="Passport" name="Passport" type="file" runat="server"/></td><td class="style2">Email:</td><td>
	<asp:TextBox ID="Email" runat="server"></asp:TextBox>
	</td></tr>
<tr><td></td><td></td><td></td><td style="text-align: left">
	<asp:Button ID="SaveCandidate" runat="server" Text="Save" CssClass="btnstyle" onclick="Button1_Click" />&nbsp;&nbsp;
	<asp:Button ID="Clear" runat="server" Text="Clear" CssClass="btnstyle" onclick="Clear_Click" />
	</td></tr>
	<tr><td colspan="4"><asp:Label ID="resultLbl" runat="server" Width="100%" Text="" CssClass="red"></asp:Label></td></tr>
</table>


</td>
<td><asp:Panel ID="Panel1" runat="server" Width="140px" Height="140px">
	<asp:Image ID="Image1" runat="server" Width="100%" Height="100%" Visible="false" />
	</asp:Panel></td></tr>
</table>--%>
</div>
<br />
<hr style=" width:100%;"/>
<br />
	<%--<div style="width:100%; overflow:auto;">
		<table id="RequestList" class="mygrid" >
	<thead>
				<tr>
					<th width="20%">Code</th>
					<th width="25%">FirstName</th>
					<th width="25%">LastName</th>
					<th width="15%">StaffID</th>
					<th width="15%">Branch</th>
					<th width="20%">Grade</th>
					<th width="25%">Region</th>
					<th width="25%">Sector</th>
					<th width="15%">Division</th>
					<th width="15%">Active</th>
					<th width="20%">-</th>
					<th width="25%">-</th>
					<th width="25%">-</th>
					<th width="15%">DateRegistered</th>
				</tr>
			</thead>
		</table>
		</div>--%>
   <div>
       <table style="width:100%;">
           <tr><td style="text-align:left;">
               <%--<asp:Button ID="AA" runat="server" CssClass="btnstyle2" Text="Approve All" OnClick="AA_Click" />--%>
               &nbsp;&nbsp;
               <%--<asp:Button ID="DA" runat="server" CssClass="btnstyle2" Text="Disapprove All" OnClick="DA_Click" />--%>

               </td>
        <td  style="text-align:right;">&nbsp;</td></tr>
           <tr><td style="text-align:left;"><asp:Label ID="TotalRecCount" runat="server" Text="" CssClass="style1"></asp:Label></td>
        <td  style="text-align:right;"><asp:TextBox ID="searchText" runat="server"  style="background-color:Silver;"></asp:TextBox>
           <%-- <asp:Button ID="SearchQuest" runat="server" Text="Search" CssClass="btnstyle2"
                style=" background-color:Lime;" OnClick="SearchQuest_Click" />--%>
            <asp:LinkButton ID="SearchQuest" runat="server" class="btn btn-default btn-sm" OnClick="SearchQuest_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>
        </td></tr></table>
   <asp:GridView ID="CandidateList" runat="server" Width="100%" AutoGenerateColumns="False"
		 AllowPaging="True"
					AllowSorting="True"
		 EmptyDataText="No Candidate Available" ShowHeaderWhenEmpty="True"
		 PageSize="20" onpageindexchanging="CandidateList_PageIndexChanging"
		onsorting="CandidateList_Sorting" onrowcreated="CandidateList_RowCreated" >
	  <Columns>
	  <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
							</asp:TemplateField>
  <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
  <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
  <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
  <asp:BoundField DataField="Sex" HeaderText="Sex" />
  <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
  <asp:BoundField DataField="Status" HeaderText="Status"  />
  <asp:BoundField DataField="Email" HeaderText="Email"  />
  <%--<asp:BoundField DataField="Region" HeaderText="Bank" SortExpression="Region" />--%>
  <%--<asp:BoundField DataField="Active" HeaderText="Active?" SortExpression="Active" />
          <asp:BoundField DataField="LastTestLogin" HeaderText="Last Test Login" SortExpression="LastTestLogin" />
  <asp:BoundField DataField="ApprovalStatus" HeaderText="Approval" SortExpression="ApprovalStatus" />--%>
  <%--<asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditV" runat="server" onclick="lnkeditV_Click" >View</asp:LinkButton>
							<asp:HiddenField ID="hdfIDV" runat="server" Value='<%# Bind("ID") %>'  />
						</ItemTemplate>
					</asp:TemplateField>--%>
  <asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditC" runat="server" onclick="lnkeditC_Click" >Edit</asp:LinkButton>
							<asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("ID") %>'  />
						</ItemTemplate>
					</asp:TemplateField>


  <asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditCa" runat="server" onclick="lnkeditCa_Click"  ><%#Eval("D")%></asp:LinkButton>
							<asp:HiddenField ID="hdfIDCa" runat="server" Value='<%# Bind("ID") %>'  />
						</ItemTemplate>
					</asp:TemplateField>
					<%--<asp:TemplateField HeaderText="-">
						<ItemTemplate>
							<asp:LinkButton ID="lnkeditApp" runat="server" onclick="lnkeditApp_Click" ><%#Eval("ApprovalLink")%></asp:LinkButton>
							<asp:HiddenField ID="hdfIDApp" runat="server" Value='<%# Bind("ID") %>'  />
						</ItemTemplate>
					</asp:TemplateField>--%>

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
   </div>
 </fieldset>
</div>
</asp:Content>
