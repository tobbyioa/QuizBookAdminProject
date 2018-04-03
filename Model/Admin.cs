using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class Admin
    {
    }

    public class AdminGridModel
    {
        public long adminId { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string supervisor { get; set; }
        public string edittxt { get; set; }
        public string ends { get; set; }
    }
}