using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Services;
using QuizBook.Model;
using System.IO;

namespace QuizBook.Views
{
    public partial class QuestionsList : System.Web.UI.Page
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
                uEmail.Value = SessionHelper.FetchEmail(Session);

                      var qg = _db.T_QuestionType.Where(x =>x.TenantId == tenantId && x.Status == true).OrderBy(s => s.Name).Select(s =>new
                    {
                        id = s.Id,
                        Name = s.Name.ToUpper()
                    });

                      QGroupList.DataSource = qg.ToList();
                      QGroupList.DataBind();
                if (!string.IsNullOrEmpty(alink))
                {
                    var lkID = long.Parse(alink);
                    var curBC = _db.T_Question.FirstOrDefault(s => s.Id == lkID);
                    HiddenField1.Value = curBC.Id.ToString();
                    TextBox1.Text = curBC.Details;
                    Section.Text = curBC.Section;
                    DropDownList1.SelectedValue = curBC.TypeId.Value.ToString();
                    DropDownList2.SelectedValue = curBC.OptionType.Value.ToString();
                    markTxt.Text = curBC.Mark.ToString();
                    percentOption.Checked = curBC.OptionPercentageMark.Value;
                    Button1.Visible = false;
                    Button3.Visible = true;
                    EditLbl.Text = "Editing Question ID :" + alink;

                    if (!(curBC.PreambleId ==0))
                    {
                        //var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == curBC.PreambleId);


                        //PreamblePreview.Text = "";
                        //PreambleNamePreview.Text = "";
                        //preview.Visible = false;
                        //QPid.Value = preamble.Id.ToString();
                        //PreambleName.Text = preamble.Name;
                        //preambleText.Text = preamble.Body;

                        //preambleNameRow.Visible = true;
                        //preambleRow.Visible = true;
                    }
                    else
                    {
                       // var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == curBC.PreambleId);

                        PreambleName.Text = "";
                        preambleText.Text = "";

                        preambleNameRow.Visible = false;
                        preambleRow.Visible = false;

                        //PreambleNamePreview.Text = preamble.Name;
                        //PreamblePreview.Text = preamble.Body;
                        //preview.Visible = true;

                    }





                }

                //Populates the Question Type DropDownList
                var typ = _db.T_QuestionType.Where(x => x.TenantId == tenantId && x.Status == true).Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name

                }).OrderBy(s =>s.Name).ToList();
                var let = Session["LstEditedType"];
                if (let != null)
                {

                    DropDownList1.SelectedValue = let.ToString();
                }

                DropDownList1.DataSource = typ;
                DropDownList1.DataBind();


                //Populates the preambles DropDownList
                //var preamb = _db.T_QuestionPreamble.Select(a => new
                //{
                //    Id = a.Id,
                //    Name = a.Name
                //}).Distinct().ToList();
                //preamb.Insert(0, new
                //{
                //    Id = long.Parse("-1"),
                //    Name = "Select..."
                //});
                //preamb.Insert(1,new
                //{
                //    Id = long.Parse("0"),
                //    Name = "New Question Preamble"
                //});
                //preambleLists.DataSource = preamb;
                //preambleLists.DataBind();



                //Populates the Question Option Type DropDownList
                var QQtyp = _db.T_QOptionType.Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name
                }).Distinct().ToList();
                DropDownList2.DataSource = QQtyp;
                DropDownList2.DataBind();

                if (!string.IsNullOrEmpty(alink))
                {
                    var lkID = long.Parse(alink);
                    var curBC = _db.T_Question.FirstOrDefault(s => s.Id == lkID);
                    var quests = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TenantId == tenantId && x.TypeId == curBC.TypeId).OrderBy(x => x.Section).Select(a => new
                    {
                        ID = a.Id,
                        Detail = a.Details,
                        Type = a.Type,
                        Preamble = a.Preamble,
                        Section = a.Section,
                        OptionType = a.OptionType,
                        OptionsCount = a.OptionsCount,
                        IsActive = a.IsActive,
                        D = a.D

                    }).Distinct().ToList();

                    QuestionIndex.Text = quests.Count + " Question(s)";
                    GridView1.DataSource = quests;
                    GridView1.DataBind();

                }
                else
                {
                        var selType = DropDownList1.SelectedValue;

                        if (string.IsNullOrEmpty(selType))
                        {
                            var quests = new List<object>();
                            QuestionIndex.Text = quests.Count + " Question(s)";
                            GridView1.DataSource = quests;
                            GridView1.DataBind();
                        }
                        else
                        {
                            var QType = long.Parse(DropDownList1.SelectedValue);
                            var quests = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TenantId == tenantId && x.TypeId == QType).OrderBy(x => x.Section).Select(a => new
                            {
                                ID = a.Id,
                                Detail = a.Details,
                                Type = a.Type,
                                Preamble = a.Preamble,
                                Section = a.Section,
                                OptionType = a.OptionType,
                                OptionsCount = a.OptionsCount,
                                IsActive = a.IsActive,
                                D = a.D

                            }).Distinct().ToList();

                            QuestionIndex.Text = quests.Count + " Question(s)";
                            GridView1.DataSource = quests;
                            GridView1.DataBind();
                        }
                }
            }
            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Question.aspx",false);
        }
        //[WebMethod]
        //public static string deleteQuest(string id)
        //{
        //    try
        //    {
        //        var quest = _db.T_Question.Where(s => s.Id == long.Parse(id)).FirstOrDefault();
        //        if (quest != null)
        //        {
        //            var Q_Options = _db.T_Option.Where(s => s.Q_Id == quest.Id);

        //            _db.T_Option.DeleteAllOnSubmit(Q_Options);
        //            _db.T_Question.DeleteOnSubmit(quest);
        //            _db.SaveChanges();
        //            return "success";
        //        }
        //        return "failed";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}
        [WebMethod(EnableSession = true)]
        public static string DeleteQuestionGroup(string id, string name)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var qg = _db.T_QuestionType.FirstOrDefault(s => s.Id == long.Parse(id));
                if (qg != null)
                {
                    var qs = _db.T_Question.Where(s => s.TypeId == qg.Id);
                    qg.Status = false;
                    foreach (var x in qs)
                    {
                        x.IsActive = false;
                    }
                    _db.SaveChanges();
                    return "success";
                }
                else
                {
                    return "notexist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod(EnableSession=true)]
        public static string NewQuestionGroup(string id, string name)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var qg = _db.T_QuestionType.FirstOrDefault(s =>s.TenantId == tenantId && s.Name.ToLower().Trim() == id.ToLower().Trim());
                if (qg == null)
                {
                    _db.T_QuestionType.Add(new T_QuestionType
                    {
                        TenantId=tenantId,
                        Name = id.Trim().ToUpper(),
                        Description = id.Trim().ToUpper(),
                        Status = true,
                        AddedBy = name,
                        DateAdded = DateTime.Now
                    });
                    _db.SaveChanges();
                    return "success";
                }
                else
                {
                    return "exist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod(EnableSession = true)]
        public static string SwitchQuestionActivity(string id)
        {
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var opt = _db.T_Question.FirstOrDefault(s => s.Id == long.Parse(id));
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
        protected void lnkedit3_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfID3");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr==null))
            {

                Response.Redirect("QuestionsList.aspx?z=" + idcr,false);
            }
        }
        protected void lnkedit2_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfID1");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {

                Response.Redirect("QuestionOptions.aspx?z=" + idcr,false);


            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //var crx = _db.T_Question.Distinct().AsQueryable();




            //var crb = new List<QuestionModel>();
            var selectedQtype = long.Parse(DropDownList1.SelectedValue);
            var cr = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TypeId == selectedQtype && x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new QuestionModel
            {
                ID = a.Id,
                Detail = a.Details,
                Type = a.Type,
                Preamble = a.Preamble,
                Section = a.Section.ToString(),
                OptionType = a.OptionType,
                OptionsCount = a.OptionsCount.ToString(),
                IsActive = a.IsActive,
                // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                D = a.D

            }).Distinct().AsQueryable();

            //var cr = crb.AsQueryable();
            //var cr = _db.T_Question.AsQueryable();

            if ((string)Session["EXP"] == e.SortExpression && (string)Session["DIRECTION"] == SortDirection.Ascending.ToString())
            {
                e.SortDirection = SortDirection.Descending;
            }
            else
            {
                e.SortDirection = SortDirection.Ascending;
            }

            Session["EXP"] = e.SortExpression;
            Session["DIRECTION"] = e.SortDirection.ToString();
            switch (e.SortExpression)
            {
                case "Detail":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                       cr = cr.OrderBy(s => s.Detail);

                        //GridView1.DataSource = cr.ToList();
                       // GridView1.DataBind();
                    }
                    else
                    {
                        cr = cr.OrderBy(s => s.Detail);
                       // GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }

                    break;
                case "OptionType":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        cr = cr.OrderBy(s => s.OptionType);
                        //GridView1.DataSource = cr.ToList();
                       // GridView1.DataBind();
                    }
                    else
                    {
                        cr = cr.OrderBy(s => s.OptionType);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }

                    break;
                case "Type":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        cr = cr.OrderBy(s => s.Type);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }
                    else
                    {
                       cr = cr.OrderBy(s => s.Type);
                       //GridView1.DataSource = cr.ToList();
                       // GridView1.DataBind();
                    }

                    break;
                case "OptionsCount":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        cr = cr.OrderBy(s => s.OptionsCount);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }
                    else
                    {
                        cr = cr.OrderBy(s => s.OptionsCount);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }

                    break;
                case "IsActive":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        cr = cr.OrderBy(s => s.IsActive);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }
                    else
                    {
                        cr = cr.OrderBy(s => s.IsActive);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }

                    break;
                case "Section":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        cr = cr.OrderBy(s => s.IsActive);
                        //GridView1.DataSource = cr.ToList();
                       // GridView1.DataBind();
                    }
                    else
                    {
                        cr = cr.OrderBy(s => s.IsActive);
                        //GridView1.DataSource = cr.ToList();
                        //GridView1.DataBind();
                    }

                    break;

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var quests = new List<QuestionModel>();
              var stext = searchText.Text;
              stext = "%" + stext.ToLower() + "%";
            if (string.IsNullOrEmpty(stext))
            {
                var selectedQtype = long.Parse(DropDownList1.SelectedValue);
                quests = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TypeId == selectedQtype && x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = a.Details,
                    Type = a.Type,
                    Preamble = a.Preamble,
                    Section = a.Section.ToString(),
                    OptionType = a.OptionType,
                    OptionsCount = a.OptionsCount.ToString(),
                    IsActive = a.IsActive,
                    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                    D = a.D

                }).Distinct().ToList();
            }
            else
            {
                quests = _db.SearchActiveQuestion(stext).OrderBy(x => x.Section).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = a.Details,
                    Type = a.Type,
                    Preamble = a.Preamble,
                    Section = a.Section,
                    OptionType = a.OptionType,
                    OptionsCount = a.OptionsCount.ToString(),
                    IsActive = a.IsActive,
                    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                    D = a.D

                }).Distinct().ToList();
            }
            GridView1.DataSource = quests;
            QuestionIndex.Text = quests.Count + " Question(s)";
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try{
            var Qtype = DropDownList1.SelectedValue;
                var opptype = DropDownList2.SelectedValue;
                var mark = markTxt.Text;
                var pOpt = percentOption.Checked;
                // var preambleid = preambleLists.SelectedValue;
                //var preambleName = PreambleName.Text;
                //var preamble = preambleText.Text;
                //T_QuestionsPreamble p = null;

                //    if (!string.IsNullOrEmpty(preamble))
                //    {
                //        p = new T_QuestionsPreamble
                //        {
                //            Name = preambleName,
                //            Body = preamble,
                //            AddedBy = SessionHelper.FetchEmail(Session),
                //            DateAdded = DateTime.Now
                //        };
                //        _db.T_QuestionPreamble.Add(p);
                //        _db.SaveChanges();
                //    }

                if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                var email = SessionHelper.FetchEmail(Session);
                var opttype = long.Parse(opptype);//(long)ErecruitHelper.OptionType.Single;
                    decimal altmark = 1;
                var qMark = string.IsNullOrEmpty(mark) ? 1 : decimal.TryParse(mark,out altmark)?altmark:1;

                var tyId = long.Parse(Qtype);
                var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
                T_Question q = new T_Question
                {
                    //PreambleId = p != null ? p.Id : string.IsNullOrEmpty(preambleid)||(long.Parse(preambleid) == -1) ? 0 :long.Parse(preambleid),
                    TypeId = tyId,
                    OptionType = opttype,
                    Section = Section.Text,
                    TenantId = tenantId,
                    IsActive = true,
                    Details = TextBox1.Text,
                    Mark = qMark,
                    OptionPercentageMark = pOpt,
                    AddedBy= email,
                    DateAdded = DateTime.Now
                };

                _db.T_Question.Add(q);
                _db.SaveChanges();
           }
            Response.Redirect("QuestionsList.aspx",false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("QuestionsList.aspx");
        //}
        protected void Button3_Click(object sender, EventArgs e)
        {
            try{
            var id = HiddenField1.Value;

            var Qtype = DropDownList1.SelectedValue;
                var opttype = DropDownList2.SelectedValue;
                var mark = markTxt.Text;
                var pOpt = percentOption.Checked;
                decimal altmark = 1;
                var qMark = string.IsNullOrEmpty(mark) ? 1 : decimal.TryParse(mark, out altmark) ? altmark : 1;
                // var preambleid = QPid.Value;
                // var preambleName = PreambleName.Text;
                // var preamble = preambleText.Text;
                //// T_QuestionsPreamble p = null;
                // if (!string.IsNullOrEmpty(preambleid))
                // {
                //     var pre = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == long.Parse(preambleid));

                //         pre.Name = preambleName;
                //         pre.Body = preamble;
                //         pre.AddedBy = SessionHelper.FetchEmail(Session);
                //         pre.DateModified = DateTime.Now;

                //     //_db.T_QuestionPreamble.Add(p);
                // }

                if (!(id == null))
            {
                var Id = long.Parse(id);
                var cur = _db.T_Question.Where(s => s.Id == Id).FirstOrDefault();
                cur.TypeId = long.Parse(Qtype);
                 cur.OptionType = long.Parse(opttype);//(long)ErecruitHelper.OptionType.Single;
                 cur.Section = Section.Text;
                cur.Details = TextBox1.Text;
                    cur.Mark = qMark;
                    cur.OptionPercentageMark = pOpt;
              //  cur.PreambleId =string.IsNullOrEmpty(preambleid)?0 :long.Parse(preambleid);
                cur.ModifiedBy = SessionHelper.FetchEmail(Session);
                cur.DateModified = DateTime.Now;
                _db.SaveChanges();

                Session["LstEditedType"] = Qtype;

                Response.Redirect("QuestionsList.aspx",false);
            }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            var selectedQtype = long.Parse(DropDownList1.SelectedValue);
            var t = _db.T_QuestionType.FirstOrDefault(s => s.Id == selectedQtype);

            var tenantId = long.Parse(SessionHelper.GetTenantID(Session));
            //if (selectedQtype == 1 || selectedQtype == 3 || selectedQtype == 4)
            //{
            //    //PreambleName.Text = "";
            //    //preambleNameRow.Visible = true;
            //    //PreambleName.Text = "";
            //    //preambleNameRow.Visible = true;

            //    PreambleName.Text = "";
            //    preambleText.Text = "";
            //    PreamblePreview.Text = "";
            //    PreambleNamePreview.Text = "";

            //    preview.Visible = false;
            //    preambleNameRow.Visible = false;
            //    preambleRow.Visible = false;

            //    //Populates the preambles DropDownList
            //    var p = _db.T_Question.Where(s => s.TypeId == selectedQtype).Select(s => s.PreambleId).Distinct();
            //    var preamblesList = _db.T_QuestionPreamble.Where(s => p.Contains(s.Id));
            //    var preamb = preamblesList.Select(a => new
            //    {
            //        Id = a.Id,
            //        Name = a.Name
            //    }).Distinct().ToList();
            //    preamb.Insert(0, new
            //    {
            //        Id = long.Parse("-1"),
            //        Name = "Select..."
            //    });
            //    preamb.Insert(1, new
            //    {
            //        Id = long.Parse("0"),
            //        Name = "New Question Preamble"
            //    });
            //    preambleLists.DataSource = preamb;
            //    preambleLists.DataBind();

            //    preambles.Visible = true;
            //}
            //else
            //{
               // preambles.Visible = false;

                //preambleLists.SelectedIndex = 0;

                PreambleName.Text = "";
                preambleText.Text = "";
                PreamblePreview.Text = "";
                PreambleNamePreview.Text = "";

                preview.Visible = false;
                preambleNameRow.Visible = false;
                preambleRow.Visible = false;

          //  }
                //Populates the Question Type DropDownList
                var typ = _db.T_QuestionType.Where(x => x.TenantId == tenantId && x.Status == true).Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name

                }).OrderBy(s => s.Name).ToList();
                DropDownList1.SelectedValue = selectedQtype.ToString();
                DropDownList1.DataSource = typ;
                DropDownList1.DataBind();

                //var quests = _db.T_Question.Where(x => x.TypeId == selectedQtype).OrderBy(x =>x.DateAdded).Select(a => new QuestionModel
                //{
                //    ID = a.Id,
                //    Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : a.Details.Trim(),
                //    Type = ErecruitHelper.getTypeName(_db, a.TypeId),
                //    Preamble = ErecruitHelper.GetPreambleName(_db, a.PreambleId),
                //    OptionType = ErecruitHelper.getOptionTypeName(_db, a.OptionType),
                //    OptionsCount = ErecruitHelper.getOptionNum(_db, a.Id).ToString(),
                //    IsActive = a.IsActive.Value ? "Yes" : "No",
                //    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                //    D = a.IsActive.Value ? "Deactivate" : "Activate"

                //}).Distinct().ToList();
              //  QuestionIndex.Text = quests.Count + " "+t.Name+" Question(s)";
               // GridView1.DataSource = quests;
               // GridView1.DataBind();

                var quests = _db.ActiveQuestions_vw.Where(x => x.TypeId == selectedQtype && x.TenantId  == tenantId).OrderBy(x => x.Id).Select(a => new
                {
                    ID = a.Id,
                    Detail = a.Details,
                    Type = a.Type,
                    Preamble = a.Preamble,
                    Section = a.Section,
                    OptionType = a.OptionType,
                    OptionsCount = a.OptionsCount,
                    IsActive = a.IsActive,
                    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                    D = a.D

                }).ToList();
                QuestionIndex.Text = quests.Count + " Question(s)";
                GridView1.DataSource = quests;
                GridView1.DataBind();


           }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
        //protected void preambleLists_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try{
        //    var selectedQtype = long.Parse(DropDownList1.SelectedValue);
        //    var t = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == selectedQtype);
        //    var QType = _db.T_Question.Select(s => s.PreambleId).Distinct();
        //    var Qt = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == selectedQtype);
        //    var QTypeCount = QType.Count();
        //    var QTC = QTypeCount++;
        //    var selectedpreamble = long.Parse(preambleLists.SelectedValue);
        //    if (selectedpreamble == 0)
        //    {
        //        PreambleName.Text = Qt.Name + " " + QTC;
        //        preambleText.Text = "";
        //        PreamblePreview.Text = "";

        //        preview.Visible = false;
        //        preambleRow.Visible = true;
        //        preambleNameRow.Visible = true;

        //        var quests = _db.T_Question.Where(x => x.TypeId == selectedQtype).OrderBy(x =>x.DateAdded).Select(a => new QuestionModel
        //        {
        //            ID = a.Id,
        //            Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : a.Details.Trim(),
        //            Type = ErecruitHelper.getTypeName(_db, a.TypeId),
        //            Preamble = ErecruitHelper.GetPreambleName(_db, a.PreambleId),
        //            OptionType = ErecruitHelper.getOptionTypeName(_db, a.OptionType),
        //            OptionsCount = ErecruitHelper.getOptionNum(_db, a.Id).ToString(),
        //            IsActive = a.IsActive.Value ? "Yes" : "No",
        //            // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
        //            D = a.IsActive.Value ? "Deactivate" : "Activate"

        //        }).Distinct().ToList();
        //       // QuestionIndex.Text = quests.Count + " " + t.Name + " Question(s)";
        //       // GridView1.DataSource = quests;
        //       // GridView1.DataBind();

        //    }
        //    else if (selectedpreamble != -1 && selectedpreamble != 0)
        //    {
        //        var id = QPid.Value;
        //        //var Id = long.Parse(id);
        //        //var cur = _db.T_Question.Where(s => s.Id == Id).FirstOrDefault();
        //        //var Qt = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == cur.TypeId);
        //        if (!(string.IsNullOrEmpty(id)))
        //        {
        //            var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == selectedpreamble);


        //            PreamblePreview.Text ="";
        //            PreambleNamePreview.Text = "";
        //            preview.Visible = false;
        //            QPid.Value = preamble.Id.ToString();
        //            PreambleName.Text = preamble.Name;
        //            preambleText.Text = preamble.Body;

        //            preambleNameRow.Visible = true;
        //            preambleRow.Visible = true;
        //        }
        //        else
        //        {
        //            var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == selectedpreamble);

        //            PreambleName.Text = "";
        //            preambleText.Text = "";

        //            preambleNameRow.Visible = false;
        //            preambleRow.Visible = false;

        //            PreambleNamePreview.Text = preamble.Name;
        //            PreamblePreview.Text = preamble.Body;
        //            preview.Visible = true;
        //        }

        //        var quests = _db.T_Question.Where(x => x.PreambleId == selectedpreamble).OrderBy(x =>x.DateAdded).Select(a => new QuestionModel
        //        {
        //            ID = a.Id,
        //            Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : a.Details.Trim(),
        //            Type = ErecruitHelper.getTypeName(_db, a.TypeId),
        //            Preamble = ErecruitHelper.GetPreambleName(_db, a.PreambleId),
        //            OptionType = ErecruitHelper.getOptionTypeName(_db, a.OptionType),
        //            OptionsCount = ErecruitHelper.getOptionNum(_db, a.Id).ToString(),
        //            IsActive = a.IsActive.Value ? "Yes" : "No",
        //            // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
        //            D = a.IsActive.Value ? "Deactivate" : "Activate"

        //        }).Distinct().ToList();
        //     //   QuestionIndex.Text = quests.Count + " " + t.Name + " Question(s)";
        //       // GridView1.DataSource = quests;
        //        //GridView1.DataBind();



        //    }
        //    else
        //    {
        //        PreambleName.Text = "";
        //        preambleText.Text = "";
        //        PreamblePreview.Text = "";
        //        PreambleNamePreview.Text = "";

        //        preview.Visible = false;
        //        preambleNameRow.Visible = false;
        //





        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErecruitHelper.SetErrorData(ex, Session);
        //        Response.Redirect("ErrorPage.aspx", false);
        //    }
        //}
        protected void lnkeditQ_Click(object sender, EventArgs e)
        {


            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1()){
                    LinkButton lnkedit = ((LinkButton)sender);
                    var p = lnkedit.Parent;
                    HiddenField hdfID = (HiddenField)p.FindControl("hdfIDQ");
                    var idcr = long.Parse(hdfID.Value);
                    if (!(idcr == null))
                    {
                        var opt = _db.T_Question.FirstOrDefault(s => s.Id == (idcr));
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
                            var selectedQtype = long.Parse(DropDownList1.SelectedValue);
                            var quests = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TypeId == selectedQtype && x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new QuestionModel
                            {
                                ID = a.Id,
                                Detail = a.Details,
                                Type = a.Type,
                                Preamble = a.Preamble,
                                Section = a.Section,
                                OptionType = a.OptionType,
                                OptionsCount = a.OptionsCount.ToString(),
                                IsActive = a.IsActive,
                                // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                                D = a.D

                            }).ToList();
                            QuestionIndex.Text = quests.Count + " Question(s)";
                            GridView1.DataSource = quests;
                            GridView1.DataBind();

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
        //protected void SearchQuest_Click(object sender, EventArgs e)
        //{

        //}
        protected void SearchQuest_Click(object sender, EventArgs e)
        {
            var stext = searchText.Text;

            stext = "%" + stext.ToLower() + "%";

            if (string.IsNullOrEmpty(stext))
            {
                var selectedQtype = long.Parse(DropDownList1.SelectedValue);
                var quests = _db.ActiveQuestions_vw.AsEnumerable().Where(x => x.TypeId == selectedQtype && x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = a.Details,
                    Type =a.Type,
                    Section = a.Section.ToString(),
                    Preamble = a.Preamble,
                    OptionType = a.OptionType,
                    OptionsCount = a.OptionsCount.ToString(),
                    IsActive = a.IsActive,
                    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                    D = a.D

                }).Distinct().ToList();
                QuestionIndex.Text = quests.Count + " Question(s)";
                GridView1.DataSource = quests;
                GridView1.DataBind();

            }
            else
            {
                var quests = _db.SearchActiveQuestion(stext).OrderBy(x => x.Section).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = a.Details,
                    Type = a.Type,
                    Preamble = a.Preamble,
                    Section = a.Section,
                    OptionType = a.OptionType,
                    OptionsCount = a.OptionsCount.ToString(),
                    IsActive = a.IsActive,
                    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                    D = a.D

                }).Distinct().ToList();
                QuestionIndex.Text = quests.Count + " Question(s)";
                GridView1.DataSource = quests;
                GridView1.DataBind();
            }
        }
        //protected void saveQGrp_Click(object sender, EventArgs e)
        //{
        //    var tx = QG.Text;
        //}


    }
}