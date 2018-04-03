using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;

namespace QuizBook.Model
{
    public partial class TestLanding : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            wlcmLbl.Text = string.Format("Welcome: {0}", SessionHelper.FetchFirstName(Page.Session) + " " + SessionHelper.FetchLastName(Page.Session));
        }
    }
}