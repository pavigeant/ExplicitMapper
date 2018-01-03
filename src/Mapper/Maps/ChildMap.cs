using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mapper.Maps
{
    public class ChildMap<TSource, TSourceProperty, TSourceItem, TTarget, TTargetProperty, TTargetItem> : BaseMap<TSource, TTarget>
        where TSourceProperty : IEnumerable<TSourceItem>
        where TTargetProperty : IList<TTargetItem>
        where TTargetItem : new()
    {
        private readonly Expression<Func<TTarget, TTargetProperty>> _property;
        private readonly Func<TSource, TSourceProperty> _sourceEnumerable;
        private readonly IMap<TSourceItem, TTargetItem> _childMap;

        public ChildMap(
            Expression<Func<TTarget, TTargetProperty>> property,
            Func<TSource, TSourceProperty> sourceEnumerable,
            IMap<TSourceItem, TTargetItem> childMap)
        {
            _property = property;
            _sourceEnumerable = sourceEnumerable;
            _childMap = childMap;
        }

        protected override void Apply(TSource source, TTarget target)
        {
            var targetList = _property.GetPropertyValue(target);

            foreach (var sourceItem in _sourceEnumerable(source))
            {
                var targetItem = new TTargetItem();
                _childMap.Map(sourceItem, targetItem);
                targetList.Add(targetItem);
            }
        }
    }
}