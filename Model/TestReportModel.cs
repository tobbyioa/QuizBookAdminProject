using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class TestReportModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string Age { get; set; }
        public string Qualification { get; set; }
        public string Grade { get; set; }
        public string Score { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Refferal { get; set; }
        public string TestDate { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string Alt { get; set; }
        public string Passport { get; set; }
    }

    public class IndividualTestReport
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Condition { get; set; }
        public string ConditionName { get; set; }
        public string BatchName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string CorrectAnswer{ get; set; }
        public string IndicatorImg { get; set; }
        public string DateMarked { get; set; }
        public string Percentage { get; set; }
        public string TotalCorrect { get; set; }
        public string TotalWrong { get; set; }
        public string TotalUnanswered { get; set; }
        public string TotalQuestions { get; set; }
        public string Cutoff { get; set; }
        public string Branch { get; set; }
        public string Division { get; set; }

        public int Passed { get; set; }
        public int Failed { get; set; }
    }

    public class BatchReport
    {
        public long ID { get; set; }
        public string username { get; set; }
        public string BatchName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string CorrectAnswer { get; set; }
        public string IndicatorImg { get; set; }
        public string DateMarked { get; set; }
        public string Percentage { get; set; }
        public string TotalCorrect { get; set; }
        public string TotalPartial { get; set; }
        public string TotalWrong { get; set; }
        public string TotalUnanswered { get; set; }
        public string TotalQuestions { get; set; }
        public string Cutoff { get; set; }
        public string Branch { get; set; }
        public string Division { get; set; }

        public int Passed { get; set; }
        public int Failed { get; set; }
    }
}