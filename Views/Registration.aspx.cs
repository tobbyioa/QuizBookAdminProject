using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class Registration : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();

        protected void Page_Init(object sender, EventArgs e)
        {
            var ficassws = new FICAAS.FICAAS();
            string authtoken = "";
            string appcode = WebConfigurationManager.AppSettings["AppCode_T"].ToString();
            if (Request.QueryString["token"] != null || SessionHelper.FetchSessionToken(Page.Session) == null)
            {

                //Page.Request.UserHostAddress
                authtoken = Request.QueryString["token"].ToString();
                var ip = ErecruitHelper.GetIP(HttpContext.Current);
                var sessionToken = ficassws.FetchAppSessionToken(authtoken, ip, appcode);
                if (sessionToken != "")
                {
                    SessionHelper.SetSessionToken(sessionToken, Session);
                    var Userdata = ficassws.FetchUserData(sessionToken, ip);
                    if (Userdata != null)
                    {
                        SessionHelper.SetEmail(Userdata.Email, Session);
                        SessionHelper.SetUserId(Userdata.UserId, Session);
                        SessionHelper.SetUserName(Userdata.Username, Session);
                        SessionHelper.SetSol(Userdata.Sol, Session);
                        SessionHelper.SetFirstName(Userdata.FirstName, Session);
                        SessionHelper.SetStaffId(Userdata.StaffId, Session);
                        SessionHelper.SetLastName(Userdata.LastName, Session);
                        SetUserRoleAndPermissions();

                        //CheckIfUserHasProfile(db);
                    }
                }
                else if (SessionHelper.FetchSessionToken(Page.Session) == null)
                {
                    var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
                    Response.Redirect(ficaaslogin);
                }
            }
            else if (SessionHelper.FetchSessionToken(Page.Session) != null)
            {
                return;
            }
            else
            {
                var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
                Response.Redirect(ficaaslogin);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    var staffid = SessionHelper.FetchStaffId(Page.Session);
                    var c = _db.T_Candidate.FirstOrDefault(s => s.Code == staffid);
                    if (c != null)
                    {
                        Response.Redirect("TestLanding.aspx", false);
                    }
                    else
                    {
                        staff_id.Text = SessionHelper.FetchStaffId(Page.Session);
                        surname.Text = SessionHelper.FetchLastName(Page.Session);
                        othername.Text = SessionHelper.FetchFirstName(Page.Session);
                        email.Text = SessionHelper.FetchEmail(Page.Session);

                        var g = _db.grade_tab.Select(a => new
                        {
                            Id = a.GRADE_CODE.Trim(),
                            Name = a.GRADE_LEVEL.Trim()

                        }).Distinct().OrderBy(s => s.Name).ToList();
                        g.Insert(0, new { Id = "-1", Name = "--Select Your Grade--" });
                        grades.DataSource = g;
                        grades.DataBind();

                        var d = _db.division_tab.Select(a => new
                        {
                            Id = a.DIV_CODE.Trim(),
                            Name = a.DIV_NAME.Trim()

                        }).Distinct().OrderBy(s => s.Name).ToList();
                        d.Insert(0, new { Id = "-1", Name = "--Select Your Division--" });
                        divisions.DataSource = d;
                        divisions.DataBind();

                        var b = _db.branch_tab.Select(a => new
                        {
                            Id = a.id,
                            Name = a.branch_name.Trim().ToUpper()

                        }).Distinct().OrderBy(s => s.Name).ToList();
                        b.Insert(0, new { Id = -1, Name = "--Select Your Branch--" });

                        var solid = SessionHelper.FetchBranchId(Page.Session);

                        branches.DataSource = b;
                        branches.DataBind();
                        branches.SelectedValue = _db.branch_tab.FirstOrDefault(s=>s.sol_id == solid).id.ToString();

                        var sec = _db.sector_tab.Select(a => new
                        {
                            Id = a.SECTOR_CODE.Trim(),
                            Name = a.SECTOR_NAME.Trim()

                        }).Distinct().OrderBy(s => s.Name).ToList();
                        sec.Insert(0, new { Id = "-1", Name = "--Select Your Directorate--" });
                        Sector.DataSource = sec;
                        Sector.DataBind();

                        var reg = _db.region_tab.Select(a => new
                        {
                            Id = a.region_code.ToString().Trim(),
                            Name = a.region_name.Trim()

                        }).Distinct().OrderBy(s => s.Name).ToList();
                        reg.Insert(0, new { Id = "-1", Name = "--Select Your Bank--" });
                        Region.DataSource = reg;
                        Region.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("Err.aspx", false);
            }
        
        }

        private void SetUserRoleAndPermissions()
        {          
            var ws = new FICAAS.FICAAS();
            var appcode = WebConfigurationManager.AppSettings["AppCode_T"].ToString();
            var ip = ErecruitHelper.GetIP(HttpContext.Current);
            var roles = ws.FetchUserRoles(SessionHelper.FetchSessionToken(Session), appcode, ip);
            var permissions = ws.FetchUserPermissions(SessionHelper.FetchSessionToken(Session), appcode, ip);
            SessionHelper.SetUserRoles(roles, Session);
            SessionHelper.SetUserPermissions(permissions, Session);
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            try
            {
                var staffid = SessionHelper.FetchStaffId(Page.Session);
                

                var c = _db.T_Candidate.FirstOrDefault(s => s.Code == staffid);
                if (c != null)
                {
                   
                    submit.Text = "Update";

                    var gr = grades.SelectedValue;
                    var br = branches.SelectedValue;
                    var div = divisions.SelectedValue;
                    var sec = Sector.SelectedValue;
                    var reg = Region.SelectedValue;

                }
                else
                {

                    var lastname = SessionHelper.FetchLastName(Page.Session);
                    var othername = SessionHelper.FetchFirstName(Page.Session);
                    var email = SessionHelper.FetchEmail(Page.Session);

                    var gr = grades.SelectedValue;
                    var br = branches.SelectedValue;
                    var div = divisions.SelectedValue;
                    var sec = Sector.SelectedValue;
                    var reg = Region.SelectedValue;
                    _db.T_Candidate.Add(
                        new T_Candidate
                        {
                            Code = staffid,
                            StaffID = staffid,
                            FirstName = othername,
                            LastName = lastname,
                            Email = email,
                            Grade = gr,
                            Branch =  int.Parse(br),
                            Division = div,
                            Sector = sec,
                            IsActive = true,
                            ApprovalStatus = ErecruitHelper.ApprovalStatus.APPROVED.ToString(),
                            Region =  int.Parse(reg),
                            RegisterBy = SessionHelper.FetchEmail(Page.Session),
                            DateRegistered = DateTime.Now
                        });
                    _db.SaveChanges();

                    Response.Redirect("TestLanding.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("Err.aspx", false);
            }

        }

        protected void cancel2_Click(object sender, EventArgs e)
        {

        }
    }
}