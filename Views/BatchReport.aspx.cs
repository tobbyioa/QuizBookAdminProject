using QuizBook.Helpers;
using QuizBook.Helpers.ReportFactory;
using System;
using System.Linq;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web.UI;
using System.Web;
using System.Web.Hosting;
using System.Configuration;
using System.Drawing.Printing;
using SelectPdf;
using WSProfilerAPI;

namespace QuizBook.Views
{
    public partial class BatchReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
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
                            var selectedBatch = Session["GrpList"]==null?0: long.Parse(Session["GrpList"].ToString());
                            DateTime? fromDate = DateTime.Now;
                            if ((bool)Session["From"])
                            {
                                fromDate = null;
                            }else
                            {
                                fromDate = (DateTime)Session["dateFrom"];
                            }
                            DateTime? toDate = DateTime.Now;
                            if ((bool)Session["To"])
                            {
                                toDate = null;
                            }
                            else
                            {
                                toDate = (DateTime)Session["dateTo"];
                            }
                            //var toDate = (bool)Session["To"] ? null : (DateTime)Session["dateTo"];
                            //logoCtrl.ImageUrl = HostingEnvironment.MapPath("~/Images/book.png");
                            //logoCtrl.ImageUrl = GetUrl("book.png");
                            logoCt.Src = GetUrl("book.png");
                            //Session["imageURL"] = GetUrl("Images/book.png");

                            var details = new ERecruitReportFactory().BatchReport(selectedBatch, fromDate, toDate,long.Parse(tenant)).ToList();
                            var oneInstance = details.FirstOrDefault();
                            var count = details.Count();
                            candCount.Text = count.ToString();
                            batchName.Text = oneInstance == null? "":oneInstance.BatchName;
                            ppassed.Text = count >0?((details.Count(x => x.Passed == 1)/count)*100)+" %":"0 %";
                            pfailed.Text = count > 0 ? ((details.Count(x => x.Failed == 1) / count) * 100) + " %" : "0 %";
                            ResultList.DataSource = details;
                            ResultList.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    WSProfile filter = new WSProfile(System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Path.GetFileName(Request.Url.AbsolutePath) + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name, ApplicationType.WebApplication);
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
            Response.Redirect("TestReport.aspx", false);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void pdfBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Response.Clear();

                //Response.ContentType = "application/pdf";

                //Response.AddHeader("content-disposition", "attachment;filename=BatchReport.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //Response.Buffer = true;



                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                bresult.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());

                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();

                //GlobalConfig gc = new GlobalConfig();
                //gc.SetPaperSize(PaperKind.A4);
                //gc.SetPaperOrientation(true);

                //byte[] pdfBuf = new SynchronizedPechkin(gc).Convert(sr.ReadToEnd());
                //MemoryStream ms = new MemoryStream(pdfBuf);

                ////Response.Write(pdfDoc);
                //ms.WriteTo(Response.OutputStream);
                //Response.End();

                // read parameters from the webpage
                //string htmlString = TxtHtmlCode.Text;
                //string baseUrl = TxtBaseUrl.Text;

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

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                //converter.Options.WebPageWidth = webPageWidth;
                //converter.Options.WebPageHeight = webPageHeight;

                // create a new pdf document converting an url
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(sr.ReadToEnd());

                // save pdf document
                doc.Save(Response, false, "BatchReport.pdf");

                // close pdf document
                doc.Close();
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            } catch(Exception ex)
            {
                WSProfile filter = new WSProfile(System.Reflection.Assembly.GetExecutingAssembly().FullName.Split(',')[0], Path.GetFileName(Request.Url.AbsolutePath) + "-" + System.Reflection.MethodBase.GetCurrentMethod().Name,ApplicationType.WebApplication);
                filter.LogError(ex);
            }
        }

    }
}