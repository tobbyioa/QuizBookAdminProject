using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class MultiIntelligenceTest : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                var candId = SessionHelper.FetchCandidateId(Session);


                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == long.Parse(candId));
                var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == tracker.CandidateCode);
                var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);
                var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                //string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                //Image1.ImageUrl = !(string.IsNullOrEmpty(cand.Passport)) ? cand.Passport : path;
                //string st = cand.Code + " - " + cand.FirstName + " " + cand.LastName;
                //CandName.Text = st;


                var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);

                if (cand != null && candBatch != null)
                {
                    var bs = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                    ccode.InnerHtml = cand.Code;
                    CGender.InnerHtml = cand.Sex;
                    Surname.InnerHtml = cand.LastName;
                    COthernames.InnerHtml = cand.FirstName + " " + cand.MiddleName + " " + cand.MaidenName;
                    CDob.InnerHtml = ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Day) + "/" + ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Month) + "/" + cand.DateOfBirth.Value.Year;
                    cgrade.InnerHtml = bs.TestScore + "%";
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
            var candId = SessionHelper.FetchCandidateId(Session);
            var id = long.Parse(candId);
            var cand = _db.T_Candidate.FirstOrDefault(s => s.Id == id);
           
            if (cand != null )
            {

            var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);
            var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

            if (candBatch != null)
            {
                var ansCol1 = Request.Form["D1"];
                var ansCol2 = Request.Form["D2"];
                var ansCol3 = Request.Form["D3"];
                var ansCol4 = Request.Form["D4"];
                var ansCol5 = Request.Form["D5"];
                var ansCol6 = Request.Form["D6"];
                var ansCol7 = Request.Form["D7"];
                var sums = Request.Form["Summation"];
                var intel = intelligence.Value;
                if (string.IsNullOrEmpty(ansCol1) || string.IsNullOrEmpty(ansCol2) || string.IsNullOrEmpty(ansCol3) ||
                    string.IsNullOrEmpty(ansCol4) || string.IsNullOrEmpty(ansCol5) || string.IsNullOrEmpty(ansCol6)
                    || string.IsNullOrEmpty(ansCol7) || string.IsNullOrEmpty(sums) || string.IsNullOrEmpty(intel))
                {
                    msgLabel.Text = "Please make sure you answer all the questions";
                }
                else
                {

                    _db.T_MultiintelligencQuizBookDb.Add(new T_MultiintelligencQuizBookDb
                    {
                        CandidateId = cand.Id,
                        BatchId = candBatch.Id,
                        Options1 = ansCol1,
                        Options2 = ansCol2,
                        Options3 = ansCol3,
                        Options4 = ansCol4,
                        Options5 = ansCol5,
                        Options6 = ansCol6,
                        Options7 = ansCol7,
                        Summations = sums,
                        Intelligence = intel,
                        DateLogged = DateTime.Now
                    });

                    _db.SaveChanges();

                    Response.Redirect("BackGroundQuestionaire.aspx", false);
                }
            }

            }
             }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
    }
}