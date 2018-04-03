using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;

namespace QuizBook.Views
{
    public partial class Settings : System.Web.UI.Page
    {
        QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
               try{

                   string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
                   var PermMgr = new PermissionManager(Session);

                   if (PermMgr.IsAdmin || PermMgr.CanManagePortal)
                   {

                  
                   if (!IsPostBack)
                   {
                       var settings = _db.T_Settings.AsQueryable();
                       foreach (var x in settings)
                       {
                           if (x.SettingsName == ErecruitHelper.Settings.CUT_OFF_MARK.ToString())
                           {
                               coffId.Value = x.Id.ToString();
                               Coff.Text = x.SettingsValue;
                           }
                           else if (x.SettingsName == ErecruitHelper.Settings.QUESTIONS_PER_TYPE.ToString())
                           {
                               qptId.Value = x.Id.ToString();
                               Qpt.Text = x.SettingsValue;
                           }
                       }
                   }
                   }
                   else
                   {
                       Response.Redirect("NoPermission.aspx", false);
                   }
               }
               catch (Exception ex)
               {
                   ErecruitHelper.SetErrorData(ex, Session);
                   Response.Redirect("ErrorPage.aspx",false);
               }
            
        }

        protected void CutOff_Click(object sender, EventArgs e)
        {
            try{
            var cid = coffId.Value;
            var newvalue = Coff.Text;
            if (!string.IsNullOrEmpty(cid))
            {
                long id = long.Parse(cid);
                var coff = _db.T_Settings.FirstOrDefault(s => s.Id == id);

                if (coff != null)
                {
                    coff.SettingsValue = newvalue;
                    coff.ModifiedBy = SessionHelper.FetchEmail(Session);
                    coff.DateModified = DateTime.Now;
                    _db.SaveChanges();
                }
            }

             }catch(Exception ex){
            ErecruitHelper.SetErrorData(ex, Session);
            Response.Redirect("ErrorPage.aspx",false);
    }
        }

        protected void Qptbtn_Click(object sender, EventArgs e)
        {
            try
            {
                var cid = qptId.Value;
                var newvalue = Qpt.Text;
                if (!string.IsNullOrEmpty(cid))
                {
                    long id = long.Parse(cid);
                    var coff = _db.T_Settings.FirstOrDefault(s => s.Id == id);

                    if (coff != null)
                    {
                        coff.SettingsValue = newvalue;
                        coff.ModifiedBy = SessionHelper.FetchEmail(Session);
                        coff.DateModified = DateTime.Now;
                        _db.SaveChanges();
                    }
                }


 }catch(Exception ex){
            ErecruitHelper.SetErrorData(ex, Session);
            Response.Redirect("ErrorPage.aspx",false);
    }
        }

       
    }
}