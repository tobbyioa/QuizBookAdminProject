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
    
    public partial class branch_tab
    {
        public branch_tab()
        {
            this.T_Candidate = new HashSet<T_Candidate>();
        }
    
        public int id { get; set; }
        public string sol_id { get; set; }
        public string branch_name { get; set; }
        public Nullable<int> region_code { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual ICollection<T_Candidate> T_Candidate { get; set; }
    }
}