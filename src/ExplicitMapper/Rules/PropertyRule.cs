using System;
using System.Linq.Expressions;

namespace Mapper.Rules
{
    public class PropertyRule<TSource, TTarget, TTargetProperty> : BaseRule<TSource, TTarget, TTargetProperty>
    {
        private readonly Func<TSource, TTargetProperty> _func;

        public PropertyRule(Expression<Func<TTarget, TTargetProperty>> property, Func<TSource, TTargetProperty> func)
            : base(property)
        {
            _func = func;
        }

        public override void Apply(TSource source, TTarget target)
        {
            Property.SetPropertyValue(target, _func(source));
        }
    }
}