using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace QuizBook.Helpers
{
    public class PermissionManager
    {
        private const string _IsAdmin = "IsAdmin";
        private const string _CanWorkWithCandidates = "CanWorkWithCandidates";
        private const string _CanManageTestBatches = "CanManageTestBatches";
        private const string _CanManageQuestion = "CanManageQuestion";
        private const string _CanManageTestResults = "CanManageTestResults";
        private const string _CanManagePortal = "CanManagePortal";
        private const string _CanApprove = "CanApprove";


    private HttpSessionState _session;

    public PermissionManager(HttpSessionState session)
    {
        _session = session;
    }

    public bool IsAdmin
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_IsAdmin); }
    }
    public bool CanManageTestBatches
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanManageTestBatches); }
    }
    public bool CanWorkWithCandidates
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanWorkWithCandidates); }
    }
    public bool CanManageQuestion
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanManageQuestion); }
    }
    public bool CanManageTestResults
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanManageTestResults); }
    }
    public bool CanManagePortal
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanManagePortal); }
    }
    public bool CanApprove
    {
        get { return SessionHelper.FetchUserPermissions(_session).Contains(_CanApprove); }
    }

    }
}