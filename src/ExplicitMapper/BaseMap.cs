using System;
using System.Collections.Generic;
using Mapper.Rules;

namespace Mapper
{
    public abstract class BaseMap<TSource, TTarget> : IMap<TSource, TTarget>
    {

        public BaseMap()
        {
            Rules = new List<IMapRule<TSource, TTarget>>();
        }

        public IList<IMapRule<TSource, TTarget>> Rules { get; }

        public void Map(object source, object target) => Apply(source, target);

        public void Map(TSource source, TTarget target) => Apply(source, target);

        private void Apply(object source, object target)
        {
            if (source is TSource s)
            {
                if (target is TTarget t)
                    Apply(s, t);
                else
                    throw new InvalidCastException($"{nameof(target)} is not of type {typeof(TTarget)}.");
            }
            else
                throw new InvalidCastException($"{nameof(source)} is not of type {typeof(TSource)}.");
        }

        protected virtual void Apply(TSource source, TTarget target)
        {
            foreach (var rule in Rules)
            {
                rule.Apply(source, target);
            }
        }
    }
}