using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using QuizBook.Helpers;
using System.IO;

namespace QuizBook.Views
{
    public partial class Question : System.Web.UI.Page
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManageQuestion)
            {

            if (!IsPostBack)
            {
                string alink = Request["z"];
                if (!string.IsNullOrEmpty(alink))
                {
                    var curBC = _db.T_Question.FirstOrDefault(s => s.Id == long.Parse(alink));
                    HiddenField1.Value = curBC.Id.ToString();
                    TextBox1.Text = curBC.Details;
                    DropDownList1.SelectedValue = curBC.TypeId.Value.ToString();
                    DropDownList2.SelectedValue = curBC.OptionType.Value.ToString();
                    Button1.Visible = false;
                    Button3.Visible = true;
                }

                //Populates the Question Type DropDownList
                var typ = _db.T_QuestionType.Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name
                }).Distinct().ToList();
                DropDownList1.DataSource = typ;
                DropDownList1.DataBind();

                //Populates the Question Option Type DropDownList
                var QQtyp = _db.T_QOptionType.Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name
                }).Distinct().ToList();
                DropDownList2.DataSource = QQtyp;
                DropDownList2.DataBind();
            }
            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }
            }

       
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            T_Question q = new T_Question
            {
                TypeId = long.Parse(DropDownList1.SelectedValue),
                OptionType = long.Parse(DropDownList2.SelectedValue),
                IsActive = true,
                Details = TextBox1.Text   
            };
            _db.T_Question.Add(q);
            _db.SaveChanges();
            Response.Redirect("QuestionsList.aspx",false);

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuestionsList.aspx",false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var id = HiddenField1.Value;
            if (!(id == null))
            {
                var Id = long.Parse(id);
                var cur = _db.T_Question.FirstOrDefault(s => s.Id == Id);
                cur.TypeId = long.Parse(DropDownList1.SelectedValue);
                cur.OptionType = long.Parse(DropDownList2.SelectedValue);
                cur.Details = TextBox1.Text;
                //cur.Details = TextBox1.Text;
               _db.SaveChanges();     
                Response.Redirect("QuestionsList.aspx",false);
            }
        }
    }
}