using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class CandLogin : System.Web.UI.Page
    {
        string keySalt = "QuizBook";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var usName = username.Text;
            var psWord = password.Text;
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            var user = _db.Candidates.FirstOrDefault(s => s.Username == usName);
            if (user != null)
            {
                string key = user.LogInKey;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                {
                    byte[] pw = ErecruitHelper.getByte(psWord, keySalt);
                    byte[] pwFromDB = Convert.FromBase64String(key);
                    if (ErecruitHelper.CompareByteArrays(pw, pwFromDB))
                    {
                        if (user.Status.Trim() == ErecruitHelper.CStatus.Active.ToString())
                        {
                            SessionHelper.SetEmail(user.Email, Session);
                            SessionHelper.SetUserId((int)user.Id, Session);
                            SessionHelper.SetUserName(user.Username, Session);
                            if (user.TenantId == null)
                            {
                                SessionHelper.NullifyTenantID(Session);
                            }
                            else
                            {
                                SessionHelper.SetTenantID(user.TenantId.Value.ToString(), Session);
                            }
                            SessionHelper.SetLocation(user.Location, Session);
                            SessionHelper.SetFirstName(user.FirstName, Session);
                            SessionHelper.SetLastName(user.LastName, Session);
                            var permissions = ErecruitHelper.GetuserPermissions(_db, user);
                            SessionHelper.SetUserPermissions(permissions, System.Web.HttpContext.Current.Session);
                            Response.Redirect("TestLanding.aspx");
                        }
                        else
                        {
                            lblAlert.Text = string.Format("Your status is {0}. Kindly contact the Administartor", user.Status);
                        }
                    }
                    else
                    {
                        lblAlert.Text = string.Format("Your password seems incorrect. Kindly check.");
                    }
                }

                else
                {
                    lblAlert.Text = string.Format("No password set.");
                }
            }
            else
            {

                lblAlert.Text = string.Format("Cannot find user in the System.");

            }
        }


        [WebMethod(EnableSession = true)]
        public static string ResetMth(string name)
        {
            string keySalt = "QuizBook";
           

            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var pw = Guid.NewGuid().ToString();
                var phrase = pw.Split('-')[0];

                var qg = _db.Candidates .AsEnumerable().FirstOrDefault(s => s.Username.Trim() == name.Trim() || s.Email.Trim() == name.Trim());
                //var qg = _db.T_QuestionType.FirstOrDefault(s => s.Id == long.Parse(id));
                if (qg != null)
                {

                    qg.LogInKey = ErecruitHelper.getHash(phrase.Trim(), keySalt.Trim());
                    qg.ModifiedBy = qg.Username;
                    qg.DefaultLoginKeyChanged = false;
                    qg.DateModified = DateTime.Now;
                    _db.SaveChanges();
                    ErecruitHelper.sendPwReser(qg, " ", phrase);
                    return "success";
                }
                else
                {
                    return "notexist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}