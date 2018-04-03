using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using QuizBook.Helpers;
using QuizBook.Model;
using System.IO;

namespace QuizBook.Views
{
    public partial class CandidateSearch : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();

        protected void Page_Load(object sender, EventArgs e)

        {
            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanWorkWithCandidates||PermMgr.CanApprove)
            {

            if (!IsPostBack)
            {
                var quests = _db.Candidates.Select(a => new CandidateGridModel
                {
                    ID = a.Id,
                    TenantId = a.TenantId ?? 0,
                    Username = a.Username,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Sex = a.Sex,
                    DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                    Status = a.Status ?? "-",
                    Email = a.Email,
                    D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                    DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                });
                TotalRecCount.Text = quests.Count() + " Candidate(s)";
                CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                CandidateList.DataBind();

            
            }
            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }
        }

        [WebMethod]
        public static string SwitchCandidateActivity(string id)
        {
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var opt = _db.Candidates.Where(s => s.Id == long.Parse(id)).FirstOrDefault();
                if (opt != null)
                {
                    if (opt.Status == ErecruitHelper.CStatus.Active.ToString())
                    {
                        opt.Status = ErecruitHelper.CStatus.Inactive.ToString();

                    }
                    else
                    {
                        opt.Status = ErecruitHelper.CStatus.Active.ToString();
                    }

                    _db.SaveChanges();
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        protected void lnkeditV_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDV");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                Response.Redirect("CandidateView.aspx?z=" + idcr, false);
            }
        }

        protected void CandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var name = Name.Text;
            var degree = Degree.Value;
            var c = cond.Value;
            var course = Course.Text;
            var DegreeClass = ClassOfDegree.Value;
            var referal = Referal.Text;
            var age = Age.Text;

            IQueryable<QuizBook.Candidate> cands;

            if (!string.IsNullOrEmpty(name))
            {
                cands = _db.Candidates.Where(s => (s.FirstName.Contains(name) || s.LastName.Contains(name)));
            }
            else
            {
                cands = _db.Candidates.AsQueryable();
            }
            

            var quests = cands.Select(a => new CandidateGridModel
            {
                ID = a.Id,
                TenantId = a.TenantId ?? 0,
                Username = a.Username,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Sex = a.Sex,
                DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                Status = a.Status ?? "-",
                Email = a.Email,
                D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
            });
            CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
            CandidateList.PageIndex = e.NewPageIndex;
            CandidateList.DataBind();
        }

        protected void lnkeditC_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDC");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                Session["UserToEdit"] = idcr;
                Response.Redirect("Candidate.aspx");
            }
            
        }

        protected void CandidateList_Sorting(object sender, GridViewSortEventArgs e)
        {
            var name = Name.Text;
            var degree = Degree.Value;
            var c = cond.Value;
            var course = Course.Text;
            var DegreeClass = ClassOfDegree.Value;
            var referal = Referal.Text;
            var age = Age.Text;
            var cCode = code.Text;

            IQueryable<QuizBook.Candidate> cands;

            if (!string.IsNullOrEmpty(name))
            {
                cands = _db.Candidates.Where(s => (s.FirstName.Contains(name) || s.LastName.Contains(name) ));
            }
            else
            {
                cands = _db.Candidates.AsQueryable();
            }

           

            var quests = cands.Select(a => new CandidateGridModel
            {
                ID = a.Id,
                TenantId = a.TenantId ?? 0,
                Username = a.Username,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Sex = a.Sex,
                DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                Status = a.Status ?? "-",
                Email = a.Email,
                D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
            }).Distinct().ToList();

            quests = quests.OrderByDescending(x => x.ID).ToList();

            if ((string)Session["EXP"] == e.SortExpression && (string)Session["DIRECTION"] == SortDirection.Ascending.ToString())
            {
                e.SortDirection = SortDirection.Descending;
            }
            else
            {
                e.SortDirection = SortDirection.Ascending;
            }

            Session["EXP"] = e.SortExpression;
            Session["DIRECTION"] = e.SortDirection.ToString();
            switch (e.SortExpression)
            {
                case "Code":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.Username).ToList();

                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.Username).ToList();
                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }

                    break;

                case "FirstName":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.FirstName).ToList();

                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.FirstName).ToList(); 
                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }

                    break;
                case "LastName":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.LastName).ToList();

                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.LastName).ToList(); 
                        CandidateList.DataSource = quests;
                        CandidateList.DataBind();
                    }

                    break;
              

            }

        }

        protected void SearchCandidate_Click(object sender, EventArgs e)
        {
            try{
            var name = Name.Text;
            var degree = Degree.Value;
            var c = cond.Value;
            var course = Course.Text;
            var DegreeClass = ClassOfDegree.Value;
            var referal = Referal.Text;
            var age = Age.Text;

            IQueryable<QuizBook.Candidate> cands ;

            if (!string.IsNullOrEmpty(name))
            {
                cands = _db.Candidates.Where(s => (s.FirstName.Contains(name) || s.LastName.Contains(name)));
            }
            else
            {
                cands = _db.Candidates.AsQueryable();
            }
            

            var quests = cands.Select(a => new CandidateGridModel
            {
                ID = a.Id,
                TenantId = a.TenantId ?? 0,
                Username = a.Username,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Sex = a.Sex,
                DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                Status = a.Status ?? "-",
                Email = a.Email,
                D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
            }).Distinct().ToList();
            TotalRecCount.Text = quests.Count() + " Candidate(s)";
            CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
            CandidateList.DataBind();

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }

        }

        protected void lnkeditCS_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDCS");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                var opt = _db.T_Candidate.Where(s => s.Id == idcr).FirstOrDefault();
                if (opt.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString())
                {
                if (opt != null)
                {
                    if (opt.IsActive.Value)
                    {
                        opt.IsActive = false;
                    }
                    else
                    {
                        opt.IsActive = true;
                    }

                    _db.SaveChanges();

                    var quests = _db.Candidates.Select(a => new CandidateGridModel
                    {
                        ID = a.Id,
                        TenantId = a.TenantId ?? 0,
                        Username = a.Username,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Sex = a.Sex,
                        DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                        Status = a.Status ?? "-",
                        Email = a.Email,
                        D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                        DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                    }).Distinct().ToList();
                    TotalRecCount.Text = quests.Count() + " Candidate(s)";
                    CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                    CandidateList.DataBind();
                   
                }
                    resultLbl.Text = "";
                }
                else
                {
                    resultLbl.Text = "The candidate has to be approved first";
                }
            }
        }

        protected void lnkeditApp_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDApp");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                var opt = _db.Candidates.FirstOrDefault(s => s.Id == idcr);
                if (opt != null)
                {
                    //if (opt.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString())
                    //{
                    //    opt.ApprovalStatus = ErecruitHelper.ApprovalStatus.NOT_APPROVED.ToString();
                    //    opt.IsActive = false;
                    //    opt.ApprovedBy = SessionHelper.FetchEmail(Session);
                    //}
                    //else
                    //{
                    //    opt.ApprovalStatus = ErecruitHelper.ApprovalStatus.APPROVED.ToString();
                    //    opt.IsActive = true;
                    //    opt.ApprovedBy = SessionHelper.FetchEmail(Session);
                    //}

                    //_db.SaveChanges();
                    var quests = _db.Candidates.Select(a => new CandidateGridModel
                    {
                        ID = a.Id,
                        TenantId = a.TenantId ?? 0,
                        Username = a.Username,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Sex = a.Sex,
                        DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                        Status = a.Status ?? "-",
                        Email = a.Email,
                        D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                        DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                    });
                    CandidateList.DataSource = quests.OrderByDescending(x => x.DateRegistered).ToList();

                    CandidateList.DataBind();
                    resultLbl.Text = "";
                }
            }
        }

        protected void CandidateList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //var PermMgr = new PermissionManager(Session);
            //if (!PermMgr.CanApprove)
            //{
            //    CandidateList.Columns[16].Visible = false; // Hide column
            //}
            //if (!PermMgr.CanWorkWithCandidates)
            //{
            //    CandidateList.Columns[15].Visible = false; // Hide column
            //}
            var PermMgr = new PermissionManager(Session);
            if (!PermMgr.CanApprove)
            {
                CandidateList.Columns[17].Visible = false; // Hide column
            }
            if (!PermMgr.CanWorkWithCandidates)
            {
                CandidateList.Columns[15].Visible = false; // Hide column
            }
        }


    }
}