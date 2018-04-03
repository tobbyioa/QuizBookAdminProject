using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class ActiveCandidates : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
             var permissions = ErecruitHelper.GetUserPermissions(Page.Session);
                    var sid = SessionHelper.FetchStaffId(Page.Session);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var user = _db.T_Candidate.FirstOrDefault(s => s.Code.Trim() == sid.Trim());



                LoadTestsForCandidate(_db);

                //  testPanel.Visible = true;
            }

        }

        private void LoadTestsForCandidate(QuizBookDbEntities1 _db)
        {
            //var ab = _db.T_Batch.Where(s => s.IsActive == true);
            //var abid = ab.Select(s => s.Id).ToList();

            var tenant = long.Parse(SessionHelper.GetTenantID(Session));
            var scopes = _db.T_CTestTracker.Where(s =>s.Candidate.TenantId == tenant && s.InSession.Value == true && s.Finished.Value ==false).ToList();
            var myScopes = new List<BatchScopeContent>();

              var quests = scopes.Where(x =>x.T_Batch.EndDate!= null && !(x.T_Batch.EndDate.Value < DateTime.Now)).OrderByDescending(s=>s.BatchId).Select(a => new
              {
                ID = a.BatchId,
                trackerId = a.Id,
                CandidateName = a.Candidate.FirstName +" "+a.Candidate.LastName,
                CandidateStaffId = a.Candidate.Username??"-",
                Test = a.T_Batch.Name,
                Duration = a.T_Batch.Duration.Value,
                Rem = TimeSpan.FromSeconds(int.Parse(a.RemainingDuration)).ToString(@"hh\:mm\:ss"),
                  st = a.CurrentStartTime,
                  la = a.CurrentStartTime,
                  Time = a.T_Batch.StartDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt"),
                ETime = a.T_Batch.EndDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt")
            }).Distinct().ToList();

            GridView1.DataSource = quests;
            GridView1.DataBind();
        }

        protected void rfsh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActiveCandidates.aspx", false);
        }

        protected void lnkeditCa_Click(object sender, EventArgs e)
        {

                LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDCa");
            var idcr = long.Parse(hdfID.Value);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {

                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.Id == idcr);
                if (tracker != null)
                {
                    tracker.LastQIndex = 0;
                    tracker.CurrentStartTime = DateTime.Now;
                    tracker.InSession = false;
                    tracker.Finished = true;
                    _db.SaveChanges();
                }
            }
            Response.Redirect("ActiveCandidates.aspx", false);
        }
    }
}