using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using QuizBook.Helpers;
using QuizBook.Model;

namespace QuizBook.Views
{
    public partial class ViewTR : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManageTestResults)
            {
                 string alink = Request["z"];
                 string blink = Request["y"];
                 if (!string.IsNullOrEmpty(alink))
                 {
                     var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == alink);
                     var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(blink));

                     var bs = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                     ccode.InnerHtml = cand.Code;
                     CGender.InnerHtml = cand.Sex;
                     Surname.InnerHtml = cand.LastName;
                     COthernames.InnerHtml = cand.FirstName + " " + cand.MiddleName + " " + cand.MaidenName;
                     CDob.InnerHtml = ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Day) + "/" + ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Month) + "/" + cand.DateOfBirth.Value.Year;
                     cgrade.InnerHtml = bs.TestScore + "%";
                     string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                     passport.ImageUrl = !(string.IsNullOrEmpty(cand.Passport)) ? cand.Passport : path;
                     BindScoreGrid(cand, candBatch);
                 }
               
            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }
        }

        protected void BindScoreGrid(T_Candidate c, T_Batch bid)
        {
            var candBatch = bid;
            var b_question = _db.T_BatchQuestions.Where(s => s.BatchId == candBatch.Id).Select(s => s.QuestionId);

            var quests = _db.T_CandidateAnswers.Where(s => s.CandidateId == c.Id && s.BatchId == candBatch.Id).Select(a => new TestScoreGridModel
            {
                QuestionNo = a.QuestionId.Value,
                OptionType = ErecruitHelper.getQOptionTypeName(a.QuestionId.Value),
                CandidateOptions = ErecruitHelper.GetCandidateOptions(c.Id, candBatch.Id, a.QuestionId.Value),
                Url = a.Correct.Value == true ? "../Images/accept.png" : "../Images/delete.png",
                Alt = a.Correct.Value == true ? "Correct" : "Wrong"
            }).Distinct().ToList();
            var answered = quests.Select(s => s.QuestionNo);
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
                quests.InsertRange(0, unanswered);
            }

            ScoreList.DataSource = quests;
            ScoreList.DataBind();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTestScore.aspx", false);
        }


    }
}