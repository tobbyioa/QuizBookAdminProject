//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuizBook
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestReportAnswer
    {
        public long Id { get; set; }
        public Nullable<long> ReportId { get; set; }
        public string sn { get; set; }
        public string question { get; set; }
        public Nullable<decimal> Mark { get; set; }
        public Nullable<decimal> Score { get; set; }
        public string chosenAnswer { get; set; }
        public string correct { get; set; }
        public string correctAnswer { get; set; }
    
        public virtual TestResultReport TestResultReport { get; set; }
    }
}
