using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QuizBook.Helpers
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool asc)
        {
            var type = typeof(T);
            string methodName = asc ? "OrderBy" : "OrderByDescending";
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

        public static IQueryable<T> Like<T>(this IQueryable<T> source, string propertyName, string keyword)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var constant = Expression.Constant("%" + keyword + "%");
            var like = typeof(SqlMethods).GetMethod("Like", new Type[] { typeof(string), typeof(string) });
            MethodCallExpression methodExp = Expression.Call(null, like, propertyAccess, constant);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
            return source.Where(lambda);
           
        }
        public static void DeleteObjects<T>(DbSet<T> set, IEnumerable<T> entities) where T : class
        {
            //foreach (var entity in entities)
            //    set.Remove(entity);
            var e = entities.ToList();
            e.ForEach(x => set.Remove(x));
        }

        public static void InsertAllOnSubmit<T>(DbSet<T> db, List<T> newentities) where T : class
        {
            //var objectSet = db.CreateObjectSet<T>();
            newentities.ForEach(x => db.Add(x));
        }
    }
}