using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using QuizBook.Model;

namespace QuizBook.Views
{
    public partial class UploadQuestionImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPageFileName = new FileInfo(this.Request.Url.AbsolutePath).Name;
            var PermMgr = new PermissionManager(Session);

            if (PermMgr.IsAdmin || PermMgr.CanManageQuestion)
            {


                if (!IsPostBack)
                {
                   
                    
                    if (Directory.Exists(Server.MapPath("~/QuestionImages/")))
                    {
                        var files = from file in Directory.GetFiles(Server.MapPath("~/QuestionImages/"))
                                    orderby file descending
                                    select file;
                        var quests = files.Select(a => new ImageGridModel
                        {
                            ImageName = Path.GetFileNameWithoutExtension(a),
                            FileName = Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                            Path = Path.Combine("~/QuestionImages/" , Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a)),
                            Usage = "../QuestionImages/" + Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                            Delete = "Delete"
                        }).Distinct().ToList();
                        IMGIndex.Text = quests.Count() + " Image(s)";
                        GridView1.DataSource = quests;
                        GridView1.DataBind();
                        
                    }
                    else
                    {
                        Directory.CreateDirectory(Server.MapPath("~/QuestionImages/"));
                        var files = from file in Directory.GetFiles(Server.MapPath("~/QuestionImages/"))
                                    orderby file descending
                                    select file;
                        var quests = files.Select(a => new ImageGridModel
                        {
                            ImageName = Path.GetFileName(a),
                            FileName = Path.GetFileName(a) + System.IO.Path.GetExtension(a),
                            Path = Path.Combine("~/QuestionImages/", Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a)),
                            Usage = "../QuestionImages/" + Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                            Delete = "Delete"
                        }).Distinct().ToList();
                        IMGIndex.Text = quests.Count() + " Image(s)";
                        GridView1.DataSource = quests;
                        GridView1.DataBind();

                    }
                  
                }

            }
        }

        protected void UploadQImage_Click(object sender, EventArgs e)
        {
            var imgname = ImageName.Text;
            HttpPostedFile file = QImage.PostedFile;

            if (!string.IsNullOrEmpty(imgname))
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string fname = Path.GetFileName(file.FileName);
                        string ext = System.IO.Path.GetExtension(file.FileName);
                        var PPath = "";
                        if (Directory.Exists(Server.MapPath("~/QuestionImages/")))
                        {
                            string path = Server.MapPath(Path.Combine("~/QuestionImages/", imgname + ext));
                            PPath = Path.Combine("~/QuestionImages/", imgname + ext);
                            file.SaveAs(path);
                        }
                        else
                        {
                            Directory.CreateDirectory(Server.MapPath("~/QuestionImages/"));
                            string path = Server.MapPath(Path.Combine("~/QuestionImages/", imgname + ext));
                            PPath = Path.Combine("~/QuestionImages/", imgname + ext);
                            file.SaveAs(path);
                        }

                    }
                }
            Response.Redirect("UploadQuestionImage.aspx", false);
        }

        protected void SearchQuest_Click(object sender, EventArgs e)
        {
            var txt = searchText.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                if (Directory.Exists(Server.MapPath("~/QuestionImages/")))
                {

                    var files = from file in Directory.GetFiles(Server.MapPath("~/QuestionImages/"))
                                where file.Contains(txt)
                                orderby file descending
                                select file;
                    var quests = files.Select(a => new ImageGridModel
                    {
                        ImageName = Path.GetFileNameWithoutExtension(a),
                        FileName = Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                        Path = Path.Combine("~/QuestionImages/", Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a)),
                        Usage = "../QuestionImages/" + Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                        Delete = "Delete"
                    }).Distinct().ToList();
                    IMGIndex.Text = quests.Count() + " Image(s)";
                    GridView1.DataSource = quests;
                    GridView1.DataBind();

                }
            }
            else
            {
                var files = from file in Directory.GetFiles(Server.MapPath("~/QuestionImages/"))
                            orderby file descending
                            select file;
                var quests = files.Select(a => new ImageGridModel
                {
                    ImageName = Path.GetFileNameWithoutExtension(a),
                    FileName = Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                    Path = Path.Combine("~/QuestionImages/", Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a)),
                    Usage = "../QuestionImages/" + Path.GetFileNameWithoutExtension(a) + System.IO.Path.GetExtension(a),
                    Delete = "Delete"
                }).Distinct().ToList();
                IMGIndex.Text = quests.Count() + " Image(s)";
                GridView1.DataSource = quests;
                GridView1.DataBind();
            }
        }

        protected void lnkedIMG_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkedit = ((LinkButton)sender);
                var p = lnkedit.Parent;
                HiddenField hdfID = (HiddenField)p.FindControl("hdfIMG");
                var idcr = (hdfID.Value);
                if (!(string.IsNullOrEmpty(idcr)))
                {
                    string path = Server.MapPath(Path.Combine("~/QuestionImages/", idcr));
                    File.Delete(path);
                }
                Response.Redirect("UploadQuestionImage.aspx", false);
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }
    }
}