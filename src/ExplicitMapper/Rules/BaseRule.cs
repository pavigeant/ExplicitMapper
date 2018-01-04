using System;
using System.Linq.Expressions;

namespace Mapper.Rules
{
    public interface IMapRule<TSource, TTarget>
    {
        void Apply(TSource source, TTarget target);
    }

    public abstract class BaseRule<TSource, TTarget, TTargetProperty> : IMapRule<TSource, TTarget>
    {
        public BaseRule(Expression<Func<TTarget, TTargetProperty>> property)
        {
            Property = property;
        }

        protected Expression<Func<TTarget, TTargetProperty>> Property { get; }

        public abstract void Apply(TSource source, TTarget target);
    }
}
