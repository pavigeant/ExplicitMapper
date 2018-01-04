using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mapper.Rules;

namespace Mapper
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Provides a shortcut to avoid creating a target object before mapping.
        /// The <typeparamref name="TTarget"/> must have a parameterless public constructor.
        /// </summary>
        /// <typeparam name="TSource">The source type to map.</typeparam>
        /// <typeparam name="TTarget">The target type to be map.</typeparam>
        /// <param name="map">The map being invoked.</param>
        /// <param name="source">The source item that will be map.</param>
        /// <returns>A new instance of <typeparamref name="TTarget"/> with the mapping applied.</returns>
        public static TTarget Map<TSource, TTarget>(this IMap<TSource, TTarget> map, TSource source)
            where TTarget : new()
        {
            var target = new TTarget();
            map.Map(source, target);
            return target;
        }

        public static void For<TSource, TTarget, TTargetProperty>(
            this BaseMap<TSource, TTarget> map,
            Expression<Func<TTarget, TTargetProperty>> property,
            Func<TSource, TTargetProperty> func)
        {
            map.Rules.Add(new PropertyRule<TSource, TTarget, TTargetProperty>(property, func));
        }

        public static void For<TSource, TSourceProperty, TSourceItem, TTarget, TTargetProperty, TTargetItem>(
            this BaseMap<TSource, TTarget> map,
            Expression<Func<TTarget, TTargetProperty>> property,
            Func<TSource, TSourceProperty> sourceEnumerable,
            IMap<TSourceItem, TTargetItem> childMap)
            where TSourceProperty : IEnumerable<TSourceItem>
            where TTargetProperty : IList<TTargetItem>
            where TTargetItem : new()
        {
            map.Rules.Add(new ListMapRule<TSource, TSourceProperty, TSourceItem, TTarget, TTargetProperty, TTargetItem>(property, sourceEnumerable, childMap));
        }

        public static void Ignore<TSource, TTarget, TTargetProperty>(
            this BaseMap<TSource, TTarget> map,
            Expression<Func<TTarget, TTargetProperty>> property)
        {
            map.Rules.Add(new IgnoreRule<TSource, TTarget, TTargetProperty>(property));
        }
    }
}