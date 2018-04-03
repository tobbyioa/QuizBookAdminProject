using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class CandidateReg : System.Web.UI.Page
    {
        OuterPage master = null;
        string keySalt = "QuizBook";
        protected void Page_Init(object sender, EventArgs e)
        {
            master = this.Master as OuterPage;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (SessionHelper.GetTenantName(Session) == null || SessionHelper.GetTenantImage(Session) == null)
            {
                Response.Redirect("Welcome.aspx", false);
            }
            else
            {

                master.TenantName = SessionHelper.GetTenantName(Session);
                master.TenantImage = SessionHelper.GetTenantImage(Session);
            }
            //}
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var page = Page.IsValid;
                var tsn = tsname.Text;
                var fn = fname.Text;
                var ln = lname.Text;
                //var address = Address.Text;
                var emailvar = email.Text;
                var sx = sex.SelectedItem.Value;
                //var dateOb = dob.Text;
                var un = username.Text;
                //var pw = password.Text;
                //var cpw = cPass.Text;
                //var ste = Request[state.UniqueID].ToString();
                //var ctry = Request[country.UniqueID].ToString();

                var pw = Request["userPw"].ToString();
                var cpw = Request["userPw2"].ToString();

                var lctn = Request[Location.UniqueID].ToString();
                var role = RoleList.Visible ? RoleList.SelectedValue : null;


                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                    {
                    var tn = _db.Tenants.FirstOrDefault(s => tsn.Trim().Equals(s.TenantCode));
                    if (tn != null)
                    {
                        if (pw.Trim() == cpw.Trim())
                        {
                            long? n = null;
                            var rl = _db.Roles.FirstOrDefault(s => s.Description == "Candidate");

                            _db.Candidates.Add(new QuizBook.Candidate
                            {
                                FirstName = fn,
                                LastName = ln,
                                Username = un,
                                Sex = sx,
                                //DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb),
                                //Address = Address.Text,
                                //State = Request[state.UniqueID].ToString(),
                                //Country = Request[country.UniqueID].ToString(),
                                Location = Request[Location.UniqueID].ToString(),
                                Email = emailvar,
                                TenantId = tn.Id,
                                Role = rl.Id,
                                Status = ErecruitHelper.CStatus.Active.ToString(),
                                DateCreated = DateTime.Now,
                                CreatedBy = "QuizBook",
                                Captcha = Page.IsValid,
                                Class = role ==null?n:long.Parse(role),
                                DefaultLoginKeyChanged = true,
                                LogInKey = ErecruitHelper.getHash(pw, keySalt),
                                IpAddress = ErecruitHelper.GetIP(HttpContext.Current)
                            });
                            _db.SaveChanges();
                            Session["InfoValue"] = "Your Profile has been successfully saved. Kindly <a href='CandLogin.aspx'>click here</a> to proceed.";
                            Response.Redirect("Info.aspx", false);

                        }
                        else
                        {
                            lblAlert.Text = "Registration Failed. Your passwords did not match";
                        }
                    }
                    else
                    {
                        lblAlert.Text = "Registration Failed. Kindly ensure you have the correct Tenant Code.";
                    }
                }

            }
            catch(Exception ex)
            {
                SessionHelper.SetExMessage(ex.Message,Session);
                SessionHelper.SetExStacktrace(ex.StackTrace,Session);
                Response.Redirect("ExceptionPage.aspx",false);
            }
        }

        protected void tsname_TextChanged(object sender, EventArgs e)
        {
            var tsn = tsname.Text;
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var tn = _db.Tenants.FirstOrDefault(s => tsn.Trim().Equals(s.TenantCode));
                if (tn != null)
                {
                    var roles = _db.Roles.AsEnumerable().Where(x => x.Active && x.TenantId.HasValue && x.TenantId == tn.Id);
                    if(roles.Count() > 0)
                    {
                        
                        var rls = roles.OrderBy(s => s.Description).Select(a => new
                        {
                            Id = a.Id,
                            Name = a.Description

                        }).ToList();

                        rls.Insert(0, new { Id = long.Parse("-1"), Name = "--Class--" });

                        RoleList.DataSource = rls;

                        RoleList.DataBind();
                        RoleList.Visible = true;
                    }
                }
            }
        }
    }
}