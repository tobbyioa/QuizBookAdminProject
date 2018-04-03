using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Linq;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using QuizBook.Helpers;
using System.Linq.Expressions;


namespace QuizBook
{
    partial class QuizBookDbEntities1
    {

       
        public override int SaveChanges()
        {
            var oc = this as IObjectContextAdapter;

            IEnumerable<ObjectStateEntry> changes = oc.ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);

            foreach (ObjectStateEntry stateEntryEntity in changes)
            {
                if (!stateEntryEntity.IsRelationship && stateEntryEntity.Entity != null && !(stateEntryEntity.Entity is AuditRecord || stateEntryEntity.Entity is AuditRecordField))
                {
                    StartAudit(stateEntryEntity);
                }
            }
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private void StartAudit(ObjectStateEntry entry)
        {

            //object target = CloneEntity((EntityObject)entry.Entity);


            var auditTrail = new AuditRecord();
            try
            {
                var b = SessionHelper.FetchEmail(System.Web.HttpContext.Current.Session);
                if (string.IsNullOrEmpty(b))
                {
                    auditTrail.UserName = "";
                }
                else
                {
                    auditTrail.UserName = b.Split('@')[0];//HttpContext.Current.Session["FullName"].ToString();
                }
            }
            catch (NullReferenceException)
            {

                auditTrail.UserName = "";
            }


            auditTrail.TableName = entry.EntitySet.Name;
            auditTrail.AuditDate = DateTime.Now;

            //foreach (string propName in entry.GetModifiedProperties())
            //{
            var detail = LoadEntiyProperty(entry, auditTrail);
            this.AuditRecords.Add(detail);
            //this.AddToAuditTrails(detail);
            //}
        }

        private AuditRecord LoadEntiyProperty(ObjectStateEntry entry, AuditRecord auditTrail)
        {
            //  var auditTrailDetail = new AuditTrailDetail();

            if (entry.State == EntityState.Added)
            {
                //entry is Added 
                // continue and get property list
                var currentValues = entry.CurrentValues;
                for (var i = 0; i < currentValues.FieldCount; i++)
                {
                    IsCoreType(currentValues[i].GetType());
                    {
                        var auditTrailDetail = new AuditRecordField();
                        auditTrailDetail.MemberName = currentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
                        auditTrailDetail.NewValue = (currentValues[i].ToString());
                        auditTrail.AuditRecordFields.Add(auditTrailDetail);
                    }
                }
                auditTrail.Action = ChangeAction.Insert.ToString();
            }

            if (entry.State == EntityState.Modified)
            {
                //entry is deleted
                var currentValues = entry.CurrentValues;
                var editedvalues = entry.OriginalValues;
                for (var i = 0; i < currentValues.FieldCount; i++)
                {
                    var auditTrailDetail = new AuditRecordField();
                    IsCoreType(currentValues[i].GetType());
                    {
                        auditTrailDetail.MemberName = currentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
                        auditTrailDetail.NewValue = (currentValues[i].ToString());
                        //auditTrail.AuditTrailDetails.Add(auditTrailDetail);
                    }
                    IsCoreType(editedvalues[i].GetType());
                    {
                        auditTrailDetail.OldValue = (editedvalues[i].ToString());
                    }
                    auditTrail.AuditRecordFields.Add(auditTrailDetail);

                }



                auditTrail.Action = ChangeAction.Update.ToString();
            }

            if (entry.State == EntityState.Deleted)
            {
                //entry is modified
                var deletedvalues = entry.OriginalValues;
                for (var i = 0; i < deletedvalues.FieldCount; i++)
                {
                    IsCoreType(deletedvalues[i].GetType());
                    {
                        var auditTrailDetail = new AuditRecordField();
                        auditTrailDetail.MemberName = deletedvalues.GetName(i);//.FieldMetadata[i].FieldType.Name;
                        auditTrailDetail.OldValue = deletedvalues.GetValue(i).ToString();
                        auditTrail.AuditRecordFields.Add(auditTrailDetail);
                    }
                }

                auditTrail.Action = ChangeAction.Delete.ToString();
            }
            //auditTrail.AuditTrailDetails.Add(auditTrailDetail);
            return auditTrail;
            //}
        }

        private AuditRecordField GetEntryValueInString(ObjectStateEntry entry, bool isOrginal)
        {
            var auditTrailDetail = new AuditRecordField();
            //entry.CurrentValues
            //entry.OriginalValues.
            var rt = entry.GetModifiedProperties();
            if (entry.Entity is EntityObject)
            {
                foreach (string propName in entry.GetModifiedProperties())
                {

                }
            }
            return auditTrailDetail;

        }

        public bool IsCoreType(Type type)
        {
            return (type == typeof(string) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64) || type == typeof(decimal) || type == typeof(double) || type == typeof(Boolean) || type == typeof(string) || type == typeof(float) || type == typeof(byte) || type == typeof(char) || type == typeof(Binary) || type == typeof(byte[]) || type == typeof(DateTime) || type == typeof(byte?) || type == typeof(int?) || type == typeof(DateTime?) || type == typeof(decimal?) || type == typeof(double?) || type == typeof(float?));
        }

        private enum ChangeType
        {
            Update,
            Insert,
            Delete
        }

    }
}