using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleExcelImport;

namespace QuizBook.Model
{
    public class QuestionUploadModel
    {
        [ExcelImport("Question", order = 1)]
        public string Question { get; set; }
        [ExcelImport("Section", order = 2)]
        public string Section{ get; set; }
        [ExcelImport("A", order = 3)]
        public string A { get; set; }
        [ExcelImport("B", order = 4)]
        public string B { get; set; }
        [ExcelImport("C", order = 5)]
        public string C { get; set; }
        [ExcelImport("D", order = 6)]
        public string D { get; set; }
        [ExcelImport("E", order = 7)]
        public string E { get; set; }
        [ExcelImport("Answer", order = 8)]
        public string Answer { get; set; }
    }
}