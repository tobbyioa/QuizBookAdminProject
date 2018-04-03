using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var tenantID = long.Parse(SessionHelper.GetTenantID(Session));
                    var roles = _db.Roles.AsEnumerable().Where(x =>x.Active && x.TenantId.HasValue && x.TenantId == tenantID ).ToList();

                    var rls = roles.OrderBy(s => s.Description).Select(a => new
                    {
                        Id = a.Id,
                        Name = a.Description

                    }).ToList();

                    rls.Insert(0, new { Id = long.Parse("-1"), Name = "--Select Role--" });

                    rl.DataSource = rls;

                    rl.DataBind();

                    roleModel obj = new roleModel();
                    var rs = new List<roleModel>();
                    var rCount = 0;
                    foreach (var a in roles)
                    {
                        obj = new roleModel();
                        obj.ID = a.Id;
                        obj.Role = a.Description;
                        obj.CreatedBy = string.IsNullOrEmpty(a.CreatedBy) ? "" : a.CreatedBy;
                        obj.DateCreated = a.DateCreated.HasValue ? a.DateCreated.Value.ToString("dd-MM-yyyy") : "";
                        obj.ModifiedBy = string.IsNullOrEmpty(a.ModifiedBy) ? "" : a.ModifiedBy;
                        obj.DateModified = a.DateModified.HasValue ? a.DateModified.Value.ToString("dd-MM-yyyy") : "";
                        rs.Add(obj);
                        rCount++;
                    }


                    TotalRecCount.Text = rCount+ " Role(s)";

                    RoleList.DataSource = rs;
                    RoleList.DataBind();
                }
            }
        }


    }
     public class roleModel
    {
        public long ID { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public string DateModified { get; set; }
    }

}