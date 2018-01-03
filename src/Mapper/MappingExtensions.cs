using System;
using System.Linq.Expressions;
using Mapper.Maps;

namespace Mapper
{
    public static class MappingExtensions
    {
        public static void For<TSource, TTarget, TTargetProperty>(
            this Map<TSource, TTarget> map, 
            Expression<Func<TTarget, TTargetProperty>> property, 
            Func<TSource, TTargetProperty> func)
        {
            map.Rules.Add(new PropertyMap<TSource, TTarget, TTargetProperty>(property, func));
        }
    }
}