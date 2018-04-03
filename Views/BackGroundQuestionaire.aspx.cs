using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class BackGroundQuestionaire : System.Web.UI.Page
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
                if (cand != null && candBatch != null)
                {
                    var bs = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                    ccode.InnerHtml = cand.Code;
                    CGender.InnerHtml = cand.Sex;
                    Surname.InnerHtml = cand.LastName;
                    COthernames.InnerHtml = cand.FirstName + " " + cand.MaidenName;
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

        protected void BQsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                 var candId = SessionHelper.FetchCandidateId(Session);
            var id = long.Parse(candId);
            var cand = _db.T_Candidate.FirstOrDefault(s => s.Id == id);

            if (cand != null)
            {

                var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);
                var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);

                if (candBatch != null)
                {
                    var Q1 = TextBox1.Text;
                    var Q2 = TextBox2.Text;
                    var Q3 = TextBox3.Text;
                    var Q4a = Request.Form["r1"];
                    var Q4b = TextBox4.Text;

                    var Q5a = TextBox5.Text;
                    var Q5b = TextBox6.Text;

                    var Q6a = TextBox7.Text;
                    var Q6b = TextBox8.Text;

                    var Q7a = TextBox9.Text;
                    var Q7b = TextBox10.Text;

                    var Q8a = TextBox11.Text;
                    var Q8b = TextBox12.Text;

                    var Q9a = TextBox13.Text;
                    var Q9b = TextBox14.Text;

                    var Q10a = TextBox15.Text;
                    var Q10b = TextBox16.Text;

                    var Q11 = TextBox17.Text;
                    var Q12 = TextBox18.Text;

                    var Q13 = TextBox19.Text;
                    var Q14 = TextBox20.Text;

                    var Q15a = TextBox21.Text;
                    var Q15b = TextBox22.Text;
                    var Q15c = TextBox23.Text;


                    var Q16 = TextBox24.Text;

                    var Q17a = Request.Form["r2"];
                    var Q17b = TextBox25.Text;


                    var Q18a = Request.Form["r3"];
                    var Q18b = TextBox26.Text;

                    var Q19 = TextBox27.Text;

                    var Q20a = Request.Form["r4"];
                    var Q20b = TextBox28.Text;

                    var Q21a = Request.Form["r5"];
                    var Q21b = TextBox29.Text;

                    var Q22 = TextBox30.Text;

                    var Q23a1 = TextBox31.Text;
                    var Q23a2 = TextBox32.Text;
                    var Q23a3 = TextBox33.Text;

                    var Q23b1 = TextBox34.Text;
                    var Q23b2 = TextBox35.Text;
                    var Q23b3 = TextBox36.Text;

                    var Q24a1 = TextBox37.Text;
                    var Q24a2 = TextBox38.Text;

                    var Q24b = TextBox39.Text;

                    var Q25 = TextBox40.Text;

                    var ack = Request.Form["r6"];
                    //validation
                    var litmus = false;
                    string[] elements = new string[] {TextBox1.Text ,TextBox2.Text ,TextBox3.Text , 
                        Request.Form["r1"],TextBox4.Text ,TextBox5.Text,TextBox6.Text ,
                        TextBox7.Text ,TextBox8.Text ,TextBox9.Text,TextBox10.Text ,TextBox11.Text ,
                        TextBox12.Text ,TextBox13.Text,TextBox14.Text ,TextBox15.Text ,TextBox16.Text ,
                        TextBox17.Text,TextBox18.Text,TextBox19.Text,TextBox20.Text 
                        ,TextBox21.Text ,TextBox22.Text,TextBox23.Text ,TextBox24.Text,Request.Form["r2"] ,
                        TextBox25.Text ,Request.Form["r3"] ,TextBox26.Text ,TextBox27.Text ,Request.Form["r4"] 
                       ,TextBox28.Text ,Request.Form["r5"],TextBox29.Text ,TextBox30.Text ,TextBox31.Text,
                       TextBox32.Text ,TextBox33.Text ,TextBox34.Text ,TextBox35.Text ,TextBox36.Text,TextBox37.Text ,
                       TextBox38.Text ,TextBox39.Text, TextBox40.Text,Request.Form["r6"]  };

                    foreach (var i in elements)
                    {
                        if (string.IsNullOrEmpty(i))
                        {
                            litmus = true;
                        }
                        else
                        {
                            litmus = false;
                        }
                    }
                    if (litmus) {
                        msgLabel.Text = "Please make sure you answer all the questions";
                    }
                    else
                    {
                        _db.T_BackGroundQuestAnswers.Add(new T_BackGroundQuestAnswers
                        {
                            CandidateId = cand.Id,
                            BatchId = candBatch.Id,
                            Q1 = Q1,
                            Q2 = Q2,
                            Q3 = Q3,
                            Q4a = Q4a,
                            Q4b = Q4b,
                            Q5a = Q5a,
                            Q5b = Q5b,
                            Q6a = Q6a,
                            Q6b = Q6b,
                            Q7a = Q7a,
                            Q7b = Q7b,
                            Q8a = Q8a,
                            Q8b = Q8b,
                            Q9a = Q9a,
                            Q9b = Q9b,
                            Q10a = Q10a,
                            Q10b = Q10b,

                            Q11 = Q11,
                            Q12 = Q12,
                            Q13 = Q13,
                            Q14 = Q14,
                            Q15a = Q15a,
                            Q15b = Q15b,
                            Q15c = Q15c,
                            Q16 = Q16,
                            Q17a = Q17a,
                            Q17b = Q17b,
                            Q18a = Q18a,
                            Q18b = Q18b,
                            Q19 = Q19,
                            Q20a = Q20a,
                            Q20b = Q20b,

                            Q21a = Q21a,
                            Q21b = Q21b,
                            Q22 = Q22,
                            Q23a1 = Q23a1,
                            Q23a2 = Q23a2,
                            Q23a3 = Q23a3,
                            Q23b1 = Q23b1,
                            Q23b2 = Q23b2,
                            Q23b3 = Q23b3,
                            Q24a1 = Q24a1,
                            Q24a2 = Q24a2,
                            Q24b = Q24b,
                            Q25 = Q25,
                            Acknowledgement = ack,
                            Dateadded = DateTime.Now
                        });

                        var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                        cbSet.Psychometric = true;
                        _db.SaveChanges();
                        Response.Redirect("FinalPage.aspx", false);
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