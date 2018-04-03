using QuizBook.Helpers;
using QuizBook.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class Admins : System.Web.UI.Page
    {

        string keySalt = "QuizBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userId = SessionHelper.FetchUserId(Session);

                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var user = _db.AdminUsers.FirstOrDefault(s => s.Id == userId);
                    if (user != null)
                    {
                        var tenantID = long.Parse(SessionHelper.GetTenantID(Session));
                        var rl = _db.Roles.FirstOrDefault(s => s.Description == "Admin");
                        var roles = _db.Roles.AsEnumerable().Where(x => x.Active && x.TenantId.HasValue && x.TenantId == tenantID);
                        if(user.Role.HasValue && user.Role.Value != rl.Id)
                        {
                            roles = roles.Where(x => x.Id == user.Role.Value || x.CreatedBy == user.Id.ToString());
                        }
                        var rls = roles.OrderBy(s =>s.Description).Select(a => new
                        {
                            Id = a.Id,
                            Name = a.Description

                        }).ToList();


                       
                        int count = rls.Count();
                        rls.Insert(0, new { Id = long.Parse("-1"), Name = "--Roles--" });
                        var memSelRole = Session["NewSelRole"];
                        var longmemSelRole = memSelRole == null ? "-1" : memSelRole.ToString();
                        RoleList.DataSource = rls;
                        RoleList.SelectedValue = longmemSelRole;
                        RoleList.DataBind();
                        EnableRegBtn(count);
                        
                        var admins = new List<AdminUser>();
                        //&& x.Role.HasValue && (x.Role == user.Role || x.Role == rl.Id)
                        if (user.Role.HasValue && user.Role == rl.Id && (user.Supervisor??false))
                        {
                            admins = _db.AdminUsers.AsEnumerable().Where(x => x.TenantId.HasValue && x.TenantId == tenantID ).ToList();
                        }
                        else if((user.Supervisor ?? false))
                        {
                            admins = _db.AdminUsers.AsEnumerable().Where(x => x.TenantId.HasValue && x.TenantId == tenantID && x.Role.HasValue && x.Role.Value == user.Role.Value  && (user.Supervisor??false) || x.Role1.CreatedBy == user.Id.ToString()).ToList();
                        }
                        
                        AdminGridModel objm = new AdminGridModel();
                        var adm = new List<AdminGridModel>();
                        var rCount = 0;
                        foreach (var a in admins)
                        {
                            objm = new AdminGridModel();
                            objm.adminId = a.Id;
                            objm.username = a.Username;
                            objm.firstname = a.FirstName;
                            objm.lastname = a.LastName;
                            objm.email = a.Email;
                            objm.role = a.Role.HasValue?a.Role1.Description:"-";
                            objm.supervisor = a.Supervisor.HasValue ?a.Supervisor.Value?"Yes":"No": "No";
                            objm.edittxt = a.Id == user.Id ? "" :"Edit";
                            //if (a.Id == user.Id)
                            //{
                            //    objm.ends = string.Empty;
                            //}
                            //else
                            //{
                            //    if (a.Supervisor.HasValue)
                            //    {
                            //        if (a.Supervisor.Value)
                            //        {
                            //            if (a.Status.Trim() != "Active".Trim())
                            //            {
                            //                objm.ends = "Enable";
                            //            }
                            //            else
                            //            {
                            //                objm.ends = "Disable";
                            //            }
                            //        }
                            //        else
                            //        {
                            //            objm.ends = string.Empty;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        objm.ends = string.Empty;
                            //    }
                            //}
                            objm.ends = a.Id == user.Id ? string.Empty: (user.Supervisor??false)? a.Status.Trim()!="Active"?"Enable":"Disable":string.Empty;

                            adm.Add(objm);
                            rCount++;
                        }
                        TotalRecCount.Text = rCount + " Administrator(s)";
                        GridView1.DataSource = adm;
                        GridView1.DataBind();
                        if (!string.IsNullOrEmpty(user.Location))
                        {
                            country.Attributes.Add("data-default-value", user.Location);
                        }
                        else
                        {
                            country.Attributes.Add("data-default-value", "Nigeria");
                        }
                    }
                }
            
                }
            

        }

        [WebMethod(EnableSession = true)]
        public static string NewRole(string id)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
            var userId = SessionHelper.FetchUserId(HttpContext.Current.Session);
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                //var user = _db.AdminUsers.FirstOrDefault(x => x.Id == userId);
                var adminperms = ConfigurationManager.AppSettings["AdminPerm"];
                if (adminperms != null)
                {
                    var perms = adminperms.ToString().Split(',');
                    var qg = _db.Roles.FirstOrDefault(s => s.TenantId == tenantId && s.Description.ToLower().Trim() == id.ToLower().Trim());
                    if (qg == null)
                    {
                        var newRole = new Role
                        {
                            TenantId = tenantId,
                            Description = id.Trim().ToUpper(),
                            DateCreated = DateTime.Now,
                            Active = true,
                            CreatedBy = userId.ToString()
                        };
                        _db.Roles.Add(newRole);
                        
                        _db.SaveChanges();
                        var ps = perms.Select(x => new RolePermission
                        {
                            RoleId = newRole.Id,
                            PermId = long.Parse(x),
                            DateAdded = DateTime.Now,
                            AddedBy = userId.ToString()
                        });
                        foreach(var p in ps)
                        {
                            _db.RolePermissions.Add(p);
                        }
                        _db.SaveChanges();                        
                        HttpContext.Current.Session["NewSelRole"] = newRole.Id;

                        return "success";
                    }
                    else
                    {
                        qg.Active = true;
                        qg.ModifiedBy = userId.ToString();
                        qg.DateModified = DateTime.Now;
                        _db.SaveChanges();
                        HttpContext.Current.Session["NewSelRole"] = qg.Id;
                        return "success";
                        //return "exist";
                    }
                }
                else
                {
                    return "Roles Permission Config not found.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public static string DisableRole(string id)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
            var userId = SessionHelper.FetchUserId(HttpContext.Current.Session);
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            try
            {
                var rId = long.Parse(id);
                //var user = _db.AdminUsers.FirstOrDefault(x => x.Id == userId);
                var qg = _db.Roles.FirstOrDefault(s => s.TenantId == tenantId && s.Id == rId);
                if (qg != null)
                {
                    qg.Active = false;
                    qg.ModifiedBy = userId.ToString();
                    qg.DateModified = DateTime.Now;
                    _db.SaveChanges();
                    HttpContext.Current.Session["NewSelRole"] = null;
                    return "success";
                }
                else
                {
                    return "exist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void EnableRegBtn(int count)
        {
            if (count > 0)
            {
                    //var adminperms = ConfigurationManager.AppSettings["AdminPerm"];               
                    //var perms = adminperms.ToString().Split(',');

                    saveRole.Enabled = true;
            }
            else
            {
                saveRole.Enabled = false;
            }

        }

        protected void saveRole_Click(object sender, EventArgs e)
        {
            var tenantID = long.Parse(SessionHelper.GetTenantID(Session));
            var userId = SessionHelper.FetchUserId(Session);
            var fn = firstname.Text;
            var ln = lname.Text;
            var role = RoleList.SelectedValue;
            var emailvar = email.Text;
            var sx = sex.SelectedItem.Value;
            var dateOb = dob.Text;
            var un = username.Text;
            var address = Address.Text;
            var super = supervisor.Checked;
            var adId = adminId.Value;
            //var cpw = cPass.Text;

            if (string.IsNullOrEmpty(role) || role == "-1")
            {
                messageBox.Text = "Kindly Select a Role.";
            }
            else
            {
                using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                {
                    var pw = Guid.NewGuid().ToString();
                    var phrase = pw.Split('-')[0];

                    if (string.IsNullOrEmpty(adId))
                    {
                        var newAdmin = new AdminUser
                        {
                            FirstName = fn,
                            LastName = ln,
                            Username = un,
                            Sex = sx,
                            DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb),
                            Address = address,
                            State = Request[state.UniqueID].ToString(),
                            Country = Request[country.UniqueID].ToString(),
                            Location = Request[Location.UniqueID].ToString(),
                            TenantId = tenantID,
                            Email = emailvar,
                            Supervisor = super,
                            Role = long.Parse(role),
                            Status = ErecruitHelper.CStatus.Active.ToString(),
                            DateCreated = DateTime.Now,
                            CreatedBy = userId.ToString(),
                            Captcha = Page.IsValid,
                            DefaultLoginKeyChanged = true,
                            LogInKey = ErecruitHelper.getHash(phrase.Trim(), keySalt.Trim()),
                            IpAddress = ErecruitHelper.GetIP(HttpContext.Current)
                        };
                        _db.AdminUsers.Add(newAdmin);
                        _db.SaveChanges();
                        ErecruitHelper.sendProfile(newAdmin, "", phrase);
                    }
                    else
                    {
                        long idcr = long.Parse(adId);
                        var admin = _db.AdminUsers.FirstOrDefault(x => x.Id == idcr);
                        if (admin != null)
                        {
                          admin.FirstName = fn;
                          admin.LastName = ln;
                          admin.Username = un;
                          admin.Sex = sx;
                          admin.DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb);
                          admin.Address = address;
                          admin.State = Request[state.UniqueID].ToString();
                          admin.Country = Request[country.UniqueID].ToString();
                          admin.Location = Request[Location.UniqueID].ToString();
                          admin.TenantId = tenantID;
                          admin.Email = emailvar;
                          admin.Supervisor = super;
                          admin.Role = long.Parse(role);
                            admin.DateModified = DateTime.Now;
                          admin.Status = ErecruitHelper.CStatus.Active.ToString();
                            admin.IpAddress = ErecruitHelper.GetIP(HttpContext.Current);
                          _db.SaveChanges();
                           messageBox.Text = "Changes Saved";
                        }
                    }
                   
                    Response.Redirect("Admins.aspx", false);
                }
            }

        }

        protected void lnkeditC_Click(object sender, EventArgs e)
        {
            LinkButton lnkeditC = ((LinkButton)sender);
            var p = lnkeditC.Parent;
            HiddenField hdfIDC = (HiddenField)p.FindControl("hdfIDC");
            var idcr = long.Parse(hdfIDC.Value);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var admin = _db.AdminUsers.FirstOrDefault(x => x.Id == idcr);
                if (admin != null)
                {
                    adminId.Value = admin.Id.ToString();
                    firstname.Text = admin.FirstName;
                    lname.Text = admin.LastName;
                    dob.Text = admin.DOB == null ? string.Empty : admin.DOB.Value.ToString("dd/MM/yyyy");
                    Address.Text = admin.Address;
                    username.Text = admin.Username;
                    email.Text = admin.Email;
                    sex.SelectedValue = admin.Sex;
                    RoleList.SelectedValue = admin.Role.HasValue ? admin.Role.Value.ToString() : "-1";
                    supervisor.Checked = admin.Supervisor.HasValue ? admin.Supervisor.Value : false;
                    country.Attributes.Add("data-default-value", admin.Country);
                    state.Attributes.Add("data-default-value", admin.State);
                }
            }
        }
        protected void lnkeditD_Click(object sender, EventArgs e)
        {
            LinkButton lnkeditD = ((LinkButton)sender);
            var p = lnkeditD.Parent;
            HiddenField hdfIDD = (HiddenField)p.FindControl("hdfIDD");
            var idcr = long.Parse(hdfIDD.Value);
            var userId = SessionHelper.FetchUserId(Session);
            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
            {
                var admin = _db.AdminUsers.FirstOrDefault(x => x.Id == idcr);
                admin.Status = string.IsNullOrEmpty(admin.Status)?"Inactive":admin.Status.Trim() == "Active"?"Inactive": "Active";
                admin.DateModified = DateTime.Now;
                _db.SaveChanges();
            }
            Response.Redirect("Admins.aspx", false);
        }
        
    }
}