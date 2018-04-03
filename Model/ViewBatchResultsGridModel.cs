using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class ViewBatchResultsGridModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string Score { get; set; }
        public string Alt { get; set; }
        public string Passport { get; set; }
    }
}