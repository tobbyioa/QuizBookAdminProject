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
    public partial class ExceptionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var exm = SessionHelper.GetExMessage(Session);
            var exs = SessionHelper.GetExStacktrace(Session);
            if (exm != null && exs != null)
            {
                HtmlGenericControl infoControl = new HtmlGenericControl("span");
                HtmlGenericControl infoControl2 = new HtmlGenericControl("span");
                infoControl.InnerHtml = exm.ToString();
                messagePanel.Controls.Add(infoControl);
                infoControl2.InnerHtml = exm.ToString();
                Stacktrace.Controls.Add(infoControl2);
                SessionHelper.NullifyExMessage(Session);
                SessionHelper.NullifyExStacktrace(Session);
            }
            else
            {

            }
        }
    }
}