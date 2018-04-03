using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class CandidateGridModel
    {
        public long ID { get; set; }
        public long TenantId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string DateRegistered { get; set; }
        
        public string D { get; set; }
    }
}