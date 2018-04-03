using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Services;

namespace QuizBook.Views
{
    public partial class TestLanding : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                wlcmLbl.Text = string.Format("{0}", SessionHelper.FetchFirstName(Page.Session) + " " + SessionHelper.FetchLastName(Page.Session));


                //var username = SessionHelper.FetchUserName(Session);
                //var user = _db.AdminUsers.AsEnumerable().FirstOrDefault(x => x.Username.Trim() == username.Trim());
                


                var permissions = ErecruitHelper.GetUserPermissions(Page.Session);
                    var sid = SessionHelper.FetchUserId(Page.Session);
                    var user = _db.Candidates.FirstOrDefault(s => s.Id == sid);

                    var username = SessionHelper.FetchUserName(Session);
                    var userx = _db.Candidates.AsEnumerable().FirstOrDefault(x => x.Username.Trim() == username.Trim());
                    IsFresh.Value = userx.DefaultLoginKeyChanged.HasValue ? user.DefaultLoginKeyChanged.ToString() : "0";

                    if (user.Status.Trim() == ErecruitHelper.CStatus.Active.ToString())
                    {
                        if (permissions._CanDoTest)
                        {


                            LoadTestsForCandidate(user);

                            //  testPanel.Visible = true;
                            messagePanel.Visible = false;
                            messageLbl.Text = "";
                        }
                    }
                    else
                    {
                        GridView1.Visible = false;
                        messagePanel.Visible = true;
                        messageLbl.Text = "Your profile is either not active or not approved. Kindly contact Performance Management.";
                    }

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }
        private void LoadTestsForCandidate(QuizBook.Candidate user)
        {
            var abid = _db.T_Batch.Where(s => s.IsActive == true).Select(s => s.Id);
            //var abid = ab..ToList();
            var scopes = _db.BatchScopeContents.Where(s => abid.Contains(s.BatchId.Value)).ToList();
            var myScopes = new List<BatchScopeContent>();
            myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.ALL && long.Parse(s.ScopeContentId.Trim()) == user.Id));
            //myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.BRANCH && s.ScopeContentId.Trim() == user.branch_tab.sol_id.Trim()));
            //myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.DIVISION && s.ScopeContentId.Trim() == user.Division.Trim()));
            //myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.GRADE && s.ScopeContentId.Trim() == user.Grade.Trim()));
            //myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.DIRECTORATE && s.ScopeContentId.Trim() == user.Sector.Trim()));
            //myScopes.AddRange(scopes.Where(s => s.BatchScope == ErecruitHelper.BGS.BANK && int.Parse(s.ScopeContentId) == user.Region.Value));
            
            var quests = myScopes.Where(x =>x.T_Batch.EndDate!= null && !(x.T_Batch.EndDate.Value < DateTime.Now)).OrderByDescending(s=>s.BatchId).Select(a => new
            {
                ID = a.BatchId,
                Test = a.T_Batch.Name,
                Duration = a.T_Batch.Duration,
                Rem = a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username) == null ? a.T_Batch.Duration.Value.ToString():
                      a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).InSession.Value ?
                      a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).RemainingDuration :
                      a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).Finished.Value ? "00:00:00" : a.T_Batch.Duration.Value.ToString(),
                Status = a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username) == null ? "Not Attempted" :
                         a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).InSession.Value ? "Attempted" :
                         a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).Finished.Value ? "Finished" : "Not Attempted",
                BStatus = a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username) == null ? true :
                          a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).InSession.Value ? true :
                          a.T_Batch.T_CTestTracker.FirstOrDefault(s => s.CandidateCode.Trim() == user.Username).Finished.Value ? false : true,              
                Time = a.T_Batch.StartDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt"),
                ETime = a.T_Batch.EndDate.Value.ToString("dd/MM/yyyy hh:mm:ss tt")


            }).Distinct().ToList();

            GridView1.DataSource = quests;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("Registration.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
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
                var batch = _db.T_Batch.FirstOrDefault(s => s.Id == idcr);
                var sid = SessionHelper.FetchUserName(Page.Session);
                var user = _db.Candidates.FirstOrDefault(s => s.Username.Trim() == sid.Trim());
                if (batch.IsActive.Value)
                {

                    Session["SelectedBatch"] = idcr;
                    if (batch.StartDate <= DateTime.Now)
                    {
                        var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == batch.Id);
                       
                        if (tracker != null)
                        {
                            SessionHelper.SetCandidateId(user.Id.ToString(CultureInfo.InvariantCulture), Session);
                            Response.Redirect("_CandidateTestPage.aspx", false);
                        }
                        else
                        {
                            var st = DateTime.Now;
                            var duration = batch.Duration.ToString();

                            _db.T_CTestTracker.Add(new T_CTestTracker
                            {
                                CandidateId = user.Id,
                                BatchId = batch.Id,
                                CandidateCode = user.Username,
                                InSession = true,
                                Finished = false,
                                // InitialStartTime = st,
                                // CurrentStartTime = st,
                                TestDuration = ErecruitHelper.AppendZero(0) + ":" + ErecruitHelper.AppendZero(int.Parse(duration)) + ":" + ErecruitHelper.AppendZero(0),
                                RemainingDuration = duration
                                //EndTime = endtime
                            });
                            batch.SessionOn = true;
                            _db.SaveChanges();

                            tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == user.Id && s.BatchId == batch.Id);
                            var remaining = tracker.RemainingDuration;
                            var d = tracker.TestDuration;
                            if (d != "0:0:0" && remaining != "0:0:0")
                            {
                                SessionHelper.SetCandidateId(user.Id.ToString(CultureInfo.InvariantCulture), Session);
                                Response.Redirect("_CandidateTestPage.aspx", false);
                            }

                        }

                     //   Response.Redirect("_CandidateTestPage.aspx", false);
                    }
                    else
                    {
                        messageLbl.Visible = true;
                        messagePanel.Visible = true;
                        messageLbl.Text = "It is not yet time to take this Test :'"+batch.Name+"'\n Please contact the Administrator.";
                    }


                }
                else
                {


                    LoadTestsForCandidate(user);
                    var info = "This test is no longer active.";
                    messageLbl.Visible = true;
                    messagePanel.Visible = true;
                    messageLbl.Text = info;
                    
                }
            }
        }
        [WebMethod(EnableSession = true)]
        public static string PassCheck(string op, string xx)
        {
            string keySalt = "QuizBook";


            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var usName = SessionHelper.FetchUserName(HttpContext.Current.Session);
                var psWord = op;

                string key = "";
                if (xx == "index")
                {
                    var qg = _db.AdminUsers.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    key = qg == null ? "" : qg.LogInKey;
                }
                else
                {
                    var qg = _db.Candidates.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    key = qg == null ? "" : qg.LogInKey;
                }


                if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                {
                    byte[] pw = ErecruitHelper.getByte(psWord, keySalt);
                    byte[] pwFromDB = Convert.FromBase64String(key);
                    if (ErecruitHelper.CompareByteArrays(pw, pwFromDB))
                    {
                        return "success";
                    }
                    else
                    {
                        return "failed";
                    }
                }
                else
                {
                    return "failed";
                }



            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string ChangePass(string op, string xx)
        {
            string keySalt = "QuizBook";


            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var usName = SessionHelper.FetchUserName(HttpContext.Current.Session);
                var psWord = op;

                string key = "";
                if (xx == "index")
                {
                    var qg = _db.AdminUsers.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    if (qg == null)
                    {
                        return "failed";
                    }
                    else
                    {
                        qg.LogInKey = ErecruitHelper.getHash(psWord.Trim(), keySalt.Trim());
                        qg.DefaultLoginKeyChanged = true;
                        qg.DateModified = DateTime.Now;
                        _db.SaveChanges();
                        return "success";
                    }
                }
                else
                {
                    var qg = _db.Candidates.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    if (qg == null)
                    {
                        return "failed";
                    }
                    else
                    {
                        qg.LogInKey = ErecruitHelper.getHash(psWord.Trim(), keySalt.Trim());
                        qg.ModifiedBy = qg.Username;
                        qg.DefaultLoginKeyChanged = true;
                        qg.DateModified = DateTime.Now;
                        _db.SaveChanges();
                        return "success";
                    }
                }


                //if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                //{
                //    byte[] pw = ErecruitHelper.getByte(psWord, keySalt);
                //    byte[] pwFromDB = Convert.FromBase64String(key);

                //if (ErecruitHelper.CompareByteArrays(pw, pwFromDB))
                //{
                //    return "success";
                //}
                //else
                //{
                //    return "failed";
                //}
                //}
                //else
                //{
                //    return "failed";
                //}



            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}