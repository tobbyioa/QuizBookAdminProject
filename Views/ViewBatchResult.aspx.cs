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
    public partial class ViewBatchResult : System.Web.UI.Page
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
                    string alink = Request["z"];

                    if (!string.IsNullOrEmpty(alink))
                    {


                        var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(alink));

                        var bs = _db.T_BatchSet.Where(s => s.BatchId == candBatch.Id);

                        var candNo = bs.Count();

                        var res = bs.Select(a => new ViewBatchResultsGridModel
                        {
                            ID = (long)a.CandidateId,
                            Code = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString(),
                            FirstName = ErecruitHelper.getCandidateFirstName((long)a.CandidateId).ToString(),
                            LastName = ErecruitHelper.getCandidateLastName((long)a.CandidateId).ToString(),
                            Score = a.TestScore == null ? "Not Attempted" : a.TestScore + "%",
                            DateOfBirth = ErecruitHelper.getCandidateDOB((long)a.CandidateId).ToString(),
                            Sex = ErecruitHelper.getCandidateSex((long)a.CandidateId).ToString(),
                            Passport = ErecruitHelper.getCandidateImgUrl((long)a.CandidateId).ToString(),
                            Alt = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString()

                        });

                        bname.InnerHtml = candBatch.Name;
                        NoCands.InnerHtml = candNo.ToString();
                        dateTaken.InnerHtml = ErecruitHelper.GetDateStringFromDate((DateTime)candBatch.StartDate);
                        BatchScoreList.DataSource = res.ToList();
                        BatchScoreList.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Batches.aspx", false);
        }
    }
}