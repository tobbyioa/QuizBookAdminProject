using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Model;
using QuizBook.Helpers;
using System.IO;
using System.Web.Configuration;

namespace QuizBook.Views
{
    public partial class AddCandidateToBatch : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;

            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManageTestBatches)
            {


            if (!IsPostBack)
            {



                //Bind Active Batch DropDownList
                var activeBatches = _db.T_Batch.Where(s =>(s.BatchType == ErecruitHelper.BatchType.Multiple.ToString()|| s.BatchType==null) && s.IsActive.Value == true).ToList();
                Batches.DataSource = activeBatches;
                if(Session["ToBeSelected"] !=null){
                    Batches.SelectedIndex = int.Parse(Session["ToBeSelected"].ToString());
                }
                Batches.DataBind();
               
 //Bind Active Candidate ListBox
            var cands = _db.T_Candidate.Where(s => s.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString() && s.IsActive.Value == true).Select(a => new CandidateDropDownModel
            {
                ID = a.Id,
                Name = a.Code + " - " + a.LastName + " " + a.FirstName
            }).ToList();
            ActiveCandidateList.DataSource = cands;
            ActiveCandidateList.DataBind();

                //Bind Active Batch Content ListBox

            var x = string.IsNullOrEmpty(Batches.SelectedValue) ? "0" : Batches.SelectedValue;
                var selectedBatch = long.Parse(x);
                var batch = new T_Batch();
                if (selectedBatch == 0)
                {
                    batch = new T_Batch
                    {
                        Id=0,
                        Name="No Active batch."
                    };
                }
                else
                {
                    batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);
                }
               
                List<BatchContentDropDownModel> activeContent = _db.T_BatchSet.Where(s => s.BatchId == selectedBatch).Select(a => new BatchContentDropDownModel
                {
                    ID = a.CandidateId.Value,
                    Name =_db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).Code +" - "+_db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).FirstName+" "+_db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).LastName
                }).ToList();

                if (activeContent.Count > 0)
                {
                    ActiveContentList.DataSource = activeContent;
                    ActiveContentList.DataBind();
                    SendInvite.Enabled = true;
                }
                else
                {
                    activeContent = new List<BatchContentDropDownModel>();
                    activeContent.Add(new BatchContentDropDownModel
                    {
                        ID = 0,
                        Name = "---"+batch.Name+" is Empty---"
                    });
                    ActiveContentList.DataSource = activeContent;
                    ActiveContentList.DataBind();
                    SendInvite.Enabled = false;
                }

                //Bind DropDownList1 ListBox
                var cs = _db.T_Candidate.Where(s => s.ApprovalStatus == ErecruitHelper.ApprovalStatus.APPROVED.ToString() && s.IsActive.Value == true).Select(a => new CandidateDropDownModel
                {
                    ID = a.Id,
                    Name = a.Code + " - " + a.LastName + " " + a.FirstName
                }).ToList();
                DropDownList1.DataSource = cs;
                DropDownList1.DataBind();


  


            }

            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }

        }

        protected void Batches_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bind Active Batch Content ListBox
            var selectedBatch = long.Parse(Batches.SelectedValue);
            var selectedIndex = Batches.SelectedIndex;
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);
            List<BatchContentDropDownModel> activeContent = _db.T_BatchSet.Where(s => s.BatchId == selectedBatch).Select(a => new BatchContentDropDownModel
            {
                ID = a.CandidateId.Value,
                Name = _db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).Code + " - " + _db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).FirstName + " " + _db.T_Candidate.FirstOrDefault(s => s.Id == a.CandidateId).LastName
            }).ToList();
            if (activeContent.Count > 0)
            {
                ActiveContentList.DataSource = activeContent;
                ActiveContentList.DataBind();
                SendInvite.Enabled = true;
            }
            else
            {
                activeContent = new List<BatchContentDropDownModel>();
                activeContent.Add(new BatchContentDropDownModel
                {
                    ID = 0,
                    Name = "---" + batch.Name + " is Empty---"
                });
                ActiveContentList.DataSource = activeContent;
                ActiveContentList.DataBind();
                SendInvite.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = Batches.SelectedValue;
                if (string.IsNullOrEmpty(sb)) return;
                var selectedBatch = long.Parse(Batches.SelectedValue);
                var selectedIndex = Batches.SelectedIndex;
                var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);

                int[] selectedCandidates = ActiveCandidateList.GetSelectedIndices();
                var contentIds = new List<int>();
                var cids = selectedCandidates.Select(i => int.Parse(ActiveCandidateList.Items[i].Value)).ToList();

                foreach (int x in cids)
                {
                    if (x == 0)
                    {
                    }
                    else
                    {
                        contentIds.Add(x);
                    }
                }
                foreach (int x in contentIds)
                {
                    var x1 = x;
                    var hasActive = false;
                    var prevBatchSet = _db.T_BatchSet.Where(s => s.CandidateId == x1).Select(s =>s.BatchId);
                   List<T_Batch> prevBatch = null;
                    if (prevBatchSet.Any())
                    {
                        prevBatch = _db.T_Batch.Where(s => prevBatchSet.Contains(s.Id)).ToList();

                    }
                    if (prevBatch != null && prevBatch.Count>0)
                    {
                        foreach (var batch1 in prevBatch)
                        {
                            if (batch1.IsActive == true)
                            {
                                hasActive = true;
                            }
                        }
                    }
                    if (hasActive)
                    {
                        //Session["Status"] = "";
                    }
                    else
                    {



                        var existing =_db.T_BatchSet.FirstOrDefault(s => s.BatchId == batch.Id && s.CandidateId == x);

                        if (existing == null)
                        {
                            if (batch != null)
                                _db.T_BatchSet.Add(new T_BatchSet
                                                                   {
                                                                       CandidateId = x,
                                                                       BatchId = batch.Id,
                                                                       Finished = false,
                                                                       IsLive = false

                                                                   });
                        }

                    }
                }

                _db.SaveChanges();
                Session["ToBeSelected"] = selectedIndex;

                Response.Redirect("AddCandidateToBatch.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try{
            var selectedBatch = long.Parse(Batches.SelectedValue);
            var selectedIndex = Batches.SelectedIndex;
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);

            int[] selectedCandidates = ActiveContentList.GetSelectedIndices();
            var contentIds = new List<int>();
            var cids = selectedCandidates.Select(i => int.Parse(ActiveContentList.Items[i].Value)).ToList();
            // int count = cids.Count;
            foreach (int x in cids)
            {
                if (x == 0){}
                else{contentIds.Add(x); }
            }

            foreach (int x in contentIds)
            {
                var entry = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == batch.Id && s.CandidateId == x);
                if (entry != null) _db.T_BatchSet.Remove(entry);
            }
            _db.SaveChanges();
            Session["ToBeSelected"] = selectedIndex;
          
            Response.Redirect("AddCandidateToBatch.aspx",false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try{
            var selectedBatch = long.Parse(Batches.SelectedValue);
            var selectedIndex = Batches.SelectedIndex;
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);

            ListItemCollection allActiveCandidates = ActiveCandidateList.Items;
            var contentIds = new List<int>();
            var cids = (from ListItem i in allActiveCandidates select int.Parse(i.Value)).ToList();

            foreach (int x in cids)
            {
                if (x == 0) { }
                else { contentIds.Add(x); }
            }
            foreach (int x in contentIds)
            {
                var x1 = x;
                var hasActive = false;
                var prevBatchSet = _db.T_BatchSet.Where(s => s.CandidateId == x1).Select(s => s.BatchId);
                List<T_Batch> prevBatch = null;
                if (prevBatchSet.Any())
                {
                    prevBatch = _db.T_Batch.Where(s => prevBatchSet.Contains(s.Id)).ToList();

                }
                if (prevBatch != null && prevBatch.Count > 0)
                {
                    foreach (var batch1 in prevBatch)
                    {
                        if (batch1.IsActive == true)
                        {
                            hasActive = true;
                        }
                    }
                }
                if (hasActive)
                {
                    //Session["Status"] = "";
                }
                else
                {


                    var existing = _db.T_BatchSet.FirstOrDefault(s => s.BatchId == batch.Id && s.CandidateId == x);
                    if (existing == null)
                    {
                        if (batch != null)
                            _db.T_BatchSet.Add(new T_BatchSet
                                                               {
                                                                   CandidateId = x,
                                                                   BatchId = batch.Id,
                                                                   Finished = false,
                                                                   IsLive = false

                                                               });
                    }
                }
            }

            _db.SaveChanges();
            Session["ToBeSelected"] = selectedIndex;

            Response.Redirect("AddCandidateToBatch.aspx",false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {

           
            var selectedBatch = long.Parse(Batches.SelectedValue);
            var selectedIndex = Batches.SelectedIndex;
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);

            ListItemCollection allCurrentContent = ActiveContentList.Items;

            var contentIds = new List<int>();
            var cids = (from ListItem i in allCurrentContent select int.Parse(i.Value)).ToList();
            // int count = cids.Count;
            foreach (int x in cids)
            {
                if (x == 0) { }
                else { contentIds.Add(x); }
            }

            foreach (int x in contentIds)
            {
                //s => s.BatchId == batch.Id && s.CandidateId == x
                var entry = _db.T_BatchSet.Where(m => m.BatchId == batch.Id && m.CandidateId == x).FirstOrDefault();
                if (entry != null) _db.T_BatchSet.Remove(entry);
            }
            _db.SaveChanges();
            Session["ToBeSelected"] = selectedIndex;
            Response.Redirect("AddCandidateToBatch.aspx",false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCandidate = long.Parse(DropDownList1.SelectedValue);
                var selectedIndex = DropDownList1.SelectedIndex;

                var Stdate = B_StartDate.Text;
                var duration = Duration.Text;
                // var actv = Active.Checked;

                var cand = _db.T_Candidate.FirstOrDefault(s => s.Id == selectedCandidate);


                var batch = new T_Batch
                {
                    Name = cand.Code + " - " + cand.LastName + " " + cand.FirstName,
                    Description = cand.Code + " - " + cand.LastName + " " + cand.FirstName,
                    StartDate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(Stdate),
                    Duration = int.Parse(duration),
                    IsActive = false,
                    BatchType = ErecruitHelper.BatchType.Single.ToString(),
                    SessionOn = false,
                    AddedBy = SessionHelper.FetchEmail(Session),
                    DateAdded = DateTime.Now
                };

                _db.T_Batch.Add(batch);
                _db.SaveChanges();

                _db.T_BatchSet.Add(new T_BatchSet
                {
                    CandidateId = selectedCandidate,
                    BatchId = batch.Id,
                    Finished =false,
                    IsLive = false

                });
                _db.SaveChanges();
                var ip = Page.Request.UserHostAddress;
                ErecruitHelper.sendTestInviteMail(cand, batch, Page.Session, ip);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try{
            var selectedBatch = long.Parse(Batches.SelectedValue);
            var selectedIndex = Batches.SelectedIndex;
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == selectedBatch);

            //int[] selectedCandidates = ActiveContentList.GetSelectedIndices();//ActiveContentList.Items.Cast<String>().ToList();//
           // var contentIds = new List<int>();
            ListItemCollection items = ActiveContentList.Items;
            var conts = new List<int>();
                foreach(ListItem i in items){
                    conts.Add(int.Parse(i.Value));
                }
            //var cids = selectedCandidates.Select(i => int.Parse(ActiveContentList.Items[i].Value)).ToList();
          //  int count = cids.Count;
            //foreach (int x in cids)
            //{
            //    if (x == 0){}
            //    else{contentIds.Add(x);}
            //}
                foreach (int x in conts)
            {
                var c = _db.T_Candidate.FirstOrDefault(s => s.Id == x);
                var ip = Page.Request.UserHostAddress;
                ErecruitHelper.sendTestInviteMail(c, batch, Page.Session, ip);
                msglabel.Text = "Invite(s) Sent";
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