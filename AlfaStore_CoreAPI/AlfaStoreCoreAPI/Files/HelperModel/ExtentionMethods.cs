using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System;
using DataAccessLayer;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AlfaStoreCoreAPI.Files.HelperModel
{
    public static class ExtentionMethods
    {
        public static Func<T, bool> GetExpression<T>(this T model, List<Filter> filters) where T : IModel
        {
            Expression? body = null;

            foreach (var item in filters)
            {
                //handle nested properties ex (user.role = "admin")
                if (item.prop_name.Contains('.'))
                {
                    var res1 =  CreateNestedExpression(model, item);
                    body = body == null ? res1 : Expression.AndAlso(body, res1);
                    continue;
                }
                var res2 = CreateSimpleExpression(model, item);
                if (res2 != null)
                {
                    body = body == null ? res2 : Expression.AndAlso(body, res2);
                    continue;
                }
                if (item.prop_name.Contains("Contain"))
                {
                    var res3 = CreateContainsExpression(model, item);
                    body = body == null ? res3 : Expression.AndAlso(body, res3);
                    continue;
                }
                if (item.prop_name.Contains("In"))
                {
                    var res4 = CreateInExpression(model, item);
                    body = body == null ? res4 : Expression.AndAlso(body, res4);
                    continue;
                }

            }

            if (body == null)
                return null;

            var predicate = ExpressionCacheHelper.GetPredicate((Expression<Func<T, bool>>)body);
            return predicate;
        }
        /// <summary>
        /// Constructs an expression tree representing an equality comparisons(=, != , >, < ,<=, >=) between property and value.
        /// </summary>
        /// <param name="filter">Contain the property name, value and operator_sign</param>
        /// <returns>An expression tree representing the field list.</returns>
        public static Expression<Func<T, bool>> CreateSimpleExpression<T>(this T model, Filter filter) where T : IModel
        {
            var param = Expression.Parameter(typeof(T), "M");
            var member = Expression.Property(param, filter.prop_name);

            var nullCheck = Expression.Equal(member, Expression.Constant(null));

            var constant = Expression.Constant(filter.value);

            BinaryExpression be = null;       

            if (filter.operator_sign == "=")
                be = Expression.Equal(member, constant);
            if (filter.operator_sign == "!=")
                be = Expression.NotEqual(member, constant);
            if (filter.operator_sign == ">")
                be = Expression.GreaterThan(member, constant);
            if (filter.operator_sign == "<")
                be = Expression.LessThan(member, constant);
            if (filter.operator_sign == ">=")
                be = Expression.GreaterThanOrEqual(member, constant);
            if (filter.operator_sign == "<=")
                be = Expression.LessThanOrEqual(member, constant);
            if (be == null)
                return null;

            var condition = Expression.Condition(nullCheck, Expression.Constant(false), be);

            return Expression.Lambda<Func<T, bool>>(condition, param);
        }
        public static Expression<Func<T, bool>> CreateNestedExpression<T>(this T model, Filter filter)
        {
            var param = Expression.Parameter(typeof(T), "p");
            Expression member = param;
            foreach (var namePart in filter.prop_name.Split('.'))
            {
                member = Expression.Property(member, namePart);
            }
            var constant = Expression.Constant(filter.value);
            var body = Expression.Equal(member, constant);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Expression<Func<T, bool>> CreateInExpression<T>(this T model, Filter filter)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var member = Expression.Property(param, filter.prop_name);
            var propertyType = ((PropertyInfo)member.Member).PropertyType;
            var constant = Expression.Constant(filter.value);
            var body = Expression.Call(typeof(Enumerable), "Contains", new[] { propertyType }, constant, member);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }
       
        public static Expression<Func<T, bool>> CreateContainsExpression<T>(this T model, Filter filter)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var member = Expression.Property(param, filter.prop_name);
            var constant = Expression.Constant(filter.value);
            var body = Expression.Call(member, "Contains", Type.EmptyTypes, constant);
            return Expression.Lambda<Func<T, bool>>(body, param);
        }

    }
}
