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
    
    public partial class T_QuestionType
    {
        public T_QuestionType()
        {
            this.BatchScopeContents = new HashSet<BatchScopeContent>();
            this.T_Question = new HashSet<T_Question>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<long> TenantId { get; set; }
    
        public virtual ICollection<BatchScopeContent> BatchScopeContents { get; set; }
        public virtual ICollection<T_Question> T_Question { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
