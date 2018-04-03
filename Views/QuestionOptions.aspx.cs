using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Collections.Specialized;
using System.Web.Services;
using System.IO;

namespace QuizBook.Views
{
    public partial class QuestionOptions : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {


                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);
                var tenantId = long.Parse(SessionHelper.GetTenantID(Session));
                if (PermMgr.IsAdmin || PermMgr.CanManageQuestion)
                {
if (!IsPostBack)
             {

             string alink = Request["z"];
             QuestID.Value = alink;
             var al = long.Parse(alink);
             if (!string.IsNullOrEmpty(alink))
             {
                // var al = long.Parse(alink);
                 var curBC = _db.T_Question.FirstOrDefault(s => s.Id == al );
                 HiddenField1.Value = curBC.Id.ToString();

                 Label1.Text = (curBC.Details).ToString();
                 Label2.Text = (ErecruitHelper.getTypeName(_db, curBC.TypeId)).ToString();
                 Label3.Text = (ErecruitHelper.getOptionTypeName(_db, curBC.OptionType)).ToString();
                 Button1.Visible = true;
                 Button2.Visible = false;
             }
             string xlink = Request["x"];
             if (!string.IsNullOrEmpty(xlink))
             {
                 var xl = long.Parse(xlink);
                 var cur = _db.T_Option.Where(s => s.Id == xl).FirstOrDefault();
                 HiddenField2.Value = cur.Id.ToString();
                 TextBox1.Text = cur.Details;
                 CheckBox1.Checked = cur.Answer.HasValue?cur.Answer.Value:false;
                 Button1.Visible = false;
                 Button2.Visible = true;
             }


                 var options = _db.T_Option.Where(s => s.Q_Id== al).Select(a => new
                 {
                     ID = a.Id,
                     Detail = a.Details,
                     Answer = a.Answer,
                     D = "Delete"

                 }).ToList();

                 Label4.Text = options.Count.ToString() + " Option(s)";
                 GridView1.DataSource = options;
                 GridView1.DataBind();
             }
                }
                else
                {
                    Response.Redirect("NoPermission.aspx", false);
                }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionsList.aspx");
        }

        [WebMethod]
        public static string deleteQuestOption(string id)
        {
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var optId = long.Parse(id);
                var opt = _db.T_Option.FirstOrDefault(s => s.Id == optId);
                if (opt != null)
                {
                    _db.T_Option.Remove(opt);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var curQ_id = long.Parse(HiddenField1.Value);

                if (curQ_id != null)
                {
                    var question = _db.T_Question.FirstOrDefault(s => s.Id == curQ_id);
                    if (question != null)
                    {
                        T_Option q = new T_Option
                        {
                            Q_Id = curQ_id,
                            Answer = CheckBox1.Checked,
                            Details = TextBox1.Text,
                            AddedBy = SessionHelper.FetchEmail(Session),
                            DateAdded = DateTime.Now
                        };
                        _db.T_Option.Add(q);

                        var qTrueOption = _db.T_Option.FirstOrDefault(s => s.Q_Id == question.Id && s.Answer == true);
                        var single = ErecruitHelper.OptionType.Single.ToString();
                        var opttype =  _db.T_QOptionType.FirstOrDefault(s=>s.Name == single);

                        if (question.OptionType == opttype.Id)
                        {

                            if (q.Answer == true && qTrueOption != null)
                            {
                                q.AddedBy = SessionHelper.FetchEmail(Session);
                                q.DateAdded = DateTime.Now;

                                qTrueOption.Answer = false;
                                qTrueOption.ModifiedBy = SessionHelper.FetchEmail(Session);
                                qTrueOption.DateModified = DateTime.Now;
                                _db.SaveChanges();
                            }
                            else if (question.T_QOptionType.Name== "Multi")
                            {
                                q.AddedBy = SessionHelper.FetchEmail(Session);
                                q.DateAdded = DateTime.Now;

                                _db.SaveChanges();
                            }
                        }
                        else
                        {
                            _db.SaveChanges();
                        }

                    }
                }
                Response.Redirect("QuestionOptions.aspx?z=" + curQ_id,false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void lnkedit3_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfID3");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                var cur = _db.T_Option.FirstOrDefault(s => s.Id == idcr);

                HiddenField2.Value = cur.Id.ToString();
                TextBox1.Text = cur.Details;
                CheckBox1.Checked = cur.Answer.Value;
                Button1.Visible = false;
                Button2.Visible = true;
                Response.Redirect("QuestionOptions.aspx?z=" + cur.Q_Id + "&x=" + cur.Id);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            var id = HiddenField2.Value;
            if (!(id == null))
            {


                var optId = long.Parse(id);
                var cur = _db.T_Option.FirstOrDefault(s => s.Id == optId);
                if (cur != null)
                {
                   // var qid = cur.Q_Id;
                    //var question = _db.T_Question.FirstOrDefault(s => s.Id == cur.Q_Id);
                    var question = cur.T_Question;
                    if (question != null)
                    {
                        var istrue = CheckBox1.Checked;
                       // cur.Answer = CheckBox1.Checked;
                          //var qTrueOption = _db.T_Option.FirstOrDefault(s =>s.Q_Id == question.Id && s.Answer == true);
                        var qTrueOption = question.T_Option.FirstOrDefault(s =>s.Answer.Value == true);

                        var single =  ErecruitHelper.OptionType.Single.ToString();
                        var opttype =  _db.T_QOptionType.FirstOrDefault(s=>s.Name == single);

                        if (question.OptionType == opttype.Id)
                        {
                            //if (cur.Answer == true && qTrueOption != null)
                            //{
                            if (istrue && qTrueOption != null)
                            {
                                cur.Answer = istrue;
                                cur.ModifiedBy = SessionHelper.FetchEmail(Session);
                                cur.DateModified = DateTime.Now;
                                cur.Details = TextBox1.Text;

                                qTrueOption.ModifiedBy = SessionHelper.FetchEmail(Session);
                                qTrueOption.DateModified = DateTime.Now;
                                qTrueOption.Answer = false;

                                _db.SaveChanges();
                            }
                            else
                            {
                                cur.Answer = istrue;
                                cur.ModifiedBy = SessionHelper.FetchEmail(Session);
                                cur.DateModified = DateTime.Now;
                                cur.Details = TextBox1.Text;
                                _db.SaveChanges();
                            }
                        }
                        else if (question.T_QOptionType.Name == "Multi")
                        {
                            cur.Answer = istrue;
                                cur.ModifiedBy = SessionHelper.FetchEmail(Session);
                                cur.DateModified = DateTime.Now;
                                cur.Details = TextBox1.Text;
                            _db.SaveChanges();
                        }
                    }
                    Response.Redirect("QuestionOptions.aspx?z=" + question.Id, false);
                }

            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void lnkeditO_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDO");
            var idcr = long.Parse(hdfID.Value);
            var opt = _db.T_Option.FirstOrDefault(s => s.Id == idcr);
            if (opt != null)
            {
                var qid = opt.Q_Id;
                _db.T_Option.Remove(opt);
                _db.SaveChanges();

                Response.Redirect("QuestionOptions.aspx?z=" + qid, false);
            }

        }


    }
}