using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.Web.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Web.Services;

namespace QuizBook.Views
{
    public partial class index : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Init(object sender, EventArgs e)
        {
            //var ficassws = new FICAAS.FICAAS();
            //string authtoken = "";
            //string appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            //if (Request.QueryString["token"] != null || SessionHelper.FetchSessionToken(Page.Session) == null)
            //{             
            //    authtoken = Request.QueryString["token"].ToString();
            //    var ip = ErecruitHelper.GetIP(HttpContext.Current);
            //    var sessionToken = ficassws.FetchAppSessionToken(authtoken, ip, appcode);
            //    if (sessionToken != "")
            //    {
            //        SessionHelper.SetSessionToken(sessionToken, Session);
            //        var Userdata = ficassws.FetchUserData(sessionToken, ip);
            //        if (Userdata != null)
            //        {
                        //SessionHelper.SetEmail(Userdata.Email, Session);
                        //SessionHelper.SetUserId(Userdata.UserId, Session);
                        //SessionHelper.SetUserName(Userdata.Username, Session);
                        //SessionHelper.SetSol(Userdata.Sol, Session);
                        //SessionHelper.SetFirstName(Userdata.FirstName, Session);
                        //SetUserRoleAndPermissions();
                        
                        //CheckIfUserHasProfile(db);
            //        }
            //    }
            //    else if (SessionHelper.FetchSessionToken(Page.Session) == null)
            //    {
            //        var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            //        Response.Redirect(ficaaslogin);
            //    }
            //}
            //else if (SessionHelper.FetchSessionToken(Page.Session) != null)
            //{
            //    return;
            //}
            //else
            //{
            //    var ficaaslogin = WebConfigurationManager.AppSettings["FicassLoginUrl"].ToString();
            //    Response.Redirect(ficaaslogin);
            //}
        }
        private void SetUserRoleAndPermissions()
        {
            //var ws = new FICAAS.FICAAS();
            //var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            //var ip = ErecruitHelper.GetIP(HttpContext.Current);
            //var roles = ws.FetchUserRoles(SessionHelper.FetchSessionToken(Session), appcode, ip);
            //var permissions = ws.FetchUserPermissions(SessionHelper.FetchSessionToken(Session), appcode, ip);
            //SessionHelper.SetUserRoles(roles, Session);
            //SessionHelper.SetUserPermissions(permissions, Session);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod(EnableSession = true)]
        public static string PassCheck(string op,string xx)
        {
            string keySalt = "QuizBook";


            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var usName = SessionHelper.FetchUserName(HttpContext.Current.Session);
                var psWord = op;
               
                string key = "";
                if (xx == "index")
                {
                   var  qg = _db.AdminUsers.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    key = qg==null?"":qg.LogInKey;
                }
                else
                {
                   var  qg = _db.Candidates.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                   key = qg == null ? "" : qg.LogInKey;
                }
            
                   
                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                    {
                        byte[] pw = ErecruitHelper.getByte(psWord, keySalt);
                        byte[] pwFromDB = Convert.FromBase64String(key);
                        if (ErecruitHelper.CompareByteArrays(pw, pwFromDB))
                        {
                            return "success";
                        }
                        else
                        {
                            return "failed";
                        }
                    }
                    else
                    {
                        return "failed";
                    }


               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string ChangePass(string op, string xx)
        {
            string keySalt = "QuizBook";


            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var usName = SessionHelper.FetchUserName(HttpContext.Current.Session);
                var psWord = op;

                string key = "";
                if (xx == "index")
                {
                    var qg = _db.AdminUsers.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    if (qg == null)
                    {
                        return "failed";
                    }
                    else
                    {
                        qg.LogInKey = ErecruitHelper.getHash(psWord.Trim(), keySalt.Trim());
                        qg.DefaultLoginKeyChanged = true;
                        qg.DateModified = DateTime.Now;
                        _db.SaveChanges();
                        return "success";
                    }
                }
                else
                {
                    var qg = _db.Candidates.AsEnumerable().FirstOrDefault(s => s.Username.Trim() == usName.Trim());
                    if (qg == null)
                    {
                        return "failed";
                    }
                    else
                    {
                        qg.LogInKey = ErecruitHelper.getHash(psWord.Trim(), keySalt.Trim());
                        qg.ModifiedBy = qg.Username;
                        qg.DateModified = DateTime.Now;
                        _db.SaveChanges();
                        return "success";
                    }
                }


                //if (!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
                //{
                //    byte[] pw = ErecruitHelper.getByte(psWord, keySalt);
                //    byte[] pwFromDB = Convert.FromBase64String(key);
                
                    //if (ErecruitHelper.CompareByteArrays(pw, pwFromDB))
                    //{
                    //    return "success";
                    //}
                    //else
                    //{
                    //    return "failed";
                    //}
                //}
                //else
                //{
                //    return "failed";
                //}



            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}