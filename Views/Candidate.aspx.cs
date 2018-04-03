using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Model;
using System.IO;
using QuizBook.Helpers;
using System.Web.Services;
using Erecruit.Models;
using System.Web.Script.Serialization;

namespace QuizBook.Views
{
    public partial class Candidate : System.Web.UI.Page
    {
        // QuizBookDbEntities1 _db = new QuizBookDbEntities1();
         string keySalt = "QuizBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);
            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var permissions = ErecruitHelper.GetAdminUserPermissions(Session);
                    if (!permissions._CanWorkWithCandidates)
                    {
                        Response.Redirect("NoPermission.aspx", false);
                    }


                    //    var data = _db.T_Candidate.OrderBy(x => x.DateRegistered).Select(a => new CandidateGridModel
                    //        {
                    //            ID = a.Id,
                    //            Code = a.Code,
                    //            FirstName = a.FirstName,
                    //            LastName = a.LastName,
                    //            StaffID = a.Code,
                    //            Branch = ErecruitHelper.getBranchName(a.Branch),
                    //            Grade = ErecruitHelper.getGradeName(a.Grade),
                    //            Region = ErecruitHelper.getRegionName(a.Region),
                    //            Sector = ErecruitHelper.getSectorName(a.Sector),
                    //            Division = ErecruitHelper.getDivisionName(a.Division),
                    //            Active = a.IsActive.Value ? "Yes" : "No",
                    //            ApprovalStatus = a.ApprovalStatus,
                    //            ApprovalLink = a.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString() ? "Dispprove" : "Approve",
                    //            D = a.IsActive.Value ? "Deactivate" : "Activate",
                    //            DateRegistered = (DateTime)a.DateRegistered

                    //        }).Distinct().ToList();


                    //   // var pagedData = data.Skip(int.Parse(Request.QueryString["iDisplayStart"])).Take(int.Parse(Request.QueryString["iDisplayLength"]));
                    //    System.Web.Script.Serialization.JavaScriptSerializer toJSON = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //    Response.Clear();
                    //    string dataString = toJSON.Serialize(new
                    //    {
                    //        sEcho = Request.QueryString["sEcho"],
                    //        iTotalRecords = data.Count(),
                    //        iTotalDisplayRecords = data.Count(),
                    //        aaData = data
                    //    });
                    //    Response.Write(dataString);
                    //   // Response.End();
                    //}
                    //else
                    //{

                    //}



                    //if (PermMgr.IsAdmin || PermMgr.CanWorkWithCandidates)
                    //{
                    //    CandidateDetailsPane.Visible = true;
                    //     if ((Session["UserToEdit"]) != null)
                    //     {
                    //         var idcr = long.Parse(Session["UserToEdit"].ToString());
                    //         if (!(idcr == null))
                    //         {
                    //             var c = _db.T_Candidate.FirstOrDefault(s => s.Id == idcr);
                    //             string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                    //             Image1.ImageUrl = !(string.IsNullOrEmpty(c.Passport)) ? c.Passport : path;
                    //             C_Id.Value = c.Id.ToString();
                    //             FN.Text = c.FirstName;
                    //             LN.Text = c.LastName;
                    //             MaN.Text = c.MaidenName;
                    //             MN.Text = c.MiddleName;
                    //             Sex.Value = c.Sex;
                    //             Degree.Value = c.Degree;
                    //             ClassOfDegree.Value = c.ClassOfDegree;
                    //             DateTime dateofbirth = c.DateOfBirth.Value;
                    //             if (dateofbirth != null)
                    //             {
                    //                 DoB.Text = ErecruitHelper.AppendZero(dateofbirth.Day) + "/" + ErecruitHelper.AppendZero(dateofbirth.Month) + "/" + ErecruitHelper.AppendZero(dateofbirth.Year);
                    //             }
                    //             Course.Text = c.Course;
                    //             Referal.Text = c.Referer;
                    //             Email.Text = c.Email;
                    //         }
                    //         Image1.DataBind();
                    //         Image1.Visible = true;
                    //         Session["UserToEdit"] = null;
                    //     }

                    //}
                    //else
                    //{
                    //    CandidateDetailsPane.Visible = false;
                    //}
                    //else
                    //{
                    //    Response.Redirect("NoPermission.aspx", false);
                    //}
                    if (!IsPostBack)
                    {
                        if (PermMgr.IsAdmin || PermMgr.CanWorkWithCandidates || PermMgr.CanApprove)
                        {

                            if (!IsPostBack)
                            {
                                //var staffid = SessionHelper.FetchStaffId(Page.Session);
                                //var c = _db.T_Candidate.FirstOrDefault(s => s.Code == staffid);
                                //if (c != null)
                                //{
                                //    Response.Redirect("TestLanding.aspx", false);
                                //}
                                //else
                                //{
                                //staff_id.Text = SessionHelper.FetchStaffId(Page.Session);
                                //surname.Text = SessionHelper.FetchLastName(Page.Session);
                                //othername.Text = SessionHelper.FetchFirstName(Page.Session);
                                //email.Text = SessionHelper.FetchEmail(Page.Session);

                                //var g = _db.grade_tab.Select(a => new
                                //{
                                //    Id = a.GRADE_CODE.Trim(),
                                //    Name = a.GRADE_LEVEL.Trim()

                                //}).Distinct().OrderBy(s => s.Name).ToList();
                                //g.Insert(0, new { Id = "-1", Name = "--Select Your Grade--" });
                                //grades.DataSource = g;
                                //grades.DataBind();

                                //var d = _db.division_tab.Select(a => new
                                //{
                                //    Id = a.DIV_CODE.Trim(),
                                //    Name = a.DIV_NAME.Trim()

                                //}).Distinct().OrderBy(s => s.Name).ToList();
                                //d.Insert(0, new { Id = "-1", Name = "--Select Your Division--" });
                                //divisions.DataSource = d;
                                //divisions.DataBind();

                                //var b = _db.branch_tab.Select(a => new
                                //{
                                //    Id = a.id,
                                //    Name = a.branch_name.Trim().ToUpper()

                                //}).Distinct().OrderBy(s => s.Name).ToList();
                                //b.Insert(0, new { Id = -1, Name = "--Select Your Branch--" });

                                //var solid = SessionHelper.FetchBranchId(Page.Session);

                                //branches.DataSource = b;
                                //branches.DataBind();

                                //var sec = _db.sector_tab.Select(a => new
                                //{
                                //    Id = a.SECTOR_CODE.Trim(),
                                //    Name = a.SECTOR_NAME.Trim()

                                //}).Distinct().OrderBy(s => s.Name).ToList();
                                //sec.Insert(0, new { Id = "-1", Name = "Select Your Directorate" });
                                //Sector.DataSource = sec;
                                //Sector.DataBind();

                                //var reg = _db.region_tab.Select(a => new
                                //{
                                //    Id = a.region_code.ToString().Trim(),
                                //    Name = a.region_name.Trim()

                                //}).Distinct().OrderBy(s => s.Name).ToList();
                                //reg.Insert(0, new { Id = "-1", Name = "--Select Your Bank--" });
                                //Region.DataSource = reg;
                                //Region.DataBind();
                            }
                        }
                        var userId = SessionHelper.FetchUserId(Session);
                        var user = _db.AdminUsers.FirstOrDefault(s => s.Id == userId);
                        if (user.Supervisor ?? false)
                        {


                            var rl = _db.Roles.FirstOrDefault(s => s.Description == "Admin");
                            var roles = _db.Roles.AsEnumerable().Where(x => x.Active && x.TenantId.HasValue && x.TenantId == long.Parse(SessionHelper.GetTenantID(Session)));

                            if (user.Role.HasValue && user.Role.Value != rl.Id)
                            {
                                roles = roles.Where(x => x.Id == user.Role.Value || x.CreatedBy == user.Id.ToString());
                            }
                            var rls = roles.OrderBy(s => s.Description).Select(a => new
                            {
                                Id = a.Id,
                                Name = a.Description

                            }).ToList();

                            rls.Insert(0, new { Id = long.Parse("-1"), Name = "--Class--" });
                            
                            RoleList.DataSource = rls;
                           
                            RoleList.DataBind();
                        }
                        else
                        {
                            RoleList.Visible = false;
                        }
                        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                        }).ToList();

                        TotalRecCount.Text = quests.Count() + " Candidate(s)";

                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                        CandidateList.DataBind();

                    }
                    // }

                    if (PermMgr.IsAdmin || PermMgr.CanWorkWithCandidates)
                    {
                        CandidateDetailsPane.Visible = true;
                    }
                    else
                    {
                        CandidateDetailsPane.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }


        [WebMethod]
        public static string SwitchCandidateActivity(string id)
        {
           // QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {

                    var opt = _db.Candidates.FirstOrDefault(s => s.Id == long.Parse(id));
                    if (opt != null)
                    {
                        if (!string.IsNullOrEmpty(opt.Status) && opt.Status == ErecruitHelper.CStatus.Active.ToString())
                        {
                            opt.Status = ErecruitHelper.CStatus.Active.ToString();
                        }
                        else
                        {
                            opt.Status = ErecruitHelper.CStatus.Inactive.ToString();
                        }

                        _db.SaveChanges();
                        return "success";
                    }
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{

        //    try
        //    {

        //         var FirstName = FN.Text;
        //            var LastName = LN.Text;
        //            var MiddleName = MN.Text;
        //            var MaidenName = MaN.Text;
        //            var D1 = Degree.Value;
        //            var S1 = Sex.Value;
        //            var DOfB = DoB.Text;
        //            var course = Course.Text;
        //            var DegreeClass = ClassOfDegree.Value;
        //            var referal = Referal.Text;
        //            var email = Email.Text;
        //            var PPath = "";
        //            var ApprovalStatus = ErecruitHelper.ApprovalStatus.NOT_APPROVED.ToString() ;

        //            HttpPostedFile file = Passport.PostedFile;

        //        var cid = C_Id.Value;
        //        if (!string.IsNullOrEmpty(cid))
        //        {
        //            //Do Edit
        //            var cand = _db.T_Candidate.FirstOrDefault(s => s.Id == long.Parse(cid));
        //            cand.FirstName = FirstName;
        //            cand.LastName = LastName;
        //            cand.MiddleName = MiddleName;
        //            cand.MaidenName = MaidenName;
        //            cand.Degree = D1;
        //            cand.Sex = S1;
        //            cand.DateOfBirth = ErecruitHelper.GetCurrentDateFromDateString(DOfB);
        //            cand.Course = course;
        //            cand.ClassOfDegree = DegreeClass;
        //            cand.Referer = referal;
        //            cand.Email = email;
        //              //check file was submitted
        //            if (file != null && file.ContentLength > 0)
        //            {
        //                string fname = Path.GetFileName(file.FileName);
        //                string ext = System.IO.Path.GetExtension(file.FileName);
        //                cand.Age = DateTime.Now.Year - cand.DateOfBirth.Value.Year;
        //                if (Directory.Exists(Server.MapPath("~/Passports/")))
        //                {
        //                    string path = Server.MapPath(Path.Combine("~/Passports/", cand.Code + ext));
        //                    PPath = Path.Combine("~/Passports/", cand.Code + ext);
        //                    cand.Passport = PPath;
        //                    file.SaveAs(path);
        //                }
        //                else
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Passports/"));
        //                    string path = Server.MapPath(Path.Combine("~/Passports/", cand.Code + ext));
        //                    PPath = Path.Combine("~/Passports/", cand.Code + ext);
        //                    cand.Passport = PPath;
        //                    file.SaveAs(path);
        //                }

        //            }
        //            else
        //            {
        //                cand.Age = DateTime.Now.Year - cand.DateOfBirth.Value.Year;
        //            }
        //            cand.IsActive = false;
        //            cand.ApprovalStatus = ErecruitHelper.ApprovalStatus.NOT_APPROVED.ToString();
        //            _db.SaveChanges();
        //            Response.Redirect("Candidate.aspx",false);
        //        }
        //        else
        //        {


        //            var candidateCount = _db.T_Candidate.Count() + 1;

        //            var candidate = new T_Candidate
        //            {
        //                FirstName = FirstName,
        //                LastName = LastName,
        //                MiddleName = MiddleName,
        //                MaidenName = MaidenName,
        //                Degree = D1,
        //                Sex = S1,
        //                DateOfBirth = ErecruitHelper.GetCurrentDateFromDateString(DOfB),
        //                Course = course,
        //                ClassOfDegree = DegreeClass,
        //                Referer = referal,
        //                Email = email,
        //                ApprovalStatus = ApprovalStatus,
        //                IsActive = false
        //            };

        //            //check file was submitted
        //            if (file != null && file.ContentLength > 0)
        //            {

        //                string fname = Path.GetFileName(file.FileName);
        //                string ext = System.IO.Path.GetExtension(file.FileName);


        //                if (Directory.Exists(Server.MapPath("~/Passports/")))
        //                {
        //                    candidate.Age = DateTime.Now.Year - candidate.DateOfBirth.Value.Year;
        //                    candidate.Code = ErecruitHelper.GenerateCandidateCode(candidateCount);
        //                    string path = Server.MapPath(Path.Combine("~/Passports/", candidate.Code + ext));
        //                    PPath = Path.Combine("~/Passports/", candidate.Code + ext);
        //                    candidate.Passport = PPath;
        //                    candidate.RegisterBy = SessionHelper.FetchEmail(Session);
        //                    candidate.DateRegistered = DateTime.Now;
        //                    _db.T_Candidate.Add(candidate);
        //                    _db.SaveChanges();
        //                    file.SaveAs(path);
        //                }
        //                else
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Passports/"));
        //                    candidate.Age = DateTime.Now.Year - candidate.DateOfBirth.Value.Year;
        //                    candidate.Code = ErecruitHelper.GenerateCandidateCode(candidateCount);
        //                    string path = Server.MapPath(Path.Combine("~/Passports/", candidate.Code + ext));
        //                    PPath = Path.Combine("~/Passports/", candidate.Code + ext);
        //                    candidate.Passport = PPath;
        //                    candidate.RegisterBy = SessionHelper.FetchEmail(Session);
        //                    candidate.DateRegistered = DateTime.Now;
        //                    _db.T_Candidate.Add(candidate);
        //                    _db.SaveChanges();
        //                    file.SaveAs(path);
        //                }

        //            }
        //            else
        //            {
        //                candidate.Age = candidate.DateOfBirth.Value.Year - DateTime.Now.Year;
        //                candidate.Code = ErecruitHelper.GenerateCandidateCode(candidateCount);
        //                candidate.RegisterBy = SessionHelper.FetchEmail(Session);
        //                candidate.DateRegistered = DateTime.Now;
        //                _db.T_Candidate.Add(candidate);
        //                _db.SaveChanges();
        //            }
        //            Response.Redirect("Candidate.aspx",false);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErecruitHelper.SetErrorData(ex, Session);
        //        Response.Redirect("ErrorPage.aspx", false);
        //    }
        //}

        protected void lnkeditC_Click(object sender, EventArgs e)
        {
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                LinkButton lnkedit = ((LinkButton)sender);
                var p = lnkedit.Parent;
                HiddenField hdfID = (HiddenField)p.FindControl("hdfIDC");
                var idcr = long.Parse(hdfID.Value);
                if (!(idcr == null))
                {
                    var c = _db.Candidates.FirstOrDefault(s => s.Id == idcr);

                    fname.Text = c.FirstName;
                    lname.Text = c.LastName;
                    email.Text = c.Email;
                    Address.Text = c.Address;
                    username.Text = c.Username;
                    InitUsername.Value = c.Username;
                    dob.Text = c.DOB == null ? string.Empty : c.DOB.Value.ToString("dd/MM/yyyy");
                    country.Attributes.Add("data-default-value", c.Country);
                    state.Attributes.Add("data-default-value", c.State);
                    sex.SelectedValue = c.Sex;
                    //objID.Value = c.Id.ToString();
                    //staffIdtxt.Text = c.Code;
                    //Surnametxt.Text = c.LastName;
                    //OtherNamestxt.Text = c.FirstName;
                    //emailtxt.Text   =c.Email;

                    //var g = _db.grade_tab.Select(a => new
                    //{
                    //    Id = a.GRADE_CODE.Trim(),
                    //    Name = a.GRADE_LEVEL.Trim()

                    //}).Distinct().OrderBy(s => s.Name).ToList();
                    //g.Insert(0, new { Id = "-1", Name = "--Select Your Grade--" });
                    //grades.DataSource = g;
                    //grades.DataBind();
                    //grades.SelectedValue = string.IsNullOrEmpty(c.Grade) ? "-1" : c.Grade.Trim();

                    //var d = _db.division_tab.Select(a => new
                    //{
                    //    Id = a.DIV_CODE.Trim(),
                    //    Name = a.DIV_NAME.Trim()

                    //}).Distinct().OrderBy(s => s.Name).ToList();
                    //d.Insert(0, new { Id = "-1", Name = "--Select Your Division--" });
                    //divisions.DataSource = d;
                    //divisions.DataBind();
                    //divisions.SelectedValue = string.IsNullOrEmpty(c.Division) ? "-1" : c.Division.Trim();


                    //var b = _db.branch_tab.Select(a => new
                    //{
                    //    Id = a.id,
                    //    Name = a.branch_name.Trim().ToUpper()

                    //}).Distinct().OrderBy(s => s.Name).ToList();
                    //b.Insert(0, new { Id = -1, Name = "--Select Your Branch--" });
                    //branches.DataSource = b;
                    //branches.DataBind();
                    //branches.SelectedValue = c.Branch !=null?_db.branch_tab.FirstOrDefault(s => s.id == c.Branch.Value).id.ToString():"-1";

                    //var sec = _db.sector_tab.Select(a => new
                    //{
                    //    Id = a.SECTOR_CODE.Trim(),
                    //    Name = a.SECTOR_NAME.Trim()

                    //}).Distinct().OrderBy(s => s.Name).ToList();
                    //sec.Insert(0, new { Id = "-1", Name = "--Select Your Directorate--" });
                    //Sector.DataSource = sec;
                    //Sector.DataBind();
                    //Sector.SelectedValue = string.IsNullOrEmpty(c.Sector) ? "-1":c.Sector.Trim();

                    //var reg = _db.region_tab.Select(a => new
                    //{
                    //    Id = a.region_code.ToString().Trim(),
                    //    Name = a.region_name.Trim()

                    //}).Distinct().OrderBy(s => s.Name).ToList();
                    //reg.Insert(0, new { Id = "-1", Name = "--Select Your Bank--" });
                    //Region.DataSource = reg;
                    //Region.DataBind();
                    //Region.SelectedValue = c.Region != null ? _db.region_tab.FirstOrDefault(s => s.region_code == c.Region.Value).region_code.ToString() : "-1";

                    //string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                    //Image1.ImageUrl = !(string.IsNullOrEmpty(c.Passport)) ? c.Passport : path;
                    //C_Id.Value = c.Id.ToString();
                    //FN.Text = c.FirstName;
                    //LN.Text = c.LastName;
                    //MaN.Text = c.MaidenName;
                    //MN.Text = c.MiddleName;
                    //Sex.Value = c.Sex;
                    //Degree.Value = c.Degree;
                    //ClassOfDegree.Value = c.ClassOfDegree;
                    //DateTime dateofbirth = c.DateOfBirth.Value;
                    //if (dateofbirth != null)
                    //{
                    //    DoB.Text = ErecruitHelper.AppendZero(dateofbirth.Day) + "/" + ErecruitHelper.AppendZero(dateofbirth.Month) + "/" + ErecruitHelper.AppendZero(dateofbirth.Year);
                    //}
                    //Course.Text = c.Course;
                    //Referal.Text = c.Referer;
                    //Email.Text = c.Email;
                }
                //Image1.DataBind();
                //Image1.Visible = true;
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

        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate.aspx");
        }

        protected void CandidateList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var stext = searchText.Text;
                    stext = "%" + stext.ToLower() + "%";
                    if (string.IsNullOrEmpty(stext))
                    {

                        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                        }).ToList();
                        TotalRecCount.Text = quests.Count() + " Candidate(s)";
                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                        CandidateList.PageIndex = e.NewPageIndex;
                        CandidateList.DataBind();
                    }
                    else
                    {
                        var q = _db.SearchTenantCandidate(long.Parse(SessionHelper.GetTenantID(Session)), stext);
                        var quests = q.Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")

                        }).Distinct().ToList();
                        TotalRecCount.Text = quests.Count() + " Candidate(s)";
                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                        CandidateList.PageIndex = e.NewPageIndex;
                        CandidateList.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void CandidateList_Sorting(object sender, GridViewSortEventArgs e)
        {
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                    D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                    DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                }).ToList();
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

                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }
                        else
                        {
                            quests = quests.OrderByDescending(s => s.Username).ToList();
                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }

                        break;
                    case "FirstName":
                        if (e.SortDirection == SortDirection.Ascending)
                        {
                            quests = quests.OrderBy(s => s.FirstName).ToList();

                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }
                        else
                        {
                            quests = quests.OrderByDescending(s => s.FirstName).ToList();
                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }

                        break;
                    case "LastName":
                        if (e.SortDirection == SortDirection.Ascending)
                        {
                            quests = quests.OrderBy(s => s.LastName).ToList();

                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }
                        else
                        {
                            quests = quests.OrderByDescending(s => s.LastName).ToList();
                            //CandidateList.DataSource = quests;
                            //CandidateList.DataBind();
                        }

                        break;


                }
                TotalRecCount.Text = quests.Count() + " Candidate(s)";
                CandidateList.DataSource = quests;
                CandidateList.DataBind();
            }
        }

        protected void lnkeditCa_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDCa");
            var idcr = long.Parse(hdfID.Value);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                if (!(idcr == null))
                {
                    var opt = _db.Candidates.FirstOrDefault(s => s.Id == idcr);

                    //if (opt.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString())
                    //{

                        if (opt != null)
                        {
                            if (!string.IsNullOrEmpty(opt.Status) && opt.Status.Trim() ==  ErecruitHelper.CStatus.Active.ToString())
                            {
                                opt.Status = ErecruitHelper.CStatus.Inactive.ToString();

                            }
                            else
                            {
                                opt.Status = ErecruitHelper.CStatus.Active.ToString();
                            }

                            _db.SaveChanges();
                            var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                                D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                                DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                            }).ToList();
                            TotalRecCount.Text = quests.Count() + " Candidate(s)";
                            CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                            CandidateList.DataBind();
                            //CandidateList.DataSource = quests.OrderByDescending(x => x.DateRegistered).OrderByDescending(s => s.Active).ToList();

                            //CandidateList.DataBind();

                        }
                        alertLbl.Text = "";
                    //}
                    //else
                    //{
                    //    alertLbl.Text = "The candidate has to be approved first";
                    //}
                }
            }
        }

        protected void lnkeditApp_Click(object sender, EventArgs e)
        {
             LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDApp");
            var idcr = long.Parse(hdfID.Value);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                if (!(idcr == null))
                {
                    var opt = _db.Candidates.FirstOrDefault(s => s.Id == idcr);
                    if (opt != null)
                    {
                        //if (opt.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString())
                        //{
                        //    //opt.ApprovalStatus = ErecruitHelper.ApprovalStatus.NOT_APPROVED.ToString();
                        //    opt.Status = ErecruitHelper.CStatus.Inactive.ToString();
                        //    //opt.ApprovedBy = SessionHelper.FetchEmail(Session);
                        //}
                        //else
                        //{
                        //    opt.ApprovalStatus = ErecruitHelper.ApprovalStatus.APPROVED.ToString();
                        //    opt.IsActive = true;
                        //    opt.ApprovedBy = SessionHelper.FetchEmail(Session);
                        //}

                        _db.SaveChanges();
                        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                        }).ToList();
                        TotalRecCount.Text = quests.Count() + " Candidate(s)";
                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                        CandidateList.DataBind();
                        //CandidateList.DataSource = quests.OrderByDescending(x => x.DateRegistered).OrderByDescending(s => s.Active).ToList();

                        //CandidateList.DataBind();
                        alertLbl.Text = "";
                    }
                }
            }
        }

        protected void CandidateList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var PermMgr = new PermissionManager(Session);
            if (!PermMgr.CanApprove)
            {
               // CandidateList.Columns[17].Visible = false; // Hide column
            }
            if (!PermMgr.CanWorkWithCandidates)
            {
              //  CandidateList.Columns[15].Visible = false; // Hide column
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    long? n = null;
                    var staffid = InitUsername.Value;
                    var c = _db.Candidates.FirstOrDefault(s => s.Username == staffid);

                    var fn = fname.Text;
                    var ln = lname.Text;
                    var address = Address.Text;
                    var emailvar = email.Text;
                    var sx = sex.SelectedItem.Value;
                    var dateOb = dob.Text;
                    var un = Request[username.UniqueID].ToString();
                    var ste = Request[state.UniqueID].ToString();
                    var ctry = Request[country.UniqueID].ToString();
                    var lctn = Request[Location.UniqueID].ToString();
                    var role = RoleList.Visible?RoleList.SelectedValue:null;

                    if (c != null)
                    {
                        //Update

                        c.FirstName = fn;
                        c.LastName = ln;
                        c.Username = un;
                        c.Sex = sx;
                        c.DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb);
                        c.Address = Address.Text;
                        c.State = Request[state.UniqueID].ToString();
                        c.Country = Request[country.UniqueID].ToString();
                        c.Location = Request[Location.UniqueID].ToString();
                        c.Email = emailvar;
                        c.TenantId = SessionHelper.GetTenantID(Session) != null ? long.Parse(SessionHelper.GetTenantID(Session)) : (long?)null;
                        c.Status = ErecruitHelper.CStatus.Active.ToString();
                        c.DateModified = DateTime.Now;
                        c.ModifiedBy = SessionHelper.FetchUserName(Session);
                        c.Class = role == null ? c.Class : long.Parse(role);
                        c.DateAssignedToClass = DateTime.Now;
                        c.Captcha = true;
                        c.IpAddress = ErecruitHelper.GetIP(HttpContext.Current);

                        _db.SaveChanges();
                        Response.Redirect("Candidate.aspx", false);
                    }
                    else
                    {
                        // create new

                        var pw = Guid.NewGuid().ToString();
                        var phrase = pw.Split('-')[0];
                        var rl = _db.Roles.FirstOrDefault(s => s.Description == "Candidate");

                        var cand = new QuizBook.Candidate
                        {
                            FirstName = fn,
                            LastName = ln,
                            Username = un,
                            Sex = sx,
                            DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb),
                            Address = Address.Text,
                            State = Request[state.UniqueID].ToString(),
                            Country = Request[country.UniqueID].ToString(),
                            Location = Request[Location.UniqueID].ToString(),
                            Email = emailvar,
                            TenantId = SessionHelper.GetTenantID(Session) != null ? long.Parse(SessionHelper.GetTenantID(Session)) : (long?)null,
                            Role = rl.Id,
                            Status = ErecruitHelper.CStatus.Active.ToString(),
                            DateCreated = DateTime.Now,
                            CreatedBy = SessionHelper.FetchUserName(Session),
                            Class =  role == null ? n : long.Parse(role),
                            DateAssignedToClass = DateTime.Now,
                            Captcha = true,
                            DefaultLoginKeyChanged = false,
                            LogInKey = ErecruitHelper.getHash(phrase.Trim(), keySalt.Trim()),
                            IpAddress = ErecruitHelper.GetIP(HttpContext.Current)
                        };
                        _db.Candidates.Add(cand);
                        _db.SaveChanges();
                        ErecruitHelper.sendProfile(cand, "", phrase);
                        Response.Redirect("Candidate.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void cancel2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Candidate.aspx",false);
        }

        protected void SearchQuest_Click(object sender, EventArgs e)
        {
            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var stext = searchText.Text;
                    if (string.IsNullOrEmpty(stext))
                    {
                        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                        }).ToList();
                        TotalRecCount.Text = quests.Count() + " Candidate(s)";
                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();

                        CandidateList.DataBind();
                    }
                    else
                    {
                        stext = "%" + stext.ToLower() + "%";
                        var q = _db.SearchTenantCandidate(long.Parse(SessionHelper.GetTenantID(Session)), stext);
                        var quests = q.Select(a => new CandidateGridModel
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
                            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
                        });
                        TotalRecCount.Text = quests.Count() + " Candidate(s)";
                        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                        CandidateList.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        //protected void AA_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        _db.ApproveAll_sp(SessionHelper.FetchEmail(Page.Session));
        //        alertLbl.Text = "All Candidates Approved and Active";

        //        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
        //        {
        //            ID = a.Id,
        //            TenantId = a.TenantId ?? 0,
        //            Username = a.Username,
        //            FirstName = a.FirstName,
        //            LastName = a.LastName,
        //            Sex = a.Sex,
        //            DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
        //            Status = a.Status ?? "-",
        //            Email = a.Email,
        //            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
        //            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
        //        }).ToList();
        //        TotalRecCount.Text = quests.Count() + " Candidate(s)";
        //        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
        //        CandidateList.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErecruitHelper.SetErrorData(ex, Session);
        //        Response.Redirect("ErrorPage.aspx", false);
        //    }
        //}

        //protected void DA_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        _db.DisApproveAll_sp(SessionHelper.FetchEmail(Page.Session));
        //        alertLbl.Text = "All Candidates Disapproved and Inactive";
        //        var quests = _db.CandidatesByTenant(long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new CandidateGridModel
        //        {
        //            ID = a.Id,
        //            TenantId = a.TenantId ?? 0,
        //            Username = a.Username,
        //            FirstName = a.FirstName,
        //            LastName = a.LastName,
        //            Sex = a.Sex,
        //            DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
        //            Status = a.Status ?? "-",
        //            Email = a.Email,
        //            D = a.Status.Trim() == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
        //            DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
        //        }).ToList();
        //        TotalRecCount.Text = quests.Count() + " Candidate(s)";
        //        CandidateList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
        //        CandidateList.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErecruitHelper.SetErrorData(ex, Session);
        //        Response.Redirect("ErrorPage.aspx", false);
        //    }
        //}
    }
}