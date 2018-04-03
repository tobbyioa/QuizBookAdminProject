using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizBook.Model;

namespace QuizBook.Helpers.ReportFactory
{
    public class ERecruitReportFactory
    {
         QuizBookDbEntities1 _db = new QuizBookDbEntities1();
        //public List<IndividualTestReport> IndividualTestReport(long candid, long batchid)
        //{
        //    var TR = new List<IndividualTestReport>();
        //    TR.AddRange(_db.IndividualTestResult_sp(candid, batchid,1).Select(s =>new IndividualTestReport{
        //        ID = s.ID,
        //        BatchName = s.BatchName,
        //        Code = s.STAFF_ID,
        //        FirstName = s.FirstName,
        //       Branch = ErecruitHelper.getCandidateBranch(s.STAFF_ID),
        //        Division = ErecruitHelper.getCandidateDivision(s.STAFF_ID),
        //        LastName = s.LastName,
        //        Question = s.QuestionDetails,
        //        Answer = string.IsNullOrEmpty(s.ChosenAnswerDetails) ? "UnAnswered" : s.ChosenAnswerDetails,
        //        CorrectAnswer = string.IsNullOrEmpty(s.CorrectAnswer)?"No Answer Set for the Question.":s.CorrectAnswer,
        //        IndicatorImg = s.Correct.Value ? "CORRECT":"WRONG",
        //        TotalCorrect = s.TotalCorrect.ToString(),
        //        TotalWrong = s.TotalWrong.ToString(),
        //        TotalUnanswered = s.TotalUnAnswered.ToString(),
        //        TotalQuestions = s.TotalQuestions.ToString(),
        //        Percentage = s.Percentage.ToString(),
        //        DateMarked = s.TimeMarked.Value.ToString("dd/MM/yyy")
        //    }));
        //    return TR;
        //}
        public List<IndividualTestReport> BatchTestReport(string type, string tid, DateTime fr , DateTime to)
        {

            var TR = new List<IndividualTestReport>();

           // var cutoff = _db.T_Settings.FirstOrDefault(s => s.SettingsName == "CUT_OFF_MARK").SettingsValue;
            int countP = 0;
            var countF = 0;
            if (fr == null && to == null)
            {
                TR.AddRange(_db.BatchResultByCondition_sp(type, tid).Select(s => new IndividualTestReport
                {
                    Condition = s.Condition,
                    ConditionName = s.ConditionName,
                    BatchName = s.BATCH_NAME,
                    Code = s.STAFF_ID,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    Branch = ErecruitHelper.getCandidateBranch(s.STAFF_ID),
                    Division = ErecruitHelper.getCandidateDivision(s.STAFF_ID),
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyy"),
                    Cutoff = "50",
                    Passed = s.Percentage >= 50? countP++:0,
                    Failed = s.Percentage < 50?countF++:0
                }));
            }
            else if (fr != null && to == null)
            {
                TR.AddRange(_db.BatchResultByConditionNTime_sp(type, tid,fr,DateTime.Now).Select(s => new IndividualTestReport
                {
                    Condition = s.Condition,
                    ConditionName = s.ConditionName,
                    BatchName = s.BATCH_NAME,
                    Code = s.STAFF_ID,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    Branch = ErecruitHelper.getCandidateBranch(s.STAFF_ID),
                    Division = ErecruitHelper.getCandidateDivision(s.STAFF_ID),
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    Cutoff = "50",
                    Passed = s.Percentage >= 50 ? countP++ : 0,
                    Failed = s.Percentage < 50 ? countF++ : 0
                }));
            }
            else if (fr == null && to != null)
            {
                TR.AddRange(_db.BatchResultByConditionNTime_sp(type, tid, DateTime.Now, to).Select(s => new IndividualTestReport
                {
                    Condition = s.Condition,
                    ConditionName = s.ConditionName,
                    BatchName = s.BATCH_NAME,
                    Code = s.STAFF_ID,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    Branch = ErecruitHelper.getCandidateBranch(s.STAFF_ID),
                    Division = ErecruitHelper.getCandidateDivision(s.STAFF_ID),
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    Cutoff = "50",
                    Passed = s.Percentage >= 50 ? countP++ : 0,
                    Failed = s.Percentage < 50 ? countF++ : 0
                }));
            }
            else
            {
                TR.AddRange(_db.BatchResultByConditionNTime_sp(type, tid, fr,to).Select(s => new IndividualTestReport
                {
                    Condition = s.Condition,
                    ConditionName = s.ConditionName,
                    BatchName = s.BATCH_NAME,
                    Code = s.STAFF_ID,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    Branch = ErecruitHelper.getCandidateBranch(s.STAFF_ID),
                    Division = ErecruitHelper.getCandidateDivision(s.STAFF_ID),
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    Cutoff = "50",
                    Passed = s.Percentage >= 50 ? ++countP : 0,
                    Failed = s.Percentage < 50 ? ++countF : 0
                }));
            }

            return TR;
        }
        public List<TestReportModel> TestReport(string dateFrom, string dateTo)
        {
            var TR = new List<TestReportModel>();
             QuizBookDbEntities1 _db = new QuizBookDbEntities1();

            if (!string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
            {

                var f = ErecruitHelper.GetCurrentDateFromDateString(dateFrom);
                var t = ErecruitHelper.GetCurrentDateFromDateString(dateTo);
                var tr = _db.T_CTestTracker.Where(s => s.CurrentStartTime.Value.Date >= f.Date && s.CurrentStartTime.Value.Date <= t.Date).OrderByDescending(s => s.CurrentStartTime).Select(s => s.BatchId).Distinct();
                var bs = _db.T_BatchSet.Where(s => tr.Contains(s.BatchId)).ToList();
                TR = bs.Select(a => new TestReportModel
                {
                    ID = (long)a.CandidateId,
                    Code = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString(),
                    FirstName = ErecruitHelper.getCandidateFirstName((long)a.CandidateId).ToString(),
                    LastName = ErecruitHelper.getCandidateLastName((long)a.CandidateId).ToString(),
                    Qualification = ErecruitHelper.getCandidate((long)a.CandidateId).Degree,
                    Grade = ErecruitHelper.getCandidate((long)a.CandidateId).ClassOfDegree,
                    Contact = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    Refferal = ErecruitHelper.getCandidate((long)a.CandidateId).Referer,
                    from =ErecruitHelper.GetDateStringFromDateX(f),
                    to = ErecruitHelper.GetDateStringFromDateX(t),
                    Email = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    TestDate = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getTracker(a.CandidateId.Value,a.BatchId.Value).CurrentStartTime.Value),
                    Score = a.TestScore == null ? "Not Attempted" : a.TestScore + "%",
                    Age = (DateTime.Now.Year - (ErecruitHelper.getCandidateDobx((long)a.CandidateId) != null ? ErecruitHelper.getCandidateDobx((long)a.CandidateId).Value.Year: 0)).ToString(),
                    DateOfBirth = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getCandidate((long)a.CandidateId).DateOfBirth.Value),
                    Sex = ErecruitHelper.getCandidateSex((long)a.CandidateId).ToString(),
                    Passport = ErecruitHelper.getCandidateImgUrl((long)a.CandidateId).ToString(),
                    Alt = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString()

                }).ToList();

            }
            else if (string.IsNullOrEmpty(dateFrom) && !string.IsNullOrEmpty(dateTo))
            {

                var f = DateTime.Now;
                var t = ErecruitHelper.GetCurrentDateFromDateString(dateTo);
                var tr = _db.T_CTestTracker.Where(s => s.CurrentStartTime.Value.Date >= f.Date && s.CurrentStartTime.Value.Date <= t.Date).OrderByDescending(s => s.CurrentStartTime).Select(s => s.BatchId).Distinct();
                var bs = _db.T_BatchSet.Where(s => tr.Contains(s.BatchId)).ToList();
                TR = bs.Select(a => new TestReportModel
                {
                    ID = (long)a.CandidateId,
                    Code = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString(),
                    FirstName = ErecruitHelper.getCandidateFirstName((long)a.CandidateId).ToString(),
                    LastName = ErecruitHelper.getCandidateLastName((long)a.CandidateId).ToString(),
                    Qualification = ErecruitHelper.getCandidate((long)a.CandidateId).Degree,
                    Grade = ErecruitHelper.getCandidate((long)a.CandidateId).ClassOfDegree,
                    Contact = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    Refferal = ErecruitHelper.getCandidate((long)a.CandidateId).Referer,
                    Email = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    from = ErecruitHelper.GetDateStringFromDateX(f),
                    to = ErecruitHelper.GetDateStringFromDateX(t),
                    TestDate = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getTracker(a.CandidateId.Value, a.BatchId.Value).CurrentStartTime.Value),
                    Score = a.TestScore == null ? "Not Attempted" : a.TestScore + "%",
                    Age = (DateTime.Now.Year - (ErecruitHelper.getCandidateDobx((long)a.CandidateId) != null ? ErecruitHelper.getCandidateDobx((long)a.CandidateId).Value.Year : 0)).ToString(),
                    DateOfBirth = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getCandidate((long)a.CandidateId).DateOfBirth.Value),
                    Sex = ErecruitHelper.getCandidateSex((long)a.CandidateId).ToString(),
                    Passport = ErecruitHelper.getCandidateImgUrl((long)a.CandidateId).ToString(),
                    Alt = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString()

                }).ToList();

            }
            else if (!string.IsNullOrEmpty(dateFrom) && string.IsNullOrEmpty(dateTo))
            {
                var f = ErecruitHelper.GetCurrentDateFromDateString(dateFrom);
                var t = DateTime.Now;
                var tr = _db.T_CTestTracker.Where(s => s.CurrentStartTime.Value.Date >= f.Date && s.CurrentStartTime.Value.Date <= t.Date).OrderByDescending(s => s.CurrentStartTime).Select(s => s.BatchId).Distinct();
                var bs = _db.T_BatchSet.Where(s => tr.Contains(s.BatchId)).ToList();
                TR = bs.Select(a => new TestReportModel
                {
                    ID = (long)a.CandidateId,
                    Code = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString(),
                    FirstName = ErecruitHelper.getCandidateFirstName((long)a.CandidateId).ToString(),
                    LastName = ErecruitHelper.getCandidateLastName((long)a.CandidateId).ToString(),
                    Qualification = ErecruitHelper.getCandidate((long)a.CandidateId).Degree,
                    Grade = ErecruitHelper.getCandidate((long)a.CandidateId).ClassOfDegree,
                    Contact = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    Refferal = ErecruitHelper.getCandidate((long)a.CandidateId).Referer,
                    Email = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    from = ErecruitHelper.GetDateStringFromDateX(f),
                    to = ErecruitHelper.GetDateStringFromDateX(t),
                    TestDate = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getTracker(a.CandidateId.Value, a.BatchId.Value).CurrentStartTime.Value),
                    Score = a.TestScore == null ? "Not Attempted" : a.TestScore + "%",
                    Age = (DateTime.Now.Year - (ErecruitHelper.getCandidateDobx((long)a.CandidateId) != null ? ErecruitHelper.getCandidateDobx((long)a.CandidateId).Value.Year : 0)).ToString(),
                    DateOfBirth = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getCandidate((long)a.CandidateId).DateOfBirth.Value),
                    Sex = ErecruitHelper.getCandidateSex((long)a.CandidateId).ToString(),
                    Passport = ErecruitHelper.getCandidateImgUrl((long)a.CandidateId).ToString(),
                    Alt = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString()

                }).ToList();
            }
            else
            {
                var f = DateTime.Now;
                var tr = _db.T_CTestTracker.Where(s => s.CurrentStartTime.Value.Date == f.Date).OrderByDescending(s=>s.CurrentStartTime).Select(s => s.BatchId).Distinct();
                var bs = _db.T_BatchSet.Where(s => tr.Contains(s.BatchId)).ToList();
                TR = bs.Select(a => new TestReportModel
                {
                    ID = (long)a.CandidateId,
                    Code = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString(),
                    FirstName = ErecruitHelper.getCandidateFirstName((long)a.CandidateId).ToString(),
                    LastName = ErecruitHelper.getCandidateLastName((long)a.CandidateId).ToString(),
                    Qualification = ErecruitHelper.getCandidate((long)a.CandidateId).Degree,
                    Grade = ErecruitHelper.getCandidate((long)a.CandidateId).ClassOfDegree,
                    Contact = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    Refferal = ErecruitHelper.getCandidate((long)a.CandidateId).Referer,
                    Email = ErecruitHelper.getCandidate((long)a.CandidateId).Email,
                    from = ErecruitHelper.GetDateStringFromDateX(f),

                    TestDate = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getTracker(a.CandidateId.Value, a.BatchId.Value).CurrentStartTime.Value),
                    Score = a.TestScore == null ? "Not Attempted" : a.TestScore + "%",
                    Age = (DateTime.Now.Year - (ErecruitHelper.getCandidateDobx((long)a.CandidateId) != null ? ErecruitHelper.getCandidateDobx((long)a.CandidateId).Value.Year : 0)).ToString(),
                    DateOfBirth = ErecruitHelper.GetDateStringFromDateX(ErecruitHelper.getCandidate((long)a.CandidateId).DateOfBirth.Value),
                    Sex = ErecruitHelper.getCandidateSex((long)a.CandidateId).ToString(),
                    Passport = ErecruitHelper.getCandidateImgUrl((long)a.CandidateId).ToString(),
                    Alt = ErecruitHelper.getCandidateCode((long)a.CandidateId).ToString()

                }).ToList();
            }

            return TR;
        }

        public List<BatchReport> BatchReport(long tid, DateTime? fr, DateTime? to, long tenantid)
        {

            var TR = new List<BatchReport>();

            // var cutoff = _db.T_Settings.FirstOrDefault(s => s.SettingsName == "CUT_OFF_MARK").SettingsValue;
            int countP = 0;
            var countF = 0;



            if (tid > 0 && fr == null && to == null)
            {
                TR.AddRange(_db.BatchResult(tid,tenantid).Select(s => new BatchReport
                {
                    BatchName = s.BATCH_NAME,
                    username = s.Username,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyy"),
                    TotalPartial = s.Partial.ToString(),
                    Cutoff = s.CutOff.ToString(),
                    Passed = s.Percentage >= s.CutOff ? 1 : 0,
                    Failed = s.Percentage < s.CutOff ? 1 : 0
                }));
            }
            else if (tid > 0 && fr != null && to == null)
            {
                TR.AddRange(_db.BatchResultByBatchNTime(tid, fr.Value, DateTime.Now, tenantid).Select(s => new BatchReport
                {

                    BatchName = s.BATCH_NAME,
                    username = s.Username,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    TotalPartial = s.Partial.ToString(),
                    Cutoff = s.CutOff.ToString(),
                    Passed = s.Percentage >= s.CutOff ? 1 : 0,
                    Failed = s.Percentage < s.CutOff ? 1 : 0
                }));
            }
            else if (tid > 0 && fr == null && to != null)
            {
                TR.AddRange(_db.BatchResultByBatchNTime(tid, DateTime.Now, to.Value, tenantid).Select(s => new BatchReport
                {

                    BatchName = s.BATCH_NAME,
                    username = s.Username,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    TotalPartial = s.Partial.ToString(),
                    Cutoff = s.CutOff.ToString(),
                    Passed = s.Percentage >= s.CutOff ? 1 : 0,
                    Failed = s.Percentage < s.CutOff ? 1 : 0
                }));
            }
            else if (tid > 0 && fr != null && to != null)
            {
                TR.AddRange(_db.BatchResultByBatchNTime(tid, fr.Value, to.Value, tenantid).Select(s => new BatchReport
                {

                    BatchName = s.BATCH_NAME,
                    username = s.Username,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    TotalCorrect = s.Correct.ToString(),

                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    TotalPartial = s.Partial.ToString(),
                    Cutoff = s.CutOff.ToString(),
                    Passed = s.Percentage >= s.CutOff ? 1 : 0,
                    Failed = s.Percentage < s.CutOff ? 1 : 0
                }));
            }
            else
            {
                TR.AddRange(_db.BatchResultByTime(fr.Value, to.Value, tenantid).Select(s => new BatchReport
                {

                    BatchName = s.BATCH_NAME,
                    username = s.Username,
                    FirstName = s.FIrst_Name,
                    LastName = s.Last_Name,
                    TotalCorrect = s.Correct.ToString(),
                    TotalWrong = s.Wrong.ToString(),
                    TotalUnanswered = s.Unanswered.ToString(),
                    TotalQuestions = s.TotalQuestion.ToString(),
                    Percentage = s.Percentage.ToString(),
                    DateMarked = s.DateLogged.Value.ToString("dd/MM/yyyy"),
                    TotalPartial = s.Partial.ToString(),
                    Cutoff = s.CutOff.ToString(),
                    Passed = s.Percentage >= s.CutOff ? 1 : 0,
                    Failed = s.Percentage < s.CutOff ? 1 : 0
                }));
            }

            return TR;
        }
    }
}