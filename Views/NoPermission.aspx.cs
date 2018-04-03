using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Configuration;

namespace QuizBook.Views
{
    public partial class NoPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var ws = new FICAAS.FICAAS();
            ws.LogoutUser(SessionHelper.FetchSessionToken(Session), Request.UserHostAddress);
            SessionHelper.NullSessionToken(Session);
            SessionHelper.NullEmail(Session);
            SessionHelper.FetchUserId(Session);
            var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            Response.Redirect(ficaaslogin);
        }
    }
}