using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuizBook.Helpers;
using System.IO;
using System.Data;
using System.Data.OleDb;
using SimpleExcelImport;
using System.Data;
using QuizBook.Model;


namespace QuizBook.Views
{
    public partial class QuestionUpload : System.Web.UI.Page
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
                    //Populates the Question Type DropDownList
                    var typ = _db.T_QuestionType.Where(x => x.Status == true).Select(a => new
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).Distinct().OrderBy(s => s.Name).ToList();
                    DropDownList1.DataSource = typ;
                    DropDownList1.DataBind();
                }
            }
            else
            {
                Response.Redirect("NoPermission.aspx", false);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedQtype = long.Parse(DropDownList1.SelectedValue);
                //if (selectedQtype == 1 || selectedQtype == 3 || selectedQtype == 4)
                //{
                //    PreambleName.Text = "";
                //    preambleText.Text = "";
                //    PreamblePreview.Text = "";
                //    PreambleNamePreview.Text = "";

                //    preview.Visible = false;
                //    preambleNameRow.Visible = false;
                //    preambleRow.Visible = false;

                //    //Populates the preambles DropDownList
                //    var p = _db.T_Question.Where(s => s.TypeId == selectedQtype).Select(s => s.PreambleId).Distinct();
                //    var preamblesList = _db.T_QuestionPreamble.Where(s => p.Contains(s.Id));
                //    var preamb = preamblesList.Select(a => new
                //    {
                //        Id = a.Id,
                //        Name = a.Name
                //    }).Distinct().ToList();
                //    preamb.Insert(0, new
                //    {
                //        Id = long.Parse("-1"),
                //        Name = "Select..."
                //    });
                //    preamb.Insert(1, new
                //    {
                //        Id = long.Parse("0"),
                //        Name = "New Question Preamble"
                //    });
                //    preambleLists.DataSource = preamb;
                //    preambleLists.DataBind();

                //    preambles.Visible = true;
                //}
                //else
                //{
                //    preambles.Visible = false;

                //    preambleLists.SelectedIndex = 0;

                //    PreambleName.Text = "";
                //    preambleText.Text = "";
                //    PreamblePreview.Text = "";
                //    PreambleNamePreview.Text = "";

                //    preview.Visible = false;
                //    preambleNameRow.Visible = false;
                //    preambleRow.Visible = false;

                //}
                //Populates the Question Type DropDownList
                var typ = _db.T_QuestionType.Select(a => new
                {
                    Id = a.Id,
                    Name = a.Name
                }).Distinct().ToList();
                DropDownList1.SelectedValue = selectedQtype.ToString();
                DropDownList1.DataSource = typ;
                DropDownList1.DataBind();
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        //protected void preambleLists_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var selectedQtype = long.Parse(DropDownList1.SelectedValue);
        //        var QType = _db.T_Question.Select(s => s.PreambleId).Distinct();
        //        var Qt = _db.T_QuestionTypes.FirstOrDefault(s => s.Id == selectedQtype);
        //        var QTypeCount = QType.Count();
        //        var QTC = QTypeCount++;
        //        var selectedpreamble = long.Parse(preambleLists.SelectedValue);
        //        if (selectedpreamble == 0)
        //        {
        //            PreambleName.Text = Qt.Name + " " + QTC;
        //            preambleText.Text = "";
        //            PreamblePreview.Text = "";

        //            preview.Visible = false;
        //            preambleRow.Visible = true;
        //            preambleNameRow.Visible = true;
        //        }
        //        else if (selectedpreamble != -1 && selectedpreamble != 0)
        //        {
        //            var id = QPid.Value;

        //            if (!(string.IsNullOrEmpty(id)))
        //            {
        //                var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == selectedpreamble);


        //                PreamblePreview.Text = "";
        //                PreambleNamePreview.Text = "";
        //                preview.Visible = false;
        //                QPid.Value = preamble.Id.ToString();
        //                PreambleName.Text = preamble.Name;
        //                preambleText.Text = preamble.Body;

        //                preambleNameRow.Visible = true;
        //                preambleRow.Visible = true;
        //            }
        //            else
        //            {
        //                var preamble = _db.T_QuestionPreamble.FirstOrDefault(s => s.Id == selectedpreamble);

        //                PreambleName.Text = "";
        //                preambleText.Text = "";

        //                preambleNameRow.Visible = false;
        //                preambleRow.Visible = false;

        //                PreambleNamePreview.Text = preamble.Name;
        //                PreamblePreview.Text = preamble.Body;
        //                preview.Visible = true;

        //            }
        //        }
        //        else
        //        {
        //            PreambleName.Text = "";
        //            preambleText.Text = "";
        //            PreamblePreview.Text = "";
        //            PreambleNamePreview.Text = "";

        //            preview.Visible = false;
        //            preambleNameRow.Visible = false;
        //            preambleRow.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErecruitHelper.SetErrorData(ex, Session);
        //        Response.Redirect("ErrorPage.aspx", false);
        //    }
        //}

        protected void PreviewUpload_Click(object sender, EventArgs e)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
            HttpPostedFile file = QuestionFile.PostedFile;

            if (file != null && file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                string fullFilePath = Path.GetFullPath(file.FileName);
                string ext = System.IO.Path.GetExtension(file.FileName);
                string fileID = Guid.NewGuid().ToString();
                string path = "";
                // var all =  new List<string[]>();
                if (Directory.Exists(Server.MapPath("~/UploadedQuestions/")))
                {
                    path = Server.MapPath(Path.Combine("~/UploadedQuestions/", fileID + ext));
                    // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                    file.SaveAs(path);
                }
                else
                {
                    Directory.CreateDirectory(Server.MapPath("~/UploadedQuestions/"));
                    path = Server.MapPath(Path.Combine("~/UploadedQuestions/", fileID + ext));
                    // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                    file.SaveAs(path);
                }
                var data = File.ReadAllBytes(path);
                ImportFromExcel import = new ImportFromExcel();
                if (ext == ".xls")
                {
                    import.LoadXls(data);
                }
                else if (ext == ".xlsx")
                {
                    import.LoadXlsx(data);
                }
                //first parameter it's the sheet number in the excel workbook
                //second paramter it's the number of rows to skip at the start(we have an header in the file)
                List<QuestionUploadModel> all = import.ExcelToList<QuestionUploadModel>(0, 1);
                var obj = new List<object>();
                foreach (var s in all)
                {

                    obj.Add(new { Question = s.Question, Section = s.Section, A = s.A, B = s.B, C = s.C, D = s.D, E = s.E, Answer = s.Answer });
                }
                DetailGrid.DataSource = obj;
                DetailGrid.DataBind();
                ViewActiveTitle.Value = "Import Preview";
                ViewActive.Value = "1";
                FileID.Value = path;
                EXT.Value = ext;
                resultLbl.Text = "";
                //}
               // QuestionFile.Value = fullFilePath;
            }

            

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
               // var all = new List<string[]>();
                var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
                string fId = FileID.Value;
                //long preaId = 0;

                

                if (!string.IsNullOrEmpty(fId))
                {
                    string ext = EXT.Value;
                    //all = ErecruitHelper.GetLinesFromFile(fId, ext);

                    var data = File.ReadAllBytes(fId);
                    ImportFromExcel import = new ImportFromExcel();
                    if (ext == ".xls")
                    {
                        import.LoadXls(data);
                    }
                    else if (ext == ".xlsx")
                    {
                        import.LoadXlsx(data);
                    }
                    //first parameter it's the sheet number in the excel workbook
                    //second paramter it's the number of rows to skip at the start(we have an header in the file)
                    List<QuestionUploadModel> all = import.ExcelToList<QuestionUploadModel>(0, 1);

                    if (all.Count() < 1)
                    {
                        resultLbl.Text = "Either you uploaded an empty file or you provided wrong file type. Only allowed file type is .csv, .xls or.xlsx!";
                    }
                    else
                    {
                        resultLbl.Text = "";
                        var Qtype = DropDownList1.SelectedValue;
                        var ex = 0;
                        var obj = new List<object>();
                        foreach (var s in all)
                        {
                            ex += _db.SearchQuestion(s.Question.ToLower()).Where(x => x.TypeId == long.Parse(Qtype)).Count();
                            T_Question q = new T_Question
                            {
                                PreambleId = 0,
                                TypeId = long.Parse(Qtype),
                                OptionType = (long)ErecruitHelper.OptionType.Single,
                                IsActive = true,
                                Details =s.Question,
                                TenantId=tenantId,
                                Section = s.Section,
                                AddedBy = SessionHelper.FetchEmail(Session),
                                DateAdded = DateTime.Now
                            };
                            _db.T_Question.Add(q);
                            _db.SaveChanges();
                            var opts = new List<T_Option>();
                            if (!string.IsNullOrEmpty(s.A))
                            {
                                opts.Add(new T_Option
                                                    {
                                                        Q_Id = q.Id,
                                                        Details = s.A,
                                                        Answer = s.Answer == ErecruitHelper.OptionIndex.A.ToString(),
                                                        AddedBy = SessionHelper.FetchEmail(Session),
                                                        DateAdded = DateTime.Now
                                                    });
                            }
                            if (!string.IsNullOrEmpty(s.B))
                            {
                                opts.Add(new T_Option
                                {
                                    Q_Id = q.Id,
                                    Details = s.B,
                                    Answer = s.Answer == ErecruitHelper.OptionIndex.B.ToString(),
                                    AddedBy = SessionHelper.FetchEmail(Session),
                                    DateAdded = DateTime.Now
                                });
                            }
                            if (!string.IsNullOrEmpty(s.C))
                            {
                                opts.Add(new T_Option
                                {
                                    Q_Id = q.Id,
                                    Details = s.C,
                                    Answer = s.Answer == ErecruitHelper.OptionIndex.C.ToString(),
                                    AddedBy = SessionHelper.FetchEmail(Session),
                                    DateAdded = DateTime.Now
                                });
                            }
                            if (!string.IsNullOrEmpty(s.D))
                            {
                                opts.Add(new T_Option
                                {
                                    Q_Id = q.Id,
                                    Details = s.D,
                                    Answer = s.Answer == ErecruitHelper.OptionIndex.D.ToString(),
                                    AddedBy = SessionHelper.FetchEmail(Session),
                                    DateAdded = DateTime.Now
                                });
                            }
                            if (!string.IsNullOrEmpty(s.E))
                            {
                                opts.Add(new T_Option
                                {
                                    Q_Id = q.Id,
                                    Details = s.E,
                                    Answer = s.Answer == ErecruitHelper.OptionIndex.E.ToString(),
                                    AddedBy = SessionHelper.FetchEmail(Session),
                                    DateAdded = DateTime.Now
                                });
                            }
                           // _db.T_Option.InsertAllOnSubmit(opts);
                            ExtensionMethods.InsertAllOnSubmit(_db.T_Option, opts);
                            _db.SaveChanges();
                        }
                        if (ex > 0)
                        {
                            resultLbl.Text = "Some Question(s) already exist in the system therefore were skipped."; 
                        }
                        else
                        {
                            resultLbl.Text = "Questions Uploaded";
                        }
                    }
                }
                else
                {
                    HttpPostedFile file = QuestionFile.PostedFile;

                    if (file != null && file.ContentLength > 0)
                    {
                        string fname = Path.GetFileName(file.FileName);
                        string ext = System.IO.Path.GetExtension(file.FileName);
                        string fileID = Guid.NewGuid().ToString();
                        string path = "";
                        // var all =  new List<string[]>();
                        if (Directory.Exists(Server.MapPath("~/UploadedQuestions/")))
                        {
                            path = Server.MapPath(Path.Combine("~/UploadedQuestions/", fileID + ext));
                            // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                            file.SaveAs(path);
                        }
                        else
                        {
                            Directory.CreateDirectory(Server.MapPath("~/UploadedQuestions/"));
                            path = Server.MapPath(Path.Combine("~/UploadedQuestions/", fileID + ext));
                            // PPath = Path.Combine("~/Passports/", cand.Code + ext);
                            file.SaveAs(path);
                        }
                        var data = File.ReadAllBytes(path);
                        ImportFromExcel import = new ImportFromExcel();
                        if (ext == ".xls")
                        {
                            import.LoadXls(data);
                        }
                        else if (ext == ".xlsx")
                        {
                            import.LoadXlsx(data);
                        }
                        //first parameter it's the sheet number in the excel workbook
                        //second paramter it's the number of rows to skip at the start(we have an header in the file)
                        List<QuestionUploadModel> all = import.ExcelToList<QuestionUploadModel>(0, 1);

                        if (all.Count() < 1)
                        {
                            resultLbl.Text = "Either you uploaded an empty file or you provided wrong file type. Only allowed file type is .csv, .xls or.xlsx!";
                        }
                        else
                        {
                            resultLbl.Text = "";
                            var Qtype = DropDownList1.SelectedValue;
                            var ex = 0;
                            var obj = new List<object>();
                            foreach (var s in all)
                            {
                                ex += _db.SearchQuestion(s.Question.ToLower()).Where(x => x.TypeId == long.Parse(Qtype)).Count();
                                T_Question q = new T_Question
                                {
                                    PreambleId = 0,
                                    TypeId = long.Parse(Qtype),
                                    OptionType = (long)ErecruitHelper.OptionType.Single,
                                    IsActive = true,
                                    Details = s.Question,
                                    Section = s.Section,
                                    TenantId = tenantId,
                                    AddedBy = SessionHelper.FetchEmail(Session),
                                    DateAdded = DateTime.Now
                                };
                                _db.T_Question.Add(q);
                                _db.SaveChanges();
                                var opts = new List<T_Option>();
                                if (!string.IsNullOrEmpty(s.A))
                                {
                                    opts.Add(new T_Option
                                                        {
                                                            Q_Id = q.Id,
                                                            Details = s.A,
                                                            Answer = s.Answer == ErecruitHelper.OptionIndex.A.ToString(),
                                                            AddedBy = SessionHelper.FetchEmail(Session),
                                                            DateAdded = DateTime.Now
                                                        });
                                }
                                if (!string.IsNullOrEmpty(s.B))
                                {
                                    opts.Add(new T_Option
                                    {
                                        Q_Id = q.Id,
                                        Details = s.B,
                                        Answer = s.Answer == ErecruitHelper.OptionIndex.B.ToString(),
                                        AddedBy = SessionHelper.FetchEmail(Session),
                                        DateAdded = DateTime.Now
                                    });
                                }
                                if (!string.IsNullOrEmpty(s.C))
                                {
                                    opts.Add(new T_Option
                                    {
                                        Q_Id = q.Id,
                                        Details = s.C,
                                        Answer = s.Answer == ErecruitHelper.OptionIndex.C.ToString(),
                                        AddedBy = SessionHelper.FetchEmail(Session),
                                        DateAdded = DateTime.Now
                                    });
                                }
                                if (!string.IsNullOrEmpty(s.D))
                                {
                                    opts.Add(new T_Option
                                    {
                                        Q_Id = q.Id,
                                        Details = s.D,
                                        Answer = s.Answer == ErecruitHelper.OptionIndex.D.ToString(),
                                        AddedBy = SessionHelper.FetchEmail(Session),
                                        DateAdded = DateTime.Now
                                    });
                                }
                                if (!string.IsNullOrEmpty(s.E))
                                {
                                    opts.Add(new T_Option
                                    {
                                        Q_Id = q.Id,
                                        Details = s.E,
                                        Answer = s.Answer == ErecruitHelper.OptionIndex.E.ToString(),
                                        AddedBy = SessionHelper.FetchEmail(Session),
                                        DateAdded = DateTime.Now
                                    });
                                }
                                ExtensionMethods.InsertAllOnSubmit(_db.T_Option, opts);
                                //_db.T_Option.InsertAllOnSubmit(opts);
                                _db.SaveChanges();
                            }
                            if (ex > 0)
                            {
                                resultLbl.Text = "Some Question(s) already exist in the system therefore were skipped.";
                            }
                            else
                            {
                                resultLbl.Text = "Questions Uploaded";
                            }
                        }

                    }
                   
                    }
            }
            catch (Exception ex)
            {
                ErecruitHelper.SetErrorData(ex, Session);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        protected void proceedtoUpload_Click(object sender, EventArgs e)
        {
            var tenantId = long.Parse(SessionHelper.GetTenantID(HttpContext.Current.Session));
             string fId = FileID.Value;
                //long preaId = 0;



             if (!string.IsNullOrEmpty(fId))
             {
                 string ext = EXT.Value;

                 var data = File.ReadAllBytes(fId);
                 ImportFromExcel import = new ImportFromExcel();
                 if (ext == ".xls")
                 {
                     import.LoadXls(data);
                 }
                 else if (ext == ".xlsx")
                 {
                     import.LoadXlsx(data);
                 }
                 //first parameter it's the sheet number in the excel workbook
                 //second paramter it's the number of rows to skip at the start(we have an header in the file)
                 List<QuestionUploadModel> all = import.ExcelToList<QuestionUploadModel>(0, 1);

                 if (all.Count() < 1)
                 {
                     resultLbl.Text = "Either you uploaded an empty file or you provided wrong file type. Only allowed file type is .csv, .xls or.xlsx!";
                 }
                 else
                 {
                     resultLbl.Text = "";
                     var Qtype = DropDownList1.SelectedValue;
                     var ex = 0;
                     var obj = new List<object>();
                     foreach (var s in all)
                     {
                         ex += _db.SearchQuestion(s.Question.ToLower()).Where(x => x.TypeId == long.Parse(Qtype)).Count();
                         T_Question q = new T_Question
                         {
                             PreambleId = 0,
                             TypeId = long.Parse(Qtype),
                             OptionType = (long)ErecruitHelper.OptionType.Single,
                             IsActive = true,
                             Details = s.Question,
                             Section = s.Section,
                             TenantId = tenantId,
                             AddedBy = SessionHelper.FetchEmail(Session),
                             DateAdded = DateTime.Now
                         };
                         _db.T_Question.Add(q);
                         _db.SaveChanges();
                         var opts = new List<T_Option>();
                         if (!string.IsNullOrEmpty(s.A))
                         {
                             opts.Add(new T_Option
                             {
                                 Q_Id = q.Id,
                                 Details = s.A,
                                 Answer = s.Answer == ErecruitHelper.OptionIndex.A.ToString(),
                                 AddedBy = SessionHelper.FetchEmail(Session),
                                 DateAdded = DateTime.Now
                             });
                         }
                         if (!string.IsNullOrEmpty(s.B))
                         {
                             opts.Add(new T_Option
                             {
                                 Q_Id = q.Id,
                                 Details = s.B,
                                 Answer = s.Answer == ErecruitHelper.OptionIndex.B.ToString(),
                                 AddedBy = SessionHelper.FetchEmail(Session),
                                 DateAdded = DateTime.Now
                             });
                         }
                         if (!string.IsNullOrEmpty(s.C))
                         {
                             opts.Add(new T_Option
                             {
                                 Q_Id = q.Id,
                                 Details = s.C,
                                 Answer = s.Answer == ErecruitHelper.OptionIndex.C.ToString(),
                                 AddedBy = SessionHelper.FetchEmail(Session),
                                 DateAdded = DateTime.Now
                             });
                         }
                         if (!string.IsNullOrEmpty(s.D))
                         {
                             opts.Add(new T_Option
                             {
                                 Q_Id = q.Id,
                                 Details = s.D,
                                 Answer = s.Answer == ErecruitHelper.OptionIndex.D.ToString(),
                                 AddedBy = SessionHelper.FetchEmail(Session),
                                 DateAdded = DateTime.Now
                             });
                         }
                         if (!string.IsNullOrEmpty(s.E))
                         {
                             opts.Add(new T_Option
                             {
                                 Q_Id = q.Id,
                                 Details = s.E,
                                 Answer = s.Answer == ErecruitHelper.OptionIndex.E.ToString(),
                                 AddedBy = SessionHelper.FetchEmail(Session),
                                 DateAdded = DateTime.Now
                             });
                         }
                         ExtensionMethods.InsertAllOnSubmit(_db.T_Option, opts);
                         //_db.T_Option.InsertAllOnSubmit(opts);
                         _db.SaveChanges();
                     }
                     if (ex > 0)
                     {
                         resultLbl.Text = "Some Question(s) already exist in the system therefore were skipped.";
                     }
                     else
                     {
                         resultLbl.Text = "Questions Uploaded";
                     }
                 }
             }
             else
             {
                 resultLbl.Text = "No file to upload. Kindly chose a file.";
             }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/QuestionTemplatesFile.xls", false);
        }
    }
}