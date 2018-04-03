using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class QuestionModel
    {
         public long ID { get; set; }
         public string Detail {get;set;}
         public string Preamble { get; set; }
         public string Type {get;set;}
         public string Section { get; set; }
         public string OptionType {get;set;}
         public string OptionsCount { get; set; }
         public string IsActive { get; set; }
         public string Edit { get; set; }
         public string D { get; set; }
    }
}