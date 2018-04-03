using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class IndividualTestReport : System.Web.UI.Page
    {
        //QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            var permissions = ErecruitHelper.GetAdminUserPermissions(Session);
            if (!IsPostBack)
            {
                if (permissions._CanManageTestResults)
                {
                   // var actTest = _db.T_CTestTracker.Where(s =>s.CandidateId == "")
                    var actTest = new List<object>();
                    CandidateTestList.DataSource = actTest.ToList();
                    CandidateTestList.DataBind();
                    DAlert.Visible = false;
                    DMain.Visible = true;
                }
                else{

                    DAlert.Visible =true;
                    DMain.Visible =false;
                }
            }
        }

        protected void lnkeditApp_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField batchid = (HiddenField)p.FindControl("BatchId");
            var bid = long.Parse(batchid.Value);
            HiddenField candId = (HiddenField)p.FindControl("CandId");
            var cid = long.Parse(candId.Value);
            if (!(bid == null) && !(cid == null))
            {
                Session["BatchId"] =bid ;
                Session["CandId"] = cid;

                //Response.Redirect("~/Reports/IndividualTestResult.aspx", false);
                Response.Redirect("IndividualTestResult.aspx", false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var stid = staffId.Text;
                var tent = long.Parse(SessionHelper.GetTenantID(Session));
                var cand = _db.Candidates.FirstOrDefault(s => s.Username == stid.Trim() && s.TenantId == tent );
                if (cand != null)
                {
                    var actTest = _db.T_CTestTracker.AsEnumerable().Where(s => s.CandidateId == cand.Id && s.Finished == true).OrderByDescending(x => x.CurrentStartTime).Select(x => new
                    {
                        Name = x.T_Batch.Name,
                        Candidate = x.CandidateId,
                        Batch = x.BatchId,
                        TimeFinished = ErecruitHelper.GetDateStringFromDate(x.CurrentStartTime.Value)
                    });

                    CandidateTestList.DataSource = actTest.ToList();
                    CandidateTestList.DataBind();
                    DAlert.Visible = false;
                    DMain.Visible = true;
                }
                else
                {
                    var actTest = new List<object>();
                    CandidateTestList.DataSource = actTest.ToList();
                    CandidateTestList.DataBind();

                    //alert.InnerText = "This Candidate does not exist on the portal.";
                    DAlert.Visible = false;
                    DMain.Visible = true;
                }
            }
        }
    }
}