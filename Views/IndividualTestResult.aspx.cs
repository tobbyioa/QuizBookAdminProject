
using QuizBook.Helpers;
using QuizBook.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSProfilerAPI;

namespace QuizBook.Views
{
    public partial class IndividualTestResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var candId = Session["CandId"].ToString();
                    var batchId = Session["BatchId"].ToString();
                    var tenant = SessionHelper.GetTenantID(Session);
                    using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                    {

                        if (string.IsNullOrEmpty(tenant))
                        {
                            ErecruitHelper.SetErrorData(new NullReferenceException("There must be a valid Organisation"), Session);
                            Response.Redirect("ErrorPage.aspx", false);
                        }
                        else
                        {

                            if (string.IsNullOrEmpty(candId))
                            {
                                ErecruitHelper.SetErrorData(new NullReferenceException("There must be a valid candidate"), Session);
                                Response.Redirect("ErrorPage.aspx", false);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(batchId))
                                {
                                    ErecruitHelper.SetErrorData(new NullReferenceException("There must be a valid Batch"), Session);
                                    Response.Redirect("ErrorPage.aspx", false);
                                }
                                else
                                {
                                    var cid = long.Parse(candId);
                                    var bid = long.Parse(batchId);
                                    var tid = long.Parse(tenant);

                                    var repM = _db.TestResultReports.FirstOrDefault(s => s.candId == cid && s.batchId == bid && s.tenantId == tid);
                                    var repSum = _db.TestReportSummaries.FirstOrDefault(x => x.ReportId == repM.Id);
                                    var repAns = _db.TestReportAnswers.Where(x => x.ReportId == repM.Id).ToList();



                                    logoCt.Src = GetUrl("book.png");

                                    //var result = _db.IndividualTestResult_sp(bid, cid, tid).ToList();
                                    //var cand = result.FirstOrDefault();

                                    candidateId.Text = repM.candidateId.ToUpper();
                                    candidateName.Text = repM.candidateName.ToUpper() ;
                                    batchName.Text = repM.batchName.ToUpper();
                                    tenantName.Text = repM.tenantName.ToUpper();
                                    tstDate.Text = repM.tstDate;


                                    var forList = repAns.Select(x => new
                                    {
                                        sn = x.sn,
                                        question = x.question,
                                        Mark = x.Mark,
                                        Score = x.Score,
                                        chosenAnswer = x.chosenAnswer,
                                        correctAnswer = x.correctAnswer,
                                        Status = x.correct == "Correct" ? "<span style='color:#008000;'>Right</span>":x.correct== "Partial"? "<span style='color:#ffb400;'>Partial</span>": " <span style='color:#f00;'>Wrong</span>",

                                    }).ToList();




                                    //var forList = result.Select((s, i) => new
                                    //{
                                    //    sn = (i + 1).ToString(),
                                    //    Question = s.QuestionDetails,
                                    //    Answer = string.IsNullOrEmpty(s.ChosenAnswerDetails) ? "Unanswered" : s.ChosenAnswerDetails,
                                    //    CorrectAnswer = s.CorrectAnswer,
                                    //    Status = s.Correct.HasValue ? s.Correct.Value ? "<b style='color:green;'>Right</b>" : "<b style='color:red;'>Wrong</b>" : "<b style='color:red;'>Wrong</b>"
                                    //}).ToList();

                                    ResultList.DataSource = forList;
                                    ResultList.DataBind();

                                    var summary = new ResultModel
                                    {
                                        Correct = repSum.Correct.Value,
                                        Partial = repSum.Partial.Value,
                                        Wrong = repSum.Wrong.Value,
                                        Unanswered = repSum.Unanswered.Value,
                                        CorrectPercent = repSum.CorrectPercent.Value,
                                        PartialPercent = repSum.PartialPercent.Value,
                                        WrongPercent = repSum.WrongPercent.Value,
                                        UnansweredPercent = repSum.UnansweredPercent.Value,
                                        CorrectCount = repSum.CorrectCount.Value,
                                        PartialCount = repSum.PartialCount.Value,
                                        WrongCount = repSum.WrongCount.Value,
                                        UnansweredCount = repSum.UnansweredCount.Value,
                                        questionCount = repSum.questionCount.HasValue ? repSum.questionCount.Value:0,
                                        questionTotalMark = repSum.questionTotalMark.HasValue? repSum.questionTotalMark.Value:0,
                                        testDate = repSum.testDate.Value
                                    };

                                    var totalQustionMark = forList.Sum(x => x.Mark);

                                    Correct.Text = repM.Correct.ToString();
                                    Wrong.Text = repM.Wrong.ToString();
                                    Partial.Text = repM.Partial.ToString();
                                    Unanswered.Text = repM.Unanswered.ToString();
                                    percentage.Text = repM.percentage.ToString();
                                    result_correct.Text = summary.Correct.ToString();
                                    result_partial.Text = summary.Partial.ToString();
                                    result_wrong.Text = summary.Wrong.ToString();
                                    result_unanswered.Text = summary.Unanswered.ToString();
                                    sumation_result.Text = (summary.Correct+ summary.Partial).ToString() +" out of " +totalQustionMark;



                                }
                            }
                        }
                    }
                }
                    catch (Exception ex)
                {
                    WSProfile filter = new WSProfile(System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Path.GetFileName(Request.Url.AbsolutePath)+"-"+System.Reflection.MethodBase.GetCurrentMethod().Name, ApplicationType.WebApplication);
                    filter.LogError(ex);
                    //ErecruitHelper.SetErrorData(ex, Session);
                    //Response.Redirect("ErrorPage.aspx", false);
                }
            }

        }

        protected string GetUrl(string imagepath)
        {
            string[] splits = Request.Url.AbsoluteUri.Split('/');
            if (splits.Length >= 2)
            {
                string url = splits[0] + "//";
                for (int i = 2; i < splits.Length - 1; i++)
                {
                    url += splits[i];
                    url += "/";
                }
                return url + imagepath;
            }
            return imagepath;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndividualTestReport.aspx", false);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void pdfBtn_Click(object sender, EventArgs e)
        {

            try
            {
                var lbl = string.Format("IndividualTestReport_{0}_{1}", candidateId.Text, batchName.Text);
                //Response.Clear();

                //Response.ContentType = "application/pdf";

                //Response.AddHeader("content-disposition", "attachment;filename="+lbl+".pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //Response.Buffer = true;



                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                Panel1.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                //GlobalConfig gc = new GlobalConfig();
                //gc.SetPaperSize(PaperKind.A4);
                //gc.SetPaperOrientation(true);



                //byte[] pdfBuf = new SynchronizedPechkin(gc).Convert(sr.ReadToEnd());
                //MemoryStream ms = new MemoryStream(pdfBuf);

                //ms.WriteTo(Response.OutputStream);
                //Response.End();

                string pdf_page_size = "A4";
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                    pdf_page_size, true);

                string pdf_orientation = "Landscape";
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);

                //int webPageWidth = 1024;
                //try
                //{
                //    webPageWidth = Convert.ToInt32(TxtWidth.Text);
                //}
                //catch { }

                //int webPageHeight = 0;
                //try
                //{
                //    webPageHeight = Convert.ToInt32(TxtHeight.Text);
                //}
                //catch { }

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set css media type
                converter.Options.CssMediaType = (HtmlToPdfCssMediaType)Enum.Parse(typeof(HtmlToPdfCssMediaType), "Screen", true);

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                //converter.Options.WebPageWidth = webPageWidth;
                //converter.Options.WebPageHeight = webPageHeight;

                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(sr.ReadToEnd());

                // save pdf document
                doc.Save(Response, false, lbl + ".pdf");

                // close pdf document
                doc.Close();
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                WSProfile filter = new WSProfile(System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Path.GetFileName(Request.Url.AbsolutePath) + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name, ApplicationType.WebApplication);
                filter.LogError(ex);
            }

        }
    }
}