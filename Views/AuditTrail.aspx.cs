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
    public partial class AuditTrail : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManagePortal)
            {
                if (!IsPostBack)
                {
                    var auditLogs = _db.AuditRecords.OrderByDescending(s => s.AuditDate).ToList();
                    TotalRecCount.Text = auditLogs.Count() + " Log(s)";
                    AudiTrailGrid.DataSource = auditLogs;
                    AudiTrailGrid.DataBind();
                    ViewActive.Value = "";
                    ViewActiveTitle.Value = "";
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
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void AudiTrailGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try{
                var auditLogs = _db.AuditRecords.OrderByDescending(s => s.AuditDate).ToList();
            TotalRecCount.Text = auditLogs.Count() + " Log(s)";
            AudiTrailGrid.DataSource = auditLogs;
            AudiTrailGrid.PageIndex = e.NewPageIndex;
            AudiTrailGrid.DataBind();
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void AudiTrailGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            try{
                var auditLogs = _db.AuditRecords.OrderByDescending(s => s.AuditDate).ToList();
            TotalRecCount.Text = auditLogs.Count() + " Log(s)";
            
            if ((string)Session["EXP"] == e.SortExpression && (string)Session["DIRECTION"] == SortDirection.Ascending.ToString())
            {
                e.SortDirection = SortDirection.Descending;
            }
            else
            {
                e.SortDirection = SortDirection.Ascending;
            }

            Session["EXP"] = e.SortExpression;
            Session["DIRECTION"] = e.SortDirection.ToString();
            switch (e.SortExpression)
            {
                case "UserName":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        auditLogs = auditLogs.OrderBy(s => s.UserName).ToList();

                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }
                    else
                    {
                        auditLogs = auditLogs.OrderByDescending(s => s.UserName).ToList();
                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }

                    break;
                case "Action":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        auditLogs = auditLogs.OrderBy(s => s.Action).ToList();

                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }
                    else
                    {
                        auditLogs = auditLogs.OrderByDescending(s => s.Action).ToList();
                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }

                    break;
                case "TableName":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        auditLogs = auditLogs.OrderBy(s => s.TableName).ToList();

                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }
                    else
                    {
                        auditLogs = auditLogs.OrderByDescending(s => s.TableName).ToList();
                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }

                    break;
                //case "MemberName":
                //    if (e.SortDirection == SortDirection.Ascending)
                //    {
                //        auditLogs = auditLogs.OrderBy(s => s.MemberName).ToList();

                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }
                //    else
                //    {
                //        auditLogs = auditLogs.OrderByDescending(s => s.MemberName).ToList();
                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }

                //    break;
                //case "OldValue":
                //    if (e.SortDirection == SortDirection.Ascending)
                //    {
                //        auditLogs = auditLogs.OrderBy(s => s.OldValue).ToList();

                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }
                //    else
                //    {
                //        auditLogs = auditLogs.OrderByDescending(s => s.OldValue).ToList();
                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }

                //    break;
                //case "NewValue":
                //    if (e.SortDirection == SortDirection.Ascending)
                //    {
                //        auditLogs = auditLogs.OrderBy(s => s.NewValue).ToList();

                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }
                //    else
                //    {
                //        auditLogs = auditLogs.OrderByDescending(s => s.NewValue).ToList();
                //        AudiTrailGrid.DataSource = auditLogs;
                //        AudiTrailGrid.DataBind();
                //    }

                //    break;
                case "AuditDate":
                    if (e.SortDirection == SortDirection.Ascending)
                    {
                        auditLogs = auditLogs.OrderBy(s => s.AuditDate).ToList();

                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }
                    else
                    {
                        auditLogs = auditLogs.OrderByDescending(s => s.AuditDate).ToList();
                        AudiTrailGrid.DataSource = auditLogs;
                        AudiTrailGrid.DataBind();
                    }

                    break;
            }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void SearchAuditTrail_Click(object sender, EventArgs e)
        {
            try{
            var user = username.Text;
            var action = Action.Text;
            var c = cond.Value;
            var table = tablename.Text;
           // var col = column.Text;
            var dateLogged = AuditDate.Text;

            IQueryable<AuditRecord> logs;

            if (!string.IsNullOrEmpty(user))
            {
                logs = _db.AuditRecords.Where(s => (s.UserName.Contains(user)));
            }
            else
            {
                logs = _db.AuditRecords.AsQueryable();
            }

            if (!string.IsNullOrEmpty(table))
            {
                logs = logs.Where(s => s.TableName.Contains(table)).AsQueryable();
            }
            if (!string.IsNullOrEmpty(action))
            {
                logs = logs.Where(s => s.Action.Contains(action)).AsQueryable();
            }
            //if (!string.IsNullOrEmpty(col) )
            //{
            //    logs = logs.Where(s => s.MemberName.Contains(col)).AsQueryable();
            //}
            if (!string.IsNullOrEmpty(dateLogged))
            {
                var logdate = ErecruitHelper.GetCurrentDateFromDateStringWithHM(dateLogged);
                if ((logdate)!=null)
                {
                    if (c == "=")
                    {
                        logs = logs.Where(s => s.AuditDate == (logdate)).AsQueryable();
                    }
                    else if (c == "<")
                    {
                        logs = logs.Where(s => s.AuditDate < (logdate)).AsQueryable();
                    }
                    else if (c == ">")
                    {
                        logs = logs.Where(s => s.AuditDate > (logdate)).AsQueryable();
                    }

                }
            }
            TotalRecCount.Text = logs.Count() + " Log(s)";
            AudiTrailGrid.DataSource = logs;
            AudiTrailGrid.DataBind();
             }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ViewActive.Value = "1";
        }

        protected void lnkeditDetail_Click(object sender, EventArgs e)
        {
             try{
                
            LinkButton lnkedit = ((LinkButton)sender);
            var p = lnkedit.Parent;
            HiddenField hdfID = (HiddenField)p.FindControl("hdfIDDetail");
            var idcr = long.Parse(hdfID.Value);
            if (!(idcr == null))
            {
                var theRec = _db.AuditRecords.FirstOrDefault(s => s.Id == idcr);
                var details = _db.AuditRecordFields.Where(s=>s.AuditRecordId == idcr).ToList();
                DetailGrid.DataSource = details;
                DetailGrid.DataBind();
                ViewActiveTitle.Value = theRec.Action + " action on "+theRec.TableName;
                ViewActive.Value = idcr.ToString();
            }
             }
             catch (Exception ex)
             {
                 ErecruitHelper.SetErrorData(ex, Session);
                 Response.Redirect("ErrorPage.aspx", false);
             }
        }
    }
}