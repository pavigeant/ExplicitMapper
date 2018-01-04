using System;
using System.Linq.Expressions;

namespace Mapper.Rules
{
    public interface IMapRule
    {
        void Apply(object source, object target);
    }

    public abstract class BaseRule<TSource, TTarget, TTargetProperty> : IMapRule
    {
        public BaseRule(Expression<Func<TTarget, TTargetProperty>> property)
        {
            Property = property;
        }

        protected Expression<Func<TTarget, TTargetProperty>> Property { get; }

        public void Apply(object source, object target)
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

        protected abstract void Apply(TSource source, TTarget target);
    }
}
