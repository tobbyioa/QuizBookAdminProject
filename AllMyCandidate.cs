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
    
    public partial class AllMyCandidate
    {
        public long Id { get; set; }
        public Nullable<long> TenantId { get; set; }
        public string TenantName { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<long> Role { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<bool> TenantStatus { get; set; }
        public string TenantCode { get; set; }
    }
}
