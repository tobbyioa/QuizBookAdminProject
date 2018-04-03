using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using QuizBook.Model;
using System.IO;

namespace QuizBook.Views
{
    public partial class ViewTestScore : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManageTestResults)
            {

           
                var c = SessionHelper.FetchCandidateCode(Session);
                if (!string.IsNullOrEmpty(c))
                {

                    var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == c);
                    if (!(cand == null))
                    {
                        var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId).ToList();

                        if (b_id.Count() != 0)
                        {
                            var bs = new T_BatchSet() ;
                            var candBatch = new T_Batch();
                           
                                if (Session["BatchSetId"] != null)
                                {
                                    bs = _db.T_BatchSet.FirstOrDefault(s => s.Id == long.Parse(Session["BatchSetId"].ToString()));
                                    candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == bs.BatchId);
                                    var b_set = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).ToList();
                                    var quests = b_set.Select(a => new PrevBatchGridModel
                                    {
                                        ID = a.Id,
                                        BatchName = ErecruitHelper.getBatchName((long)a.BatchId),
                                        Code = a.Finished == true ? ErecruitHelper.getCandidateCode((long)a.CandidateId) + "," + a.Id : ErecruitHelper.getCandidateCode((long)a.CandidateId),
                                        DateTaken = a.Finished == true ? a.TimeStarted.ToString() : "Not Finished."
                                    }).Distinct().ToList();
                                    batchHistory.DataSource = quests;
                                    batchHistory.DataBind();
                                    batchHistoryPanel.Visible = true;
                                }
                                else
                                {
                                   bs = _db.T_BatchSet.FirstOrDefault(s => s.CandidateId == cand.Id);
                                   candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == bs.BatchId);
                                }
                                
                                if (bs.Finished == true)
                                {
                                    int totalQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == candBatch.Id);
                                    int correct = _db.T_CandidateAnswers.Count(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id && s.Correct == true);
                                    double percentage = (double)correct / totalQuestions;
                                    percentage = Math.Round((percentage * 100), 2);

                                    var rsltTxt = "Candidate Name: " + cand.FirstName + " " + cand.LastName + "<br /><br />Got " + correct + " question(s)  out of " + totalQuestions + " questions.<br /><br />Percentage Score: " + percentage + " %";

                                    name.Text = rsltTxt;
                                    CID.Value = cand.Code;
                                    BID.Value = candBatch.Id.ToString();
                                    BindScoreGrid(cand.Id, candBatch);
                                }
                                else
                                {
                                    var rsltTxt = "The candidate has not concluded the test.";

                                    name.Text = rsltTxt;
                                    batchHistoryPanel.Visible = false;
                                    ScoreListPanel.Visible = false;
                                }
                           
                        }
                        else
                        {
                            resultLbl.Text = "The candidate has not been assigned to a test batch.";
                            batchHistoryPanel.Visible = false;
                            ScoreListPanel.Visible = false;
                            
                        }
                    }
                    else
                    {
                        resultLbl.Text = "This is not a valid candidate code";
                        batchHistoryPanel.Visible = false;
                        ScoreListPanel.Visible = false;
                    }
                
            }
            }
            else
            {
                batchHistoryPanel.Visible = false;
                ScoreListPanel.Visible = false;
                Response.Redirect("NoPermission.aspx", false);
            }
        }

        protected void BindScoreGrid(long id, T_Batch bid)
        {
            //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == id).Select(x => x.BatchId);
            //var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
            var candBatch = bid;
            var b_question = _db.T_BatchQuestions.Where(s =>s.BatchId == candBatch.Id).Select(s => s.QuestionId);

            var quests = _db.T_CandidateAnswers.Where(s => s.CandidateId == id && s.BatchId == candBatch.Id).Select(a => new TestScoreGridModel
                {
                    QuestionNo = a.QuestionId.Value,
                    OptionType = ErecruitHelper.getQOptionTypeName(a.QuestionId.Value),
                    CandidateOptions = ErecruitHelper.GetCandidateOptions(id, candBatch.Id, a.QuestionId.Value),
                    Url = a.Correct.Value == true ? "../Images/accept.png" : "../Images/delete.png",
                    Alt = a.Correct.Value == true ? "Correct":"Wrong"
                }).Distinct().ToList();
            var answered = quests.Select(s =>s.QuestionNo);
            var unanswered = _db.T_Question.Where(s => b_question.Contains(s.Id) && !answered.Contains(s.Id)).Select(a => new TestScoreGridModel
            {
                QuestionNo = a.Id,
                OptionType = ErecruitHelper.getQOptionTypeName(a.Id),
                CandidateOptions = "Unanswered",
                Url = "../Images/help.png",
                Alt = "?"
            }).Distinct().ToList();

            int i = quests.Count();
            if (i > 0)
            {
                quests.InsertRange(quests.Count() - 1, unanswered);
            }
            else
            {
                quests.InsertRange(0,unanswered); 
            }
                 
                ScoreList.DataSource = quests;
                ScoreList.DataBind();
                ScoreListPanel.Visible = true;
        }

        protected void check_Click(object sender, EventArgs e)
        {
            var code = Code.Text;

            var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);
            if (!(cand == null))
            {

                var b_set = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).ToList();
                int count = b_set.Count();
                if (count > 1)
                {
                    var quests = b_set.Select(a => new PrevBatchGridModel
                    {
                       ID = a.Id,
                       BatchName = ErecruitHelper.getBatchName((long)a.BatchId),
                       Code = a.Finished == true ? ErecruitHelper.getCandidateCode((long)a.CandidateId) + "," + a.Id : ErecruitHelper.getCandidateCode((long)a.CandidateId),
                       DateTaken = a.Finished == true ? ErecruitHelper.GetDateStringFromDate((DateTime)a.TimeStarted) : "Not Finished."
                    }).Distinct().ToList();
                    batchHistory.DataSource = quests;
                    batchHistory.DataBind();
                    batchHistoryPanel.Visible = true;
                    ScoreListPanel.Visible = false;
                    SessionHelper.NullCandidateCode(Session);
                    Session["BatchSetId"] = null;
                }
                else if (count == 1)
                {
                    batchHistoryPanel.Visible = false;
                    SessionHelper.SetCandidateCode(code, Session);
                    Session["BatchSetId"] = null;
                    Response.Redirect("ViewTestScore.aspx", false);
                }
                else
                {
                    resultLbl.Text = String.Empty;
                    batchHistoryPanel.Visible = false;
                }


            }
            else
            {
                resultLbl.Text = "This is not a valid candidate code";
                batchHistoryPanel.Visible = false;
            } 
        }

        protected void lnkeditCa_Click(object sender, EventArgs e)
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
                    Session["BatchSetId"] = s[1];
                    Response.Redirect("ViewTestScore.aspx", false);
                }
                else
                {
                    SessionHelper.NullCandidateCode(Session);
                    Session["BatchSetId"] = null;
                    Response.Redirect("ViewTestScore.aspx", false);
                }
            }
        }

        protected void print_Click(object sender, EventArgs e)
        {
            var cid = CID.Value;
            var bid = BID.Value;
            Response.Redirect("ViewTR.aspx?z=" + cid+"&y="+bid, false);
        }

    }
}