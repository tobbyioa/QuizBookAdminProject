using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using QuizBook.Model;

namespace QuizBook.Views
{
    public partial class TestReport : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanManageTestBatches)
                {
                    //from.Text = ErecruitHelper.GetDateStringFromDateX(DateTime.Now);
                    //to.Text = ErecruitHelper.GetDateStringFromDateX(DateTime.Now);
                    if (!IsPostBack)
                    {
                        //var l = Enum.GetValues(typeof(ErecruitHelper.BatchGroupsR)).Cast<ErecruitHelper.BatchGroupsR>().ToList();
                        //var bg = l.Select(a => new
                        //{
                        //    Id = a.ToString(),
                        //    Name = a.ToString()

                        //}).Distinct().OrderBy(s => s.Name).ToList();
                        //bgrp.DataSource = bg;
                        // bgrp.DataBind();
                        var tn = long.Parse(SessionHelper.GetTenantID(Session));
                        var cands = new List<object> { new { ID = "ALL", Name = "ALL" } };
                        using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                        {
                            var batches = _db.T_Batch.Where(x => x.TenantId == tn && x.IsActive.Value).Select(x=> new
                            {
                                ID = x.Id,
                                Name = x.Name
                            }).OrderByDescending(x =>x.ID);
                            GroupContentList.DataSource = batches.ToList();
                            GroupContentList.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect("NoPermission.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                //var selectedGroup = bgrp.SelectedValue;
                var GroupItem = GroupContentList.SelectedValue;
               // Session["Grp"] = string.IsNullOrEmpty(selectedGroup) ? "ALL" : selectedGroup.Trim();
                Session["GrpList"] = string.IsNullOrEmpty(GroupItem) ? "ALL" : GroupItem.Trim();
                //ErecruitHelper.GetCurrentDateFromDateStringWithHM(Stdate);
                Session["dateFrom"] = string.IsNullOrEmpty(from.Text)?DateTime.Now.Date:ErecruitHelper.GetCurrentDateFromDateStringWithHM(from.Text);
                Session["dateTo"] = string.IsNullOrEmpty(to.Text) ? DateTime.Now.Date : ErecruitHelper.GetCurrentDateFromDateStringWithHM(to.Text);
                Session["From"] = string.IsNullOrEmpty(from.Text) ? true : false;
                Session["To"] = string.IsNullOrEmpty(to.Text) ? true : false;
                Response.Redirect("BatchReport.aspx", false);
                // Response.Redirect("~/Reports/ResultView.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void bgrp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // var selectedGroup = bgrp.SelectedValue;
          //  GChangeState(selectedGroup);
        }

        private void GChangeState(string selectedGroup)
        {
            switch (selectedGroup)
            {
                case ErecruitHelper.BGSR.ALL:

                    var cands = new List<object> { new {ID="ALL", Name = "ALL" } };
                    GroupContentList.DataSource = cands;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGSR.BATCHES:
                    var cands1 = _db.T_Batch.OrderBy(x => x.Name).Select(a => new
                    {
                        ID = a.Id,
                        Name = a.Name.ToUpper()
                    }).ToList();
                    GroupContentList.DataSource = cands1;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.BRANCH:
                    var candsx = _db.branch_tab.OrderBy(x =>x.branch_name).Select(a => new
                    {
                        ID = a.id,
                        Name = a.branch_name
                    }).ToList();
                    GroupContentList.DataSource = candsx;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIVISION:

                    var cands2 = _db.division_tab.OrderBy(x => x.DIV_NAME).Select(a => new
                    {
                        ID = a.DIV_CODE,
                        Name = a.DIV_NAME
                    }).ToList();
                    GroupContentList.DataSource = cands2;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.GRADE:

                    var cands3 = _db.grade_tab.OrderBy(x => x.GRADE_LEVEL).Select(a => new
                    {
                        ID = a.GRADE_CODE,
                        Name = a.GRADE_LEVEL
                    }).ToList();
                    GroupContentList.DataSource = cands3;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.BANK:

                    var cands4 = _db.region_tab.OrderBy(x => x.region_name).Select(a => new
                    {
                        ID = a.region_code,
                        Name = a.region_name
                    }).ToList();
                    GroupContentList.DataSource = cands4;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIRECTORATE:
                    //Clear Existing

                    var cands5 = _db.sector_tab.OrderBy(x => x.SECTOR_NAME).Select(a => new
                    {
                        ID = a.SECTOR_CODE,
                        Name = a.SECTOR_NAME
                    }).ToList();
                    GroupContentList.DataSource = cands5;
                    GroupContentList.DataBind();

                    break;
            }


        }
    }
}