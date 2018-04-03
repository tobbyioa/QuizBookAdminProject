using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using System.Web.Configuration;

namespace QuizBook.Views
{
    public partial class ActivateCandidateSession : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanManageTestBatches)
                {
                    
                }
                else
                {
                    Response.Redirect("~/Views/NoPermission.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }

        }
        private void UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage()
        {
            var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            Response.Redirect(ficaaslogin);
            Session.Abandon();
            Session.Clear();
        }
        protected void check_Click(object sender, EventArgs e)
        {
            try
            {
            var code = Code.Text;
            if (!string.IsNullOrEmpty(code))
            {
                var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);

                if (cand != null)
                {

                    var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

                    var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                    if (candBatch != null)
                    {


                        var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                        var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                        if (tracker != null)
                            { 
                        if (cbSet.Finished == false && cbSet.IsLive == true)
                        {
                           
                            
                                cbSet.IsLive = false;
                           
                                _db.SaveChanges();

                                var duration = candBatch.Duration.ToString();
                                string[] ds = duration.Split(':');
                                int min = 0;
                                int sec = 0;
                                int hour = 0;
                                int TestdurationSum = 0;
                                if (ds.Length == 1)
                                {
                                    min = int.Parse(ds[0]);
                                    sec = 0;
                                    hour = 0;
                                    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                }
                                else if (ds.Length == 2)
                                {
                                    min = int.Parse(ds[0]);
                                    sec = int.Parse(ds[1]);
                                    hour = 0;
                                    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                }
                                else
                                {
                                    min = int.Parse(ds[1]);
                                    sec = int.Parse(ds[2]);
                                    hour = int.Parse(ds[0]);
                                    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                }

                                var timeEnding = DateTime.Now;
                                var ending = timeEnding.AddSeconds(TestdurationSum);

                                var st = DateTime.Now;
                                var initialTime = tracker.InitialStartTime == null
                          ? st
                          : tracker.InitialStartTime.Value;


                                DateTime lastActiveTime = tracker.CurrentStartTime == null
                             ? initialTime
                             : tracker.CurrentStartTime.Value;

                                //TimeSpan spent = (lastActiveTime - initialTime);

                                //int hours = spent.Hours;
                                //int mins = spent.Minutes;
                                //int secs = spent.Seconds;
                                if (initialTime != null)
                                {
                                    var span = (lastActiveTime - initialTime);

                                    //var sumSpent = ((span.Hours * 3600) + (span.Minutes * 60) + span.Seconds);

                                    var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);

                                    ending = ending.Subtract(spentTime);
                                }

                                TimeSpan remaining = (ending - timeEnding);

                                //var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                //                               ErecruitHelper.AppendZero(remaining.Minutes),
                                //                               ErecruitHelper.AppendZero(remaining.Seconds));
                                resultLbl.Text = "Session for the Candidate: " + cand.Code + " has been reset.<br />Time Remaining: " + ErecruitHelper.AppendZero(remaining.Hours) + " hours, " + ErecruitHelper.AppendZero(remaining.Minutes) + " minutes and " + ErecruitHelper.AppendZero(remaining.Seconds) + " seconds";
                                //int sumSpent = ((hours ) + (mins * 60) + secs);
                                //string[] ds = duration.Split(',');
                                //int min = 0;
                                //int sec = 0;
                                //if (ds.Length == 1)
                                //{
                                //    min = int.Parse(ds[0]);
                                //    sec = 0;
                                //    duration = min + "," + sec;
                                //    resultLbl.Text = "Session for the Candidate: " + cand.Code + " has been reset.<br />Time Remaining: " + min + " minutes and " + sec + " seconds";
                                //}
                                //else
                                //{
                                //    min = int.Parse(ds[0]);
                                //    sec = int.Parse(ds[1]);
                                //    duration = min + "," + sec;
                                //    resultLbl.Text = "Session for the Candidate: " + cand.Code + " has been reset.<br />Time Remaining: " + min + " minutes and " + sec + " seconds";
                                //}

                           

                                //SessionHelper.SetCandidateCode(code, Session);
                                //Response.Redirect("ActivateCandidateSession.aspx", false);
                        }
                        else if (cbSet.Finished == false && cbSet.IsLive == false)
                        {
                            resultLbl.Text = "The candidate Session currently valid.";

                            }else
                            {
                                var rsltTxt = "The candidate must have finished the test.";



                                resultLbl.Text = rsltTxt;
                            }
 }
                            else
                            {
                                resultLbl.Text = "The candidate is yet to start the test.";
                            }
                        }
                        else
                        {
                            resultLbl.Text = "The candidate has not been assigned to a test batch.";

                        }

                    }
                    else
                    {
                        resultLbl.Text = "This is not a valid candidate code";
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