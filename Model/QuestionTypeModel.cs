using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class QuestionTypeModel
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public string Status {get;set;}
        public string Action { get; set; }
    }
}