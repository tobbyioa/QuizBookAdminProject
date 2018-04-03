using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;

namespace QuizBook.Views
{
    public partial class BackgroundView : System.Web.UI.Page
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

                
                var code = SessionHelper.FetchCandidateCode(Session);
                var bid = Session["Batchid"].ToString();
                if (!string.IsNullOrEmpty(code))
                {
                    var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == code);

                    if (cand != null)
                    {

                        //var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == cand.Id);

                       // var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

                        var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id== long.Parse(bid));
                        if (candBatch != null)
                        {
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

                            var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                            if (cbSet.Finished == true)
                            {

                                var background = _db.T_BackGroundQuestAnswers.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                                if (background != null)
                                {
                                    TextBox1.Text = background.Q1;
                                    TextBox2.Text = background.Q2;
                                    TextBox3.Text = background.Q3;
                                    TextBox41.Text = background.Q4a;
                                    TextBox4.Text = background.Q4b;
                                    TextBox5.Text = background.Q5a;
                                    TextBox6.Text = background.Q5b;
                                    TextBox7.Text = background.Q6a;
                                    TextBox8.Text = background.Q6b;
                                    TextBox9.Text = background.Q7a;
                                    TextBox10.Text = background.Q7b;
                                    TextBox11.Text = background.Q8a;
                                    TextBox12.Text = background.Q8b;
                                    TextBox13.Text = background.Q9a;
                                    TextBox14.Text = background.Q9b;
                                    TextBox15.Text = background.Q10a;
                                    TextBox16.Text = background.Q10b;
                                    TextBox17.Text = background.Q11;
                                    TextBox18.Text = background.Q12;
                                    TextBox19.Text = background.Q13;
                                    TextBox20.Text = background.Q14;
                                    TextBox21.Text = background.Q15a;
                                    TextBox22.Text = background.Q15b; 
                                    TextBox23.Text = background.Q15c;
                                    TextBox24.Text = background.Q16;
                                    TextBox42.Text = background.Q17a;
                                    TextBox25.Text = background.Q17b;
                                    TextBox43.Text = background.Q18a;
                                    TextBox26.Text = background.Q18b;
                                    TextBox27.Text = background.Q19;
                                    TextBox44.Text = background.Q20a;
                                    TextBox28.Text = background.Q20b;
                                    TextBox45.Text = background.Q21a;
                                    TextBox29.Text = background.Q21b; 
                                    TextBox30.Text = background.Q22;
                                    TextBox31.Text = background.Q23a1;
                                    TextBox32.Text = background.Q23a2;
                                    TextBox33.Text = background.Q23a3;
                                    TextBox34.Text = background.Q23b1;
                                    TextBox35.Text = background.Q23b2;
                                    TextBox36.Text = background.Q23b3;
                                    TextBox37.Text = background.Q24a1;
                                    TextBox38.Text = background.Q24a2;
                                    TextBox39.Text = background.Q24b;
                                    TextBox40.Text = background.Q25;
                                    TextBox46.Text = background.Acknowledgement;
                                }
                            }

                        }

                    }
                }
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SessionHelper.NullCandidateCode(Session);
                Response.Redirect("BackgroundQuestResults.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
    }
}