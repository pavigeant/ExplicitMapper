using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mapper
{
    public static class ReflectionExtensions
    {
        public static void SetPropertyValue<T, TValue>(this Expression<Func<T, TValue>> memberLamda, T target, TValue value)
        {
            if (memberLamda.Body is MemberExpression body)
            { 
                if(body.Member is PropertyInfo property)
                    property.SetValue(target, value);
                else if(body.Member is FieldInfo field)
                    field.SetValue(target, value);
            }

        }

        public static TValue GetPropertyValue<T, TValue>(this Expression<Func<T, TValue>> memberLamda, T target)
        {
            if (memberLamda.Body is MemberExpression body)
            {
                if (body.Member is PropertyInfo property)
                    return (TValue)property.GetValue(target);
                else if (body.Member is FieldInfo field)
                    return (TValue)field.GetValue(target);
            }

            return default;
        }
    }
}