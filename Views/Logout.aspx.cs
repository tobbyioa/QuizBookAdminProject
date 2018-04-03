using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Configuration;
using System.Configuration;

namespace QuizBook.Views
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var permissions = ErecruitHelper.GetAllPermissions(Page.Session);
            var al = ConfigurationManager.AppSettings["AdminLogin"].ToString();
            var cl = ConfigurationManager.AppSettings["CandidateLogin"].ToString();
            if (permissions._CanDoTest && permissions._CanViewOwnTestResult)
            {
                Session.Abandon();
                Response.Redirect(cl);
            }
            else
            {
                Session.Abandon();
                Response.Redirect(al);
            }
            //var ws = new FICAAS.FICAAS();
            //ws.LogoutUser(SessionHelper.FetchSessionToken(Session), Request.UserHostAddress);
            //SessionHelper.NullSessionToken(Session);
            //SessionHelper.NullEmail(Session);
            //SessionHelper.FetchUserId(Session);
            //var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            //Response.Redirect(ficaaslogin);
        }
    }
}