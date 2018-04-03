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
    
    public partial class Tenant
    {
        public Tenant()
        {
            this.Candidates = new HashSet<Candidate>();
            this.T_Question = new HashSet<T_Question>();
            this.T_QuestionType = new HashSet<T_QuestionType>();
            this.T_Batch = new HashSet<T_Batch>();
            this.TestResultReports = new HashSet<TestResultReport>();
            this.AdminUsers = new HashSet<AdminUser>();
        }
    
        public long Id { get; set; }
        public string TenantCode { get; set; }
        public string TenantName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Nullable<bool> TenantStatus { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<long> TenantLimit { get; set; }
        public string Image { get; set; }
    
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<T_Question> T_Question { get; set; }
        public virtual ICollection<T_QuestionType> T_QuestionType { get; set; }
        public virtual ICollection<T_Batch> T_Batch { get; set; }
        public virtual ICollection<TestResultReport> TestResultReports { get; set; }
        public virtual ICollection<AdminUser> AdminUsers { get; set; }
    }
}
