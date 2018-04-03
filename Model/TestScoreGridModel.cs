using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class TestScoreGridModel
    {
         public long ID { get; set; }
         public long QuestionNo { get; set; }
        public string OptionType { get; set; }
        public string CandidateOptions { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
    }
}