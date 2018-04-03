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
    
    public partial class CandidateView : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanWorkWithCandidates||PermMgr.CanApprove)
                {
                if (!IsPostBack)
                {
                    string code = Request["z"];

                    if (!string.IsNullOrEmpty(code))
                    {
                        var cand = _db.T_Candidate.FirstOrDefault(s => s.Id.ToString() == code);

                        if (cand != null)
                        {
                            candId.Value = cand.Id.ToString();
                            Label1.Text = cand.Code;
                            Label2.Text = cand.LastName;
                            Label3.Text = cand.FirstName + " " + cand.MiddleName + " " + cand.MaidenName;
                            Label4.Text = cand.Sex;
                            Label5.Text = ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Day) + "/" + ErecruitHelper.AppendZero(cand.DateOfBirth.Value.Month) + "/" + cand.DateOfBirth.Value.Year;
                            Label6.Text = cand.Degree;
                            Label10.Text = cand.ClassOfDegree;
                            Label11.Text = cand.Course;
                            Label12.Text = cand.Referer;
                            Label13.Text = cand.Email;
                            Label14.Text = cand.ApprovalStatus;
                            Comment.Text = cand.Comment;
                            string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                            Image1.ImageUrl = !(string.IsNullOrEmpty(cand.Passport)) ? cand.Passport : path;
                            Image1.DataBind();

                            var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);

                            var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                            if (candBatch != null)
                            {

                                var cbSet = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == candBatch.Id && s.CandidateId == cand.Id);
                                if (cbSet != null)
                                {
                                    Label7.Text = string.IsNullOrEmpty(cbSet.TestScore)?"Not Taken":cbSet.TestScore + "%";
                                    Label8.Text = cbSet.Essay == true ? "Taken" : "Not Taken";
                                    Label9.Text = cbSet.Psychometric == true ? "Taken" : "Not Taken";
                                }
                            }


                        }
                        else
                        {
                            ErecruitHelper.SetErrorData(new NullReferenceException(), Session);
                            Response.Redirect("ErrorPage.aspx", false);
                        }

                    }
                    else
                    {
                        ErecruitHelper.SetErrorData(new NullReferenceException(), Session);
                        Response.Redirect("ErrorPage.aspx", false);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
             try
            {
           var id = candId.Value;
                 var com = Comment.Text; 
           if (!string.IsNullOrEmpty(id))
           {
               var cand = _db.T_Candidate.FirstOrDefault(s => s.Id.ToString() == id);
               if (cand != null)
               {
                   cand.Comment = string.IsNullOrEmpty(com) ? "" : com;
                   _db.SaveChanges();
               }
           }
                }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("Candidate.aspx", false);
            }
        }

        protected void BackToCandidates_Click(object sender, EventArgs e)
        {
            try
            {
                SessionHelper.NullCandidateCode(Session);
                Response.Redirect("Candidate.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("Candidate.aspx", false);
            }
        }
    }
}