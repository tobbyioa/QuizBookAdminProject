using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace QuizBook.Helpers
{
    public class SessionHelper
    {
        public static void SetUserId(int UserId, HttpSessionState session)
        {
            session["UserId"] = UserId;
        }

        public static void NullUserId(HttpSessionState session)
        {
            session["UserId"] = null;
        }

        public static Int32 FetchUserId(HttpSessionState session)
        {
            if (session["UserId"] != null)
            {
                return Int32.Parse(session["UserId"].ToString());
            }
            else
            {
                return -1;
            }
        }

        public static void SetTestDuration(string Duration, HttpSessionState Session)
        {
            Session["Duration"] = Duration;
        }
        public static void NullTestDuration(HttpSessionState Session)
        {
            Session["Duration"] = null;
        }

        public static string FetchTestDuration(HttpSessionState Session)
        {
            if (Session["Duration"] != null)
            {
                return Session["Duration"].ToString();
            }
            else
            {
                return "0,0";
            }
        }




        public static void SetPageIndex(int PageIndex, HttpSessionState session)
        {
            session["PageIndex"] = PageIndex;
        }

        public static void NullPreambleIndex(HttpSessionState session)
        {
            session["PageIndex"] = null;
        }

        public static Int32 FetchPageIndex(HttpSessionState session)
        {
            if (session["PageIndex"] != null)
            {
                return Int32.Parse(session["PageIndex"].ToString());
            }
            else
            {
                return -1;
            }
        }


        public static void SetCurrentErrorMessage(string CurrentErrorMessage, HttpSessionState session)
        {
            session["CurrentErrorMessage"] = CurrentErrorMessage;
        }

        public static void NullCurrentErrorMessage(HttpSessionState session)
        {
            session["CurrentErrorMessage"] = null;
        }

        public static string FetchCurrentErrorMessage(HttpSessionState session)
        {
            if (session["CurrentErrorMessage"] != null)
            {
                return session["CurrentErrorMessage"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetCurrentErrorApp(string CurrentErrorSource, HttpSessionState session)
        {
            session["CurrentErrorSource"] = CurrentErrorSource;
        }

        public static void NullCurrentErrorApp(HttpSessionState session)
        {
            session["CurrentErrorSource"] = null;
        }

        public static string FetchCurrentErrorApp(HttpSessionState session)
        {
            if (session["CurrentErrorSource"] != null)
            {
                return session["CurrentErrorSource"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetCurrentErrorMethod(string CurrentErrorMethod, HttpSessionState session)
        {
            session["CurrentErrorSource"] = CurrentErrorMethod;
        }

        public static void NullCurrentErrorMethod(HttpSessionState session)
        {
            session["CurrentErrorMethod"] = null;
        }

        public static string FetchCurrentErrorMethod(HttpSessionState session)
        {
            if (session["CurrentErrorMethod"] != null)
            {
                return session["CurrentErrorMethod"].ToString();
            }
            else
            {
                return "";
            }
        }



        public static void SetCandidateId(string CandidateId, HttpSessionState Session)
        {
            Session["CandidateId"] = CandidateId;
        }
        public static void NullCandidateId(HttpSessionState Session)
        {
            Session["CandidateId"] = null;
        }

        public static string FetchCandidateId(HttpSessionState Session)
        {
            if (Session["CandidateId"] != null)
            {
                return Session["CandidateId"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetCandidateCode(string CandidateCode, HttpSessionState Session)
        {
            Session["CandidateCode"] = CandidateCode;
        }
        public static void NullCandidateCode(HttpSessionState Session)
        {
            Session["CandidateCode"] = null;
        }

        public static string FetchCandidateCode(HttpSessionState Session)
        {
            if (Session["CandidateCode"] != null)
            {
                return Session["CandidateCode"].ToString();
            }
            else
            {
                return "";
            }
        }


        public static void SetUserName(string UserName, HttpSessionState session)
        {
            session["UserName"] = UserName;
        }

        public static void NullUserName(HttpSessionState session)
        {
            session["UserName"] = null;
        }

        public static string FetchUserName(HttpSessionState session)
        {
            if (session["UserName"] != null)
            {
                return session["UserName"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetFirstName(string FirstName, HttpSessionState session)
        {
            session["FirstName"] = FirstName;
        }

        public static void NullFirstName(HttpSessionState session)
        {
            session["FirstName"] = null;
        }

        public static string FetchFirstName(HttpSessionState session)
        {
            if (session["FirstName"] != null)
            {
                return session["FirstName"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetEmail(string Email, HttpSessionState session)
        {
            session["Email"] = Email;
        }

        public static void NullEmail(HttpSessionState session)
        {
            session["Email"] = null;
        }

        public static string FetchEmail(HttpSessionState session)
        {
            if (session["Email"] != null)
            {
                return session["Email"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetSol(string Sol, HttpSessionState session)
        {
            session["Sol"] = Sol;
        }

        public static void NullSol(HttpSessionState session)
        {
            session["Sol"] = null;
        }

        public static Int32 FetchSol(HttpSessionState session)
        {
            if (session["Sol"] != null)
            {
                return Int32.Parse(session["Sol"].ToString());
            }
            else
            {
                return -1;
            }
        }

        public static void SetBranchId(string Sol, HttpSessionState session)
        {
            session["Sol"] = Sol;
        }

        public static void NullBranchId(HttpSessionState session)
        {
            session["Sol"] = null;
        }

        public static string FetchBranchId(HttpSessionState session)
        {
            if (session["Sol"] != null)
            {
                return session["Sol"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetStaffId(string staffId, HttpSessionState session)
        {
            session["StaffId"] = staffId;
        }

        public static void NullStaffId(HttpSessionState session)
        {
            session["StaffId"] = null;
        }

        public static string FetchStaffId(HttpSessionState session)
        {
            if (session["StaffId"] != null)
            {
                return session["StaffId"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void  SetLocation(string location, HttpSessionState session){
            session["Location"] = location;
        }
        public static string GetLocation(HttpSessionState session)
        {
            if (session["LastName"] != null)
            {
               return session["Location"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyLocation(HttpSessionState session){
        session["Location"] = null;
        }

        public static void SetCity(string City, HttpSessionState session)
        {
            session["City"] = City;
        }
        public static string GetCity(HttpSessionState session)
        {
            if (session["City"] != null)
            {
                return session["City"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyCity(HttpSessionState session)
        {
            session["City"] = null;
        }

        public static void SetExMessage(string ExMessage, HttpSessionState session)
        {
            session["ExMessage"] = ExMessage;
        }
        public static string GetExMessage(HttpSessionState session)
        {
            if (session["ExMessage"] != null)
            {
                return session["ExMessage"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyExMessage(HttpSessionState session)
        {
            session["ExMessage"] = null;
        }


        public static void SetExStacktrace(string ExStacktrace, HttpSessionState session)
        {
            session["ExStacktrace"] = ExStacktrace;
        }
        public static string GetExStacktrace(HttpSessionState session)
        {
            if (session["ExStacktrace"] != null)
            {
                return session["ExStacktrace"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyExStacktrace(HttpSessionState session)
        {
            session["ExStacktrace"] = null;
        }

        public static void SetAddress(string Address, HttpSessionState session)
        {
            session["Address"] = Address;
        }
        public static string GetAddress(HttpSessionState session)
        {
            if (session["Address"] != null)
            {
                return session["Address"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyAddress(HttpSessionState session)
        {
            session["Address"] = null;
        }

        public static void SetState(string State, HttpSessionState session)
        {
            session["State"] = State;
        }
        public static string GetState(HttpSessionState session)
        {
            if (session["State"] != null)
            {
                return session["State"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyState(HttpSessionState session)
        {
            session["State"] = null;
        }

        public static void SetCountry(string Country, HttpSessionState session)
        {
            session["Country"] = Country;
        }
        public static string GetCountry(HttpSessionState session)
        {
            if (session["Country"] != null)
            {
                return session["Country"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyCountry(HttpSessionState session)
        {
            session["Country"] = null;
        }

        public static void SetTenantName(string TenantName, HttpSessionState session)
        {
            session["TenantName"] = TenantName;
        }
        public static string GetTenantName(HttpSessionState session)
        {
            if (session["TenantName"] != null)
            {
                return session["TenantName"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyTenantName(HttpSessionState session)
        {
            session["TenantName"] = null;
        }

        public static void SetTenantID(string TenantID, HttpSessionState session)
        {
            session["TenantID"] = TenantID;
        }
        public static string GetTenantID(HttpSessionState session)
        {
            if (session["TenantID"] != null)
            {
                return session["TenantID"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyTenantID(HttpSessionState session)
        {
            session["TenantID"] = null;
        }


        public static void SetTenantImage(string TenantImage, HttpSessionState session)
        {
            session["TenantImage"] = TenantImage;
        }
        public static string GetTenantImage(HttpSessionState session)
        {
            if (session["TenantImage"] != null)
            {
                return session["TenantImage"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyTenantImage(HttpSessionState session)
        {
            session["TenantImage"] = null;
        }

        public static void SetInfoValue(string InfoValue, HttpSessionState session)
        {
            session["InfoValue"] = InfoValue;
        }
        public static string GetInfoValue(HttpSessionState session)
        {
            if (session["InfoValue"] != null)
            {
                return session["InfoValue"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void NullifyInfoValue(HttpSessionState session)
        {
            session["InfoValue"] = null;
        }


        public static void SetLastName(string staffId, HttpSessionState session)
        {
            session["LastName"] = staffId;
        }

        public static void NullLastName(HttpSessionState session)
        {
            session["LastName"] = null;
        }

        public static string FetchLastName(HttpSessionState session)
        {
            if (session["LastName"] != null)
            {
                return session["LastName"].ToString();
            }
            else
            {
                return "";
            }
        }

        public static void SetSessionToken(string sessionToken, HttpSessionState session)
        {
            session["sessionToken"] = sessionToken;
        }

        public static void NullSessionToken(HttpSessionState session)
        {
            session["sessionToken"] = null;
        }

        public static string FetchSessionToken(HttpSessionState session)
        {
            if (session["sessionToken"] != null)
            {
                return session["sessionToken"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetDeptId(string DeptId, HttpSessionState session)
        {
            session["DeptId"] = DeptId;
        }

        public static void NullDeptId(HttpSessionState session)
        {
            session["DeptId"] = null;
        }

        public static Int32 FetchDeptId(HttpSessionState session)
        {
            if (session["DeptId"] != null)
            {
                return Int32.Parse(session["DeptId"].ToString());
            }
            else
            {
                return -1;
            }
        }

        public static void SetUserPermissions(String[] appPermissions, HttpSessionState session)
        {
            session["appPermissions"] = appPermissions;
        }

        public static void NullUserPermissions(HttpSessionState session)
        {
            session["appPermissions"] = null;
        }

        public static String[] FetchUserPermissions(HttpSessionState session)
        {
            if (session == null) return new string[0];
            if (session["appPermissions"] != null)
            {
                return session["appPermissions"] as String[];
            }
            else
            {
                return new string[0];
            }
        }

        public static void SetUserRoles(int[] UserRoles, HttpSessionState session)
        {
            session["UserRoles"] = UserRoles;
        }

        public static void NullUserRoles(HttpSessionState session)
        {
            session["UserRoles"] = null;
        }

        public static int[] FetchUserRoles(HttpSessionState session)
        {
            if (session["UserRoles"] != null)
            {
                return session["UserRoles"] as int[];
            }
            else
            {
                return null;
            }
        }

        public static void SetReportStartDate(DateTime ReportStartDate, HttpSessionState session)
        {
            session["ReportStartDate"] = ReportStartDate;
        }

        public static DateTime FetchReportStartDate(HttpSessionState session)
        {
            if (session["ReportStartDate"] != null)
            {
                return DateTime.Parse(session["ReportStartDate"].ToString());
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static void SetReportEndDate(DateTime ReportEndDate, HttpSessionState session)
        {
            session["ReportEndDate"] = ReportEndDate;
        }

        public static DateTime FetchReportEndDate(HttpSessionState session)
        {
            if (session["ReportEndDate"] != null)
            {
                return DateTime.Parse(session["ReportEndDate"].ToString());
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static void SetReportTitle(String ReportTitle, HttpSessionState session)
        {
            session["ReportTitle"] = ReportTitle;
        }

        public static String FetchReportTitle(HttpSessionState session)
        {
            if (session["ReportTitle"] != null)
            {
                return session["ReportTitle"].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void SetReportSource(Object ReportSource, HttpSessionState session)
        {
            session["ReportSource"] = ReportSource;
        }

        public static Object FetchReportSource(HttpSessionState session)
        {
            if (session["ReportSource"] != null)
            {
                return session["ReportSource"].ToString();
            }
            else
            {
                return null;
            }
        }

        public static void SetReportExceptionUserId(int ReportExceptionUserId, HttpSessionState session)
        {
            session["ReportExceptionUserId"] = ReportExceptionUserId;
        }

        public static int FetchReportExceptionUserId(HttpSessionState session)
        {
            if (session["ReportExceptionUserId"] != null)
            {
                return int.Parse(session["ReportExceptionUserId"].ToString());
            }
            else
            {
                return 0;
            }
        }

    }
}
