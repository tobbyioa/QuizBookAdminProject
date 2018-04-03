using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Views
{
    public partial class CandidateRegistration : System.Web.UI.MasterPage
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionHelper.FetchSessionToken(Page.Session) == null)
            {
                UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage();
            }
            else
            {
                // Page.Request.UserHostAddress
                var ws = new FICAAS.FICAAS();
                var appcode = WebConfigurationManager.AppSettings["AppCode_T"].ToString();
                var ip = ErecruitHelper.GetIP(HttpContext.Current);
                if (!ws.UpdateLastActivityTime(SessionHelper.FetchSessionToken(Page.Session), ip, Page.Request.Url.AbsoluteUri, appcode))
                {
                    var ss = SessionHelper.FetchSessionToken(Page.Session);
                    if (!string.IsNullOrEmpty(ss))
                    {
                        Response.Redirect("SessionExpired.aspx", false);
                    }
                    else
                    {
                        UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage();
                    }
                }
                else
                {
                    //ShowPermissibleMenu();
                    wlcmLbl.Text = string.Format("Welcome: {0}", SessionHelper.FetchFirstName(Page.Session) + " " + SessionHelper.FetchLastName(Page.Session));
                }
            }
        }

        private void UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage()
        {
            var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            Response.Redirect(ficaaslogin);
            Session.Abandon();
            Session.Clear();
        }
    }
}