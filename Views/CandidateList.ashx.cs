using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using QuizBook.Helpers;
using QuizBook.Model;

namespace QuizBook.Views
{
    /// <summary>
    /// Summary description for CandidateList
    /// </summary>
    public class CandidateList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            // Those parameters are sent by the plugin
            QuizBookDbEntities1 _db = new QuizBookDbEntities1();
            var action = context.Request["action"];
            var qtS = context.Request["qtypeSort"];
            var alink = context.Request["z"];
            //var alink = context.Session["thelink"]!=null?context.Session["thelink"].ToString():"";
            var iDisplayLength = context.Request["iDisplayLength"];
            var iDisplayStart = context.Request["iDisplayStart"];
            var iSortCol = context.Request["iSortCol_0"];
            var iSortDir = context.Request["sSortDir_0"];
            var iSearch = context.Request["sSearch"];
            var isEcho = context.Request["sEcho"];
            

            switch (action)
            {
                case "SwitchActivity":
                    var id = context.Request["id"];
                    SwitchActivityAction(_db, context, id);
                    break;
                case "CandidateList":
                    CandidatesGridDataLoad(_db, context, iSearch, iSortCol, iSortDir, iDisplayStart, iDisplayLength, isEcho);
                    break;

                case "QuestList":
                    QuestionGridDataLoad(_db, context, iSearch, iSortCol, iSortDir, iDisplayStart, iDisplayLength, isEcho, qtS);
                    break;

                case "QuestOptList":
                    OptionGridDataLoad(_db, context, iSearch, iSortCol, iSortDir, iDisplayStart, iDisplayLength, isEcho, alink);
                    break;
                case "QuestTypeList":
                    QtypeGridDataLoad(_db, context, iSearch, iSortCol, iSortDir, iDisplayStart, iDisplayLength, isEcho);
                    break;
            }
        }

        public void SwitchActivityAction(QuizBookDbEntities1 _db,HttpContext context, string id)
        {
            var opt = _db.T_Candidate.FirstOrDefault(s => s.Id == long.Parse(id));
            if (opt != null)
            {
                if (opt.IsActive != null && opt.IsActive.Value)
                {
                    opt.IsActive = false;
                }
                else
                {
                    opt.IsActive = true;
                }

                _db.SaveChanges();
                context.Response.ContentType = "text/plain";
                context.Response.Write("Successful");
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Failed");
            }

        }
        public void CandidatesGridDataLoad(QuizBookDbEntities1 _db, HttpContext context, string iSearch, string iSortCol1, string iSortDir, string iDisplayStart1, string iDisplayLength1, string isEcho)
        {
           var iDisplayLength = int.Parse(iDisplayLength1);
           var iDisplayStart = int.Parse(iDisplayStart1);
           var iSortCol = int.Parse(iSortCol1);

            var data = _db.Candidates.Select(a => new CandidateGridModel
            {
                ID = a.Id,
                TenantId = a.TenantId ?? 0,
                Username = a.Username,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Sex = a.Sex,
                DOB = a.DOB == null ? "-" : a.DOB.Value.ToString("dd-MM-yyyy"),
                Status = a.Status ?? "-",
                Email = a.Email,
                D = a.Status == ErecruitHelper.CStatus.Active.ToString() ? "Deactivate" : "Activate",
                DateRegistered = a.DateCreated == null ? "-" : a.DateCreated.Value.ToString("dd-MM-yyyy")
            }).ToList();
            //Searching
            IEnumerable<CandidateGridModel> filtered;
            if (!string.IsNullOrEmpty(iSearch))
            {
                filtered = data
                         .Where(c =>
                               c.Username.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.FirstName.ToLower().Contains(iSearch.ToLower())
                                     ||

                          c.LastName.ToLower().Contains(iSearch.ToLower())
                          ||
                           
                          c.D.ToLower().Contains(iSearch.ToLower())


                          );
            }
            else
            {
                filtered = data;
            }


            // Sorting
            var items = filtered;

            var sortColumnIndex = Convert.ToInt32(iSortCol);
            // Func<BDCCustomerGridModel, string> orderingFunction = (c => c.id.ToString());

            Func<CandidateGridModel, string> orderingFunction = (c => sortColumnIndex == 0 ? c.Username :
                 sortColumnIndex == 1 ? c.FirstName :
                sortColumnIndex == 2 ? c.LastName :
                                                       
                                                           sortColumnIndex == 8 ? c.D : ""
                                                        );

            //? sortColumnIndex == 2 ? c.Title :c.StartDate
            var sortDirection = iSortDir;
            // asc or desc       
            filtered = sortDirection == "asc" ? filtered.OrderBy(orderingFunction) : filtered.OrderByDescending(orderingFunction);
            //Paging
            var displayed = filtered
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);

            //Table Construction
            var thelist = from s in displayed
                          select new[] { s.Username, s.FirstName, s.LastName, s.D, s.DateRegistered.ToString() };
            var result = new
            {
                sEcho = isEcho,
                iTotalRecords = data.Count(),
                iTotalDisplayRecords = thelist.Count(),
                aaData = thelist.ToList()
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
            
        }
        public void QuestionGridDataLoad(QuizBookDbEntities1 _db, HttpContext context, string iSearch, string iSortCol2, string iSortDir, string iDisplayStart2, string iDisplayLength2, string isEcho, string qtS)
        {
            var iDisplayLength = int.Parse(iDisplayLength2);
            var iDisplayStart = int.Parse(iDisplayStart2);
            var iSortCol = int.Parse(iSortCol2);

            var quests = new List<QuestionModel>();
            if (qtS == "null")
            {

                quests = _db.T_Question.OrderByDescending(x => x.DateAdded).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : "<div class='box'>" + a.Details.Trim() + "</div>",
                    Type = ErecruitHelper.getTypeName(_db, a.TypeId),
                    OptionType = ErecruitHelper.getOptionTypeName(_db, a.OptionType),
                    OptionsCount = ErecruitHelper.getOptionNumLink(_db, a.Id, a.Id),
                    IsActive = a.IsActive.Value ? "Yes" : "No",
                    Edit = "<a href='QuestionsList.aspx?z=" + a.Id + "' >Edit</a>",
                    D = a.IsActive.Value ? "<a href='#' >Deactivate</a>" : "<a href='#' >Activate</a>"
                }).ToList();
            }
            else
            {

                quests = _db.T_Question.Where(s => s.TypeId == long.Parse(qtS)).OrderByDescending(x => x.DateAdded).Select(a => new QuestionModel
                {
                    ID = a.Id,
                    Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : "<div class='box'>" + a.Details.Trim() + "</div>",
                    Type = ErecruitHelper.getTypeName(_db, a.TypeId),
                    OptionType = ErecruitHelper.getOptionTypeName(_db, a.OptionType),
                    OptionsCount = ErecruitHelper.getOptionNumLink(_db, a.Id, a.Id),
                    IsActive = a.IsActive.Value ? "Yes" : "No",
                    Edit = "<a href='QuestionsList.aspx?z=" + a.Id + "' >Edit</a>",
                    D = a.IsActive.Value ? "<a href='#' >Deactivate</a>" : "<a href='#' >Activate</a>"
                }).Distinct().ToList();

            }
            //Searching
            IEnumerable<QuestionModel> f;
            if (!string.IsNullOrEmpty(iSearch))
            {
                f = quests
                         .Where(c => c.ID.ToString().ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Detail.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Type.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.OptionType.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.OptionsCount.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.IsActive.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.Edit.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.D.ToLower().Contains(iSearch.ToLower())


                          );
            }
            else
            {
                f = quests;
            }
            // Sorting
            var its = f;

            var sortCIndex = Convert.ToInt32(iSortCol);
            // Func<BDCCustomerGridModel, string> orderingFunction = (c => c.id.ToString());

            Func<QuestionModel, string> orderingFunct = (c => sortCIndex == 0 ? c.ID.ToString() :
                 sortCIndex == 1 ? c.Detail :
                sortCIndex == 2 ? c.Type :
                                                        sortCIndex == 3 ? c.OptionType :
                                                         sortCIndex == 4 ? c.OptionsCount :
                                                          sortCIndex == 5 ? c.IsActive :
                                                           sortCIndex == 6 ? c.Edit :
                                                           sortCIndex == 7 ? c.D : ""
                                                        );

            //? sortColumnIndex == 2 ? c.Title :c.StartDate
            var sortDirect = iSortDir;

            // asc or desc       
            f = sortDirect == "asc" ? f.OrderBy(orderingFunct) : f.OrderByDescending(orderingFunct);


            //Paging
            var displ = f
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);

            //Table Construction
            var thelst = from s in displ
                         select new[] { s.ID.ToString(), s.Detail, s.Type, s.OptionType, s.IsActive, s.OptionsCount, s.Edit, s.D };


            var r = new
            {
                sEcho = isEcho,
                iTotalRecords = quests.Count(),
                iTotalDisplayRecords = thelst.Count(),
                aaData = thelst.ToList()
            };

            var srlizer = new JavaScriptSerializer();
            var jsonObj = srlizer.Serialize(r);
            context.Response.ContentType = "application/json";
            context.Response.Write(jsonObj);
        }
        public void OptionGridDataLoad(QuizBookDbEntities1 _db, HttpContext context, string iSearch, string iSortCol3, string iSortDir, string iDisplayStart3, string iDisplayLength3, string isEcho, string alink)
        {
            var iDisplayLength = int.Parse(iDisplayLength3);
            var iDisplayStart = int.Parse(iDisplayStart3);
            var iSortCol = int.Parse(iSortCol3);

            var options = _db.T_Option.AsEnumerable().Where(s => s.Q_Id == long.Parse(alink)).Select(a => new QuestionOptionModel
            {
                ID = a.Id.ToString(),
                Detail = string.IsNullOrEmpty(a.Details) ? "Empty" : a.Details.Trim(),
                Answer = (a.Answer.Value.ToString()),
                E = "<a href='QuestionOptions.aspx?z=" + a.Id + "' >Edit</a>",
                D = "<a href='#'>Delete</a>"

            }).ToList();


            //Searching
            IEnumerable<QuestionOptionModel> fopt;
            if (!string.IsNullOrEmpty(iSearch))
            {
                fopt = options
                         .Where(c => c.ID.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Detail.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Answer.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.E.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.D.ToLower().Contains(iSearch.ToLower())
                          );
            }
            else
            {
                fopt = options;
            }
            // Sorting
            var itOpt = fopt;

            var sortOptIndex = Convert.ToInt32(iSortCol);


            Func<QuestionOptionModel, string> orderingOptFunct = (c => sortOptIndex == 0 ? c.ID.ToString() :
                 sortOptIndex == 1 ? c.Detail :

                                                          sortOptIndex == 5 ? c.Answer :
                                                           sortOptIndex == 6 ? c.E :
                                                           sortOptIndex == 7 ? c.D : ""
                                                        );

            //? sortColumnIndex == 2 ? c.Title :c.StartDate
            var sortOptDirect = iSortDir;

            // asc or desc       
            fopt = sortOptDirect == "asc" ? fopt.OrderBy(orderingOptFunct) : fopt.OrderByDescending(orderingOptFunct);


            //Paging
            var displOpt = fopt
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);

            //Table Construction
            var thelstOpt = from s in displOpt
                            select new[] { s.ID.ToString(), s.Detail, s.Answer, s.E, s.D };


            var rOpt = new
            {
                sEcho = isEcho,
                iTotalRecords = options.Count(),
                iTotalDisplayRecords = thelstOpt.Count(),
                aaData = thelstOpt.ToList()
            };

            var srlizerOpt = new JavaScriptSerializer();
            var jsonObjOpt = srlizerOpt.Serialize(rOpt);
            context.Response.ContentType = "application/json";
            context.Response.Write(jsonObjOpt);
        }
        public void QtypeGridDataLoad(QuizBookDbEntities1 _db, HttpContext context, string iSearch, string iSortCol3, string iSortDir, string iDisplayStart3, string iDisplayLength3, string isEcho)
        {
            var iDisplayLength = int.Parse(iDisplayLength3);
            var iDisplayStart = int.Parse(iDisplayStart3);
            var iSortCol = int.Parse(iSortCol3);

            //var options = _db.T_QuestionTypes.Select(a => new QuestionTypeModel
            //{
            //    Id = a.Id.ToString(),
            //    Name = string.IsNullOrEmpty(a.Name) ? "Empty" : a.Name.Trim(),
            //    Status = a.Status.Value ? "Yes" : "No",
            //    Action = a.Status.Value ? "<a href='#'>Activate</a>" : "<a href='#'>Deactivate</a>"

            //}).ToList();

            var options = _db.T_QuestionType.Select(a => new QuestionTypeModel
            {
                Id = "-",
                Name = "3",
                Status = "No",
                Action = "YES"

            }).ToList();


            //Searching
            IEnumerable<QuestionTypeModel> fopt;
            if (!string.IsNullOrEmpty(iSearch))
            {
                fopt = options
                         .Where(c => c.Id.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Name.ToLower().Contains(iSearch.ToLower())
                                     ||
                          c.Status.ToLower().Contains(iSearch.ToLower())
                           ||
                          c.Action.ToLower().Contains(iSearch.ToLower())
                          );
            }
            else
            {
                fopt = options;
            }
            // Sorting
            var itOpt = fopt;

            var sortOptIndex = Convert.ToInt32(iSortCol);


            Func<QuestionTypeModel, string> orderingOptFunct = (c => sortOptIndex == 0 ? c.Id.ToString() :
                 sortOptIndex == 1 ? c.Name :

                                                          sortOptIndex == 5 ? c.Status :
                                                           sortOptIndex == 7 ? c.Action: ""
                                                        );

            //? sortColumnIndex == 2 ? c.Title :c.StartDate
            var sortOptDirect = iSortDir;

            // asc or desc       
            fopt = sortOptDirect == "asc" ? fopt.OrderBy(orderingOptFunct) : fopt.OrderByDescending(orderingOptFunct);


            //Paging
            var displOpt = fopt
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);

            //Table Construction
            var thelstOpt = from s in displOpt
                            select new[] { s.Id.ToString(), s.Name, s.Status, s.Action };


            var rOpt = new
            {
                sEcho = isEcho,
                iTotalRecords = options.Count(),
                iTotalDisplayRecords = thelstOpt.Count(),
                aaData = thelstOpt.ToList()
            };

            var srlizerOpt = new JavaScriptSerializer();
            var jsonObjOpt = srlizerOpt.Serialize(rOpt);
            context.Response.ContentType = "application/json";
            context.Response.Write(jsonObjOpt);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}