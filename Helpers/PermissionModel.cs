using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizBook.Models
{
    public class PermissionModel
    {

        public bool _CanDoTest { get; set; }
        public bool _CanViewOwnTestResult { get; set; }

    }
    public class AdminPermissionModel
    {
        public bool _IsAdmin { get; set; }
        public bool _CanWorkWithCandidates { get; set; }
        public bool _CanManageTestBatches { get; set; }
        public bool _CanManageQuestion { get; set; }
        public bool _CanManageTestResults { get; set; }
        public bool _CanManagePortal { get; set; }
        public bool _CanApprove { get; set; }
    }
    public class AllPermissionModel
    {

        public bool _CanDoTest { get; set; }
        public bool _CanViewOwnTestResult { get; set; }
        public bool _IsAdmin { get; set; }
        public bool _CanWorkWithCandidates { get; set; }
        public bool _CanManageTestBatches { get; set; }
        public bool _CanManageQuestion { get; set; }
        public bool _CanManageTestResults { get; set; }
        public bool _CanManagePortal { get; set; }
        public bool _CanApprove { get; set; }

    }
}