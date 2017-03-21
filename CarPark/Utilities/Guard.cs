using System;
using System.Linq.Expressions;

namespace CarPark.Utilities
{
    public static class Guard
    {
        public static void NotNull<T>(Expression<Func<T>> expr, T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(GetMemberName(expr), "Cannot be null.");
            }
        }

        private static string GetMemberName<T>(Expression<Func<T>> expr)
        {
            var memberExpression = (MemberExpression)expr.Body;
            var memberName = memberExpression.Member.Name;
            return memberName;
        }

        public static void NotNullOrEmpty(Expression<Func<string>> expr, string text)
        {
            NotNull<string>(expr, text);
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Cannot be an empty string.", GetMemberName(expr));
            }
        }
    }
}