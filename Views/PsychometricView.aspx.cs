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
    public partial class PsychometricView : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        List<TextBox> TextBoxes = new List<TextBox>();
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

                        //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

                        var candBatch = _db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(bid));
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
                                GetTextBoxes(this);

                                if (TextBoxes.Count > 0)
                                {
                                    var psychTestResult = _db.T_MultiintelligencQuizBookDb.FirstOrDefault(s => s.CandidateId == cand.Id && s.BatchId == candBatch.Id);
                                    var intel = TextBoxes.FirstOrDefault(s => s.CssClass == "intel");
                                    var analysis = TextBoxes.Where(s => s.CssClass == "analysis").OrderBy(x => x.ID).ToList();
                                    var summation = TextBoxes.Where(s => s.CssClass == "summation").OrderBy(x => x.ID).ToList();
                                    var D1 = TextBoxes.Where(s => s.CssClass == "D1").OrderBy(x =>x.ID).ToList();
                                    var D2 = TextBoxes.Where(s => s.CssClass == "D2").OrderBy(x => x.ID).ToList();
                                    var D3 = TextBoxes.Where(s => s.CssClass == "D3").OrderBy(x => x.ID).ToList();
                                    var D4 = TextBoxes.Where(s => s.CssClass == "D4").OrderBy(x => x.ID).ToList();
                                    var D5 = TextBoxes.Where(s => s.CssClass == "D5").OrderBy(x => x.ID).ToList();
                                    var D6 = TextBoxes.Where(s => s.CssClass == "D6").OrderBy(x => x.ID).ToList();
                                    var D7 = TextBoxes.Where(s => s.CssClass == "D7").OrderBy(x => x.ID).ToList();

                                    intel.Text = psychTestResult.Intelligence;

                                    //D1
                                    var d1 = psychTestResult.Options1.Split(',');
                                    for (var s = 0; s < d1.Length;s++ )
                                    {
                                        if (s < D1.Count)
                                        {
                                            D1[s].Text = d1[s];
                                        }
                                    }

                                    //D2
                                    var d2 = psychTestResult.Options2.Split(',');
                                    for (var s = 0; s < d1.Length; s++)
                                    {
                                        if (s < D2.Count)
                                        {
                                            D2[s].Text = d2[s];
                                        }
                                    }

                                    //D3
                                    var d3 = psychTestResult.Options3.Split(',');
                                    for (var s = 0; s < d3.Length; s++)
                                    {
                                        if (s < D3.Count)
                                        {
                                            D3[s].Text = d3[s];
                                        }
                                    }

                                    //D4
                                    var d4 = psychTestResult.Options4.Split(',');
                                    for (var s = 0; s < d4.Length; s++)
                                    {
                                        if (s < D4.Count)
                                        {
                                            D4[s].Text = d4[s];
                                        }
                                    }
                                    //D5
                                    var d5 = psychTestResult.Options5.Split(',');
                                    for (var s = 0; s < d5.Length; s++)
                                    {
                                        if (s < D5.Count)
                                        {
                                            D5[s].Text = d5[s];
                                        }
                                    }
                                    //D6
                                    var d6 = psychTestResult.Options6.Split(',');
                                    for (var s = 0; s < d6.Length; s++)
                                    {
                                        if (s < D6.Count)
                                        {
                                            D6[s].Text = d6[s];
                                        }
                                    }
                                    //D7
                                    var d7 = psychTestResult.Options7.Split(',');
                                    for (var s = 0; s < d7.Length; s++)
                                    {
                                        if (s < D7.Count)
                                        {
                                            D7[s].Text = d7[s];
                                        }
                                    }

                                    //summation
                                    var dsummation = psychTestResult.Summations.Split(',');
                                    for (var s = 0; s < dsummation.Length; s++)
                                    {
                                        if (s < summation.Count)
                                        {
                                            summation[s].Text = dsummation[s];
                                        }
                                    }
                                    //analysis
                                    var danalysis = psychTestResult.Summations.Split(',');
                                    for (var s = 0; s < danalysis.Length; s++)
                                    {
                                        if (s < analysis.Count)
                                        {
                                            analysis[s].Text = danalysis[s];
                                        }
                                    }


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

        protected void GetTextBoxes(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (((TextBox)(c)).CssClass == "D1" || ((TextBox)(c)).CssClass == "D2" || ((TextBox)(c)).CssClass == "D3"||
                        ((TextBox)(c)).CssClass == "D4"||((TextBox)(c)).CssClass == "D5"||((TextBox)(c)).CssClass == "D6"||
                        ((TextBox)(c)).CssClass == "D7" || ((TextBox)(c)).CssClass == "analysis" || ((TextBox)(c)).CssClass == "summation"
                        || ((TextBox)(c)).CssClass == "intel")
                    {
                        TextBoxes.Add((TextBox)c);
                    }
                    
                }
                if (c.HasControls())
                {
                    GetTextBoxes(c);
                }
            } 
        }
        protected void BackToPTR_Click(object sender, EventArgs e)
        {
            try
            {
                SessionHelper.NullCandidateCode(Session);
                Response.Redirect("PsychTestResults.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
    }
}