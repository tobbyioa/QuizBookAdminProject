using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Model;
using QuizBook.Helpers;
using System.Web.Services;
using System.IO;
using System.Data.Objects;

namespace QuizBook.Views
{
    public partial class Batches : System.Web.UI.Page
    {

        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                var PermMgr = new PermissionManager(Session);

                if (PermMgr.IsAdmin || PermMgr.CanManageTestBatches)
                {

                if (!IsPostBack)
                {

                    var l = Enum.GetValues(typeof(ErecruitHelper.BatchGroups)).Cast<ErecruitHelper.BatchGroups>().ToList();
                    var bg = l.Select(a => new
                    {
                        Id = a.ToString(),
                        Name = a.ToString()

                    }).ToList();
                    bgrp.DataSource = bg;
                    bgrp.DataBind();

                    var selectedGroup = bgrp.SelectedValue;
                    GChangeState(selectedGroup);


                    //var clear = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.ALL && s.LoggedBy == user).Select(a => new
                    //{
                    //    ID = a.GroupSelected,
                    //    Name = a.LoggedBy
                    //}).ToList() ;

                    //var seld = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == selectedGroup && s.LoggedBy == user).Select(x => long.Parse(x.SelectedID));
                    //var clear = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id)).Select(a => new
                    //{
                    //    ID = a.Id,
                    //    Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    //});

                    //SelectedGrp.DataSource = clear.ToList();
                    //SelectedGrp.DataBind();

                    var qg = _db.T_QuestionType.AsEnumerable().Where(x =>x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))&& x.Status == true).OrderBy(s => s.Name).Select(s => new
                    {
                        id = s.Id,
                        Name = s.Name
                    }).ToList();
                    qg.Insert(0, new { id = (long)-1, Name = "--Select a Question Group--" });
                    Qgroup.DataSource = qg;
                    Qgroup.DataBind();

                    var sel = Session["Selectedcrp"];

                    if (sel == null)
                    {
                        GChangeState("ALL");
                    }
                    else
                    {
                        GChangeState(sel.ToString());
                    }

                    var quests = _db.T_Batch.AsEnumerable().Where(s =>s.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).OrderByDescending(s=>s.Id).Select(a => new BatchGridModel
                    {
                        ID = a.Id,
                        Name = a.Name,
                        Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                        BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                        SessionOn = a.SessionOn.Value ? "Yes" : "No",
                        IsActive = a.IsActive.Value ? "Yes" : "No",
                        StartDate = a.StartDate.HasValue? a.StartDate.Value.ToString() : "<Not Set>",
                        EndDate = a.EndDate.HasValue? a.EndDate.Value.ToString() : "<Not Set>",
                        Duration = a.Duration.HasValue? a.Duration.ToString() : "<Not Set>",
                        NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                        DateModified = a.DateModified.HasValue ? a.DateModified.Value.ToString() : "",
                        DateAdded = a.DateAdded.HasValue ? a.DateAdded.Value.ToString() : "",
                        // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                        D = a.IsActive.Value ? "Deactivate" : "Activate",

                        State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                        ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                        StateValue = ErecruitHelper.IsBatchDone(a.Id),
                        ViewResults =  "View Results"

                    }).ToList();
                    TotalRecCount.Text = quests.Count.ToString()+" Records";
                    BatchList.DataSource = quests;
                    BatchList.DataBind();
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

        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Batches.aspx",false);
        }

        private static void AssignQuestionsToBatch(long batchId)
        {
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            var tst = _db.T_BatchQuestions.Where(s => s.BatchId == batchId).ToList();
            if (!tst.Any())
            {
                List<T_Question> questions = RandomHelper.GetQuestions().ToList();
                var q = questions.GroupBy(l => l.PreambleId);
                //List<T_Question> questions = _db.T_Question.Where(s => q.Contains(s.Id)).ToList();
                //List<long> qTypes = _db.T_QuestionType.Select(s => s.Id).Distinct().ToList();

                foreach (var qe in q)
                {
                    foreach (var s in qe)
                    {
                        var optionCount = ErecruitHelper.getOptionNum(_db,s.Id);
                        if (optionCount > 0)
                        {
                            _db.T_BatchQuestions.Add(new T_BatchQuestions
                            {
                                BatchId = batchId,
                                QuestionId = s.Id
                            });
                        }
                    }
                    _db.SaveChanges();
                }
            }
        }

        [WebMethod]
        public static string SwitchBatchActivity(string id)
        {
            try
            {
                QuizBookDbEntities1 _db = new QuizBookDbEntities1();
                var opt = _db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(id));
                if (opt != null)
                {
                    if (opt.IsActive==true)
                    {
                        opt.IsActive = false;
                        opt.DateModified = DateTime.Now;
                       // AssignQuestionsToBatch(long batchId)
                    }
                    else
                    {
                        opt.IsActive = true;
                        opt.DateModified = DateTime.Now;
                    }
                    _db.SaveChanges();
                    if (opt.IsActive.Value)
                    {
                        AssignQuestionsToBatch(opt.Id);
                    }



                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        protected void lnkeditC_Click(object sender, EventArgs e)
        {
            try{
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDC");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {

                var user = SessionHelper.FetchEmail(Session);
                var c = _db.T_Batch.FirstOrDefault(s => s.Id == idcr);
                var bs = _db.BatchScopeContents.Where(s => s.BatchId == c.Id);
                B_ID.Value = c.Id.ToString();
                B_Name.Text = c.Name;
                B_Desc.Text = c.Description;
                CutOff.Text = c.CutOff.HasValue?c.CutOff.Value.ToString():"50";
                Active.Checked = c.IsActive.HasValue?c.IsActive.Value:false;
                if (c.StartDate != null)
                {
                    B_StartDate.Text = ErecruitHelper.AppendZero(c.StartDate.Value.Day) + "/" + ErecruitHelper.AppendZero(c.StartDate.Value.Month) + "/" + ErecruitHelper.AppendZero(c.StartDate.Value.Year) + " " + ErecruitHelper.AppendZero(c.StartDate.Value.Hour) + ":" + ErecruitHelper.AppendZero(c.StartDate.Value.Minute);
                }
                if (c.EndDate != null)
                {
                    B_EndDate.Text = ErecruitHelper.AppendZero(c.EndDate.Value.Day) + "/" + ErecruitHelper.AppendZero(c.EndDate.Value.Month) + "/" + ErecruitHelper.AppendZero(c.EndDate.Value.Year) + " " + ErecruitHelper.AppendZero(c.EndDate.Value.Hour) + ":" + ErecruitHelper.AppendZero(c.EndDate.Value.Minute);
                }
                if (c.Duration.Value != null)
                {
                Duration.Text = c.Duration.ToString();
                }

                var y = "";


                if (bs.Any())
                {

                    y = bs.FirstOrDefault().BatchScope;
                    bgrp.SelectedValue = y;
                    var qtt = bs.FirstOrDefault().T_QuestionType;
                    if (qtt.Status == false)
                    {
                        //var qg = _db.T_QuestionType.Where(x => x.Status == true).OrderBy(s => s.Name).Select(s => new
                        //{
                        //    id = s.Id,
                        //    Name = s.Name
                        //}).ToList();
                        //qg.Insert(0, new { id = (long)-1, Name = "--Select a Question Group--" });

                        var qg = _db.T_QuestionType.AsEnumerable().Where(x => x.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && x.Status == true).OrderBy(s => s.Name).Select(s => new
                        {
                            id = s.Id,
                            Name = s.Name
                        }).ToList();
                        qg.Insert(0, new { id = (long)-1, Name = "--Select a Question Group--" });
                        Qgroup.DataSource = qg;
                        Qgroup.DataBind();

                        //Qgroup.DataSource = qg;
                        //Qgroup.DataBind();
                        alert.Text ="The attached Question Group is inactive";
                    }
                    else
                    {
                        var qg = _db.T_QuestionType.AsEnumerable().Where(x => x.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && x.Status == true).OrderBy(s => s.Name).Select(s => new
                        {
                            id = s.Id,
                            Name = s.Name
                        }).ToList();
                        qg.Insert(0, new { id = (long)-1, Name = "--Select a Question Group--" });
                        Qgroup.SelectedValue = qtt.Id.ToString();
                        Qgroup.DataSource = qg;
                        Qgroup.DataBind();
                        alert.Text = "";
                    }
                }
                else
                {
                    var qg = _db.T_QuestionType.AsEnumerable().Where(x => x.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && x.Status == true).OrderBy(s => s.Name).Select(s => new
                    {
                        id = s.Id,
                        Name = s.Name
                    }).ToList();
                    qg.Insert(0, new { id = (long)-1, Name = "--Select a Question Group--" });
                    Qgroup.DataSource = qg;
                    Qgroup.DataBind();

                }


               // GChangeState(y);

                switch (y)
                {
                    case ErecruitHelper.BGS.ALL:
                        var seld = bs.AsEnumerable().Select(s => long.Parse(s.ScopeContentId)).ToArray();

                        var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                        {

                            ID = a.Id,
                            Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                        });
                        SelectedGrp.DataSource = cands;
                        SelectedGrp.DataBind();
                        // _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString())
                        var cs = _db.AllMyCandidates.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString() && !seld.Contains(s.Id)).Select(a => new
                        {

                            ID = a.Id,
                            Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                        }).ToList();

                        GroupContentList.DataSource = cs;
                        GroupContentList.DataBind();
                        break;
                    case ErecruitHelper.BGS.BRANCH:

                        var selb = bs.Select(s => s.ScopeContentId).ToArray();

                        var b = _db.branch_tab.Where(s => selb.Contains(s.sol_id)).Select(a => new
                        {
                            ID = a.sol_id,
                            Name = a.branch_name
                        });
                        SelectedGrp.DataSource = b;
                        SelectedGrp.DataBind();
                        var br = _db.branch_tab.OrderBy(x => x.branch_name).Where(s => !selb.Contains(s.sol_id)).Select(a => new
                        {
                            ID = a.sol_id,
                            Name = a.branch_name
                        }).ToList();

                        GroupContentList.DataSource = br;
                        GroupContentList.DataBind();
                        break;
                    case ErecruitHelper.BGS.DIVISION:


                        var seldiv = bs.Select(s => s.ScopeContentId).ToArray();
                        var d = _db.division_tab.Where(s => seldiv.Contains(s.DIV_CODE)).Select(a => new
                        {
                            ID = a.DIV_CODE,
                            Name = a.DIV_NAME
                        });
                        SelectedGrp.DataSource = d;
                        SelectedGrp.DataBind();
                        var div = _db.division_tab.OrderBy(x => x.DIV_NAME).Where(s => !seldiv.Contains(s.DIV_CODE)).Select(a => new
                        {
                            ID = a.DIV_CODE,
                            Name = a.DIV_NAME
                        }).ToList();

                        GroupContentList.DataSource = div;
                        GroupContentList.DataBind();
                        break;
                    case ErecruitHelper.BGS.GRADE:


                        var selgr = bs.Select(s => s.ScopeContentId).ToArray();
                        var g = _db.grade_tab.Where(s => selgr.Contains(s.GRADE_CODE)).Select(a => new
                        {
                            ID = a.GRADE_CODE,
                            Name = a.GRADE_LEVEL
                        });
                        SelectedGrp.DataSource = g;
                        SelectedGrp.DataBind();
                        var gr = _db.grade_tab.OrderBy(x => x.GRADE_LEVEL).Where(s => !selgr.Contains(s.GRADE_CODE)).Select(a => new
                        {
                            ID = a.GRADE_CODE,
                            Name = a.GRADE_LEVEL
                        }).ToList();

                        GroupContentList.DataSource = gr;
                        GroupContentList.DataBind();

                        break;
                    case ErecruitHelper.BGS.BANK:

                        var selreg = bs.Select(s => int.Parse(s.ScopeContentId)).ToArray();
                        var r = _db.region_tab.Where(s => selreg.Contains(s.region_code)).Select(a => new
                        {
                            ID = a.region_code,
                            Name = a.region_name
                        });
                        SelectedGrp.DataSource = r;
                        SelectedGrp.DataBind();
                        var reg = _db.region_tab.OrderBy(x => x.region_name).Where(s => !selreg.Contains(s.region_code)).Select(a => new
                        {
                            ID = a.region_code,
                            Name = a.region_name
                        }).ToList();

                        GroupContentList.DataSource = reg;
                        GroupContentList.DataBind();
                        break;
                    case ErecruitHelper.BGS.DIRECTORATE:

                        var selsec = bs.Select(s => s.ScopeContentId).ToArray();
                        var sec = _db.sector_tab.Where(s => selsec.Contains(s.SECTOR_CODE)).Select(a => new
                        {
                            ID = a.SECTOR_CODE,
                            Name = a.SECTOR_NAME
                        });
                        SelectedGrp.DataSource = sec;
                        SelectedGrp.DataBind();
                        var secs = _db.sector_tab.OrderBy(x => x.SECTOR_NAME).Where(s => !selsec.Contains(s.SECTOR_CODE)).Select(a => new
                        {
                            ID = a.SECTOR_CODE,
                            Name = a.SECTOR_NAME
                        }).ToList();

                        GroupContentList.DataSource = secs;
                        GroupContentList.DataBind();
                        break;
                    default:
                        break;
                }

                    ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps,_db.BatchConfigurationTemps.AsEnumerable().Where(s => s.LoggedBy == user).AsEnumerable());
                    //ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps, (_db.BatchConfigurationTemps.AsEnumerable().Where(s => s.LoggedBy == SessionHelper.FetchEmail(Session))));
                   //_db.BatchConfigurationTemps.DeleteAllOnSubmit(_db.BatchConfigurationTemps.Where(s => s.LoggedBy == user));

                    _db.SaveChanges();
                    var se = bs.Select(s => s.ScopeContentId);
                    var n = new List<BatchConfigurationTemp>();
                    foreach (var g in se)
                    {
                        n.Add(new BatchConfigurationTemp
                        {
                            GroupSelected = y,
                            SelectedID = g.ToString(),
                            LoggedBy = user,
                            DateLogged = DateTime.Now
                        });
                    }
                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(n);
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, n);

                    _db.SaveChanges();


                //if (c.IsActive.Value != null)
                //{
                //    Active.Checked = c.IsActive.Value;
                //}
            }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
             }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var name = B_Name.Text;
                var desc = B_Desc.Text;
                var Stdate = B_StartDate.Text;
                var Endate = B_EndDate.Text;
                var duration = Duration.Text;
                var cutOff = decimal.Parse(CutOff.Text);
                var selectedGroup = bgrp.SelectedValue;
                var qG = Qgroup.SelectedValue;

                var useremail = SessionHelper.FetchEmail(Session);
                ListItemCollection cids = SelectedGrp.Items;
                //foreach (int x in selected)
                //{
                //    cids.Add(SelectedGrp.Items[x].Value);
                //}

                 var cid = B_ID.Value;
                 if (!string.IsNullOrEmpty(cid))
                 {
                     var batch = _db.T_Batch.AsEnumerable().FirstOrDefault(s => s.Id == long.Parse(cid));

                     //if (!batch.IsActive.Value)
                     //{
                         batch.Name = name;
                         batch.Description = desc;
                         batch.IsActive = Active.Checked;
                         batch.StartDate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(Stdate);
                         batch.EndDate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(Endate);
                         batch.Duration = int.Parse(duration);
                         batch.CutOff = cutOff;
                         batch.TenantId = long.Parse(SessionHelper.GetTenantID(Session));
                         batch.ModifiedBy = SessionHelper.FetchEmail(Session);
                         batch.DateModified = DateTime.Now;


                         ExtensionMethods.DeleteObjects(_db.BatchScopeContents, _db.BatchScopeContents.AsEnumerable().Where(x => x.BatchId == batch.Id));
                         //_db.BatchScopeContents.DeleteAllOnSubmit(_db.BatchScopeContents.Where(x => x.BatchId == batch.Id));

                         switch (selectedGroup)
                         {
                             case ErecruitHelper.BGS.ALL:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.ALL,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                               //  _db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.BRANCH:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.BRANCH,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                // _db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.DIVISION:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.DIVISION,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                // _db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.GRADE:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.GRADE,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                // _db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.BANK:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.BANK,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.DIRECTORATE:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.DIRECTORATE,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                // _db.SaveChanges();
                                 break;
                         }

                         _db.SaveChanges();
                         ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps,_db.BatchConfigurationTemps.Where(s => s.LoggedBy == useremail));
                         _db.SaveChanges();
                         alert.Text = "";
                         Response.Redirect("Batches.aspx", false);
                     //}
                     //else
                     //{
                     //    alert.Text = "This batch cannot be edited because its currently active";
                     //  //  Response.Redirect("Batches.aspx", false);
                     //}
                 }
                 else
                 {

                     var exBatch = _db.T_Batch.AsEnumerable().FirstOrDefault(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Name.Trim().ToLower() == name.Trim().ToLower());

                     if (exBatch != null) {
                         AlertLbl.Text = "You already have a batch with this name";
                     }
                     else
                     {
                        var batch = new T_Batch
                        {
                            Name = name,
                            Description = desc,
                            TenantId = long.Parse(SessionHelper.GetTenantID(Session)),
                            StartDate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(Stdate),
                            EndDate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(Endate),
                            Duration = int.Parse(duration),
                            CutOff = cutOff,
                             IsActive = Active.Checked,
                             BatchType = ErecruitHelper.BatchType.Multiple.ToString(),
                             SessionOn = false,
                             AddedBy = SessionHelper.FetchEmail(Session),
                             DateAdded = DateTime.Now
                         };
                         _db.T_Batch.Add(batch);
                         _db.SaveChanges();


                         switch (selectedGroup)
                         {
                             case ErecruitHelper.BGS.ALL:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.ALL,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.BRANCH:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.BRANCH,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.DIVISION:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.DIVISION,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.GRADE:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.GRADE,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.BANK:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.BANK,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 // _db.SaveChanges();
                                 break;
                             case ErecruitHelper.BGS.DIRECTORATE:
                                 foreach (ListItem x in cids)
                                 {
                                     _db.BatchScopeContents.Add(new BatchScopeContent
                                     {
                                         BatchId = batch.Id,
                                         BatchScope = ErecruitHelper.BGS.DIRECTORATE,
                                         ScopeContentId = x.Value,
                                         QuestionTypeId = long.Parse(qG)
                                     });
                                 }
                                 //_db.SaveChanges();
                                 break;
                         }
                         _db.SaveChanges();
                         ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps, _db.BatchConfigurationTemps.Where(s => s.LoggedBy == useremail));
                         _db.SaveChanges();
                         Response.Redirect("Batches.aspx", false);
                     }
                 }



            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void BatchList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //var quests = _db.T_Batch.OrderBy(s => s.IsActive).Select(a => new BatchGridModel
            //{
            //    ID = a.Id,
            //    Name = a.Name,
            //    Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
            //    BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
            //    SessionOn = a.SessionOn.Value ? "Yes" : "No",
            //    IsActive = a.IsActive.Value ? "Yes" : "No",
            //    StartDate = a.StartDate.Value != null ? a.StartDate.Value.ToString() : "<Not Set>",
            //    Duration = a.Duration != null ? a.Duration.ToString() : "<Not Set>",
            //    NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
            //    DateModified = a.DateModified.Value != null ? a.DateModified.Value.ToString() : "",
            //    DateAdded = a.DateAdded.Value != null ? a.DateAdded.Value.ToString() : "",

            //    D = a.IsActive.Value ? "Deactivate" : "Activate",
            //    State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
            //            ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
            //            StateValue = ErecruitHelper.IsBatchDone(a.Id),
            //            ViewResults =  "View Results"

            //}).Distinct().ToList();
            //BatchList.DataSource = quests.OrderByDescending(s => s.DateAdded).OrderByDescending(x => x.StartDate).OrderByDescending(x => x.IsActive).ToList();
            var quests = _db.T_Batch.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).OrderByDescending(s => s.Id).Select(a => new BatchGridModel
            {
                ID = a.Id,
                Name = a.Name,
                Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                SessionOn = a.SessionOn.Value ? "Yes" : "No",
                IsActive = a.IsActive.Value ? "Yes" : "No",
                StartDate = a.StartDate.HasValue ? a.StartDate.Value.ToString() : "<Not Set>",
                EndDate = a.EndDate.HasValue ? a.EndDate.Value.ToString() : "<Not Set>",
                Duration = a.Duration.HasValue ? a.Duration.ToString() : "<Not Set>",
                NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                DateModified = a.DateModified.HasValue ? a.DateModified.Value.ToString() : "",
                DateAdded = a.DateAdded.HasValue ? a.DateAdded.Value.ToString() : "",
                // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                D = a.IsActive.Value ? "Deactivate" : "Activate",

                State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                StateValue = ErecruitHelper.IsBatchDone(a.Id),
                ViewResults = "View Results"

            }).ToList();
            BatchList.DataSource = quests;
            TotalRecCount.Text = quests.Count.ToString() + " Records";
            BatchList.PageIndex = e.NewPageIndex;
            BatchList.DataBind();
        }

        protected void BatchList_Sorting(object sender, GridViewSortEventArgs e)
        {
            var quests = _db.T_Batch.OrderBy(s => s.IsActive).Select(a => new BatchGridModel
            {
                ID = a.Id,
                Name = a.Name,
                Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                SessionOn = a.SessionOn.Value ? "Yes" : "No",
                IsActive = a.IsActive.Value ? "Yes" : "No",
                StartDate = a.StartDate.Value != null ? a.StartDate.Value.ToString() : "<Not Set>",
                Duration = a.Duration != null ? a.Duration.ToString() : "<Not Set>",
                NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                DateModified = a.DateModified.Value != null ? a.DateModified.Value.ToString() : "",
                DateAdded = a.DateAdded.Value != null ? a.DateAdded.Value.ToString() : "",
                // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                D = a.IsActive.Value ? "Deactivate" : "Activate",
                State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                StateValue = ErecruitHelper.IsBatchDone(a.Id),
                ViewResults = "View Results"


            }).Distinct().ToList();

            quests = quests.OrderByDescending(s => s.DateAdded).OrderByDescending(x => x.StartDate).OrderByDescending(x => x.IsActive).ToList();

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
                case "Name":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.Name).ToList();

                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.Name).ToList(); ;
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataBind();
                    }

                    break;
                case "Description":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.Description).ToList();

                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.Description).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }

                    break;
                case "BatchType":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.BatchType).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.BatchType).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }

                    break;
                case "StartDate":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.StartDate).ToList();

                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.StartDate).ToList(); ;
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataBind();
                    }

                    break;
                case "Duration":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.Duration).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.Duration).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }

                    break;
                case "NoOfQuestions":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.NoOfQuestions).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.NoOfQuestions).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    break;
                case "IsActive":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.IsActive).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }

                    break;
                case "SessionOn":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        quests = quests.OrderBy(s => s.SessionOn).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }
                    else
                    {
                        quests = quests.OrderByDescending(s => s.SessionOn).ToList();
                        TotalRecCount.Text = quests.Count.ToString() + " Records";
                        BatchList.DataSource = quests.OrderByDescending(x => x.IsActive).ToList();
                        BatchList.DataBind();
                    }

                    break;

            }
        }

        protected void lnkeditB_Click(object sender, EventArgs e)
        {
            try
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    LinkButton lnkedit = ((LinkButton)sender);
                    var p = lnkedit.Parent;
                    HiddenField hdfID = (HiddenField)p.FindControl("hdfIDB");
                    var idcr = long.Parse(hdfID.Value);
                    if (!(idcr == null))
                    {
                        var opt = _db.T_Batch.FirstOrDefault(s => s.Id == idcr);
                        if (opt != null)
                        {
                            if (opt.IsActive == true)
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
                            //if (opt.IsActive.Value)
                            //{
                            //    AssignQuestionsToBatch(opt.Id);
                            //}

                            var quests = _db.T_Batch.AsEnumerable().Where(x => x.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).Select(a => new BatchGridModel
                            {
                                ID = a.Id,
                                Name = a.Name,
                                Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                                BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                                SessionOn = a.SessionOn.Value ? "Yes" : "No",
                                IsActive = a.IsActive.Value ? "Yes" : "No",
                                StartDate = a.StartDate != null ? a.StartDate.Value.ToString() : "<Not Set>",
                                EndDate = a.EndDate != null ? a.EndDate.Value.ToString() : "<Not Set>",
                                Duration = a.Duration != null ? a.Duration.ToString() : "<Not Set>",
                                NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                                DateModified = a.DateModified.Value != null ? a.DateModified.Value.ToString() : "",
                                DateAdded = a.DateAdded.Value != null ? a.DateAdded.Value.ToString() : "",
                                // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                                D = a.IsActive.Value ? "Deactivate" : "Activate",

                                State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                                ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                                StateValue = ErecruitHelper.IsBatchDone(a.Id),
                                ViewResults = "View Results"

                            }).Distinct().ToList();
                            TotalRecCount.Text = quests.Count.ToString() + " Records";
                            //BatchList.DataSource = quests.OrderByDescending(s => s.DateAdded).OrderByDescending(x => x.StartDate).OrderByDescending(x => x.IsActive).ToList();
                            BatchList.DataSource = quests.OrderByDescending(x => x.ID).ToList();
                            BatchList.DataBind();

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

        protected void SearchQuest_Click(object sender, EventArgs e)
        {
            try{
              var stext = searchText.Text;
              if (string.IsNullOrEmpty(stext))
              {
                  //var quests = _db.T_Batch.OrderBy(s => s.IsActive).Select(a => new BatchGridModel
                  //{
                  //    ID = a.Id,
                  //    Name = a.Name,
                  //    Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                  //    BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                  //    SessionOn = a.SessionOn.Value ? "Yes" : "No",
                  //    IsActive = a.IsActive.Value ? "Yes" : "No",
                  //    StartDate = a.StartDate.Value != null ? a.StartDate.Value.ToString() : "<Not Set>",
                  //    Duration = a.Duration != null ? a.Duration.ToString() : "<Not Set>",
                  //    NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                  //    DateModified = a.DateModified.Value != null ? a.DateModified.Value.ToString() : "",
                  //    DateAdded = a.DateAdded.Value != null ? a.DateAdded.Value.ToString() : "",
                  //    // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                  //    D = a.IsActive.Value ? "Deactivate" : "Activate",

                  //    State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                  //    ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                  //    StateValue = ErecruitHelper.IsBatchDone(a.Id),
                  //    ViewResults = "View Results"

                  //}).Distinct().ToList();
                  var quests = _db.T_Batch.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session))).OrderByDescending(s => s.Id).Select(a => new BatchGridModel
                  {
                      ID = a.Id,
                      Name = a.Name,
                      Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                      BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                      SessionOn = a.SessionOn.Value ? "Yes" : "No",
                      IsActive = a.IsActive.Value ? "Yes" : "No",
                      StartDate = a.StartDate.HasValue ? a.StartDate.Value.ToString() : "<Not Set>",
                      EndDate = a.EndDate.HasValue ? a.EndDate.Value.ToString() : "<Not Set>",
                      Duration = a.Duration.HasValue ? a.Duration.ToString() : "<Not Set>",
                      NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                      DateModified = a.DateModified.HasValue ? a.DateModified.Value.ToString() : "",
                      DateAdded = a.DateAdded.HasValue ? a.DateAdded.Value.ToString() : "",
                      // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                      D = a.IsActive.Value ? "Deactivate" : "Activate",

                      State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                      ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                      StateValue = ErecruitHelper.IsBatchDone(a.Id),
                      ViewResults = "View Results"

                  }).ToList();
                  TotalRecCount.Text = quests.Count.ToString() + " Records";
                  BatchList.DataSource = quests;
                  BatchList.DataBind();
              }
              else
              {
                  var quests = _db.T_Batch.AsEnumerable().Where(x => x.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && x.Name.Contains(stext) || x.Description.Contains(stext)).OrderByDescending(s => s.Id).Select(a => new BatchGridModel
                  {
                      ID = a.Id,
                      Name = a.Name,
                      Description = string.IsNullOrEmpty(a.Description) ? "<Empty>" : a.Description.Trim(),
                      BatchType = string.IsNullOrEmpty(a.BatchType) ? ErecruitHelper.BatchType.Multiple.ToString() : a.BatchType,
                      SessionOn = a.SessionOn.Value ? "Yes" : "No",
                      IsActive = a.IsActive.Value ? "Yes" : "No",
                      StartDate = a.StartDate.HasValue ? a.StartDate.Value.ToString() : "<Not Set>",
                      EndDate = a.EndDate.HasValue ? a.EndDate.Value.ToString() : "<Not Set>",
                      Duration = a.Duration.HasValue ? a.Duration.ToString() : "<Not Set>",
                      NoOfQuestions = _db.T_BatchQuestions.Count(s => s.BatchId == a.Id).ToString(),
                      DateModified = a.DateModified.HasValue ? a.DateModified.Value.ToString() : "",
                      DateAdded = a.DateAdded.HasValue ? a.DateAdded.Value.ToString() : "",
                      // D = "<a id='" + a.Id.ToString() + "'  onclick='deleteQuest(this)' href='#' >Delete</a>"
                      D = a.IsActive.Value ? "Deactivate" : "Activate",

                      State = ErecruitHelper.IsBatchDone(a.Id) ? "FINISHED" : "NOT FINISHED",
                      ActivateLinkActive = ErecruitHelper.IsBatchDone(a.Id) ? false : true,
                      StateValue = ErecruitHelper.IsBatchDone(a.Id),
                      ViewResults = "View Results"

                  }).Distinct().ToList();
                  TotalRecCount.Text = quests.Count.ToString() + " Records";
                  BatchList.DataSource = quests;
                  BatchList.DataBind();
              }
             }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void lnkeditResults_Click(object sender, EventArgs e)
        {
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDResults");
            var bid = hdfID.Value;

            if (!string.IsNullOrEmpty(bid))
            {
                var batch = _db.T_Batch.FirstOrDefault(s => s.Id == long.Parse(bid));
                if (batch != null && batch.BatchType == ErecruitHelper.BatchType.Single.ToString())
                {
                    var cid = _db.T_Candidate.FirstOrDefault(x => x.Id == (_db.T_BatchSet.FirstOrDefault(s => s.BatchId == batch.Id).CandidateId)).Code;

                    Response.Redirect("ViewTR.aspx?z=" + cid + "&y=" + batch.Id, false);
                }
                else if (batch.BatchType == ErecruitHelper.BatchType.Multiple.ToString())
                {
                    Response.Redirect("ViewBatchResult.aspx?z=" + batch.Id, false);
                }
            }


        }

        private void GChangeState( string selectedGroup)
        {
            var user = SessionHelper.FetchEmail(Session);

            switch (selectedGroup)
            {
                case ErecruitHelper.BGS.ALL:

                    //var cands = _db.AllCandidates_vw.Where(s => s.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString() && s.IsActive.Value == true).Select(a => new CandidateDropDownModel
                    //{
                    //    ID = a.Id,
                    //    Name = a.Code + " - " + a.LastName + " " + a.FirstName
                    //}).ToList();

                    //var cands = _db.AllMyCandidates.AsEnumerable().Where(s =>s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new CandidateDropDownModel
                    //{
                    //    ID = a.Id,
                    //    Name = a.LastName + " " + a.FirstName+" ["+a.Username + "]"
                    //}).ToList();
                    //GroupContentList.DataSource = cands;
                    //GroupContentList.DataBind();

                   var seld = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == selectedGroup && s.LoggedBy == user).Select(x => long.Parse(x.SelectedID)).Distinct();


                    var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                    {
                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                     });

                    SelectedGrp.DataSource = cands.ToList();
                    SelectedGrp.DataBind();

                    var cs = _db.AllMyCandidates.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString() && !seld.Contains(s.Id)).Select(a => new
                    {

                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    }).ToList();

                    GroupContentList.DataSource = cs;
                    GroupContentList.DataBind();



                    break;
                //case ErecruitHelper.BGSR.BATCHES:
                //    var cands1 = _db.T_Batch.OrderBy(x => x.Name).Select(a => new
                //    {
                //        ID = a.Id,
                //        Name = a.Name.ToUpper()
                //    }).ToList();
                //    GroupContentList.DataSource = cands1;
                //    GroupContentList.DataBind();
                //    break;
                //case ErecruitHelper.BGS.BRANCH:
                //    var candsx = _db.branch_tab.OrderBy(x => x.branch_name).Select(a => new
                //    {
                //        ID = a.id,
                //        Name = a.branch_name
                //    }).ToList();
                //    GroupContentList.DataSource = candsx;
                //    GroupContentList.DataBind();
                //    break;
                //case ErecruitHelper.BGS.DIVISION:

                //    var cands2 = _db.division_tab.OrderBy(x => x.DIV_NAME).Select(a => new
                //    {
                //        ID = a.DIV_CODE,
                //        Name = a.DIV_NAME
                //    }).ToList();
                //    GroupContentList.DataSource = cands2;
                //    GroupContentList.DataBind();
                //    break;
                //case ErecruitHelper.BGS.GRADE:

                //    var cands3 = _db.grade_tab.OrderBy(x => x.GRADE_LEVEL).Select(a => new
                //    {
                //        ID = a.GRADE_CODE,
                //        Name = a.GRADE_LEVEL
                //    }).ToList();
                //    GroupContentList.DataSource = cands3;
                //    GroupContentList.DataBind();
                //    break;
                //case ErecruitHelper.BGS.BANK:

                //    var cands4 = _db.region_tab.OrderBy(x => x.region_name).Select(a => new
                //    {
                //        ID = a.region_code,
                //        Name = a.region_name
                //    }).ToList();
                //    GroupContentList.DataSource = cands4;
                //    GroupContentList.DataBind();
                //    break;
                //case ErecruitHelper.BGS.DIRECTORATE:
                //    //Clear Existing

                //    var cands5 = _db.sector_tab.OrderBy(x => x.SECTOR_NAME).Select(a => new
                //    {
                //        ID = a.SECTOR_CODE,
                //        Name = a.SECTOR_NAME
                //    }).ToList();
                //    GroupContentList.DataSource = cands5;
                //    GroupContentList.DataBind();

                //    break;
            }


        }

        protected void bgrp_SelectedIndexChanged(object sender, EventArgs e)
        {//Clear Existing
            ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps, (_db.BatchConfigurationTemps.AsEnumerable().Where(s => s.LoggedBy == SessionHelper.FetchEmail(Session))));
           // _db.BatchConfigurationTemps.DeleteAllOnSubmit(_db.BatchConfigurationTemps.Where(s => s.LoggedBy == SessionHelper.FetchEmail(Session)));
            _db.SaveChanges();

            var selectedGroup = bgrp.SelectedValue;
            GChangeState(selectedGroup);

            //var user = SessionHelper.FetchEmail(Session);
            //var clear = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.ALL && s.LoggedBy == user).Select(a => new
            //{
            //    ID = a.GroupSelected,
            //    Name = a.LoggedBy
            //}); ;

            //SelectedGrp.DataSource = clear;
            //SelectedGrp.DataBind();

        }
        //Add to selected list from List
        protected void Button1_Click(object sender, EventArgs e)
        {
            var selectedGroup = bgrp.SelectedValue;

            int[] selected = GroupContentList.GetSelectedIndices();
            //var contentIds = new List<int>();
            var cids = new List<string>();

            var de = GroupContentList.Items;
            foreach (int x in selected)
            {
                cids.Add(GroupContentList.Items[x].Value);
            }
            var user = SessionHelper.FetchEmail(Session);
            switch (selectedGroup)
            {
                case ErecruitHelper.BGS.ALL:
                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s.ToString(),
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));

                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());




                    _db.SaveChanges();
                    var seld = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == selectedGroup && s.LoggedBy == user).Select(x => long.Parse(x.SelectedID)).Distinct();


                    var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                    {
                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                     });

                    SelectedGrp.DataSource = cands.ToList();
                    SelectedGrp.DataBind();

                    var cs = _db.AllMyCandidates.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString() && !seld.Contains(s.Id)).Select(a => new
                    {

                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    }).ToList();

                    GroupContentList.DataSource = cs;
                    GroupContentList.DataBind();

                    break;
                case ErecruitHelper.BGS.BRANCH:
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());
                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s.ToString(),
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));
                    _db.SaveChanges();
                    var selb = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.BRANCH && s.LoggedBy == user).Select(x => x.SelectedID);
                     var b= _db.branch_tab.Where(s =>selb.Contains(s.sol_id)).Select(a => new
                    {
                        ID = a.sol_id,
                        Name = a.branch_name
                    });
                    SelectedGrp.DataSource = b;
                    SelectedGrp.DataBind();
                    var br = _db.branch_tab.OrderBy(x =>x.branch_name).Where(s => !selb.Contains(s.sol_id)).Select(a => new
                    {
                        ID = a.sol_id,
                        Name = a.branch_name
                    }).ToList();

                    GroupContentList.DataSource = br;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIVISION:

                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s.ToString(),
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());
                    _db.SaveChanges();
                   var seldiv = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.DIVISION && s.LoggedBy == user).Select(x => x.SelectedID);
                     var d= _db.division_tab.Where(s =>seldiv.Contains(s.DIV_CODE)).Select(a => new
                    {
                        ID = a.DIV_CODE,
                        Name = a.DIV_NAME
                    });
                    SelectedGrp.DataSource = d;
                    SelectedGrp.DataBind();
                    var div = _db.division_tab.OrderBy(x =>x.DIV_NAME).Where(s => !seldiv.Contains(s.DIV_CODE)).Select(a => new
                    {
                        ID = a.DIV_CODE,
                        Name = a.DIV_NAME
                    }).ToList();

                    GroupContentList.DataSource = div;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.GRADE:
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());
                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s,
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));
                    _db.SaveChanges();
                   var selgr = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.GRADE && s.LoggedBy == user).Select(x => x.SelectedID);
                     var g= _db.grade_tab.Where(s =>selgr.Contains(s.GRADE_CODE)).Select(a => new
                    {
                        ID = a.GRADE_CODE,
                        Name = a.GRADE_LEVEL
                    });
                    SelectedGrp.DataSource = g;
                    SelectedGrp.DataBind();
                    var gr = _db.grade_tab.OrderBy(x =>x.GRADE_LEVEL).Where(s => !selgr.Contains(s.GRADE_CODE)).Select(a => new
                    {
                        ID = a.GRADE_CODE,
                        Name = a.GRADE_LEVEL
                    }).ToList();

                    GroupContentList.DataSource = gr;
                    GroupContentList.DataBind();

                    break;
                case ErecruitHelper.BGS.BANK:
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());

                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s.ToString(),
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));
                    _db.SaveChanges();
                  var selreg = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.BANK && s.LoggedBy == user).Select(x => int.Parse(x.SelectedID));
                        var r= _db.region_tab.Where(s =>selreg.Contains(s.region_code)).Select(a => new
                    {
                        ID = a.region_code,
                        Name = a.region_name
                    });
                    SelectedGrp.DataSource = r;
                    SelectedGrp.DataBind();
                    var reg = _db.region_tab.OrderBy(x =>x.region_name).Where(s => !selreg.Contains(s.region_code)).Select(a => new
                    {
                        ID = a.region_code,
                        Name = a.region_name
                    }).ToList();

                    GroupContentList.DataSource = reg;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIRECTORATE:
                    ExtensionMethods.InsertAllOnSubmit(_db.BatchConfigurationTemps, cids.Select(s => new BatchConfigurationTemp
                    {
                        GroupSelected = selectedGroup,
                        SelectedID = s.ToString(),
                        LoggedBy = user,
                        DateLogged = DateTime.Now
                    }).ToList());
                    //_db.BatchConfigurationTemps.InsertAllOnSubmit(cids.Select(s => new BatchConfigurationTemp
                    //{
                    //    GroupSelected = selectedGroup,
                    //    SelectedID = s.ToString(),
                    //    LoggedBy = user,
                    //    DateLogged = DateTime.Now
                    //}));
                    _db.SaveChanges();
                   var selsec = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.DIRECTORATE && s.LoggedBy == user).Select(x => x.SelectedID);
                     var sec= _db.sector_tab.Where(s =>selsec.Contains(s.SECTOR_CODE)).Select(a => new
                    {
                        ID = a.SECTOR_CODE,
                        Name = a.SECTOR_NAME
                    });
                    SelectedGrp.DataSource = sec;
                    SelectedGrp.DataBind();
                    var secs = _db.sector_tab.OrderBy(x =>x.SECTOR_NAME).Where(s => !selsec.Contains(s.SECTOR_CODE)).Select(a => new
                    {
                        ID = a.SECTOR_CODE,
                        Name = a.SECTOR_NAME
                    }).ToList();

                    GroupContentList.DataSource = secs;
                    GroupContentList.DataBind();
                    break;
            }


        }
        // Remove Selected from List
        protected void Button2_Click(object sender, EventArgs e)
        {
            var selectedGroup = bgrp.SelectedValue;

            int[] selected = SelectedGrp.GetSelectedIndices();
            //var contentIds = new List<int>();
            var cids = new List<string>();
           // var de = SelectedGrp.Items;
            foreach (int x in selected)
            {
                cids.Add(SelectedGrp.Items[x].Value);
            }

            var user = SessionHelper.FetchEmail(Session);
            var delTemp  =  _db.BatchConfigurationTemps.AsEnumerable().Where(x => x.GroupSelected.Trim() == selectedGroup.Trim() && x.LoggedBy == user && cids.Contains(x.SelectedID.ToString()));
            //_db.BatchConfigurationTemps.DeleteAllOnSubmit(delTemp);
            ExtensionMethods.DeleteObjects(_db.BatchConfigurationTemps, delTemp);
            _db.SaveChanges();

            switch (selectedGroup)
            {
                case ErecruitHelper.BGS.ALL:

                    //var seld = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.ALL && s.LoggedBy == user).Select(x => long.Parse(x.SelectedID));

                    ////var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                    ////{
                    ////    ID = a.Id,
                    ////    Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    ////});
                    //var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                    //{
                    //    ID = a.Id,
                    //    Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    //});
                    //SelectedGrp.DataSource = cands.ToList();
                    //SelectedGrp.DataBind();
                    //var cs = _db.AllMyCandidates.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString() && !seld.Contains(s.Id)).OrderBy(x => x.FirstName).Select(a => new
                    //{
                    //    ID = a.Id,
                    //    Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    //}).ToList();

                    //GroupContentList.DataSource = cs;
                    //GroupContentList.DataBind();

                    var seld = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == selectedGroup && s.LoggedBy == user).Select(x => long.Parse(x.SelectedID)).Distinct();


                    var cands = _db.AllMyCandidates.AsEnumerable().Where(s => seld.Contains(s.Id) && s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString()).Select(a => new
                    {
                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                     });

                    SelectedGrp.DataSource = cands.ToList();
                    SelectedGrp.DataBind();

                    var cs = _db.AllMyCandidates.AsEnumerable().Where(s => s.TenantId == long.Parse(SessionHelper.GetTenantID(Session)) && s.Status.Trim() == ErecruitHelper.CandidateStatus.Active.ToString() && !seld.Contains(s.Id)).Select(a => new
                    {

                        ID = a.Id,
                        Name = a.LastName + " " + a.FirstName + " [" + a.Username + "]"
                    }).ToList();

                    GroupContentList.DataSource = cs;
                    GroupContentList.DataBind();

                    break;
                case ErecruitHelper.BGS.BRANCH:

                    var selb = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.BRANCH && s.LoggedBy == user).Select(x => x.SelectedID);
                    var b = _db.branch_tab.Where(s => selb.Contains(s.sol_id)).Select(a => new
                    {
                        ID = a.sol_id,
                        Name = a.branch_name
                    });
                    SelectedGrp.DataSource = b;
                    SelectedGrp.DataBind();
                    var br = _db.branch_tab.OrderBy(x => x.branch_name).Where(s => !selb.Contains(s.sol_id)).Select(a => new
                    {
                        ID = a.sol_id,
                        Name = a.branch_name
                    }).ToList();

                    GroupContentList.DataSource = br;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIVISION:


                    var seldiv = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.DIVISION && s.LoggedBy == user).Select(x => x.SelectedID);
                    var d = _db.division_tab.Where(s => seldiv.Contains(s.DIV_CODE)).Select(a => new
                    {
                        ID = a.DIV_CODE,
                        Name = a.DIV_NAME
                    });
                    SelectedGrp.DataSource = d;
                    SelectedGrp.DataBind();
                    var div = _db.division_tab.OrderBy(x => x.DIV_NAME).Where(s => !seldiv.Contains(s.DIV_CODE)).Select(a => new
                    {
                        ID = a.DIV_CODE,
                        Name = a.DIV_NAME
                    }).ToList();

                    GroupContentList.DataSource = div;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.GRADE:


                    var selgr = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.GRADE && s.LoggedBy == user).Select(x => x.SelectedID);
                    var g = _db.grade_tab.Where(s => selgr.Contains(s.GRADE_CODE)).Select(a => new
                    {
                        ID = a.GRADE_CODE,
                        Name = a.GRADE_LEVEL
                    });
                    SelectedGrp.DataSource = g;
                    SelectedGrp.DataBind();
                    var gr = _db.grade_tab.OrderBy(x => x.GRADE_LEVEL).Where(s => !selgr.Contains(s.GRADE_CODE)).Select(a => new
                    {
                        ID = a.GRADE_CODE,
                        Name = a.GRADE_LEVEL
                    }).ToList();

                    GroupContentList.DataSource = gr;
                    GroupContentList.DataBind();

                    break;
                case ErecruitHelper.BGS.BANK:

                    var selreg = _db.BatchConfigurationTemps.AsEnumerable().Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.BANK && s.LoggedBy == user).Select(x => int.Parse(x.SelectedID));
                    var r = _db.region_tab.Where(s => selreg.Contains(s.region_code)).Select(a => new
                    {
                        ID = a.region_code,
                        Name = a.region_name
                    });
                    SelectedGrp.DataSource = r;
                    SelectedGrp.DataBind();
                    var reg = _db.region_tab.OrderBy(x => x.region_name).Where(s => !selreg.Contains(s.region_code)).Select(a => new
                    {
                        ID = a.region_code,
                        Name = a.region_name
                    }).ToList();

                    GroupContentList.DataSource = reg;
                    GroupContentList.DataBind();
                    break;
                case ErecruitHelper.BGS.DIRECTORATE:

                    var selsec = _db.BatchConfigurationTemps.Where(s => s.GroupSelected.Trim() == ErecruitHelper.BGS.DIRECTORATE && s.LoggedBy == user).Select(x => x.SelectedID);
                    var sec = _db.sector_tab.Where(s => selsec.Contains(s.SECTOR_CODE)).Select(a => new
                    {
                        ID = a.SECTOR_CODE,
                        Name = a.SECTOR_NAME
                    });
                    SelectedGrp.DataSource = sec;
                    SelectedGrp.DataBind();
                    var secs = _db.sector_tab.OrderBy(x => x.SECTOR_NAME).Where(s => !selsec.Contains(s.SECTOR_CODE)).Select(a => new
                    {
                        ID = a.SECTOR_CODE,
                        Name = a.SECTOR_NAME
                    }).ToList();

                    GroupContentList.DataSource = secs;
                    GroupContentList.DataBind();
                    break;
            }

        }
    }
}