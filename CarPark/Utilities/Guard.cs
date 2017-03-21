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
                var memberExpression = (MemberExpression)expr.Body;
                var memberName = memberExpression.Member.Name;
                throw new ArgumentNullException(memberName, "Cannot be null.");
            }
        }

        public static void NotNullOrEmpty(string text)
        {
            //NotNull();
            //if (string.IsNullOrEmpty(text))
            //{
            //    throw new 
            //}
        }
    }
}