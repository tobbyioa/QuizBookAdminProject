using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class Report : System.Web.UI.MasterPage
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            var username = SessionHelper.FetchUserName(Session);
            var user = _db.AdminUsers.AsEnumerable().FirstOrDefault(x => x.Username.Trim() == username.Trim());
            IsFresh.Value = user.DefaultLoginKeyChanged.HasValue ? user.DefaultLoginKeyChanged.ToString() : "0";
            //ShowPermissibleMenu();
            wlcmLbl.Text = string.Format("Welcome: {0}", SessionHelper.FetchFirstName(Page.Session));

        }

        private void UserNotLoggedInSoAbandonSessionAndRedirectToLoginPage()
        {
            var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            Response.Redirect(ficaaslogin);
            Session.Abandon();
            Session.Clear();
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/UserManual.doc", false);
        }
    }
}