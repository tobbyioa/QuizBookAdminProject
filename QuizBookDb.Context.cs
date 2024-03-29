﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class QuizBookDbEntities1 : DbContext
    {
        public QuizBookDbEntities1()
            : base("name=QuizBookDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AuditRecordField> AuditRecordFields { get; set; }
        public DbSet<AuditRecord> AuditRecords { get; set; }
        public DbSet<BatchConfigurationTemp> BatchConfigurationTemps { get; set; }
        public DbSet<BatchScopeContent> BatchScopeContents { get; set; }
        public DbSet<branch_tab> branch_tab { get; set; }
        public DbSet<division_tab> division_tab { get; set; }
        public DbSet<grade_tab> grade_tab { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<region_tab> region_tab { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sector_tab> sector_tab { get; set; }
        public DbSet<T_BackGQuestions> T_BackGQuestions { get; set; }
        public DbSet<T_BackGQuestnGroups> T_BackGQuestnGroups { get; set; }
        public DbSet<T_BackGroundQuestAnswers> T_BackGroundQuestAnswers { get; set; }
        public DbSet<T_Batch> T_Batch { get; set; }
        public DbSet<T_BatchQuestions> T_BatchQuestions { get; set; }
        public DbSet<T_BatchSet> T_BatchSet { get; set; }
        public DbSet<T_Candidate> T_Candidate { get; set; }
        public DbSet<T_CandidateAnswers> T_CandidateAnswers { get; set; }
        public DbSet<T_CandidateTemp> T_CandidateTemp { get; set; }
        public DbSet<T_CTestTracker> T_CTestTracker { get; set; }
        public DbSet<T_EssayQuestions> T_EssayQuestions { get; set; }
        public DbSet<T_MultiintelligencQuizBookDb> T_MultiintelligencQuizBookDb { get; set; }
        public DbSet<T_Option> T_Option { get; set; }
        public DbSet<T_QOptionType> T_QOptionType { get; set; }
        public DbSet<T_Question> T_Question { get; set; }
        public DbSet<T_QuestionsPreambles> T_QuestionsPreambles { get; set; }
        public DbSet<T_QuestionType> T_QuestionType { get; set; }
        public DbSet<T_Reports> T_Reports { get; set; }
        public DbSet<T_Settings> T_Settings { get; set; }
        public DbSet<T_Summary> T_Summary { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<ActiveQuestions_vw> ActiveQuestions_vw { get; set; }
        public DbSet<AllCandidates_vw> AllCandidates_vw { get; set; }
        public DbSet<AuditTrailView> AuditTrailViews { get; set; }
        public DbSet<InactiveQuestions_vw> InactiveQuestions_vw { get; set; }
        public DbSet<Questions_vw> Questions_vw { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<AllMyCandidate> AllMyCandidates { get; set; }
        public DbSet<TestReportAnswer> TestReportAnswers { get; set; }
        public DbSet<TestResultReport> TestResultReports { get; set; }
        public DbSet<TestReportSummary> TestReportSummaries { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    
        public virtual int ApproveAll_sp(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ApproveAll_sp", usernameParameter);
        }
    
        public virtual ObjectResult<BatchResultByCondition_sp_Result> BatchResultByCondition_sp(string condition, string conditionID)
        {
            var conditionParameter = condition != null ?
                new ObjectParameter("condition", condition) :
                new ObjectParameter("condition", typeof(string));
    
            var conditionIDParameter = conditionID != null ?
                new ObjectParameter("conditionID", conditionID) :
                new ObjectParameter("conditionID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BatchResultByCondition_sp_Result>("BatchResultByCondition_sp", conditionParameter, conditionIDParameter);
        }
    
        public virtual ObjectResult<BatchResultByConditionNTime_sp_Result> BatchResultByConditionNTime_sp(string condition, string conditionID, Nullable<System.DateTime> dateF, Nullable<System.DateTime> dateT)
        {
            var conditionParameter = condition != null ?
                new ObjectParameter("condition", condition) :
                new ObjectParameter("condition", typeof(string));
    
            var conditionIDParameter = conditionID != null ?
                new ObjectParameter("conditionID", conditionID) :
                new ObjectParameter("conditionID", typeof(string));
    
            var dateFParameter = dateF.HasValue ?
                new ObjectParameter("dateF", dateF) :
                new ObjectParameter("dateF", typeof(System.DateTime));
    
            var dateTParameter = dateT.HasValue ?
                new ObjectParameter("dateT", dateT) :
                new ObjectParameter("dateT", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BatchResultByConditionNTime_sp_Result>("BatchResultByConditionNTime_sp", conditionParameter, conditionIDParameter, dateFParameter, dateTParameter);
        }
    
        public virtual int DisApproveAll_sp(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DisApproveAll_sp", usernameParameter);
        }
    
        public virtual ObjectResult<GetCandMark_sp_Result> GetCandMark_sp(Nullable<long> batchId, Nullable<long> candId)
        {
            var batchIdParameter = batchId.HasValue ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(long));
    
            var candIdParameter = candId.HasValue ?
                new ObjectParameter("candId", candId) :
                new ObjectParameter("candId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCandMark_sp_Result>("GetCandMark_sp", batchIdParameter, candIdParameter);
        }
    
        public virtual ObjectResult<LoadCandidateQuestion_sp_Result> LoadCandidateQuestion_sp(Nullable<long> candId)
        {
            var candIdParameter = candId.HasValue ?
                new ObjectParameter("candId", candId) :
                new ObjectParameter("candId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoadCandidateQuestion_sp_Result>("LoadCandidateQuestion_sp", candIdParameter);
        }
    
        public virtual int MarkCandidatquizUser_sp(Nullable<long> batchId, Nullable<long> candId)
        {
            var batchIdParameter = batchId.HasValue ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(long));
    
            var candIdParameter = candId.HasValue ?
                new ObjectParameter("candId", candId) :
                new ObjectParameter("candId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MarkCandidatquizUser_sp", batchIdParameter, candIdParameter);
        }
    
        public virtual int MarkUnAnswered_sp(Nullable<long> batchId, Nullable<long> candId)
        {
            var batchIdParameter = batchId.HasValue ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(long));
    
            var candIdParameter = candId.HasValue ?
                new ObjectParameter("candId", candId) :
                new ObjectParameter("candId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MarkUnAnswered_sp", batchIdParameter, candIdParameter);
        }
    
        public virtual ObjectResult<SearchActiveQuestion_Result> SearchActiveQuestion(string searchString)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchActiveQuestion_Result>("SearchActiveQuestion", searchStringParameter);
        }
    
        public virtual ObjectResult<SearchCandidate_Result> SearchCandidate(string searchString)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchCandidate_Result>("SearchCandidate", searchStringParameter);
        }
    
        public virtual ObjectResult<SearchInactiveQuestion_Result> SearchInactiveQuestion(string searchString)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchInactiveQuestion_Result>("SearchInactiveQuestion", searchStringParameter);
        }
    
        public virtual ObjectResult<SearchQuestion_Result> SearchQuestion(string searchString)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchQuestion_Result>("SearchQuestion", searchStringParameter);
        }
    
        public virtual ObjectResult<CandidatesByTenant_Result> CandidatesByTenant(Nullable<long> searchString)
        {
            var searchStringParameter = searchString.HasValue ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CandidatesByTenant_Result>("CandidatesByTenant", searchStringParameter);
        }
    
        public virtual ObjectResult<SearchTenantCandidate_Result> SearchTenantCandidate(Nullable<long> tenantId, string searchString)
        {
            var tenantIdParameter = tenantId.HasValue ?
                new ObjectParameter("tenantId", tenantId) :
                new ObjectParameter("tenantId", typeof(long));
    
            var searchStringParameter = searchString != null ?
                new ObjectParameter("SearchString", searchString) :
                new ObjectParameter("SearchString", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchTenantCandidate_Result>("SearchTenantCandidate", tenantIdParameter, searchStringParameter);
        }
    
        public virtual ObjectResult<IndividualTestResult_sp_Result> IndividualTestResult_sp(Nullable<long> batchId, Nullable<long> candId, Nullable<long> tenId)
        {
            var batchIdParameter = batchId.HasValue ?
                new ObjectParameter("BatchId", batchId) :
                new ObjectParameter("BatchId", typeof(long));
    
            var candIdParameter = candId.HasValue ?
                new ObjectParameter("candId", candId) :
                new ObjectParameter("candId", typeof(long));
    
            var tenIdParameter = tenId.HasValue ?
                new ObjectParameter("tenId", tenId) :
                new ObjectParameter("tenId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IndividualTestResult_sp_Result>("IndividualTestResult_sp", batchIdParameter, candIdParameter, tenIdParameter);
        }
    
        public virtual ObjectResult<BatchResult_Result> BatchResult(Nullable<long> condition, Nullable<long> tenantId)
        {
            var conditionParameter = condition.HasValue ?
                new ObjectParameter("condition", condition) :
                new ObjectParameter("condition", typeof(long));
    
            var tenantIdParameter = tenantId.HasValue ?
                new ObjectParameter("tenantId", tenantId) :
                new ObjectParameter("tenantId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BatchResult_Result>("BatchResult", conditionParameter, tenantIdParameter);
        }
    
        public virtual ObjectResult<BatchResultByBatchNTime_Result> BatchResultByBatchNTime(Nullable<long> condition, Nullable<System.DateTime> dateF, Nullable<System.DateTime> dateT, Nullable<long> tenantId)
        {
            var conditionParameter = condition.HasValue ?
                new ObjectParameter("condition", condition) :
                new ObjectParameter("condition", typeof(long));
    
            var dateFParameter = dateF.HasValue ?
                new ObjectParameter("dateF", dateF) :
                new ObjectParameter("dateF", typeof(System.DateTime));
    
            var dateTParameter = dateT.HasValue ?
                new ObjectParameter("dateT", dateT) :
                new ObjectParameter("dateT", typeof(System.DateTime));
    
            var tenantIdParameter = tenantId.HasValue ?
                new ObjectParameter("tenantId", tenantId) :
                new ObjectParameter("tenantId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BatchResultByBatchNTime_Result>("BatchResultByBatchNTime", conditionParameter, dateFParameter, dateTParameter, tenantIdParameter);
        }
    
        public virtual ObjectResult<BatchResultByTime_Result> BatchResultByTime(Nullable<System.DateTime> dateF, Nullable<System.DateTime> dateT, Nullable<long> tenantId)
        {
            var dateFParameter = dateF.HasValue ?
                new ObjectParameter("dateF", dateF) :
                new ObjectParameter("dateF", typeof(System.DateTime));
    
            var dateTParameter = dateT.HasValue ?
                new ObjectParameter("dateT", dateT) :
                new ObjectParameter("dateT", typeof(System.DateTime));
    
            var tenantIdParameter = tenantId.HasValue ?
                new ObjectParameter("tenantId", tenantId) :
                new ObjectParameter("tenantId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BatchResultByTime_Result>("BatchResultByTime", dateFParameter, dateTParameter, tenantIdParameter);
        }
    }
}
