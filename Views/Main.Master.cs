using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using QuizBook.Helpers;
using System.Net;
using System.Net.Sockets;
using System.Web.Services;
using System.Configuration;

namespace QuizBook.Views
{
    public partial class Main : System.Web.UI.MasterPage
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (SessionHelper.FetchSessionToken(Page.Session) == null)
            //{
            //    UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage();
            //}
            //else
            //{
            //    // Page.Request.UserHostAddress
            //    var ws = new FICAAS.FICAAS();
            //    var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            //    var ip = ErecruitHelper.GetIP(HttpContext.Current);
            //    if (!ws.UpdateLastActivityTime(SessionHelper.FetchSessionToken(Page.Session), ip, Page.Request.Url.AbsoluteUri, appcode))
            //    {
            //        var ss = SessionHelper.FetchSessionToken(Page.Session);
            //        if (!string.IsNullOrEmpty(ss))
            //        {
            //            Response.Redirect("SessionExpired.aspx",false);
            //        }else{
            //        UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage();
            //        }
            //    }
            //    else
            //    {
            //if ( Session == null || SessionHelper.FetchUserName(Session) == null)
            //{
                var username = SessionHelper.FetchUserName(Session);
                var user = _db.AdminUsers.AsEnumerable().FirstOrDefault(x => x.Username.Trim() == username.Trim());
                IsFresh.Value = user.DefaultLoginKeyChanged.HasValue ? user.DefaultLoginKeyChanged.ToString() : "0";
                ShowPermissibleMenu(user);
                wlcmLbl.Text = string.Format("Welcome: {0}", SessionHelper.FetchFirstName(Page.Session));
            //}
            //else
            //{
            //    var login = ConfigurationManager.AppSettings["AdminLogin"] == null? "Login.aspx" : ConfigurationManager.AppSettings["AdminLogin"].ToString();
            //    Response.Redirect(login, false);
            //}
            //    }
            //}
        }

        private void UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage()
        {
            var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            Response.Redirect(ficaaslogin);
            Session.Abandon();
            Session.Clear();
        }

        private void ShowPermissibleMenu(AdminUser user)
        {
            var PermMgr = new PermissionManager(Session);

            if ( PermMgr.CanWorkWithCandidates||PermMgr.CanApprove)
            {
               //CandidateSearchmenu.Visible = true;
            }
            else
            {
                //CandidateSearchmenu.Visible = false;
            }
            if ( PermMgr.CanWorkWithCandidates || PermMgr.CanApprove)
            {
                Candidatemenu.Visible = true;
            }
            else
            {
                Candidatemenu.Visible = false;
            }
            if (user.Role==1 || user.Supervisor.HasValue?user.Supervisor.Value:false)
            {
                adminLnk.Visible = true;
                admins.Visible = true;
                AddAdmins.Visible = true;
                AddRoles.Visible = true;
            }
            else
            {
                adminLnk.Visible = false;
                admins.Visible = false;
                AddAdmins.Visible = false;
                AddRoles.Visible = false;
            }

            if ( PermMgr.CanManageQuestion)
            {
                QuestionsListsmenu.Visible = true;
            }
            else
            {
                QuestionsListsmenu.Visible = false;
            }
            //if ( PermMgr.CanManageQuestion)
            //{
            //    QuestionImagemenu.Visible = true;
            //}
            //else
            //{
            //    QuestionImagemenu.Visible = false;
            //}
            if ( PermMgr.CanManageQuestion)
            {
                UploadQuestions.Visible = true;
            }
            else
            {
                UploadQuestions.Visible = false;
            }
            //if ( PermMgr.CanManageQuestion)
            //{
            //    EssayQuestionsmenu.Visible = true;
            //}
            //else
            //{
            //    EssayQuestionsmenu.Visible = false;
            //}
            if ( PermMgr.CanManageTestBatches)
            {
                Batchesmenu.Visible = true;
            }
            else
            {
                Batchesmenu.Visible = false;
            }
            if ( PermMgr.CanManageTestBatches)
            {
               // AddCandidateToBatchmenu.Visible = true;
            }
            else
            {
               // AddCandidateToBatchmenu.Visible = false;
            }
            if ( PermMgr.CanManageTestResults)
            {
                Individual.Visible = true;
            }
            else
            {
                Individual.Visible = false;
            }
            //if ( PermMgr.CanManageTestResults)
            //{
            //    PsychTestResultsmenu.Visible = true;
            //}
            //else
            //{
            //    PsychTestResultsmenu.Visible = false;
            //}
            //if (PermMgr.CanManageTestResults)
            //{
            //    BackgroundQuestResultsmenu.Visible = true;
            //}
            //else
            //{
            //    BackgroundQuestResultsmenu.Visible = false;
            //}
            if (PermMgr.CanManageTestResults)
            {
                BatchRep.Visible = true;
            }
            else
            {
                BatchRep.Visible = false;
            }
            if ( PermMgr.CanManageTestBatches)
            {
                ActivateCandidateSessionmenu.Visible = true;
            }
            else
            {
                ActivateCandidateSessionmenu.Visible = false;
            }
            if ( PermMgr.CanManagePortal)
            {
                notImp.Visible = true;
            }
            else
            {
                notImp.Visible = false;
            }

            if ( PermMgr.CanManagePortal)
            {
                Settingsmenu.Visible = false;
            }
            else
            {
                Settingsmenu.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/UserManual.doc", false);
        }


    }
}