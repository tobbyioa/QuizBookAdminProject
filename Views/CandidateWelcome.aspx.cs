using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class CandidateWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regBtn_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(tnCode.Text))
            {
                if (tnCode.Text.Length == 6)
                {
                    QuizBookDbEntities1 _db = new QuizBookDbEntities1();
                    var tn = _db.Tenants.FirstOrDefault(s => s.TenantCode == tnCode.Text);
                    if (tn != null)
                    {
                        SessionHelper.SetTenantID(tn.Id.ToString(), Session);
                        SessionHelper.SetTenantName(tn.TenantName, Session);
                        SessionHelper.SetTenantImage(tn.Image, Session);
                        Response.Redirect("CandidateReg.aspx", false);
                    }
                    else
                    {
                        lblAlert.Text = "There is no tenant registered as '" + tnCode.Text + "'. Kindly verify and re-enter tenant code above.";
                    }
                }
                else
                {
                    lblAlert.Text = "Tenant code should be 6 characters. You have "+tnCode.Text.Length+". Kindly verify.";
                }
            }
            else
            {
                lblAlert.Text = "Kindly fill in your tenant code above";
            }

        }
    }
}