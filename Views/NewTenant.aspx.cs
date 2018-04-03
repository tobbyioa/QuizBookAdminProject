using QuizBook.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizBook.Views
{
    public partial class NewTenant : System.Web.UI.Page
    {
        string keySalt = "QuizBook";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void regBtn_Click(object sender, EventArgs e)
        {
           // QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            var page = Page.IsValid;
            if (page)
            {

                var fn = firstname.Text;
                var ln = lname.Text;
                var address = Address.Text;
                var emailvar = email.Text;
                var sx = sex.SelectedItem.Value;
                var dateOb = dob.Text;
                var un = username.Text;
                var pw = password.Text;
                var cpw = cPass.Text;
                if (pw.Trim() == cpw.Trim())
                {
                    HttpPostedFile file = tLogo.PostedFile;

                    if (file != null && file.ContentLength > 0)
                    {

                        string fname = Path.GetFileName(file.FileName);
                        string ext = System.IO.Path.GetExtension(file.FileName);
                        string fileID = Guid.NewGuid().ToString();
                        string path = "";
                        if (shortName.Text.Length >= 6)
                        {
                            var tenant = new Tenant
                            {
                                TenantName = name.Text,
                                TenantCode = string.IsNullOrEmpty(shortName.Text) ? name.Text.Substring(0, 6) : shortName.Text,
                                Address = Address.Text,
                                State = Request[state.UniqueID].ToString(),
                                Country = Request[country.UniqueID].ToString(),
                                TenantStatus = true,
                                DateCreated = DateTime.Now,
                                CreatedBy = "QuizBook",
                                TenantLimit = 0,
                                Image = Path.Combine("~/TenantLogo/", fileID + ext)
                            };


                            using (QuizBookDbEntities1 _db = new QuizBookDbEntities1())
                            {
                                _db.Tenants.Add(tenant);
                                _db.SaveChanges();
                                var rl = _db.Roles.FirstOrDefault(s => s.Description == "Admin");

                                _db.AdminUsers.Add(new AdminUser
                                {
                                    FirstName = fn,
                                    LastName = ln,
                                    Username = un,
                                    Sex = sx,
                                    DOB = ErecruitHelper.GetCurrentDateFromDateString(dateOb),
                                    Address = Address.Text,
                                    State = Request[state.UniqueID].ToString(),
                                    Country = Request[country.UniqueID].ToString(),
                                    Location = Request[Location.UniqueID].ToString(),
                                    TenantId = tenant.Id,
                                    Email = emailvar,
                                    Role = rl.Id,
                                    Status = ErecruitHelper.CStatus.Active.ToString(),
                                    DateCreated = DateTime.Now,
                                    CreatedBy = "QuizBook",
                                    Captcha = Page.IsValid,
                                    DefaultLoginKeyChanged = true,
                                    LogInKey = ErecruitHelper.getHash(pw, keySalt),
                                    IpAddress = ErecruitHelper.GetIP(HttpContext.Current)
                                });
                                _db.SaveChanges();
                            }



                            // var all =  new List<string[]>();
                            if (Directory.Exists(Server.MapPath("~/TenantLogo/")))
                            {
                                path = Server.MapPath(Path.Combine("~/TenantLogo/", fileID + ext));
                                // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                                file.SaveAs(path);
                            }
                            else
                            {
                                Directory.CreateDirectory(Server.MapPath("~/TenantLogo/"));
                                path = Server.MapPath(Path.Combine("~/TenantLogo/", fileID + ext));
                                // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                                file.SaveAs(path);
                            }
                            var data = File.ReadAllBytes(path);
                            SessionHelper.SetInfoValue("Your Profile has been successfully saved. Kindly <a href='Welcome.aspx'>click here</a> to proceed.", Session);
                            Response.Redirect("Info.aspx", false);
                        }else
                        {
                            lblAlert.Text = "Short Name should be at least 6 characters";
                        }
                    }
                }
                else
                {
                    lblAlert.Text = "Administrator's Password did not match";
                }
            }
            else
            {
                lblAlert.Text = "Kindly fill the recaptcha";
            }
        }
    }
}