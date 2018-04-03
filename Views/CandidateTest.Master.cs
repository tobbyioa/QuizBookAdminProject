using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using System.Web.Services;

namespace QuizBook.Views
{
    public partial class CandidateTest1 : System.Web.UI.MasterPage
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddKeepAlive();
            try
            {
                if (!IsPostBack)
                {
                    //var candId = SessionHelper.FetchCandidateId(Session);
                    //var tracker = _db.T_CTestTracker.FirstOrDefault(s => s.CandidateId == long.Parse(candId));
                    //var cand = _db.T_Candidate.FirstOrDefault(s => s.Code == tracker.CandidateCode);
                    //var b_id = _db.T_BatchSet.Where(s => s.CandidateId == cand.Id).Select(x => x.BatchId);
                    //var candBatch = _db.T_Batch.FirstOrDefault(s => b_id.Contains(s.Id) && s.IsActive.Value);
                    //string path = Path.Combine("~/Passports/", "no-pic-avatar.jpg");
                    //Image1.ImageUrl = !(string.IsNullOrEmpty(cand.Passport)) ? cand.Passport : path;
                    //string st = cand.Code + " - " + cand.FirstName + " " + cand.LastName;
                    //CandName.Text = st;
                    //dur.Value = candBatch.Duration.ToString();
                    //if (tracker.InitialStartTime.Value == null)
                    //{
                    //    Response.Redirect("CandidateLogin.aspx", false);
                    //}
                    //else
                    //{

                    //    DateTime lastActiveTime = tracker.CurrentStartTime == null ? DateTime.Now : tracker.CurrentStartTime.Value;

                    //    TimeSpan span = (lastActiveTime - tracker.InitialStartTime.Value);


                    //    var duration = candBatch.Duration.ToString();
                    //    string[] ds = duration.Split(':');
                    //    int min = 0;
                    //    int sec = 0;
                    //    int hour = 0;
                    //    int TestdurationSum = 0;
                    //    if (ds.Length == 1)
                    //    {
                    //        min = int.Parse(ds[0]);
                    //        sec = 0;
                    //        hour = 0;
                    //        TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                    //    }
                    //    else if (ds.Length == 2)
                    //    {
                    //        min = int.Parse(ds[0]);
                    //        sec = int.Parse(ds[1]);
                    //        hour = 0;
                    //        TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                    //    }
                    //    else
                    //    {
                    //        min = int.Parse(ds[1]);
                    //        sec = int.Parse(ds[2]);
                    //        hour = int.Parse(ds[0]);
                    //        TestdurationSum = ((hour * 3600) + (min * 60) + sec);
                    //    }


                    //    var timeEnding = DateTime.Now;
                    //    var ending = timeEnding.AddSeconds(TestdurationSum);

                    //    var sumSpent = ((span.Hours * 3600) + (span.Minutes * 60) + span.Seconds);

                    //    TimeSpan spentTime = new TimeSpan(span.Hours, span.Minutes, span.Seconds);

                    //    ending = ending.Subtract(spentTime);

                    //    TimeSpan remaining = (ending - timeEnding);

                    //    var timeString = String.Format("{0}:{1}:{2}", ErecruitHelper.AppendZero(remaining.Hours), ErecruitHelper.AppendZero(remaining.Minutes), ErecruitHelper.AppendZero(remaining.Seconds));


                    //    minutes.Value = timeString;
                    //    // minutes.Value = tracker.EndTime.Value.ToString("M/d/yyyy hh:mm:ss tt");

                    //    candid.Value = cand.Id.ToString();
                    //    batchid.Value = candBatch.Id.ToString();
                    //}
                }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("CandidateErrorPage.aspx", false);
            }
        }

        private void AddKeepAlive()
        {
            int int_MilliSecondsTimeOut = (this.Session.Timeout * 60000) - 30000;
            string str_Script = @"
<script type='text/javascript'>
//Number of Reconnects
var count=0;
//Maximum reconnects setting
var max = 5;
function Reconnect(){

count++;
if (count < max)
{
window.status = 'Link to Server Refreshed ' + count.toString()+' time(s)' ;

var img = new Image(1,1);

img.src = 'Reconnect.aspx';

}
}

window.setInterval('Reconnect()'," + int_MilliSecondsTimeOut.ToString() + @"); //Set to length required

</script>

";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Reconnect", str_Script);

        }

        [WebMethod(EnableSession = true)]
        public static string logout()
        {
            var v = HttpContext.Current.Session;
            v.Abandon();
            return "You are leaving this page";
        }
    }
}