using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Model;
using System.Web.Services;
using QuizBook.Helpers;
using System.IO;

namespace QuizBook.Views
{
    public partial class EssayQuestions : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanManageQuestion)
                {

               

                if (!IsPostBack)
                {

                    string alink = Request["z"];
                    if (!string.IsNullOrEmpty(alink))
                    {
                        var curEssay = _db.T_EssayQuestions.FirstOrDefault(s => s.Id == long.Parse(alink));
                        essayId.Value = curEssay.Id.ToString();
                        EssayText.Text = curEssay.Question;
                        Q_Active.Checked = curEssay.IsActive.Value == null ? false : curEssay.IsActive.Value;
                        EssayDuration.Text = curEssay.Duration != null ? curEssay.Duration.Value.ToString() : (0).ToString();
                        ESave.Visible = false;
                        Echanges.Visible = true;

                    }
                    var quests = _db.T_EssayQuestions.OrderBy(s=>s.IsActive).Select(a => new EssayGridModel
                    {
                        ID = a.Id,
                        Detail = string.IsNullOrEmpty(a.Question) ? "Empty" : a.Question.Trim(),
                        IsActive = a.IsActive == true?"Active":"Inactive",
                        Duration = a.Duration != null ? a.Duration.Value.ToString() : "<Empty>",
                        D = a.IsActive.Value ? "Deactivate" : "Activate"

                    }).Distinct().ToList();
                    EssayIndex.Text = quests.Count + " Question(s)";
                    EssayList.DataSource = quests;
                    EssayList.DataBind();
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
                Response.Redirect("ErrorPage.aspx",false);
            }
        }


        [WebMethod]
        public static string SwitchEssayActivity(string id)
        {
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var opt = _db.T_EssayQuestions.FirstOrDefault(s => s.Id == long.Parse(id));
                if (opt != null)
                {
                    if (opt.IsActive.Value)
                    {
                        opt.IsActive = false;
                        opt.DateModified = DateTime.Now;
                    }
                    else
                    {
                        opt.IsActive = true;
                        opt.DateModified = DateTime.Now;
                    }


                    _db.SaveChanges();
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        protected void lnkeditE_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDE");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                //var curBC = _db.T_Question.Where(s  =>s.Id == idcr).FirstOrDefault();
                //if (curBC != null)
                //{
                Response.Redirect("EssayQuestions.aspx?z=" + idcr,false);
                // }

            }
        }

        protected void ESave_Click(object sender, EventArgs e)
        {
           try{
            var essay = EssayText.Text;
            if (!string.IsNullOrEmpty(essay))
            {
                var duration = !string.IsNullOrEmpty(EssayDuration.Text) ? int.Parse(EssayDuration.Text) : 0;
                _db.T_EssayQuestions.Add(new T_EssayQuestions { Question = essay, Duration = duration, IsActive = Q_Active.Checked, DateAdded = DateTime.Now });
                _db.SaveChanges();
               
            }
            else
            {
            }
             Response.Redirect("EssayQuestions.aspx",false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx",false);
            }
        }

        protected void Echanges_Click(object sender, EventArgs e)
        {
            try{
                var id = essayId.Value;
                var essay = EssayText.Text;
                var duration = !string.IsNullOrEmpty(EssayDuration.Text) ? int.Parse(EssayDuration.Text) : 0;

                if (id != null)
                {
                    var theEssay = _db.T_EssayQuestions.FirstOrDefault(s => s.Id == long.Parse(id));
                    theEssay.Question = essay;
                    theEssay.Duration = duration;
                    theEssay.IsActive = Q_Active.Checked;
                    theEssay.DateModified = DateTime.Now;
                    _db.SaveChanges();
                   
                }
                else
                {
                }
                Response.Redirect("EssayQuestions.aspx",false);

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx",false);
            }

        }

        protected void lnkeditEs_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton lnkedit = ((LinkButton)sender);
                var p = lnkedit.Parent;
                HiddenField hdfID = (HiddenField)p.FindControl("hdfIDEs");
                var idcr = long.Parse(hdfID.Value);
                if (!(idcr == null))
                {
                    var opt = _db.T_EssayQuestions.FirstOrDefault(s => s.Id == idcr);
                    if (opt != null)
                    {
                        if (opt.IsActive.Value)
                        {
                            opt.IsActive = false;
                            opt.DateModified = DateTime.Now;
                        }
                        else
                        {
                            opt.IsActive = true;
                            opt.DateModified = DateTime.Now;
                        }


                        _db.SaveChanges();
                       
                    }

                    Response.Redirect("EssayQuestions.aspx", false);

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