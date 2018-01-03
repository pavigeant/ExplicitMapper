using System;
using System.Linq.Expressions;

namespace Mapper.Maps
{
    public class PropertyMap<TSource, TTarget, TTargetProperty> : BaseMap<TSource, TTarget>
    {
        private readonly Expression<Func<TTarget, TTargetProperty>> _property;
        private readonly Func<TSource, TTargetProperty> _func;

        public PropertyMap(Expression<Func<TTarget, TTargetProperty>> property, Func<TSource, TTargetProperty> func)
        {
            _property = property;
            _func = func;
        }

        protected override void Apply(TSource source, TTarget target)
        {
            _property.SetPropertyValue(target, _func(source));
        }
    }
}