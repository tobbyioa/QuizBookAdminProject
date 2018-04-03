using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class BatchGridModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BatchType { get; set; }
        public string IsActive { get; set; }
        public string SessionOn { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Duration { get; set; }
        public string NoOfQuestions { get; set; }
        public string State { get; set; }
        public bool StateValue { get; set; }
        public bool ActivateLinkActive { get; set; }
        public string DateAdded { get; set; }
        public string DateModified { get; set; }
        public string D { get; set; }
        public string ViewResults { get; set; }
    }
}