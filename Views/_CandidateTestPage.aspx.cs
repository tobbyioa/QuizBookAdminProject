using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Services;
using System.IO;
using System.Web.UI.HtmlControls;

namespace QuizBook.Views
{
    public partial class _CandidateTestPage : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();

        [WebMethod(EnableSession = true)]
        public static string logout(string id)
        {
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            if (id == "false")
            {
                var v = HttpContext.Current.Session;
                var sid = SessionHelper.FetchStaffId(v);
                var selbatch = v["SelectedBatch"].ToString();
                var user = _db.T_Candidate.FirstOrDefault(s => s.StaffID.Trim() == sid.Trim());
                var selBatchLong =  long.Parse(selbatch);
                var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);
                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == candBatch.Id);
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

                TimeSpan testDuration = new TimeSpan(hour, min, sec);

                var timeEnding = DateTime.Now;
                //var ending = timeEnding.AddSeconds(TestdurationSum);

                var initialTime = tracker.InitialStartTime == null
                                      ? timeEnding
                                      : tracker.InitialStartTime.Value;

                var lastActiveTime = tracker.CurrentStartTime == null
                                         ? initialTime
                                         : tracker.CurrentStartTime.Value;

                if (initialTime != null)
                {
                    var span = (lastActiveTime - initialTime);

                    var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);



                    var cStartTime = timeEnding.Subtract(spentTime);

                    var remaining = testDuration.Subtract(spentTime);

                    var ending = timeEnding.Add(remaining);

                    var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                                   ErecruitHelper.AppendZero(remaining.Minutes),
                                                   ErecruitHelper.AppendZero(remaining.Seconds));

                    tracker.InitialStartTime = cStartTime;
                    tracker.CurrentStartTime = timeEnding;
                    tracker.RemainingDuration = timeString;
                    tracker.EndTime = ending;
                    _db.SaveChanges();

                }

                v.Abandon();
            }
            return "You are leaving this page";

        }

        protected string GetfinishedPostBack()
        {
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterForEventValidation(finish_btn.UniqueID);
            return Page.ClientScript.GetPostBackEventReference(finish_btn, string.Empty);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack)
                //{
                var next = Session["curr"] ?? 0;
                //var next = string.IsNullOrEmpty(currPage.Value) ? "0" : currPage.Value;
                var selbatch = Session["SelectedBatch"].ToString();
                var selBatchLong = long.Parse(selbatch);
                var sid = SessionHelper.FetchUserName(Page.Session);


                var el = Request["z"];

                if (el != null && el == ErecruitHelper.sha256_hash("elapsed"))
                {
                    // Control c = GetPostBackControl();
                    Session["curr"] = nextPage.Value;
                    //var selbatch = Session["SelectedBatch"].ToString();
                    //var sid = SessionHelper.FetchStaffId(Page.Session);
                    var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                    var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);
                    // Page l = (Page)this;

                    //Panel hdfID = (Panel)this.FindControl("Panel1");

                    // var r = this.Controls;

                    Table t = (Table)this.Panel1.FindControl("Quests");
                    DoAnswerQuestions(t, user, candBatch);
                    _db.MarkUnAnswered_sp(candBatch.Id, user.Id);
                    _db.MarkCandidatquizUser_sp(candBatch.Id, user.Id);


                    var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == candBatch.Id);

                    tracker.CurrentStartTime = DateTime.Now;
                    tracker.InSession = false;
                    tracker.Finished = true;
                    _db.SaveChanges();


                    Response.Redirect("CandidateTestResult.aspx", false);
                }
                else
                {
                    var bat = long.Parse(selbatch);

                    var batch = _db.T_Batch.FirstOrDefault(s => s.Id == bat);

                    var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());

                    var questions = _db.BatchScopeContents.FirstOrDefault(s => s.BatchId == bat).T_QuestionType.T_Question.OrderBy(x => x.Section).ToList();
                    //RandomHelper.Shuffle(questions);
                    var sects = questions.Select(s => s.Section).Distinct().OrderBy(x => x.ToString()).ToArray();
                    Session["sects"] = sects;

                    Table tb = new Table();
                    tb.ID = "Quests";
                    tb.Width = new Unit("100%");
                    tb.CssClass = "top";
                    Label y1 = new Label();
                    var nx = sects[int.Parse(next.ToString())];
                    //"Section -" + 
                    y1.Text = nx.ToString();
                    var r1 = new TableRow();
                    var c1 = new TableCell();
                    c1.Controls.Add(y1);
                    r1.Cells.Add(c1);
                    tb.Rows.Add(r1);
                    //sects[int.Parse(next.ToString())]
                    var qs = questions.Where(s => s.Section == nx).ToList();
                    RandomHelper.Shuffle(qs);
                    // var orgSet = qs;
                    TableRow mtr = new TableRow();
                    TableCell mtc = new TableCell();
                    int count = 0;
                    foreach (var q in qs)
                    {
                        Table tbs = new Table();

                        tb.CssClass = "i_top lowerBorder";
                        HtmlGenericControl QuestionDetails = new HtmlGenericControl("span");
                        QuestionDetails.InnerHtml = q.Details;
                        QuestionDetails.ID = "Question:" + q.Id.ToString();
                        tbs.ID = "Que_" + q.Id.ToString();
                        TableRow tr1 = new TableRow();
                        TableCell tc1 = new TableCell();
                        TableCell tc2 = new TableCell();
                        Label x1 = new Label();
                        //   x1.Text = (questions.IndexOf(q) + 1) + ".";
                        x1.Text = (count + 1) + ".";
                        tc1.Controls.Add(x1);
                        tc2.Controls.Add(QuestionDetails);
                        tr1.Cells.Add(tc1);
                        tr1.Cells.Add(tc2);
                        tbs.Rows.Add(tr1);
                        TableRow tr2 = new TableRow();



                        TableCell tc21 = new TableCell();
                        TableCell tc22 = new TableCell();
                        Label x2 = new Label();
                        x2.Text = " ";
                        tc21.Controls.Add(x2);

                        //new implementation



                        var answered = _db.T_CandidateAnswers.FirstOrDefault(s => s.BatchId == batch.Id && s.CandidateId == user.Id && s.QuestionId == q.Id);
                        if (answered != null)
                        {
                            foreach (var an in q.T_Option)
                            {
                                RadioButton opt = new RadioButton();
                                opt.GroupName = questions.IndexOf(q).ToString();
                                opt.ID = an.Id.ToString();
                                opt.Text = an.Details;
                                opt.Enabled = false;
                                if (an.Id == answered.Answer)
                                {
                                    opt.Checked = true;
                                }
                                opt.CssClass = "optPad";
                                ; var br = new LiteralControl("<br>"); //br.InnerHtml = "<br />";
                                tc22.Controls.Add(opt);
                                tc22.Controls.Add(br);
                            }
                        }
                        else
                        {
                            foreach (var an in q.T_Option)
                            {
                                RadioButton opt = new RadioButton();
                                opt.GroupName = questions.IndexOf(q).ToString();
                                opt.ID = an.Id.ToString();
                                opt.Text = an.Details;
                                opt.Enabled = true;
                                opt.CssClass = "optPad";
                                var br = new LiteralControl("<br>"); //br.InnerHtml = "<br />";
                                tc22.Controls.Add(opt);
                                tc22.Controls.Add(br);
                            }
                        }

                        tr2.Cells.Add(tc21);
                        tr2.Cells.Add(tc22);
                        tbs.Rows.Add(tr2);
                        mtc.Controls.Add(tbs);
                        mtr.Cells.Add(mtc);
                        tb.Rows.Add(mtr);
                        count++;
                    }
                    Session["curr"] = int.Parse(next.ToString());
                    Panel1.Controls.Add(tb);
                    //} 
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    var sid = SessionHelper.FetchUserName(Page.Session);
                    var selbatch = Session["SelectedBatch"].ToString();
                    var bat = long.Parse(selbatch);
                    var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == bat);

                    var cand = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                    //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == candid).Select(x => x.BatchId);
                    //var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                    var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                    //string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                    //if (Master != null)
                    //{
                    //    var img = (Image)Master.FindControl("Image1");
                    //    img.ImageUrl = !(string.IsNullOrEmpty(cand.Passport)) ? cand.Passport : path;
                    //}
                    string st = cand.Username + " - " + cand.FirstName + " " + cand.LastName + "-" + ErecruitHelper.GetIP(HttpContext.Current);
                    if (Master != null)
                    {
                        var lbl = (Label)Master.FindControl("CandName");
                        lbl.Text = st;
                    }
                    if (Master != null)
                    {
                        var drtn = (HiddenField)Master.FindControl("dur");
                        drtn.Value = candBatch.Duration.ToString();
                    }

                    //PopulateQuestion(candBatch.Id);


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

                    TimeSpan testDuration = new TimeSpan(hour, min, sec);
                    var timeEnding = DateTime.Now;
                    //var ending = timeEnding.AddSeconds(TestdurationSum);

                    var initialTime = tracker.InitialStartTime == null
                                          ? timeEnding
                                          : tracker.InitialStartTime.Value;

                    var lastActiveTime = tracker.CurrentStartTime == null
                                             ? initialTime
                                             : tracker.CurrentStartTime.Value;

                    if (initialTime != null)
                    {
                        var span = (lastActiveTime - initialTime);

                        var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);



                        var cStartTime = timeEnding.Subtract(spentTime);

                        var remaining = testDuration.Subtract(spentTime);

                        var ending = timeEnding.Add(remaining);

                        var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                                       ErecruitHelper.AppendZero(remaining.Minutes),
                                                       ErecruitHelper.AppendZero(remaining.Seconds));


                        if (Master != null)
                        {
                            var minute = (HiddenField)Master.FindControl("minutes");
                            minute.Value = timeString;
                        }
                        // minutes.Value = tracker.EndTime.Value.ToString("M/d/yyyy hh:mm:ss tt");
                        if (Master != null)
                        {
                            var c = (HiddenField)Master.FindControl("candid");
                            c.Value = cand.Id.ToString();
                        }
                        if (Master != null)
                        {
                            var b = (HiddenField)Master.FindControl("batchid");
                            b.Value = candBatch.Id.ToString();
                        }

                        tracker.InitialStartTime = cStartTime;
                        tracker.CurrentStartTime = timeEnding;
                        tracker.RemainingDuration = timeString;
                        tracker.EndTime = ending;
                        _db.SaveChanges();

                    }



                }

                var curr = Session["curr"] ?? 0;
                //var curr = string.IsNullOrEmpty(currPage.Value) ? "0" : currPage.Value;
                var cr = int.Parse(curr.ToString());



                // var prev = Session["prev"] ?? 0;
                //var curr = Session["curr"] ?? 0;
                // var next = Session["next"] ?? 0;

                var sects = (string[])Session["sects"];

                Session["curr"] = int.Parse(curr.ToString());
                // currPage.Value = (int.Parse(next.ToString())).ToString();
                if (cr <= 0)
                {
                    try
                    {
                        var newSection = sects[cr + 1];
                        next_btn.Visible = true;
                        finish_btn.Visible = false;
                        prevPage.Value = cr.ToString();
                        currPage.Value = cr.ToString();
                        nextPage.Value = (cr + 1).ToString();
                        back_btn.Visible = false;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        next_btn.Visible = false;
                        finish_btn.Visible = true;
                        prevPage.Value = cr.ToString();
                        currPage.Value = cr.ToString();
                        nextPage.Value = (cr).ToString();
                        back_btn.Visible = false;
                    }
                }
                else
                {
                    try
                    {
                        var newSection = sects[cr + 1];
                        next_btn.Visible = true;
                        finish_btn.Visible = false;
                        prevPage.Value = (cr - 1).ToString();
                        currPage.Value = cr.ToString();
                        nextPage.Value = (cr + 1).ToString();
                        back_btn.Visible = true;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        next_btn.Visible = false;
                        finish_btn.Visible = true;
                        prevPage.Value = (cr - 1).ToString();
                        currPage.Value = cr.ToString();
                        nextPage.Value = (cr).ToString();
                        back_btn.Visible = true;
                    }
                }

                zel.Value = ErecruitHelper.sha256_hash("elapsed");

            }
            catch (Exception ex)
            {
                Response.Redirect("TestLanding.aspx", false);
            }
        }
        [WebMethod]
        public static string UpdateNextTime(string id, string cid, string bid)
        {

            QuizBookDbEntities1 db = new QuizBookDbEntities1();


            long candid = long.Parse(cid);
            //var b_id = db.T_BatchSet.Where(s => s.CandidateId == candid).Select(x => x.BatchId);
            var candBatch = db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(bid) && s.IsActive.Value);

            var tracker = db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == candid);

            try
            {

                if (tracker != null)
                {
                    tracker.RemainingDuration = id;
                    db.SaveChanges();
                    return "success";
                }

                return "failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        [WebMethod]
        public static string ExpireSubmit(string ansd, string ansdQ, string sAnss, string mAnss, string candId)
        {
            try
            {
                QuizBookDbEntities1 db = new QuizBookDbEntities1();


                long id = long.Parse(candId);
                var b_id = db.T_BatchSet.Where(x => x.CandidateId == id).Select(x => x.BatchId);
                var candBatch = db.T_Batch.FirstOrDefault(v => b_id.Contains(v.Id) && v.IsActive.Value);

                var a = ansd.Split(',');
                var Q = ansdQ.Split(',');
                var s = sAnss.Split(',');
                var M = mAnss.Split(',');

                var ans1 = a[0];
                var Q1 = Q[0];
                var ans2 = a[1];
                var Q2 = Q[1];
                var ans3 = a[2];
                var Q3 = Q[2];
                var ans4 = a[3];
                var Q4 = Q[3];
                var ans5 = a[4];
                var Q5 = Q[4];
                var ans6 = a[5];
                var Q6 = Q[5];

                var singleA1 = s[0];
                var singleA2 = s[1];
                var singleA3 = s[2];
                var singleA4 = s[3];
                var singleA5 = s[4];
                var singleA6 = s[5];

                var MultiA1 = M[0];
                var MultiA2 = M[1];
                var MultiA3 = M[2];
                var MultiA4 = M[3];
                var MultiA5 = M[4];
                var MultiA6 = M[5];


                AnswerQuestion2(Q1, singleA1, MultiA1, id, candBatch.Id);
                AnswerQuestion2(Q2, singleA2, MultiA2, id, candBatch.Id);
                AnswerQuestion2(Q3, singleA3, MultiA3, id, candBatch.Id);
                AnswerQuestion2(Q4, singleA4, MultiA4, id, candBatch.Id);
                AnswerQuestion2(Q5, singleA5, MultiA5, id, candBatch.Id);
                AnswerQuestion2(Q6, singleA6, MultiA6, id, candBatch.Id);

                var tracker = db.T_CTestTracker.FirstOrDefault(y => y.CandidateId == id && y.BatchId == candBatch.Id);
                tracker.CurrentStartTime = DateTime.Now;
                db.SaveChanges();

                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void AnswerQuestion2(string Q_id, string single_AId, string multi_AId, long candId, long batchId)
        {
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            if (!string.IsNullOrEmpty(Q_id))
            {
                if (!string.IsNullOrEmpty(single_AId))
                {
                    _db.T_CandidateAnswers.Add(new T_CandidateAnswers
                    {
                        CandidateId = candId,
                        BatchId = batchId,
                        QuestionId = long.Parse(Q_id),
                        Answer = long.Parse(single_AId),
                        TimeAnswered = DateTime.Now
                    });
                    var temp = _db.T_CandidateTemp.Where(s => s.CandidateId == candId && s.BatchId == batchId && s.Q_Id == long.Parse(Q_id)).FirstOrDefault();
                    temp.Answered = true;
                    _db.SaveChanges();
                }
                else if (!string.IsNullOrEmpty(multi_AId))
                {
                    string[] optionIds = multi_AId.Split(',');
                    foreach (var x in optionIds)
                    {
                        _db.T_CandidateAnswers.Add(new T_CandidateAnswers
                        {
                            CandidateId = candId,
                            BatchId = batchId,
                            QuestionId = long.Parse(Q_id),
                            Answer = long.Parse(x),
                            TimeAnswered = DateTime.Now
                        });
                        var temp = _db.T_CandidateTemp.Where(s => s.CandidateId == candId && s.BatchId == batchId && s.Q_Id == long.Parse(Q_id)).FirstOrDefault();
                        temp.Answered = true;
                        _db.SaveChanges();
                    }
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            try
            {
                Session["curr"] = prevPage.Value;
                var selbatch = Session["SelectedBatch"].ToString();
                var selBatchLong = long.Parse(selbatch);
                var sid = SessionHelper.FetchUserName(Page.Session);
                var cand = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());

                var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);



                LinkButton btn = ((LinkButton)sender);
                var topp = btn.Parent;
                Panel hdfID = (Panel)topp.FindControl("Panel1");
                var r = this.Controls;
                Table t = (Table)topp.FindControl("Quests");
                DoAnswerQuestions(t, cand, batch);



                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == batch.Id);
                tracker.CurrentStartTime = DateTime.Now;
                _db.SaveChanges();
                ////PopulateBackQuestion(candBatch.Id);
                var duration = batch.Duration.ToString();
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

                TimeSpan testDuration = new TimeSpan(hour, min, sec);
                var timeEnding = DateTime.Now;
                // var ending = timeEnding.AddSeconds(TestdurationSum);

                var initialTime = tracker.InitialStartTime == null
                                      ? timeEnding
                                      : tracker.InitialStartTime.Value;

                var lastActiveTime = tracker.CurrentStartTime == null
                                         ? initialTime
                                         : tracker.CurrentStartTime.Value;

                if (initialTime != null)
                {
                    var span = (lastActiveTime - initialTime);

                    var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);



                    var cStartTime = timeEnding.Subtract(spentTime);

                    var remaining = testDuration.Subtract(spentTime);

                    var ending = timeEnding.Add(remaining);

                    var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                                   ErecruitHelper.AppendZero(remaining.Minutes),
                                                   ErecruitHelper.AppendZero(remaining.Seconds));


                    if (Master != null)
                    {
                        var minute = (HiddenField)Master.FindControl("minutes");
                        minute.Value = timeString;
                    }
                    // minutes.Value = tracker.EndTime.Value.ToString("M/d/yyyy hh:mm:ss tt");
                    if (Master != null)
                    {
                        var c = (HiddenField)Master.FindControl("candid");
                        c.Value = cand.Id.ToString();
                    }
                    if (Master != null)
                    {
                        var b = (HiddenField)Master.FindControl("batchid");
                        b.Value = batch.Id.ToString();
                    }

                    tracker.InitialStartTime = cStartTime;
                    tracker.CurrentStartTime = timeEnding;
                    tracker.RemainingDuration = timeString;
                    tracker.EndTime = ending;
                    _db.SaveChanges();


                    Response.Redirect("_CandidateTestPage.aspx", false);



                }

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void next_Click(object sender, EventArgs e)
        {
            try
            {

                Session["curr"] = nextPage.Value;

                var selbatch = Session["SelectedBatch"].ToString();
                var sid = SessionHelper.FetchUserName(Page.Session);
                var selBatchLong = long.Parse(selbatch);
                var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);


                LinkButton btn = ((LinkButton)sender);
                var topp = btn.Parent;
                //var topp = p.Parent;
                Panel hdfID = (Panel)topp.FindControl("Panel1");
                //var bx = Page.FindControl("Panel1");
                //var bp = Page.Controls;
                //Panel p = ((Panel)sender);
                //var x = p.Parent;
                var r = this.Controls;

                Table t = (Table)topp.FindControl("Quests");
                DoAnswerQuestions(t, user, candBatch);

                //var candId = SessionHelper.FetchCandidateId(Session);
                //long id = long.Parse(candId);
                //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == id).Select(x => x.BatchId);
                //var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

                ////Get all the Questions and and answers detail for submit
                ////var ans1 = Q1Answered.Value;
                ////var Q1 = string.IsNullOrEmpty(ans1) ? "" : Q1Id.Value;
                ////var ans2 = Q2Answered.Value;
                ////var Q2 = string.IsNullOrEmpty(ans2) ? "" : Q2Id.Value;
                ////var ans3 = Q3Answered.Value;
                ////var Q3 = string.IsNullOrEmpty(ans3) ? "" : Q3Id.Value;
                ////var ans4 = Q4Answered.Value;
                ////var Q4 = string.IsNullOrEmpty(ans4) ? "" : Q4Id.Value;
                ////var ans5 = Q5Answered.Value;
                ////var Q5 = string.IsNullOrEmpty(ans5) ? "" : Q5Id.Value;
                ////var ans6 = Q6Answered.Value;
                ////var Q6 = string.IsNullOrEmpty(ans6) ? "" : Q6Id.Value;

                ////var singleA1 = Request.Form["single1"];
                ////var singleA2 = Request.Form["single2"];
                ////var singleA3 = Request.Form["single3"];
                ////var singleA4 = Request.Form["single4"];
                ////var singleA5 = Request.Form["single5"];
                ////var singleA6 = Request.Form["single6"];

                ////var MultiA1 = Request.Form["Multi1"];
                ////var MultiA2 = Request.Form["Multi2"];
                ////var MultiA3 = Request.Form["Multi3"];
                ////var MultiA4 = Request.Form["Multi4"];
                ////var MultiA5 = Request.Form["Multi5"];
                ////var MultiA6 = Request.Form["Multi6"];

                ////AnswerQuestion(Q1, singleA1, MultiA1, id, candBatch.Id);
                ////AnswerQuestion(Q2, singleA2, MultiA2, id, candBatch.Id);
                ////AnswerQuestion(Q3, singleA3, MultiA3, id, candBatch.Id);
                ////AnswerQuestion(Q4, singleA4, MultiA4, id, candBatch.Id);
                ////AnswerQuestion(Q5, singleA5, MultiA5, id, candBatch.Id);
                ////AnswerQuestion(Q6, singleA6, MultiA6, id, candBatch.Id);

                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == candBatch.Id);
                tracker.CurrentStartTime = DateTime.Now;
                _db.SaveChanges();

                ////PopulateQuestion(candBatch.Id);



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

                TimeSpan testDuration = new TimeSpan(hour, min, sec);

                var timeEnding = DateTime.Now;
                //var ending = timeEnding.AddSeconds(TestdurationSum);

                var initialTime = tracker.InitialStartTime == null
                                      ? timeEnding
                                      : tracker.InitialStartTime.Value;

                var lastActiveTime = tracker.CurrentStartTime == null
                                         ? initialTime
                                         : tracker.CurrentStartTime.Value;

                if (initialTime != null)
                {
                    var span = (lastActiveTime - initialTime);

                    var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);



                    var cStartTime = timeEnding.Subtract(spentTime);

                    var remaining = testDuration.Subtract(spentTime);

                    var ending = timeEnding.Add(remaining);

                    var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                                   ErecruitHelper.AppendZero(remaining.Minutes),
                                                   ErecruitHelper.AppendZero(remaining.Seconds));


                    if (Master != null)
                    {
                        var minute = (HiddenField)Master.FindControl("minutes");
                        minute.Value = timeString;
                    }
                    // minutes.Value = tracker.EndTime.Value.ToString("M/d/yyyy hh:mm:ss tt");
                    if (Master != null)
                    {
                        var c = (HiddenField)Master.FindControl("candid");
                        c.Value = user.Id.ToString();
                    }
                    if (Master != null)
                    {
                        var b = (HiddenField)Master.FindControl("batchid");
                        b.Value = candBatch.Id.ToString();
                    }

                    tracker.InitialStartTime = cStartTime;
                    tracker.CurrentStartTime = timeEnding;
                    tracker.RemainingDuration = timeString;
                    tracker.EndTime = ending;
                    _db.SaveChanges();


                }

                Response.Redirect("_CandidateTestPage.aspx", false);

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void finish_Click(object sender, EventArgs e)
        {
            try
            {

                Session["curr"] = nextPage.Value;
                var selbatch = Session["SelectedBatch"].ToString();
                var sid = SessionHelper.FetchUserName(Page.Session);
                var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                var selBatchLong = long.Parse(selbatch);
                var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);
                LinkButton btn = ((LinkButton)sender);
                var topp = btn.Parent;
                //var topp = p.Parent;
                Panel hdfID = (Panel)topp.FindControl("Panel1");
                //var bx = Page.FindControl("Panel1");
                //var bp = Page.Controls;
                //Panel p = ((Panel)sender);
                //var x = p.Parent;
                var r = this.Controls;

                Table t = (Table)topp.FindControl("Quests");
                DoAnswerQuestions(t, user, candBatch);
                _db.MarkUnAnswered_sp(candBatch.Id, user.Id);
                _db.MarkCandidatquizUser_sp(candBatch.Id, user.Id);
                //var candId = SessionHelper.FetchCandidateId(Session);
                //long id = long.Parse(candId);
                //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == id).Select(x => x.BatchId);
                //var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

                //Get all the Questions and and answers detail for submit
                //var ans1 = Q1Answered.Value;
                //var Q1 = string.IsNullOrEmpty(ans1)?"":Q1Id.Value;
                //var ans2 = Q2Answered.Value;
                //var Q2 = string.IsNullOrEmpty(ans2) ? "" : Q2Id.Value;
                //var ans3 = Q3Answered.Value;
                //var Q3 = string.IsNullOrEmpty(ans3) ? "" : Q3Id.Value;
                //var ans4 = Q4Answered.Value;
                //var Q4 = string.IsNullOrEmpty(ans4) ? "" : Q4Id.Value;
                //var ans5 = Q5Answered.Value;
                //var Q5 = string.IsNullOrEmpty(ans5) ? "" : Q5Id.Value;
                //var ans6 = Q6Answered.Value;
                //var Q6 = string.IsNullOrEmpty(ans6) ? "" : Q6Id.Value;

                //var singleA1 = Request.Form["single1"];
                //var singleA2 = Request.Form["single2"];
                //var singleA3 = Request.Form["single3"];
                //var singleA4 = Request.Form["single4"];
                //var singleA5 = Request.Form["single5"];
                //var singleA6 = Request.Form["single6"];

                //var MultiA1 = Request.Form["Multi1"];
                //var MultiA2 = Request.Form["Multi2"];
                //var MultiA3 = Request.Form["Multi3"];
                //var MultiA4 = Request.Form["Multi4"];
                //var MultiA5 = Request.Form["Multi5"];
                //var MultiA6 = Request.Form["Multi6"];


                //AnswerQuestion(Q1, singleA1, MultiA1, id, candBatch.Id);
                //AnswerQuestion(Q2, singleA2, MultiA2, id, candBatch.Id);
                //AnswerQuestion(Q3, singleA3, MultiA3, id, candBatch.Id);
                //AnswerQuestion(Q4, singleA4, MultiA4, id, candBatch.Id);
                //AnswerQuestion(Q5, singleA5, MultiA5, id, candBatch.Id);
                //AnswerQuestion(Q6, singleA6, MultiA6, id, candBatch.Id);

                var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == candBatch.Id);
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

                TimeSpan testDuration = new TimeSpan(hour, min, sec);

                var timeEnding = DateTime.Now;
                //var ending = timeEnding.AddSeconds(TestdurationSum);

                var initialTime = tracker.InitialStartTime == null
                                      ? timeEnding
                                      : tracker.InitialStartTime.Value;

                var lastActiveTime = tracker.CurrentStartTime == null
                                         ? initialTime
                                         : tracker.CurrentStartTime.Value;

                if (initialTime != null)
                {
                    var span = (lastActiveTime - initialTime);

                    var spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);



                    var cStartTime = timeEnding.Subtract(spentTime);

                    var remaining = testDuration.Subtract(spentTime);

                    var ending = timeEnding.Add(remaining);

                    var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours),
                                                   ErecruitHelper.AppendZero(remaining.Minutes),
                                                   ErecruitHelper.AppendZero(remaining.Seconds));

                    tracker.CurrentStartTime = DateTime.Now;
                    tracker.RemainingDuration = timeString;
                    tracker.InSession = false;
                    tracker.Finished = true;
                    _db.SaveChanges();

                }
                // tracker.CurrentStartTime = DateTime.Now;
                //_db.SaveChanges();
                //var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == id);


                // ErecruitHelper.CheckBatches(_db,candBatch);          
                Response.Redirect("CandidateTestResult.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }

        private void DoAnswerQuestions(Table t, QuizBook.Candidate user, T_Batch batch)
        {
            List<Table> tabs = new List<Table>();
            List<RadioButton> options = new List<RadioButton>();
            foreach (TableRow tr in t.Rows)
            {
                foreach (TableCell tc in tr.Cells)
                {
                    foreach (Control c in tc.Controls)
                    {
                        if (c.GetType() == typeof(Table))
                        {
                            Table tb = (Table)c;
                            // var qid = questionTable.ID;
                            // tabs.Add(questionTable);
                            var qid = tb.ID;
                            var Q_id = qid.Split('_');
                            var lr = tb.Rows.Count;
                            var lastrow = tb.Rows[lr - 1];
                            var lc = lastrow.Cells.Count;
                            var lastcell = lastrow.Cells[lc - 1];

                            foreach (var lcc in lastcell.Controls)
                            {
                                if (lcc.GetType() == typeof(RadioButton))
                                {
                                    RadioButton rb = (RadioButton)lcc;
                                    var queId = long.Parse(Q_id[1]);
                                    var answered = _db.T_CandidateAnswers.FirstOrDefault(s => s.BatchId == batch.Id && s.CandidateId == user.Id && s.QuestionId == queId);
                                    if (rb.Enabled && rb.Checked && answered == null)
                                    {
                                        var ansId = long.Parse(rb.ID);
                                        options.Add(rb);
                                        _db.T_CandidateAnswers.Add(new T_CandidateAnswers
                                        {
                                            CandidateId = user.Id,
                                            BatchId = batch.Id,
                                            QuestionId = queId,
                                            Answer = ansId,
                                            TimeAnswered = DateTime.Now
                                        });
                                        _db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AnswerQuestion(string Q_id, string single_AId, string multi_AId, long candId, long batchId)
        {

            if (!string.IsNullOrEmpty(Q_id))
            {
                if (!string.IsNullOrEmpty(single_AId))
                {
                    _db.T_CandidateAnswers.Add(new T_CandidateAnswers
                    {
                        CandidateId = candId,
                        BatchId = batchId,
                        QuestionId = long.Parse(Q_id),
                        Answer = long.Parse(single_AId),
                        TimeAnswered = DateTime.Now
                    });
                    var temp = _db.T_CandidateTemp.Where(s => s.CandidateId == candId && s.BatchId == batchId && s.Q_Id == long.Parse(Q_id)).FirstOrDefault();
                    temp.Answered = true;
                    _db.SaveChanges();
                }
                else if (!string.IsNullOrEmpty(multi_AId))
                {
                    string[] optionIds = multi_AId.Split(',');
                    foreach (var x in optionIds)
                    {
                        _db.T_CandidateAnswers.Add(new T_CandidateAnswers
                        {
                            CandidateId = candId,
                            BatchId = batchId,
                            QuestionId = long.Parse(Q_id),
                            Answer = long.Parse(x),
                            TimeAnswered = DateTime.Now
                        });
                        var temp = _db.T_CandidateTemp.Where(s => s.CandidateId == candId && s.BatchId == batchId && s.Q_Id == long.Parse(Q_id)).FirstOrDefault();
                        temp.Answered = true;
                        _db.SaveChanges();
                    }
                }
            }
        }

        private void ConstructOptions(int index, long candidateid, long batchid, T_Question q, T_CandidateTemp temp, Label QuestionNumber, System.Web.UI.HtmlControls.HtmlGenericControl QuestionDetails,
            System.Web.UI.HtmlControls.HtmlInputHidden QuestionId, System.Web.UI.HtmlControls.HtmlGenericControl optionspan, System.Web.UI.HtmlControls.HtmlInputHidden Answered)
        {
            var answers = _db.T_CandidateAnswers.Where(s => s.QuestionId == q.Id && s.CandidateId == candidateid && s.BatchId == batchid).Select(x => x.Answer).ToList();
            QuestionNumber.Text = temp.Q_Index.ToString();
            //var q = questions[0];
            QuestionDetails.InnerHtml = q.Details;
            QuestionId.Value = q.Id.ToString();
            var optionType = _db.T_QOptionType.Where(s => s.Id == q.OptionType).Select(x => x.Name).FirstOrDefault();
            var optionHTML = "<table style='border-bottom:1px solid #FFFFFF;'>";
            var options = _db.T_Option.Where(s => s.Q_Id == q.Id).ToList();
            if (optionType == ErecruitHelper.OptionType.Single.ToString())
            {
                foreach (var opt in options)
                {
                    if (temp.Answered.Value)
                    {
                        Answered.Value = "1";
                        if (answers.Contains(opt.Id))
                        {
                            optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input id='" + opt.Id + "' name='single" + index + "' type='radio' value='" + opt.Id + "' disabled='disabled' checked='checked' /></td><td style='padding:10px 10px 10px 10px;' ><label for='" + opt.Id + "' >" + opt.Details + "</label></td></tr>";
                        }
                        else
                        {
                            optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input   id='" + opt.Id + "'  name='single" + index + "' type='radio' value='" + opt.Id + "' disabled='disabled'  /></td><td style='padding:10px 10px 10px 10px;' ><label for='" + opt.Id + "' >" + opt.Details + "</label></td></tr>";
                        }
                    }
                    else
                    {
                        Answered.Value = "0";
                        optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input id='" + opt.Id + "' name='single" + index + "' type='radio' value='" + opt.Id + "' /></td><td style='padding:10px 10px 10px 10px;' ><label for='" + opt.Id + "' >" + opt.Details + "</label></td></tr>";
                    }
                }
            }
            else
            {
                //    <input id="Checkbox1" type="checkbox" />
                foreach (var opt in options)
                {
                    if (temp.Answered.Value)
                    {
                        Answered.Value = "1";
                        if (answers.Contains(opt.Id))
                        {
                            optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input id='" + (options.IndexOf(opt) + 1) + "'  name='Multi" + index + "' type='checkbox'  value='" + opt.Id + "' disabled='disabled' checked='checked' /></td><td style='padding:10px 10px 10px 10px;'><label for='" + opt.Id + "'>" + opt.Details + "</label></td></tr>";
                        }
                        else
                        {
                            optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input id='" + (options.IndexOf(opt) + 1) + "'  name='Multi" + index + "' type='checkbox' value='" + opt.Id + "' disabled='disabled' /></td><td style='padding:10px 10px 10px 10px;'><label for='" + opt.Id + "'>" + opt.Details + "</label></td></tr>";
                        }
                    }
                    else
                    {
                        Answered.Value = "0";
                        optionHTML = optionHTML + "<tr><td style='padding:10px 10px 10px 10px;'><input id='" + (options.IndexOf(opt) + 1) + "'  name='Multi" + index + "' type='checkbox'  value='" + opt.Id + "' /></td><td style='padding:10px 10px 10px 10px;'><label for='" + opt.Id + "'>" + opt.Details + "</label></td></tr>";
                    }
                }

            }

            optionspan.InnerHtml = optionHTML + "</table>";
        }

        //Populate Questions on display for a press of the Next button
        //private void PopulateQuestion(long BatchId)
        //{

        //    var candId = SessionHelper.FetchCandidateId(Session);

        //    List<T_CandidateTemp> Q = new List<T_CandidateTemp>();
        //    List<T_CandidateTemp> QID = new List<T_CandidateTemp>();

        //    if (!string.IsNullOrEmpty(candId))
        //    {
        //        long id = long.Parse(candId);
        //        var b_id = _db.T_BatchSet.Where(s => s.CandidateId == id).Select(x => x.BatchId);
        //        var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

        //        long firstIndex = string.IsNullOrEmpty(FirstQ.Value) ? 0 : long.Parse(FirstQ.Value);
        //        long lastIndex = string.IsNullOrEmpty(LastQ.Value) ? 0 : long.Parse(LastQ.Value);

        //        int totQuest = _db.T_CandidateTemp.Count(s => s.CandidateId == id && s.BatchId == BatchId);

        //        if (Master != null)
        //        {
        //            var QCount = (Literal)Master.FindControl("QuestCount");
        //            QCount.Text = totQuest+" Question(s)";
        //        }

        //        int rem = _db.T_CandidateTemp.Count(s => s.Q_Index > lastIndex && s.CandidateId == id && s.BatchId == BatchId);

        //        if (rem > 0)
        //        {
        //            Q.Clear();
        //            QID.Clear();
        //            Q = _db.T_CandidateTemp.Where(s => s.CandidateId == id && s.BatchId == BatchId).OrderBy(x => x.Q_Index).ToList();

        //            var pIds = Q.Select(s => s.PreambleId).Distinct().ToList();

        //            int index = (SessionHelper.FetchPageIndex(Session));// SessionHelper.FetchPageIndex(Session) < 0 ? 0 : (SessionHelper.FetchPageIndex(Session));
        //            if ((index) == -1)
        //            {
        //                index = (SessionHelper.FetchPageIndex(Session) + 1);
        //                SessionHelper.SetPageIndex((index), Session);
        //            }

        //            long? preambleID = pIds.FirstOrDefault(x =>x==(index));

        //            var PQ = Q.Where(s => s.Q_Index > lastIndex && s.PreambleId == preambleID).ToList();

        //            if (PQ.Count() > 6)
        //            {
        //                QID = PQ.Take(6).ToList();
        //                if (preambleID > 0)
        //                {
        //                    ppSpan.Visible = true;
        //                    PreamblePanel.Visible = true;
        //                    ppSpan.InnerHtml = " ";
        //                    var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                    if (preamble != null)
        //                    {
        //                        ppSpan.InnerHtml = preamble.Body;
        //                    }
        //                }
        //                else
        //                {
        //                    ppSpan.Visible = false;
        //                    PreamblePanel.Visible = false;
        //                }
        //                SessionHelper.SetPageIndex((index), Session);
        //            }
        //            else if (PQ.Count() != 0)
        //            {
        //                QID = PQ;
        //                if (preambleID > 0)
        //                {
        //                    ppSpan.Visible = true;
        //                    PreamblePanel.Visible = true;
        //                    ppSpan.InnerHtml = " ";
        //                    var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                    if (preamble != null)
        //                    {
        //                        ppSpan.InnerHtml = preamble.Body;
        //                    }
        //                }
        //                else
        //                {
        //                    ppSpan.Visible = false;
        //                    PreamblePanel.Visible = false;
        //                }
        //                var l = pIds.FirstOrDefault(x => x == (index +1));
        //                if (l != null)
        //                {
        //                    SessionHelper.SetPageIndex((index + 1), Session);
        //                }
        //            }

        //            while (PQ.Count() == 0)
        //            {
        //                index = index + 1;

        //                preambleID = pIds.FirstOrDefault(x => x == (index));

        //                PQ = Q.Where(s => s.Q_Index > lastIndex && s.PreambleId == preambleID).ToList();

        //                if (PQ.Count() > 6)
        //                {
        //                    QID = PQ.Take(6).ToList();
        //                    if (preambleID > 0)
        //                    {
        //                        ppSpan.Visible = true;
        //                        PreamblePanel.Visible = true;
        //                        ppSpan.InnerHtml = " ";
        //                        var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                        if (preamble != null)
        //                        {
        //                            ppSpan.InnerHtml = preamble.Body;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ppSpan.Visible = false;
        //                        PreamblePanel.Visible = false;
        //                    }
        //                    SessionHelper.SetPageIndex((index), Session);
        //                }
        //                else 
        //                {
        //                    QID = PQ;
        //                    if (preambleID > 0)
        //                    {
        //                        ppSpan.Visible = true;
        //                        PreamblePanel.Visible = true;
        //                        ppSpan.InnerHtml = " ";
        //                        var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                        if (preamble != null)
        //                        {
        //                            ppSpan.InnerHtml = preamble.Body;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ppSpan.Visible = false;
        //                        PreamblePanel.Visible = false;
        //                    }
        //                    var l = pIds.FirstOrDefault(x => x == (index + 1));
        //                    if (l != null)
        //                    {
        //                        SessionHelper.SetPageIndex((index + 1), Session);
        //                    }
        //                }

        //            }


        //           // var PQ = Q.Where(s => s.Q_Index > lastIndex && s.PreambleId == preambleID).ToList();




        //            //QID = Q.Where(s => s.Q_Index > lastIndex && s.PreambleId == pIds[index]).ToList();

        //            // var segmentGroup = Q.Where(s => s.Q_Index > lastIndex).Take(6).GroupBy(s => s.PreambleId).OrderBy(s => s.Key);

        //            int qlength = QID.Count();
        //            if (qlength >= 1)
        //            {


        //                Q1.Visible = true;
        //                A1.Visible = true;
        //                Label1.Visible = true;

        //                    var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[0].Q_Id && s.IsActive.Value);

        //                    var typ = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == q.TypeId);
        //                    grpSpan.InnerHtml = typ.Name;
        //                 GroupPanel.Visible = true;
        //                grpSpan.Visible = true;

        //                    ConstructOptions(1, id, candBatch.Id, q, QID[0], Label1, q1Span, Q1Id, a1span,Q1Answered);




        //            }
        //            else
        //            {
        //                Q1.Visible = false;
        //                A1.Visible = false;
        //                Label1.Visible = false;
        //               // Panel1.Visible = false;
        //            }
        //            if (qlength >= 2)
        //            {

        //                Q2.Visible = true;
        //                A2.Visible = true;
        //                Label2.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[1].Q_Id && s.IsActive.Value);

        //                ConstructOptions(2, id, candBatch.Id, q, QID[1], Label2, q2Span, Q2Id, a2span,Q2Answered);

        //            }
        //            else
        //            {
        //                Q2.Visible = false;
        //                A2.Visible = false;
        //                Label2.Visible = false;
        //                //Panel2.Visible = false;
        //            }
        //            if (qlength >= 3)
        //            {

        //                Q3.Visible = true;
        //                A3.Visible = true;
        //                Label3.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[2].Q_Id && s.IsActive.Value);

        //                ConstructOptions(3, id, candBatch.Id, q, QID[2], Label3, q3Span, Q3Id, a3span,Q3Answered);


        //            }
        //            else
        //            {
        //                Q3.Visible = false;
        //                A3.Visible = false;
        //                Label3.Visible = false;
        //                //Panel3.Visible = false;
        //            }
        //            if (qlength >= 4)
        //            {

        //                Q4.Visible = true;
        //                A4.Visible = true;
        //                Label4.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[3].Q_Id && s.IsActive.Value);

        //                ConstructOptions(4, id, candBatch.Id, q, QID[3], Label4, q4Span, Q4Id, a4span,Q4Answered);

        //            }
        //            else
        //            {
        //                Q4.Visible = false;
        //                A4.Visible = false;
        //                Label4.Visible = false;
        //                //Panel4.Visible = false;
        //            }

        //            if (qlength >= 5)
        //            {

        //                Q5.Visible = true;
        //                A5.Visible = true;
        //                Label5.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[4].Q_Id && s.IsActive.Value);

        //                ConstructOptions(5, id, candBatch.Id, q, QID[4], Label5, q5Span, Q5Id, a5span, Q5Answered);

        //            }
        //            else
        //            {
        //                Q5.Visible = false;
        //                A5.Visible = false;
        //                Label5.Visible = false;
        //                //Panel4.Visible = false;
        //            }
        //            if (qlength >= 6)
        //            {

        //                Q6.Visible = true;
        //                A6.Visible = true;
        //                Label6.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[5].Q_Id && s.IsActive.Value);

        //                ConstructOptions(6, id, candBatch.Id, q, QID[5], Label6, q6Span, Q6Id, a6span, Q6Answered);

        //            }
        //            else
        //            {
        //                Q6.Visible = false;
        //                A6.Visible = false;
        //                Label6.Visible = false;
        //                //Panel4.Visible = false;
        //            }

        //            FirstQ.Value = QID.FirstOrDefault().Q_Index.ToString();
        //            LastQ.Value = QID.LastOrDefault().Q_Index.ToString();
        //            int remaining = Q.Count(s => s.Q_Index > QID.LastOrDefault().Q_Index);
        //            if (QID.FirstOrDefault().Q_Index <= 1)
        //            {
        //                back.Enabled = false;
        //            }
        //            else
        //            {
        //                back.Enabled = true;
        //            }
        //            if (remaining > 0)
        //            {
        //                finish.Visible = false;
        //                next.Visible = true;
        //            }
        //            else
        //            {
        //                finish.Visible = true;
        //                next.Visible = false;
        //            }


        //        }

        //    }
        //}
        //Populate Questions on display for a press of the Back button
        //private void PopulateBackQuestion(long BatchId)
        //{
        //    var candId = SessionHelper.FetchCandidateId(Session);
        //    List<T_CandidateTemp> Q = new List<T_CandidateTemp>();
        //    List<T_CandidateTemp> QID = new List<T_CandidateTemp>();
        //    if (!string.IsNullOrEmpty(candId))
        //    {
        //        long id = long.Parse(candId);
        //        var b_id = _db.T_BatchSet.Where(s => s.CandidateId == id).Select(x => x.BatchId);
        //        var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

        //        long firstIndex = string.IsNullOrEmpty(FirstQ.Value) ? 0 : long.Parse(FirstQ.Value);
        //        long lastIndex = string.IsNullOrEmpty(LastQ.Value) ? 0 : long.Parse(LastQ.Value);

        //        int totQuest = _db.T_CandidateTemp.Count(s => s.CandidateId == id && s.BatchId == BatchId);

        //        if (Master != null)
        //        {
        //            var QCount = (Literal)Master.FindControl("QuestCount");
        //            QCount.Text = totQuest + " Question(s)";
        //        }

        //        int rem = _db.T_CandidateTemp.Count(s => s.Q_Index < firstIndex && s.CandidateId == id && s.BatchId == BatchId);

        //        if (rem > 0)
        //        {
        //            Q.Clear();
        //            QID.Clear();
        //            Q = _db.T_CandidateTemp.Where(s => s.CandidateId == id && s.BatchId == BatchId).OrderBy(x => x.Q_Index).ToList();

        //            var pIds = Q.Select(s => s.PreambleId).Distinct().ToList();


        //           // int index = (SessionHelper.FetchPageIndex(Session)-1);


        //            int index = (SessionHelper.FetchPageIndex(Session));// SessionHelper.FetchPageIndex(Session) < 0 ? 0 : (SessionHelper.FetchPageIndex(Session));
        //            if ((index) == -1)
        //            {
        //                index = (SessionHelper.FetchPageIndex(Session) + 1);
        //                SessionHelper.SetPageIndex((index), Session);
        //            }

        //            long? preambleID = pIds.FirstOrDefault(x => x == (index));

        //            var PQ = Q.Where(s => s.Q_Index < firstIndex && s.PreambleId == preambleID).OrderByDescending(x => x.Q_Index).ToList();
        //            if (PQ.Count() > 6)
        //            {
        //                QID = PQ.Take(6).ToList();

        //                if (preambleID > 0)
        //                {
        //                    ppSpan.Visible = true;
        //                    PreamblePanel.Visible = true;
        //                    ppSpan.InnerHtml = " ";
        //                    var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                    if (preamble != null)
        //                    {
        //                        ppSpan.InnerHtml = preamble.Body;
        //                    }
        //                }
        //                else
        //                {
        //                    ppSpan.Visible = false;
        //                    PreamblePanel.Visible = false;
        //                }
        //                QID = QID.OrderBy(x => x.Q_Index).ToList();
        //                SessionHelper.SetPageIndex((index), Session);
        //            }

        //            else if (PQ.Count() != 0)
        //            {
        //                QID = PQ;

        //                if (preambleID > 0)
        //                {
        //                    ppSpan.Visible = true;
        //                    PreamblePanel.Visible = true;
        //                    ppSpan.InnerHtml = " ";
        //                    var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                    if (preamble != null)
        //                    {
        //                        ppSpan.InnerHtml = preamble.Body;
        //                    }
        //                }
        //                else
        //                {
        //                    ppSpan.Visible = false;
        //                    PreamblePanel.Visible = false;
        //                }
        //                QID = QID.OrderBy(x => x.Q_Index).ToList();
        //                var l = pIds.FirstOrDefault(x => x == (index - 1));
        //                if(l!=null){
        //                SessionHelper.SetPageIndex((index - 1), Session);
        //                }
        //            }

        //            while (PQ.Count() == 0)
        //            {
        //                index = index - 1;

        //                preambleID = pIds.FirstOrDefault(x => x == (index));

        //                PQ = Q.Where(s => s.Q_Index < firstIndex && s.PreambleId == preambleID).OrderByDescending(x => x.Q_Index).ToList();

        //                if (PQ.Count() > 6)
        //                {
        //                    QID = PQ.Take(6).ToList();

        //                    if (preambleID > 0)
        //                    {
        //                        ppSpan.Visible = true;
        //                        PreamblePanel.Visible = true;
        //                        ppSpan.InnerHtml = " ";
        //                        var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                        if (preamble != null)
        //                        {
        //                            ppSpan.InnerHtml = preamble.Body;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ppSpan.Visible = false;
        //                        PreamblePanel.Visible = false;
        //                    }
        //                    QID = QID.OrderBy(x => x.Q_Index).ToList();
        //                    SessionHelper.SetPageIndex((index), Session);
        //                }
        //                else
        //                {
        //                    QID = PQ;

        //                    if (preambleID > 0)
        //                    {
        //                        ppSpan.Visible = true;
        //                        PreamblePanel.Visible = true;
        //                        ppSpan.InnerHtml = " ";
        //                        var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == preambleID);
        //                        if (preamble != null)
        //                        {
        //                            ppSpan.InnerHtml = preamble.Body;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ppSpan.Visible = false;
        //                        PreamblePanel.Visible = false;
        //                    }
        //                    QID = QID.OrderBy(x => x.Q_Index).ToList();
        //                    //SessionHelper.SetPageIndex((index - 1), Session);

        //                    SessionHelper.SetPageIndex((index), Session);
        //                }
        //            }

        //            //PQ = PQ.OrderBy(x => x.Q_Index).ToList();


        //            //QID = Q.Where(s => s.Q_Index < firstIndex && s.PreambleId == pIds[index]).OrderByDescending(x => x.Q_Index).ToList();
        //            //QID = QID.OrderBy(x => x.Q_Index).ToList();

        //            int qlength = QID.Count();
        //            if (qlength >= 1)
        //            {

        //                Q1.Visible = true;
        //                A1.Visible = true;
        //                Label1.Visible = true;

        //                    var q = _db.T_Question.Where(s => s.Id == QID[0].Q_Id && s.IsActive.Value).FirstOrDefault();

        //                    var typ = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == q.TypeId);
        //                    grpSpan.InnerHtml = typ.Name;
        //                    GroupPanel.Visible = true;
        //                    grpSpan.Visible = true;

        //                    ConstructOptions(1, id, candBatch.Id, q, QID[0], Label1, q1Span, Q1Id, a1span,Q1Answered);




        //            }
        //            else
        //            {
        //                Q1.Visible = false;
        //                A1.Visible = false;
        //                Label1.Visible = false;
        //                //Panel1.Visible = false;
        //            }
        //            if (qlength >= 2)
        //            {
        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[1].Q_Id && s.IsActive.Value);

        //                ConstructOptions(2, id, candBatch.Id, q, QID[1], Label2, q2Span, Q2Id, a2span,Q2Answered);

        //            }
        //            else
        //            {
        //                Q2.Visible = false;
        //                A2.Visible = false;
        //                Label2.Visible = false;
        //                //Panel2.Visible = false;
        //            }
        //            if (qlength >= 3)
        //            {

        //                Q3.Visible = true;
        //                A3.Visible = true;
        //                Label3.Visible = true;


        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[2].Q_Id && s.IsActive.Value);

        //                ConstructOptions(3, id, candBatch.Id, q, QID[2], Label3, q3Span, Q3Id, a3span,Q3Answered);


        //            }
        //            else
        //            {
        //                Q3.Visible = false;
        //                A3.Visible = false;
        //                Label3.Visible = false;
        //                //Panel3.Visible = false;
        //            }
        //            if (qlength >= 4)
        //            {
        //                Q4.Visible = true;
        //                A4.Visible = true;
        //                Label4.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[3].Q_Id && s.IsActive.Value);

        //                ConstructOptions(4, id, candBatch.Id, q, QID[3], Label4, q4Span, Q4Id, a4span,Q4Answered);

        //            }
        //            else
        //            {
        //                Q4.Visible = false;
        //                A4.Visible = false;
        //                Label4.Visible = false;
        //              //  Panel4.Visible = false;
        //            }
        //            if (qlength >= 5)
        //            {

        //                Q5.Visible = true;
        //                A5.Visible = true;
        //                Label5.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[4].Q_Id && s.IsActive.Value);

        //                ConstructOptions(5, id, candBatch.Id, q, QID[4], Label5, q5Span, Q5Id, a5span, Q5Answered);

        //            }
        //            else
        //            {
        //                Q5.Visible = false;
        //                A5.Visible = false;
        //                Label5.Visible = false;
        //                //Panel4.Visible = false;
        //            }
        //            if (qlength >= 6)
        //            {

        //                Q6.Visible = true;
        //                A6.Visible = true;
        //                Label6.Visible = true;

        //                var q = _db.T_Question.FirstOrDefault(s => s.Id == QID[5].Q_Id && s.IsActive.Value);

        //                ConstructOptions(6, id, candBatch.Id, q, QID[5], Label6, q6Span, Q6Id, a6span, Q6Answered);

        //            }
        //            else
        //            {
        //                Q6.Visible = false;
        //                A6.Visible = false;
        //                Label6.Visible = false;
        //                //Panel4.Visible = false;
        //            }

        //            FirstQ.Value = QID.FirstOrDefault().Q_Index.ToString();
        //            LastQ.Value = QID.LastOrDefault().Q_Index.ToString();
        //            int remaining = Q.Count(s => s.Q_Index > QID.LastOrDefault().Q_Index);
        //            if (QID.FirstOrDefault().Q_Index <= 1)
        //            {
        //                back.Enabled = false;
        //            }
        //            else
        //            {
        //                back.Enabled = true;
        //            }
        //            if (remaining > 0)
        //            {
        //                finish.Visible = false;
        //                next.Visible = true;
        //            }
        //            else
        //            {
        //                finish.Visible = true;
        //                next.Visible = false;
        //            }

        //           // SessionHelper.SetPageIndex((index), Session);
        //        }

        //    }
        //}
    }
}