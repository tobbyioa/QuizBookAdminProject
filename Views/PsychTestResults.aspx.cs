using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using QuizBook.Model;

namespace QuizBook.Views
{
    public partial class PsychTestResults : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanManageTestResults)
                {

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

        protected void check_Click(object sender, EventArgs e)
        {
            var code = Code.Text;

            var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);
            if (!(cand == null))
            {
                var b_set = _db.T_MultiintelligencQuizBookDb.Where(s => s.CandidateId == cand.Id).ToList();
                int count = b_set.Count();
                if (count > 1)
                {
                    var quests = b_set.Select(a => new PrevBatchGridModel
                    {
                        ID = a.Id,
                        BatchName = ErecruitHelper.getBatchName((long)a.BatchId),
                        Code = ErecruitHelper.getCandidateCode((long)a.CandidateId) + "," + a.BatchId,
                        DateTaken = ErecruitHelper.GetDateStringFromDate((DateTime)a.DateLogged)
                    }).Distinct().ToList();
                    batchHistory.DataSource = quests;
                    batchHistory.DataBind();
                    batchHistoryPanel.Visible = true;

                    SessionHelper.NullCandidateCode(Session);
                    Session["Batchid"] = null;
                }
                else if (count == 1)
                {
                    batchHistoryPanel.Visible = false;
                    SessionHelper.SetCandidateCode(code, Session);
                    Session["Batchid"] = b_set[0].BatchId;
                    Response.Redirect("PsychometricView.aspx", false);
                }
                else
                {
                    resultLbl.Text = "No History";
                    batchHistoryPanel.Visible = false;
                }


            }
            else
            {
                resultLbl.Text = "This is not a valid candidate code";
                batchHistoryPanel.Visible = false;
            } 

            //if (!string.IsNullOrEmpty(code))
            //{
            //    var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);

            //    if (cand != null)
            //    {

            //        var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

            //        var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
            //        if (candBatch != null)
            //        {
            //            var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
            //            var c_off = _db.T_Settings.FirstOrDefault(s => s.SettingsName == ErecruitHelper.Settings.CUT_OFF_MARK.ToString()).SettingsValue;
                        
            //            if (cbSet!= null && cbSet.Finished == true )
            //            {
            //                if (double.Parse(cbSet.TestScore) > double.Parse(c_off))
            //                {
            //                SessionHelper.SetCandidateCode(code, Session);
            //                Response.Redirect("PsychometricView.aspx", false);

            //                }
            //                else
            //                {
            //                    resultLbl.Text = "The candidate did not pass the test.";
            //                }
                           
            //            }
            //            else
            //            {
            //                var rsltTxt = "The candidate has not concluded the test.";

            //                resultLbl.Text = rsltTxt;
            //            }

            //        }
            //        else
            //        {
            //            resultLbl.Text = "The candidate has not been assigned to a test batch.";

            //        }
                   
            //    }
            //     else
            //        {
            //            resultLbl.Text = "This is not a valid candidate code";
            //        }
            //}
        }

        protected void lnkeditBa_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDBa");
            var code = hdfID.Value;
            if (!(string.IsNullOrEmpty(code)))
            {

                var s = code.Split(',');
                if (s.Length > 1)
                {
                    SessionHelper.SetCandidateCode(s[0], Session);
                    Session["Batchid"] = s[1];
                    Response.Redirect("PsychometricView.aspx", false);
                }
                else
                {
                    SessionHelper.SetCandidateCode(s[0], Session);
                    //SessionHelper.NullCandidateCode(Session);
                    Session["Batchid"] = null;
                    Response.Redirect("PsychometricView.aspx", false);
                }
            }
        }
    }
}