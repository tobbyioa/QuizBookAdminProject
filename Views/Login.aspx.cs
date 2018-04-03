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

    public partial class Login : System.Web.UI.Page
    {
        OuterPage master = null;
        string keySalt = "QuizBook";
        protected void Page_Init(object sender, EventArgs e)
        {
            master = this.Master as OuterPage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            if (SessionHelper.GetTenantName(Session) == null || SessionHelper.GetTenantImage(Session) == null)
            {
                Response.Redirect("Welcome.aspx", false);
            }
            else
            {

                master.TenantName = SessionHelper.GetTenantName(Session);
                master.TenantImage = SessionHelper.GetTenantImage(Session);
            }
            //}
        }

        protected void lnk1_Click(object sender, EventArgs e)
        {
            SessionHelper.NullifyTenantID(Session);
            SessionHelper.NullifyTenantName(Session);
            SessionHelper.NullifyTenantImage(Session);

            Response.Redirect("Welcome.aspx", false);
        }



        protected void loginBtn_Click(object sender, EventArgs e)
        {
            var usName = username.Text;
            var psWord = password.Text;
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var user = _db.AdminUsers.FirstOrDefault(s => s.Username == usName);
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
                                    SessionHelper.SetTenantName(user.Tenant.TenantName.ToString(), Session);
                                }
                                SessionHelper.SetLocation(user.Location, Session);
                                SessionHelper.SetFirstName(user.FirstName, Session);
                                SessionHelper.SetLastName(user.LastName, Session);
                                var permissions = ErecruitHelper.GetAdminPermissions(_db, user);
                                SessionHelper.SetUserPermissions(permissions, System.Web.HttpContext.Current.Session);
                                //var adminObj = _db.Roles.FirstOrDefault(s => s.Description == "Admin");
                                var adminObj = _db.Roles.Select(s =>s.Id).ToArray();
                                MB.FileBrowser.MagicSession.Current.FileBrowserAccessMode = IZ.WebFileManager.AccessMode.Write;
                                if (user.Role.HasValue && adminObj.Contains(user.Role.Value))
                                {
                                    Response.Redirect("index.aspx", false);
                                }
                                else
                                {
                                    Response.Redirect("TestLanding.aspx");
                                }
                            }
                            else
                            {
                                lblAlert.Text = string.Format("Your status is {0}. Kindly contact the Administartor", user.Status);
                            }
                        }
                    }
                }
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

                var qg = _db.Candidates.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == name.Trim() || s.Email.Trim() == name.Trim());
                //var qg = _db.T_QuestionType.FirstOrDefault(s => s.Id == long.Parse(id));
                if (qg != null)
                {

                    qg.LogInKey = ErecruitHelper.getHash(phrase.Trim(), keySalt.Trim());
                    qg.ModifiedBy = qg.Username;
                    qg.DateModified = DateTime.Now;
                    qg.DefaultLoginKeyChanged = false;
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