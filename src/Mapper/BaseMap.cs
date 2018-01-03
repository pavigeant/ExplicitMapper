using System.Collections.Generic;

namespace Mapper
{
    public abstract class BaseMap<TSource, TTarget> : IMap<TSource, TTarget>, IMapRule
    {

        public BaseMap()
        {
            Rules = new List<IMapRule>();
        }

        public IList<IMapRule> Rules { get; }

        void IMap.Map(object source, object target) => ((IMapRule)this).Apply(source, target);

        void IMap<TSource, TTarget>.Map(TSource source, TTarget target) => Apply(source, target);

        void IMapRule.Apply(object source, object target)
        {
            if (source is TSource s &&
                target is TTarget t)
            {
                Apply(s, t);
            }
        }

        protected abstract void Apply(TSource source, TTarget target);
    }

    public abstract class Map<TSource, TTarget> : BaseMap<TSource, TTarget>
    {
        protected override void Apply(TSource source, TTarget target)
        {
            foreach (var rule in Rules)
            {
                rule.Apply(source, target);
            }
        }
    }
}