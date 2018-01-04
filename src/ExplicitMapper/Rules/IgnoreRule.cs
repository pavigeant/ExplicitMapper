using System;
using System.Linq.Expressions;

namespace Mapper.Rules
{
    public class IgnoreRule<TSource, TTarget, TTargetProperty> : BaseRule<TSource, TTarget, TTargetProperty>
    {
        public IgnoreRule(Expression<Func<TTarget, TTargetProperty>> property)
            : base(property)
        {
        }

        public override void Apply(TSource source, TTarget target)
        {
            // Do nothing
        }
    }
}