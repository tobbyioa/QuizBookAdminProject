<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Main.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="QuizBook.Views.Roles" %>

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
        });
        function checkInput() {
            var xx = $("#<%=rname.ClientID %>").val(ctry);
            if (xx.length > 0) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <div style="width: 100%; height: auto; margin: 0 auto; font-size: 10pt;">
        <fieldset>
            <legend style="font-weight: 700">Roles</legend>
            <asp:HiddenField ID="Location" runat="server" />
            <div class="row">
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        <asp:TextBox ID="rname" runat="server" CssClass="form-control" placeholder="Role Name" required></asp:TextBox>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
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
                        <asp:DropDownList ID="rl" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" placeholder="Role"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
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
                       <b>Can have Candidates?</b>
                 <asp:CheckBox ID="Active" runat="server" />
                 </div>
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
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
                        <asp:LinkButton ID="saveRole" runat="server" class="btn btn-default btn-sm" OnClientClick="return checkInput();"><span class="glyphicon glyphicon-save" aria-hidden="true"></span>  Save</asp:LinkButton>
                    </div>
                </div>

                <div class="col-xs-4 col-sm-4 col-md-4" style="text-align: right;">
                    <div class="form-group">
                        &nbsp;
                    </div>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4">
                    <div class="form-group">
                        &nbsp;
                    </div>
                </div>
            </div>
            <br />
            <hr style="width: 100%;" />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: left;">&nbsp;&nbsp;
                    </td>
                    <td style="text-align: right;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="TotalRecCount" runat="server" Text="" CssClass="style1"></asp:Label></td>
                    <td style="text-align: right;">
                        <asp:TextBox ID="searchText" runat="server" Style="background-color: Silver;"></asp:TextBox>
                        <asp:LinkButton ID="SearchQuest" runat="server" class="btn btn-default btn-sm"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>  Search</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="RoleList" runat="server" Width="100%" AutoGenerateColumns="False"
                AllowPaging="False"
                EmptyDataText="No Roles Yet" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Role" HeaderText="Role" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                    <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                    <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" />
                    <asp:BoundField DataField="DateModified" HeaderText="Date Modified" />
                    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditC" runat="server">Edit</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="-">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkeditC" runat="server">Delete</asp:LinkButton>
                            <asp:HiddenField ID="hdfIDC" runat="server" Value='<%# Bind("ID") %>' />
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
