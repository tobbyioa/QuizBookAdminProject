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
    
    public partial class T_CandidateTemp
    {
        public long Id { get; set; }
        public Nullable<long> CandidateId { get; set; }
        public Nullable<long> BatchId { get; set; }
        public Nullable<long> Q_Index { get; set; }
        public Nullable<long> PreambleId { get; set; }
        public Nullable<long> Q_Id { get; set; }
        public Nullable<bool> Answered { get; set; }
    
        public virtual T_Batch T_Batch { get; set; }
        public virtual T_Candidate T_Candidate { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}