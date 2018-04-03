using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class CandidateLogin : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void C_TestStart_Click(object sender, EventArgs e)
        {
            try
            {
                var code = Code.Text;
                if (!string.IsNullOrEmpty(code))
                {
                    var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);



                    if (cand.ApprovalStatus == QuizBook.Helpers.ErecruitHelper.ApprovalStatus.APPROVED.ToString())
                    {

                        if (cand != null)
                        {
                            SessionHelper.SetCandidateCode(cand.Code.ToString(CultureInfo.InvariantCulture), Session);
                            var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

                            if (!b_id.Any())
                            {
                                Info.Text = "You have not been assigned to a batch.\n Please contact the Administrator.";
                                //Response.Redirect("CandidateLogin.aspx");
                            }
                            else
                            {

                                var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                                if (candBatch != null)
                                {
                                    if (candBatch.StartDate <= DateTime.Now)
                                    {
                                        var bSets = _db.T_BatchSet.Where(s => s.BatchId == candBatch.Id).ToList();
                                        //int membersCount = bSets.Count();
                                        //int finishedMembersCount = bSets.Where(s => s.Finished.Value).Count();
                                        var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                                        if (cbSet != null && cbSet.Finished == true)
                                        {
                                            SessionHelper.SetCandidateId(cand.Id.ToString(CultureInfo.InvariantCulture), Session);

                                            if (cbSet.Essay == true)
                                            {
                                                if (cbSet.Psychometric == true)
                                                {
                                                    ErecruitHelper.CheckBatches(_db, candBatch);
                                                    Info.Text = "You have already finished this process";
                                                }
                                                else
                                                {
                                                    var exitingPsyc1 = _db.T_MultiintelligencQuizBookDb.FirstOrDefault(s => s.CandidateId == cand.Id);
                                                    if (exitingPsyc1 != null)
                                                    {
                                                        Response.Redirect("BackGroundQuestionaire.aspx", false);
                                                    }
                                                    else
                                                    {
                                                        Response.Redirect("MultiIntelligenceTest.aspx", false);
                                                    }
                                                }


                                            }
                                            else
                                            {

                                                //Info.Text = "You have not done the Essay part";
                                                Response.Redirect("CandidateTestResult.aspx", false);
                                            }

                                            //if (cbSet.Psychometric == false)
                                            //{
                                            //    Info.Text = "You have not done the Psychometric part";
                                            //}
                                            //else if (cbSet.Finished == true&& cbSet.Psychometric == true && cbSet.Essay == true)
                                            //{

                                            //}
                                            //if (cbSet.Essay == true)
                                            //{
                                            //}
                                            // Info.Text = "You Have Done this test.";

                                        }
                                        else
                                        {
                                            var batchSet = bSets.FirstOrDefault(s => s.CandidateId == cand.Id);

                                            if (batchSet.IsLive.Value)
                                            {
                                                Info.Text = "You Currently have a Session on.\n Please contact the Administrator.";
                                                // Response.Redirect("CandidateLogin.aspx");
                                            }
                                            else
                                            {

                                                if (candBatch != null)
                                                {
                                                    var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                                                    if (tracker != null)
                                                    {


                                                        //var duration = tracker.RemainingDuration.ToString();
                                                        //string[] ds = duration.Split(':');
                                                        //int hour = 0;
                                                        //int min = 0;
                                                        //int sec = 0;
                                                        //if (ds.Length == 1)
                                                        //{
                                                        //    min = int.Parse(ds[0]);
                                                        //    sec = 0;
                                                        //    hour = 0;
                                                        //    duration = hour+":"+min + ":" + sec;
                                                        //}
                                                        //else if (ds.Length == 2)
                                                        //{
                                                        //    min = int.Parse(ds[0]);
                                                        //    sec = int.Parse(ds[1]);
                                                        //    hour = 0;
                                                        //    duration = hour + ":" + min + ":" + sec;
                                                        //}
                                                        //else
                                                        //{
                                                        //    min = int.Parse(ds[1]);
                                                        //    sec = int.Parse(ds[2]);
                                                        //    hour = int.Parse(ds[0]);
                                                        //    duration = hour + ":" + min + ":" + sec;
                                                        //}
                                                        var st = DateTime.Now;
                                                        var initialTime = tracker.InitialStartTime == null
                                                  ? st
                                                  : tracker.InitialStartTime.Value;


                                                        DateTime lastActiveTime = tracker.CurrentStartTime == null
                                                     ? initialTime
                                                     : tracker.CurrentStartTime.Value;

                                                        TimeSpan spent = (lastActiveTime - initialTime);

                                                        int hours = spent.Hours;
                                                        int mins = spent.Minutes;
                                                        int secs = spent.Seconds;
                                                        int sumSpent = ((hours * 3600) + (mins * 60) + secs);

                                                        var TestDuration = tracker.TestDuration.ToString();
                                                        string[] ds = TestDuration.Split(':');
                                                        int hour = 0;
                                                        int min = 0;
                                                        int sec = 0;
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


                                                        if (sumSpent >= TestdurationSum)
                                                        {
                                                            Response.Redirect("CandidateTestResult.aspx?z=elapsed", false);
                                                        }
                                                        else
                                                        {

                                                            //var endtime = st.AddSeconds(TestdurationSum - sumSpent);

                                                            //tracker.CurrentStartTime = st;
                                                            //tracker.EndTime = endtime;

                                                            batchSet.IsLive = true;
                                                            candBatch.SessionOn = true;
                                                            _db.SaveChanges();


                                                            tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                                                            var remaining = tracker.RemainingDuration;
                                                            var d = tracker.TestDuration;
                                                            if (d != "00:00:00" && remaining != "00:00:00")
                                                            {
                                                                var existingQCount = _db.T_CandidateTemp.Count(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);

                                                                if (existingQCount < 1)
                                                                {
                                                                    List<long?> Q = _db.T_BatchQuestions.Where(s => s.BatchId == candBatch.Id).Select(x => x.QuestionId).ToList();
                                                                    var questions = _db.T_Question.Where(s => Q.Contains(s.Id)).ToList();
                                                                    var typ = questions.Select(s => s.PreambleId).Distinct().OrderBy(s => s).ToList();
                                                                    //Randomize the questions
                                                                    // Q.Shuffle(); 
                                                                    int count = 0;
                                                                    foreach (var t in typ)
                                                                    {
                                                                        var qs = questions.Where(s => s.PreambleId == t).ToList();
                                                                        //Randomize the questions
                                                                        RandomHelper.Shuffle(qs);
                                                                        RandomHelper.Shuffle(qs);
                                                                        foreach (var q in qs)
                                                                        {
                                                                            _db.T_CandidateTemp.Add(new T_CandidateTemp
                                                                            {
                                                                                CandidateId = cand.Id,
                                                                                BatchId = candBatch.Id,
                                                                                PreambleId = q.PreambleId,
                                                                                Q_Id = q.Id,
                                                                                Q_Index = (count + 1),
                                                                                Answered = false
                                                                            });
                                                                            count++;
                                                                        }
                                                                        _db.SaveChanges();
                                                                    }
                                                                }
                                                                //List<T_Question> questions = _db.T_Question.Where(s => Q.Contains(s.Id) && s.IsActive.Value).ToList();



                                                                SessionHelper.SetCandidateId(cand.Id.ToString(CultureInfo.InvariantCulture), Session);
                                                                Response.Redirect("CandidateTestPage.aspx", false);
                                                            }

                                                        }


                                                    }
                                                    else
                                                    {
                                                        var st = DateTime.Now;
                                                        var duration = candBatch.Duration.ToString();
                                                        //string[] ds = duration.Split(':');
                                                        //int min = 0;
                                                        //int sec = 0;
                                                        //int hour = 0;
                                                        //int TestdurationSum = 0;
                                                        //if (ds.Length == 1)
                                                        //{
                                                        //    min = int.Parse(ds[0]);
                                                        //    sec = 0;
                                                        //    hour = 0;
                                                        //    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                                        //}
                                                        //else if (ds.Length == 2)
                                                        //{
                                                        //    min = int.Parse(ds[0]);
                                                        //    sec = int.Parse(ds[1]);
                                                        //    hour = 0;
                                                        //    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                                        //}
                                                        //else
                                                        //{
                                                        //    min = int.Parse(ds[1]);
                                                        //    sec = int.Parse(ds[2]);
                                                        //    hour = int.Parse(ds[0]);
                                                        //    TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                                                        //}


                                                        //var endtime = st.AddSeconds(TestdurationSum);


                                                        _db.T_CTestTracker.Add(new T_CTestTracker
                                                        {
                                                            CandidateId = cand.Id,
                                                            BatchId = candBatch.Id,
                                                            CandidateCode = cand.Code,
                                                            // InitialStartTime = st,
                                                            // CurrentStartTime = st,
                                                            TestDuration = ErecruitHelper.AppendZero(0) + ":" + ErecruitHelper.AppendZero(int.Parse(duration)) + ":" + ErecruitHelper.AppendZero(0),
                                                            RemainingDuration = duration,
                                                            //EndTime = endtime
                                                        }
                                                        );

                                                        //var batchSets = _db.T_BatchSet.Where(s => s.BatchId == candBatch.Id).ToList();


                                                        // var batchSet = bSets.Where(s => s.CandidateId == cand.Id).FirstOrDefault();


                                                        batchSet.IsLive = true;
                                                        batchSet.TimeStarted = DateTime.Now;
                                                        candBatch.SessionOn = true;
                                                        _db.SaveChanges();

                                                        tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                                                        var remaining = tracker.RemainingDuration;
                                                        var d = tracker.TestDuration;
                                                        if (d != "0:0:0" && remaining != "0:0:0")
                                                        {
                                                            var existingQCount = _db.T_CandidateTemp.Count(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);

                                                            if (existingQCount < 1)
                                                            {
                                                                List<long?> Q = _db.T_BatchQuestions.Where(s => s.BatchId == candBatch.Id).Select(x => x.QuestionId).ToList();
                                                                var questions = _db.T_Question.Where(s => Q.Contains(s.Id)).ToList();
                                                                var typ = questions.Select(s => s.PreambleId).Distinct().OrderBy(s => s).ToList();
                                                                //Randomize the questions
                                                                // Q.Shuffle(); 
                                                                int count = 0;
                                                                foreach (var t in typ)
                                                                {
                                                                    var qs = questions.Where(s => s.PreambleId == t).ToList();
                                                                    //Randomize the questions
                                                                    RandomHelper.Shuffle(qs);
                                                                    RandomHelper.Shuffle(qs);
                                                                    foreach (var q in qs)
                                                                    {
                                                                        _db.T_CandidateTemp.Add(new T_CandidateTemp
                                                                        {
                                                                            CandidateId = cand.Id,
                                                                            BatchId = candBatch.Id,
                                                                            PreambleId = q.PreambleId,
                                                                            Q_Id = q.Id,
                                                                            Q_Index = (count + 1),
                                                                            Answered = false
                                                                        });
                                                                        count++;
                                                                    }
                                                                    _db.SaveChanges();
                                                                }
                                                            }
                                                            //List<T_Question> questions = _db.T_Question.Where(s => Q.Contains(s.Id) && s.IsActive.Value).ToList();



                                                            SessionHelper.SetCandidateId(cand.Id.ToString(CultureInfo.InvariantCulture), Session);
                                                            Response.Redirect("CandidateTestPage.aspx", false);
                                                        }

                                                    }


                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Info.Text = "It is not yet time to take this test.\n Please contact the Administrator.";
                                    }
                                }
                                else
                                {
                                    Info.Text = "You are not assigned to any active batch.\n Please contact the Administrator.";
                                }
                            }
                        }
                        else
                        {
                            Info.Text = "This is not a valid candidate ID.\n Please contact the Administrator.";
                            // Response.Redirect("CandidateLogin.aspx");
                        }
                    }
                    else
                    {
                        Info.Text = "You have not been approved.\n Please contact the Administrator.";
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