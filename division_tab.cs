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
    
    public partial class division_tab
    {
        public division_tab()
        {
            this.T_Candidate = new HashSet<T_Candidate>();
        }
    
        public string DIV_CODE { get; set; }
        public string DIV_NAME { get; set; }
    
        public virtual ICollection<T_Candidate> T_Candidate { get; set; }
    }
}