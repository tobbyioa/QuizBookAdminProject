using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sv = SessionHelper.GetInfoValue(Session);
            if (sv != null)
            {
                HtmlGenericControl infoControl = new HtmlGenericControl("span");
                infoControl.InnerHtml = sv.ToString();
                messagePanel.Controls.Add(infoControl);
                SessionHelper.NullifyInfoValue(Session);
            }
            else
            {
                Response.Redirect("Welcome.aspx", false);
            }
        }
    }
}