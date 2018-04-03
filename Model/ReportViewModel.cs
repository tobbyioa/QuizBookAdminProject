using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizBook.Models
{
    public class ReportViewModel
    {
        [Key]
        public string candidateId { get; set; }
        public long candId { get; set; }
        public string candidateName { get; set; }
        public long batchId { get; set; }
        public string batchName { get; set; }
        public string tenantName { get; set; }
        public long tenantId { get; set; }
        public List<Answer> answers { get; set; }
        public string Correct { get; set; }
        public string Partial { get; set; }
        public string Wrong { get; set; }
        public string Unanswered { get; set; }
        public string percentage { get; set; }
        public decimal? totalQuestionMark { get; set; }
        public string tstDate { get; set; }
        public ResultModel result { get; set; }
        public string imgUrl { get; set; }
        public string fontUrl { get; set; }

    }

    public class ResultModel
    {
        public decimal Correct { get; set; }
        public decimal Partial { get; set; }
        public decimal Wrong { get; set;}
        public decimal Unanswered { get; set; }

        public decimal CorrectPercent { get; set; }
        public decimal PartialPercent { get; set; }
        public decimal WrongPercent { get; set; }
        public decimal UnansweredPercent { get; set; }


        public int CorrectCount { get; set; }
        public int PartialCount { get; set; }
        public int WrongCount { get; set; }
        public int UnansweredCount { get; set; }


        public decimal questionCount { get; set; }
        public decimal questionTotalMark { get; set; }

        public DateTime testDate { get; set; }
    }
        public class Answer
    {
        [Key]
        public string sn { get; set; }
        public string question { get; set; }
        public decimal? Mark { get; set; }
        public decimal? Score { get; set; }
        public string chosenAnswer { get; set; }
        public string correctAnswer { get; set; }
        //public bool correct { get; set; }
        public string correct { get; set; }
    }

    public enum optionState
    {
        Correct,
        Wrong,
        Partial
    }
}