using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class OuterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        public string TenantName
        {
            get
            {
                return tenantName.Text;
            }
            set
            {
                tenantName.Text = value;
            }
        }
        public string TenantImage
        {
            get
            {
                return tenantImg.ImageUrl;
            }
            set
            {
                tenantImg.ImageUrl = value;
            }
        }
    }
}