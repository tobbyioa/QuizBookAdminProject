using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class EditCandidate : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var permissions = ErecruitHelper.GetAdminUserPermissions(Session);
                if (!permissions._CanWorkWithCandidates)
                {
                    Response.Redirect("NoPermission.aspx", false);
                }
                else
                {
                    var candId = Request["z"];
                    var candidate = _db.T_Candidate.FirstOrDefault(s => s.Id == long.Parse(candId));
                    //staff_id.Text = candidate.Code;
                    cidHdn.Value = candidate.Id.ToString();
                    stID.Text = candidate.Code;
                    surname.Text = candidate.LastName;
                    othername.Text = candidate.FirstName;
                    email.Text = candidate.Email;

                    var g = _db.grade_tab.Select(a => new
                    {
                        Id = a.GRADE_CODE.Trim(),
                        Name = a.GRADE_LEVEL.Trim()

                    }).Distinct().OrderBy(s => s.Name).ToList();
                    g.Insert(0, new { Id = "-1", Name = "--Select Your Grade--" });
                    grades.DataSource = g;
                    grades.DataBind();
                    grades.SelectedValue = candidate.Grade;

                    var d = _db.division_tab.Select(a => new
                    {
                        Id = a.DIV_CODE.Trim(),
                        Name = a.DIV_NAME.Trim()

                    }).Distinct().OrderBy(s => s.Name).ToList();
                    d.Insert(0, new { Id = "-1", Name = "--Select Your Division--" });
                    divisions.DataSource = d;
                    divisions.DataBind();
                    divisions.SelectedValue = candidate.Division;

                    var b = _db.branch_tab.Select(a => new
                    {
                        Id = a.sol_id.Trim(),
                        Name = a.branch_name.Trim().ToUpper()

                    }).Distinct().OrderBy(s => s.Name).ToList();
                    b.Insert(0, new { Id = "-1", Name = "--Select Your Branch--" });
                    branches.DataSource = b;
                    branches.DataBind();
                    branches.SelectedValue = candidate.branch_tab.sol_id.Trim();

                    var sec = _db.sector_tab.Select(a => new
                    {
                        Id = a.SECTOR_CODE.Trim(),
                        Name = a.SECTOR_NAME.Trim()

                    }).Distinct().OrderBy(s => s.Name).ToList();
                    sec.Insert(0, new { Id = "-1", Name = "Select Your Sector" });
                    Sector.DataSource = sec;
                    Sector.DataBind();
                    Sector.SelectedValue = candidate.sector_tab.SECTOR_CODE;

                    var reg = _db.region_tab.Select(a => new
                    {
                        Id = a.region_code.ToString().Trim(),
                        Name = a.region_name.Trim()

                    }).Distinct().OrderBy(s => s.Name).ToList();
                    reg.Insert(0, new { Id = "-1", Name = "--Select Your Region--" });
                    Region.DataSource = reg;
                    Region.DataBind();
                    Region.SelectedValue = candidate.region_tab.region_code.ToString();
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
            Response.Redirect("Candidate.aspx", false);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                var id = cidHdn.Value;
                var gr = grades.SelectedValue;
                var br = branches.SelectedValue;
                var div = divisions.SelectedValue;
                var sec = Sector.SelectedValue;
                var reg = Region.SelectedValue;
                var candidate = _db.T_Candidate.FirstOrDefault(s => s.Id == long.Parse(id));
                candidate.Grade = gr;
                candidate.Branch = int.Parse( br);
                candidate.Division = div;
                candidate.Sector = sec;
                candidate.Region =  int.Parse(reg);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }

        }
    }
}