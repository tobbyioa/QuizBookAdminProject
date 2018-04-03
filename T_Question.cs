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
    
    public partial class T_Question
    {
        public T_Question()
        {
            this.T_BatchQuestions = new HashSet<T_BatchQuestions>();
            this.T_Option = new HashSet<T_Option>();
            this.T_Reports = new HashSet<T_Reports>();
            this.T_CandidateAnswers = new HashSet<T_CandidateAnswers>();
        }
    
        public long Id { get; set; }
        public Nullable<long> TypeId { get; set; }
        public Nullable<long> PreambleId { get; set; }
        public string Details { get; set; }
        public Nullable<long> OptionType { get; set; }
        public string Section { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<long> TenantId { get; set; }
        public Nullable<decimal> Mark { get; set; }
        public Nullable<bool> OptionPercentageMark { get; set; }
    
        public virtual ICollection<T_BatchQuestions> T_BatchQuestions { get; set; }
        public virtual ICollection<T_Option> T_Option { get; set; }
        public virtual T_QOptionType T_QOptionType { get; set; }
        public virtual T_QuestionType T_QuestionType { get; set; }
        public virtual ICollection<T_Reports> T_Reports { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<T_CandidateAnswers> T_CandidateAnswers { get; set; }
    }
}
