using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using System.Web.Services;

namespace QuizBook.Views
{
    public partial class CandidateTestResult : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try{

                var selbatch = Session["SelectedBatch"].ToString();
                var sid = SessionHelper.FetchUserName(Page.Session);
                var selBatchLong = long.Parse(selbatch);
                var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == selBatchLong);
                CandName.Text = user.FirstName + " " +user.LastName;
                
                var mark = _db.GetCandMark_sp(candBatch.Id, user.Id).FirstOrDefault();
                var totalQuestions = _db.BatchScopeContents.FirstOrDefault(s => s.BatchId == selBatchLong).T_QuestionType.T_Question.Count();
                double percentage = (double)mark.Correct / totalQuestions;
                percentage = Math.Round((percentage * 100), 2);

                //var cut_off_string = _db.T_Settings.FirstOrDefault(s => s.SettingsName == ErecruitHelper.Settings.CUT_OFF_MARK.ToString()).SettingsValue;
                //var c_off = 0;
                //if (!string.IsNullOrEmpty(cut_off_string))
                //{
                //    c_off = int.Parse(cut_off_string);
                //}


                var rsltTxt = "You got " + mark.Correct + " question(s) correct," + mark.Wrong + " question(s) Wrong and " + mark.UnAnswered + " question(s) Unanswered out of " + totalQuestions + " questions.<br />Percentage score: " + percentage + " %";

                //if (percentage < c_off)
                //{
                    
                   //resultLblf.Text = rsltTxt;
                   // resultLblf.Visible = true;
                   // resultLblp.Visible = false;
                //}
                //else
                //{
                    resultLblp.Text = rsltTxt;
                    //resultLblf.Visible = false;
                    resultLblp.Visible = true;
                //}



            //if (cbSet.Finished == true && cbSet.TestGraded == true)
            //{

              

            //}
            //else
            //{
                
            //}
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }

        [WebMethod(EnableSession = true)]
        public static string logout(string id)
        {
            if (id == "false")
            {
                var v = HttpContext.Current.Session;
                v.Abandon();
            }
            return "You are leaving this page";
        }
       
    }
}