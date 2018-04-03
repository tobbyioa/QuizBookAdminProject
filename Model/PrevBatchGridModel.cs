using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Model
{
    public class PrevBatchGridModel
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string BatchName { get; set; }
        public string DateTaken { get; set; }
    }
}