<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestLanding.aspx.cs" Inherits="QuizBook.Views.TestLanding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		  <%--<script src="../Scripts/jquery-1.6.4.js" type="text/javascript"></script>--%>
     <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap-show-password.js" type="text/javascript"></script>
    <%--<script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
	<%--<script src="../Scripts/jquery-1.8.0.js" type="text/javascript"></script>--%>
	<script src="../Scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
	<script src="../Scripts/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
	<link href="../Content/fidelity-theme/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
	 <script src="../Content/tiny_mce/jquery.tinymce.js" type="text/javascript"></script>
	<script src="../Content/tiny_mce/tiny_mce.js" type="text/javascript"></script>
	<script src="../Scripts/Site.js" type="text/javascript"></script>
    
	
	<link href="../Content/demo_page.css" rel="stylesheet" type="text/css" />
	<link href="../Content/demo_table.css" rel="stylesheet" type="text/css" />
	<link href="../Content/demo_table_jui.css" rel="stylesheet" type="text/css" />
	<link href="../Content/Site.css" rel="stylesheet" type="text/css" />
	<link href="../Content/YahooGridView.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Varela+Round' rel='stylesheet' type='text/css' />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Content/QuizBookFont.css" rel="stylesheet" type='text/css' />--%>
    <link href="../Content/loginStyle.css" rel="stylesheet" type='text/css' />
	<script type="text/javascript">
		$(function () {
		  
			var icons = {
				header: "ui-icon-circle-arrow-e",
				headerSelected: "ui-icon-circle-arrow-s"
			};
			$("#Button1").button();
			$("#Button2").button();
			$(".btnstyle2").button();
			//$("#lout").button();
			//$("#accordion").accordion({
			//	collapsible: true,
			//	navigation: true,
			//	fillSpace: true,
			//	icons: icons
			//});
			$("#s").attr("style", "height:auto;padding: 0px;overflow:auto;");
			//$("#Button2").click(function () {
			//    location.href = "Registration.aspx";
		    //});

			$('#<%=op.ClientID %>').blur(function () {
			    var pw = $('#<%=op.ClientID %>').val();
                   $.ajax({
                       type: "POST",
                       url: "TestLanding.aspx/PassCheck",
                       data: "{ 'op':'" + pw + "', 'xx':'candidate' }",
                       //data: "{ 'id':'" + val + "', 'name':'" + name + "'}",
                       contentType: "application/json; charset=utf-8",
                       error: function (xhr, ajaxOptions, thrownError) {
                           alert(xhr.statusText);
                           alert(thrownError);
                       },
                       success: function (data) {
                           // alert(data.d);
                           if (data.d == "success") {
                               $('#indicator').html("<span style=\"color:green;\"><span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>&nbsp; Right Password</span>");
                               $('#<%=np.ClientID %>').prop("disabled", false);
                            $('#<%=cnp.ClientID %>').prop("disabled", false);
                            $('#cgBtn').prop("disabled", false);
                        } else {
                            $('#indicator').html("<span style=\"color:red;\"><span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span>&nbsp; Wrong Password</span>");
                            $('#<%=np.ClientID %>').prop("disabled", true);
                            $('#<%=cnp.ClientID %>').prop("disabled", true);
                            $('#cgBtn').prop("disabled", true);
                        }
                    }

                });

               });

		    $('#<%=cnp.ClientID %>').blur(function () {

		        var one = $('#<%=np.ClientID %>').val();
                var two = $('#<%=cnp.ClientID %>').val();

                if (one != two || one.length < 6) {
                    $('#indicator').html("");
                    $('#indicator2').html("<span style=\"color:red;\"><span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span>&nbsp; Your new passwords must match</span>");
                    $('#cgBtn').prop("disabled", true);
                } else {
                    $('#indicator').html("");
                    $('#indicator2').html("<span style=\"color:green;\"><span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>&nbsp; Your good to go</span>");
                    $('#cgBtn').prop("disabled", false);
                }

            });

		    $('#cgBtn').click(function () {
		        var pw = $('#<%=cnp.ClientID %>').val();
                $.ajax({
                    type: "POST",
                    url: "TestLanding.aspx/ChangePass",
                    data: "{ 'op':'" + pw + "', 'xx':'candidate' }",
                    //data: "{ 'id':'" + val + "', 'name':'" + name + "'}",
                    contentType: "application/json; charset=utf-8",
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.statusText);
                        alert(thrownError);
                    },
                    success: function (data) {
                      //   alert(data.d);
                        if (data.d == "success") {
                            clear();
                            //alert($('#indicator2').html())
                            $('#indicator2').html("<span style=\"color:green;\"><span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>&nbsp; Password changed.</span>");

                        } else {
                            clear();
                            $('#indicator2').html("<span style=\"color:red;\"><span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span>&nbsp; Issues changing your password. Contact the Administrator.</span>");

                        }
                    }

                });

            });

		    var fresh = $('#<%=IsFresh.ClientID %>').val();
		   // alert(fresh);

		    if (fresh == "0" || fresh == "False") {
		        $('#showChange').modal('show');
		    }


		});

	    function clear() {
	        $('#indicator').html("");
	        $('#indicator2').html("");
	        $('#<%=op.ClientID %>').html("");
            $('#<%=np.ClientID %>').html("");
             $('#<%=cnp.ClientID %>').html("");
         }

	</script>
	<title>QuizBook</title>
</head>
<body>
        <div id="mainHeader" class="row headFont">
            <div class="col-xs-6 col-sm-6 col-md-6">QuizBook
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/book.png" Height="30px" Width="39px" />

            </div>
             <div class="col-xs-6 col-sm-6 col-md-6 welogout">
                 <%--<asp:Label ID="wlcmLbl" runat="server" Text=""></asp:Label><a 
		  href="Logout.aspx" style="text-decoration:none; color:Black;">&nbsp;&nbsp;<span id="lout" style="font-style:italic;">Logout</span></a>--%>


                 <div class="dropdown">
                     <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                         <a href="#"><span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                         <asp:Label ID="wlcmLbl" runat="server" Text=""></asp:Label>
                         <span class="caret"></span>
                     </button>
                     <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenu1">
                         <li><a href="#" data-toggle="modal" data-target="#showChange"><span class="glyphicon glyphicon-transfer" aria-hidden="true"></span>&nbsp;&nbsp;Change Password</a></li>
                         <li role="separator" class="divider"></li>
                         <li><a href="Logout.aspx"><span class="glyphicon glyphicon-off" aria-hidden="true"></span>&nbsp;&nbsp;Logout</a></li>
                     </ul>
                 </div>


             </div>
        </div>
	<form id="form1" runat="server">

         <asp:HiddenField ID="IsFresh" runat="server" />
  <%-- <div style="width: 80%; margin:0 auto;text-align:right;  font-weight:800;">
	  <asp:Label ID="wlcmLbl" runat="server" Text=""></asp:Label><a 
		  href="Logout.aspx" style="text-decoration:none; color:Black;">&nbsp;&nbsp;<span id="lout" style="font-style:italic;font-size:9pt;">Logout</span></a></div>--%>
	<div style="width: 80%; margin:0 auto; font-weight:800;">    
	 
	 <%--<div id="accordion" style="width:100%; height:auto;margin:0 auto; font-size:8pt;">
	<h3>QuizBook</h3>
		<div id="s">--%>
		<table style="width:100%;"><tr><td>&nbsp;</td><td style="text-align:right;"><%--<asp:Button ID="Button2" ClientIDMode="Static" runat="server" Text="Edit your profile" OnClick="Button2_Click" />--%></td></tr></table>
		<br />
		   <%-- <p id="testPanel" runat="server" style="width:100%; text-align:center; height:auto;margin:0 auto; padding:7px; font-size:10pt;">
		   <asp:Button ID="Button1" ClientIDMode="Static" runat="server" Text="Click Here to Start the Test" OnClick="Button1_Click" />
			</p>--%>

			<p  style="width:100%; text-align:center; height:auto;margin:0 auto; padding:7px; font-size:10pt;">

				<asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" 
			CssClass="table table-hover" style="width:90%; text-align:center; height:auto;margin:0 auto; padding:7px; font-size:10pt;"
					EmptyDataText="No Test Available!" 
			ShowHeaderWhenEmpty="True" PageSize="20" 
		   >
	  <Columns>
	  <asp:TemplateField HeaderText="SN">
							<ItemTemplate>
					<%# Container.DataItemIndex + 1 %>                     
							</ItemTemplate>
							</asp:TemplateField>
					   
					   <asp:BoundField DataField="Test" HeaderText="Test Available"  />
		  <asp:BoundField DataField="Time" HeaderText="Start Time"  />
          <asp:BoundField DataField="ETime" HeaderText="End Time"  />
		  <asp:BoundField DataField="Duration" HeaderText="Test Duration (mins)"  />
           <asp:BoundField DataField="Rem" HeaderText="Remaining (hr:min:sec)" />
          <asp:TemplateField HeaderText="-"  >
						<ItemTemplate>
                            <asp:Label ID="Label1" runat="server" style="color:red;font-weight:bold;"><%# Eval("Status") %></asp:Label>
						</ItemTemplate>
					</asp:TemplateField>
		  <asp:TemplateField HeaderText="-"  >
						<ItemTemplate>
							<asp:LinkButton ID="lnkedit3" Visible='<%# Bind("BStatus") %>' runat="server" CssClass="btn btn-default" onclick="lnkedit3_Click">
                                <span class="glyphicon glyphicon-record" aria-hidden="true"></span>&nbsp;&nbsp;
                                Start Test</asp:LinkButton>
							<asp:HiddenField ID="hdfID3" runat="server" Value='<%# Bind("ID") %>'  />
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

			</p>
			<p id="messagePanel" runat="server" style="width:100%; text-align:center; height:auto;margin:0 auto; padding:7px; font-size:10pt;">
				<asp:Label ID="messageLbl" runat="server" Text="Label" style="color:red;font-size:9pt;"></asp:Label>
			</p>
		<%-- </div>
	 </div>--%>
	</div>


          <%--Change password pane--%>
         <div class="modal fade" id="showChange" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Change your password</h4>
      </div>
      <div class="modal-body">
          <script type="text/javascript">
              $(function () {

              });
          </script>
       <%-- <table>
            <tr><td style="font-weight:bold;">Old Password</td><td >--%>
          <div class="row">
                 <div class="form-group" style="padding:10px;">
                <asp:TextBox ID="op" runat="server" TextMode="Password" style="width:100%;" CssClass="form-control passwordField" placeholder="Old Password" data-minlength="6" required></asp:TextBox>
                 <span id="indicator" style="padding:10px;font-weight:bold;"></span>    
                 </div>
                </div>
                   <%--  </td>
            </tr>
            <tr><td style="font-weight:bold;">New Password</td><td >--%>
          <div class="row">
                 <div class="form-group" style="padding:10px;">
                <asp:TextBox ID="np" runat="server" TextMode="Password" style="width:100%;" CssClass="form-control passwordField" placeholder="New Password" data-minlength="6"  required ></asp:TextBox>
                    
                      </div>
                </div>
           <%--          </td>
            </tr>
            <tr><td style="font-weight:bold;">Confirm New Password</td><td >--%>
          <div class="row">
                 <div class="form-group" style="padding:10px;">
                <asp:TextBox ID="cnp" runat="server" TextMode="Password" style="width:100%;" data-match="#np"  CssClass="form-control passwordField"  placeholder="Confirm New Password" data-minlength="6" data-match-error="Whoops, these don't match the password" required></asp:TextBox>
                     <span id="indicator2" style="padding:10px;font-weight:bold;"></span>  
                 </div>
                <asp:Label ID="msg" runat="server" Text=""></asp:Label></div>
                  <%--   </td>
            </tr>
        </table>--%>
          </div>
        <div class="modal-footer">
        <button type="button" id="clBtn" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" id="cgBtn" class="btn btn-primary">Change</button>
      </div>
    </div>
                </div>
            </div>

	</form>
   
    
</body>
</html>
