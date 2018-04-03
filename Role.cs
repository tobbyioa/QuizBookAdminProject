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
    
    public partial class Role
    {
        public Role()
        {
            this.RolePermissions = new HashSet<RolePermission>();
            this.Candidates = new HashSet<Candidate>();
            this.AdminUsers = new HashSet<AdminUser>();
            this.Candidates1 = new HashSet<Candidate>();
        }
    
        public long Id { get; set; }
        public string Description { get; set; }
        public string CretaedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<long> TenantId { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public bool Active { get; set; }
        public Nullable<bool> CanHaveCandidates { get; set; }
        public Nullable<long> ReportsTo { get; set; }
    
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<AdminUser> AdminUsers { get; set; }
        public virtual ICollection<Candidate> Candidates1 { get; set; }
    }
}
