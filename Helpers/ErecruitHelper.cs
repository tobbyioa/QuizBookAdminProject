using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using QuizBook.Models;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI;
using System.Data.Objects;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;
using System.Data.Entity;
using System.Net.Mail;
using System.Web.Hosting;

namespace QuizBook.Helpers
{
    public  class ErecruitHelper
    {
        static QuizBookDbEntities1 _db = new QuizBookDbEntities1();

        private static void RegisterEmail(string header, string message, string from, string to, string appcode, string ss, string ip)
        {
            // var fromAddress = new MailAddress("noreply.bdcpro@gmail.com", "BDC Pro");

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message, null, "text/html");

            //Add Image
            LinkedResource theEmailImage = new LinkedResource(HostingEnvironment.MapPath("~/Images/book.png"));
            theEmailImage.ContentId = "filename";

            //Add the Image to the Alternate view
            htmlView.LinkedResources.Add(theEmailImage);



            var fromAddress = new MailAddress("tobbyioa@gmail.com", "QuizBook Pro");
            var toAddress = new MailAddress(to, to);
            var smtp = new SmtpClient
            {
                 Host = "smtp.gmail.com",
                //Host = "secure.emailsrvr.com",
                Port = 587,
                //Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "glkioa")
            };
            using (var messagex = new MailMessage(fromAddress, toAddress)
            {
                Subject = header,
                //Body = message,
                IsBodyHtml = true
            })
            {
                messagex.AlternateViews.Add(htmlView);
                smtp.Send(messagex);
            }
        }


        public static void sendProfile(QuizBook.Candidate user, string comment, string lk)
        {
            //var ews = new EmailService.EmailService();
            var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            var from = WebConfigurationManager.AppSettings["GlobalEmail"].ToString();
            var message = "<html><body><!-- BEGIN MESSAGE_BODY -->"
                + "<div style='width: 100%;'><b style='font-weight:900;font-size:20pt;'>QuizBook</b> <img src = \"cid:filename\" alt = 'QB' style = 'height:30px;width:39px;' /></ div ><br><br /><br />"
                  + "Dear <b>" + user.LastName.ToUpper() + " " + user.FirstName.ToUpper() + "</b>,<br>" +
                          "<br>This is to notify you that your Profile has been set up on the QuizBook<b><br/><br />" +
                          "Below are the details: <br /><br />" +
                          "<b>Username:</b>&nbsp;" + user.Username + "<br><br>" +
                          "<b>Password:</b>&nbsp;" + lk + "<br><br>" +
                          "<br>Kindly login and change your password.  <a href='http://www.quizbookpro.com'>www.quizbookpro.com</a>" +
                          "<br><br>Thanks,<br><br><b>Quiz Book Support Team</b>" +
                          "<!-- END MESSAGE_BODY --></body></html>";

            //var ss = SessionHelper.FetchSessionToken(session);
            RegisterEmail("QuizBookPro : Profile SetUp", message, from, user.Email, appcode, "", "");
        }
        public static void sendProfile(AdminUser user, string comment, string lk)
        {
            //var ews = new EmailService.EmailService();
            var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            var from = WebConfigurationManager.AppSettings["GlobalEmail"].ToString();
            var message = "<html><body><!-- BEGIN MESSAGE_BODY -->"
                + "<div style='width: 100%;'><b style='font-weight:900;font-size:20pt;'>QuizBook</b> <img src = \"cid:filename\" alt = 'QB' style = 'height:30px;width:39px;' /></ div ><br><br /><br />"
                  + "Dear <b>" + user.LastName.ToUpper() + " " + user.FirstName.ToUpper() + "</b>,<br>" +
                          "<br>This is to notify you that your Profile has been set up on the QuizBook<b><br/><br />" +
                          "Below are the details: <br /><br />" +
                          "<b>Username:</b>&nbsp;" + user.Username + "<br><br>" +
                          "<b>Password:</b>&nbsp;" + lk + "<br><br>" +
                          "<br>Kindly login and change your password. <a href='http://www.quizbookpro.com'>www.quizbookpro.com</a>" +
                          "<br><br>Thanks,<br><br><b>Quiz Book Support Team</b>" +
                          "<!-- END MESSAGE_BODY --></body></html>";

            //var ss = SessionHelper.FetchSessionToken(session);
            RegisterEmail("QuizBookPro : Profile SetUp", message, from, user.Email, appcode, "", "");
        }


        public static void sendPwReser(QuizBook.Candidate user, string comment, string lk)
        {
            //var ews = new EmailService.EmailService();
            var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            var from = WebConfigurationManager.AppSettings["GlobalEmail"].ToString();
            var message = "<html><body><!-- BEGIN MESSAGE_BODY -->"
                 + "<div style='width: 100%;'><b style='font-weight:900;font-size:20pt;'>QuizBook</b> <img src = \"cid:filename\" alt = 'QB' style = 'height:30px;width:39px;' /></ div ><br><br /><br />"
                + "Dear <b>" + user.LastName.ToUpper() + " " + user.FirstName.ToUpper() + "</b>,<br>" +
                          "<br>This is to notify you that you just reset the password to your Quizbook profile<b><br/><br />" +
                          "Below are the details: <br /><br />" +
                          "<b>Username:</b>&nbsp;" + user.Username + "<br><br>" +
                          "<b>Password:</b>&nbsp;" + lk + "<br><br>" +
                          "<br>Kindly login and change your password" +
                          "<br><br>Thanks,<br><br><b>Quiz Book Support Team</b>" +
                          "<!-- END MESSAGE_BODY --></body></html>";

            //var ss = SessionHelper.FetchSessionToken(session);
            RegisterEmail("QuizBookPro : Profile SetUp", message, from, user.Email, appcode, "", "");
        }

        public static int getOptionNum(QuizBookDbEntities1 _db,long id)
        {
            var result = 0;
            if (id != null)
            {
                var opts = _db.T_Option.Where(s => s.Q_Id == id).ToList();
                result = opts.Count();
            }
            return result;
        }

        public static String[] GetuserPermissions(QuizBookDbEntities1 _db, QuizBook.Candidate user)
        {
            var perms = _db.RolePermissions.AsEnumerable().Where(s => s.RoleId == user.Role.Value && s.Permission.PermissionStatus == true).Select(x => x.Permission.NameString).ToArray();

            return perms;
        }

        public static String[] GetAdminPermissions(QuizBookDbEntities1 _db, AdminUser user)
        {
            var perms = _db.RolePermissions.AsEnumerable().Where(s => s.RoleId == user.Role.Value && s.Permission.PermissionStatus == true).Select(x => x.Permission.NameString).ToArray();

            return perms;
        }

        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public static string getHash(string k, string s)
        {

            byte[] kb = Encoding.UTF8.GetBytes(string.Concat(k));
            byte[] sb = Encoding.UTF8.GetBytes(string.Concat(s));

            byte[] hh = GenerateSaltedHash(kb, sb);

            return Convert.ToBase64String(hh);

        }
        public static byte[] getByte(string k, string s)
        {

            byte[] kb = Encoding.UTF8.GetBytes(string.Concat(k));
            byte[] sb = Encoding.UTF8.GetBytes(string.Concat(s));

            byte[] hh = GenerateSaltedHash(kb, sb);

            return hh;

        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }


        public static string GetLastTestLogin(long userid)
        {
            var ct = _db.T_CTestTracker.OrderByDescending(s => s.CurrentStartTime).FirstOrDefault(x => x.CandidateId == userid);

            if (ct != null)
            {
                var x = ct.CurrentStartTime;

                return x ==null?"-":x.Value.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                return "-";
            }

        }

        public static string getOptionNumLink(QuizBookDbEntities1 _db, long id,long qid)
        {
            var result = 0;
            if (id != null)
            {
                var opts = _db.T_Option.Where(s => s.Q_Id == id).ToList();
                result = opts.Count();
            }
            return "<a href='QuestionOptions.aspx?z=" + qid + "' >" + result.ToString() + "</a>";
        }

        public static string getBatchName( long id)
        {
            return _db.T_Batch.Where(s => s.Id == id).Select(x =>x.Name).FirstOrDefault();
        }

        public static string getCandidateBranch(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.branch_tab.branch_name).FirstOrDefault();
        }
        public static string getCandidateDivision(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.division_tab.DIV_NAME).FirstOrDefault();
        }

        public static string getCandidateBranch(string id)
        {
            return _db.T_Candidate.Where(s => s.StaffID == id).Select(x => x.branch_tab.branch_name).FirstOrDefault();
        }
        public static string getCandidateDivision(string id)
        {
            return _db.T_Candidate.Where(s => s.StaffID == id).Select(x => x.division_tab.DIV_NAME).FirstOrDefault();
        }
        public static string getBranchName( QuizBookDbEntities1 _db,string id)
        {
            var br = _db.branch_tab.Where(s => s.sol_id==id).FirstOrDefault();
            if (br != null)
            {
                return br.branch_name.ToUpper();
            }
            else
            {
                return "-";
            }
        }

        public static string getRegionName(QuizBookDbEntities1 _db,string id)
        {
            var br = _db.region_tab.Where(s => s.region_code == int.Parse(id)).FirstOrDefault();
            if (br != null)
            {
                return br.region_name.ToUpper();
            }
            else
            {
                return "-";
            }
        }

        public static string getSectorName(QuizBookDbEntities1 _db,string id)
        {
            var br = _db.sector_tab.Where(s => s.SECTOR_CODE == id).FirstOrDefault();
            if (br != null)
            {
                return br.SECTOR_NAME.ToUpper();
            }
            else
            {
                return "-";
            }
        }

        public static string getGradeName(QuizBookDbEntities1 _db,string id)
        {
            var br = _db.grade_tab.Where(s => s.GRADE_CODE == id).FirstOrDefault();
            if (br != null)
            {
                return br.GRADE_LEVEL.ToUpper();
            }
            else
            {
                return "-";
            }
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public static Control GetPostBackControl(Page page)
        {
            Control control = null;
            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != String.Empty)
            {
                control = page.FindControl(ctrlname);

            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Panel)
                    {
                        control = c;
                        break;
                    }
                }

            }
            return control;
        }

        public static string getDivisionName(QuizBookDbEntities1 _db,string id)
        {
            var br = _db.division_tab.Where(s => s.DIV_CODE == id).FirstOrDefault();
            if (br != null)
            {
                return br.DIV_NAME.ToUpper();
            }
            else
            {
                return "-";
            }
        }

        public static string GetIP(System.Web.HttpContext context)
        {
            string appLoc = WebConfigurationManager.AppSettings["AppLocation"].ToString();
            var ret = "";
            switch (appLoc)
            {
                case "0":
                    string localComputerName = Dns.GetHostName();
                    IPAddress[] ips = Dns.GetHostAddresses(localComputerName);
                    IPAddress theIP = null;
                    foreach (var localIP in ips)
                    {
                        if (localIP.AddressFamily == AddressFamily.InterNetwork)
                        {
                            theIP = localIP;
                        }
                    }
                    var IP = theIP.ToString();

                    ret = theIP.ToString();

                    break;
                case "1":
                    ret = context.Request.UserHostAddress;
                    break;
            }
            return ret;
        }


        public static string getCandidateCode(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.Code).FirstOrDefault();
        }
        public static T_CTestTracker getTracker(long cid, long bid)
        {
            return _db.T_CTestTracker.Where(s => s.CandidateId == cid && s.BatchId == bid).FirstOrDefault();
        }

        public static string getCandidateFirstName(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.FirstName).FirstOrDefault();
        }
        public static string getCandidateLastName(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.LastName).FirstOrDefault();
        }
        public static T_Candidate getCandidate(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).FirstOrDefault();
        }
        public static string getCandidateImgUrl(long id)
        {
            string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
            var pt = _db.T_Candidate.Where(s => s.Id == id).Select(x => x.Passport).FirstOrDefault();
            if (string.IsNullOrEmpty(pt))
            {
                return path;
            }
            else
            {
                return pt;
            }
        }
        public bool HasPermissions(HttpSessionState session, string permission)
        {
            string[] ps = SessionHelper.FetchUserPermissions(session);

            return ps.Contains(permission) ? true : false;
        }
        public static bool HasPermissions(HttpSessionState session, string[] permission)
        {
            string[] ps = SessionHelper.FetchUserPermissions(session);

            return ps.Intersect(permission).Any() ? true : false;
        }
        public static PermissionModel GetUserPermissions(HttpSessionState session)
        {
            string[] ps = SessionHelper.FetchUserPermissions(session);
            return new PermissionModel
            {
                _CanDoTest = ps.Contains("CanDoTest") ? true : false,
                _CanViewOwnTestResult = ps.Contains("CanViewOwnTestResult") ? true : false
            };
        }
        public static AdminPermissionModel GetAdminUserPermissions(HttpSessionState session)
        {
            string[] ps = SessionHelper.FetchUserPermissions(session);
            return new AdminPermissionModel
            {
                _IsAdmin = ps.Contains("IsAdmin") ? true : false,
                _CanWorkWithCandidates = ps.Contains("CanWorkWithCandidates") ? true : false,
                _CanManageTestBatches = ps.Contains("CanManageTestBatches") ? true : false,
                _CanManageQuestion = ps.Contains("CanManageQuestion") ? true : false,
                _CanManageTestResults = ps.Contains("CanManageTestResults") ? true : false,
                _CanManagePortal = ps.Contains("CanManagePortal") ? true : false,
                _CanApprove = ps.Contains("CanApprove") ? true : false
            };
        }
        public static AllPermissionModel GetAllPermissions(HttpSessionState session)
        {
            string[] ps = SessionHelper.FetchUserPermissions(session);
            return new AllPermissionModel
            {
                 _CanDoTest = ps.Contains("CanDoTest") ? true : false,
                _CanViewOwnTestResult = ps.Contains("CanViewOwnTestResult") ? true : false,
                _IsAdmin = ps.Contains("IsAdmin") ? true : false,
                _CanWorkWithCandidates = ps.Contains("CanWorkWithCandidates") ? true : false,
                _CanManageTestBatches = ps.Contains("CanManageTestBatches") ? true : false,
                _CanManageQuestion = ps.Contains("CanManageQuestion") ? true : false,
                _CanManageTestResults = ps.Contains("CanManageTestResults") ? true : false,
                _CanManagePortal = ps.Contains("CanManagePortal") ? true : false,
                _CanApprove = ps.Contains("CanApprove") ? true : false
            };
        }
        //public static string GetIP(System.Web.HttpContext context)
        //{
        //    string appLoc = WebConfigurationManager.AppSettings["AppLocation"].ToString();
        //    var ret = "";
        //    switch (appLoc)
        //    {
        //        case "0":
        //            string localComputerName = Dns.GetHostName();
        //            IPAddress[] ips = Dns.GetHostAddresses(localComputerName);
        //            IPAddress theIP = null;
        //            foreach (var localIP in ips)
        //            {
        //                if (localIP.AddressFamily == AddressFamily.InterNetwork)
        //                {
        //                    theIP = localIP;
        //                }
        //            }
        //            var IP = theIP.ToString();

        //            ret = theIP.ToString();

        //            break;
        //        case "1":
        //            ret = context.Request.UserHostAddress;
        //            break;
        //    }
        //    return ret;
        //}
        public static string getCandidateSex(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.Sex).FirstOrDefault();
        }
        public static DateTime? getCandidateDobx(long id)
        {
            return _db.T_Candidate.Where(s => s.Id == id).Select(x => x.DateOfBirth).FirstOrDefault();
        }
        public static string getCandidateDOB(long id)
        {
            return GetDateStringFromDate((DateTime)_db.T_Candidate.Where(s => s.Id == id).Select(x => x.DateOfBirth).FirstOrDefault());
        }
        public static string GetCandidateOptions(long cid,long bid, long qid){
            var answers = _db.T_CandidateAnswers.Where(s => s.CandidateId == cid && s.BatchId == bid && s.QuestionId == qid).Select(x => x.Answer.Value.ToString()).ToList();
            return String.Join(",", answers.ToArray());
        }
        public static void SetErrorData(Exception ex, HttpSessionState session)
        {
            SessionHelper.SetCurrentErrorApp(ex.StackTrace, session);
            SessionHelper.SetCurrentErrorMethod(ex.GetBaseException().ToString(), session);
            SessionHelper.SetCurrentErrorMessage(ex.Message.ToString(), session);
        }
        public static bool IsBatchDone(long batchid)
        {
            var batch = _db.T_Batch.FirstOrDefault(s => s.Id == batchid);
            var bSets = _db.T_BatchSet.Where(s => s.BatchId == batchid);
            var unfinished = bSets.Where(s => s.Finished == false).Count();

            if (bSets.Count() > 0 && unfinished > 0)
            {
                return false;
            }
            else if (bSets.Count() > 0 && unfinished == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void CheckBatches( QuizBookDbEntities1 _db,T_Batch candBatch)
        {

            var batchMemberCount = _db.T_BatchSet.Count(s => s.BatchId == candBatch.Id);
            var batchActiveMemberCount = _db.T_BatchSet.Count(s => s.BatchId == candBatch.Id && s.Finished == true);
            if (batchMemberCount == batchActiveMemberCount)
            {
                candBatch.SessionOn = false;
                _db.SaveChanges();
            }
        }
        public static string getTypeName(QuizBookDbEntities1 _db, long? id)
        {
            var result = "";
            if (id != null)
            {
                var typ = _db.T_QuestionType.Where(s => s.Id == id).FirstOrDefault();
                result = typ.Name;
            }
            else
            {
                result = "-";
            }
            return result;
        }
        public static string getOptionTypeName(QuizBookDbEntities1 _db, long? id)
        {
            var result = "";
            if (id != null)
            {
                var typ = _db.T_QOptionType.Where(s => s.Id == id).FirstOrDefault();
                result = typ.Name;
            }
            else
            {
                result = "-";
            }
            return result;
        }
        public static string GetPreambleName(QuizBookDbEntities1 _db,long? preambleId)
        {
            if (preambleId.Value == 0)
            {
                return "N/A";
            }
            else
            {
                var typ = _db.T_QuestionsPreambles.FirstOrDefault(s => s.Id == preambleId.Value);
                if (typ != null)
                {
                    return typ.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        public static string getQOptionTypeName(long id)
        {
            var result = "";
            if (id != null)
            {
                var q = _db.T_Question.Where(s => s.Id == id).FirstOrDefault();
                var typ = _db.T_QOptionType.Where(s => s.Id == q.OptionType).FirstOrDefault();
                result = typ.Name;
            }
            else
            {
                result = "-";
            }
            return result;
        }
        public static string trimQuestion(string s)
        {
            var result = "";
            if (s != null)
            {
                result = s.Length > 100 ? s.Substring(0, 100) + "..." : s;
            }
            else
            {
                result = "-";
            }
            return result;
        }
        public static void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file

            FileStream newFile = new FileStream(strPath, FileMode.Create);

            // Write data to the file

            newFile.Write(Buffer, 0, Buffer.Length);

            // Close file

            newFile.Close();
        }
        public static string GenerateCandidateCode(int CCount)
        {
            return  String.Format("{0:000000}", CCount);
        }
        public static void sendTestInviteMail(T_Candidate cand, T_Batch batch,HttpSessionState session,string ip)
        {
            var ews = new EmailService.EmailService();
            var appcode = WebConfigurationManager.AppSettings["AppCode"].ToString();
            var ss = SessionHelper.FetchSessionToken(session);
            var emailBody = "Hello " + cand.FirstName + ",<br />You are invited for a test at <a href='http://www.fidelitybankplc.com'>Fidelity bank PLC</a><br/><br/>" +
                "<b>Candidate Name: " + cand.FirstName + " " + cand.LastName + "</b><br />" +
                "<b>Candidate Code: " + cand.Code + "</b><br />" +
                "<b>Test Duration: " + batch.Duration + " minutes</b><br />" +
                "<b>Test Date: " + ErecruitHelper.GetDateStringFromDate((DateTime)batch.StartDate) + "</b>";
            var from = "fidelityrecruitment@fidelitybankplc.com";
            var to = cand.Email;
            var subject = "QuizBook Test Invite";
            var response =  ews.RegisterEmail(subject,emailBody,from,to,appcode,ss,ip);
            //ews.RegisterProcessEmail(subject, emailBody, from, to, appcode, ip);
        }
        public static DateTime GetCurrentDateFromDateString(string d)
        {
            if (string.IsNullOrEmpty(d))
            {
                return DateTime.Now;
            }
            else
            {
                TimeZoneInfo timeZoneInfo;
                DateTime date;
                //Set the time zone information to US Mountain Standard Time
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
                //Get date and time in US Mountain Standard Time
                date = TimeZoneInfo.ConvertTime(DateTime.ParseExact(d.Trim(), "dd/MM/yyyy", null), timeZoneInfo);
                return date;
            }
        }
        public static DateTime GetCurrentDateFromDateStringWithHM(string d)
        {
            if (string.IsNullOrEmpty(d))
            {
                return DateTime.Now;
            }
            else
            {
                TimeZoneInfo timeZoneInfo;
                DateTime date;
                //Set the time zone information to US Mountain Standard Time
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
                //Get date and time in US Mountain Standard Time
                date = TimeZoneInfo.ConvertTime(DateTime.ParseExact(d.Trim(), "dd/MM/yyyy HH:mm", null), timeZoneInfo);
                return date;
            }
        }
        public static string GetDateStringFromDate(DateTime d)
        {
            // var culture = new CultureInfo("ig-NG");
            // var dt = DateTime.ParseExact(d.ToString(), "MM/dd/yyyy h:mm:ss tt", null);

            //var s = dt.ToString("dd/MM/yyyy");
            //return s;
            int day = d.Day;
            int month = d.Month;
            int year = d.Year;

            return AppendZero(day) + "/" + AppendZero(month) + "/" + year + " " + d.ToString("h:mm tt") ;
        }
        public static string GetDateStringFromDateX(DateTime d)
        {
            // var culture = new CultureInfo("ig-NG");
            // var dt = DateTime.ParseExact(d.ToString(), "MM/dd/yyyy h:mm:ss tt", null);

            //var s = dt.ToString("dd/MM/yyyy");
            //return s;
            int day = d.Day;
            int month = d.Month;
            int year = d.Year;

            return AppendZero(day) + "/" + AppendZero(month) + "/" + year  ;
        }
        public static string AppendZero(int i)
        {
            if (i < 10)
            {
                return "0" + i.ToString();
            }
            return i.ToString();
        }
        public static IEnumerable<string[]> GetAllLines(string filepath)
        {
            string str;
            using (StreamReader rd = new StreamReader(filepath))
            {
                while ((str = rd.ReadLine()) != null)
                {
                    yield return str.Split(',');
                }
            }
        }
        public static List<string[]> GetLinesFromFile (string path, string ext)
        {
            string connString = "";
            var all = new List<string[]>();
            if (ext == ".xls")
            {

                connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                               "Data Source=" + path + ";" +
                               "Extended Properties=Excel 8.0;";
                DataTable excelDT;
                int sheetNumber = 0; // select a sheet(zero base index) which will be loaded!
                excelDT = ErecruitHelper.GetDataFromSingleSheet(sheetNumber, connString);
                int l = excelDT.Columns.Count;
                foreach (DataRow row in excelDT.Rows) // Loop over the rows.
                {
                    string[] r = new string[l];
                    var dr = row.ItemArray;
                    for (int i = 0; i < l; i++) // Loop over the items.
                    {
                        r[i] = dr[i].ToString();
                    }
                    all.Add(r);
                }

            }
            else if (ext == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                               "Data Source= " + path + ";" +
                               "Extended Properties=Excel 12.0;";

                DataTable excelDT;
                int sheetNumber = 0; // select a sheet(zero base index) which will be loaded!

                excelDT = ErecruitHelper.GetDataFromSingleSheet(sheetNumber, connString);
                int l = excelDT.Columns.Count;
                foreach (DataRow row in excelDT.Rows) // Loop over the rows.
                {
                    string[] r = new string[l];
                    var dr = row.ItemArray;
                    for (int i = 0; i < l; i++) // Loop over the items.
                    {
                        r[i] = dr[i].ToString();
                    }
                    all.Add(r);
                }

            }
            else if (ext == ".csv" || ext == ".txt")
            {
                all = GetAllLines(path).ToList();
            }
            else
            {
                //infoDiv.InnerText = "Wrong file type provided. Only allowed file type is .xls and .xlsx!";

            }
            return all;
        }
        public static DataTable GetDataFromSingleSheet(int sheetNumber, string connString)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dtSchemaTable = null;

            DataSet ds = new DataSet();
            DataTable dtData = new DataTable();

            try
            {
                // Create connection.
                objConn = new OleDbConnection(connString);

                // Opens connection with the database.
                objConn.Open();

                // Get the data table containing the schema guid, and also sheet names.
                dtSchemaTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dtSchemaTable != null)
                {
                    String[] excelSheets = new String[dtSchemaTable.Rows.Count];
                    int i = 0;

                    // Add the sheet name to the string array.
                    foreach (DataRow row in dtSchemaTable.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[sheetNumber] + "]", objConn);
                    OleDbDataAdapter oleda = new OleDbDataAdapter();

                    oleda.SelectCommand = cmd;
                    oleda.Fill(dtData);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dtSchemaTable != null)
                {
                    dtSchemaTable.Dispose();
                }
            }

            return dtData;
        }

        public List<Answer> AnswersReport(long? uId, long? bid, QuizBookDbEntities1 _db)
        {
            ResultModel m = new ResultModel();
            var anss = _db.T_CandidateAnswers.AsEnumerable().Where(x => x.CandidateId == uId && x.BatchId == bid).Select(s => s.QuestionId).Distinct().ToList();
            var ans = anss.Select((s, i) => new Answer
            {
                sn = (i + 1).ToString(),
                question = _db.T_Question.FirstOrDefault(x => x.Id == s).Details,
                Mark = _db.T_Question.FirstOrDefault(x => x.Id == s).Mark,
                Score = GetScoreForQuestion(uId, bid, s, _db),
                chosenAnswer = chosenAnswers(uId, s, bid, _db),
                correctAnswer = CAnswers(s, _db),
                correct = Correctness(uId, s, bid, _db)
            }).ToList();

            return ans;

        }
        public decimal GetScoreForQuestion(long? uId, long? bid, long? qid, QuizBookDbEntities1 _db)
        {
            var anss = _db.T_CandidateAnswers.AsEnumerable().Where(x => x.CandidateId == uId && x.BatchId == bid).ToList();
            var quest = _db.T_Question.FirstOrDefault(x => x.Id == qid);
            var questionOptions = quest.T_Option.Where(s => s.Answer.Value).Select(x => x.Id).ToList();
            var chosenOption = anss.Where(x => x.QuestionId == qid).Select(s => s.Answer.Value).ToList();

            if (quest.T_QOptionType.Name == "Multi")
            {
                if (quest.OptionPercentageMark.Value)
                {

                    var rest = ScrambledEquals(questionOptions, chosenOption);
                    if (rest)
                    {
                        //Correct
                        return quest.Mark.Value;
                    }
                    else if (questionOptions.Except(chosenOption).Any())
                    {

                        //Partial
                        var correctEntries = questionOptions.Intersect(chosenOption).ToList();
                        return (correctEntries.Count() * quest.Mark.Value) / questionOptions.Count();

                    }
                    else
                    {
                        //Wrong
                        return 0;
                    }

                }
                else
                {
                    var rest = ScrambledEquals(questionOptions, chosenOption);
                    if (rest)
                    {
                        //Correct
                        return quest.Mark.Value;
                    }
                    else
                    {
                        //Wrong
                        return 0;
                    }
                }
            }
            else
            {
                var rest = ScrambledEquals(questionOptions, chosenOption);
                if (rest)
                {
                    //Correct
                    return quest.Mark.Value;
                }
                else
                {
                    //Wrong
                    return 0;
                }
            }

        }

        public ResultModel BatchSummary(long? uId, long? bid, QuizBookDbEntities1 _db)
        {
            ResultModel m = new ResultModel();
            var anss = _db.T_CandidateAnswers.AsEnumerable().Where(x => x.CandidateId == uId && x.BatchId == bid).ToList();
            var qs = anss.Where(x => x.Answer.Value != -1).Select(s => s.QuestionId).Distinct().ToList();
            var ua = anss.Where(x => x.Answer.Value == -1).ToList();
            m.questionCount = qs.Count();
            m.UnansweredCount = ua.Count();
            m.Unanswered = ua.Sum(x => x.T_Question.Mark.Value);

            foreach (var question in qs)
            {

                var quest = _db.T_Question.FirstOrDefault(x => x.Id == question);
                m.questionTotalMark += quest.Mark.Value;
                var questionOptions = quest.T_Option.Where(s => s.Answer.Value).Select(x => x.Id).ToList();
                var chosenOption = anss.Where(x => x.QuestionId == question).Select(s => s.Answer.Value).ToList();

                if (quest.T_QOptionType.Name == "Multi")
                {
                    if (quest.OptionPercentageMark.Value)
                    {

                        var rest = ScrambledEquals(questionOptions, chosenOption);
                        if (rest)
                        {
                            // ret = optionState.Correct.ToString();
                            m.CorrectCount += 1;
                            m.Correct += quest.Mark.Value;
                        }
                        else if (questionOptions.Except(chosenOption).Any())
                        {
                            // ret = optionState.Partial.ToString();
                            m.PartialCount += 1;

                            var correctEntries = questionOptions.Intersect(chosenOption).ToList();
                            var wrongs = chosenOption.Except(questionOptions);

                            m.Partial += (correctEntries.Count() * quest.Mark.Value) / questionOptions.Count();
                            m.Wrong += (wrongs.Count() * quest.Mark.Value) / questionOptions.Count();
                        }
                        else
                        {
                            m.WrongCount += 1;
                            m.Wrong += quest.Mark.Value;
                            // ret = optionState.Wrong.ToString();
                        }

                    }
                    else
                    {
                        var rest = ScrambledEquals(questionOptions, chosenOption);
                        if (rest)
                        {
                            //ret = optionState.Correct.ToString();
                            m.CorrectCount += 1;
                            m.Correct += quest.Mark.Value;
                        }
                        else
                        {
                            m.WrongCount += 1;
                            m.Wrong += quest.Mark.Value;
                            // ret = optionState.Wrong.ToString();
                        }
                    }
                }
                else
                {
                    var rest = ScrambledEquals(questionOptions, chosenOption);
                    if (rest)
                    {
                        // ret = optionState.Correct.ToString();
                        m.CorrectCount += 1;
                        m.Correct += quest.Mark.Value;
                    }
                    else
                    {
                        m.WrongCount += 1;
                        m.Wrong += quest.Mark.Value;
                        // ret = optionState.Wrong.ToString();
                    }
                }

            }

            //m.CorrectPercent = Math.Round((m.CorrectCount * 100) / m.questionCount,2);
            //m.WrongPercent = Math.Round((m.WrongCount * 100) / m.questionCount, 2);
            //m.PartialPercent = Math.Round((m.PartialCount * 100) / m.questionCount, 2);
            //m.UnansweredPercent = Math.Round((m.UnansweredCount * 100) / m.questionCount, 2);

            m.CorrectPercent = Math.Round((m.Correct * 100) / m.questionTotalMark, 2);
            m.WrongPercent = Math.Round((m.Wrong * 100) / m.questionTotalMark, 2);
            m.PartialPercent = Math.Round((m.Partial * 100) / m.questionTotalMark, 2);
            m.UnansweredPercent = Math.Round((m.Unanswered * 100) / m.questionTotalMark, 2);

            m.testDate = anss.AsEnumerable().Max(x => x.TimeMarked.Value);
            return m;
        }

        public string CAnswers(long? qid, QuizBookDbEntities1 _db)
        {
            var ret = optionState.Wrong.ToString();

            var quest = _db.T_Question.FirstOrDefault(x => x.Id == qid);

            var questOptions = quest.T_Option.Where(x => x.Answer.Value).ToList();
            var wrongs = questOptions.Select(x => "<b style = 'color:black;'>" + x.Details + "</b>").ToList();
            ret = string.Join("<br />", wrongs.ToArray());

            return ret;
        }

        public string chosenAnswers(long? uId, long? qid, long? bid, QuizBookDbEntities1 _db)
        {
            var anss = _db.T_CandidateAnswers.AsEnumerable().Where(x => x.CandidateId == uId && x.BatchId == bid && x.QuestionId == qid).Select(s => s.Answer).ToArray();
            var quest = _db.T_Question.FirstOrDefault(x => x.Id == qid);
            var questionOptions = quest.T_Option.Where(s => s.Answer.Value).Select(x => x.Id).ToList();

            var chosen = _db.T_Option.Where(x => x.Q_Id == qid && anss.Contains(x.Id)).ToList();


            var fullAns = chosen.Select(s => s.Details).ToArray();

            var chosenOption = chosen.Select(x => x.Id).ToList();

            var retr = "";

            if (quest.T_QOptionType.Name == "Multi")
            {
                if (quest.OptionPercentageMark.Value)
                {

                    var rest = ScrambledEquals(questionOptions, chosenOption);
                    if (rest)
                    {


                        //fullAns.Select(c => "<b style = 'color:green;'>" + c + "</b>");

                        var rights = chosen.Where(x => chosenOption.Intersect(questionOptions).Contains(x.Id)).Select(x => "<b style = 'color:green;'>" + x.Details + "</b>").ToList();

                        retr = string.Join("<br />", rights.ToArray());
                    }
                    else if (questionOptions.Except(chosenOption).Any())
                    {
                        var wrongs = chosen.Where(s => chosenOption.Except(questionOptions).Contains(s.Id)).Select(x => "<b style = 'color:red;'>" + x.Details + "</b>").ToList();
                        var rights = chosen.Where(x => chosenOption.Intersect(questionOptions).Contains(x.Id)).Select(x => "<b style = 'color:green;'>" + x.Details + "</b>").ToList();
                        var ans = new List<string>();
                        ans.AddRange(wrongs);
                        ans.AddRange(rights);
                        retr = string.Join("<br />", ans.ToArray());
                    }
                    else
                    {
                        //fullAns.Select(c => "<b style = 'color:red;'>" + c + "</b>");

                        //retr = string.Join("<br />", fullAns);
                        var wrongs = chosen.Where(s => chosenOption.Except(questionOptions).Contains(s.Id)).Select(x => "<b style = 'color:red;'>" + x.Details + "</b>").ToList();
                        retr = string.Join("<br />", wrongs.ToArray());
                    }

                }
                else
                {
                    var rest = ScrambledEquals(questionOptions, chosenOption);
                    if (rest)
                    {
                        //fullAns.Select(c => "<b style = 'color:green;'>" + c + "</b>");

                        //retr = string.Join("<br />", fullAns);
                        var rights = chosen.Where(x => chosenOption.Intersect(questionOptions).Contains(x.Id)).Select(x => "<b style = 'color:green;'>" + x.Details + "</b>").ToList();
                        retr = string.Join("<br />", rights.ToArray());
                    }
                    else
                    {
                        //fullAns.Select(c => "<b style = 'color:red;'>" + c + "</b>");

                        //retr = string.Join("<br />", fullAns);
                        var wrongs = chosen.Where(s => chosenOption.Except(questionOptions).Contains(s.Id)).Select(x => "<b style = 'color:red;'>" + x.Details + "</b>").ToList();
                        retr = string.Join("<br />", wrongs.ToArray());
                    }
                }
            }
            else
            {
                var rest = ScrambledEquals(questionOptions, chosenOption);
                if (rest)
                {
                    //fullAns.Select(c => "<b style = 'color:green;'>" + c + "</b>");

                    //retr = string.Join("<br />", fullAns);
                    var rights = chosen.Where(x => chosenOption.Intersect(questionOptions).Contains(x.Id)).Select(x => "<b style = 'color:green;'>" + x.Details + "</b>").ToList();
                    retr = string.Join("<br />", rights.ToArray());
                }
                else
                {
                    //fullAns.Select(c => "<b style = 'color:red;'>" + c + "</b>");

                    //retr = string.Join("<br />", fullAns);
                    var wrongs = chosen.Where(s => chosenOption.Except(questionOptions).Contains(s.Id)).Select(x => "<b style = 'color:red;'>" + x.Details + "</b>").ToList();
                    retr = string.Join("<br />", wrongs.ToArray());
                }
            }

            return retr;
        }

        public string Correctness(long? uId, long? qid, long? bid, QuizBookDbEntities1 _db)
        {
            var ret = optionState.Wrong.ToString();

            var quest = _db.T_Question.FirstOrDefault(x => x.Id == qid);

            var questOptions = quest.T_Option.Where(x => x.Answer.Value).Select(s => s.Id).ToList();

            var anss = _db.T_CandidateAnswers.AsEnumerable().Where(x => x.CandidateId == uId && x.BatchId == bid && x.QuestionId == qid).Select(s => s.Answer).ToArray();

            var fullAns = _db.T_Option.Where(x => x.Q_Id == qid && anss.Contains(x.Id)).Select(s => s.Id).ToList();


            if (quest.T_QOptionType.Name == "Multi")
            {
                if (quest.OptionPercentageMark.Value)
                {

                    var rest = ScrambledEquals(questOptions, fullAns);
                    if (rest)
                    {
                        ret = optionState.Correct.ToString();
                    }
                    else if (questOptions.Except(fullAns).Any())
                    {
                        ret = optionState.Partial.ToString();

                    }
                    else
                    {
                        ret = optionState.Wrong.ToString();
                    }

                }
                else
                {
                    var rest = ScrambledEquals(questOptions, fullAns);
                    if (rest)
                    {
                        ret = optionState.Correct.ToString();
                    }
                    else
                    {
                        ret = optionState.Wrong.ToString();
                    }
                }
            }
            else
            {
                var rest = ScrambledEquals(questOptions, fullAns);
                if (rest)
                {
                    ret = optionState.Correct.ToString();
                }
                else
                {
                    ret = optionState.Wrong.ToString();
                }
            }


            return ret;
        }

        public bool ScrambledEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            var cnt = new Dictionary<T, int>();
            foreach (T s in list1)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]++;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            foreach (T s in list2)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]--;
                }
                else
                {
                    return false;
                }
            }
            return cnt.Values.All(c => c == 0);
        }

        public string CorrectAnswers(long? qid, QuizBookDbEntities1 _db)
        {
            var fullAns = _db.T_Option.Where(x => x.Q_Id == qid && x.Answer.Value == true).Select(s => s.Details).ToArray();

            return string.Join("<br />", fullAns);
        }

        public enum optionState
        {
            Correct,
            Wrong,
            Partial
        }
        public enum CandidateStatus
        {
            Active,
            Inactive
        }
        public enum BatchType
        {
            Single,
            Multiple
        }
        public enum OptionType
        {
            Single= 1,
            Multi = 2
        }
        public enum Settings
        {
            CUT_OFF_MARK,
            QUESTIONS_PER_TYPE,
            QUESTIONS_PER_PAGE
        }
        public enum BatchGroups
        {
            ALL,
            //GRADE,
            //DIRECTORATE,
            //DIVISION,
            //BRANCH,
            //BANK
        }
        public enum CStatus
        {
            Active,
            Inactive,
            Disabled,
            Deleted
        }
        public enum BatchGroupsR
        {
            ALL,
            GRADE,
            DIRECTORATE,
            DIVISION,
            BRANCH,
            BATCHES,
            BANK
        }
        public enum OptionIndex
        {
            A,
            B,
            C,
            D,
            E
        }
        public struct BGS
        {
            public const string ALL = "ALL";
            public const string GRADE = "GRADE";

            public const string DIVISION = "DIVISION";
            public const string BRANCH = "BRANCH";
            public const string DIRECTORATE = "DIRECTORATE";
            public const string BANK = "BANK";
        }
        public struct BGSR
        {
            public const string ALL = "ALL";
            public const string GRADE = "GRADE";
            public const string DIVISION = "DIVISION";
            public const string BRANCH = "BRANCH";
            public const string BATCHES = "BATCHES";
            public const string DIRECTORATE = "DIRECTORATE";
            public const string BANK = "BANK";
        }
        public enum ApprovalStatus
        {
            APPROVED,
            NOT_APPROVED
        }
        public enum ChangeType
        {
            Delete = 1,
            Insert,
            Update
        }
        //public enum QTypes
        //{
        //    ARITHMETIC = "ARITHMETIC",
        //    NUMERIC_REASONING = "NUMERIC REASONING",
        //    VERBAL_REASONING = "VERBAL REASONING",
        //    COMPREHENSION = "COMPREHENSION"
        //}
    }
}